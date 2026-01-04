# PortalCliente - Self-Service Billing and Agreement Portal

An ASP.NET MVC web application built for customer self-service in debt negotiation and billing retrieval. The portal lets customers authenticate from a unique link, review their outstanding items, choose a payment plan, and generate a boleto (PDF/JPG). It also tracks activity and supports reporting for operations teams.

## What this project does
- Secure entry via link token + last digits of CPF/CNPJ for quick verification.
- Presents debt details and payment options (single payment or installment plans).
- Generates boleto documents from HTML templates and exports as PDF or JPG.
- Captures user actions (access, authentication, agreement created, callback requested).
- Exports operational reports and contact lists for follow-up.
- Imports remittance XML files into the database on a scheduled loop.

## User flow (high level)
1. Customer receives a unique link and lands on the portal.
2. Customer confirms identity using the last digits of CPF/CNPJ.
3. Customer selects a payment option and a due date.
4. System generates a boleto (HTML -> PDF/JPG) and logs the agreement.
5. Optional: customer requests a callback instead of generating a boleto.

## Solution layout
- `PortalCliente.Web`: ASP.NET MVC 5 app (controllers, views, static assets).
- `PortalCliente.BLL`: business logic layer with domain services.
- `PortalCliente.DAL`: data access layer with stored procedure mapping.
- `PortalCliente.DTO`: data transfer objects and binding attributes.
- `PortalCliente.ImportaParqueGrafico`: console app that imports XML remessa files.
- `PortalCliente.Web.Tests`: MSTest unit tests for web controllers.
- `PortalCliente.Remessa.DTO`: supporting DTOs for remessa payloads (not in the .sln).

## Architecture highlights
- Layered architecture (MVC UI -> BLL -> DAL -> SQL Server).
- DTOs decorated with custom attributes define stored procedure bindings.
- Generic DAL base class handles CRUD via ADO.NET + stored procedures.
- HTML boleto templates are stored in `PortalCliente.Web/Content/Boletos` and populated at runtime.
- Telemetry is wired via Application Insights for web request tracking.

## Tech stack
- C#, .NET
- ASP.NET MVC 5, Razor views, Bundling/Minification
- SQL Server (ADO.NET + stored procedures)
- Application Insights
- jQuery 1.10, Bootstrap 3, PagedList
- MSTest for unit testing

## Notable implementation details
- Boleto generation uses HTML templates + conversion libraries to produce PDF/JPG outputs.
- Remessa import job watches a network share and ingests XML payloads into domain tables.
- Reporting endpoints export operational data to flat files on a network share.
- Link-based access uses hex tokens to map to server-side records.

## How to run (local)
1. Open `PortalCliente.sln` in Visual Studio 2015 or newer.
2. Restore NuGet packages.
3. Provide third-party DLLs referenced by local paths (Winnovative HtmlConvert, WebsitesScreenshot).
4. Configure database access (connection strings are currently in `PortalCliente.DAL/Conexao.cs`).
5. Run `PortalCliente.Web`.

## Tests
Run the MSTest project `PortalCliente.Web.Tests`.

## Before publishing to GitHub (important)
- Remove or replace credentials and internal IPs from `PortalCliente.DAL/Conexao.cs`.
- Review `PortalCliente.Web/Images` and any PDF/JPG outputs for sensitive data.
- Review any network-share paths in the console app and report exports.

## Why this matters
This project demonstrates full-stack delivery of a real-world billing portal: web UX, secure access flow, document generation, data ingestion pipelines, and operational reporting. It showcases layered architecture, stored procedure integration, and practical business automation in a legacy .NET environment.
