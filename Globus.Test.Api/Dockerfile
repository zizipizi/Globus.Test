FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Globus.Test.Api/Globus.Test.Api.csproj", "Globus.Test.Api/"]
COPY ["Globus.Test.Application/Globus.Test.Application.csproj", "Globus.Test.Application/"]
COPY ["Globus.Test.Domain/Globus.Test.Domain.csproj", "Globus.Test.Domain/"]
COPY ["Globus.Test.Infrastructure/Globus.Test.Infrastructure.csproj", "Globus.Test.Infrastructure/"]
RUN dotnet restore "Globus.Test.Api/Globus.Test.Api.csproj"
COPY . .
WORKDIR "/src/Globus.Test.Api"
RUN dotnet build "Globus.Test.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Globus.Test.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Globus.Test.Api.dll"]
