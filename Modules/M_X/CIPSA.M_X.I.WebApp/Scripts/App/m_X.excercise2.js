$("document").ready(function () {

    $("#exerciseTwoShowObject").click(function () {
        $.ajax({
            url: '/api/Casa',
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#exerciseTwoContentJson").html('<span class="row">OBJETO CASA</span><span class="row">'+data+'</span>');
                secondCall();
            },
            error: function (data) {
                alert('Hubo un problema en el servidor, lo sentimos.');
            }
        });
    });

    function secondCall() {
        $.ajax({
            url: '/api/Oficina',
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var beforeHtml = $("#exerciseTwoContentJson").html();
                $("#exerciseTwoContentJson").html(beforeHtml.concat('<span class="row">OBJETO OFICINA</span><span class="row">' + data + '</span>'));
            },
            error: function (data) {
                alert('Hubo un problema en el servidor, lo sentimos.');
            }
        });

    };
});