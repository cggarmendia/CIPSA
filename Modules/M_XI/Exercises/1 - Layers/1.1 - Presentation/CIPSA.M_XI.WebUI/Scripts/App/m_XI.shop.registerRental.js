$("document").ready(function () {

    var rentalPrefixUrl = 'http://localhost:63551/api/rental/';

    var articleUrl = {
        movie: 'http://localhost:63551/api/movie/getNonRentedArticle',
        game: 'http://localhost:63551/api/game/getNonRentedArticle'
    };

    var defaultArticle = {
        articleId: "",
        articleName: ""
    };

    var getArticleFileName = function () {
        var date = new Date();
        var strDate = date.getFullYear().toString().concat("/").concat(date.getMonth() + 1).concat("/").concat(date.getDate());
        return "articulosSinRentar_".concat(strDate);
    };

    var articleTable = $('#articles_table').DataTable({
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
                filename: getArticleFileName().concat('_excel'),
                exportOptions: {
                    columns: ':visible:not(.not-export-col)'
                }
            },
            {
                text: 'CSV',
                extend: 'csv',
                filename: getArticleFileName().concat('_csv'),
                exportOptions: {
                    columns: ':visible:not(.not-export-col)'
                }
            }
        ],
        columns: [
            { data: 'articleId' },
            { data: 'articleName' }
        ]
    });

    articleTable.buttons().container().appendTo($('#articleTableExport'));

    $('#findMovie').click(function () {
        getArticlesByType(articleUrl.movie, onSuccessFindArticlesByType);
    });

    $('#findGame').click(function () {
        getArticlesByType(articleUrl.game, onSuccessFindArticlesByType);
    });

    var getArticlesByType = function (articleUrl, onSuccess) {
        var type = 'GET';
        callAPI(type, articleUrl, null, onSuccess);
    };

    var onSuccessFindArticlesByType = function (response) {
        if (response.length === 0) {
            alert('No existen artículos para el tipo seleccionado.');
            updateRentedArticlesTable([defaultArticle]);
        } else {
            updateRentedArticlesTable(response);
        }
    };

    var resetRentalDataInfo = function (reloadTable) {
        $("#nif").val("");
        $("#name").val("");
        $("#lastName").val("");
        $("#rentalDate").val("");
        if (reloadTable === undefined) {
            updateRentedArticlesTable([defaultArticle]);
        }
    };

    var updateRentedArticlesTable = function (dataSet) {
        articleTable.clear();
        articleTable.rows.add(dataSet);
        articleTable.draw();
    };

    $('#articles_table tbody').on('click', 'tr', function () {
        if (articleTable.rows().count() > 0) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                articleTable.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }
        }
    });

    var callAPI = function (type, url, data, onSuccess) {
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
        resetRentalDataInfo();
    };

    var getClientFileName = function () {
        var date = new Date();
        var strDate = date.getFullYear().toString().concat("/").concat(date.getMonth() + 1).concat("/").concat(date.getDate());
        return "clientesParaRentar_".concat(strDate);
    };

    var clientTable = $('#clients_table').DataTable({
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
                filename: getClientFileName().concat('_excel'),
                exportOptions: {
                    columns: ':visible:not(.not-export-col)'
                }
            },
            {
                text: 'CSV',
                extend: 'csv',
                filename: getClientFileName().concat('_csv'),
                exportOptions: {
                    columns: ':visible:not(.not-export-col)'
                }
            }
        ],
        columns: [
            { data: 'id' },
            { data: 'nif' },
            { data: 'name' },
            { data: 'lastName' }
        ]
    });

    clientTable.buttons().container().appendTo($('#clientTableExport'));

    $('#clients_table tbody').on('click', 'tr', function () {
        if (clientTable.rows().count() > 0) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                clientTable.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }
        }
    });

    $('#registerRentalButton').click(function () {
        var articleSelected = articleTable.$('tr.selected');
        var clientSelected = clientTable.$('tr.selected');
        if (articleSelected.length === 0) {
            alert("Seleccione un artículo, por favor.");
        } else if (clientSelected.length === 0) {
            alert("Seleccione un cliente, por favor.");
        } else {
            var articleId = getArticleSelected();
            var clientId = getClientSelected();
            registerRental(`${rentalPrefixUrl}isPossibleToRent/article/${articleId}/client/${clientId}`, onSuccessIsPossibleToRent);
        }
    });

    var registerRental = function (rentalUrl, onSuccess) {
        var type = 'GET';
        callAPI(type, rentalUrl, null, onSuccess);
    };

    var onSuccessIsPossibleToRent = function (response) {
        if (response) {
            addRegisterRental();
        } else {
            alert('El cliente necesita ser mayor de edad (>18).');
        }
    };

    var addRegisterRental = function () {
        var type = 'POST';
        var data = {
            articleId: getArticleSelected(),
            clientId: getClientSelected(),
            date: new Date()
        };
        callAPI(type, `${rentalPrefixUrl}addRental`, JSON.stringify(data), onSuccessRegisterRental);
    };

    var onSuccessRegisterRental = function (response) {
        alert("Alquiler registrado.");
        location.reload();
    };

    var getArticleSelected = function () {
        var articleSelected = articleTable.$('tr.selected');
        return parseInt(articleSelected[0].cells[0].textContent.trim());
    };

    var getClientSelected = function () {
        var clientSelected = clientTable.$('tr.selected');
        return parseInt(clientSelected[0].cells[0].textContent.trim())
    };
});