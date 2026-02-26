# =====================================================
# ЭТАП 1: СБОРКА (Build)
# =====================================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Копируем только csproj для кэширования NuGet пакетов
COPY ["src/EventLiteWeb.csproj", "src/EventLiteWeb.csproj"]
RUN dotnet restore "src/EventLiteWeb.csproj"

# Копируем весь исходный код и собираем
COPY . .
WORKDIR "/src/src"
RUN dotnet build "EventLiteWeb.csproj" -c Release -o /app/build

# =====================================================
# ЭТАП 2: ПУБЛИКАЦИЯ (Publish)
# =====================================================
FROM build AS publish
RUN dotnet publish "EventLiteWeb.csproj" -c Release -o /app/publish

# =====================================================
# ЭТАП 3: RUNTIME (Финальный образ)
# =====================================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Настройки для ASP.NET Core
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

# Копируем только скомпилированное приложение
COPY --from=publish /app/publish .

# Команда запуска
ENTRYPOINT ["dotnet", "EventLiteWeb.dll"]