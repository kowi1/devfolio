FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY ./gtbweb.blazor/*.csproj ./
#RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish gtbweb.blazor -c Release -o gtbweb.blazor/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app/gtbweb.blazor/out .

#ENV ASPNETCORE_URLS=http://*:$PORT
#ENTRYPOINT ["dotnet", "gtbweb.dll","--server.urls", "http://*:"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet gtbweb.blazor.dll


