var $messages = $('.messages-content'),
    d, h, m,
    i = 0;

var myName = "";
var videoid = "";

$(window).load(function () {
    myName = vSNombre;
    videoid = vIdVideoPDF;
    $messages.mCustomScrollbar();

    firebase.database().ref("messages").on("child_added", function (snapshot) {
        if (snapshot.val().sender === myName && parseInt(snapshot.val().videoid) === parseInt(videoid)) {
            //si hay mensajes mios
            $('<div class="message message-personal"><figure class="avatar"><img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpdX6tPX96Zk00S47LcCYAdoFK8INeCElPeJrVDrh8phAGqUZP_g" /></figure><div id="message-' + snapshot.key + '">' + snapshot.val().message + '</div></div>').appendTo($('.mCSB_container')).addClass('new');
            $('.message-input').val(null);
        } else if (parseInt(snapshot.val().videoid) === parseInt(videoid)) {
            $('<div class="message new"><figure class="avatar"><img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpdX6tPX96Zk00S47LcCYAdoFK8INeCElPeJrVDrh8phAGqUZP_g" /></figure><div id="message-' + snapshot.key + '">' + snapshot.val().sender + ': ' + snapshot.val().message + '</div></div>').appendTo($('.mCSB_container')).addClass('new');
        }

        setDate();
        updateScrollbar();
    });

});

function updateScrollbar() {
    $messages.mCustomScrollbar("update").mCustomScrollbar('scrollTo', 'bottom', {
        scrollInertia: 10,
        timeout: 0
    });
}

function setDate() {
    d = new Date();
    if (m !== d.getMinutes()) {
        m = d.getMinutes();
        $('<div class="timestamp">' + d.getHours() + ':' + m + '</div>').appendTo($('.message:last'));
    }
}

function insertMessage() {
    msg = $('.message-input').val();
    if ($.trim(msg) === '') {
        return false;
    }

    sendMessage();
}

$('.message-submit').click(function () {
    insertMessage();
});

$(window).on('keydown', function (e) {
    if (e.which === 13) {
        insertMessage();
        return false;
    }
});