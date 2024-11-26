FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["PStudent.csproj", "./"]
RUN dotnet restore "PStudent.csproj"

COPY . .
RUN dotnet build "PStudent.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ""PStudent.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

ENTRYPOINT ["./entrypoint.sh"]

