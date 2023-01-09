using System;
using System.Collections.Generic;
using System.Globalization;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa1 : System.Web.UI.Page
    {
        protected List<string> ErrorList;
        protected DateTime DataNascimentoConvertida;
        protected void Page_Load(object sender, EventArgs e)
        {
            var pessoas = new BLL.PESSOAS();
            List<DAO.PESSOAS> pessoasList = pessoas.CarregarTodos();
            // Para saber se o seu registro foi realmente adicionado à tabela, utilize um dos métodos de BLL.PESSOAS.
            // Você poderá realizar a depuração aqui no VS e conferir se tudo deu certo.
            // Sinta-se livre para fazer a sua arte, mas tente fazer o formulário funcionar ok!
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            this.ValidaCampos();

            
            if(this.ErrorList.Count > 0)
            {
                RetornaErrosAoUsuario();
                return;
            }
               
            var pessoa = new DAO.PESSOAS()
            {
                NOME = this.txtNome.Text,
                CPF  = this.txtCpf.Text,
                RG   = this.txtRg.Text,
                TELEFONE = this.txtTelefone.Text,
                EMAIL = this.txtEmail.Text,
                SEXO = this.ddlSexo.SelectedValue,
                DATA_NASCIMENTO = DataNascimentoConvertida,
            };

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

        /// <summary>
        /// Valida os Campos Enviados no Form
        /// </summary>
        private void ValidaCampos()
        {

            this.ErrorList = new List<string>();

            if (this.txtNome.Text == String.Empty) ErrorList.Add("O campo Nome é Obrigatório");
            if (this.txtCpf.Text == String.Empty) ErrorList.Add("O campo CPF é Obrigatório");
            if (this.txtRg.Text == String.Empty) ErrorList.Add("O campo RG é Obrigatório");
            if (this.ddlSexo.SelectedIndex == 0) ErrorList.Add("O campo Sexo é Obrigatório");
            if (this.txtDataNascimento.Text == String.Empty) ErrorList.Add("O campo Data de Nascimento é Obrigatório");

            if (this.txtNome.Text.Length > 200) ErrorList.Add("O campo Nome deve possuir no máximo 200 caracteres");
            if (this.txtCpf.Text.Length != 11) ErrorList.Add("O campo CPF deve possuir 11 Digitos");
            if (this.txtRg.Text.Length > 15) ErrorList.Add("O campo RG deve possuir no máximo 15 caracteres");
            if (this.txtTelefone.Text.Length > 20) ErrorList.Add("O campo Telefone deve possuir no máximo 20 caracteres");
            if (this.txtEmail.Text.Length > 200) ErrorList.Add("O Campo e-mail deve possuir no Maximo 200 caracteres");

            if (!DateTime.TryParseExact(this.txtDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DataNascimentoConvertida))
                ErrorList.Add("O campo Data de Nascimento está em formato inválido");
        }

        ///<summary>
        /// Retorna FeedBack Visual para o Usuário
        /// </summary>
        private void RetornaErrosAoUsuario()
        {
            
            var retorno = String.Empty;
            foreach(var erro in this.ErrorList)
                retorno += String.Format("<p class='danger-text'>{0}</p>", erro.ToString());
           
            Response.Write(retorno);
        }
    }
}