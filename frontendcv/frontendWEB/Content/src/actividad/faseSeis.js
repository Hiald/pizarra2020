﻿function fnValidar() {
    for (var i = 1; i <= 43; i++) {
        if ($('input[name=' + "grd" + i + ']:checked').val() == undefined) {
            alert("Falta seleccionar algunas preguntas");
            return;
        }
    }
    fnGuardar();
}

var fechahoy = moment().format("YYYY-MM-DD");
function fnGuardar() {

    //#region parametros
    var iv1 = $('input[name=' + "grd" + 1 + ']:checked').val();
    var iv2 = $('input[name=' + "grd" + 2 + ']:checked').val();
    var iv3 = $('input[name=' + "grd" + 3 + ']:checked').val();
    var iv4 = $('input[name=' + "grd" + 4 + ']:checked').val();
    var iv5 = $('input[name=' + "grd" + 5 + ']:checked').val();
    var iv6 = $('input[name=' + "grd" + 6 + ']:checked').val();
    var iv7 = $('input[name=' + "grd" + 7 + ']:checked').val();
    var iv8 = $('input[name=' + "grd" + 8 + ']:checked').val();
    var iv9 = $('input[name=' + "grd" + 9 + ']:checked').val();
    var iv10 = $('input[name=' + "grd" + 10 + ']:checked').val();
    var iv11 = $('input[name=' + "grd" + 11 + ']:checked').val();
    var iv12 = $('input[name=' + "grd" + 12 + ']:checked').val();
    var iv13 = $('input[name=' + "grd" + 13 + ']:checked').val();
    var iv14 = $('input[name=' + "grd" + 14 + ']:checked').val();
    var iv15 = $('input[name=' + "grd" + 15 + ']:checked').val();
    var iv16 = $('input[name=' + "grd" + 16 + ']:checked').val();
    var iv17 = $('input[name=' + "grd" + 17 + ']:checked').val();
    var iv18 = $('input[name=' + "grd" + 18 + ']:checked').val();
    var iv19 = $('input[name=' + "grd" + 19 + ']:checked').val();
    var iv20 = $('input[name=' + "grd" + 20 + ']:checked').val();
    var iv21 = $('input[name=' + "grd" + 21 + ']:checked').val();
    var iv22 = $('input[name=' + "grd" + 22 + ']:checked').val();
    var iv23 = $('input[name=' + "grd" + 23 + ']:checked').val();
    var iv24 = $('input[name=' + "grd" + 24 + ']:checked').val();
    var iv25 = $('input[name=' + "grd" + 25 + ']:checked').val();
    var iv26 = $('input[name=' + "grd" + 26 + ']:checked').val();
    var iv27 = $('input[name=' + "grd" + 27 + ']:checked').val();
    var iv28 = $('input[name=' + "grd" + 28 + ']:checked').val();
    var iv29 = $('input[name=' + "grd" + 29 + ']:checked').val();
    var iv30 = $('input[name=' + "grd" + 30 + ']:checked').val();
    var iv31 = $('input[name=' + "grd" + 31 + ']:checked').val();
    var iv32 = $('input[name=' + "grd" + 32 + ']:checked').val();
    var iv33 = $('input[name=' + "grd" + 33 + ']:checked').val();
    var iv34 = $('input[name=' + "grd" + 34 + ']:checked').val();
    var iv35 = $('input[name=' + "grd" + 35 + ']:checked').val();
    var iv36 = $('input[name=' + "grd" + 36 + ']:checked').val();
    var iv37 = $('input[name=' + "grd" + 37 + ']:checked').val();
    var iv38 = $('input[name=' + "grd" + 38 + ']:checked').val();
    var iv39 = $('input[name=' + "grd" + 39 + ']:checked').val();
    var iv40 = $('input[name=' + "grd" + 40 + ']:checked').val();
    var iv41 = $('input[name=' + "grd" + 41 + ']:checked').val();
    var iv42 = $('input[name=' + "grd" + 42 + ']:checked').val();
    var iv43 = $('input[name=' + "grd" + 43 + ']:checked').val();
    var iv44 = "";
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

    var paramidusuario = $('#hddidusuario').val();
    $.ajax({
        url: vgrutaprincipal + "actividad/InsertarFase",
        type: 'POST',
        async: false,
        data: {
            "idaa": paramidusuario, "idad": 6, "i_fase": 6, "v1": iv1, "v2": iv2,
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