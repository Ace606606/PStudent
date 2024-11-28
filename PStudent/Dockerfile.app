# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы проекта и восстанавливаем зависимости
COPY PStudent.csproj .
RUN dotnet restore

# Копируем исходный код и публикуем
COPY . .
RUN dotnet publish -c Release -o /app

# Финальный образ для выполнения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Копируем скомпилированные файлы
COPY --from=build /app .

# Запускаем приложение
ENTRYPOINT ["dotnet", "PStudent.dll"]
