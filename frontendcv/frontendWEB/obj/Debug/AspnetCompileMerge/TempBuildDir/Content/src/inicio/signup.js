new Vue({
    el: '#appregistro',
    methods: {
        RegistroCuenta: function () {
            let self = this
            if (this.firstname == '' || this.lastname == '' || this.email == '' || this.password == '') {
                self.show = true;

            } else {
                self.dialogocarga = true;
                axios.post(vgruta + 'login/registrarusuario', {
                    "wnombre": this.firstname,
                    "wapellido": this.lastname,
                    "wemail": this.email,
                    "wgenero": this.radios,
                    "wclave": this.password
                })
                    .then(function (response) {
                        self.dialogocarga = false;
                        if (response.data.iResultado == -1) {
                            self.snackbar = true;
                            self.text = response.data.iresultadoins;
                            self.color = "error";
                        }
                        if (response.data.iResultado == -2) {
                            self.snackbar = true;
                            self.text = "Ya hay una cuenta con ese correo.";
                            self.color = "warning";
                        }
                        if (response.data.iResultado == -3) {
                            self.snackbar = true;
                            self.text = "Ya hay una cuenta con el número.";
                            self.color = "warning";
                        }
                        if (response.data.iResultado == -4) {
                            self.snackbar = true;
                            self.text = response.data.iresultadoins;
                            self.color = "warning";
                        }
                        if (response.data.iResultado == -5) {
                            self.snackbar = true;
                            self.text = response.data.iresultadoins;
                            self.color = "error";
                        }
                        if (response.data.iResultado == 1) {
                            self.e6 = 2;
                            self.show = false;
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
        e6: 1,
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
        slctipocuenta: [
            { nombre: 'Administrador', valor: 1 },
            { nombre: 'Operador', valor: 2 }
            ,],
        cbotp: '',
        valorce: false,
        valorpw: false,
        slccargo: [
            { nombre: 'Administración', valor: 1 },
            { nombre: 'Individual', valor: 2 },
            { nombre: 'Operaciones', valor: 3 },
            { nombre: 'Marketing', valor: 4 },
            { nombre: 'Ventas', valor: 5 },
            { nombre: 'Servicios/Asistencia técnica', valor: 6 },
            { nombre: 'Otro', valor: 7 }
        ],
        cbocargo: '',
        slccantidadempleado: [
            { nombre: '1', valor: 1 },
            { nombre: '2 a 5', valor: 2 },
            { nombre: '6 a 10', valor: 3 },
            { nombre: '11 a 25', valor: 4 },
            { nombre: '51 a 200', valor: 5 },
            { nombre: '201 a 1000', valor: 6 },
            { nombre: '1000 a más', valor: 7 }
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
