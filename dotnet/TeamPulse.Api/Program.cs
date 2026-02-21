using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamPulse.Application;
using TeamPulse.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TeamPulseDbContext>(options =>
    options.UseInMemoryDatabase("TeamPulseInMemoryDb"));

// Service Mappings
builder.Services.AddScoped<IPulseRepository, PulseRepository>();

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<SubmitTeamPulseCommand>());

// CORS - Allow all origins for this example
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TeamPulseDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (error?.Error is BadHttpRequestException)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new { error = "Invalid request body." });
        }
        else
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });
        }
    });
});

// Using inline endpoint declarations since there are only 3 endpoints
app.MapPost("/api/pulse", async (SubmitTeamPulseDTO dto, IMediator mediator) =>
{
    var validationResults = new List<ValidationResult>();
    if (!Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true))
    {
        var errors = validationResults.Select(r => r.ErrorMessage).ToList();
        return Results.BadRequest(new SubmitTeamPulseResponseDTO { Success = false, Error = string.Join("; ", errors) });
    }

    var result = await mediator.Send(new SubmitTeamPulseCommand { Request = dto });
    return result.Success ? Results.Created($"/api/pulse/{result.Id}", result) : Results.BadRequest(result);
});

app.MapGet("/api/pulse/summary", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetTeamPulseSummaryQuery());
    return Results.Ok(result);
});

app.MapGet("/api/pulse/categories", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetTeamPulseCategoriesQuery());
    return Results.Ok(result);
});

app.Run();
