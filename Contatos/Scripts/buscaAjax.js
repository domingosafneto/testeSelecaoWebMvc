function buscaAjax(){
    $.ajax({
        method: "GET",
        url: "/Pessoas/Buscar/",
        data: { "texto": $("txtBusca").val() }
    })
}
