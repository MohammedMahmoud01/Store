# Use the .NET SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and restore dependencies
COPY *.sln ./
COPY Domains/Domains.csproj ./Domains/
COPY Store/Store.csproj ./Store/
RUN dotnet restore Store/Store.csproj
RUN dotnet restore Domains/Domains.csproj

# Copy the rest of the files and build the project
COPY . .
WORKDIR /app/Store
RUN dotnet publish -c Release -o out

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/Store/out ./
ENV ASPNETCORE_URLS=http://+:8090
EXPOSE 8090
ENTRYPOINT ["dotnet", "Store.dll" , "http://*/8090"]
