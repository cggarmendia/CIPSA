$("document").ready(function () {

    var getFileName = function () {
        var date = new Date();
        var strDate = date.getFullYear().toString().concat("/").concat(date.getMonth() + 1).concat("/").concat(date.getDate());
        return "Clientes_".concat(strDate);
    };

    var table = $('#client_table').DataTable({
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

    $('#client_table tbody').on('click', 'tr', function () {
        if (table.rows().count() > 0) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                showClientManagementAnimate(true);
                getClientById(parseInt($(this)[0].cells[0].textContent.trim()), onSuccessClientSelected, onError);
                $('#deleteButton').prop("disabled", false);
                $("#detailForm").removeClass("hidden");
                $("#name").attr("readonly", true);
            }
        }
    });

    $('#cancelButton').click(function () {
        resetClientInfo();
        $("#detailForm").addClass("hidden");
    });

    $('#addOrUpdateButton').click(function () {
        if (validateClientInfo()) {
            if ($("#name").is('[readonly]')) {
                updateClient();
                $("#detailForm").addClass("hidden");
            } else {
                getClientByNif($("#nif").val(), onSuccessClientAdded, onError);
            }
        }
    });

    $('#deleteButton').click(function () {
        var type = 'DELETE';
        var url = 'http://localhost:63551/api/client/deleteClient?id=' + Number(getIdOfClientSelected());
        var data = {};
        callAPI(type, url, data, onSuccessClientDeleted, onError);
        $("#detailForm").removeClass("hidden");
    });

    $('#addButton').click(function () {
        resetClientInfo();
        $("#name").attr("readonly", false);
        $("#detailForm").removeClass("hidden");
    });

    $(".datepicker").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy',
        minDate: new Date(1850, 11, 11)
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
        showClientManagementAnimate(false);
    };

    var onSuccessClientSelected = function (response) {
        if (response === null) {
            alert('No existe ningún cliente con ese NIF, intente con otro.');
            showClientManagementAnimate(false);
        } else {
            showClientInfo(response);
        }
    };

    var onSuccessClientUpdated = function (response) {
        if (response === null) {
            alert('No existe ningún cliente con ese NIF, intente con otro.');
            showClientManagementAnimate(false);
        } else {
            showClientManagementAnimate(false);
            alert(`Datos actualizados correctamente del cliente con identificador ${response}`);
            location.reload();
        }
    };

    var onSuccessClientAdded = function (response) {
        if (response === null) {
            addClient();
        } else {
            alert('Ya existe un cliente con ese NIF, lo sentimos.');
        }
    };

    var onSuccessClientDeleted = function (response) {
        if (response === null) {
            alert('Hubo un problema en el servidor, lo sentimos.');
        } else {
            table.row('.selected').remove().draw(false);
            alert('Datos eliminados correctamente.');
        }
        resetClientInfo();
        $("#detailForm").addClass("hidden");
    };

    var showClientInfo = function (clientDto) {
        showClientManagementAnimate(false);
        $("#name").val(clientDto.name);
        $("#lastName").val(clientDto.lastName);
        $("#birthday").val(new Date(clientDto.birthday).toLocaleDateString());
        $("#nif").val(clientDto.nif);
    };

    var resetClientInfo = function () {
        $("#name").val("");
        $("#lastName").val("");
        $("#birthday").val("");
        $("#nif").val("");
        $('#client_table tbody tr').each(function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
        });
        $('#deleteButton').prop("disabled", true);
        $("#name").attr("readonly", false);
    };

    var validateClientInfo = function () {
        var birthdayRegex = /^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$/i;
        var isValidated = true;
        if (!birthdayRegex.test($("#birthday").val())) {
            isValidated = false;
            alert("La fecha de nacimiento debe tener el siguiente formato: dd/mm/yyyy");
        } else if ($("#name").val() === '' || $("#lastName").val() === '') {
            isValidated = false;
            alert("El nombre ó apellido no puede estar vacío.");
        } else if ($("#nif").val() === '') {
            isValidated = false;
            alert("El NIF no puede estar vacío.");
        }
        return isValidated;
    };

    var showClientManagementAnimate = function (showAnimate) {
        if (showAnimate) {
            $("#clientManagementInfo").addClass("hide");
            $("#clientManagementAnimate").removeClass("hide");
        } else {
            $("#clientManagementInfo").removeClass("hide");
            $("#clientManagementAnimate").addClass("hide");
        }
    };

    var getIdOfClientSelected = function () {
        var id = -1;
        $('#client_table tbody tr').each(function () {
            if ($(this).hasClass('selected')) {
                id = parseInt($(this)[0].cells[0].textContent.trim());
            }
        });
        return id;
    };

    var updateClient = function () {
        addOrUpdateClient(getIdOfClientSelected(), 'PUT', 'http://localhost:63551/api/client/updateClient', onSuccessClientUpdated);
    };

    var addClient = function () {
        addOrUpdateClient(0, 'POST', 'http://localhost:63551/api/client/addClient', onSuccessClientUpdated);
    };

    var addOrUpdateClient = function (id, type, url, onSuccess) {
        var dateSplited = $("#birthday").val().split('/');
        showClientManagementAnimate(true);
        var data = {
            id: id,
            name: $("#name").val(),
            lastName: $("#lastName").val(),
            birthday: new Date(dateSplited[2], Number(dateSplited[1]) - 1, Number(dateSplited[0]) + 1),
            nif: $("#nif").val()
        };
        callAPI(type, url, JSON.stringify(data), onSuccess, onError);
        resetClientInfo();
    };

    var getClientByNif = function (nif, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/client/findClientByNif';
        var data = { nif: nif };
        callAPI(type, url, data, onSuccess, onError);
    };

    var getClientById = function (id, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/client/findClientById';
        var data = { id: id };
        callAPI(type, url, data, onSuccess, onError);
    };
});