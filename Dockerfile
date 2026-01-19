FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Ortak ayarları ve tüm .csproj dosyalarını kopyalıyoruz
COPY ["common.props", "."]
COPY ["src/VeraClinic.HttpApi.Host/VeraClinic.HttpApi.Host.csproj", "src/VeraClinic.HttpApi.Host/"]
COPY ["src/VeraClinic.Application/VeraClinic.Application.csproj", "src/VeraClinic.Application/"]
COPY ["src/VeraClinic.Application.Contracts/VeraClinic.Application.Contracts.csproj", "src/VeraClinic.Application.Contracts/"]
COPY ["src/VeraClinic.Domain/VeraClinic.Domain.csproj", "src/VeraClinic.Domain/"]
COPY ["src/VeraClinic.Domain.Shared/VeraClinic.Domain.Shared.csproj", "src/VeraClinic.Domain.Shared/"]
COPY ["src/VeraClinic.EntityFrameworkCore/VeraClinic.EntityFrameworkCore.csproj", "src/VeraClinic.EntityFrameworkCore/"]
COPY ["src/VeraClinic.HttpApi/VeraClinic.HttpApi.csproj", "src/VeraClinic.HttpApi/"]

# Restore işlemi
RUN dotnet restore "src/VeraClinic.HttpApi.Host/VeraClinic.HttpApi.Host.csproj"

# Tüm kaynak kodları içeri alıyoruz
COPY . .

# Build ve Publish
WORKDIR "/src/src/VeraClinic.HttpApi.Host"
RUN dotnet publish "VeraClinic.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
# Build katmanından yayınlanmış dosyaları alıyoruz
COPY --from=build /app/publish .

# --- HATA BURADAYDI, ŞÖYLE DÜZELTTİK ---
# Sertifikayı 'build' aşamasındaki kaynak klasörden çekiyoruz. 
# Çünkü 'final' katmanında 'src/' klasörü fiziksel olarak yoktur.
COPY --from=build /src/VeraClinic.HttpApi.Host/openiddict.pfx .
# ---------------------------------------

ENTRYPOINT ["dotnet", "VeraClinic.HttpApi.Host.dll"]