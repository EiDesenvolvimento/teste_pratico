using System;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa2 : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            // Para saber se o seu registro foi realmente adicionado à tabela, utilize um dos métodos de BLL.PESSOAS.
            // Você poderá realizar a depuração aqui no VS e conferir se tudo deu certo.
            // Sinta-se livre para fazer a sua arte, mas tente fazer o formulário funcionar ok!
        }

        protected void BtnGravar_Click(object sender, EventArgs e)
        {
            // Objeto DAO para representar os dados
            var pessoa = new DAO.PESSOAS();
            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string rg = txtRg.Text.Trim();
            string cpf = txtCpf.Text.Trim();
            string tel = txtTelefone.Text.Trim();

            // Validar campos obrigatórios
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(rg) || string.IsNullOrWhiteSpace(tel) || ddlSexo.SelectedValue == "[Selecione]" || string.IsNullOrWhiteSpace(txtDataNascimento.Text))
            {
                msgErro.Text = "***Todos os campos são obrigatórios.";
                msgErro.Visible = true;
                return;
            }

            // Limitar o tamanho dos campos
            if (nome.Length > 50 || email.Length > 80 || cpf.Length > 14 || rg.Length > 9 || tel.Length > 15 )
            {
                msgErro.Text = "O campo ultrapassa o limite de caracteres permitidos";
                msgErro.Visible = true;
                return;
            }

            if (!IsValidCpf(txtCpf.Text))
            {
                msgErroCpf.Text = "CPF inválido.";
                msgErroCpf.Visible = true;
                return;
            }

            // Validação de Telefone (Formato "(xx) xxxx-xxxx")
            if (!IsValidTelefone(txtTelefone.Text))
            {
                msgErroTel.Text = "Telefone inválido.";
                msgErroTel.Visible = true;
                return;
            }

            // Validação de Data de Nascimento
            if (!IsValidData(txtDataNascimento.Text))
            {
                msgErroData.Text = "Data de Nascimento inválida.";
                msgErroData.Visible = true;
                return;
            }

            // Validação de E-mail
            if (!IsValidEmail(txtEmail.Text))
            {
                msgErroEmail.Text = "E-mail inválido.";
                msgErroEmail.Visible = true;
                return;
            }

            // Preencher o objeto com os dados do formulário
            pessoa.NOME = nome;
            pessoa.EMAIL = email;
            pessoa.CPF = cpf.Replace(",", "").Replace(".", "").Replace("-", ""); ;
            pessoa.RG = rg;
            pessoa.SEXO = ddlSexo.SelectedValue;
            pessoa.TELEFONE = tel.Replace(",", "").Replace(".", "").Replace("-", ""); ;
            pessoa.DATA_NASCIMENTO = DateTime.Parse(txtDataNascimento.Text);

            try
            {
                // Persistir os dados
                this.Gravar(pessoa);

                // Limpar os campos do formulário após salvar
                this.Limpar();

                // Mensagem de sucesso
                msgErro.Text = string.Empty; // Limpa mensagem de erro
            }
            catch (Exception ex)
            {
                // Log do erro (opcional)
                msgErro.Text = $"Erro ao salvar os dados: {ex.Message}";
            }

        }

        private void Gravar(DAO.PESSOAS pessoa)
        {
            // Implementação do método
            new BLL.PESSOAS().Adicionar(pessoa);
            this.divAlerta.Visible = true;

        }

        private bool IsValidCpf(string cpf)
        {
            // Verifique se o CPF é válido (exemplo simples de verificação)
            return cpf.Contains(".") && cpf.Contains("-");
        }

        private bool IsValidTelefone(string telefone)
        {
            // Verifique se o telefone é válido
            return telefone.Contains("(");
        }

        private bool IsValidEmail(string email)
        {
            // Validação simples de email
            return email.Contains("@") && email.Contains(".");
        }

        private bool IsValidData(string email)
        {
            // Validação simples de data
            return email.Contains("/");
        }

        /// <summary>
        /// Limpar os campos do formulário.
        /// </summary>
        private void Limpar()
        {
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtRg.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtDataNascimento.Text = string.Empty;
            msgErro.Text = string.Empty;

        }
    }
}