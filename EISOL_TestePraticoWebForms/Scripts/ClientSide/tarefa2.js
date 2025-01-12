/// <reference path="../../Scripts/jquery-1.10.2.js" />
/// <reference path="../../Scripts/bootstrap.js" />

// Legal né, essas linhas mágicas aí de cima permitem o Visual Studio a montar o Intellisense do jQuery aqui como ele já faz com o C#.
// Não apague elas, elas são do bem.

"use strict";

var TAREFA2 = TAREFA2 || {
    Carregar: () => {
        $("[id$='_btnEstranho']").on('click', () => {
            return TAREFA2.Autodestruir();
        });

        TAREFA2.AdicionarMascaras();
        TAREFA2.ConfigurarValidacao();
    },
    Autodestruir: () => {
        window.alert('Este computador se autodestruirá em 20 segundos...\r\nTodos os seus códigos serão descartados e não poderão ser recuperados.');
        window.setTimeout(() => {
            window.alert('A autodestruição era brincadeira tá!');
        }, 3000);
        return false;
    },
    AdicionarMascaras: () => {
        // Máscara para CPF
        $("[id$='_txtCpf']").on('input', function () {
            let valor = this.value.replace(/\D/g, '');
            valor = valor.replace(/(\d{3})(\d)/, '$1.$2');
            valor = valor.replace(/(\d{3})(\d)/, '$1.$2');
            valor = valor.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
            this.value = valor;
        });

        // Máscara para Telefone
        $("[id$='_txtTelefone']").on('input', function () {
            let valor = this.value.replace(/\D/g, '');
            if (valor.length <= 10) {
                valor = valor.replace(/(\d{2})(\d)/, '($1) $2');
                valor = valor.replace(/(\d{4})(\d)/, '$1-$2');
            } else {
                valor = valor.replace(/(\d{2})(\d)/, '($1) $2');
                valor = valor.replace(/(\d{5})(\d)/, '$1-$2');
            }
            this.value = valor;
        });

        // Máscara para Data de Nascimento
        $("[id$='_txtDataNascimento']").on('input', function () {
            let valor = this.value.replace(/\D/g, '');
            valor = valor.replace(/(\d{2})(\d)/, '$1/$2');
            valor = valor.replace(/(\d{2})(\d)/, '$1/$2');
            this.value = valor;
        });
    },
    ConfigurarValidacao: () => {
        $("[id$='_btnGravar']").on('click', function (e) {
            e.preventDefault();

            // Limpar mensagens de erro anteriores
            $(".text-danger").remove();

            let valido = true;

            // Validação de Nome
            const nome = $("[id$='_txtNome']");
            if (nome.val().trim() === "") {
                valido = false;
                nome.after('<span class="text-danger">O campo Nome é obrigatório.</span>');
            }

            // Validação de CPF
            const cpf = $("[id$='_txtCpf']");
            const cpfValido = /^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}$/.test(cpf.val());
            if (!cpfValido) {
                valido = false;
                cpf.after('<span class="text-danger">Informe um CPF válido.</span>');
            }

            // Validação de Telefone
            const telefone = $("[id$='_txtTelefone']");
            const telefoneValido = /^\(\d{2}\) \d{4,5}-\d{4}$/.test(telefone.val());
            if (!telefoneValido) {
                valido = false;
                telefone.after('<span class="text-danger">Informe um telefone válido.</span>');
            }

            // Validação de Email
            const email = $("[id$='_txtEmail']");
            const emailValido = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email.val());
            if (!emailValido) {
                valido = false;
                email.after('<span class="text-danger">Informe um email válido.</span>');
            }

            // Validação de Data de Nascimento
            const dataNascimento = $("[id$='_txtDataNascimento']");
            const dataValida = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[012])\/\d{4}$/.test(dataNascimento.val());
            if (!dataValida) {
                valido = false;
                dataNascimento.after('<span class="text-danger">Informe uma data de nascimento válida.</span>');
            }

            if (valido) {
                alert("Formulário válido! Pronto para ser enviado.");
                // Aqui você pode submeter o formulário usando __doPostBack() ou outro método
            }
        });
    }
};

var postBackPage = postBackPage || Sys.WebForms.PageRequestManager.getInstance();

$(document).ready(function () {
    TAREFA2.Carregar();
});

postBackPage.add_endRequest(function () {
    TAREFA2.Carregar();
});
