# TesteCoordly

O projeto está implementado com as funcionalidades básicas de um CRUD ( com os métodos GET, POST, PUT, DELETE)
Fiz a persistência dos dados em um arquivo JSON, devido ao tempo de implementação

Está dividido em 4 projetos:

- Application - Aplicação principal, contendo os controllers com os métodos da API
- Core - onde estão os Dtos, Interface de service e DtosFactory
- Domain - As entidades e as interfaces de repositorio
- Infra - Implementação do Repositorio


# Executando o projeto
No projeto principal (TesteCoordly) executar o comando dotnet run, ou no Visual Studio, está setado como projeto principal e executar.

# Respostas das perguntas

------------------ PERGUNTA 1 --------------------------
// Primeiramente eu criaria um indice com os campos do where e do order by

CREATE INDEX idx_orders ON Onrders(OrderDate, CustomerID

// Segundo trocaria o SELECT * por somente as colunas a serem usadas na query e adicionaria uma paginação para trazer menos dados de cada vez
SELECT OrderID, CustomerID, OrderDate, OtherColumns
FROM Orders
WHERE OrderDate BETWEEN '2023-01-01' AND '2023-12-31'
ORDER BY CustomerID
OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY;


--------------- PERGUNTA 2 ----------------------------

O inner join traz o retorno somente de registros que se correspondem em ambas tabelas
Left Join retorna todas as linhas da esquerda e as correspondentes à da direita, preenche com null quando não tiver nenhuma correspondencia

--------------- PERGUNTA 3 ----------------------------

O Lazy carrega os dados somente quando acesso pela primeira vez, indicado pra melhorar desempenho, mas causa consultas adicionais para acessar as entidades que são relacionadas
O Eager os dados são buscados em uma unica consulta, isso evita consultas adicionais igual ao Lazy, porem pode trazer mais dados do que o necessario de uma vez
Explicit carrega os dados relacionados manualmente, de acordo com o necessário, usando o Load()

--------------- PERGUNTA 4 ----------------------------

Monolitica todo o sistema é construído como uma única aplicação, os componentes, interface, business layer e acesso a dados são agrupados em um unico código-base e é implantado como uma unica unidade
Microserviços é desenvolvido vários 