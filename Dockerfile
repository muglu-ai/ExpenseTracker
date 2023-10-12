# Use the official .NET Core SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /ExpenseTracker

# Copy the project file and restore dependencies
COPY ExpenseTracker.csproj ./ExpenseTracker
RUN dotnet restore

# Copy the rest of the application code
COPY . ./ExpenseTracker

# Build the application
RUN dotnet publish -c Release -o out

# Use the official .NET Core runtime as the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /ExpenseTracker

# Copy the published application from the build image
COPY --from=build /ExpenseTracker/out ./

ENTRYPOINT ["dotnet", "ExpenseTracker.dll"]
