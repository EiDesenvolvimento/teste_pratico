$("#MainContent_ddlUf").on('change', function () {
    if ($("#MainContent_ddlUf").val() == 1) {
        $("#MainContent_ddlCidades").val(1);
    }
    if ($("#MainContent_ddlUf").val() == 2) {
        $("#MainContent_ddlCidades").val(2);
    }
    if ($("#MainContent_ddlUf").val() == 3) {
        $("#MainContent_ddlCidades").val(3);
    }
});

    $(document).ready(function () {
        $('#<%= ddlEstado.ClientID %>').change(function () {
            var estado = $(this).val();  // Pega o valor selecionado do estado

            // Limpa as opções anteriores de cidade
            $('#<%= ddlCidade.ClientID %>').empty();
            $('#<%= ddlCidade.ClientID %>').append('<option value="">Selecione a Cidade</option>');

            // Verifica o estado selecionado e adiciona as cidades correspondentes
            if (estado === 'RJ') {
                $('#<%= ddlCidade.ClientID %>').append('<option value="Rio de Janeiro">Rio de Janeiro</option>');
                $('#<%= ddlCidade.ClientID %>').append('<option value="Niterói">Niterói</option>');
            }
            else if (estado === 'SP') {
                $('#<%= ddlCidade.ClientID %>').append('<option value="São Paulo">São Paulo</option>');
                $('#<%= ddlCidade.ClientID %>').append('<option value="Campinas">Campinas</option>');
            }
            else if (estado === 'MG') {
                $('#<%= ddlCidade.ClientID %>').append('<option value="Belo Horizonte">Belo Horizonte</option>');
                $('#<%= ddlCidade.ClientID %>').append('<option value="Uberlândia">Uberlândia</option>');
            }
        });
    });
