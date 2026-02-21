# Overview
Thank you for inviting me to complete this exercise! In order to run the solution, you need to run both the TeamPulse.Api dotnet project and the Vite server.

The Nuxt app was developed using Node version 24.11.0.

## How To Run
Run these commands from the project root:

API:
`cd dotnet && dotnet run --project TeamPulse.Api`

Frontend:
```
cd frontend/team-pulse
cp .env.example .env
npm i
npm run dev
```

# Assumptions / Limitations
This MVP doesn't include any form of team grouping or project selection - obviously, a real version of this application would handle pulses for different teams, different projects, and each Team Pulse would be a collection of Pulse submissions. The Team Pulse Summary page doesn't allow you to see the summary for a specific category either - in fact, as per the spec, it doesn't consider the category at all.
