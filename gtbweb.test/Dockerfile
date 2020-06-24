FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY ./gtbweb.test/*.csproj ./

#RUN dotnet restore

#Copy everything else and build
COPY . ./
RUN dotnet publish gtbweb.test -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/gtbweb.test/out .

#ENV ASPNETCORE_URLS=http://*:$PORT
#ENTRYPOINT ["dotnet", "gtbweb.dll","--server.urls", "http://*:"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet gtbweb.test.dll


