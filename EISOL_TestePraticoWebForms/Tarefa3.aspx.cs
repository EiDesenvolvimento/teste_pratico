using System;
using System.Web.UI.WebControls;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                // Não chamar CarregarControles(), apenas configurar a UF com uma opção inicial
                this.ddlUf.Items.Clear();
                this.ddlUf.DataSource = new BLL.UF().CarregarTodos();
                this.ddlUf.DataTextField = "NOME";
                this.ddlUf.DataValueField = "COD_UF";
                this.ddlUf.DataBind();

                // Adiciona a opção padrão "Selecione" para forçar o usuário a escolher
                this.ddlUf.Items.Insert(0, new ListItem("-- Selecione uma UF --", ""));

                // Garante que a lista de cidades comece vazia
                this.ddlCidades.Items.Clear();
                this.ddlCidades.Items.Insert(0, new ListItem("-- Selecione uma cidade --", ""));
            }
        }

        /// <summary>
        /// Carregar dados e povoar os controles
        /// </summary>
        //private void CarregarControles()
        //{
        //    // Povoando as Unidades da Federação.
        //    this.ddlUf.Items.Clear();
        //    this.ddlUf.DataSource = new BLL.UF().CarregarTodos();
        //    this.ddlUf.DataTextField = "NOME";
        //    this.ddlUf.DataValueField = "COD_UF";
        //    this.ddlUf.DataBind();

        //    // Povoando as Cidades
        //    this.ddlCidades.Items.Clear();
        //    this.ddlCidades.DataSource = new BLL.CIDADES().CarregarTodos();
        //    this.ddlCidades.DataTextField = "NOME";
        //    this.ddlCidades.DataValueField = "COD_CIDADE";
        //    this.ddlCidades.DataBind();

        //    if (!string.IsNullOrEmpty(ddlUf.SelectedValue))
        //    {
        //        FiltraCidades(null, null);
        //    }
        //    else
        //    {
        //        // Caso nenhuma UF esteja selecionada, limpa as cidades
        //        this.ddlCidades.Items.Clear();
        //        this.ddlCidades.Items.Insert(0, new ListItem("-- Selecione uma cidade --", ""));
        //    }

        //}

        // Cadê o evento?
        // É isso que você deve fazer para finalizar essa tarefa!
        protected void FiltraCidades(object sender, EventArgs e)
        {
            string ufSelecionado = ddlUf.SelectedValue;

            System.Diagnostics.Debug.WriteLine($"UF Selecionado: {ufSelecionado}");

            if (!string.IsNullOrEmpty(ufSelecionado))
            {
                decimal ufSelecionadoConvertido;

                // Verificar se a conversão para decimal está correta
                if (!decimal.TryParse(ufSelecionado, out ufSelecionadoConvertido))
                {
                    throw new Exception($"Erro ao converter UF '{ufSelecionado}' para decimal.");
                }

                System.Diagnostics.Debug.WriteLine($"UF Convertida: {ufSelecionadoConvertido}");
                var bllCidades = new BLL.CIDADES();

                var listaCidades = bllCidades.CarregarPorUF(ufSelecionadoConvertido);

                ddlCidades.DataSource = listaCidades;
                ddlCidades.DataTextField = "NOME";
                ddlCidades.DataValueField = "COD_CIDADE";
                ddlCidades.DataBind();
            }
            else
            {
                ddlCidades.Items.Clear();
                ddlCidades.Items.Insert(0, new ListItem("-- Selecione uma cidade --", ""));
            }
        }

    }

    
}