function AbrirCurso(enlace, titulo, idvideo, idcurso, wfechabuscar) {
    redirectPostV4(vgrutaprincipal + 'curso/video', "wenlace", enlace, "wtitulo", titulo, "widvideo", idvideo, "widcurso", idcurso, "wfechabuscar", wfechabuscar);
}

new Vue({
    el: "#appcurso",
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
        },
        IndexPrincipal: function () {
            window.location.href = vgrutaprincipal + "main/index";
        }
    }

});
