function fnValidar() {
    for (var i = 1; i <= 43; i++) {
        if ($('input[name=' + "grd" + i + ']:checked').val() == undefined) {
            alert("Falta seleccionar algunas preguntas");
            return;
        }
    }
    // si ya esta

    fnGuardar();

}


function fnGuardar() {
    //mostrar();
    var idusuario = $('#hddidusuario').val();
    for (var i = 1; i <= 24; i++) {
        var valorRB = $('input[name=' + "grd" + i + ']:checked').val();
        // itipopregunta 1 es input
        // itipopregunta 2 es radio
        // itipopregunta 3 es checkbox
        $.ajax({
            url: vgrutaprincipal + "actividad/InsertarActividadAlumnoDetalle",
            type: 'POST',
            async: false,
            data: {
                "widactividadAlumno": idusuario,
                "widactividadDetalle": i,
                "wrespuesta_A": valorRB,
                "wrespuesta_B": "",
                "wrespuesta_C": "",
                "wrespuesta_D": "",
                "wrespuesta_E": "",
                "wrespuesta_F": "",
                "wrespuesta_G": "",
                "wrespuesta_H": "",
                "wrespuesta_I": "",
                "wipuntaje": 0,
                "wifase": 6, //va el numero de la fase
                "wipregunta": i,
                "witipopregunta": 2
            },
            cache: false,
            success: function (respuesta) {

            },
            error: function () {
                console.log("No se ha podido obtener la información");
            }
        });

    }
    alert("Registrado correctamente");
    var gidusuario = $('#hddidusuario').val();
    window.location.href = vgrutaprincipal + "actividad/fase?idrespuesta=" + gidusuario;

}