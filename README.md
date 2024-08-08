<div align="center">
<img src="https://github.com/user-attachments/assets/208a0ebb-ca7c-4b0b-9f68-0b35050a9880" width="30%" />
</div>

# Lanchonete do Bairro API (POS TECH: TECH CHALLENGE - 1a FASE)🚀

Seja bem vindo ao repositório da Lanchonete do Bairro API! Este é um desafio proposto pela PósTech (Fiap + Alura) na primeira fase da pós graduação de Software Architecture (8SOAT).

Integrantes do grupo:<br>
Alexis Cesar (RM 356558)<br>
Bruna Gonçalves (RM 356557)

Esta API foi projetada para gerenciar pedidos de uma lanchonete de bairro, permitindo que os clientes façam seus pedidos através de um totem. A aplicação é containerizada usando Docker, facilitando a implantação e execução.

Os diagramas relacionados ao projeto (Event Storming) e o dicionário de linguagem ubíqua podem ser encontrados no nosso [board do Miro](https://miro.com/app/board/uXjVK26mPM0=/?share_link_id=393927699887) 😉

## Navegação
- [Arquitetura](#arquitetura)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Rodando o projeto](#rodando-o-projeto)
- [Acessando o banco de dados](#acessando-o-banco-de-dados)

## Arquitetura

A aplicação segue a arquitetura hexagonal (Ports and Adapters), que facilita a manutenção e escalabilidade. Esta arquitetura permite que a lógica de negócios principal seja independente de qualquer dependência externa, como bancos de dados ou serviços externos.

## Funcionalidades
 
- **Gerenciamento de Pedidos**: Os clientes podem fazer pedidos via o totem da lanchonete.
- **Rastreamento de Status de Pedidos**: Os clientes e colaboradores podem companhar o status dos pedidos (Recebido, Em Preparação, Pronto, Finalizado).
- **Processamento de Pagamentos**: Neste momento, o sistema simula o processamento de pagamento.
- **Gerenciamento de Produtos**: Gerencia os produtos da lanchonete dentro de quatro categorias (Lanche, Bebida, Acompanhamento e Sobremesa).

## Tecnologias Utilizadas
 
- **.NET 8.0**: ASP.NET Core.
- **Entity Framework Core**: ORM para interações com o banco de dados.
- **PostgreSQL**: Banco de dados.
- **Docker**: Plataforma de containerização.
  
## Rodando o projeto
- 🐳 [Docker](https://www.docker.com/get-started) é um pré-requisito para rodar esta aplicação localmente
- 📜 Com o Docker instalado, execute o seguinte comando pelo terminal na pasta raíz do projeto:

```bash
docker-compose up
```
- Acesse a aplicação através do swagger pelo seguinte endereço: http://localhost:7575/swagger

## Acessando o banco de dados

Por padrão, o banco de dados não é exposto ao subir os contêineres para evitar conflitos de portas. Para acessar o banco de dados, será necessário executar o seguinte comando na pasta raíz do projeto ao invés do mencionado na etapa anterior:

```bash
docker compose -f docker-compose-db-exposed.yaml up
```
Agora você pode acessar o banco de dados através de um sistema gerenciador de banco de dados para o PostgreSQL, como o [PgAdmin](https://www.pgadmin.org/download/), no servidor localhost e com a porta padrão do PostgreSQL (5432). As credenciais do banco local podem ser encontrados no arquivo .env na pasta raíz do projeto.