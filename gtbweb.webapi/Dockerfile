FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore

# Copy everything else and build
COPY . ./

RUN dotnet publish gtbweb.webapi -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /app
COPY --from=build-env /app/gtbweb.webapi/out .

#ENV ASPNETCORE_URLS=http://*:$PORT
#ENTRYPOINT ["dotnet", "gtbweb.dll","--server.urls", "http://*:"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet gtbweb.webapi.dll


