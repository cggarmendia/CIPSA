$("document").ready(function () {

    $("#exerciseEightFindAndDelete").click(function () {
        var fraseOne = $("#fraseOneFindAndDelete").val();
        var wordToSearch = $("#findWordFindAndDelete").val();

        if (fraseOne == '') {
            alert('Debe escribir la frase uno.');
        } else if (wordToSearch == '') {
            alert('Debe escribir la palabra a buscar.');
        }
        else {
            $.ajax({
                url: '/api/ExerciseEight/BuscaYElimina',
                type: "GET",
                data: { fraseOne: fraseOne, wordToSearch: wordToSearch },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data == '') {
                        alert('La palabra no existe en la frase.');
                    } else {
                        alert('La frase sin la palabra queda así: ' + data + '.');
                    }
                },
                error: function (data) {
                    alert('Hubo un problema en el servidor, lo sentimos.');
                }
            });
        }
    });

    $("#exerciseEightConcat").click(function () {
        var fraseOne = $("#fraseOneConcat").val();
        var fraseTwo = $("#fraseTwoConcat").val();

        if (fraseOne == '') {
            alert('Debe escribir la frase uno.');
        } else if (fraseTwo == '') {
            alert('Debe escribir la frase dos.');
        } 
        else {
            $.ajax({
                url: '/api/ExerciseEight/Concatena',
                type: "GET",
                data: { fraseOne: fraseOne, fraseTwo: fraseTwo },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert('La frase concatenada es: ' + data + '.');
                },
                error: function (data) {
                    alert('Hubo un problema en el servidor, lo sentimos.');
                }
            });
        }
    });


});