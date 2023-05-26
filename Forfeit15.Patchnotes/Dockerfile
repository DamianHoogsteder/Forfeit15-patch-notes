FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG NUGET_USERNAME
ARG NUGET_PASSWORD

ENV NUGET_USERNAME=${NUGET_USERNAME}
ENV NUGET_PASSWORD=${NUGET_PASSWORD}

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Forfeit15.Patchnotes/Forfeit15.Patchnotes.csproj", "Forfeit15.Patchnotes/"]

RUN echo ${NUGET_AT}

RUN dotnet nuget add source https://nuget.pkg.github.com/DamianHoogsteder/index.json --username DamianHoogsteder --store-password-in-clear-text --password ${NUGET_PASSWORD}
RUN dotnet restore "Forfeit15.Patchnotes/Forfeit15.Patchnotes.csproj"

WORKDIR "/src/Forfeit15.Patchnotes"
COPY . .
RUN dotnet build "Forfeit15.Patchnotes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Forfeit15.Patchnotes.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Forfeit15.Patchnotes.dll"]
