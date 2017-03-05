FROM microsoft/dotnet:runtime

RUN apt-get update
RUN curl -sL https://deb.nodesource.com/setup_6.x | bash -
RUN apt-get install -y build-essential nodejs

# Create directory for the app source code
RUN mkdir -p /opt/app
WORKDIR /opt/app

# Copy the source and restore dependencies
COPY . /opt/app
# RUN ["dotnet", "restore"]
# RUN ["dotnet", "build"]

# Expose the port and start the app
# EXPOSE 5000/tcp
# CMD ["dotnet", "run", "--server.urls", "http://*:5000"]
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "MyChoose.dll"]