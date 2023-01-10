/// <reference path="Scripts/ClientSide/jquery-1.10.2.js" />
/// <reference path="Scripts/ClientSide/bootstrap.js" />

// Legal né, essas linhas mágicas aí de cima permitem o Visual Studio a montar o Intellisense do jQuery aqui como ele já faz com o C#.
// Não apague elas, elas são do bem.

"use strict"

var TAREFA2 = TAREFA2 || {
    Carregar: () => {
        $("[id$='_btnEstranho']").on('click', () => {
            return TAREFA2.Autodestruir();
        });

    },
    Autodestruir: () => {
        window.alert('Este computador se autodestruirá em 20 segundos...\r\nTodos os seus códigos serão descartados e não poderão ser recuperados.');
        window.setTimeout(() => {
            window.alert('A autodestruição era brincadeira tá!')
        }, 3000);
        return false;
    },
}

// Isso aqui são coisas que usamos pra fazer os scripts funcionarem bem com o WebForms
// Pode ser que você tenha um código muito melhor!
// Use este modelo se preferir.

var postBackPage = postBackPage || Sys.WebForms.PageRequestManager.getInstance();

$(document).ready(function () {
    TAREFA2.Carregar();
    $("[id$='_txtNome']").prop('required', true);

    $("[id$='_txtCpf']").mask("999.999.999-99");
    $("[id$='_txtCpf']").prop('required', true);

    $("[id$='_txtRg']").mask("999.999.999");
    $("[id$='_txtRg']").prop('required', true);

    $("[id$='_txtTelefone']").mask("(99) 9999-9999");

    $("[id$='_txtDataNascimento']").mask("99/99/9999");
    $("[id$='_txtDataNascimento']").prop('required', true);

    $("[id$='_ddlSexo']").prop('required', true);


    $("[id$='_txtEmail']").on("blur", (e) => {
        if (!emailValido(e.target.value)) {
            alert("Email digitado é inválido! Digite novamente.")
            $("[id$='_txtEmail']").val("");
        }
    });
});

postBackPage.add_endRequest(function () {
    TAREFA2.Carregar();
});

function emailValido(email) {
    var regex =
        /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    }
    else {
        return true;
    }
}