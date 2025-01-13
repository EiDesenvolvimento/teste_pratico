using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa1 : System.Web.UI.Page
	{
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                // Adicionando dados dos controls na instância de pessoa
                var pessoa = new DAO.PESSOAS
                {
                    NOME = txtNome.Text,
                    CPF = txtCpf.Text,
                    RG = txtRg.Text,
                    TELEFONE = txtTelefone.Text,
                    EMAIL = txtEmail.Text,
                    SEXO = ddlSexo.SelectedValue,
                    DATA_NASCIMENTO = DateTime.ParseExact(txtDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                };

                // Preparando o contexto de validação
                var results = new List<ValidationResult>();
                var context = new ValidationContext(pessoa);

                // Verificando as validações do DataAnnotations presente na DAO.PESSOAS
                if (!Validator.TryValidateObject(pessoa, context, results, true))
                {
                    // Exibe o erro de validação
                    msgErro.Text = results[0].ToString();
                    msgErro.Visible = true;
                    return;
                } 

                Gravar(pessoa);

                // Limpandp os campos do form após a gravação
                Limpar();
            }
            catch (FormatException)
            {
                msgErro.Visible = true;
                msgErro.Text = "Formato de data inválido. Por favor, use o formato DD/MM/YYYY.";
            }
            catch (Exception ex)
            {
                msgErro.Visible = true;
                msgErro.Text = "Ocorreu um erro inesperado: " + ex.Message;
            }
        }

        /// <summary>
        /// Persistir os dados no Banco.
        /// </summary>
        /// <param name="pessoa">DAO.PESSOAS</param>
        private void Gravar(DAO.PESSOAS pessoa)
		{
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
			//Limpando cada um dos controls
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtRg.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtDataNascimento.Text = string.Empty;
			ddlSexo.SelectedIndex = 0;
            msgErro.Text = string.Empty;
        }
	}
}