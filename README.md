<h2>API em .NET Core integrada a um cluster MongoDB</h2>

Esta API foi criada como exercício de aprendizado no desenvolvimento de uma API em .NET Core com HTTP e integração com o MongoDB, em aula com Gabriel Faraday, da DIO (Digital Innovation One).

------------------

Em relação ao projeto desenvolvido optei por fazer uma  API completamente nova, com a finalidade de criar um cadastro de Sócios de um Clube:

* A entidade desenvolvida permite o cadastro de Nome, Telefone, Data de Nascimento e Data de Ingresso no Clube, além da opção Ativo (Boolean);
* Incluídas todas as opções CRUD e ainda listagem dos sócios Ativos e/ou Inativos de forma separada.

--------------------

Com o desenvolvimento de uma nova API foi possível exercitar e aprender todas as dimensões do processo de desenvolvimento.

O maior desafio esteve relacionado ao aprendizado do MongoDB e especialmente o processo de conexão da API com este.

Obs.: É possível executar a API, via Swager.

-----------------

Requisitos para a execução do projeto:

- Conexão com o banco de dados MongoDB, com alteração da ConnectionString no arquivo "appsettings.json";
- Inclusão das dependências MongoDB.Bson e MongoDB.Driver.



