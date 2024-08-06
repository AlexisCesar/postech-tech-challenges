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
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Rodando o projeto](#rodando-o-projeto)

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
- 📜 Com o Docker instalado, execute o seguinte comando pelo terminal na pasta raíz do projeto

```bash
docker-compose up
```
- Acesse a aplicação através do swagger pelo seguinte endereço: http://localhost:7575/swagger
- Alternativamente você pode utilizar um API Client como o Postman, acessando diretamente os endpoints citados a seguir
