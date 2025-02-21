# API de Geração de EMV (Copia e Cola) Pix Estático

📌 Descrição

Este projeto é uma API desenvolvida em ASP.NET Core 8.0 utilizando Minimal API. Ele permite a geração EMVs (Copia e Cola) para Pix Estático. Além disso, oferece endpoints para listar os códigos gerados de forma geral ou filtrados por chave Pix.

🚀 Futuro do Projeto: Existe a possibilidade de implementação do Pix Dinâmico em versões futuras.

⚙️ Funcionalidades

🔹 Gerar Pix Estático: Criação de códigos EMV com base nos dados informados.

🔹 Listar todos os Pix gerados: Retorna uma lista com todos os códigos gerados.

🔹 Listar Pix por chave: Retorna uma lista de códigos filtrados por uma chave Pix específica.

🏗️ Tecnologias Utilizadas

ASP.NET Core 8.0

Minimal API

C#

🔧 Como Executar

Clone o repositório:

git clone https://github.com/DenisDiniz99/API-Pix.git

Acesse o diretório do projeto:

cd nome-do-repositorio

Restaure as dependências:

dotnet restore

Compile e execute a aplicação:

dotnet run

📖 Endpoints Disponíveis

➤ Gerar um Pix Estático

Método: POST

Rota: /pix/gerar

Payload:

{
  "Key": "suachave@pix.com",
  "MerchantName": "Nome do recebedor",
  "MerchantCity": "Cidade de Transação",
  "Total": 100.00
}

Resposta:

{
  "emv": "00020126330014BR.GOV.BCB.PIX0114suachave@pix5204000053039865802BR5920Nome do Beneficiário6009Sao Paulo62070503***6304ABCD"
}

➤ Listar todos os Pix gerados

Método: GET

Rota: /pix/

Resposta: Lista de códigos gerados.

➤ Listar Pix por chave específica

Método: GET

Rota: /pix/key/{chave}

Resposta: Lista de códigos gerados filtrados pela chave Pix fornecida.

📜 Licença

Este projeto é distribuído sob a licença MIT.
