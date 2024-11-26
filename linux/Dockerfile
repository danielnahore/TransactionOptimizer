# Use the official .NET image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TransactionProcessor/TransactionProcessor.csproj", "TransactionProcessor/"]
RUN dotnet restore "TransactionProcessor/TransactionProcessor.csproj"
COPY . .
WORKDIR "/src/TransactionProcessor"
RUN dotnet build "TransactionProcessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TransactionProcessor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransactionProcessor.dll"]