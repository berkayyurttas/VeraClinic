FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 1. Ortak dosyaları kopyala
COPY ["common.props", "."]

# 2. .csproj dosyalarını ve Sertifikayı kopyala
COPY ["src/VeraClinic.HttpApi.Host/VeraClinic.HttpApi.Host.csproj", "VeraClinic.HttpApi.Host/"]
COPY ["src/VeraClinic.HttpApi.Host/openiddict.pfx", "VeraClinic.HttpApi.Host/"]
COPY ["src/VeraClinic.Application/VeraClinic.Application.csproj", "VeraClinic.Application/"]
COPY ["src/VeraClinic.Application.Contracts/VeraClinic.Application.Contracts.csproj", "VeraClinic.Application.Contracts/"]
COPY ["src/VeraClinic.Domain/VeraClinic.Domain.csproj", "VeraClinic.Domain/"]
COPY ["src/VeraClinic.Domain.Shared/VeraClinic.Domain.Shared.csproj", "VeraClinic.Domain.Shared/"]
COPY ["src/VeraClinic.EntityFrameworkCore/VeraClinic.EntityFrameworkCore.csproj", "VeraClinic.EntityFrameworkCore/"]
COPY ["src/VeraClinic.HttpApi/VeraClinic.HttpApi.csproj", "VeraClinic.HttpApi/"]

# 3. Restore et
RUN dotnet restore "VeraClinic.HttpApi.Host/VeraClinic.HttpApi.Host.csproj"

# 4. Tüm kodları içeri al
COPY . .

# 5. Build aşaması (Klasör yoluna DİKKAT)
WORKDIR "/src/src/VeraClinic.HttpApi.Host"
RUN dotnet build "VeraClinic.HttpApi.Host.csproj" -c Release -o /app/build

# 6. Publish aşaması
FROM build AS publish
# WORKDIR zaten yukarıda set edildiği için burada tekrar girmeye gerek yok
RUN dotnet publish "VeraClinic.HttpApi.Host.csproj" -c Release -o /app/publish

# 7. Final aşaması
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ✅ Sertifikayı çalışma dizinine (root) kopyalıyoruz
COPY src/VeraClinic.HttpApi.Host/openiddict.pfx . 

ENTRYPOINT ["dotnet", "VeraClinic.HttpApi.Host.dll"]