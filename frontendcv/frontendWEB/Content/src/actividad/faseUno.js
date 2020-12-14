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

function fnValidar() {

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
// $("input[name='vp1'][value='2']").prop('checked', true);
// $('#vp35').prop("checked", true);
// 

function fnGuardar() {

    var idusuario = $('#hddidusuario').val();
    for (var i = 1; i < 45; i++) {

        if (i == 1 || i == 2 || i == 20 || i == 41 || i == 42 || i == 43) {
            //radio obligatorio
            var irespuestaradio = $('input[name="vp' + i + '"]:checked').val();
            AlmacenarPreguntas(idusuario, i, 2, irespuestaradio, "", "", "", "", "", "", "", "");
        }

        if (i >= 3 && i <= 19) {
            //input obligatorio
            var irespuestaInput = $('#vp' + i).val();
            AlmacenarPreguntas(idusuario, i, 1, irespuestaInput, "", "", "", "", "", "", "", "");
        }

        if (vpreguntaradio == 1) {
            //radio opcional
            if (i == 23 || i == 24 || i == 25 || i == 26 || i == 28) {
                var irespuestaradioop = $('input[name="vp' + i + '"]:checked').val();
                AlmacenarPreguntas(idusuario, i, 2, irespuestaradioop, "", "", "", "", "", "", "", "");
            }

            //checkbox opcional, guarda si es true o false
            if (i >= 29 && i <= 36) {
                var irespuestaradioOp = $('#vp' + i)[0].checked;
                AlmacenarPreguntas(idusuario, i, 3, irespuestaradioOp, "", "", "", "", "", "", "", "");
            }

            //input opcional
            if (i == 21 || i == 22 || i == 27 || i == 37 || i == 38 || i == 39 || i == 40) {
                var irespuestaInputOp = $('#vp' + i).val();
                AlmacenarPreguntas(idusuario, i, 1, irespuestaInputOp, "", "", "", "", "", "", "", "");
            }

        }

        if (vpreguntaradiof == 1) {
            //radio opcional 2
            if (i == 44) {
                var irespuestaradioOp2 = $('input[name="vp' + i + '"]:checked').val();
                AlmacenarPreguntas(idusuario, i, 2, irespuestaradioOp2, "", "", "", "", "", "", "", "");
            }
        }

    }

    alert("Registrado correctamente");
    var gidusuario = $('#hddidusuario').val();
    window.location.href = vgrutaprincipal + "actividad/fase?idrespuesta=" + gidusuario;


}

function fnLeer() { }

function AlmacenarPreguntas(
    usuarioid, ipregunta, itipopregunta,
    param1, param2, param3, param4,
    param5, param6, param7, param8, param9) {
    // itipopregunta 1 es input
    // itipopregunta 2 es radio
    // itipopregunta 3 es checkbox
    $.ajax({
        url: vgrutaprincipal + "actividad/InsertarActividadAlumnoDetalle",
        type: 'POST',
        async: false,
        data: {
            "widactividadAlumno": usuarioid,
            "widactividadDetalle": ipregunta,
            "wrespuesta_A": param1,
            "wrespuesta_B": param2,
            "wrespuesta_C": param3,
            "wrespuesta_D": param4,
            "wrespuesta_E": param5,
            "wrespuesta_F": param6,
            "wrespuesta_G": param7,
            "wrespuesta_H": param8,
            "wrespuesta_I": param9,
            "wipuntaje": 0,
            "wifase": 1, //va el numero de la fase
            "wipregunta": ipregunta,
            "witipopregunta": itipopregunta
        },
        cache: false,
        success: function (respuesta) {

        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}