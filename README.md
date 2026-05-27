## Database Migration

This project uses Entity Framework Core Code-First migrations.

---

## Using Visual Studio Package Manager Console

Open:

`Tools` → `NuGet Package Manager` → `Package Manager Console`

### Apply Existing Migrations

```powershell
Update-Database
```

### Create a New Migration

```powershell
Add-Migration MigrationName
```

Example:

```powershell
Add-Migration InitialCreate
```

### Create Migration for MySQL

```powershell
Add-Migration MigrationName -OutputDir Migrations/MySql
```

### Create Migration for SQL Server

```powershell
Add-Migration MigrationName -OutputDir Migrations/MsSql
```

---

## Using .NET CLI / Terminal

### Apply Existing Migrations

```bash
dotnet ef database update
```

### Create a New Migration

```bash
dotnet ef migrations add MigrationName
```

Example:

```bash
dotnet ef migrations add InitialCreate
```

### Create Migration for MySQL

```bash
dotnet ef migrations add MigrationName --output-dir Migrations/MySql
```

### Create Migration for SQL Server

```bash
dotnet ef migrations add MigrationName --output-dir Migrations/MsSql
```
