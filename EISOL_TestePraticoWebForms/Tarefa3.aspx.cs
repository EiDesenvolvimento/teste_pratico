using System;
using System.Collections.Generic;
using System.Web.UI;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa3 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Carregar as UFs e as Cidades (o primeiro carregamento)
                CarregarControles();
            }
        }

        /// <summary>
        /// Carregar dados e povoar os controles
        /// </summary>
        private void CarregarControles()
        {
            // Povoando as Unidades da Federação.
            this.ddlUf.Items.Clear();
            this.ddlUf.DataSource = new BLL.UF().CarregarTodos();  // Supondo que você tenha um método para carregar as UFs.
            this.ddlUf.DataTextField = "NOME";  // Exibirá o nome da UF no Dropdown.
            this.ddlUf.DataValueField = "COD_UF";  // O valor da UF será o código (COD_UF).
            this.ddlUf.DataBind();

            // Adicionar uma opção inicial de "Selecione"
            this.ddlUf.Items.Insert(0, new ListItem("Selecione a UF", "0"));
        }

        // Este evento será chamado quando a UF for selecionada.
        protected void ddlUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpar o dropdown de cidades
            ddlCidades.Items.Clear();
            
            // Recuperar a UF selecionada
            string selectedUf = ddlUf.SelectedValue;

            if (selectedUf != "0")
            {
                // Carregar as cidades relacionadas com a UF selecionada
                var cidades = CarregarCidadesPorUf(selectedUf);

                // Adicionar uma opção inicial
                ddlCidades.Items.Add(new ListItem("Selecione a cidade", "0"));

                // Adicionar as cidades ao dropdown de cidades
                foreach (var cidade in cidades)
                {
                    ddlCidades.Items.Add(new ListItem(cidade, cidade));
                }
            }
            else
            {
                // Caso não haja UF selecionada, adicione a opção "Selecione a cidade"
                ddlCidades.Items.Add(new ListItem("Selecione a cidade", "0"));
            }
        }

        // Método para carregar as cidades com base na UF selecionada (Simulação de dados)
        private List<string> CarregarCidadesPorUf(string uf)
        {
            // Exemplo simples de dados simulados. Isso seria feito via banco de dados em uma aplicação real.
            var cidades = new Dictionary<string, List<string>>
            {
                { "SP", new List<string> { "São Paulo", "Campinas", "Santos" } },
                { "RJ", new List<string> { "Rio de Janeiro", "Niterói", "Petrópolis" } },
                { "MG", new List<string> { "Belo Horizonte", "Uberlândia", "Contagem" } },
                { "BA", new List<string> { "Salvador", "Feira de Santana", "Vitória da Conquista" } }
            };

            // Retorna as cidades baseadas na UF selecionada ou uma lista vazia se a UF não for encontrada
            return cidades.ContainsKey(uf) ? cidades[uf] : new List<string>();
        }
    }
}
