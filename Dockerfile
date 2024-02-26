# Use the official .NET 7 SDK image as a base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container for the backend
WORKDIR /app/server

# Copy the solution file and restore dependencies for backend
COPY server/AdminProSolutions.sln .
COPY server/AdminProSolutions.API/*.csproj ./AdminProSolutions.API/
COPY server/AdminProSolutions.Domain/*.csproj ./AdminProSolutions.Domain/
COPY server/AdminProSolutions.Infrastructure/*.csproj ./AdminProSolutions.Infrastructure/
RUN dotnet restore 

# Copy the entire backend directory
COPY server .

# Build the .NET application with detailed logging
RUN dotnet publish -c Release -o out

# Switch to Node.js for building the Angular app
FROM node:16 AS angular-build

# Set the working directory inside the container for the frontend
WORKDIR /app/client-admin

# Copy package.json and package-lock.json to the working directory
COPY client-admin/package*.json ./

# Install Angular dependencies
RUN npm install --force

# Copy the remaining Angular files to the working directory
COPY client-admin .

# Build the Angular application
RUN npm run build

# Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app/server

# Copy the built .NET application
COPY --from=build /app/server/out .

# Copy the necessary configuration files for each backend project
COPY server/AdminProSolutions.API/appsettings*.json .

# Copy the Seeds directory into the runtime image
COPY server/AdminProSolutions.Domain/Seeds /app/AdminProSolutions.Domain/Seeds

# Copy the built Angular app into wwwroot
COPY --from=angular-build /app/client-admin/dist/client-admin ./wwwroot

# Expose the port
EXPOSE 80

# Define the command to run the application
ENTRYPOINT ["dotnet", "AdminProSolutions.API.dll"]

