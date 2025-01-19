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
				if (ValidarDados(out string mensagemErro))
				{
					pessoa.NOME = txtNome.Text;
					pessoa.CPF = txtCpf.Text;
					pessoa.RG = txtRg.Text;
					pessoa.TELEFONE = txtTelefone.Text;
					pessoa.EMAIL = txtEmail.Text;
					pessoa.SEXO = ddlSexo.SelectedValue;
					pessoa.DATA_NASCIMENTO = DateTime.Parse(txtDataNascimento.Text);

					this.Gravar(pessoa);
				}
				else
				{
					// Exibir mensagem de erro
					msgErro.Text = mensagemErro;
				}


			}
			catch (Exception ex)
			{
				msgErro.Text = "Houve um erro ao salvar os dados: " + ex.Message;
				msgErro.Visible = true;
			}


			// - Ao persistir os dados no Banco de Dados, apresenta a seguinte mensagem "Houve um erro ao salvar os dados: A solicitação de conexão sofreu timeout"
			// - Realizado a validação dos dados ao instânciar Pessoa
			// - O que precisa ser melhorado: Verificar o erro da persistência de dados no banco, pois não consegui resolver a tempo
			// - E também criar um Service para realizar a validação do CPF e verificar a data de nascimento
			// - Ao recompilar o código apresenta o erro: Linha 1:  <%@ Application Codebehind="Global.asax.cs" Inherits="EISOL_TestePraticoWebForms.Global" Language="C#" %>
			// - Erro no qual consegui resolver, mas segui toda a validação certo, tentei resolver há dias, mas não consegui, deixo
			// - Em aberto para possíveis melhorias de validação da aplicação

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
			// Isso é apenas um bônus!
			// Tente fazê-lo e colocar em um lugar apropriado no código.
		}

		private bool ValidarDados(out string mensagemErro)
		{
			mensagemErro = "";

			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				mensagemErro = "Nome é obrigatório.";
				return false;
			}

			if (string.IsNullOrWhiteSpace(txtCpf.Text))
			{
				mensagemErro = "Campo CPF obrigatório.";
				return false;
			}

			if (!DateTime.TryParse(txtDataNascimento.Text, out DateTime dataNascimento))
			{
				mensagemErro = "Data de nascimento inválida.";
				return false;
			}
			if (dataNascimento > DateTime.Now)
			{
				mensagemErro = "Data de nascimento não pode ser no futuro.";
				return false;
			}

			if (string.IsNullOrWhiteSpace(txtTelefone.Text))
			{
				mensagemErro = "Campo telefone obrigatório.";
				return false;
			}

			return true;
		}
	}
}