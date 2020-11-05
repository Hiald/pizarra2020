
setTimeout(
    function () {
        window.scrollTo(0, 300);
    }, 1000);

new Vue({
    el: '#appregistro',
    methods: {
        RegistroCuenta: function () {
            let self = this
            if (this.cboetapa.valor == undefined || self.namefather == '' || this.cbogrado.valor == undefined || this.cboseccion.valor == undefined) {
                self.dialogocarga = false;
                self.snackbar = true;
                self.text = "Falta completar campos";
                self.color = "info";
            } else {
                this.dialogocarga = true;
                this.show2 = false;
                axios.post(vgruta + 'login/registrarusuario', {
                    "wnombre": this.firstname,
                    "wapellido": this.lastname,
                    "wemail": this.email,
                    "wetapa": this.cboetapa.valor,
                    "wgrado": this.cbogrado.valor,
                    "wseccion": this.cboseccion.valor,
                    "wnombrepadre": this.namefather,
                    "wclave": this.password
                })
                    .then(function (response) {
                        self.dialogocarga = false;
                        if (response.data.iResultado === -1) {
                            self.e1 = 1;
                            self.snackbar = true;
                            self.text = response.data.iresultadoins;
                            self.color = "error";
                        }
                        if (response.data.iResultado === -2) {
                            self.e1 = 1;
                            self.snackbar = true;
                            self.text = "Ya hay una cuenta con ese correo.";
                            self.color = "warning";
                        }
                        if (response.data.iResultado === -3) {
                            self.e1 = 2;
                            self.snackbar = true;
                            self.text = "Ya hay una cuenta con el número.";
                            self.color = "warning";
                        }
                        if (response.data.iResultado === -4) {
                            self.snackbar = true;
                            self.text = response.data.iresultadoins;
                            self.color = "warning";
                        }
                        if (response.data.iResultado === -5) {
                            self.snackbar = true;
                            self.text = response.data.iresultadoins;
                            self.color = "error";
                        }
                        if (response.data.iResultado === 1) {
                            window.location.href = vgruta + "main/index";
                        }

                    })
                    .catch(function (error) {
                        self.dialogocarga = false;
                        self.snackbar = true;
                        self.text = "Ha ocurrido un error, inténtelo nuevamente.";
                        self.color = "error";
                    });
            }

        },
        switchVisibility() {
            this.passwordFieldType = this.passwordFieldType === 'password' ? 'text' : 'password'

        },
        cambiaricono() {
            this.icono === 'fas fa-eye' ? this.icono = this.icono2 : this.icono = 'fas fa-eye'

        },
        Combinacion1: function () {
            this.switchVisibility();
            this.cambiaricono();
        },
        vtooltip() {
            if (this.firstname == '' || this.lastname == '' || this.email == '' || this.password == '') {
                this.show = true;

            } else {
                this.e1 = 2;
                this.show = false;
            }

        },
        vtooltip2() {
            if (this.date == '' || this.phone == '') {
                this.show2 = true;
            } else {
                this.e1 = 3;
                this.show2 = false;
            }

        },
        save(date) {
            this.$refs.menu.save(date)
        },
        fnverificartipocuenta() {
            if (this.cbotp.valor == 1) {
                this.valorce = false;
                this.valorpw = false;
            } else {
                this.valorce = true;
                this.valorpw = true;
            }
        }
    },
    data: {
        email: '',
        icono: 'fas fa-eye',
        icono2: 'fas fa-eye-slash',
        firstname: '',
        lastname: '',
        password: '',
        phone: '',
        enterprice: '',
        web: '',
        namefather: '',
        cboetapa: '',
        cbogrado: '',
        cboseccion: '',
        passwordFieldType: 'password',
        rules: {
            emailrules: v => /.+@.+/.test(v) || 'El correo no es válido',
            required: value => !!value || 'Campo necesario.',
            min: v => v.length >= 8 || 'Mínimo 8 caracteres',
            counter: value => value.length <= 20 || 'Máximo 20 caracteres',
            phoneRules: v => v.length <= 9 || 'El número no es válido',
            enterpriceRules: v => v.length <= 30 || 'Máximo 30 caracteres',
            webRules: v => v.length <= 30 || 'Máximo 30 caracteres'
        },
        radios: '1',
        dialogo: false,
        e1: 0,
        show: false, //campo tooltip
        show2: false, //campo tooltip
        show3: false, //campo tooltip
        date: null,
        menu: false,
        snackbar: false,
        color: '',
        mode: '',
        timeout: 6000,
        text: '',
        valorce: false,
        valorpw: false,
        slcEtapa: [
            { nombre: 'Inicial', valor: 1 },
            { nombre: 'Primaria', valor: 2 },
            { nombre: 'Secundaria', valor: 3 },
            { nombre: 'COAR', valor: 4 },
            { nombre: 'Preuniversitario', valor: 5 }
        ],
        slcgrado: [
            { nombre: 'Primero', valor: 1 },
            { nombre: 'Segundo', valor: 2 },
            { nombre: 'Tercero', valor: 3 },
            { nombre: 'Cuarto', valor: 4 },
            { nombre: 'Quinto', valor: 5 },
            { nombre: 'Sexto', valor: 6 },
            { nombre: '3 años', valor: 1 },
            { nombre: '4 años', valor: 2 },
            { nombre: '5 años', valor: 3 },
            { nombre: 'COAR', valor: 10 },
            { nombre: 'Preuniversitario', valor: 11 }
        ],
        slcseccion: [
            { nombre: 'A', valor: 1 },
            { nombre: 'B', valor: 2 },
            { nombre: 'C', valor: 3 },
            { nombre: 'D', valor: 4 },
            { nombre: 'E', valor: 5 },
            { nombre: 'F', valor: 6 },
            { nombre: 'G', valor: 7 },
            { nombre: 'Rojo', valor: 8 },
            { nombre: 'Verde', valor: 9 },
            { nombre: 'Celeste', valor: 10 },
            { nombre: 'Naranja', valor: 11 },
            { nombre: 'Azul', valor: 12 },
            { nombre: 'Celeste', valor: 13 },
            { nombre: 'Otro', valor: 14 }
        ],
        cbocemp: '',
        dialogocarga: false
    },
    watch: {
        menu(val) {
            val && setTimeout(() => (this.$refs.picker.activePicker = 'YEAR'))
        }
    }
})
