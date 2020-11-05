$(document).ready(function () {

    $('#modalvideo').modal('show');
    $('#contactForm').submit(false);
});

$('#EnviarInformacion').click(function () {
    var wnombre = $('#name').val();
    var wemail = $('#email').val();
    var wcelular = $('#phone').val();
    var wmensaje = $('#message').val();

    if (wnombre == "" || wemail == "" || wcelular == "") {
        alert("Por favor, completar los campos");
    } else {
        $.ajax({
            url: vgruta + "index/ContactarCorreo",
            data: {
                "wemail": wemail,
                "wnombre": wnombre,
                "wcelular": wcelular,
                "wmensaje": wmensaje
            },
            cache: false,
            type: "POST",
            success: function (respuesta) {
                $('#name').val("");
                $('#email').val("");
                $('#phone').val("");
                $('#message').val("");
                alert("muchas gracias por contactarnos");
            },
            error: function () {
                console.log("No se ha podido obtener la información");
            }
        });
    }

});

$('#btncontactarllamada').click(function (e) {
    var wnombre = $('#inpnombre').val();
    var wcelular = $('#inpnumero').val();

    if (wnombre == "" || wcelular == "") {
        alert("Por favor, completar los campos");
    } else {
        $.ajax({
            url: vgruta + "index/ContactarNumero",
            data: {
                "wnombre": wnombre,
                "wcelular": wcelular,
            },
            cache: false,
            type: "POST",
            success: function (respuesta) {
                $('#inpnombre').val("");
                $('#inpnumero').val("");
                $('#modalcelular').modal('show');
                alert("muchas gracias por contactarnos");
            },
            error: function () {
                console.log("No se ha podido obtener la información");
            }
        });
    }

});
