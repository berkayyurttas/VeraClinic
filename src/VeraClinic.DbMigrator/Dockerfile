FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["common.props", "."]
COPY ["src/VeraClinic.DbMigrator/VeraClinic.DbMigrator.csproj", "src/VeraClinic.DbMigrator/"]
COPY ["src/VeraClinic.Domain/VeraClinic.Domain.csproj", "src/VeraClinic.Domain/"]
COPY ["src/VeraClinic.Domain.Shared/VeraClinic.Domain.Shared.csproj", "src/VeraClinic.Domain.Shared/"]
COPY ["src/VeraClinic.EntityFrameworkCore/VeraClinic.EntityFrameworkCore.csproj", "src/VeraClinic.EntityFrameworkCore/"]

RUN dotnet restore "src/VeraClinic.DbMigrator/VeraClinic.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/VeraClinic.DbMigrator"
RUN dotnet publish "VeraClinic.DbMigrator.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VeraClinic.DbMigrator.dll"]