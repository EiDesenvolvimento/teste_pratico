/// <reference path="../../Scripts/jquery-1.10.2.js" />
/// <reference path="../../Scripts/bootstrap.js" />

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
    Validar: ()=> {
        // hummmm...
    }
}
function mascaraCpf(campo) {
    var valor = campo.value.replace(/\D/g, ''); // Remove todos os caracteres não numéricos

    if (valor.length <= 11) {
        valor = valor.replace(/(\d{3})(\d)/, "$1.$2");
        valor = valor.replace(/(\d{3})(\d)/, "$1.$2");
        valor = valor.replace(/(\d{3})(\d{1,2})$/, "$1-$2");
    }

    campo.value = valor;
}


function mascaraTelefone(campo) {
    var valor = campo.value.replace(/\D/g, ''); // Remove todos os caracteres não numéricos

    if (valor.length <= 11) {
        valor = valor.replace(/(\d{2})(\d)/, "($1) $2");
        valor = valor.replace(/(\d{5})(\d{1,4})$/, "$1-$2");
    }

    campo.value = valor;
}


function mascaraData(campo) {
    var valor = campo.value.replace(/\D/g, ''); // Remove todos os caracteres não numéricos

    // Verifica se o valor tem pelo menos 2 dígitos para o dia
    if (valor.length <= 2) {
        campo.value = valor.replace(/(\d{2})/, "$1"); // Aplica apenas o formato do dia
    }
    // Se o valor tiver entre 3 e 4 caracteres, adiciona a barra para o mês
    else if (valor.length > 2 && valor.length <= 4) {
        campo.value = valor.replace(/(\d{2})(\d{2})/, "$1/$2"); // Aplica a barra no mês
    }
    // Se o valor tiver entre 5 e 8 caracteres, adiciona a barra para o ano
    else if (valor.length > 4) {
        campo.value = valor.replace(/(\d{2})(\d{2})(\d{4})/, "$1/$2/$3"); // Aplica a barra no ano
    }
}





// Isso aqui são coisas que usamos pra fazer os scripts funcionarem bem com o WebForms
// Pode ser que você tenha um código muito melhor!
// Use este modelo se preferir.

var postBackPage = postBackPage || Sys.WebForms.PageRequestManager.getInstance();

$(document).ready(function () {
    TAREFA2.Carregar();
});

postBackPage.add_endRequest(function () {
    TAREFA2.Carregar();
});