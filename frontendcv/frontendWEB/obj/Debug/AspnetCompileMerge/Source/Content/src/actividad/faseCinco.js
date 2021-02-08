function fnValidar() {
    for (var i = 1; i <= 28; i++) {
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

    var resultadopos1a = iv1 + "|" + iv5 + "|" + iv9 + "|" + iv13 + "|" + iv17 + "|" + iv21 + "|" + iv25;
    var resultadopos2b = iv1 + "|" + iv5 + "|" + iv9 + "|" + iv13 + "|" + iv17 + "|" + iv21 + "|" + iv25;

    var resultadopos3a = iv2 + "|" + iv6 + "|" + iv10 + "|" + iv14 + "|" + iv18 + "|" + iv22 + "|" + iv26;
    var resultadopos4b = iv2 + "|" + iv6 + "|" + iv10 + "|" + iv14 + "|" + iv18 + "|" + iv22 + "|" + iv26;

    var resultadopos5a = iv3 + "|" + iv7 + "|" + iv11 + "|" + iv15 + "|" + iv19 + "|" + iv23 + "|" + iv27;
    var resultadopos6b = iv3 + "|" + iv7 + "|" + iv11 + "|" + iv15 + "|" + iv19 + "|" + iv23 + "|" + iv27;

    var resultadopos7a = iv4 + "|" + iv8 + "|" + iv12 + "|" + iv16 + "|" + iv20 + "|" + iv24 + "|" + iv28;
    var resultadopos8b = iv4 + "|" + iv8 + "|" + iv12 + "|" + iv16 + "|" + iv20 + "|" + iv24 + "|" + iv28;

    var match1a = resultadopos1a.match("1");
    var match1b = resultadopos2b.match("2");

    var match2a = resultadopos3a.match("1");
    var match2b = resultadopos4b.match("2");

    var match3a = resultadopos5a.match("1");
    var match3b = resultadopos6b.match("2");

    var match4a = resultadopos7a.match("1");
    var match4b = resultadopos8b.match("2");

    var paramidusuario = $('#hddidusuario').val();
    $.ajax({
        url: vgrutaprincipal + "actividad/InsertarFase",
        type: 'POST',
        async: false,
        data: {
            "idaa": paramidusuario, "idad": 5, "i_fase": 5, "v1": iv1, "v2": iv2,
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

function fnLeer(ifase) {
    $('#btnaf').css("display", "none");
    $('#btnff').css("display", "none");

    var paramidusuario = $('#hddidusuario').val();
    $.ajax({
        url: vgrutaprincipal + "actividad/ListarActividadAlumnoDetalle",
        type: 'POST',
        data: {
            "widactividad": parseInt(paramidusuario),
            "wifase": parseInt(5)
        },
        cache: false,
        success: function (val) {
            console.log(val);
            $('input[name="' + "grd1" + '"][value="' + val.aaData[0].v_pregunta_1 + '"]').prop('checked', true);
            $('input[name="' + "grd2" + '"][value="' + val.aaData[0].v_pregunta_2 + '"]').prop('checked', true);
            $('input[name="' + "grd3" + '"][value="' + val.aaData[0].v_pregunta_3 + '"]').prop('checked', true);
            $('input[name="' + "grd4" + '"][value="' + val.aaData[0].v_pregunta_4 + '"]').prop('checked', true);
            $('input[name="' + "grd5" + '"][value="' + val.aaData[0].v_pregunta_5 + '"]').prop('checked', true);
            $('input[name="' + "grd6" + '"][value="' + val.aaData[0].v_pregunta_6 + '"]').prop('checked', true);
            $('input[name="' + "grd7" + '"][value="' + val.aaData[0].v_pregunta_7 + '"]').prop('checked', true);
            $('input[name="' + "grd8" + '"][value="' + val.aaData[0].v_pregunta_8 + '"]').prop('checked', true);
            $('input[name="' + "grd9" + '"][value="' + val.aaData[0].v_pregunta_9 + '"]').prop('checked', true);
            $('input[name="' + "grd10" + '"][value="' + val.aaData[0].v_pregunta_10 + '"]').prop('checked', true);
            $('input[name="' + "grd11" + '"][value="' + val.aaData[0].v_pregunta_11 + '"]').prop('checked', true);
            $('input[name="' + "grd12" + '"][value="' + val.aaData[0].v_pregunta_12 + '"]').prop('checked', true);
            $('input[name="' + "grd13" + '"][value="' + val.aaData[0].v_pregunta_13 + '"]').prop('checked', true);
            $('input[name="' + "grd14" + '"][value="' + val.aaData[0].v_pregunta_14 + '"]').prop('checked', true);
            $('input[name="' + "grd15" + '"][value="' + val.aaData[0].v_pregunta_15 + '"]').prop('checked', true);
            $('input[name="' + "grd16" + '"][value="' + val.aaData[0].v_pregunta_16 + '"]').prop('checked', true);
            $('input[name="' + "grd17" + '"][value="' + val.aaData[0].v_pregunta_17 + '"]').prop('checked', true);
            $('input[name="' + "grd18" + '"][value="' + val.aaData[0].v_pregunta_18 + '"]').prop('checked', true);
            $('input[name="' + "grd19" + '"][value="' + val.aaData[0].v_pregunta_19 + '"]').prop('checked', true);
            $('input[name="' + "grd20" + '"][value="' + val.aaData[0].v_pregunta_20 + '"]').prop('checked', true);
            $('input[name="' + "grd21" + '"][value="' + val.aaData[0].v_pregunta_21 + '"]').prop('checked', true);
            $('input[name="' + "grd22" + '"][value="' + val.aaData[0].v_pregunta_22 + '"]').prop('checked', true);
            $('input[name="' + "grd23" + '"][value="' + val.aaData[0].v_pregunta_23 + '"]').prop('checked', true);
            $('input[name="' + "grd24" + '"][value="' + val.aaData[0].v_pregunta_24 + '"]').prop('checked', true);
            $('input[name="' + "grd25" + '"][value="' + val.aaData[0].v_pregunta_25 + '"]').prop('checked', true);
            $('input[name="' + "grd26" + '"][value="' + val.aaData[0].v_pregunta_26 + '"]').prop('checked', true);
            $('input[name="' + "grd27" + '"][value="' + val.aaData[0].v_pregunta_27 + '"]').prop('checked', true);
            $('input[name="' + "grd28" + '"][value="' + val.aaData[0].v_pregunta_28 + '"]').prop('checked', true);

            $('#hddpuntaje').val(val.aaData[0].i_puntaje);
            $('#hdddescripcion').val(val.aaData[0].v_descripcion);
            $('#hddtipopregunta').val(val.aaData[0].i_tipo_pregunta);
            $('#lbldescripcion').text(val.aaData[0].v_descripcion);
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}

function fnGenerarFase() {
    $('#modalfaseresultado').modal("show");
}

function fninicio() {
    var gidusuario = $('#hddidusuario').val();
    window.location.href = vgrutaprincipal + "actividad/fase?idrespuesta=" + gidusuario;
}

$(document).ready(function () {
    var gicompletado = $('#hddiCompletado').val();
    if (gicompletado != 0) {
        fnLeer(gicompletado);
    } else {
        console.log("sin completar");
        $('#btnff').css("display", "show");
        $('#btnaf').css("display", "none");
    }
});