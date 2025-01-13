$(document).ready(function () {
    // Máscaras para os campos
    $('#<%= txtCpf.ClientID %>').mask('000.000.000-00');
    $('#<%= txtTelefone.ClientID %>').mask('(00) 0000-0000');
    $('#<%= txtDataNascimento.ClientID %>').mask('00/00/0000');

    // Validação do formulário
    $('#<%= btnGravar.ClientID %>').click(function (e) {
        e.preventDefault(); // Previne o envio até validar

        var valid = true;
        var msgErro = "";

        if ($('#<%= txtNome.ClientID %>').val() == "") {
            valid = false;
            msgErro += "Nome é obrigatório.\n";
        }
        if ($('#<%= txtCpf.ClientID %>').val() == "") {
            valid = false;
            msgErro += "CPF é obrigatório.\n";
        }
        if ($('#<%= txtEmail.ClientID %>').val() == "") {
            valid = false;
            msgErro += "Email é obrigatório.\n";
        }

        // Regex para validar o email
        var emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
        if (!emailRegex.test($('#<%= txtEmail.ClientID %>').val())) {
            valid = false;
            msgErro += "Email inválido.\n";
        }

        if (!valid) {
            alert(msgErro);
            return false;
        }

        // Envia o formulário se tudo estiver correto
        $('#<%= form1.ClientID %>').submit();
    });
});
