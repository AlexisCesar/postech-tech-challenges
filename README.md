<div align="center">
<img src="https://github.com/user-attachments/assets/208a0ebb-ca7c-4b0b-9f68-0b35050a9880" width="30%" />
</div>

# Lanchonete do Bairro API (POS TECH: TECH CHALLENGE - 3a FASE)🚀

Seja bem vindo ao repositório da Lanchonete do Bairro API! Este é um desafio proposto pela PósTech (Fiap + Alura) na terceira fase da pós graduação de Software Architecture (8SOAT).

📼 Vídeo de demonstração do projeto desta fase: TBD

Integrantes do grupo:<br>
Alexis Cesar (RM 356558)<br>
Bruna Gonçalves (RM 356557)

A API foi projetada para gerenciar pedidos de uma lanchonete de bairro, permitindo que os clientes façam seus pedidos através de um totem. A aplicação é containerizada utilizando Docker, orquestrada por Kubernetes (K8s) para garantir escalabilidade e resiliência, e gerenciada por Helm, que automatiza o deployment e rollbacks no cluster Kubernetes (EKS) na nuvem da AWS.

## Navegação
- [Arquitetura](#arquitetura)
- [Infraestrutura](#infraestrutura)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Rodando o projeto com Docker-Compose](#rodando-o-projeto-com-docker-compose)
  - [Acessando o banco de dados com Docker](#acessando-o-banco-de-dados-com-docker)
- [Subindo a infraestrutura na AWS](#subindo-a-infraestrutura-na-aws)

## Arquitetura

A aplicação segue a Arquitetura Limpa, que promove a separação de responsabilidade, facilitando a manutenção e escalabilidade. Esta abordagem permite que a lógica de negócios principal seja independente de qualquer dependência externa, como bancos de dados ou serviços externos.

## Infraestrutura

Diagrama da infraestrutura na nuvem AWS:



## Funcionalidades
 
- **Gerenciamento de Pedidos**: Os clientes podem fazer pedidos via o totem da lanchonete.
- **Rastreamento de Status de Pedidos**: Os clientes e colaboradores podem companhar o status dos pedidos (Recebido, Em Preparação, Pronto, Finalizado).
- **Processamento de Pagamentos**: Neste momento, o sistema simula o processamento de pagamento através de um webhook.
- **Gerenciamento de Produtos**: Gerencia os produtos da lanchonete dentro de quatro categorias (Lanche, Bebida, Acompanhamento e Sobremesa).

## Tecnologias Utilizadas
 
- **.NET 8.0**: ASP.NET Core.
- **Entity Framework Core**: ORM para interações com o banco de dados.
- **PostgreSQL**: Banco de dados.
- **Docker**: Plataforma de containerização.
- **Kubernetes**: Orquestração de contêineres.
- **Helm**: Gerenciamento de de pacotes kubernetes.
- **EKS**: Cluster Kubernetes na nuvem da AWS.

## Rodando o projeto com Docker-Compose
> ⚠ Para que a integração com o Mercado Pago funcione e seja possível utilizar o endpoint 'Realizar Pedido' para gerar QR codes, é necessário uma integração criada e configurada para QR Code Dinâmico através do [Mercado Pago Developers](https://www.mercadopago.com.br/developers/). Para mais detalhes de como configurar a integração consulte nossa [página sobre a integração na Wiki](https://github.com/AlexisCesar/postech-tech-challenges/wiki/Integra%C3%A7%C3%A3o-com-Mercado-Pago).
- 🐳 [Docker](https://www.docker.com/get-started) é um pré-requisito para rodar esta aplicação localmente
- 📜 Com o Docker instalado, execute o seguinte comando pelo terminal na pasta raíz do projeto:

```bash
docker-compose up
```
- Acesse a aplicação através do swagger pelo seguinte endereço: http://localhost:7575/swagger
  
### Acessando o banco de dados com Docker

Por padrão, o banco de dados não é exposto ao subir os contêineres para evitar conflitos de portas. Para acessar o banco de dados, será necessário executar o seguinte comando na pasta raíz do projeto ao invés do mencionado na etapa anterior:

```bash
docker compose -f docker-compose-db-exposed.yaml up
```
Agora você pode acessar o banco de dados através de um sistema gerenciador de banco de dados para o PostgreSQL, como o [PgAdmin](https://www.pgadmin.org/download/), no servidor localhost e com a porta padrão do PostgreSQL (5432). As credenciais do banco local podem ser encontrados no arquivo .env na pasta raíz do projeto.

### Subindo a infraestrutura na AWS
Para subir a infraestrutura do sistema no ambiente cloud, siga os passos mencionados nos seguintes repositórios:
- [postech-tc-eks](https://github.com/AlexisCesar/postech-tc-eks)
- [postech-tc-rds](https://github.com/AlexisCesar/postech-tc-rds)
- [postech-tc-lambda](https://github.com/AlexisCesar/postech-tc-lambda)