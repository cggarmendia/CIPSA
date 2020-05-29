$("document").ready(function () {

    var getFileName = function () {
        var date = new Date();
        var strDate = date.getFullYear().toString().concat("/").concat(date.getMonth() + 1).concat("/").concat(date.getDate());
        return "Peliculas_".concat(strDate);
    };

    var table = $('#movie_table').DataTable({
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

    $('#movie_table tbody').on('click', 'tr', function () {
        if (table.rows().count() > 0) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                showMovieManagementAnimate(true);
                getMovieById(parseInt($(this)[0].cells[0].textContent.trim()), onSuccessMovieSelected, onError);
                $('#deleteButton').prop("disabled", false);
                $("#detailForm").removeClass("hidden");
                $("#name").attr("readonly", true);
            }
        }
    });

    $('#cancelButton').click(function () {
        resetMovieInfo();
        $("#detailForm").addClass("hidden");
    });

    $('#addOrUpdateButton').click(function () {
        if (validateMovieInfo()) {
            if ($("#name").is('[readonly]')) {
                updateMovie();
                $("#detailForm").addClass("hidden");
            } else {
                getMovieByName($("#name").val(), onSuccessMovieAdded, onError);
            }
        }
    });

    $('#deleteButton').click(function () {
        var type = 'DELETE';
        var url = 'http://localhost:63551/api/movie/deleteMovie?id=' + Number(getIdOfMovieSelected());
        var data = {};
        callAPI(type, url, data, onSuccessMovieDeleted, onError);
        $("#detailForm").removeClass("hidden");        
    });

    $('#addButton').click(function () {
        resetMovieInfo();
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
        showMovieManagementAnimate(false);
    };

    var onSuccessMovieSelected = function (response) {
        if (response === null) {
            alert('No existe ninguna película con ese nombre, intente con otro.');
            showMovieManagementAnimate(false);
        } else {
            showMovieInfo(response);
        }
    };

    var onSuccessMovieUpdated = function (response) {
        if (response === null) {
            alert('No existe ninguna película con ese nombre, intente con otro.');
            showMovieManagementAnimate(false);
        } else {
            showMovieManagementAnimate(false);
            alert(`Datos actualizados correctamente de la película con identificador ${response}`);
            location.reload();
        }
    };

    var onSuccessMovieAdded = function (response) {
        if (response === null) {
            addMovie();
        } else {
            alert('Ya existe una película con ese nombre, lo sentimos.');
        }
    };

    var onSuccessMovieDeleted = function (response) {
        if (response === null) {
            alert('Hubo un problema en el servidor, lo sentimos.');
        } else {
            table.row('.selected').remove().draw(false);
            alert('Datos eliminados correctamente.');
        }
        resetMovieInfo();
        $("#detailForm").addClass("hidden");
    };

    var showMovieInfo = function (movieDto) {
        showMovieManagementAnimate(false);
        $("#name").val(movieDto.name);
        $("#device").val(movieDto.device);
        $("#isAdult").val(movieDto.isAdult);
        document.getElementById(movieDto.isRented ? 'isRentedYes' : 'isRentedNo').checked = true;
        document.getElementById(movieDto.isAdult ? 'isAdultYes' : 'isAdultNo').checked = true;
    };

    var resetMovieInfo = function () {
        $("#name").val("");
        $("#device").val("");
        $("#isAdult").val("");
        $('#movie_table tbody tr').each(function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
        });
        $('#deleteButton').prop("disabled", true);
        $("#name").attr("readonly", false); 
    };

    var validateMovieInfo = function () {
        var isValidated = true;
        if ($("#name").val() === '') {
            isValidated = false;
            alert("El título no puede estar vacío.");
        } else if ($("#device").val() === "") {
            isValidated = false;
            alert("Tiene que seleccionar un dispositivo.");
        }
        return isValidated;
    };

    var showMovieManagementAnimate = function (showAnimate) {
        if (showAnimate) {
            $("#movieManagementInfo").addClass("hide");
            $("#movieManagementAnimate").removeClass("hide");
        } else {
            $("#movieManagementInfo").removeClass("hide");
            $("#movieManagementAnimate").addClass("hide");
        }
    };

    var getIdOfMovieSelected = function () {
        var id = -1;
        $('#movie_table tbody tr').each(function () {
            if ($(this).hasClass('selected')) {
                id = parseInt($(this)[0].cells[0].textContent.trim());
            }
        });
        return id;
    };

    var updateMovie = function () {
        addOrUpdateMovie(getIdOfMovieSelected(), 'PUT', 'http://localhost:63551/api/movie/updateMovie', onSuccessMovieUpdated);
    };

    var addMovie = function () {
        addOrUpdateMovie(0, 'POST', 'http://localhost:63551/api/movie/addMovie', onSuccessMovieUpdated);
    };

    var addOrUpdateMovie = function (id, type, url, onSuccess) {
        showMovieManagementAnimate(true);
        var data = {
            id: id,
            name: $("#name").val(),
            device: $("#device").val(),
            isAdult: document.getElementById('isAdultYes').checked,
            isRented: document.getElementById('isRentedYes').checked,
            rentals: [] 
        };
        callAPI(type, url, JSON.stringify(data), onSuccess, onError);
        resetMovieInfo();
    };

    var getMovieByName = function (name, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/movie/findMovieByName';
        var data = { name: name };
        callAPI(type, url, data, onSuccess, onError);
    };

    var getMovieById = function (id, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/movie/findMovieById';
        var data = { id: id };
        callAPI(type, url, data, onSuccess, onError);
    };
});