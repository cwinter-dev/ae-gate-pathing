FROM mcr.microsoft.com/dotnet/sdk:9.0
COPY ./AEBestGatePath.Web AEBestGatePath.Web
COPY ./AEBestGatePath.Data AEBestGatePath.Data
COPY ./AEBestGatePath.Core AEBestGatePath.Core
COPY ./AEBestGatePath.Test AEBestGatePath.Test
RUN dotnet restore AEBestGatePath.Test
RUN dotnet test AEBestGatePath.Test
RUN dotnet publish AEBestGatePath.API/AEBestGatePath.API.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
COPY --from=build-env /app/out .

ENV ASPNETCORE_ENVIRONMENT Production

ENTRYPOINT ["dotnet", "AEBestGatePath.API.dll"]