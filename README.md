# BlackGrimoire
# Documento de Escopo: Grimório D&D

## 1. Visão Geral do Projeto
O projeto consiste em uma aplicação web desenvolvida em dupla, atuando como um catálogo digital (Grimório) para magias de Dungeons & Dragons. A aplicação tem acesso aberto, sem necessidade de autenticação (login), com foco em uma navegação rápida, leitura de descrições e fácil gerenciamento (CRUD) do catálogo.

## 2. Arquitetura e Stack Tecnológica
A divisão do projeto se dará entre Front-end e Back-end.
* **Back-end:** C# e .NET. Estruturação do projeto utilizando princípios de **Clean Architecture**, separando as camadas de domínio, aplicação e infraestrutura para manter o código testável e escalável.
* **Banco de Dados:** SQLite.
* **ORM:** Entity Framework Core, facilitando o mapeamento do modelo relacional e a aplicação de migrations.
* **Front-end:** SPA (Single Page Application) utilizando frameworks modernos (como React, Vue ou Angular) a ser definido e implementado pelo responsável pelo Front-end.
* **Documentação de API:** Swagger/OpenAPI.

## 3. Modelagem de Dados
O banco de dados relacional foi estruturado para suportar o fato de que uma magia pode pertencer a múltiplas classes, a apenas uma, ou a nenhuma (0 a N).

### Tabelas Principais

#### Tabela `Magias`
Armazena as informações descritivas e mecânicas das magias.
* `Id`: Identificador Único (Guid ou Int)
* `Nome`: String (Ex: "Bola de Fogo")
* `Nivel`: Inteiro (Ex: 3)
* `Escola`: String (Ex: "Evocação")
* `TempoConjuracao`: String (Ex: "1 ação")
* `Alcance`: String (Ex: "45 metros")
* `Duracao`: String (Ex: "Instantânea")
* `Concentracao`: Booleano (Sim/Não)
* `Ritual`: Booleano (Sim/Não)
* `Componentes`: String (Ex: "V, S, M")
* `Descricao`: Texto longo com a mecânica principal
* `DescricaoNiveisSuperiores`: Texto longo (Anulável/Nullable)

#### Tabela `Classes`
Armazena as classes disponíveis no sistema.
* `Id`: Identificador Único
* `Nome`: String (Ex: "Mago", "Feiticeiro", "Bardo")

#### Tabela Associativa `Magias_Classes`
Resolve o relacionamento de Muitos-para-Muitos (N:N).
* `MagiaId`: Chave estrangeira para `Magias.Id`
* `ClasseId`: Chave estrangeira para `Classes.Id`

## 4. Contratos da API (Endpoints RESTful)
O Back-end deverá expor os seguintes endpoints principais para consumo do Front-end, utilizando as ações HTTP básicas. 

### Recurso: Magias (`/api/magias`)
* **`GET /api/magias`**
  * **Objetivo:** Retorna a lista completa de magias.
  * **Dica:** Retornar dados resumidos (Id, Nome, Nivel, Escola) para otimizar o carregamento. Futuramente, pode receber parâmetros de Query para paginação ou filtros (`?nivel=3&classe=Mago`).
* **`GET /api/magias/{id}`**
  * **Objetivo:** Retorna os dados completos de uma magia específica, incluindo a lista de Classes vinculadas.
* **`POST /api/magias`**
  * **Objetivo:** Adiciona uma nova magia. O payload deve conter os dados da magia e um array opcional de `ClasseId`s.
* **`PUT /api/magias/{id}`**
  * **Objetivo:** Atualiza uma magia existente e sincroniza as classes vinculadas na tabela associativa.
* **`DELETE /api/magias/{id}`**
  * **Objetivo:** Remove uma magia e limpa seus vínculos.

### Recurso: Classes (`/api/classes`)
* **`GET /api/classes`**
  * **Objetivo:** Retorna todas as classes para popular selects/filtros no front-end.
* **`POST /api/classes`**
  * **Objetivo:** Cria uma nova classe.
* **`DELETE /api/classes/{id}`**
  * **Objetivo:** Remove uma classe.

## 5. Processos do Front-End
Para que o front-end consuma a API de forma eficiente e entregue uma boa experiência ao usuário, o desenvolvimento deverá seguir estas etapas:

### 5.1. Prototipagem e UI/UX (Opcional, mas recomendado)
* Definir o layout visual.
* Estruturar o fluxo de navegação antes de codificar.

### 5.2. Configuração do Projeto
* Setup inicial do framework escolhido (React, Vue, etc.).
* Configuração do roteamento (ex: React Router) para navegação entre as páginas (Home/Listagem, Detalhes da Magia, Formulário de Criação/Edição).
* Definição da biblioteca de componentes visuais (Tailwind CSS, Material UI, Bootstrap, ou CSS puro).

### 5.3. Integração com a API
* Configuração de um cliente HTTP (como Axios ou a API nativa Fetch).
* Criação de serviços (Services) no Front-end mapeando exatamente os endpoints definidos no Back-end, utilizando o Swagger como documentação de referência.
* Tratamento de estados de carregamento (Loading spinners) e erros (Mensagens de falha caso a API retorne 400 ou 500).



### Tarefas para o Front-End
* **Tela Principal (Listagem):** Criar a interface que consome o `GET /api/magias`. Renderizar as magias em formato de lista ou cards. Incluir barra de busca e filtros (por nível, classe ou escola).
* **Tela de Detalhes:** Criar a visão expandida de uma magia, consumindo o `GET /api/magias/{id}` para mostrar todas as propriedades (Alcance, Tempo de Conjuração, Componentes, Descrição Completa).
* **Formulários (CRUD):** Implementar formulários para Criação e Edição de magias.
  * Realizar a validação de campos obrigatórios no lado do cliente antes de enviar o `POST` ou `PUT`.
  * Incluir um componente de seleção múltipla (Multi-select) alimentado pelo `GET /api/classes` para vincular as classes à magia.

## Tarefas para o Back-End
1. **Mock e Swagger (Back-end):** A primeira entrega do Back-end deve ser a estrutura de Controllers rodando com dados falsos (mockados) e o Swagger ativo. Isso libera o Front-end para criar serviços e testar a interface imediatamente.
2. **Integração de Banco (Back-end):** Após disponibilizar os mocks, o EF Core e o banco SQLite serão implementados para substituir as listas em memória pela persistência real.
3. **Tratamento de Erros e CORS:** A API deve estar configurada para retornar os Status Codes corretos (`404` para não encontrado, `400` para erro de validação) e possuir o CORS liberado para o ambiente local de desenvolvimento do Front-end.
