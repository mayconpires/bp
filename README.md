# Desafio Braspag - API de Pagamento

## Executar o Projeto

- O sistema esta hospedado na máquina virtual da Azure no Windows Server. O IIS e o .Net Core 2.2 foram instalados no servidor.

**URL**

- http://191.232.162.9/
- Documentação da API: http://191.232.162.9/swagger
- Collection do Postman para download: https://www.getpostman.com/collections/b72659cd7ff13553732a
- Download do Environment do Postman:
https://raw.githubusercontent.com/mayconpires/bp/master/src/BP/Tests/IntegrationTest/AmbientePostman_Azure-BP.postman_environment.json

![Postman Environment](https://raw.githubusercontent.com/mayconpires/bp/master/img/Postman-Environment-Producao.PNG)

- Endpoint MDR: Get http://191.232.162.9/mdr

- Endpoint Transaction: Post + Body http://191.232.162.9/transaction

## Tecnologias e Padrões Utilizados 

- **Framework** .Net Core 2.2 com C#

- **Padrões:** IoC (Inversion of Control), MVC, DDD, CQRS, Mediator, Repository, Factory, TLD com XUnit e BDD. 

- **Log e tratamento de erros:** Para logar as exceptions foi utilizado o Serilog com um midleware para captura automática das exceptions.
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

![Json Retorno](https://raw.githubusercontent.com/mayconpires/bp/master/img/Validacao-View-Model.PNG)

 - **Validações de negócios na API:**

Para validar as regras de negócio foi utilizado  uma classe de Notification para agrupar todas as inconsistências.
Antes de retornar para o usuário o controller verifica se há alguma inconsistência e caso haja envia para o usuário:

Http Status Code: 412 Precondition Failed
Body de Retorno:

[{"Code":"MDR01","Value":"A Adquirente não existe"}]

![Json Retorno](https://raw.githubusercontent.com/mayconpires/bp/master/img/Validacao-Negocio.PNG)

## Como os Teste foram Feitos

- **Teste Unitário**

O foco dos testes unitários foram nos cálculos do Valor Líquido da Transaction com BDD. Foram testados todas as taxas das 3 adquirentes: A, B e C.
O Xunit e Fluent Assertions foram os frameworks utilizados. A tag [Theory] foi utilizado para realizar esses testes com diversos inputs de entrada.


![14 Testes Unitários](https://raw.githubusercontent.com/mayconpires/bp/master/img/Teste-Unitario-BDD-Evidencia.PNG)

- **Teste de Integração**

Para garantir que os componentes do sistema estão funcionando em ambiente de produção com qualidade. 
Foi utilizado o Postman Runner com uma Massa de Dados de 12 transactions diferentes para serem incluídas no
endpoint de Transaction. Cada retorno do Valor Líquido foi comparado com o valor esperado informado na massa de dados.

**Passos para os Testes de Integração**

1. Criação de uma planilha no Calc com a taxa de todas as adquirentes para cada bandeira e tipo de transação. 
A planilha forneceu a prova real para os testes de integração.

2. Criação de um Dataset em formato Json para ser importado no Postman a cada execução do teste de integração no Runner.

3. Desenvolvimento dos Testes na Aba Test do Postman no formato BDD - Behavior Driven Development.

4. Execução dos Testes no Runner do Postman importando a massa de dados criada no 2º passo.

5. Por fim a avaliação do resultado do Runner para verificar se retornou tudo com sucesso.

- Evidência do Teste

![Postman Runner Execução de 12 Testes](https://raw.githubusercontent.com/mayconpires/bp/master/img/Postman-Runner-Teste-Integracao-Evidencia.PNG)
 





