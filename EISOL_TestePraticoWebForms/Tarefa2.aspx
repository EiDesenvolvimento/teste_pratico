<%@ Page Title="EISOL Tarefa 2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tarefa2.aspx.cs" Inherits="EISOL_TestePraticoWebForms.Tarefa2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        &nbsp;
    </div>
    <div class="row">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title">Client Side</h3>
            </div>
            <div class="panel-body">
                <p>
                    Os sistemas baseados na web, usam uma tríade de tecnologia imprescindíveis que são utilizadas junto qualquer linguagem de servidor como o C#. 
                    Essa tríade é constrituída pelos deuses mitológicos HTML, CSS e JAVASCRIPT.
                </p>
                <p>
                    O Client Side conhecemos por lado do cliente. É aquele lado íntimo que todos os usuários de um sistema web usam e abusam sem saber. 
                    Mas você nobre programador(a), sabe o poder do Client Side! Como muitos já devem conhcer, existe o framework JavaScript chamado jQuery que facilita muito o trabalho na manipulação de elementos DOM como validações, máscaras, AJAX, canvas e bla bla bla bla bla.
                    Use esse poder para nos mostrar as suas habilidades com o Client Side!                    
                </p>
                <p>
                    Aliás, por se tratar de um WebForms, você deve saber que a utilização do jQuery não é tão obvia assim. Bem, aqui nós temos somente um &lt;form&gt;.
                    Um controle chamado de MasterPage e suas ContentPages.
                    Isso implica em usar de forma adequada os seletores CSS no jQuery.
                    Agora se você é um cara roots e quer usar o JavaScript puro, fique a vontade para mostrar as suas habilidades mas aviso, pode ser que você tenha de digitar muito mais linhas de código.
                    Apesar do HTML oferecer um certo suporte com atributos de validação, ainda preferimos que você nos mostre o poder do Client Side com scripts.
                </p>
                <p>
                    Entre no código fonte pelo Visual Studio e exerça o seu poder criacional de scripts simples e poderosos.
                </p>
                <p class="text-warning">
                    Atenção nos campos dos formulário para que eles não excedam o tamanho das tabelas do banco!
                </p>
            </div>
        </div>
    </div>

    <%--    
        E se o usuário não preencher os campos obrigatórios desse formulário?
        Com certeza o banco de dados reclamaria e então seremos brindados com uma bela tela... de erro.
        Use o script para não permitir que isso aconteça.
        Ah! Tente não usar scripts inline ou atributos de eventos dos elementos. 
        Tente fazer a coisa realmente bacana que é um script externo!
        Ele está no rodapé desse formulário.
    --%>

    <div class="row">
        <div class="col-md-12">
            <h2>Cadastro de pessoas</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>Seus dados</h5>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <label>
                                Nome
                            </label>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12">
                            <label>
                                CPF
                            </label>
                             <%--Colocar máscara de CPF aqui será um bônus--%>
                            <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12">
                            <label>
                                RG
                            </label>
                            <asp:TextBox ID="txtRg" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12">
                            <label>
                                Telefone
                            </label>
                            <%--Colocar máscara de telefone aqui será um bônus--%>
                            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <label>
                                Email
                            </label>
                            <%--Colocar expressão regular pra validar email aqui será um bônus plus 2.0 Ultimate Edition Deluxe Ultra Master Blaster --%>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <label>
                                Sexo
                            </label>
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                                <asp:ListItem>[Selecione]</asp:ListItem>
                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                <asp:ListItem Value="F">Feminino</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <label>
                                Data de nascimento
                            </label>
                            <%--Colocar máscara de data aqui será um bônus--%>
                            <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" placeholder="DD/MM/YYYY"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <asp:Button ID="btnGravar" runat="server" Text="Gravar" CssClass="btn btn-default" />
            <asp:Button ID="btnEstranho" runat="server" Text="Não clique aqui!" CssClass="btn btn-danger" />
            <a class="btn btn-primary" href="Default.aspx">Voltar</a>
        </div>
    </div>
    <div runat="server" visible="false" id="divAlerta">
        <div class="row">
            &nbsp;
        </div>
        <div class="alert alert-success" role="alert">
            <strong>Muito Bom!</strong> Você conseguiu salvar os dados no banco de dados... será? Vou verificar isso depois.
        </div>
    </div>

    <script>
        $(document).ready(function () {
            function clearErrors() {
                $(".validation-error").remove(); 
            }

            // Função para exibir mensagem de erro abaixo do campo
            function showError(element, message) {
                $(element).after(`<span class="validation-error text-danger" style="font-size: 12px;">${message}</span>`);
            }

            //Máscara para data de nascimento
            $("#<%= txtDataNascimento.ClientID %>").on("input", function () {
                let value = $(this).val().replace(/\D/g, ""); 
                if (value.length > 2) {
                    value = value.replace(/^(\d{2})/, "$1/"); 
                }
                if (value.length > 5) {
                    value = value.replace(/^(\d{2}\/\d{2})/, "$1/"); 
                }
                value = value.substring(0, 10); 
                $(this).val(value);
            });

            // Máscara para CPF
            $("#<%= txtCpf.ClientID %>").on("input", function () {
                let value = $(this).val().replace(/\D/g, "").substring(0, 11);
                value = value.replace(/^(\d{3})(\d{3})(\d{3})(\d{2})$/, "$1.$2.$3-$4");
                $(this).val(value);
            });

            // Máscara para telefone
            $("#<%= txtTelefone.ClientID %>").on("input", function () {
                let value = $(this).val().replace(/\D/g, "").substring(0, 11);
                value = value.replace(/^(\d{2})(\d{4,5})(\d{4})$/, "($1) $2-$3");
                $(this).val(value);
            });

            $("#<%= btnGravar.ClientID %>").click(function (e) {
                e.preventDefault(); 
                clearErrors();
                let isValid = true;

                //Nome
                let nome = $("#<%= txtNome.ClientID %>");
                if (nome.val().trim() === "") {
                    isValid = false;
                    showError(nome, "O campo Nome é obrigatório.");
                }

                let telefone = $("#<%= txtTelefone.ClientID %>");
                if (!/^\(\d{2}\) \d{4,5}-\d{4}$/.test(telefone.val().trim())) {
                    isValid = false;
                    showError(telefone, "O telefone deve estar no formato (XX) XXXXX-XXXX.");
                }

                // CPF
                let cpf = $("#<%= txtCpf.ClientID %>");
                if (!/^\d{3}\.\d{3}\.\d{3}-\d{2}$/.test(cpf.val().trim())) {
                    isValid = false;
                    showError(cpf, "O CPF é inválido ou está vazio.");
                }

                // Email
                let email = $("#<%= txtEmail.ClientID %>");
                if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.val().trim())) {
                    isValid = false;
                    showError(email, "O Email é inválido ou está vazio.");
                }

                // Data de nascimento
                let dataNascimento = $("#<%= txtDataNascimento.ClientID %>");
                if (!/^\d{2}\/\d{2}\/\d{4}$/.test(dataNascimento.val().trim())) {
                    isValid = false;
                    showError(dataNascimento, "A data de nascimento deve estar no formato DD/MM/YYYY.");
                }

                // Sexo
                let sexo = $("#<%= ddlSexo.ClientID %>");
                if (sexo.val() === "[Selecione]") {
                    isValid = false;
                    showError(sexo, "O campo Sexo é obrigatório.");
                }

                if (isValid) {
                    alert("Formulário válido! Enviando...");
                }
            });
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="Scripts/ClientSide/tarefa2.js"></script>
</asp:Content>
