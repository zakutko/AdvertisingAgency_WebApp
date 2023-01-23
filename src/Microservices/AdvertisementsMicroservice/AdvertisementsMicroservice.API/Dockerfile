#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Microservices/AdvertisementsMicroservice/AdvertisementsMicroservice.API/AdvertisementsMicroservice.API.csproj", "src/Microservices/AdvertisementsMicroservice/AdvertisementsMicroservice.API/"]
COPY ["src/Microservices/IdentityMicroservice/IdentityMicroservice.DAL/IdentityMicroservice.DAL.csproj", "src/Microservices/IdentityMicroservice/IdentityMicroservice.DAL/"]
COPY ["src/Constants/AdvertisingAgency.Constants/AdvertisingAgency.Constants.csproj", "src/Constants/AdvertisingAgency.Constants/"]
COPY ["src/Microservices/AdvertisementsMicroservice/AdvertisementsMicroservice.BLL/AdvertisementsMicroservice.BLL.csproj", "src/Microservices/AdvertisementsMicroservice/AdvertisementsMicroservice.BLL/"]
COPY ["src/Microservices/AdvertisementsMicroservice/AdvertisementsMicroservice.DAL/AdvertisementsMicroservice.DAL.csproj", "src/Microservices/AdvertisementsMicroservice/AdvertisementsMicroservice.DAL/"]
RUN dotnet restore "src/Microservices/AdvertisementsMicroservice/AdvertisementsMicroservice.API/AdvertisementsMicroservice.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/AdvertisementsMicroservice/AdvertisementsMicroservice.API"
RUN dotnet build "AdvertisementsMicroservice.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdvertisementsMicroservice.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdvertisementsMicroservice.API.dll"]