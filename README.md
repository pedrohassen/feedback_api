# Feedback Api

## Criação da Database

Para criar a migration e atualizar o banco de dados, use o **Package Manager Console** no Visual Studio:

```powershell
Add-Migration CriarTabelaUsuarios -Project FeedbackApp.Infrastructure -StartupProject FeedbackApp.API
Update-Database -Project FeedbackApp.Infrastructure -StartupProject FeedbackApp.API
