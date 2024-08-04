FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

ARG CACHEBUST=3133244

RUN git clone https://github.com/TEEXIWz/dotnet-webapi-ef.git .

COPY . .

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5500

EXPOSE 5500

ENTRYPOINT ["dotnet", "dotnet-webapi-ef.dll"]