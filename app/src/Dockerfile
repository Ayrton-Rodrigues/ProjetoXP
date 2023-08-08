FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
EXPOSE 80
EXPOSE 443
WORKDIR /app

COPY . /app
COPY . ./sql
RUN dotnet restore ./CadastroCliente.Api/CadastroCliente.Api.csproj
RUN dotnet publish ./CadastroCliente.Api/CadastroCliente.Api.csproj -c Release -o /app/out

# Define a imagem base para a execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CadastroCliente.Api.dll"]
