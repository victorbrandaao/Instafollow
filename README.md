# InstafollowWeb

InstafollowWeb é um aplicativo ASP\.NET Core que permite o upload de um arquivo JSON baixado do seu perfil do Instagram\. A ferramenta analisa seus dados e mostra quem são seus seguidores mútuos e quem deixou de seguir você\.

## Funcionalidades

\- Upload de arquivo JSON do Instagram
\- Análise de dados de seguidores
\- Exibição de seguidores mútuos e quem deixou de seguir

## Tecnologias Utilizadas

\- ASP\.NET Core
\- Bootstrap 5
\- Font Awesome
\- jQuery

## Estrutura do Projeto

\- `Controllers/`
  \- `InstagramController.cs` \- Controlador responsável pelo upload e processamento do arquivo JSON\.
\- `Views/`
  \- `Home/`
    \- `Index.cshtml` \- Página inicial\.
    \- `Privacy.cshtml` \- Página de política de privacidade\.
  \- `Instagram/`
    \- `Upload.cshtml` \- Página de upload do arquivo JSON\.
  \- `Shared/`
    \- `_Layout.cshtml` \- Layout compartilhado entre as páginas\.
\- `wwwroot/`
  \- `css/`
    \- `site.css` \- Estilos personalizados\.
  \- `lib/`
    \- `bootstrap/`
    \- `font\-awesome/`

## Configuração do Ambiente

1\. **Pré\-requisitos**:
   \- \[\.NET 6 SDK\]\(https://dotnet\.microsoft\.com/download/dotnet/6\.0\)
   \- \[Node\.js\]\(https://nodejs\.org/\) \(opcional, para gerenciamento de pacotes front\-end\)

2\. **Clone o repositório**:
   \```sh
   git clone https://github.com/victorbrandaao/InstafollowWeb.git
   cd InstafollowWeb
   \```

3\. **Restaurar pacotes NuGet**:
   \```sh
   dotnet restore
   \```

4\. **Executar o projeto**:
   \```sh
   dotnet run
   \```

## Como Usar

1\. Acesse o seu perfil no Instagram e toque no ícone de Configurações\.
2\. Vá até Segurança e selecione Baixar dados\.
3\. Confirme seu e\-mail e toque em Solicitar download\. O Instagram enviará uma cópia dos seus dados para o seu e\-mail\.
4\. Verifique seu e\-mail e baixe o arquivo JSON fornecido pelo Instagram\.
5\. Retorne ao InstafollowWeb e faça o upload do arquivo utilizando o formulário na página principal\.

## Contribuição

1\. Faça um fork do projeto\.
2\. Crie uma branch para sua feature \(`git checkout \-b feature/nova\-feature`\)\.
3\. Commit suas mudanças \(`git commit \-am 'Adiciona nova feature'`\)\.
4\. Faça o push para a branch \(`git push origin feature/nova\-feature`\)\.
5\. Abra um Pull Request\.

## Licença

Este projeto está licenciado sob a Licença MIT\. Veja o arquivo \[LICENSE\]\(LICENSE\) para mais detalhes\.

## Contato

\- **Victor Brandão**
  \- \[Instagram\]\(https://www\.instagram\.com/victorbrandaao\)
  \- \[LinkedIn\]\(https://www\.linkedin\.com/in/victorbrandaao\)
