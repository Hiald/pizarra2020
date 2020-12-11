var valorPreguntasFaltantesIP = 0;
var valorPreguntasFaltantesIP2 = 0;
var valorPreguntasFaltantesRD = 0;
var valorPreguntasFaltantesRD2 = 0;

var vpreguntaradio = 0;
$('input[name="vp20"]').click(function () {
    vpreguntaradio = $('input[name="vp20"]:checked').val();
    if (vpreguntaradio == 1) {
        $('.secpreg7').css("display", "block");
    } else {
        $('.secpreg7').css("display", "none");
    }

});

$('#pregsec2').css("display", "none");
var vpreguntaradiof = 0;
$('input[name="vp43"]').click(function () {
    vpreguntaradiof = $('input[name="vp43"]:checked').val();
    if (vpreguntaradiof == 1) {
        $('#pregsec2').css("display", "block");
    } else {
        $('#pregsec2').css("display", "none");
    }

});

function fbValidar() {

    //de la 1 a la 7
    $(".ipgrupo :input").map(function () {
        if ($(this).val() == "") {
            valorPreguntasFaltantesIP++; // si esta correcto es is-valid o sino is-invalid
        }
    });

    if (!valorPreguntasFaltantesIP == 0) {
        alert("Falta responder " + valorPreguntasFaltantesIP + " pregunta(s)");
        valorPreguntasFaltantesIP = 0;
        return;
    }

    $('.rdgrupo input').map(function () {
        if ($('input[name=' + $(this).attr('name') + ']:checked').val() == undefined) {
            valorPreguntasFaltantesRD++;
        }
    });

    if (!valorPreguntasFaltantesRD == 0) {
        alert("Falta seleccionar algunas preguntas");
        valorPreguntasFaltantesRD = 0;
        return;
    }

    //preguntas ocultas
    if (vpreguntaradio == 1) {

        $('.rdgrupo2 input').map(function () {
            if ($('input[name=' + $(this).attr('name') + ']:checked').val() == undefined) {
                valorPreguntasFaltantesRD2++;
            }
        });

        if (!valorPreguntasFaltantesRD2 == 0) {
            alert("Falta seleccionar algunas preguntas");
            valorPreguntasFaltantesRD2 = 0;
            return;
        }

        $(".ipgrupo2 :input").map(function () {
            if ($(this).val() == "") {
                valorPreguntasFaltantesIP2++;
            }
        });

        if (!valorPreguntasFaltantesIP2 == 0) {
            alert("Falta responder" + valorPreguntasFaltantesIP2 + " pregunta(s)");
            valorPreguntasFaltantesIP2 = 0;
            return;
        }
    }

    if (vpreguntaradiof == 1) {
        var ivpreguntaradio = $('input[name="vp44"]:checked').val();
        if (ivpreguntaradio == undefined) {
            alert("Completar la pregunta 20.");
            return;
        }
    }

    fnGuardar();

}

function fnGuardar() {
    var idusuario = $('#hddidusuario').val();
    for (var i = 1; i < 45; i++) {

        if (i == 1 || i == 2 || i == 20 || i == 41 || i == 42 || i == 43) {
            //radio obligatorio
        }

        if (i >= 3 && i <= 19) {
            //input obligatorio
        }

        if (vpreguntaradio == 1) {
            //radio opcional
            if (i == 23 || i == 24 || i == 25 || i == 26 || i == 28) { }

            //checkbox opcional
            if (i >= 29 && i <= 36) { }

            //input opcional
            if (i == 21 || i == 22 || i == 27 || i == 37 || i == 38 || i == 39 || i == 40) { }

        }

        if (vpreguntaradiof == 1) {
            //radio opcional 2
            if (i == 44) { }
        }

    }

    $.ajax({
        url: vgrutaprincipal + "actividad/InsertarActividadAlumnoDetalle",
        type: 'POST',
        data: {
            "widactividadAlumno": idusuario,
            "widactividadDetalle": 1,
            "wrespuesta_A": 1,
            "wrespuesta_B": 2,
            "wrespuesta_C": 3,
            "wrespuesta_D": 4,
            "wrespuesta_E": 5,
            "wrespuesta_F": "asda",
            "wrespuesta_G": 6,
            "wrespuesta_H": "asdas",
            "wrespuesta_I": 8,
            "wipuntaje": 0,
            "witipoPregunta": 1,
            "wifase": 1, //va el numero de la fase
            "wipregunta": 1,
            "witipopregunta": 1
        },
        cache: false,
        success: function (respuesta) {

        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });


}

function fnLeer() { }
