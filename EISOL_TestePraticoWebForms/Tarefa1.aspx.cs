using Microsoft.Ajax.Utilities;
using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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

            if (ValidaCampos())
            {
                var pessoa = new DAO.PESSOAS
                {
                    NOME = txtNome.Text,
                    CPF = txtCpf.Text,
                    RG = txtRg.Text,
                    TELEFONE = txtTelefone.Text,
                    EMAIL = txtEmail.Text,
                    SEXO = ddlSexo.SelectedValue,
                    DATA_NASCIMENTO = Convert.ToDateTime(txtDataNascimento.Text)
                };

                this.Gravar(pessoa);
            }
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
            this.Limpar();
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
        }

        private bool ValidaCampos()
        {
            bool validaCampos = true;

            if (txtNome.Text.Length == 0 || txtNome.Text.IsNullOrWhiteSpace())
            {
                msgErro.Text = "O campo Nome é obrigatório!";
                validaCampos = false;
            }
            else if (txtCpf.Text.Length == 0 || txtCpf.Text.IsNullOrWhiteSpace())
            {
                msgErro.Text = "O campo CPF é obrigatório!";
                validaCampos = false;
            }
            else if (txtRg.Text.Length == 0 || txtRg.Text.IsNullOrWhiteSpace())
            {
                msgErro.Text = "O campo RG é obrigatório!";
                validaCampos = false;
            }
            else if (ddlSexo.SelectedIndex == 0)
            {
                msgErro.Text = "O campo Sexo é obrigatório!";
                validaCampos = false;
            }
            else if (txtDataNascimento.Text.Length == 0 || ddlSexo.Text.IsNullOrWhiteSpace())
            {
                msgErro.Text = "O campo Data de nascimento é obrigatório!";
                validaCampos = false;
            }

            if (!validaCampos)
            {
                msgErro.Visible = true;
                return false;
            }

            msgErro.Visible = false;
            return true;
        }
    }
}