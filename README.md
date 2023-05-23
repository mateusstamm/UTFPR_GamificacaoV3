# Projeto Gerenciador de Restaurante - UTFPR - 2023/1

Projeto realizado com base em atividade de gamificação para a disciplina de Tecnologia em Desenvolvimento de Sistemas, ministrada pelo professor Everton Coimbra de Araújo, com enfoque na gerência de um restaurante.

# Descrição do Projeto

O objetivo deste projeto é desenvolver um sistema de gerenciamento de pedidos de um restaurante, que permita criar atendimentos, incluir pedidos de produtos e realizar vendas.


# Requisitos para execução do projeto

- Docker, para execução dos containers da aplicação;
- Docker-Compose, para realizar o build dos projetos;

# Como deixar em funcionamento

- Clone o repositório ou faça o download do ZIP em um diretório;
- Acesse a pasta raiz onde consta o arquivo docker-compose.yml;
- Dê o comando "docker-compose up --build -d", para realizar o build dos projetos;
- Acesse a aplicação pela URL "http://localhost:5238/"
- Acesse a API através do endpoint "http://localhost:5239/"
- Acesse o Swagger (habilitado para testes) através da URL "http://localhost:5239/swagger/index.html"

# Tecnologias utilizadas

- .NET Core 7.0.5
- Entity Framework Core 7.0.5
- MySQL 5.7.16
- C# Razor Pages
- HTML
- CSS
- Bootstrap
- JavaScript