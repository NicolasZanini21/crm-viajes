FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "CrmViajes.Api.csproj"
RUN dotnet publish "CrmViajes.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render (y la mayoria de los hosts gratuitos) inyectan la variable PORT en
# tiempo de ejecucion y esperan que la app escuche ahi. Si no esta seteada,
# usamos 8080 como default para correrlo local con `docker run`.
ENTRYPOINT ["sh", "-c", "dotnet CrmViajes.Api.dll --urls http://+:${PORT:-8080}"]
