FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
EXPOSE 80
EXPOSE 443
EXPOSE 1433

 

 

 


COPY . ./

 

 

 

RUN dotnet restore
RUN dotnet publish "./PlantillaWebApi/Proyecto.csproj" -c Release -o /app

 

 

 


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Proyecto.dll"]