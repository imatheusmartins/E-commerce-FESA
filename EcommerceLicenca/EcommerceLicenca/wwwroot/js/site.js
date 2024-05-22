
function aplicaFiltroConsultaAvancadaPedidos() {
    var vNomeUsuario = document.getElementById('NomeUsuario').value;
    var vCodigoPedido = document.getElementById('CodigoPedido').value;
    var vDataInicial = document.getElementById('dataInicial').value;
    var vDataFinal = document.getElementById('dataFinal').value;
    $.ajax({
        url: "/Pedido/ObtemDadosConsultaAvancada",
        data: {
            nome: vNomeUsuario,
            codigoPedido: vCodigoPedido,
            dataInicial: vDataInicial,
            dataFinal: vDataFinal
        },
        success: function (dados) {
            if (dados.erro != undefined) {
                alert(dados.msg);
            }
            else {
                document.getElementById('resultadoConsulta').innerHTML = dados;
            }
        },
    });

}
