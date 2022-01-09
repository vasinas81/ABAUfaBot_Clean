# dockerfile
ARG CONFIGURATION=Release

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG CONFIGURATION

ENV ASPNETCORE_Environment=Production

WORKDIR /src
COPY ["ABAUfaBot.WebAPI/ABAUfaBot.WebAPI.csproj", "main/ABAUfaBot.WebAPI/"]
COPY ["ABAUfaBot.Infrastructure/ABAUfaBot.Infrastructure.csproj", "main/ABAUfaBot.Infrastructure/"]
COPY ["ABAUfaBot.Application/ABAUfaBot.Application.csproj", "main/ABAUfaBot.Application/"]
COPY ["ABAUfaBot.Domain/ABAUfaBot.Domain.csproj", "main/ABAUfaBot.Domain/"]
COPY ["ABAUfaBot.sln", "main/"]
WORKDIR /src/main

RUN dotnet restore -warnaserror /p:DisableImplicitNuGetFallbackFolder=true

WORKDIR /src
COPY ["", "main/"]

WORKDIR /src/main

RUN dotnet build && \
    dotnet test --no-build

FROM build AS publish
ARG CONFIGURATION
RUN dotnet publish --no-build -c ${CONFIGURATION} -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "ABAUfaBot.WebAPI.dll"]
CMD ["dotnet", "ABAUfaBot.WebAPI.dll"]