new Vue({
    el: "#app",
    methods: {
        CerrarSesion: function () {
            axios({
                method: 'post',
                url: '/docente/cerrarSesion'
            })
                .then(function (response) {
                    window.location.href = vgrutaprincipal + "docente/inicio";
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        MenuArchivo: function () {
            window.location.href = vgrutaprincipal + "docente/archivo";
        },
        MenuListado: function () {
            window.location.href = vgrutaprincipal + "docente/listado";
        },
        MenuVideo: function () {
            window.location.href = vgrutaprincipal + "docente/mainDocente";
        },
        IndexPrincipal: function () {
            window.location.href = vgrutaprincipal + "docente/mainDocente";
        }
    },
    data: {

    }

});
