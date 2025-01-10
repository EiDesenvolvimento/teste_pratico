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
            // Carregar as UFs
            this.ddlUf.Items.Clear();
            this.ddlUf.DataSource = new BLL.UF().CarregarTodos();
            this.ddlUf.DataTextField = "NOME";
            this.ddlUf.DataValueField = "COD_UF";
            this.ddlUf.DataBind();

            // Carregar as Cidades inicialmente
            this.CarregarCidades(0); // Sem filtro, carrega todas as cidades
        }

        // Função para carregar cidades conforme a UF selecionada
        protected void CarregarCidades(int codigoUF)
        {
            this.ddlCidades.Items.Clear();

            List<DAO.CIDADES> cidades = codigoUF > 0
                ? new BLL.CIDADES().CarregarPorUF(codigoUF)
                : new BLL.CIDADES().CarregarTodos();

            this.ddlCidades.DataSource = cidades;
            this.ddlCidades.DataTextField = "NOME";
            this.ddlCidades.DataValueField = "COD_CIDADE";
            this.ddlCidades.DataBind();
        }

        // Método para tratar o evento de mudança da UF
        protected void ddlUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigoUF;
            if (int.TryParse(this.ddlUf.SelectedValue, out codigoUF) && codigoUF > 0)
            {
                this.CarregarCidades(codigoUF);  // Carregar cidades com base no código da UF selecionada
            }
            else
            {
                this.CarregarCidades(0);  // Carregar todas as cidades caso nenhuma UF seja selecionada ou seja inválida
            }
        }

    }
}