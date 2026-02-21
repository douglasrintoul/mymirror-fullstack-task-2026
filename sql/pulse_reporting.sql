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

-- TODO: Query that matches /api/pulse/summary

-- TODO: Query to return the PulseEntry total counts by PulseCategory