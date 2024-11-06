# InstafollowWeb

InstafollowWeb é um aplicativo ASP.NET Core que permite o upload de um arquivo JSON baixado do seu perfil do Instagram. A ferramenta analisa seus dados e mostra quem são seus seguidores mútuos e quem deixou de seguir você.

## Funcionalidades

- Upload de arquivo JSON do Instagram
- Análise de dados de seguidores
- Exibição de seguidores mútuos e quem deixou de seguir

## Tecnologias Utilizadas

- ASP.NET Core
- Bootstrap 5
- Font Awesome
- jQuery

## Estrutura do Projeto

### Controllers/
- **InstagramController.cs** - Controlador responsável pelo upload e processamento do arquivo JSON.

### Views/
#### Home/
- **Index.cshtml** - Página inicial.
- **Privacy.cshtml** - Página de política de privacidade.

#### Instagram/
- **Upload.cshtml** - Página de upload do arquivo JSON.

#### Shared/
- **_Layout.cshtml** - Layout compartilhado entre as páginas.

### wwwroot/
#### css/
- **site.css** - Estilos personalizados.

#### lib/
- **bootstrap/** 
- **font-awesome/**

## Configuração do Ambiente

### Pré-requisitos:
- .NET 6 SDK
- Node.js (opcional, para gerenciamento de pacotes front-end)

### Passos para Instalar:

1. Clone o repositório:

   ```bash
   git clone https://github.com/victorbrandaao/InstafollowWeb.git
   cd InstafollowWeb

2. Restaure os pacotes NuGet:
  ```bash
dotnet restore
```

3. Execute o projeto
