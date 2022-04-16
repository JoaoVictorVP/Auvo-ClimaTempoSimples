# Auvo-ClimaTempoSimples

![image](https://1.bp.blogspot.com/-7QWWHMNeLN4/YHg-sUGr2CI/AAAAAAAACeM/UNI4wisSKr0guvDIFzAGQEonOxfZHhP3QCLcBGAsYHQ/s0/ANIMACAO_FRANCIS_CORRENDO.gif)

Projeto para teste de trabalho

## Instruções para avaliação
 * Ter uma instância do SQL Server rodando com as credenciais de máquina padrão
 * Fazer build da solução
 * Executar o projeto de console Auvo.Manager para:
  - Criar o banco de dados local a partir dos modelos
  - Adicionar dados aleatórios para consumo (como não foi específicado se o nome das cidades/dados climáticos deveria ser real, a implantação é feita com dados aleatórios)
 * Executar o site em localhost

 * Em caso de erros, execute o seguinte comando no gerenciador de pacotes:<br />
  Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r<br/>
  Isso se deve a um bug não do projeto em si mas do package referenciado pelo ASP.NET DotnetCompilerPlatform, esse comando irá reinstalar o pacote e resolver possíveis problemas com a dependência

Feito isso, o projeto deverá estar funcional e utilizável para avaliação.

## Demonstração

Página inicial
![image](https://user-images.githubusercontent.com/98046863/163687706-d1a9d77c-c877-4e83-93a7-92d0c6d1a4ae.png)

Seleção de cidade 1
![image](https://user-images.githubusercontent.com/98046863/163687713-f4ea31c8-a6fe-4177-9efd-527bffb0493d.png)

Seleção de cidade 2
![image](https://user-images.githubusercontent.com/98046863/163687730-b2348259-5c92-4a52-b0d1-ff1e376e0c6f.png)

Sobre mim
![image](https://user-images.githubusercontent.com/98046863/163687742-276419f0-3706-4a94-99f6-deec626eb338.png)
