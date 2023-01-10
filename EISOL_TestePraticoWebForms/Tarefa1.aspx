<%@ Page Title="EISOL Tarefa 1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tarefa1.aspx.cs" Inherits="EISOL_TestePraticoWebForms.Tarefa1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        &nbsp;
    </div>
    <div class="row">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title">Server Side</h3>
            </div>
            <div class="panel-body">
                <p>
                    O WebForms é uma tecnologia que facilita muito no desenvolvimento. No entanto ele depende dos componentes que são executados no lado do servidor (Server Side).
                    É fundamental saber utilizar os componentes do servidor e seus eventos para executar as tarefas triviais do WebForms.
                </p>
                <p>
                    Identifique as peças que faltam e coloque-as em seus devidos lugares para esse formulário poder funcionar. 
                </p>
                <p>
                    Entre no código fonte pelo Visual Studio e resolva os códigos místicos do Server Side.
                </p>
                <p class="text-warning">
                    Atenção nos campos dos formulário para que eles não excedam o tamanho das tabelas do banco!
                </p>
            </div>
        </div>
    </div>

    <%--    
        Ah sim é um formulário muito bonito que utiliza o Bootstrap!
        Mas parece que falta alguma coisa faltando nele para você conseguir iniciar.
        Observe atentamente os controles!
        Esses controles também são conhecidos por Server Controls... fazem parte do Server Side (Luke, come to the dark side... =S).
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
                <div>
                    <asp:Label runat="server" CssClass="form-control" ID="msgErro" Visible="false">Erro, verifique o Campo: </asp:Label>
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
            <asp:Button ID="BtnLimpar" runat="server" Text="Limpar Campos" OnClick="BtnLimpar_Click" CssClass="btn btn-warning" />
            <a class="btn btn-primary" href="Default.aspx">Voltar</a>
        </div>
    </div>
    <div runat="server" visible="false" id="divAlerta">
        <div class="row">
            &nbsp;
        </div>
        <div class="alert alert-success" role="alert">
            <strong>Muito Bom!</strong> Você conseguiu salvar os dados no banco de dados... será? Vou verificar isso depois :p.
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