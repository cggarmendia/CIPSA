$("document").ready(function () {

    var defaultPendingRentalArticle = {
        articleId: "",
        articleName: "",
        rentalDate: ""
    };

    var getFileName = function () {
        var date = new Date();
        var strDate = date.getFullYear().toString().concat("/").concat(date.getMonth() + 1).concat("/").concat(date.getDate());
        return "ArticulosPendientes_".concat(strDate);
    };
    var table = $('#pendingRentedArticles_table').DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "No hay datos disponibles",
            "info": "Mostrando _START_ hasta _END_ de _TOTAL_ entidades",
            "infoEmpty": "Mostrando 0 hasta 0 de 0 entidades",
            "infoFiltered": "(Filtrado para _MAX_ total de entidades)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ entidades",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "No se encontraron entidades",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        },
        dom: 'Bflrtip',
        buttons: [
            {
                text: 'EXCEL',
                extend: 'excel',
                filename: getFileName().concat('_excel'),
                exportOptions: {
                    columns: ':visible:not(.not-export-col)'
                }
            },
            {
                text: 'CSV',
                extend: 'csv',
                filename: getFileName().concat('_csv'),
                exportOptions: {
                    columns: ':visible:not(.not-export-col)'
                }
            }
        ],
        columns: [
            { data: 'articleId' },
            { data: 'articleName' },
            { data: 'rentalDate' }
        ]
    });

    table.buttons().container().appendTo($('#tableExport'));

    $('#findButton').click(function () {
        var nif = $("#nif").val();
        if (nif === '') {
            resetClientInfo();
            alert('Seleccione un NIF, por favor.');
        } else {
            resetClientInfo();
            getClientByNif(nif, onSuccessFindClientByNif, onError);
        }
    });

    var getClientByNif = function (nif, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/client/findClientByNif';
        var data = { nif: nif };
        callAPI(type, url, data, onSuccess, onError);
    };

    var onSuccessFindClientByNif = function (response) {
        if (response === null) {
            alert('No existe ningún cliente con ese NIF, lo sentimos.');
            resetClientInfo();
        } else {
            showClientInfo(response);
        }
    };

    var showClientInfo = function (clientDto) {
        $("#name").val(clientDto.name);
        $("#lastName").val(clientDto.lastName);
        $("#birthday").val(new Date(clientDto.birthday).toLocaleDateString());
        getPendingRentedArticlesByClientId(clientDto.id, onSuccessFindRentalByClientId, onError);
    };

    var getPendingRentedArticlesByClientId = function (clientId, onSuccess, onError) {
        var type = 'GET';
        var url = `http://localhost:63551/api/rental/client/${clientId}`;
        callAPI(type, url, null, onSuccess, onError);
    };

    var onSuccessFindRentalByClientId = function (response) {
        if (response.length === 0) {
            alert('No existen artículos alquilados pendientes, para el cliente seleccionado.');
            updatePendingRentedArticlesTable([defaultPendingRentalArticle]);
        } else {
            updatePendingRentedArticlesTable(response);
        }
    };

    var resetClientInfo = function () {
        $("#name").val("");
        $("#lastName").val("");
        $("#birthday").val("");
        updatePendingRentedArticlesTable([defaultPendingRentalArticle]);
    };

    var updatePendingRentedArticlesTable = function (dataSet) {
        table.clear();
        table.rows.add(dataSet);
        table.draw();
    };

    var callAPI = function (type, url, data, onSuccess, onError) {
        $.ajax({
            type: type,
            url: url,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                onSuccess(response);
            },
            error: function (response) {
                onError(response);
            }
        });
    };

    var onError = function (response) {
        alert('Hubo un problema en el servidor, lo sentimos.');
        resetClientInfo();
    };

});