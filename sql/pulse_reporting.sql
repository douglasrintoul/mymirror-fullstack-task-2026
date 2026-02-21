CREATE TABLE PulseCategory (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name VARCHAR(100) NOT NULL
);

CREATE TABLE PulseEntry (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    Comment NVARCHAR(500) NULL,
    -- Validation here isn't strictly necessary, but if it's a strong business rule
    -- and unlikely to change then it's a good extra line of defence.
    Score INT NOT NULL CHECK (Score >= 1 AND Score <= 5),
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_PulseEntry_PulseCategory
        FOREIGN KEY (CategoryId) REFERENCES PulseCategory(Id)
);

-- /api/pulse/summary Query
SELECT
    COUNT(*) AS TotalCount,
    -- The inner cast ensures correct math, the outer cast rounds to 2 decimal places
    CAST(AVG(CAST(Score AS DECIMAL(3,2))) AS DECIMAL(3,2)) AS AverageScore,
    -- Using this approach with Case only requires a single scan of the table (I believe),
    -- but wouldn't be ideal if the score range was likely to change.
    -- Also, to be honest I haven't worked that much with SQL pivots, so this is a 
    -- more comfortable approach for me.
    COUNT(CASE WHEN Score = 1 THEN 1 END) AS Score1,
    COUNT(CASE WHEN Score = 2 THEN 1 END) AS Score2,
    COUNT(CASE WHEN Score = 3 THEN 1 END) AS Score3,
    COUNT(CASE WHEN Score = 4 THEN 1 END) AS Score4,
    COUNT(CASE WHEN Score = 5 THEN 1 END) AS Score5
FROM PulseEntry;

-- Query to return the PulseEntry total counts by PulseCategory
SELECT
    c.Id,
    c.Name,
    COUNT (e.Id) AS TotalCount
FROM PulseCategory c
LEFT JOIN PulseEntry e ON e.CategoryId = c.Id
GROUP BY c.Id, c.Name;