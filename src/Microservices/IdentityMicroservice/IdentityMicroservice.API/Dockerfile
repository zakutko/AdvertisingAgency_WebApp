#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Microservices/IdentityMicroservice/IdentityMicroservice.API/IdentityMicroservice.API.csproj", "src/Microservices/IdentityMicroservice/IdentityMicroservice.API/"]
COPY ["src/Microservices/IdentityMicroservice/IdentityMicroservice.BLL/IdentityMicroservice.BLL.csproj", "src/Microservices/IdentityMicroservice/IdentityMicroservice.BLL/"]
COPY ["src/Contracts/AdvertisingAgency.Contracts/AdvertisingAgency.Contracts.csproj", "src/Contracts/AdvertisingAgency.Contracts/"]
COPY ["src/Microservices/IdentityMicroservice/IdentityMicroservice.DAL/IdentityMicroservice.DAL.csproj", "src/Microservices/IdentityMicroservice/IdentityMicroservice.DAL/"]
COPY ["src/Constants/AdvertisingAgency.Constants/AdvertisingAgency.Constants.csproj", "src/Constants/AdvertisingAgency.Constants/"]
RUN dotnet restore "src/Microservices/IdentityMicroservice/IdentityMicroservice.API/IdentityMicroservice.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/IdentityMicroservice/IdentityMicroservice.API"
RUN dotnet build "IdentityMicroservice.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityMicroservice.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityMicroservice.API.dll"]