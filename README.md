# Desafio Braspag - API de Pagamento

## Tecnologias e padrões utilizados 

- .Net Core 2.2

- IoC (Inversion of Control), MVC, DDD, CQRS, Mediator, Repository, Factory, TLD com XUnit e BDD. 

- Log e tratamento de erros: Para logar as exceptions foi utilizado o Serilog com um midleware para captura automática das exceptions.
Para padronizar o retorno das exceptions para os usuários foi utilizado o View Model ProblemDetails e adicionando o Content-Type application/problem+json.
Exemplo do retorno de uma exception: 
{
    "title": "Teste",
    "status": 500,
    "detail": "Problema no processamento.",
    "instance": "/mdr"
}


- **Validações dos dados na entrada de dados da API:** 

Foi utilizado o DataAnnotations nas View Models de entrada dos dados no sistema para bloquear a entrada de dados que 
estejam fora do range permitido. Para facilitar a compreensão para o usuário da API foi definido o padrão de retorno: 

Http Status Code: 422 - Unprocessable Entity retornando por exemplo o Json: 
Body de Retorno:

[{"Property":"Valor","Errors":["O Valor da Transaction deve conter no máximo duas casas decimais."]}].
Para implementar esse padrão foi criado um ActionFilter que deve ser adicionado em cada controller do projeto.
 
 - **Validações de negócios na API:**

Para validar as regras de negócio foi utilizado  uma classe de Notification para agrupar todas as inconsistências.
Antes de retornar para o usuário o controller verifica se há alguma inconsistência e caso haja envia para o usuário:

Http Status Code: 412 Precondition Failed
Body de Retorno:

[{"Code":"MDR01","Value":"A Adquirente não existe"}]

## Como os Teste foram Feitos

- **Teste Unitário**

O foco dos testes unitários foram nos cálculos do Valor Líquido da Transaction com BDD. Foram testados todas as taxas das 3 adquirentes: A, B e C.
O Xunit e Fluent Assertions foram os frameworks utilizados. A tag [Theory] foi utilizado para realizar esses testes com diversos inputs de entrada.

- **Teste de Integração**

Para garantir que os componentes do sistema estão funcionando em ambiente de produção com qualidade foi utilizado o Postman Runner 
com um Dataset de 12 transactions diferentes para serem incluídos no endpoint de transaction cada retorno do valor líquido foi comparado
com o valor esperado informado no dataset.

**Passos para o testes de integração**

1. Criação de uma planilha no Calc com a taxa de todas as adquirentes para cada bandeira e tipo de transação. 
A planilha forneceu a prova real para os testes de integração.

2. Criação de um Dataset em formato Json para ser importado pelo Postman a cada execução do teste de integração no Runner.

3. Desenvolvimento dos Testes na Aba Test do Postman no formato BDD - Behavior Driven Development.

4. Execução do Teste no Runner do Postman importando a massa de dados criado no 2º passo.

5. Avaliação do resultado do Runner para verificar se retornou tudo com sucesso.
 





