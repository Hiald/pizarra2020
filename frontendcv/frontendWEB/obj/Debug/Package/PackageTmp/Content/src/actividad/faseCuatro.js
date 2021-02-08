
function fnValidar() {
    for (var i = 1; i <= 24; i++) {
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
    var paramipuntaje = 0;
    var paramsdescripcion = "";

    var resultadopos1 = iv1 + "|" + iv10 + "|" + iv15 + "|" + iv19 + "|" + iv21;
    var resultadopos2 = iv2 + "|" + iv7 + "|" + iv11 + "|" + iv16 + "|" + iv22;
    var resultadopos3 = iv3 + "|" + iv4 + "|" + iv8 + "|" + iv12 + "|" + iv23;
    var resultadopos4 = iv6 + "|" + iv13 + "|" + iv17 + "|" + iv24;
    var resultadopos5 = iv5 + "|" + iv9 + "|" + iv14 + "|" + iv18 + "|" + iv20;

    var result1 = resultadopos1.match("1");
    var result2 = resultadopos2.match("1");
    var result3 = resultadopos3.match("1");
    var result4 = resultadopos4.match("1");
    var result5 = resultadopos5.match("1");
    if (result5 >= 0 && result5 <= 2) {
        paramipuntaje = 1;
        paramsdescripcion = "Liderazgo. " +
            "El liderazgo es la capacidad que tiene una persona de influir, motivar, organizar" +
            "y llevar a cabo acciones para lograr sus fines y objetivos que involucren a personas y grupos en una marco de valores. " +
            "El liderazgo es un potencial y se puede desarrollar de diferentes formas y en situaciones muy diferentes unas de otras.";
    } else if (result4 >= 0 && result4 <= 2) {
        paramipuntaje = 2;
        paramsdescripcion = "Resolución de problemas. " +
            "La resolución de problemas es el primer camino para el aprendizaje, la planificación" +
            " y la socialización cuando buscamos apoyo para solucionar aquello que se nos" +
            " presenta día a día, esas oportunidades ricas de interacción, autoestima y" +
            " autorealización";
    } else if (result3 >= 0 && result3 <= 2) {
        paramipuntaje = 3;
        paramsdescripcion = "Expresión de sentimientos. " +
            "Una expresión es una declaración de algo para darlo a entender, puede tratarse" +
            " de la forma de hablar, un gesto o un movimiento corporal. La expresión permite" +
            " exteriorizar sentimientos o ideas.";
    } else if (result2 >= 0 && result2 <= 2) {
        paramipuntaje = 4;
        paramsdescripcion = "Empatía. " +
            "La empatía es la capacidad que tenemos de comprender y compartir los sentimientos de" +
            " otra persona, ante distintos tipos de experiencias. Así por ejemplo, las personas con" +
            " autismo tienen problemas a la hora de identificarse con este tipo de empatía específica.";
    } else if (result1 >= 0 && result1 <= 2) {
        paramipuntaje = 5;
        paramsdescripcion = "Asertividad. " +
            "Es la habilidad de expresar nuestros deseos de una manera amable, franca, abierta, " +
            "directa y adecuada, logrando decir lo que queremos sin atentar contra los demás." +
            "Cuentas con una expresión de una sana autoestima";
    }

    // itipopregunta 1 es input
    // itipopregunta 2 es radio
    // itipopregunta 3 es checkbox
    var paramidusuario = $('#hddidusuario').val();
    $.ajax({
        url: vgrutaprincipal + "actividad/InsertarFase",
        type: 'POST',
        async: false,
        data: {
            "idaa": paramidusuario, "idad": 4, "i_fase": 4, "v1": iv1, "v2": iv2,
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
            "i_puntaje": paramipuntaje, "vdes": paramsdescripcion, "itipopreg": 1, "best": 1, "dtfr": fechahoy
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
    $('#btnaf').css("display", "show");
    $('#btnff').css("display", "none");

    var paramidusuario = $('#hddidusuario').val();
    $.ajax({
        url: vgrutaprincipal + "actividad/ListarActividadAlumnoDetalle",
        type: 'POST',
        data: {
            "widactividad": parseInt(paramidusuario),
            "wifase": parseInt(4)
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