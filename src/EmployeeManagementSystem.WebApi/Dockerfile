#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/EmployeeManagementSystem.WebApi/EmployeeManagementSystem.WebApi.csproj", "src/EmployeeManagementSystem.WebApi/"]
COPY ["src/EmployeeManagementSystem.Business/EmployeeManagementSystem.Business.csproj", "src/EmployeeManagementSystem.Business/"]
COPY ["src/EmployeeManagementSystem.Common/EmployeeManagementSystem.Common.csproj", "src/EmployeeManagementSystem.Common/"]
COPY ["src/EmployeeManagementSystem.DataAccess/EmployeeManagementSystem.DataAccess.csproj", "src/EmployeeManagementSystem.DataAccess/"]
COPY ["src/EmployeeManagementSystem.Entities/EmployeeManagementSystem.Entities.csproj", "src/EmployeeManagementSystem.Entities/"]
RUN dotnet restore "src/EmployeeManagementSystem.WebApi/EmployeeManagementSystem.WebApi.csproj"
COPY . .
WORKDIR "/src/src/EmployeeManagementSystem.WebApi"
RUN dotnet build "EmployeeManagementSystem.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeManagementSystem.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagementSystem.WebApi.dll"]