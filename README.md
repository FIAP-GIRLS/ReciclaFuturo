# Projeto Recicla Futuro
Projeto ReciclaFuturo para o StartupOne de 2024 da FIAP

## Pipeline CI/CD e Containerização

Implementação de uma pipeline CI/CD (Integração Contínua e Entrega Contínua) juntamente com a containerização utilizando Docker e Docker Compose.

O objetivo é automatizar o processo de construção, teste e implantação de uma aplicação de forma eficiente e consistente.

## Requisitos

Certifique-se de que os seguintes itens estejam instalados em sua máquina antes de começar:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [Git](https://git-scm.com/)
- Conta no [GitHub](https://github.com/) para integração com GitHub Actions
- Configurações do ambiente de desenvolvimento e de produção devidamente preparadas
    - `App.settings.Development.json` e outras configurações necessárias.

## Instruções para Clonar o Projeto

1. Clone o repositório Git do projeto:

    ```bash
    git clone https://github.com/usuario/repo.git
    ```

2. Acesse o diretório do projeto:

    ```bash
    cd nome-do-projeto
    ```

## Configuração do Ambiente de Desenvolvimento

1. **Arquivo de Configuração**: Edite o arquivo `App.settings.Development.json` conforme necessário:

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "sua_string_de_conexao_oracle"
      }
    }
    ```

2. **Secrets no GitHub**: Configure as secrets no GitHub para armazenar informações sensíveis (como credenciais de banco de dados ou tokens de acesso). Isso pode ser feito na aba de `Settings > Secrets and Variables` do repositório GitHub.

   Exemplos de secrets que você pode configurar:

    - `AZURE_CREDENTIALS`: Credenciais de acesso ao Azure.
    - `DATABASE_CONNECTION`: String de conexão com o banco de dados.

## Instruções para Executar o Projeto

### Passo 1: Criação da Imagem Docker

1. Certifique-se de que o `Dockerfile` esteja configurado corretamente para criar a imagem Docker da aplicação.

   Um exemplo básico de `Dockerfile`:
    ```dockerfile
    FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
    WORKDIR /app
    EXPOSE 80

    FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
    WORKDIR /src
    COPY ["MyApp/MyApp.csproj", "MyApp/"]
    RUN dotnet restore "MyApp/MyApp.csproj"
    COPY . .
    WORKDIR "/src/MyApp"
    RUN dotnet build "MyApp.csproj" -c Release -o /app/build

    FROM build AS publish
    RUN dotnet publish "MyApp.csproj" -c Release -o /app/publish

    FROM base AS final
    WORKDIR /app
    COPY --from=publish /app/publish .
    ENTRYPOINT ["dotnet", "MyApp.dll"]
    ```

2. Para construir a imagem Docker, execute o seguinte comando:

    ```bash
    docker build -t nome-do-projeto .
    ```

### Passo 2: Executando o Docker Compose

1. Certifique-se de que o arquivo `docker-compose.yaml` está configurado para orquestrar todos os contêineres necessários.

   Um exemplo de `docker-compose.yaml`:
    ```yaml
    version: '3.8'

    services:
      app:
        image: nome-do-projeto
        ports:
          - "5000:80"
        environment:
          - ASPNETCORE_ENVIRONMENT=Development
        depends_on:
          - db
      db:
        image: mysql:5.7
        environment:
          MYSQL_ROOT_PASSWORD: root_password
          MYSQL_DATABASE: nome_banco
          MYSQL_USER: user
          MYSQL_PASSWORD: password
        ports:
          - "3306:3306"
    ```

2. Para inicializar o ambiente com todos os contêineres, execute o comando:

    ```bash
    docker-compose up --build
    ```

### Passo 3: Acesso à Aplicação

1. Com o `docker-compose` rodando, a aplicação estará disponível localmente no endereço `http://localhost:5000`.
2. Verifique os logs dos contêineres para garantir que tudo está funcionando corretamente:

    ```bash
    docker-compose logs
    ```

### Passo 4: Executando a Pipeline CI/CD

1. A pipeline CI/CD está configurada para automatizar as seguintes etapas:
    - Construção da aplicação
    - Execução de testes automatizados
    - Containerização da aplicação
    - Implantação em ambientes de staging e produção

2. A pipeline é acionada por eventos no GitHub, como `push` para as branches `develop` e `main`.

3. Para visualizar os resultados da pipeline, acesse a aba de `Actions` no GitHub e confira o histórico de execuções.

4. Em caso de sucesso, a aplicação será implantada automaticamente no ambiente configurado.

### Passo 5: Verificando os Deployments

- Para verificar se o deployment foi bem-sucedido, acesse os logs de implantação ou a própria aplicação nos ambientes de staging ou produção.

## Comandos Úteis

- **Parar os contêineres**:
    ```bash
    docker-compose down
    ```

- **Remover todos os contêineres, volumes e imagens**:
    ```bash
    docker system prune -a --volumes
    ```

## Estrutura de Pastas do Projeto 

```bash
├── src/
│   ├── MyApp/
│   │   ├── Controllers/
│   │   ├── Models/
│   │   └── MyApp.csproj
├── docker-compose.yaml
├── Dockerfile
├── App.settings.Development.json
├── README.md
└── .github/
    └── workflows/
        └── ci-cd.yaml
