new Vue({
    el: '#appis',
    methods: {
        vtooltip() {

            if (this.email == '' || this.password == '') {
                this.snackbar = true;
                this.text = "Falta rellenar campos.";
                this.color = "info";
            } else {
                this.dialogocarga = true;
                let self = this;
                axios.post(vgruta + 'docente/loginDocente', {
                    "sUsuario": this.email,
                    "sClave": this.password
                })
                    .then(function (response) {
                        self.dialogocarga = false;
                        if (response.data.iResultado == -1) {
                            self.e1 = 1;
                            self.snackbar = true;
                            self.text = response.data.iresultadoins;
                            self.color = "error";
                        }
                        if (response.data.iResultado == -2) {
                            self.snackbar = true;
                            self.text = response.data.iresultadoins;
                            self.color = "info";
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
                        if (response.data.iResultado === 1) {
                            window.location.href = vgruta + "docente/mainDocente";
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
        }

    },
    data: {
        email: '',
        icono: 'fas fa-eye',
        icono2: 'fas fa-eye-slash',
        password: '',
        passwordFieldType: 'password',
        rules: {
            emailrules: v => /.+@.+/.test(v) || 'El correo no es válido',
            required: value => !!value || 'Campo necesario.',
            min: v => v.length >= 8 || 'Mínimo 8 caracteres',
            counter: value => value.length <= 20 || 'Máximo 20 caracteres',
            max: v => v.length <= 20 || 'Máximo 20 caracteres'
        },
        dialogo: false,
        snackbar: false,
        color: '',
        mode: '',
        timeout: 6000,
        text: '',
        dialogocarga: false

    }

})
