FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
EXPOSE 7000
ENV ASPNETCORE_URLS=http://+:7000

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "EventiApplication.WebAPI" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD ./EventiApplication.WebAPI/Images ./Images

ENTRYPOINT ["dotnet", "EventiApplication.WebAPI.dll"]