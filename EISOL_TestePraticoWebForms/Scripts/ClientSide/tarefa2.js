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

        $("[id$='_btnGravar']").on('click', (e) => {
            if (!TAREFA2.Validar()) {
                e.preventDefault();
                return false;
            }

            return true;
        })
    },
    Autodestruir: () => {
        window.alert('Este computador se autodestruirá em 20 segundos...\r\nTodos os seus códigos serão descartados e não poderão ser recuperados.');
        window.setTimeout(() => {
            window.alert('A autodestruição era brincadeira tá!')
        }, 3000);
        return false;
    },
    Validar: () => {
        var nome = $("[id$='_txtNome']").val().trim();
        var cpf = $("[id$='_txtCpf']").val().trim();
        var rg = $("[id$='_txtRg']").val().trim();
        var telefone = $("[id$='_txtTelefone']").val().trim();
        var email = $("[id$='_txtEmail']").val().trim();
        var sexo = $("[id$='_ddlSexo']").val().trim();
        var dataNascimento = $("[id$='_txtDataNascimento']").val().trim();

        if (!nome || !cpf || !rg || sexo === "[Selecione]" || !dataNascimento) {
            alert("Preencha todos os campos obrigatórios");
            return false;
        }

        if (nome.length > 200) {
            alert("O campo 'Nome' não pode exceder 200 caracteres.");
            return false;
        }
        if (cpf.length > 11) {
            alert("O campo 'CPF' não pode exceder 11 caracteres.");
            return false;
        }
        if (rg.length > 15) {
            alert("O campo 'RG' não pode exceder 15 caracteres.");
            return false;
        }
        if (telefone.length > 20) {
            alert("O campo 'Telefone' não pode exceder 20 caracteres.");
            return false;
        }
        if (email.length > 200) {
            alert("O campo 'Email' não pode exceder 200 caracteres.");
            return false;
        }

        if (!TAREFA2.ValidarEmail(email)) {
            alert("Email inválido!");
            return false;
        }

        //if (!TAREFA2.ValidarData(dataNascimento)) {
        //    alert("Data de nascimento inválida! Formato esperado: DD/MM/YYYY");
        //    return false;
        //}

        return true;
    },

    ValidarEmail: (email) => {
        var regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return regex.test(email);
    },

    //ValidarData: (dataStr) => {
    //    var parts = dataStr.split('/');
    //    if (parts.length !== 3) return false;
    //    var dia = parseInt(parts[0], 10);
    //    var mes = parseInt(parts[1], 10) - 1;
    //    var ano = parseInt(parts[2], 10);
    //    var dt = new Date(ano, mes, dia);
    //    return dt && dt.getDate() === dia && dt.getMonth() === mes && dt.getFullYear() === ano;
    //}
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