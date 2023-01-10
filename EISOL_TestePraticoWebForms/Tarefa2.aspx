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
                            <asp:TextBox ID="txtNome" MaxLength="200" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                              ControlToValidate="txtNome"
                              ErrorMessage="Nome é Obrigatório."
                              ForeColor="Red"/>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12">
                            <label>
                                CPF
                            </label>
                            <asp:TextBox ID="txtCpf" MaxLength="14" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCpf"
                             ForeColor="Red" 
                             ValidationExpression="([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})"
                             Display = "Dynamic" 
                             ErrorMessage = "CPF inválido"/>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                              ControlToValidate="txtCpf"
                              ErrorMessage="CPF é Obrigatório."
                              ForeColor="Red"/>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12">
                            <label>
                                RG
                            </label>
                            <asp:TextBox ID="txtRg" MaxLength="15" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                              ControlToValidate="txtRg"
                              ErrorMessage="RG é Obrigatório."
                              ForeColor="Red"/>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12">
                            <label>
                                Telefone
                            </label>
                            <asp:TextBox ID="txtTelefone" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                              ControlToValidate="txtTelefone"
                              ErrorMessage="Telefone é Obrigatório."
                              ForeColor="Red"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <label>
                                Email
                            </label>
                            <asp:TextBox ID="txtEmail" MaxLength="200" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                             ForeColor="Red" 
                             ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                             Display = "Dynamic" 
                             ErrorMessage = "Email inválido"/>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                              ControlToValidate="txtEmail"
                              ErrorMessage="Email é Obrigatório."
                              ForeColor="Red"/>
                        </div>
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <label>
                                Sexo
                            </label>
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">[Selecione]</asp:ListItem>
                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                <asp:ListItem Value="F">Feminino</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator 
                                ErrorMessage="Sexo é Obrigatório" 
                                id="RequiredFieldValidator6"
                                ControlToValidate="ddlSexo" 
                                InitialValue="0" runat="server" ForeColor="Red" />
                        </div>
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <label>
                                Data de nascimento
                            </label>
                            <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" placeholder="DD/MM/YYYY"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDataNascimento"
                             ForeColor="Red" 
                             ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
                             Display = "Dynamic" 
                             ErrorMessage = "Data de Nascimento inválido"/>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"
                              ControlToValidate="txtDataNascimento"
                              ErrorMessage="Data de Nascimento é Obrigatório."
                              ForeColor="Red"/>
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
            <asp:Button ID="BtnLimpar" runat="server" Text="Limpar Campos" OnClick="BtnLimpar_Click" CssClass="btn btn-warning" />
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
    <div runat="server" visible="false" id="divAlertaLimpar">
        <div class="row">
            &nbsp;
        </div>
        <div class="alert alert-success" role="alert">
            Limpeza dos campos com sucesso!
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.0/jquery.mask.js"></script>
    <script src="Scripts/ClientSide/tarefa2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () { 
            $("[id*=txtCpf]").mask("999.999.999-99");
            $("[id*=txtTelefone]").mask("(99) 99999-9999");
            $("[id*=txtDataNascimento]").mask("99/99/9999");
        });
    </script>
</asp:Content>