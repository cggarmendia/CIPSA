$("document").ready(function () {

    var getFileName = function () {
        var date = new Date();
        var strDate = date.getFullYear().toString().concat("/").concat(date.getMonth() + 1).concat("/").concat(date.getDate());
        return "Juegos_".concat(strDate);
    };

    var table = $('#game_table').DataTable({
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
        ]
    });

    table.buttons().container().appendTo($('#tableExport'));

    $('#game_table tbody').on('click', 'tr', function () {
        if (table.rows().count() > 0) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                showGameManagementAnimate(true);
                getGameById(parseInt($(this)[0].cells[0].textContent.trim()), onSuccessGameSelected, onError);
                $('#deleteButton').prop("disabled", false);
                $("#detailForm").removeClass("hidden");
                $("#name").attr("readonly", true);
            }
        }
    });

    $('#cancelButton').click(function () {
        resetGameInfo();
        $("#detailForm").addClass("hidden");
    });

    $('#addOrUpdateButton').click(function () {
        if (validateGameInfo()) {
            if ($("#name").is('[readonly]')) {
                updateGame();
                $("#detailForm").addClass("hidden");
            } else {
                getGameByName($("#name").val(), onSuccessGameAdded, onError);
            }
        }
    });

    $('#deleteButton').click(function () {
        var type = 'DELETE';
        var url = 'http://localhost:63551/api/game/deleteGame?id=' + Number(getIdOfGameSelected());
        var data = {};
        callAPI(type, url, data, onSuccessGameDeleted, onError);
        $("#detailForm").removeClass("hidden");
    });

    $('#addButton').click(function () {
        resetGameInfo();
        $("#name").attr("readonly", false);
        $("#detailForm").removeClass("hidden");
    });

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
        showGameManagementAnimate(false);
    };

    var onSuccessGameSelected = function (response) {
        if (response === null) {
            alert('No existe ningún juego con ese nombre, intente con otro.');
            showGameManagementAnimate(false);
        } else {
            showGameInfo(response);
        }
    };

    var onSuccessGameUpdated = function (response) {
        if (response === null) {
            alert('No existe ningún juego con ese nombre, intente con otro.');
            showGameManagementAnimate(false);
        } else {
            showGameManagementAnimate(false);
            alert(`Datos actualizados correctamente del juego con identificador ${response}`);
            location.reload();
        }
    };

    var onSuccessGameAdded = function (response) {
        if (response === null) {
            addGame();
        } else {
            alert('Ya existe un juego con ese nombre, lo sentimos.');
        }
    };

    var onSuccessGameDeleted = function (response) {
        if (response === null) {
            alert('Hubo un problema en el servidor, lo sentimos.');
        } else {
            table.row('.selected').remove().draw(false);
            alert('Datos eliminados correctamente.');
        }
        resetGameInfo();
        $("#detailForm").addClass("hidden");
    };

    var showGameInfo = function (gameDto) {
        showGameManagementAnimate(false);
        $("#name").val(gameDto.name);
        $("#platform").val(gameDto.platform);
        $("#isAdult").val(gameDto.isAdult);
        document.getElementById(gameDto.isRented ? 'isRentedYes' : 'isRentedNo').checked = true;
        document.getElementById(gameDto.isAdult ? 'isAdultYes' : 'isAdultNo').checked = true;
    };

    var resetGameInfo = function () {
        $("#name").val("");
        $("#platform").val("");
        $("#isAdult").val("");
        $('#game_table tbody tr').each(function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
        });
        $('#deleteButton').prop("disabled", true);
        $("#name").attr("readonly", false);
    };

    var validateGameInfo = function () {
        var isValidated = true;
        if ($("#name").val() === '') {
            isValidated = false;
            alert("El título no puede estar vacío.");
        } else if ($("#platform").val() === null) {
            isValidated = false;
            alert("El dispositivo no puede estar vacío.");
        }
        return isValidated;
    };

    var showGameManagementAnimate = function (showAnimate) {
        if (showAnimate) {
            $("#gameManagementInfo").addClass("hide");
            $("#gameManagementAnimate").removeClass("hide");
        } else {
            $("#gameManagementInfo").removeClass("hide");
            $("#gameManagementAnimate").addClass("hide");
        }
    };

    var getIdOfGameSelected = function () {
        var id = -1;
        $('#game_table tbody tr').each(function () {
            if ($(this).hasClass('selected')) {
                id = parseInt($(this)[0].cells[0].textContent.trim());
            }
        });
        return id;
    };

    var updateGame = function () {
        addOrUpdateGame(getIdOfGameSelected(), 'PUT', 'http://localhost:63551/api/game/updateGame', onSuccessGameUpdated);
    };

    var addGame = function () {
        addOrUpdateGame(0, 'POST', 'http://localhost:63551/api/game/addGame', onSuccessGameUpdated);
    };

    var addOrUpdateGame = function (id, type, url, onSuccess) {
        showGameManagementAnimate(true);
        var data = {
            id: id,
            name: $("#name").val(),
            platform: $("#platform").val(),
            isAdult: document.getElementById('isAdultYes').checked,
            isRented: document.getElementById('isRentedYes').checked,
            rentals: []
        };
        callAPI(type, url, JSON.stringify(data), onSuccess, onError);
        resetGameInfo();
    };

    var getGameByName = function (name, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/game/findGameByName';
        var data = { name: name };
        callAPI(type, url, data, onSuccess, onError);
    };

    var getGameById = function (id, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/game/findGameById';
        var data = { id: id };
        callAPI(type, url, data, onSuccess, onError);
    };
});