﻿FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
COPY ./AEBestGatePath.API AEBestGatePath.API
COPY ./AEBestGatePath.Data AEBestGatePath.Data
COPY ./AEBestGatePath.Core AEBestGatePath.Core
COPY ./AEBestGatePath.Test AEBestGatePath.Test
RUN dotnet restore AEBestGatePath.Test
RUN dotnet test AEBestGatePath.Test
RUN dotnet publish AEBestGatePath.API -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
COPY --from=build-env /out .

ENV ASPNETCORE_ENVIRONMENT Production
ENV ASPNETCORE_URLS http://*:80/;http://*:8080/
ENTRYPOINT ["dotnet", "AEBestGatePath.API.dll"]