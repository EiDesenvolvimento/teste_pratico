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
    ValidaCampos: () => {
        $("[id$='_btnGravar']").on('click', () => {

            if ($.trim($("[id$='txtNome']").val()) == "") {
                alert("O campo Nome é obrigatório!!");
            }
            else if ($.trim($("[id$='txtCpf']").val()) == "") {
                alert("O campo CPF é obrigatório!!");
            }
            else if ($.trim($("[id$='txtRg']").val()) == "") {
                alert("O campo RG é obrigatório!!");
            }
            else if ($.trim($("[id$='ddlSexo']").val()) == "[Selecione]") {
                alert("O campo Sexo é obrigatório!!");
            }
            else if ($.trim($("[id$='txtDataNascimento']").val()) == "") {
                alert("O campo Data de nascimento é obrigatório!!");
            }            
        });
    },
}

// Isso aqui são coisas que usamos pra fazer os scripts funcionarem bem com o WebForms
// Pode ser que você tenha um código muito melhor!
// Use este modelo se preferir.

var postBackPage = postBackPage || Sys.WebForms.PageRequestManager.getInstance();

$(document).ready(function () {
    TAREFA2.Carregar();

    TAREFA2.ValidaCampos();

    $("[id$='txtCpf']").mask("999.999.999-99");
    $("[id$='txtTelefone']").mask("(99) 99999-9999");
    $("[id$='txtDataNascimento']").mask("99/99/9999");
});

postBackPage.add_endRequest(function () {
    TAREFA2.Carregar();
});
