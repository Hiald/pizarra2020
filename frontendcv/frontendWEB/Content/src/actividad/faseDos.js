﻿
function fbValidar() {
    for (var i = 1; i < 11; i++) {
        if ($('input[name=' + "grd" + i + ']:checked').val() == undefined) {
            alert("falta seleccionar algunas preguntas");
            return;
        }
    }
    if ($('#ip21').val() == "") {
        alert("falta seleccionar algunas preguntas");
        return;
    }
    if ($('#ip22').val() == "") {
        alert("falta seleccionar algunas preguntas");
        return;
    }
    if ($('#ip23').val() == "") {
        alert("falta seleccionar algunas preguntas");
        return;
    }
    if ($('#ip24').val() == "") {
        alert("falta seleccionar algunas preguntas");
        return;
    }
    //si todo esta correcto


    var idusuario = $('#hddidusuario').val();
    for (var i = 1; i < 11; i++) {
        var valorRB = $('input[name=' + "grd" + i + ']:checked').val();
        AlmacenarPreguntas(idusuario, i, 2, valorRB, "", "", "", "", "", "", "", "");

    }

    for (var i = 1; i < 5; i++) {
        var valorRB = $('#ip2' + i).val();
        AlmacenarPreguntas(idusuario, i, 1, valorRB, "", "", "", "", "", "", "", "");
    }

    alert("Registrado correctamente");
    var gidusuario = $('#hddidusuario').val();
    window.location.href = vgrutaprincipal + "actividad/fase?idrespuesta=" + gidusuario;

}


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
            "wifase": 2, //va el numero de la fase
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