FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

# create a new user
RUN adduser dotnetuser -D

# impersonate into the new user
USER dotnetuser

# switch to working directory
WORKDIR /home/dotnetuser/app

# copy application files into container
COPY ../build .

# expose port for communication
EXPOSE 80

# set container entrypoint to dotnet application
ENTRYPOINT ["dotnet", "Forfeit15.Patchnotes.dll"]
