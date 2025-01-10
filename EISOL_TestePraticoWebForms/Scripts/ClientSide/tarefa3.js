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
function carregarCidades() {
    var ufId = document.getElementById('<%= ddlUf.ClientID %>').value;
    var cidadeDropdown = document.getElementById('<%= ddlCidades.ClientID %>');

    var xhr = new XMLHttpRequest();
    xhr.open('GET', 'Tarefa3.aspx?codigoUF=' + ufId, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var cidades = JSON.parse(xhr.responseText);
            cidadeDropdown.innerHTML = "";
            cidades.forEach(function (cidade) {
                var option = document.createElement("option");
                option.value = cidade.COD_CIDADE;
                option.text = cidade.NOME;
                cidadeDropdown.appendChild(option);
            });
        }
    };
    xhr.send();
}
