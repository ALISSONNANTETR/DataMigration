# 🚀 DataMigration

Ferramenta genérica para **transferência de dados entre bancos de dados relacionais**, com foco inicial em migração entre **SQL Server** e **PostgreSQL**.

O projeto foi desenvolvido com o objetivo de ser **simples de usar no início**, mas com arquitetura preparada para evoluir para uma solução mais robusta, incluindo interface gráfica (WPF) e suporte a múltiplos bancos.

---

## ⏸️ Status do Projeto

Este projeto encontra-se **temporariamente pausado**.

O desenvolvimento foi interrompido estrategicamente para priorizar:

* Outros projetos em andamento
* Estudos voltados ao aprofundamento técnico (arquitetura, bancos de dados e engenharia de software)

A pausa tem como objetivo permitir que, ao retomar o desenvolvimento, o projeto evolua com:

* Melhor estrutura arquitetural
* Novas funcionalidades mais bem fundamentadas
* Maior robustez e qualidade de código

🚧 **Importante:**
O projeto não foi abandonado — trata-se de uma pausa planejada para evolução técnica.

---

## 🎯 Objetivo

Permitir a migração de dados entre bancos de forma:

* Genérica (sem necessidade de models por tabela)
* Performática (uso de operações em massa)
* Extensível (fácil adição de novos bancos)
* Auditável (com sistema de logs)

---

## 🧱 Arquitetura

O projeto segue uma estrutura modular baseada em responsabilidades:

```
DataMigration/
│
├── Program.cs
├── appsettings.json
│
├── Services/
│   ├── PostgresReader.cs
│   ├── SqlServerWriter.cs
│   └── MigrationService.cs
│
├── Utils/
│   ├── DataTableHelper.cs
│   └── Logger.cs
```

### 🔹 Componentes principais

#### 🔄 MigrationService

Responsável por orquestrar todo o processo de migração:

* Leitura dos dados
* Transformação
* Escrita no banco destino
* Controle de fluxo e logs

---

#### 📥 PostgresReader

* Conecta ao PostgreSQL
* Executa queries dinâmicas (`SELECT * FROM tabela`)
* Retorna os dados para processamento

---

#### 📤 SqlServerWriter

* Recebe dados em formato `DataTable`
* Utiliza `SqlBulkCopy` para inserção em massa
* Alta performance para grandes volumes

---

#### 🧰 DataTableHelper

* Converte `DataReader` → `DataTable`
* Permite manipulação genérica de dados
* Base para operações independentes de schema

---

#### 📝 Logger

* Registro de logs no console e arquivo
* Suporte a níveis (`INFO`, `WARN`, `ERROR`)
* Essencial para auditoria e debugging

---

## ⚙️ Tecnologias utilizadas

* .NET (C#)
* SQL Server
* PostgreSQL
* Npgsql (driver PostgreSQL)
* SqlBulkCopy (SQL Server)

---

## 🚀 Como executar

### 1. Configurar conexões

Edite o arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Postgres": "Host=localhost;Database=...;Username=...;Password=...",
    "SqlServer": "Server=...;Database=...;User Id=...;Password=...;"
  }
}
```

---

### 2. Executar o projeto

```bash
dotnet run
```

---

### 3. Migrar uma tabela

No `Program.cs`, defina:

```csharp
migrationService.MigrateTable("usuarios");
```

---

## 🔁 Funcionalidades atuais

* ✅ Migração PostgreSQL → SQL Server
* ✅ Estrutura genérica (sem models fixos)
* ✅ Logs básicos
* ✅ Inserção em massa

---

## 🧠 Decisões de arquitetura

### ❌ Sem uso de Models por tabela

Para evitar acoplamento e permitir migração genérica, o projeto utiliza `DataTable` ao invés de classes tipadas.

---

### ⚡ Uso de Bulk Insert

Evita `INSERT` linha a linha, melhorando drasticamente a performance.

---

### 📦 Separação por serviços

Permite:

* Reutilização de código
* Testabilidade
* Evolução futura (ex: adicionar MySQL)

---

## ⚠️ Limitações atuais

* Não trata automaticamente diferenças de schema
* Não valida integridade referencial
* Não realiza migração incremental (delta)
* Não suporta transformação de dados customizada

---

## 🔮 Próximos passos

* [ ] Suporte bidirecional completo (SQL Server ↔ PostgreSQL)
* [ ] Interface gráfica (WPF)
* [ ] Configuração dinâmica de tabelas
* [ ] Mapeamento automático de tipos
* [ ] Sistema de logs mais robusto (ex: Serilog)
* [ ] Suporte a múltiplos bancos (MySQL, SQLite)
* [ ] Execução em lote (várias tabelas)
* [ ] Migração incremental (CDC)

---

## 💡 Possíveis melhorias futuras

* Paralelização da migração
* Retry inteligente com fallback
* Validação de consistência de dados
* Exportação/importação via arquivos (CSV, Parquet)

---

## 📚 Motivação

Este projeto foi desenvolvido como parte do aprendizado em:

* Integração entre bancos de dados
* Arquitetura de software
* Engenharia de dados
* Desenvolvimento de ferramentas escaláveis

---

## 👨‍💻 Autor

Desenvolvido por Alisson Nantet
Focado em evolução contínua e construção de ferramentas reais para uso prático.

---

## 📄 Licença

Uso livre para fins de estudo e aprimoramento.
