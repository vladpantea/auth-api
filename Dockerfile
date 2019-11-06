FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY Auth.API.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
#variable example
#ENV ASPNETCORE_ENVIRONMENT="Development"
#ENV ASPNETCORE_JWTSettings__Issuer="someissuer"
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Auth.API.dll"]