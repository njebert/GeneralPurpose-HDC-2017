FROM microsoft/aspnetcore-build
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet build
EXPOSE 5000
ENTRYPOINT dotnet run
