using System;

namespace EISOL_TestePraticoWebForms
{
	public partial class Tarefa1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Para saber se o seu registro foi realmente adicionado à tabela, utilize um dos métodos de BLL.PESSOAS.
			// Você poderá realizar a depuração aqui no VS e conferir se tudo deu certo.
			// Sinta-se livre para fazer a sua arte, mas tente fazer o formulário funcionar ok!
		}

		protected void btnGravar_Click(object sender, EventArgs e)

		{
			var pessoa = new DAO.PESSOAS();

            // Validação de campos obrigatórios no servidor
            if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				msgErro.Text = "Preencha o campo NOME";
				msgErro.Visible = true;
				return;
			}

            if (string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                msgErro.Text = "Preencha o campo CPF";
                msgErro.Visible = true;
                return;
            }

            // Limitação do tamanho dos campos
            pessoa.NOME = txtNome.Text.Length > 200 ? txtNome.Text.Substring(0, 200) : txtNome.Text;
            pessoa.CPF = txtCpf.Text.Length > 11 ? txtCpf.Text.Substring(0, 11) : txtCpf.Text;
            pessoa.RG = txtRg.Text.Length > 15 ? txtRg.Text.Substring(0, 15) : txtRg.Text;
            pessoa.TELEFONE = txtTelefone.Text.Length > 20 ? txtTelefone.Text.Substring(0, 20) : txtTelefone.Text;
            pessoa.EMAIL = txtEmail.Text.Length > 200 ? txtEmail.Text.Substring(0, 200) : txtEmail.Text;
            pessoa.SEXO = ddlSexo.SelectedValue;
            pessoa.DATA_NASCIMENTO = (DateTime)(DateTime.TryParse(txtDataNascimento.Text, out var data) ? data : (DateTime?) null);

            // Preenchimento do objeto de persistência
            this.Gravar(pessoa);

			// Limpar os campos do formulário após salvar os dados
			this.Limpar();
		}

		/// <summary>
		/// Persistir os dados no Banco.
		/// </summary>
		/// <param name="pessoa">DAO.PESSOAS</param>
		private void Gravar(DAO.PESSOAS pessoa)
		{
			// Se a pessoa for uma pessoa de verdade e feliz, com certeza ela será lembrada pelo banco de dados.
			new BLL.PESSOAS().Adicionar(pessoa);
			this.Alertar();
		}

		/// <summary>
		/// Apresentar o alerta de sucesso na operação.
		/// </summary>
		private void Alertar()
		{
			this.divAlerta.Visible = true;
		}

		/// <summary>
		/// Limpar os campos após a presistência dos dados.
		/// </summary>
		private void Limpar()
		{
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtRg.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlSexo.SelectedIndex = 0;
            txtDataNascimento.Text = string.Empty;
            msgErro.Visible = false;
            divAlerta.Visible = false;
        }
	}
}