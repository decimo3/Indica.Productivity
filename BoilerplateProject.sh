#!/bin/bash

# Nome base da solução
SOLUTION_NAME="Indica.Productivity.

# Cria a pasta principal
mkdir -p $SOLUTION_NAME/src
cd $SOLUTION_NAME

# Cria a solução
dotnet new sln -n $SOLUTION_NAME

# Cria os projetos
dotnet new classlib -n $SOLUTION_NAME.Domain -o src/$SOLUTION_NAME.Domain
dotnet new classlib -n $SOLUTION_NAME.Infra -o src/$SOLUTION_NAME.Infra
dotnet new classlib -n $SOLUTION_NAME.Application -o src/$SOLUTION_NAME.Application
dotnet new webapi -n $SOLUTION_NAME.API -o src/$SOLUTION_NAME.API --no-https

# Adiciona referências entre projetos
dotnet add src/$SOLUTION_NAME.Infra/$SOLUTION_NAME.Infra.csproj reference src/$SOLUTION_NAME.Domain/$SOLUTION_NAME.Domain.csproj
dotnet add src/$SOLUTION_NAME.Application/$SOLUTION_NAME.Application.csproj reference src/$SOLUTION_NAME.Domain/$SOLUTION_NAME.Domain.csproj
dotnet add src/$SOLUTION_NAME.API/$SOLUTION_NAME.API.csproj reference src/$SOLUTION_NAME.Application/$SOLUTION_NAME.Application.csproj
dotnet add src/$SOLUTION_NAME.API/$SOLUTION_NAME.API.csproj reference src/$SOLUTION_NAME.Infra/$SOLUTION_NAME.Infra.csproj

# Adiciona os projetos à solução
dotnet sln add src/$SOLUTION_NAME.Domain/$SOLUTION_NAME.Domain.csproj
dotnet sln add src/$SOLUTION_NAME.Infra/$SOLUTION_NAME.Infra.csproj
dotnet sln add src/$SOLUTION_NAME.Application/$SOLUTION_NAME.Application.csproj
dotnet sln add src/$SOLUTION_NAME.API/$SOLUTION_NAME.API.csproj

# Gera .gitignore
dotnet new gitignore

# Cria um Dockerfile básico na API
cat <<EOF > src/$SOLUTION_NAME.API/Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore src/$SOLUTION_NAME.API/$SOLUTION_NAME.API.csproj
RUN dotnet publish src/$SOLUTION_NAME.API/$SOLUTION_NAME.API.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "$SOLUTION_NAME.API.dll"]
EOF

# Mensagem final
echo "✅ Solução criada em $(pwd)/$SOLUTION_NAME"