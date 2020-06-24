FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY ./gtbweb/gtbweb/*.csproj ./
#RUN dotnet restore

COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/out .

# Copy everything else and build
##COPY . ./
##RUN dotnet publish gtbweb  -c Release -o out

# Build runtime image
##FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
##WORKDIR /app
##COPY --from=build-env /app/gtbweb/gtbweb/out .

#ENV ASPNETCORE_URLS=http://*:$PORT
#ENTRYPOINT ["dotnet", "gtbweb.dll","--server.urls", "http://*:"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet gtbweb.dll


