$("document").ready(function () {

    var articleUrl = {
        movie: 'http://localhost:63551/api/movie/getRentedArticle',
        game: 'http://localhost:63551/api/game/getRentedArticle'
    };

    var defaultArticle = {
        articleId: "",
        articleName: ""
    };

    var getFileName = function () {
        var date = new Date();
        var strDate = date.getFullYear().toString().concat("/").concat(date.getMonth() + 1).concat("/").concat(date.getDate());
        return "articulos_".concat(strDate);
    };

    var table = $('#articles_table').DataTable({
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
            { data: 'articleName' }
        ]
    });

    table.buttons().container().appendTo($('#tableExport'));

    $('#findMovie').click(function () {
        resetRentalDataInfo();
        getArticlesByType(articleUrl.movie, onSuccessFindArticlesByType, onError);
    });

    $('#findGame').click(function () {
        resetRentalDataInfo();
        getArticlesByType(articleUrl.game, onSuccessFindArticlesByType, onError);
    });

    var getArticlesByType = function (articleUrl, onSuccess, onError) {
        var type = 'GET';
        callAPI(type, articleUrl, null, onSuccess, onError);
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
        table.clear();
        table.rows.add(dataSet);
        table.draw();
    };
	
    $('#articles_table tbody').on('click', 'tr', function () {
        if (table.rows().count() > 0) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                getRentalDataByArticleId(parseInt($(this)[0].cells[0].textContent.trim()), onSuccessRentalSelected, onError);
            }
        }
    });

    var getRentalDataByArticleId = function (id, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/rental/article/{article}';
        var data = { articleId: id };
        callAPI(type, url, data, onSuccess, onError);
    };

    var onSuccessRentalSelected = function (response) {
        if (response === null) {
            alert('No existe una renta con ese identificador, intente con otro.');
            resetRentalDataInfo(false);
        } else {
            showRentalDataInfo(response);
        }
    };

    var showRentalDataInfo = function (rentalData) {
        $("#nif").val(rentalData.nif);
        $("#name").val(rentalData.name);
        $("#lastName").val(rentalData.lastName);
        $("#rentalDate").val(rentalData.rentalDate);
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
        resetRentalDataInfo();
    };

});