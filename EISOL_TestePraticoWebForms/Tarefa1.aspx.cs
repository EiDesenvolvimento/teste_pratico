using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BLL;

namespace EISOL_TestePraticoWebForms
{
	public partial class Tarefa1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            // Para saber se o seu registro foi realmente adicionado à tabela, utilize um dos métodos de BLL.PESSOAS.
            // Você poderá realizar a depuração aqui no VS e conferir se tudo deu certo.
            // Sinta-se livre para fazer a sua arte, mas tente fazer o formulário funcionar ok!
            if (!IsPostBack)  // Carregar os dados apenas na primeira vez
            {
                CarregarPessoas();
            }
        }

        private void CarregarPessoas()
        {
            var bllPessoas = new BLL.PESSOAS();

            // Obter a lista de pessoas
            var listaPessoas = bllPessoas.CarregarTodos();

            // Verificar se a lista é nula ou está vazia
            if (listaPessoas != null && listaPessoas.Count > 0)
            {
                // Associar a lista ao GridView
                gvPessoas.DataSource = listaPessoas;
                gvPessoas.DataBind(); // Exibir os dados no GridView
            }
            else
            {
                // Caso não haja registros, limpar o GridView
                gvPessoas.DataSource = null;
                gvPessoas.DataBind();
            }

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
            var bllPessoas = new BLL.PESSOAS();

            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cpf = txtCpf.Text.Trim();
            string rg = txtRg.Text.Trim();
            string telefone = txtTelefone.Text.Trim();
            string sexo = ddlSexo.SelectedValue; // Verifica o valor selecionado
            string dataTexto = txtDataNascimento.Text.Trim();

            // Validar os campos obrigatórios
            if (string.IsNullOrWhiteSpace(nome))
            {
                msgErro.Text = "Erro: O campo Nome é obrigatório.";
                msgErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                msgErro.Text = "Erro: O campo Email é obrigatório.";
                msgErro.Visible = true;
                return;
            }

            if (sexo == "[Selecione]" || string.IsNullOrWhiteSpace(sexo))
            {
                msgErro.Text = "Erro: O campo Sexo é obrigatório.";
                msgErro.Visible = true;
                return;
            }

            // Validar o tamanho dos campos
            if (nome.Length > 200)
            {
                msgErro.Text = "Erro: O campo Nome não pode ultrapassar 200 caracteres.";
                msgErro.Visible = true;
                return;
            }

            if (email.Length > 200)
            {
                msgErro.Text = "Erro: O campo Email não pode ultrapassar 200 caracteres.";
                msgErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 )
            {
                msgErro.Text = "Erro: O campo CPF não pode ultrapassar 11 caracteres e não pode ser nulo.";
                msgErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(rg) || rg.Length > 15)
            {
                msgErro.Text = "Erro: O campo RG não pode ultrapassar 15 caracteres e não pode ser nulo.";
                msgErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(telefone) || telefone.Length > 15)
            {
                msgErro.Text = "Erro: O campo Telefone não pode ser nulo e ultrapassar 15 caracteres.";
                msgErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(dataTexto))
            {
                msgErro.Text = "Erro: O campo Data de Nascimento é obrigatório.";
                msgErro.Visible = true;
                return;
            }
            // Validar e converter a data de nascimento
            DateTime dtNascimento;
            if (!DateTime.TryParse(dataTexto, out dtNascimento))
            {
                msgErro.Text = "Erro: O campo Data de Nascimento deve ser uma data válida.";
                msgErro.Visible = true;
                return;
            }

            pessoa.NOME = nome;
            pessoa.EMAIL = email;
            pessoa.CPF = cpf;
            pessoa.RG = rg;
            pessoa.TELEFONE = telefone;
            pessoa.SEXO = sexo;
            pessoa.DATA_NASCIMENTO = dtNascimento;

            // O Objeto pessoa não parece ser uma pessoa de verdade ainda. 
            // As pessoas não são objetos mas aqui podemos considerá-las assim =S
            // - Faça as devidas atribuições ao objeto 'pessoa' para que ela seja uma pessoa de verdade e feliz!

            // Verifique os tamanhos dos campos da tabela e a obrigatoriedade deles e faça o devido tratamento para evitar erros.
            // - O leiaute da tabela em questão (TB_TESTE_PESSOAS) poderá ser verificado nos arquivos .sql anexados ao projeto.

            /* SEU OBJETIVO (TAREFA 1)
             * Envie um objeto com dados, passando pela camada de negócios e que possibilite salvar os dados do formulário preenchido no banco de dados.
             */

            // Coloque o seu lindo código aqui! (O_o)

            this.Gravar(pessoa);

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
            txtEmail.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtRg.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            ddlSexo.SelectedIndex = 0; 
            txtDataNascimento.Text = string.Empty;
        }
	}
}