CoursesManager

Inlämningsuppgift i kursen Datalagring.

Projektet består av:

- ASP.NET Core Minimal API
- Entity Framework Core (Code First + Migrations)
- SQL Server (LocalDB)
- React (Vite) frontend
- Enhetstester med xUnit

Systemet hanterar kurser, kurstillfällen, deltagare, lärare och registreringar.

Projektet är uppbyggt enligt Clean Architecture med lager för:
Domain, Application, Infrastructure, Presentation och Tests.
_______________________________________________________________________________

Starta projektet

1. Kör "Update-Database" vid första start.
2. Starta backend med F5 i Visual Studio.
3. Gå till frontend-mappen i terminal och ange:
   - "npm install"
   - "npm run dev"
4. Frontend körs på http://localhost:5173
