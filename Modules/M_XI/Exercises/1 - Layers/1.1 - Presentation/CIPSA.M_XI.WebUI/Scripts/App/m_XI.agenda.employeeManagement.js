$("document").ready(function () {

    var getFileName = function () {
        var date = new Date();
        var strDate = date.getFullYear().toString().concat("/").concat(date.getMonth() + 1).concat("/").concat(date.getDate());
        return "GestionDePersonas_".concat(strDate);
    };

    var table = $('#employee_table').DataTable({
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
        "columnDefs": [
            {
                "targets": [0],
                className: "hide_column"
            }
        ]
    });
    
    table.buttons().container().appendTo($('#tableExport'));

    $('#employee_table tbody').on('click', 'tr', function () {
        if (table.rows().count() > 0) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                showEmployeeManagementAnimate(true);
                getEmployeeByDni($(this)[0].cells[1].textContent.trim(), onSuccessEmployeeSelected, onError);
                $('#deleteButton').prop("disabled", false);
                $("#dni").attr("readonly", true);
                $("#detailForm").removeClass("hidden");
            }
        }
    });

    $('#cancelButton').click(function () {    
        resetPersonInfo();
        $("#detailForm").addClass("hidden");
    });

    $('#addOrUpdateButton').click(function () {
        if (validatePersonInfo()) {
            if ($("#dni").is('[readonly]')) {
                updateEmployee();
                $("#detailForm").addClass("hidden");
            } else {
                getEmployeeByDni($("#dni").val(), onSuccessEmployeeAdded, onError);
            }
        }
    });

    $('#deleteButton').click(function () {
        var type = 'DELETE';
        var url = 'http://localhost:63551/api/Agenda/DeleteEmployee?id=' + Number(getIdOfEmployeeSelected());
        var data = {};
        callAPI(type, url, data, onSuccessEmployeeDeleted, onError);
        $("#detailForm").removeClass("hidden");
    });

    $('#addButton').click(function () {
        resetPersonInfo();
        $("#dni").attr("readonly", false);
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
        showEmployeeManagementAnimate(false);   
    };

    var onSuccessEmployeeSelected = function (response) {
        if (response === null) {
            alert('No existe ninguna persona con ese DNI, intente con otro.');
            showEmployeeManagementAnimate(false);
        } else {
            showPersonInfo(response);
        }
    };

    var onSuccessEmployeeUpdated = function (response) {
        if (response === null) {
            alert('No existe ninguna persona con ese DNI, intente con otro.');
            showEmployeeManagementAnimate(false);
        } else {
            showEmployeeManagementAnimate(false);
            alert('Datos actualizados correctamente.');
            location.reload();
        }
    };

    var onSuccessEmployeeAdded = function (response) {
        if (response === null) {
            addEmployee();
        } else {
            alert('Ya existe un usuario con ese dni, lo sentimos.');
        }
    };

    var onSuccessEmployeeDeleted = function (response) {
        if (response === null) {
            alert('Hubo un problema en el servidor, lo sentimos.');
        } else {
            table.row('.selected').remove().draw(false);
            alert('Datos eliminados correctamente.');
        }
        resetPersonInfo();
        $("#detailForm").addClass("hidden");
    };

    var showPersonInfo = function (personDto) {
        showEmployeeManagementAnimate(false);       
        $("#dni").val(personDto.dni);
        $("#name").val(personDto.name);
        $("#lastName").val(personDto.lastName);
        $("#birthday").val(new Date(personDto.birthday).toLocaleDateString());
        $("#phoneNumber").val(personDto.phoneNumber);
    };

    var resetPersonInfo = function () {
        $("#dni").val("");
        $("#name").val("");
        $("#lastName").val("");
        $("#birthday").val("");
        $("#phoneNumber").val("");
        $('#employee_table tbody tr').each(function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
        });
        $('#deleteButton').prop("disabled", true);
        $("#dni").attr("readonly", false); 
    };

    var validatePersonInfo = function () {
        var isValidated = true;
        var birthdayRegex = /^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$/i;
        var phoneNumberRegex = /[\d -]+/g;
        if (!birthdayRegex.test($("#birthday").val())) {
            isValidated = false;
            alert("La fecha de nacimiento debe tener el siguiente formato: dd/mm/yyyy");
        } else if (!phoneNumberRegex.test($("#phoneNumber").val())) {
            isValidated = false;
            alert("El teléfono solo puede debe tener números y guión medio.");
        } else if (!$("#dni").is('[readonly]') && $("#dni").val() === '') {
            isValidated = false;
            alert("El dni no puede estar vacío.");
        }     
        return isValidated;
    };

    var showEmployeeManagementAnimate = function (showAnimate) {
        if (showAnimate) {
            $("#employeeManagementInfo").addClass("hide");
            $("#employeeManagementAnimate").removeClass("hide");
        } else {
            $("#employeeManagementInfo").removeClass("hide");
            $("#employeeManagementAnimate").addClass("hide");
        }
    };

    var getIdOfEmployeeSelected = function () {
        var id = -1;
        $('#employee_table tbody tr').each(function () {
            if ($(this).hasClass('selected')) {
                id = $(this)[0].cells[0].textContent.trim();
            }
        });
        return id;
    };

    var updateEmployee = function () {
        showEmployeeManagementAnimate(true);
        var dateSplited = $("#birthday").val().split('/');
        var type = 'PUT';
        var url = 'http://localhost:63551/api/Agenda/UpdateEmployee';
        var data = {
            id: getIdOfEmployeeSelected(),
            dni: $("#dni").val(),
            name: $("#name").val(),
            lastName: $("#lastName").val(),
            birthday: new Date(dateSplited[2], Number(dateSplited[1]) - 1, Number(dateSplited[0]) + 1),
            phoneNumber: $("#phoneNumber").val()
        };
        callAPI(type, url, JSON.stringify(data), onSuccessEmployeeUpdated, onError);
        resetPersonInfo();
    };

    var addEmployee = function () {
        showEmployeeManagementAnimate(true);
        var dateSplited = $("#birthday").val().split('/');
        var type = 'POST';
        var url = 'http://localhost:63551/api/Agenda/AddPerson';
        var data = {
            id: 0,
            dni: $("#dni").val(),
            name: $("#name").val(),
            lastName: $("#lastName").val(),
            birthday: new Date(dateSplited[2], Number(dateSplited[1]) - 1, Number(dateSplited[0]) + 1),
            phoneNumber: $("#phoneNumber").val()
        };
        callAPI(type, url, JSON.stringify(data), onSuccessEmployeeUpdated, onError);
        resetPersonInfo();
    };

    var getEmployeeByDni = function (dni, onSuccess, onError) {
        var type = 'GET';
        var url = 'http://localhost:63551/api/Agenda/FindEmployeeByDNI';
        var data = { dni: dni };
        callAPI(type, url, data, onSuccess, onError);
    };
});