Este projeto de exemplo foi construído utilizando as seguintes tecnologias:

ASP.NET MVC   v5.2.3, 
BootStrap v3.3,
WCF, 
Entity Framework Code First v6.0,
Sql Server v2016,
.NET Framework v4.62.

Usarei alguns conceitos básicos de DDD (Domain Drive Design) neste exemplo :

Basicamente teremos as seguintes funcionalidades na aplicação:

Cadastro de cliente.
Cadastro de endereço do cliente.
Cadastro de telefone do cliente.
 

Observações importantes.
A publicação do Wcf e Mvc poderá ser feita na nuvem/on promisse.(IIS).
A ConnectionString deverá ser alterada nos respectivos projetos WebConfig dos projetos (Wcf e Mvc).
A publicação do banco de dados poderá ser feita via migrations/sql database project ou via script.
O Script está na pasta Documentação.
O Xml de request do WCF está na pasta Documentação.
