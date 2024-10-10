<div align="center">
<img src="https://github.com/user-attachments/assets/208a0ebb-ca7c-4b0b-9f68-0b35050a9880" width="30%" />
</div>

# Lanchonete do Bairro API (POS TECH: TECH CHALLENGE - 2a FASE)🚀

Seja bem vindo ao repositório da Lanchonete do Bairro API! Este é um desafio proposto pela PósTech (Fiap + Alura) na segunda fase da pós graduação de Software Architecture (8SOAT).

Integrantes do grupo:<br>
Alexis Cesar (RM 356558)<br>
Bruna Gonçalves (RM 356557)

A API foi projetada para gerenciar pedidos de uma lanchonete de bairro, permitindo que os clientes façam seus pedidos através de um totem. A aplicação é containerizada utilizando Docker, orquestrada por Kubernetes (K8s) para garantir escalabilidade e resiliência, e gerenciada por Helm, que automatiza o deployment e rollbacks no cluster Kubernetes.

## Navegação
- [Arquitetura](#arquitetura)
- [Infraestrutura](#infraestrutura)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Opção 1: Rodando o projeto com Kubernetes e Helm](#opção-1-rodando-o-projeto-com-kubernetes-e-helm)
  - [Acessando o banco de dados com Kubernetes](#acessando-o-banco-de-dados-com-kubernetes)
- [Opção 2: Rodando o projeto com Docker-Compose](#opção-2-rodando-o-projeto-com-docker-compose)
  - [Acessando o banco de dados com Docker](#acessando-o-banco-de-dados-com-docker)

## Arquitetura

A aplicação segue a Arquitetura Limpa, que promove a separação de responsabilidade, facilitando a manutenção e escalabilidade. Esta abordagem permite que a lógica de negócios principal seja independente de qualquer dependência externa, como bancos de dados ou serviços externos.

## Infraestrutura

Abaixo segue um diagrama da nossa infraestrutura em Kubernetes:

![arquitetura_tc2 drawio](https://github.com/user-attachments/assets/2fb9edec-70a4-41cf-a915-25d385492dfc)

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
- **Docker Desktop**: Simular cluster local do ambiente Kubernetes.
- **Lens**: Interface gráfica para gerenciar cluster Kubernetes.
  
## Opção 1: Rodando o projeto com Kubernetes e Helm
- ⛵ [Helm](https://helm.sh/pt/docs/intro/install/) é um pré-requisito para rodar esta aplicação localmente
- Um cluster local é pre-requisito para rodar esta aplicação localmente, como sugestão:
  - [Docker Desktop](https://www.docker.com/products/docker-desktop/);
  - [Minikube](https://minikube.sigs.k8s.io/docs/start/);
- 📜 Com o Helm instalado e o cluster local em funcionamento, execute o seguinte comando na raiz do projeto:

```bash
helm install lanchonetedobairro-release ./helm/lanchonetedobairro_chart/
```
- Acesse a aplicação através do swagger pelo seguinte endereço: http://localhost:30200/swagger
  
### Acessando o banco de dados com Kubernetes

É possível acessar o banco de dados conectando diretamente no respectivo pod e utilizando a linha de comando do PostgreSQL (psql), ou, acessar de maneira externa (para conectar ao banco utilizando um SGBD como o PgAdmin) fazendo um forward na porta do Service do banco com o seguinte comando:
 
```bash
kubectl port-forward <nome da service do banco de dados> 5432:5432
```

Agora você pode acessar o banco de dados através de um sistema gerenciador de banco de dados para o PostgreSQL, como o [PgAdmin](https://www.pgadmin.org/download/), no servidor localhost e com a porta padrão do PostgreSQL (5432). As credenciais do banco local podem ser encontrados no arquivo .env na pasta raíz do projeto.

## Opção 2: Rodando o projeto com Docker-Compose
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
