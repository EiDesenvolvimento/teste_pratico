using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa2 : System.Web.UI.Page
    {
        /*
         * 
         * 
         * 
         *  Sério mesmo que você acho que eu responderia a tarefa 1 aqui!?!?
         *  Nananinanão.
         *  Se ele funcionou lá, com certeza funcionará aqui! ;D
         * 
         * 
         * 
         * 
         * */

        protected void Page_Load(object sender, EventArgs e)
        {
            // Para saber se o seu registro foi realmente adicionado à tabela, utilize um dos métodos de BLL.PESSOAS.
            // Você poderá realizar a depuração aqui no VS e conferir se tudo deu certo.
            // Sinta-se livre para fazer a sua arte, mas tente fazer o formulário funcionar ok! 
            this.txtNome.MaxLength = 200;
            this.txtCpf.MaxLength = 11;
            this.txtRg.MaxLength = 15;
            this.txtTelefone.MaxLength = 20;
            this.txtEmail.MaxLength = 200;
            this.txtDataNascimento.MaxLength = 10;

            StringBuilder sb = new StringBuilder();

            sb.Append("<script type=\"text/javascript\" src=\"").Append("Scripts/jquery-1.4.1.js").Append("\"></script>");
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("$('#txtCpf').mask('999.999.999-99', { placeholder: '___.___.___-__' });");
            sb.Append("$('#txtTelefone').mask('(99) 9999-9999', { placeholder: '(__) ____-____' });");
            sb.Append("$('#txtDataNascimento').mask('99/99/9999', { placeholder: '__/__/____' });");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", sb.ToString(), true);
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

            // Coloque o seu lindo código aqui! (O_o)
            String msgErroRet = this.ValidarCamposFormulario();

            /*if (msgErroRet != "")
            {
                this.msgErro.Text += " " + msgErroRet;
                this.msgErro.Visible = true;
                return;
            }*/

            pessoa.NOME = this.txtNome.Text;
            pessoa.CPF = this.txtCpf.Text;
            pessoa.RG = this.txtRg.Text;
            pessoa.TELEFONE = this.txtTelefone.Text;
            pessoa.EMAIL = this.txtEmail.Text;
            pessoa.SEXO = this.ddlSexo.Text;
            pessoa.DATA_NASCIMENTO = DateTime.Parse(this.txtDataNascimento.Text);

            this.Gravar(pessoa);
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

            Limpar();
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
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = "";
                }
                else if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).SelectedIndex = -1;
                }
            }
        }

        /// <summary>
        /// Validação dos campos do Formulário
        /// </summary>
        public String ValidarCamposFormulario()
        {
            if (this.txtNome.Text == "")
            {
                return "Favor informar o nome!";
            }
            else if (this.txtCpf.Text == "")
            {
                return "Favor informar o CPF!";
            }
            else if (this.txtRg.Text == "")
            {
                return "Favor informar o RG!";
            }
            else if (this.txtDataNascimento.Text == "")
            {
                return "Favor informar a Data de Nascimento!";
            }
            else if (this.ddlSexo.Text == "[Selecione]")
            {
                return "Favor informar o Sexo!";
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(this.txtEmail.Text, 
                        "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
                return "Email inválido!";
            }

            return null;
        }
    }
}