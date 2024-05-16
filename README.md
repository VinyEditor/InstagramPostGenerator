Este é um projeto de uma aplicação web ASP.NET que utiliza IA generativa para gerar três ideias de posts do Instagram com base em um tema fornecido pelo usuário.

Pré-requisitos
.NET 5.0
Visual Studio 2019 ou superior
Instalação
Clone o repositório

git clone https://github.com/seu-usuario/instagram-post-ideas-generator.git

Abra o projeto no Visual Studio
Configure a API Key do ChatGPT no arquivo appsettings.json


{
  "ChatGPT": {
    "ApiKey": "Your-OpenAI-API-Key"
  }
}

Compile e execute o projeto

Uso

Faça uma requisição HTTP POST para a rota /api/post-ideas com o tema desejado no corpo da requisição.

Exemplo de requisição:

POST /api/post-ideas HTTP/1.1
Host: localhost:5001
Content-Type: application/json

{
  "topic": "viagem"
}


Exemplo de resposta:


HTTP/1.1 200 OK
Content-Type: text/plain

1. "Mostre a beleza dos lugares que você está visitando com fotos incríveis e compartilhe fatos interessantes sobre eles."
2. "Compartilhe seus momentos de lazer, como passeios em barco, caminhadas ou piqueniques, com belas paisagens de fundo."
3. "Faça uma pergunta para seus seguidores sobre os lugares que eles gostariam de visitar e compartilhe suas próprias experiências."


Tecnologias utilizadas

ASP.NET Core 5.0
OpenAI API
Newtonsoft.Json


Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para detalhes.

Contribuição
Contribuições são bem-vindas! Por favor, leia o arquivo CONTRIBUTING para obter detalhes sobre como contribuir com este projeto.

Autores
Vinicius Cruzeiro Barbosa  
Iago Rosa Dias


Agradecimentos

Agradecimentos especiais aos colaboradores que fizeram contribuições significativas para este projeto.


Histórico de versões

0.1
Versão inicial


Meta

Este projeto foi desenvolvido com ❤️ por Viny e iago
