using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web.UI;

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
			/* Olá!
             * Trabalhamos com camadas de acesso a dados e negócios, isso também é conhecido por arquitetura em camadas ou N-Tier.
             * Observe que passamos um objeto tipado da camada de acesso (DAO - Data Access Object).
             * E devemos utilizar esse objeto DAO e chamar os métodos da camada de negócios (BLL - Business Logical Layer).
             * É o que por padrão o MVC te induz a fazer, mas aqui no WebForms devemos ter esse cuidado para não dificultar as coisas criando códigos macarrônicos (eita).
             * Você está livre para espiar os códigos e entender o seu funcionamento.
             * Só não vai me bagunçar os códigos pois deu muito trabalho fazer tudo isso aqui =/
             * */
			var pessoa = new DAO.PESSOAS();

            // Parece que faltam algumas coisas aqui! =/

            // O Objeto pessoa não parece ser uma pessoa de verdade ainda. 
            // As pessoas não são objetos mas aqui podemos considerá-las assim =S
            // - Faça as devidas atribuições ao objeto 'pessoa' para que ela seja uma pessoa de verdade e feliz!

            // Verifique os tamanhos dos campos da tabela e a obrigatoriedade deles e faça o devido tratamento para evitar erros.
            // - O leiaute da tabela em questão (TB_TESTE_PESSOAS) poderá ser verificado nos arquivos .sql anexados ao projeto.

            /* SEU OBJETIVO (TAREFA 1)
             * Envie um objeto com dados, passando pela camada de negócios e que possibilite salvar os dados do formulário preenchido no banco de dados.
             */

            // Coloque o seu lindo código aqui! (O_o)


            try
            {
                pessoa.Nome = txtNome.Text.Trim();
                pessoa.CPF = txtCpf.Text.Trim();
                pessoa.Email = txtEmail.Text.Trim();
                pessoa.Telefone = txtTelefone.Text.Trim();
                pessoa.Sexo = ddlSexo.SelectedValue;
                pessoa.DataNascimento = DateTime.TryParse(txtDataNascimento.Text, out DateTime data) ? data : (DateTime?)null;

                // Validação dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(pessoa.Nome) || string.IsNullOrWhiteSpace(pessoa.CPF) || string.IsNullOrWhiteSpace(pessoa.Email))
                {
                    msgErro.Text = "Os campos Nome, CPF e Email são obrigatórios preencher!";
                    msgErro.Visible = true;
                    return;
                }

                this.Gravar(pessoa);
                Limpar();
            }
            catch (Exception ex)
            {
                msgErro.Text = "Ocorreu um erro ao gravar os dados: " + ex.Message;
                msgErro.Visible = true;
            }


        }



        /// <summary>
        /// Persistir os dados no Banco.
        /// </summary>
        /// <param name="pessoa">DAO.PESSOAS</param>
        public class PESSOAS
        {
            public string Nome { get; set; }
            public string CPF { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public string Sexo { get; set; }
            public DateTime DataNascimento { get; set; }
        }

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
			// Isso é apenas um bônus!
			// Tente fazê-lo e colocar em um lugar apropriado no código.
			txtNome.Text = string.Empty;
			txtCpf.Text = string.Empty;
			txtEmail.Text = string.Empty;
			txtTelefone.Text = string.Empty;
			ddlSexo.SelectedIndex = 0;
			txtDataNascimento.Text = string.Empty;
		}
	}
}