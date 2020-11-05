var Session = 0;


//****************************************************************
// Funcion		:: 	fn_util_AjaxWM_Obj
// Descripción	::	Realiza llamada a WebMethod (ASINCRONO) 
//                  Se envia el parametro como OBJETO
//****************************************************************
function fn_util_AjaxWM_Obj(pstrMetodo, pParam, successFn, errorFn) {

    var oParametros = JSON.stringify(pParam);

    //Arma Parametros
    var parametro = '';
    if (oParametros == '') {
        parametro = "{}";
    } else {
        parametro = oParametros;
    }

    if (Session == 0) {
        //Ejecuta Ajax
        $.ajax({
            type: "POST",
            url: pstrMetodo,
            contentType: "application/json; charset=utf-8",
            data: parametro,
            dataType: "json",
            async: true,
            success: function (data) {
                if (data.iTipoResultado == -5) {
                    Session = 1;
                    //$("body").append('<div id="dialog-message" title="Mensaje de Sistema" style="display:none;"><p>' +
                    //    '<span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>' + data.message + '</p></div>');
                    //$("#dialog-message").dialog({
                    //    modal: true,
                    //    draggable: false,
                    //    resizable: false,
                    //    dialogClass: 'no-close',
                    //    open: function (event, ui) {
                    //        $(this).closest('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
                    //        $(this).closest('.ui-dialog').find('.ui-dialog-buttonset').css("text-align", "center").css("float", "none");
                    //    },
                    //    buttons: {
                    //        Cerrar: function () {
                    //            window.location.href = VG_RUTA_SERVIDOR;
                    //        }
                    //    }
                    //});
                } else {
                    successFn(data);
                }
            },
            error: errorFn
        });
    } else {
        //$("#dialog-message").dialog({
        //    modal: true,
        //    draggable: false,
        //    resizable: false,
        //    dialogClass: 'no-close',
        //    open: function (event, ui) {
        //        $(this).closest('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
        //        $(this).closest('.ui-dialog').find('.ui-dialog-buttonset').css("text-align", "center").css("float", "none");
        //    },
        //    buttons: {
        //        Cerrar: function () {
        //            window.location.href = VG_RUTA_SERVIDOR;
        //        }
        //    }
        //});
    }
}


// configuracion general * modificar *
var timefn1;
var timefn2;
var timefn3;

//
function fn_request(idElement) {
    $("#request-" + idElement + "").hide();
    var text = $("#" + idElement + "").attr("data-request");
    $("#" + idElement + "").next().next().after("<span id='request-" + idElement + "' class='css-request'>" + text + "</span>");
    $("#" + idElement + "").focus();
    $(".css-request").fadeOut(5000, function () { $(this).remove() });
}
//
function fn_requestForm(idElement, sMensaje) {
    $("#request-" + idElement + "").hide();
    if (sMensaje == null) {
        sMensaje = $("#" + idElement + "").attr("data-request");
    }
    $("#" + idElement).animate({ borderColor: 'red' }, 500);
    $("#" + idElement + "").after("<span id='request-" + idElement + "' class='css-request'>" + sMensaje + "</span>");
    $(".css-request").fadeOut(5000, function () {
        $("#" + idElement + "").css("border", "1px solid #ccc");
        $(this).remove();
    });
    $("#" + idElement + "").focus();
}


//**************************************************
// ALERTAS => fn_util_bloquearPantalla()
// Parámetros:	
//		pMensaje => Mensaje del cargando
//**************************************************
function fn_util_bloquearPantalla(pMensaje) {
    var wHeight = $(window).height();
    var height = $("body").height();
    if (wHeight == height) {
        $("#dvBloqueo").css("height", wHeight);
    } else {
        $("#dvBloqueo").css("height", height + 100);
    }

    $("#dvBloqueo").show();
    $("#dvBloqueoCont").show();
    if ($.trim(pMensaje) == "") pMensaje = "cargando..."
    $("#dvBloqueoMsg").html(pMensaje);
}
function fn_util_desbloquearPantalla() {
    $("#dvBloqueo").hide();
    $("#dvBloqueoCont").hide();
}

function fn_util_validarEmail(correo) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(correo);
}

/***********************************************************************
 * Variables Globales
 ***********************************************************************/
var vg_sTodosCaracteres = ' !#$%&\()*+,./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyzáéíóú{|}~-';
//var vg_sAlfaNumerico = ' abcdefghijklmnñopqrstuvwxyzáéíóú-1234567890';
var vg_sAlfaNumerico = '-1234567890abcdefghijklmnopqrstuvwxyz:.,();\u00E1\u00E9\u00ED\u00F3\u00FA\u00F1 ';
var vg_sSoloLetras = 'abcdefghijklmnñopqrstuvwxyzáéíóú\u00E1\u00E9\u00ED\u00F3\u00FA\u00F1 ';
//var vg_sSoloNumeros = '-1234567890';
var vg_sSoloNumeros = '1234567890.';
var vg_sSoloNumerosDecimales = '-1234567890';

var vg_sSoloNumerosConSigno = '-1234567890';
var vg_sSoloNumerosDecimales = '-1234567890.';
var vg_sSoloNumerosSinSigno = '1234567890';
var vg_sSoloNumerosParaPlanCuentas = '1234567890_%';
var vg_sAlfaNumericoConEspacio = 'abcdefghijklmnopqrstuvwxyzáéíóúABCDEFGHIJKLMNOPQRSTUVWXYZÁÉÍÓÚ1234567890." "';
var vg_sSoloLetrasConEspacio = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" "';

/***********************************************************************
 * jQuery fn_util_validarCampoDecimal function
 * Validar Decimales: cantidad decimal, signo de puntuacion (',' - '.' ), cantidad de enteros
 * Copyright (c) 2017
 **********************************************************************/
$(document).ready(function () {
    $("input[data-validate='decimal']").fn_util_validarCorreo();
});
(function (a) {
    a.fn.fn_util_validaDecimal = function (longitud) {
        var id = jQuery(this).attr("id");
        if (longitud == null) {
            longitud = jQuery(this).attr("data-length-decimal");
        }
        data - validate
        var caracter = ".";
        a(this).on({
            keypress: function (event) {
                var valor = $(this).val();

                var c = event.which,
                    d = event.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = vg_sSoloNumerosDecimales + caracter;

                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || event.preventDefault();

                var key = String.fromCharCode(event.which);
                var position = $(this).fn_util_obtenerPosicionCursor() - 1;

                //alert(position + "|" + (valor.indexOf(caracter)));
                if (position < (valor.indexOf(caracter))) {

                } else if ((valor.indexOf(caracter) != -1) && (valor.substring(valor.indexOf(caracter), valor.indexOf(caracter).length).length > longitud)) {
                    event.preventDefault();
                }

                //Validar el punto / coma
                if ((valor.indexOf(caracter) != -1) && e == caracter) {
                    event.preventDefault();
                }

                //Validar el negativo
                if ((valor.indexOf('-') != -1) && e == '-') {
                    event.preventDefault();
                }
            }
        });
    }
})(jQuery);

(function (a) {
    a.fn.fn_util_validaDecimalPos = function (longitud) {
        var id = jQuery(this).attr("id");
        if (longitud == null) {
            longitud = jQuery(this).attr("data-length-decimal");
        }
        var caracter = ".";
        a(this).on({
            keypress: function (event) {
                var valor = $(this).val();

                var c = event.which,
                    d = event.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = vg_sSoloNumerosSinSigno + caracter;

                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || event.preventDefault();

                var key = String.fromCharCode(event.which);
                var position = $(this).fn_util_obtenerPosicionCursor() - 1;

                //alert(position + "|" + (valor.indexOf(caracter)));
                if (position < (valor.indexOf(caracter))) {

                } else if ((valor.indexOf(caracter) != -1) && (valor.substring(valor.indexOf(caracter), valor.indexOf(caracter).length).length > longitud)) {
                    event.preventDefault();
                }

                //Validar el punto / coma
                if ((valor.indexOf(caracter) != -1) && e == caracter) {
                    event.preventDefault();
                }

                //Validar el negativo
                if ((valor.indexOf('-') != -1) && e == '-') {
                    event.preventDefault();
                }
            }
        });
    }
})(jQuery);

/***********************************************************************
 * jQuery fn_util_validarCorreo function
 * Validar Correo
 * Copyright (c) 2017
 **********************************************************************/
$(document).ready(function () {
    $("input[data-validate='correo']").fn_util_validarCorreo();
});

(function (a) {
    a.fn.fn_util_validarCorreo = function () {
        var id = jQuery(this).attr("id");
        var b = "abcdefghijklmnñopqrstuvwxyzáéiou@1234567890_-.";

        a(this).on({
            keypress: function (a) {
                var valor = $(this).val();

                var c = a.which,//trae el codigo ascci de la tecla que presiona.
                    d = a.keyCode,//trae el codigo ascci de la tecla que presiona.
                    e = String.fromCharCode(c).toLowerCase(),//devuelve la letra que digitas
                    f = b;// trae los caraceteres aceptados por esa caja de texto.
                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault()

                if (valor.indexOf('@') != -1 && e == '@') {
                    event.returnValue = false;
                }
            },
            blur: function () {
                var valor = $(this).val();

                if (valor == '') {
                    //fn_util_MuestraMensaje("Ingrese un email válido", "W");
                } else if (fn_util_validarEmail(valor)) {

                } else {
                    fn_requestForm(this.id, "El correo no es v&aacute;lido");
                    $(this).focus().select();//posicion del cursos y selecciona el dato.
                }
            }

        });
    }
})(jQuery);

/***********************************************************************
 * jQuery fn_util_validarLetras function
 * Validar Letras
 * Copyright (c) 2017
 **********************************************************************/
$(document).ready(function () {
    $("input[data-validate='letras']").fn_util_validarLetras();
});
(function (a) {
    a.fn.fn_util_validarLetras = function () {
        var id = jQuery(this).attr("id");
        a(this).on({
            keypress: function (a) {

                var c = a.which,//c dfgdfgdfgdfg
                    d = a.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = vg_sSoloLetras;
                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault()
            },
            focusout: function (a) {
                var pDiferente = new RegExp("[" + vg_sSoloLetras + "]", 'gi');
                var sDiferente = vg_sTodosCaracteres.replace(pDiferente, '');
                var pFinal = new RegExp("[" + sDiferente + "]", 'gi');
                var sFinal = jQuery(this).val();
                sFinal = sFinal.replace(pFinal, '');
                jQuery(this).val(sFinal);
            }
        })
    }
})(jQuery);


/***********************************************************************
 * jQuery fn_util_validarAlfaNumerico function
 * Validar Letras
 * Copyright (c) 2017
 **********************************************************************/
$(document).ready(function () {
    $("[data-validate='alfanumerico']").fn_util_validarAlfaNumerico();
});
(function (a) {
    a.fn.fn_util_validarAlfaNumerico = function () {
        var id = jQuery(this).attr("id");
        a(this).on({
            keypress: function (a) {
                var c = a.which,//c dfgdfgdfgdfg
                    d = a.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = vg_sAlfaNumerico;
                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault()
            },
            focusout: function (a) {
                var pDiferente = new RegExp("[" + vg_sAlfaNumerico + "]", 'gi');
                var sDiferente = vg_sTodosCaracteres.replace(pDiferente, '');
                var pFinal = new RegExp("[" + sDiferente + "]", 'gi');
                var sFinal = jQuery(this).val();
                sFinal = sFinal.replace(pFinal, '');
                jQuery(this).val(sFinal);
            }
        })
    }
})(jQuery);


/***********************************************************************
 * jQuery fn_util_validarNumeros function
 * Validar Números
 * Copyright (c) 2017
 **********************************************************************/
$(document).ready(function () {
    $("input[data-validate='numeros']").fn_util_validarNumeros();
});
(function (a) {
    a.fn.fn_util_validarNumeros = function () {
        var id = jQuery(this).attr("id");
        a(this).on({
            blur: function () {
                var valor = $(this).val();

                if (valor == '') {
                    $(this).val('0');
                }

                var pDiferente = new RegExp("[" + vg_sSoloNumeros + "]", 'gi');
                var sDiferente = vg_sTodosCaracteres.replace(pDiferente, '');
                var pFinal = new RegExp("[" + sDiferente + "]", 'gi');
                var sFinal = jQuery(this).val();
                sFinal = sFinal.replace(pFinal, '');
                jQuery(this).val(sFinal);


                //Valida si es numero valido
                if ($.isNumeric(valor)) {
                    $(this).val(valor);
                } else {
                    $(this).val("0");
                }


            },
            keypress: function (a) {
                var c = a.which,//c dfgdfgdfgdfg
                    d = a.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = vg_sSoloNumeros;
                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault()

                //Validar el negativo
                var valor = $(this).val();
                if ((valor.indexOf('-') != -1) && e == '-') {
                    a.preventDefault();
                }

            }
        })
    }
})(jQuery);

/***********************************************************************
 * jQuery fn_util_validarPersonalizado function
 * Validar Letras
 * Copyright (c) 2017
 **********************************************************************/
$(document).ready(function () {
    $("input[data-validate='personalizado']").fn_util_validaPersonalizado();
});
(function (a) {
    a.fn.fn_util_validaPersonalizado = function (sValidar) {
        var id = jQuery(this).attr("id");
        if (sValidar == null) {
            sValidar = jQuery(this).attr("data-caracteres");
        }
        a(this).on({
            keypress: function (a) {
                var c = a.which,//c dfgdfgdfgdfg
                    d = a.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = sValidar;
                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault()
            },
            focusout: function (a) {
                var pDiferente = new RegExp("[" + sValidar + "]", 'gi');
                var sDiferente = vg_sTodosCaracteres.replace(pDiferente, '');
                var pFinal = new RegExp("[" + sDiferente + "]", 'gi');
                var sFinal = jQuery(this).val();
                sFinal = sFinal.replace(pFinal, '');
                jQuery(this).val(sFinal);
            }
        })
    }
})(jQuery);

/***********************************************************************
 * jQuery tipsy function
 * Autocompletar texto
 * Copyright (c) 2017
 **********************************************************************/
(function (a) {
    a.fn.fn_util_autocompletarTexto = function (strUrl, aParm, des) {

        var vId = jQuery(this).attr("id");

        a(this).on({
            keyup: function (a) {

                var vValue = jQuery(this).val();
                if (vValue.length >= 1) {

                    var parametro = '';
                    if (aParm == '') {
                        parametro = "{}";
                    } else {
                        parametro = aParm;
                    }

                    var lstAutoComplete = fn_util_ObtenerJSON(strUrl, aParm);
                    var oLstAutoComplete = JSON.parse(lstAutoComplete);

                    //Arma Cuerpo
                    var arrAutoComplete = new Array();
                    $.each(oLstAutoComplete.aaData, function (i, item) {
                        var objAutoComplete = new Object();
                        objAutoComplete.label = item.Descripcion;
                        arrAutoComplete.push(objAutoComplete)
                    });

                    var strAutoComplete = JSON.stringify(arrAutoComplete);
                    var objAutoComplete = JSON.parse(strAutoComplete);

                    $("#" + vId).autocomplete({
                        source: objAutoComplete
                    });

                }




            }
        })

    }
})(jQuery);

/***********************************************************************
 * funciones Utilitarias
 * obtener Posicion de Cursor, Obtener Trama JSON, Activar Linea de Tabla
 * Copyright (c) 2017
 **********************************************************************/
(function (a) {
    $.fn.fn_util_obtenerPosicionCursor = function () {
        var el = $(this).get(0);
        var pos = 0;
        if ('selectionStart' in el) {
            pos = el.selectionStart;
        } else if ('selection' in document) {
            el.focus();
            var Sel = document.selection.createRange();
            var SelLength = document.selection.createRange().text.length;
            Sel.moveStart('character', -el.value.length);
            pos = Sel.text.length - SelLength;
        }
        return pos;
    }
})(jQuery);

$.extend(
    {
        redirectPost: function (location, args) {
            var form = '';
            $.each(args, function (key, value) {
                value = value.split('"').join('\"')
                form += '<input type="hidden" name="' + key + '" value="' + value + '">';
            });
            $('<form action="' + location + '" method="POST">' + form + '</form>').appendTo($(document.body)).submit();
        }
    });

function fn_CargarBotones(btn1, btn2, btn3) {

    if (btn1 == "True") {
        $('#btnNuevo').show();
    } else {
        $('#btnNuevo').remove();
    }

    if (btn2 == "True") {
        $('#btnEditar').show();
    } else {
        $('#btnEditar').remove();
    }

    if (btn3 == "True") {
        $('#btnEliminar').show();
    } else {
        $('#btnEliminar').remove();
    }
}

$(function () {
    $(".fab-on,.backdrop").click(function () {
        if ($(".backdrop").is(":visible")) {
            $(".backdrop").fadeOut(125);
            $(".fab.child")
                .stop()
                .animate({
                    bottom: $("#masterfab").css("bottom"),
                    opacity: 0,

                }, 125, function () {
                    $(this).hide();
                });
        } else {
            $(".backdrop").fadeIn(125);
            $(".fab.child").each(function () {
                $(this)
                    .stop()
                    .show()
                    .animate({
                        bottom: (parseInt($("#masterfab").css("bottom")) + parseInt($("#masterfab").outerHeight()) + 60 * $(this).data("subitem") - $(".fab.child").outerHeight()) + "px",
                        opacity: 1,
                        right: 15
                    }, 125);
            });
        }
    });
    $(".filter-toggle,.backdropFilter").click(function () {
        if ($(".backdropFilter").is(":visible")) {
            $('.filter').fadeOut(125);
            $('.backdropFilter').fadeOut(125);
        } else {
            $('.filter').fadeIn(125);
            $('.backdropFilter').fadeIn(125);
        }


    });
    $(".filter-close,.close-filter").click(function () {
        $('.filter').fadeOut(125);
        $('.backdropFilter').fadeOut(125);
    });



});
