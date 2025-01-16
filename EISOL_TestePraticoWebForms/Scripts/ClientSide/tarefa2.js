/// <reference path="../../Scripts/jquery-1.10.2.js" />
/// <reference path="../../Scripts/bootstrap.js" />

// Legal né, essas linhas mágicas aí de cima permitem o Visual Studio a montar o Intellisense do jQuery aqui como ele já faz com o C#.
// Não apague elas, elas são do bem.

"use strict"


    $(document).ready(function () {
        $('#MainContent_txtCpf').mask('000.000.000-00');
        $('#MainContent_txtTelefone').mask('(00) 00000-0000');
        $('#MainContent_txtDataNascimento').mask('00/00/0000');
    });

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
        Validar: () => {
            let isValid = true;
            let errorMessage = "";

            // Limpar mensagens de erro anteriores
            $('.error-message').remove();

            // Obter os valores dos campos
            const nome = $("#MainContent_txtNome").val() ? $("#MainContent_txtNome").val().trim() :"";
            const cpf = $("#MainContent_txtCpf").val() ? $("#MainContent_txtCpf").val().trim() : "";
            const telefone = $("#MainContent_txtTelefone").val() ? $("#MainContent_txtTelefone").val().trim() : "";
            const email = $("#MainContent_txtEmail").val() ? $("#MainContent_txtEmail").val().trim() : "";
            const dataNascimento = $("#MainContent_txtDataNascimento").val() ? $("#MainContent_txtDataNascimento").val().trim() : "";

            const cpfRegex = /^\d{3}\.\d{3}\.\d{3}-\d{2}$/;
            const telefoneRegex = /^\(\d{2}\) \d{4,5}-\d{4}$/;
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            const dataRegex = /^\d{2}\/\d{2}\/\d{4}$/;

            // Validar o nome
            if (!nome) {
                errorMessage = "O campo Nome é obrigatório.";
                $("#MainContent_txtNome").after('<span class="error-message">' + errorMessage + '</span>');
                isValid = false;
            }

            // Validar o CPF
            if (!cpf || !cpfRegex.test(cpf)) {
                errorMessage = "O CPF é obrigatório e deve estar no formato 000.000.000-00.";
                $("#MainContent_txtCpf").after('<span class="error-message">' + errorMessage + '</span>');
                isValid = false;
            }

            // Validar o telefone
            if (!telefone || !telefoneRegex.test(telefone)) {
                errorMessage = "O Telefone é obrigatório e deve estar no formato (00) 00000-0000.";
                $("#MainContent_txtTelefone").after('<span class="error-message">' + errorMessage + '</span>');
                isValid = false;
            }

            // Validar o e-mail
            if (!email || !emailRegex.test(email)) {
                errorMessage = "O E-mail é obrigatório e deve estar em um formato válido.";
                $("#MainContent_txtEmail").after('<span class="error-message">' + errorMessage + '</span>');
                isValid = false;
            }

            // Validar a data de nascimento
            if (!dataNascimento || !dataRegex.test(dataNascimento)) {
                errorMessage = "A Data de Nascimento é obrigatória e deve estar no formato DD/MM/YYYY.";
                $("#MainContent_txtDataNascimento").after('<span class="error-message">' + errorMessage + '</span>');
                isValid = false;
            }

            // Retorna false para impedir o envio do formulário em caso de erro
            return isValid;
        }

        
    };


