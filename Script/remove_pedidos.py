import os
import psycopg2
from datetime import datetime

# Recuperar as credenciais e host do banco a partir das variáveis de ambiente
conn = psycopg2.connect(
    host=os.getenv('POSTGRES_HOST'),  # Use o nome do serviço
    user=os.getenv('POSTGRES_USER'),
    password=os.getenv('POSTGRES_PASSWORD'),
    database='controleDePedidos'  # Substitua pelo nome real do seu banco de dados
)
cur = conn.cursor()

# Primeira query: Excluir registros relacionados na tabela ItemPedido
query_itempedido = """
    DELETE FROM public."ItemPedido"
    WHERE "PedidoAggregateId" IN (
        SELECT p."Id"
        FROM public."Pedido" p
        JOIN public."Acompanhamento" a ON p."AcompanhamentoId" = a."Id"
        WHERE a."Status" = 1
        AND p."HorarioRecebimento" < NOW() - INTERVAL '0 minutes'
    );
"""

# Executar a query para remover da tabela ItemPedido
cur.execute(query_itempedido)

# Segunda query: Excluir os registros da tabela Acompanhamento e, consequentemente, da tabela Pedido
query_pedido = """
 DELETE FROM public."Acompanhamento"
    WHERE "Status" = 1
    AND "Id" IN (
        SELECT a."Id"
        FROM public."Acompanhamento" a
        JOIN public."Pedido" p ON a."Id" = p."AcompanhamentoId"
        WHERE p."HorarioRecebimento" < NOW() - INTERVAL '0 minutes'
        AND a."Status" = 1
    );
"""

# Executar a query para remover da tabela Pedido
cur.execute(query_pedido)

# Aplicar as mudanças no banco de dados
conn.commit()

# Fechar cursor e conexão
cur.close()
conn.close()

print(f"Pedidos com status 'recebido' (1) e HorarioRecebimento superior a 2 horas removidos em {datetime.now()}.")
