$("document").ready(function () {

    $("#findPersonButton").click(function () {
        var dniData = $("#findPersonInput").val();

        if (dniData.length < 9) {
            alert('El DNI tiene 9 caracteres.');
        } else if (dniData == '') {
            alert('Por favor, introduzca un DNI.');
        }
        else {
            var type = 'GET';
            var url = 'http://localhost:63551/api/Agenda/FindPersonByDNI';
            var data = { dni: dniData };
            callAPI(type, url, data, onSuccess, onError);
        }
    });

    $('#findPersonInput').keyup(function () {
        $("#findPersonDiv").addClass("hidden");
    });

    var callAPI = function(type, url, data, onSuccess, onError) {
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
    }

    var onSuccess = function (response) {
        if (response === null) {
            alert('No existe ninguna persona con ese DNI, intente con otro.');
        } else {
            showPersonInfo(response);
        }
    };

    var onError = function (response) {
        alert('Hubo un problema en el servidor, lo sentimos.');
    };

    var showPersonInfo = function (personDto) {
        $("#findPersonDiv").removeClass("hidden");
        $("#dni").val(personDto.dni);
        $("#name").val(personDto.name);
        $("#lastName").val(personDto.lastName);
        $("#birthday").val(new Date(personDto.birthday).toLocaleDateString());
        $("#phoneNumber").val(personDto.phoneNumber);
    };
});