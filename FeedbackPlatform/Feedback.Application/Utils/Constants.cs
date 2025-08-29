namespace FeedbackApp.Application.Utils
{
    public class Constants
    {
        public enum TipoValidacao
        {
            Registro,
            Login,
            Atualizacao
        }

        public static class MensagemErro
        {
            public const string RequestNula = "Favor preencher os dados.";
            public const string NomeObrigatorio = "Nome é obrigatório.";
            public const string EmailObrigatorio = "Email é obrigatório.";
            public const string EmailJaCadastrado = "Email já cadastrado.";
            public const string EmailInvalido = "Email inválido.";
            public const string SenhaObrigatoria = "Senha é obrigatória.";
            public const string IdInvalido = "ID inválido.";
            public const string UsuarioNaoEncontrado = "Usuário não encontrado.";
            public const string CredenciaisInvalidas = "Credenciais inválidas.";
            public const string ErroValidacao = "Erro de Validação";
            public const string ConflitoCadastro = "Conflito de Cadastro";
            public const string AcessoNegado = "Acesso Negado";
            public const string RecursoInexistente = "Recurso Inexistente";
            public const string RequisicaoInvalida = "Requisição Inválida.";
            public const string ErroRemetenteDestinatarioIgual = "O remetente não pode ser o mesmo que o destinatário";
            public const string FeedbackTextoLimite = "O texto do feedback não pode exceder 500 caracteres.";
            public const string ApenasRemetenteAtualizaFeedback = "Apenas o remetente pode atualizar o feedback.";
            public const string FeedbackNaoEncontrado = "Feedback não encontrado.";
            public const string FeedbacksNaoEncontrados = "Feedbacks não encontrados.";
            public const string DestinatarioNaoInformado = "Destinatário não informado.";
            public const string DestinatarioNaoEncontrado = "Destinatário não encontrado.";
            public const string UsuarioExcluido = "Não é possível enviar feedback para um usuário excluído.";
        }
    }
}
