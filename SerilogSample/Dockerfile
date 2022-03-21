#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SerilogSample/SerilogSample.csproj", "SerilogSample/"]
RUN dotnet restore "SerilogSample/SerilogSample.csproj"
COPY . .
WORKDIR "/src/SerilogSample"
RUN dotnet build "SerilogSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SerilogSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SerilogSample.dll"]