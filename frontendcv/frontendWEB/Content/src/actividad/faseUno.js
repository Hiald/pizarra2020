var valorPreguntasFaltantesIP = 0;
var valorPreguntasFaltantesIP2 = 0;
var valorPreguntasFaltantesRD = 0;
var valorPreguntasFaltantesRD2 = 0;

var fechahoy = moment().format("YYYY-MM-DD");

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
    //#region parametros

    var iv1 = $('input[name="vp' + 1 + '"]:checked').val();
    var iv2 = $('input[name="vp' + 2 + '"]:checked').val();
    var iv3 = $('#vp' + 3).val();
    var iv4 = $('#vp' + 4).val();
    var iv5 = $('#vp' + 5).val();
    var iv6 = $('#vp' + 6).val();
    var iv7 = $('#vp' + 7).val();
    var iv8 = $('#vp' + 8).val();
    var iv9 = $('#vp' + 9).val();
    var iv10 = $('#vp' + 10).val();
    var iv11 = $('#vp' + 11).val();
    var iv12 = $('#vp' + 12).val();
    var iv13 = $('#vp' + 13).val();
    var iv14 = $('#vp' + 14).val();
    var iv15 = $('#vp' + 15).val();
    var iv16 = $('#vp' + 16).val();
    var iv17 = $('#vp' + 17).val();
    var iv18 = $('#vp' + 18).val();
    var iv19 = $('#vp' + 19).val();
    var iv20 = $('input[name="vp' + 20 + '"]:checked').val();
    var iv21 = $('#vp' + 21).val();
    var iv22 = $('#vp' + 22).val();
    var iv23 = $('input[name="vp' + 23 + '"]:checked').val();
    var iv24 = $('input[name="vp' + 24 + '"]:checked').val();
    var iv25 = $('input[name="vp' + 25 + '"]:checked').val();
    var iv26 = $('input[name="vp' + 26 + '"]:checked').val();
    var iv27 = $('#vp' + 27).val();
    var iv28 = $('input[name="vp' + 28 + '"]:checked').val();
    var iv29 = $('#vp' + 29)[0].checked;
    var iv30 = $('#vp' + 30)[0].checked;
    var iv31 = $('#vp' + 31)[0].checked;
    var iv32 = $('#vp' + 32)[0].checked;
    var iv33 = $('#vp' + 33)[0].checked;
    var iv34 = $('#vp' + 34)[0].checked;
    var iv35 = $('#vp' + 35)[0].checked;
    var iv36 = $('#vp' + 36)[0].checked;
    var iv37 = $('#vp' + 37).val();
    var iv38 = $('#vp' + 38).val();
    var iv39 = $('#vp' + 39).val();
    var iv40 = $('#vp' + 40).val();
    var iv41 = $('input[name="vp' + 41 + '"]:checked').val();
    var iv42 = $('input[name="vp' + 42 + '"]:checked').val();
    var iv43 = $('input[name="vp' + 43 + '"]:checked').val();
    var iv44 = $('input[name="vp' + 44 + '"]:checked').val();
    var iv45 = "";
    var iv46 = "";
    var iv47 = "";
    var iv48 = "";
    var iv49 = "";
    var iv50 = "";
    var iv51 = "";
    var iv52 = "";
    var iv53 = "";
    var iv54 = "";
    var iv55 = "";
    var iv56 = "";
    var iv57 = "";
    var iv58 = "";
    var iv59 = "";
    var iv60 = "";
    //#endregion

    //#region bloque de codigo validador

    //for (var i = 1; i < 45; i++) {

    //    if (i == 1 || i == 2 || i == 20 || i == 41 || i == 42 || i == 43) {
    //        //radio obligatorio
    //        var irespuestaradio = $('input[name="vp' + i + '"]:checked').val();
    //    }
    //    if (i >= 3 && i <= 19) {
    //        //input obligatorio
    //        var irespuestaInput = $('#vp' + i).val();
    //    }
    //    if (vpreguntaradio == 1) {
    //        //radio opcional
    //        if (i == 23 || i == 24 || i == 25 || i == 26 || i == 28) {
    //            var irespuestaradioop = $('input[name="vp' + i + '"]:checked').val();
    //        }
    //        //checkbox opcional, guarda si es true o false
    //        if (i >= 29 && i <= 36) {
    //            var irespuestaradioOp = $('#vp' + i)[0].checked;
    //        }
    //        //input opcional
    //        if (i == 21 || i == 22 || i == 27 || i == 37 || i == 38 || i == 39 || i == 40) {
    //            var irespuestaInputOp = $('#vp' + i).val();
    //        }
    //    }
    //    if (vpreguntaradiof == 1) {
    //        //radio opcional 2
    //        if (i == 44) {
    //            var irespuestaradioOp2 = $('input[name="vp' + i + '"]:checked').val();
    //        }
    //    }

    //}
    //#endregion

    // itipopregunta 1 es input
    // itipopregunta 2 es radio
    // itipopregunta 3 es checkbox
    var paramidusuario = $('#hddidusuario').val();

    $.ajax({
        url: vgrutaprincipal + "actividad/InsertarFase",
        type: 'POST',
        async: false,
        data: {
            "idaa": paramidusuario, "idad": 1, "i_fase": 1, "v1": iv1, "v2": iv2,
            "v3": iv3, "v4": iv4, "v5": iv5, "v6": iv6, "v7": iv7, "v8": iv8,
            "v9": iv9, "v10": iv10, "v11": iv11, "v12": iv12, "v13": iv13, "v14": iv14,
            "v15": iv15, "v16": iv16, "v17": iv17, "v18": iv18, "v19": iv19, "v20": iv20,
            "v21": iv21, "v22": iv22, "v23": iv23, "v24": iv24, "v25": iv25,
            "v26": iv26, "v27": iv27, "v28": iv28, "v29": iv29, "v30": iv30,
            "v31": iv31, "v32": iv32, "v33": iv33, "v34": iv34, "v35": iv35,
            "v36": iv36, "v37": iv37, "v38": iv38, "v39": iv39, "v40": iv40,
            "v41": iv41, "v42": iv42, "v43": iv43, "v44": iv44, "v45": iv45,
            "v46": iv46, "v47": iv47, "v48": iv48, "v49": iv49, "v50": iv50,
            "v51": iv51, "v52": iv52, "v53": iv53, "v54": iv54, "v55": iv55,
            "v56": iv56, "v57": iv57, "v58": iv58, "v59": iv59, "v60": iv60,
            "i_puntaje": 0, "vdes": "", "itipopreg": 0, "best": 1, "dtfr": fechahoy
        },
        cache: false,
        success: function (respuesta) {
            alert("Registrado correctamente");
            var gidusuario = $('#hddidusuario').val();
            window.location.href = vgrutaprincipal + "actividad/fase?idrespuesta=" + gidusuario;
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}

function fnLeer() { }
$('#frmcerrar').submit(false);