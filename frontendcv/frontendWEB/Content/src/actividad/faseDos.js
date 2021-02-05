
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

    //var idusuario = $('#hddidusuario').val();
    //for (var i = 1; i < 11; i++) {
    //}

    //for (var i = 1; i < 5; i++) {
    //    var valorRB = $('#ip2' + i).val();
    //}
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
    var iv11 = $('#ip2' + 1).val();
    var iv12 = $('#ip2' + 2).val();
    var iv13 = $('#ip2' + 3).val();
    var iv14 = $('#ip2' + 4).val();
    var iv15 = "";
    var iv16 = "";
    var iv17 = "";
    var iv18 = "";
    var iv19 = "";
    var iv20 = "";
    var iv21 = "";
    var iv22 = "";
    var iv23 = "";
    var iv24 = "";
    var iv25 = "";
    var iv26 = "";
    var iv27 = "";
    var iv28 = "";
    var iv29 = "";
    var iv30 = "";
    var iv31 = "";
    var iv32 = "";
    var iv33 = "";
    var iv34 = "";
    var iv35 = "";
    var iv36 = "";
    var iv37 = "";
    var iv38 = "";
    var iv39 = "";
    var iv40 = "";
    var iv41 = "";
    var iv42 = "";
    var iv43 = "";
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

    // itipopregunta 1 es input
    // itipopregunta 2 es radio
    // itipopregunta 3 es checkbox
    var paramidusuario = $('#hddidusuario').val();
    $.ajax({
        url: vgrutaprincipal + "actividad/InsertarFase",
        type: 'POST',
        async: false,
        data: {
            "idaa": paramidusuario, "idad": 2, "i_fase": 2, "v1": iv1, "v2": iv2,
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
