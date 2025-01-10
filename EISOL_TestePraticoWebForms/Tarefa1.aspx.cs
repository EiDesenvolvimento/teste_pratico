using System;
using Microsoft.Ajax.Utilities;

namespace EISOL_TestePraticoWebForms
{
	public partial class Tarefa1 : System.Web.UI.Page
	{
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
			if (nome.Length > 50 || email.Length > 80 || cpf.Length > 11 || rg.Length > 9 || tel.Length > 13)
			{
				msgErro.Text = "O campo ultrapassa o limite de caracteres permitidos";
                msgErro.Visible = true;
                return;
			}

			// Preencher o objeto com os dados do formulário
			pessoa.NOME = nome;
			pessoa.EMAIL = email;
			pessoa.CPF = cpf;
			pessoa.RG = rg;
			pessoa.SEXO = ddlSexo.SelectedValue;
			pessoa.TELEFONE = tel;
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