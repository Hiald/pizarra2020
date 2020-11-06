
new Vue({
    el: "#appvideo",
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
        },
        AbrirCurso: function (enlace, titulo, idcurso) {
            redirectPostV4(vgrutaprincipal + 'curso/video', "wenlace", enlace, "wtitulo", titulo, "widvideo", vIdvideo, "widcurso", idcurso, "widsemana", vIdFechaBuscar);
        },
        AbrirVideo: function () {
            axios.post(vgrutaprincipal + 'docente/ListarArchivo', {
                "widvideo": vIdVideoPDF,
                "wtipoarchivo": 2
            })
                .then(function (response) {
                    if (response.data.aaData === []) {
                        alert("No hay transmisiones en vivo en este momento");
                        return;
                    }
                    var valor = response.data.aaData[0].surl;

                    window.open(valor.toString(), "_blank");
                })
                .catch(function (error) {
                    console.log(error);
                });

        },
        DescargarPDF: function () {
            axios.post(vgrutaprincipal + 'docente/ListarArchivo', {
                "widvideo": vIdVideoPDF,
                "wtipoarchivo": 1
            })
                .then(function (response) {

                    var valor = response.data.aaData[0].surl;
                    window.open(valor.toString(), "_blank");
                })
                .catch(function (error) {
                    console.log(error);
                });

            /*  axios({
                  method: 'get',
                  url: '/docente/ListarArchivo',
                  responseType: 'blob'
              })
                  .then(function (response) {
                      console.log(response);
                      /*var fileURL = window.URL.createObjectURL(new Blob([response.data]));
                      var fileLink = document.createElement('a');
  
                      fileLink.href = fileURL;
                      fileLink.setAttribute('download', 'educacion.pdf');
                      document.body.appendChild(fileLink);
  
                      fileLink.click();
                  })
                  .catch(function (error) {
                      console.log(error);
                  });*/
        },
        ListarVideosCapitulo: function () {
            let self = this

            axios.post(vgrutaprincipal + 'curso/ListarVideo', {
                "widcursol": vIdvideo,
                "wfechabuscarl": vIdFechaBuscar
            })
                .then(function (response) {
                    response.data.rDatos.forEach(function (value, index) {
                        self.itemslista[0].items.push({
                            title: value.snombre,
                            rtTitulo: value.snombre,
                            rtvideo: value.srutavideo,
                            idvideo: value.idvideo,
                            idcurso: value.idcurso
                        });
                    });
                })
                .catch(function (error) {
                    console.log(error);
                });

        }
    },
    data: {
        show: false,
        items: [
            {
                src: '/Content/image/contactar.jpg'
            },
            {
                src: 'https://cdn.vuetifyjs.com/images/carousel/sky.jpg'
            },
            {
                src: 'https://cdn.vuetifyjs.com/images/carousel/bird.jpg'
            },
            {
                src: 'https://cdn.vuetifyjs.com/images/carousel/planet.jpg'
            }
        ],
        itemslista: [
            {
                action: 'book',
                title: 'Ejercicio y teoría',
                active: false,
                items: []
            }
        ]

    },
    beforeMount() {
        this.ListarVideosCapitulo();
    }

});

var aud = document.getElementById("videomostrar");
aud.onended = function () {
    console.log("ha finalizado el video");
};