# Basic Microservice Sample

![GitHub Logo](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)

Embora todas essas arquiteturas variem um pouco em seus detalhes, elas s�o muito semelhantes. 
Todos eles t�m o mesmo objetivo, que � a separa��o de preocupa��es. Todos eles alcan�am essa separa��o dividindo o software em camadas. Cada um possui pelo menos uma camada para regras de neg�cios e outra para interfaces.

Cada uma dessas arquiteturas produz sistemas que s�o:

 - Independente das estruturas: A arquitetura n�o depende da exist�ncia de alguma biblioteca de software carregado de recursos. Isso permite que voc� use essas estruturas como ferramentas, em vez de ter que limitar seu sistema �s restri��es limitadas. Test�vel.
 - As regras de neg�cios podem ser testadas sem a interface do usu�rio, banco de dados, servidor da Web ou qualquer outro elemento externo.
 - Independente da interface do usu�rio. A interface do usu�rio pode mudar facilmente, sem alterar o restante do sistema. Uma interface da Web pode ser substitu�da por uma interface do console, por exemplo, sem alterar as regras de neg�cios.
 - Independente do banco de dados. Voc� pode trocar o Oracle ou SQL Server, por Mongo, BigTable, CouchDB ou qualquer outra coisa. Suas regras de neg�cios n�o est�o vinculadas ao banco de dados.
 - Independente de qualquer ag�ncia externa. Na verdade, suas regras de neg�cios simplesmente n�o sabem nada sobre o mundo exterior.