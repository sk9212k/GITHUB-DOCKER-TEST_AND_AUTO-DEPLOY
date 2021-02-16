FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine AS build-env  # Use Alpine sdk Core 3.1 and set name 'build-env'
RUN apk add --no-cache openssh-client
EXPOSE 80 # Export 80 port
WORKDIR /app # Change working Directory
COPY ./github_docker_deploy . # copy /github_docker_deploy folder to current directory
 
RUN dotnet restore
RUN dotnet build -c Release -o /out
RUN dotnet publish -c Release -o /out # Project Published on out folder
 
# Runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine # Use runtime image
WORKDIR /app # Change working directory
COPY --from=build-env /out .  # copy /out folder from 'build-env' 
ENTRYPOINT ["dotnet", "github_docker_deploy.dll"] # Start project
