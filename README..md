# Learn MyTodo
----------------------------------------------

## Criando o projto vazio.
`dotnet new web -o <NOME_PROJETO>`

Note: optcionalmente pode ser especificar a versão a ser criado a api.
`dotnet new web -o <NOME_PROJETO> -f net6.0`

## Adcionando o pacote EF para trabalhar com a DB
`dotnet add package Microsoft.EntityFrameworkCore`
`dotnet add package Microsoft.EntityFrameworkCore.<SqLite|MySQL|SqlServer|PgSqL>`

## Pacote para gerar  as migrations
`dotnet add package Microsoft.EntityFrameworkCore.Desing`

## Para os comandos `dotnet ef`, é necessario instalar a ferramenta do EF, caso já tenha, pule esse passo
`dotnet tool install --global dotnet-ef`

## Criando as migrations
`dotnet ef migrations add <NomeDaMigracao>`

Note: Antes de criar a migração é preciso ter criado a class de DbContext que representa o banco e as propriedades DbSet que representam as tabelas.

## Depois de criar as migrations, é preciso rodar o comando para criar a base ou atualizar a base
`dotnet ef database update`

Note: Pode existir mais de 1 mifgrations para a sem problema

## Para realizar o Rollback (é sempre na última migração)
`dotnet ef migrations remove`