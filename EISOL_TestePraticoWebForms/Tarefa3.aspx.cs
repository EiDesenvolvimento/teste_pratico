using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.CarregarControles();
            }
        }

        /// <summary>
        /// Carregar dados e povoar os controles
        /// </summary>
        private void CarregarControles()
        {
            // Povoando as Unidades da Federação.
            this.ddlUf.Items.Clear();
            this.ddlUf.DataSource = new BLL.UF().CarregarTodos();
            this.ddlUf.DataTextField = "NOME";
            this.ddlUf.DataValueField = "COD_UF";
            this.ddlUf.DataBind();

            // Povoando as Cidades
            this.ddlCidades.Items.Clear();
            this.ddlCidades.DataSource = new BLL.CIDADES().CarregarTodos();
            this.ddlCidades.DataTextField = "NOME";
            this.ddlCidades.DataValueField = "COD_CIDADE";
            this.ddlCidades.DataBind();
        }

        // Cadê o evento?
        // É isso que você deve fazer para finalizar essa tarefa!
        protected void ddlUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ufSelecionada = ddlUf.SelectedValue; // Obtém a UF selecionada
            PreencherCidades(ufSelecionada);            // Preenche as cidades correspondentes
        }

        private void PreencherCidades(string uf)
        {
            // Limpa as cidades atuais
            ddlCidades.Items.Clear();
            ddlCidades.Items.Add(new ListItem("Selecione a Cidade", ""));

            // Lista de cidades para cada UF (simulação)
            var cidadesPorUf = new Dictionary<string, List<string>>
    {
        { "RJ", new List<string> { "Rio de Janeiro", "Niterói", "Cabo Frio" } },
        { "SP", new List<string> { "São Paulo", "Campinas", "Santos" } },
        { "MG", new List<string> { "Belo Horizonte", "Uberlândia", "Ouro Preto" } }
    };

            // Adiciona as cidades correspondentes à UF selecionada
            if (cidadesPorUf.ContainsKey(uf))
            {
                foreach (var cidade in cidadesPorUf[uf])
                {
                    ddlCidades.Items.Add(new ListItem(cidade, cidade));
                }
            }
        }

    }
}