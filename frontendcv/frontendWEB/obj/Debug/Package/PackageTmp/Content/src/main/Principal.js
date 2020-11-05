function AbrirCurso(idcurso) {
    var fechabuscar = gfechabuscar;    
    redirectPostV3(vgrutaprincipal + 'curso/curso', "widcurso", idcurso, "wfechabuscar", fechabuscar);
}

new Vue({
    el: "#app",
    methods: {
        CerrarSesion: function () {
            axios({
                method: 'post',
                url: '/login/cerrarSesion'
            })
                .then(function (response) {
                    window.location.href = vgrutaprincipal + "login/inicio";
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
    },
    data: {
        items: [
            {
                src: '/Content/image/contactar.jpg'
            },
            {
                src: '/Content/image/contactar.jpg'
            },
            {
                src: '/Content/image/contactar.jpg'
            }
        ]

    }

});


