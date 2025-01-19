/// <reference path="../../Scripts/jquery-1.10.2.js" />
/// <reference path="../../Scripts/bootstrap.js" />

// Legal né, essas linhas mágicas aí de cima permitem o Visual Studio a montar o Intellisense do jQuery aqui como ele já faz com o C#.
// Não apague elas, elas são do bem.

"use strict"

var TAREFA2 = TAREFA2 || {
    Carregar: () => {
        $("[id$='_btnGravar']").on('click', (event) => {
            if (!TAREFA2.Validar()) {
                event.preventDefault();
                return false;
            }
        });
    },

    //Função para exibir as mensagens de erro
    ExibirErro: (campo, mensagem, validaFuncao) => {
        //Recebe a função de validação como parâmetro e executa ela
        const isValid = validaFuncao(campo);

        campo.siblings(".text-danger").remove();

        //Dependendo do resultado da validação definida, ele mostra o erro ou não
        if (!isValid) {
            campo.after('<span class="text-danger">' + mensagem + '</span>');
        }

        return isValid;
    },

    Validar: () => {
        const campos = [
            { campo: $("[id$='_txtNome']"), mensagem: 'O campo Nome deve ter entre 1 e 200 caracteres.', valida: (campo) => TAREFA2.ValidarComprimento(campo, 1, 200) },
            { campo: $("[id$='_txtCpf']"), mensagem: 'O campo CPF deve ter exatamente 11 caracteres.', valida: (campo) => TAREFA2.ValidarComprimento(campo, 11, 11) },
            { campo: $("[id$='_txtRg']"), mensagem: 'O campo RG deve ter entre 1 e 15 caracteres.', valida: (campo) => TAREFA2.ValidarComprimento(campo, 1, 15) },
            { campo: $("[id$='_txtTelefone']"), mensagem: 'O campo Telefone deve ter entre 1 e 20 caracteres.', valida: (campo) => TAREFA2.ValidarComprimento(campo, 1, 20) },
            { campo: $("[id$='_txtEmail']"), mensagem: 'O campo Email deve ter entre 5 e 200 caracteres.', valida: (campo) => TAREFA2.ValidarComprimento(campo, 5, 200) },
            { campo: $("[id$='_txtEmail']"), mensagem: 'O formato de email está inválido.', valida: (campo) => TAREFA2.ValidarEmail(campo.val()) },
            { campo: $("[id$='_ddlSexo']"), mensagem: 'O campo Sexo é obrigatório.', valida: (campo) => campo.val() !== '[Selecione]' },
            { campo: $("[id$='_txtDataNascimento']"), mensagem: 'O campo Data de Nascimento deve ter 10 caracteres.', valida: (campo) => TAREFA2.ValidarComprimento(campo, 10, 10) }
        ];

        let isValid = true;

        campos.forEach(({ campo, mensagem, valida }) => {
            if (!TAREFA2.ExibirErro(campo, mensagem, valida)) {
                isValid = false;
            }
        });

        return isValid;
    },

    ValidarComprimento: (campo, minLength, maxLength) => {
        const valor = campo.val().trim();
        return valor.length >= minLength && valor.length <= maxLength;
    },
    ValidarEmail: (email) => {
        const regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
        return regex.test(email);
    },
};

var postBackPage = postBackPage || Sys.WebForms.PageRequestManager.getInstance();

$(document).ready(function () {
    TAREFA2.Carregar();
});

postBackPage.add_endRequest(function () {
    TAREFA2.Carregar();
});