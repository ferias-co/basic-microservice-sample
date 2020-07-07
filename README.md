# Basic Microservice Sample

![GitHub Logo](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)

Embora todas essas arquiteturas variem um pouco em seus detalhes, elas são muito semelhantes. 
Todos eles têm o mesmo objetivo, que é a separação de preocupações. Todos eles alcançam essa separação dividindo o software em camadas. Cada um possui pelo menos uma camada para regras de negócios e outra para interfaces.

Cada uma dessas arquiteturas produz sistemas que são:

 - Independente das estruturas: A arquitetura não depende da existência de alguma biblioteca de software carregado de recursos. Isso permite que você use essas estruturas como ferramentas, em vez de ter que limitar seu sistema às restrições limitadas. Testável.
 - As regras de negócios podem ser testadas sem a interface do usuário, banco de dados, servidor da Web ou qualquer outro elemento externo.
 - Independente da interface do usuário. A interface do usuário pode mudar facilmente, sem alterar o restante do sistema. Uma interface da Web pode ser substituída por uma interface do console, por exemplo, sem alterar as regras de negócios.
 - Independente do banco de dados. Você pode trocar o Oracle ou SQL Server, por Mongo, BigTable, CouchDB ou qualquer outra coisa. Suas regras de negócios não estão vinculadas ao banco de dados.
 - Independente de qualquer agência externa. Na verdade, suas regras de negócios simplesmente não sabem nada sobre o mundo exterior.