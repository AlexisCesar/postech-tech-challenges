# Usar uma imagem base do Python
FROM python:3.10-slim

# Instalar dependências do sistema necessárias para o psycopg2
RUN apt-get update && apt-get install -y \
    gcc \
    libpq-dev \
    && apt-get clean

# Definir o diretório de trabalho
WORKDIR /app

# Copiar o requirements.txt para a imagem
COPY requirements.txt .

# Instalar as dependências do Python
RUN pip install --no-cache-dir -r requirements.txt

# Copiar o script para a imagem
COPY remove_pedidos.py .

# Comando para rodar o script
CMD ["python", "remove_pedidos.py"]
