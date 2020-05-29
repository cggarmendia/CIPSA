$("document").ready(function () {
    var rentalPrefixUrl = 'http://localhost:63551/api/rental/';
    var totalDays = 0;
    $('#returnArticleButton').click(function () {
        var articleId = getArticleId();
        if (isArticleIdValid(articleId)) {
            rentedTime(`${rentalPrefixUrl}article/${articleId}/rentedTime`);
        }
    });

    var isArticleIdValid = function (articleId) {
        var isValid = true;
        if (articleId === "") {
            alert("Introduzca un id de producto, por favor.");
            isValid = false;
        } else if (!isNumber(articleId)) {
            alert("El id de producto debe ser un #, lo sentimos.");
            isValid = false;
        } else if (parseInt(articleId) > 2147483647) {
            alert("El id de producto debe ser menor a 2147483647, lo sentimos.");
            isValid = false;
        }
        return isValid;
    };

    var isNumber = function (value) {
        return !isNaN(parseFloat(value)) && isFinite(value);
    };

    var getArticleId = function () {
        return $("#articleId").val();
    };

    var rentedTime = function (rentalUrl) {
        var type = 'GET';
        callAPI(type, rentalUrl, null, onSuccessRentedTime);
    };

    var onSuccessRentedTime = function (response) {
        if (response === 0) {
            alert('No hay rentas registradas para ese producto.');
        } else {
            deleteRental(getArticleId());
            totalDays = response;
        }
    };

    var deleteRental = function (articleId) {
        var type = 'DELETE';
        var url = `${rentalPrefixUrl}DeleteByArticle?articleId=${articleId}`;
        var data = {};
        callAPI(type, url, data, onSuccessRentalDeleted);
    };

    var onSuccessRentalDeleted = function (response) {
        if (response === null) {
            alert('Hubo un problema en el servidor, lo sentimos.');
        } else {
            alert(`Datos eliminados correctamente. El producto estuvo alquilado por ${totalDays} días.`);            
            $("#articleId").val("");
        }
    };

    var callAPI = function (type, url, data, onSuccess) {
        $.ajax({
            type: type,
            url: url,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                onSuccess(response, totalDays);
            },
            error: function (response) {
                onError(response);
            }
        });
    };

    var onError = function () {
        alert('Hubo un problema en el servidor, lo sentimos.');
    };
});