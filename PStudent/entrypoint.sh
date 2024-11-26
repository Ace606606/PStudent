#!/bin/bash

set -e 

echo "Waiting for Postgres to be ready..."

while ! pg_isready -h db -p 5432 - U user; do
	sleep 1
done

echo "Applying EF Core migrations..."
dotnet ef database update

echo "Starting the application..."
exec dotnet PStudent.dll
