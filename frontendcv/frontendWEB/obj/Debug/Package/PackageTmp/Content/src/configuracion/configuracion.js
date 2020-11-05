new Vue({
    el: "#appconfiguracion",
    methods: {
        ListarAlumnosConfPre: function () {
            let self = this
            self.rData = [];
            axios.post(vgruta + 'configuracion/listarconfiguracion', {
                "wcorreo": "",
                "wnombre": "",
                "wcategoria": 2
            })
                .then(function (response) {
                    console.log(response);
                    if (response.data === '') {
                        self.txtalerta = 'No hay alumnos registrados en esta categoría';
                    } else {
                        response.data.rDatos.forEach(function (value, index) {
                            if (value.idiasrestantes < 10) {
                                self.rData.push({
                                    accionesida: value.idalumno,
                                    accionesidp: value.idpago,
                                    accionesidc: value.idetapa,
                                    alumno: value.snombre,
                                    correo: value.semail,
                                    fecharegfin: value.sfechareg + " / " + value.sfechafin,
                                    diasrestantes: value.idiasrestantes,
                                    estado: 'error'
                                });
                            } else {
                                self.rData.push({
                                    accionesida: value.idalumno,
                                    accionesidp: value.idpago,
                                    accionesidc: value.idetapa,
                                    alumno: value.snombre,
                                    correo: value.semail,
                                    fecharegfin: value.sfechareg + " / " + value.sfechafin,
                                    diasrestantes: value.idiasrestantes,
                                    estado: 'verified_user'
                                });
                            }
                        });
                    }
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        ListarAlumnosConfPos: function () {
            let self = this
            self.rData = [];

            axios.post(vgruta + 'configuracion/listarconfiguracion', {
                "wcorreo": self.correo,
                "wnombre": self.alumno,
                "wcategoria": 0
            })
                .then(function (response) {

                    if (response.data === '') {
                        self.txtalerta = 'No hay alumnos registrados en esta categoría';
                    } else {
                        response.data.rDatos.forEach(function (value, index) {
                            if (value.idiasrestantes < 10) {
                                self.rData.push({
                                    accionesida: value.idalumno,
                                    accionesidp: value.idpago,
                                    accionesidc: value.idetapa,
                                    alumno: value.snombre,
                                    correo: value.semail,
                                    fecharegfin: value.sfechareg + " / " + value.sfechafin,
                                    diasrestantes: value.idiasrestantes,
                                    estado: 'error'
                                });
                            } else {
                                self.rData.push({
                                    accionesida: value.idalumno,
                                    accionesidp: value.idpago,
                                    accionesidc: value.idetapa,
                                    alumno: value.snombre,
                                    correo: value.semail,
                                    fecharegfin: value.sfechareg + " / " + value.sfechafin,
                                    diasrestantes: value.idiasrestantes,
                                    estado: 'verified_user'
                                });
                            }
                        });
                    }

                })
                .catch(function (error) {
                    console.log(error);
                });

        },
        AbrirActivarDosMeses: function (acciones) {
            this.dialogoconfirmar2meses = true;
            this.dosmesesnomb = acciones.alumno;
            this.dosmesesida = acciones.accionesida;
            this.dosmesescorreo = acciones.correo;
        },
        AbrirActivarSieteMeses: function (acciones) {
            this.dialogoconfirmar7meses = true;
            this.sietemesesnomb = acciones.alumno;
            this.sietemesesida = acciones.accionesida;
            this.sietemesescorreo = acciones.correo;
        },
        ActivarDosMeses: function () {
            let self = this
            axios.post(vgruta + 'configuracion/RegistrarDosMeses', {
                "widalumno": self.dosmesesida,
                "widcategoria": 0,
                "wtipopago": 1,
                "wcorreo": self.dosmesescorreo
            })
                .then(function (response) {
                   
                })
                .catch(function (error) {
                    console.log(error);
                });

            self.dialogoconfirmar2meses = false;
            self.correo = '';
            self.ListarAlumnosConfPre();
            
        },
        ActivarSieteMeses: function () {
            let self = this
            axios.post(vgruta + 'configuracion/RegistrarSieteMeses', {
                "widalumno": self.sietemesesida,
                "widcategoria": 0,
                "wtipopago": 1,
                "wcorreo": self.sietemesescorreo
            })
                .then(function (response) {
                   
                })
                .catch(function (error) {
                    console.log(error);
                });
            self.dialogoconfirmar7meses = false;
            self.correo = '';
            self.ListarAlumnosConfPre();
        },
        GenerarClave: function (acciones) {
            let self = this
            axios.post(vgruta + 'configuracion/GenerarClave', {
                "widalumno": acciones.accionesida
            })
                .then(function (response) {
                    self.nuevaclave = true;
                    self.ncnombre = acciones.alumno;
                    self.ncclave = response.data.iresultadoins;
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
    },
    beforeMount() {
        this.ListarAlumnosConfPre();
    },
    data: {
        ncnombre: '',
        ncclave: 0,
        nuevaclave: false,
        snackbarregistro: false,
        snackbarcolor: '',
        mode: '',
        snackbartexto: '',
        correo: '',
        alumno: '',
        seleccionado: '', // tabla       
        rData: [],
        itemscbocat: [],
        cbocat: '',
        cbocat2: '',
        cbocat3: '',
        txtalerta: 'No hay datos',
        dialogoconfirmar2meses: false,
        dialogoconfirmar7meses: false,
        valoralumno: '',
        //
        dosmesesnomb: '',
        dosmesesida: 0,
        dosmesescorreo: '',
        //
        sietemesesnomb: '',
        sietemesesida: 0,
        sietemesescorreo: '',
        //
        dialogoclavegenerar: false,
        textogenerado: ''
    }
});