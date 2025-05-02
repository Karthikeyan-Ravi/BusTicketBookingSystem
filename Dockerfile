# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

#Sets the working directory inside the container to /app
WORKDIR /app

# Copies .csproj file from machine to container’s /app folder.
COPY *.csproj ./

# Restores dependencies listed in the .csproj file
RUN dotnet restore

# Copies all other files (like .cs, .cshtml, etc.) from project directory to the container
COPY . ./

# Publishes app in Release mode and puts the result in the /app/out folder
RUN dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Sets working directory inside the runtime container.
WORKDIR /app

# Copies the published output from the build stage (previous image) into this container
COPY --from=build /app/out .

# Startup command for the container.It runs the app using dotnet
ENTRYPOINT ["dotnet", "BusTicketBookingSystem.dll"]

