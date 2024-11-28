#!/bin/bash

set -e

echo "Waiting for Postgres to be ready..."

# Ожидание готовности базы данных
while ! pg_isready -h db -p 5432 -U student_managment; do
  sleep 1
done

echo "Applying EF Core migrations..."
dotnet ef database update --project /src/PStudent.csproj --connection "Host=db;Database=student_managment;Username=student_managment;Password=student_managment"
