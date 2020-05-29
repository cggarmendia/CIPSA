$("document").ready(function () {

    $("#exerciseElevenClick").click(function () {
        var word = $("#inputExerciseEleven").val();

        if (word == '') {
            alert('Debe escribir una palabra.');
        }
        else {
            $.ajax({
                url: '/api/ExerciseEleven/Get',
                type: "GET",
                data: { id: word },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data == '') {
                        alert('La palabra introducida no existe: ' + word + '.');
                    } else {
                        $("#staticTranslate").val(data);
                    }
                },
                error: function (data) {
                    alert('Hubo un problema en el servidor, lo sentimos.');
                }
            });
        }
    });

    $.ajax({
        url: '/api/ExerciseEleven',
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#exerciseElevenWordToTranslate").html(data.join(', '));
        },
        error: function (data) {
            alert(data);
        }
    });

});