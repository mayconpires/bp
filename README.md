# Desafio Braspag - API de Pagamento

##Tecnologias e padrões utilizados 

- .Net Core 2.2

- IoC (Inversion of Control), MVC, DDD, CQRS, Mediator, Repository, Factory. 

- Log e tratamento de erros: Para logar as exceptions foi utilizado o Serilog com um midleware para captura automática das exceptions.
Para padronizar o retorno das exceptions para os usuários foi utilizado o View Model ProblemDetails e adicionando o Content-Type application/problem+json.
Exemplo do retorno de uma exception: 
{
    "title": "Teste",
    "status": 500,
    "detail": "Problema no processamento.",
    "instance": "/mdr"
}


- Validações dos dados na entrada de dados da API: 

Foi utilizado o DataAnnotations nas View Models de entrada dos dados no sistema para bloquear a entrada de dados que 
estejam fora do range permitido. Para facilitar a compreensão para o usuário da API foi definido o padrão de retorno: 

Http Status Code: 422 - Unprocessable Entity retornando por exemplo o Json: 
Body de Retorno:

[{"Property":"Valor","Errors":["O Valor da Transaction deve conter no máximo duas casas decimais."]}].
Para implementar esse padrão foi criado um ActionFilter que deve ser adicionado em cada controller do projeto.
 
 - Validações de negócios na API:

Para validar as regras de negócio foi utilizado  uma classe de Notification para agrupar todas as inconsistências.
Antes de retornar para o usuário o controller verifica se há alguma inconsistência e caso haja envia para o usuário:

Http Status Code: 412 Precondition Failed
Body de Retorno:

[{"Code":"MDR01","Value":"A Adquirente não existe"}]



