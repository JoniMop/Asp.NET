let inputPassTemp = document.getElementById("tempPass");
let inputPassEmail = document.getElementById("inputPass");
let recoverPass = document.getElementById("btnRecoverPass");

//generar codigo de verificacion
function generar_pass() {

    var letras = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I');
    var numeros = new Array('1', '2', '3', '4', '5', '6', '7', '8', '9');

    var letra1 = letras[Math.floor(Math.random() * letras.length)];
    var numero1 = numeros[Math.floor(Math.random() * numeros.length)];
    var letra2 = letras[Math.floor(Math.random() * letras.length)];
    var numero2 = numeros[Math.floor(Math.random() * numeros.length)];
    var letra3 = letras[Math.floor(Math.random() * letras.length)];
    var numero3 = numeros[Math.floor(Math.random() * numeros.length)];

    var pass = letra1 + numero1 + letra2 + numero2 + letra3 + numero3;
    return pass;
}


//obtener los usuarios desde la base, almacenarlos en una funcion.
function ObtenerCurrentUser(email) {

    var currentUser = new Array();

    //obtener el current user
    for (var i = 0; i < Usuarios.length; i++) {

        if (Usuarios[i].Email == email) {

            currentUser.push(Usuarios[i])
        }
    }
    return currentUser;

}



//validar que el email realmente sea un email.
function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}


$("#btnRecoverPass").click(function () {

    //validar correo
    var email = $("#inputPass").val();


    if (validateEmail(email)) {
        $('#olvidoPass').modal('hide');

        Swal.fire({
            type: 'success',
            title: 'Correo enviado',
            confirmButtonText: 'Entendido'
        }).then((result) => {
            if (result.value) {

                //obtener el usuario que coincide con ese correo.
                var currentUser = ObtenerCurrentUser(email);

                //llenar los campos del formulario
                for (var i = 0; i < currentUser.length; i++) {

                    document.getElementById("txtCedula").defaultValue = currentUser[i].Cedula;
                    document.getElementById("txtNombre").defaultValue = currentUser[i].Nombre;
                    document.getElementById("txtApellidos").defaultValue = currentUser[i].Apellidos;
                    document.getElementById("txtProvincia").defaultValue = currentUser[i].Provincia;
                    document.getElementById("txtCanton").defaultValue = currentUser[i].Canton;
                    document.getElementById("txtDistrito").defaultValue = currentUser[i].Distrito;
                    document.getElementById("txtMapa").defaultValue = currentUser[i].Mapa;
                    document.getElementById("txtTelefono").defaultValue = currentUser[i].Telefono;

                    document.getElementById("txtEmail2").defaultValue = currentUser[i].Email;
                    document.getElementById("txtEmail2").disabled = true;

                    document.getElementById("txtRol").defaultValue = currentUser[i].Rol;
                    document.getElementById("txtIdPaypal").defaultValue = currentUser[i].IdPaypal;
                    document.getElementById("txtCodigoAsignado").defaultValue = currentUser[i].CodigoAsignado;
                    document.getElementById("txtCodigoVerificacion").defaultValue = currentUser[i].CodigoVerificacion;
                }

                //mostrar el modal para actualizar contrasena.
                $('#newPass').modal('show');
            }
        });
    }
    else {
        Swal.fire({
            type: 'error',
            title: 'No se pudo enviar el correo',
            text: "Verifique los datos",
            confirmButtonText: 'Entendido'
        });
    }
});



function recuperarPass() {

    this.service = 'usuario';
    this.ctrlActions = new ControlActions();


    this.Update = function () {

        //verificar coincidencia de contrasena temporal
        var pass = $("#tempPass").val();
        console.log(pass);

        if (document.getElementById("txtTempPass").value == pass) {

            var customerData = {};
            customerData = this.ctrlActions.GetDataForm('frmEdition');
            //Hace el post al create
            this.ctrlActions.PutToAPI(this.service, customerData);

        } else {
            Swal.fire({
                type: 'warning',
                title: 'La contraseña temporal no coincide',
                text: "Verifique los datos",
                confirmButtonText: 'Entendido'
            });
        }
    }
}



//ON DOCUMENT READY
$(document).ready(function () {

    inputPassTemp.defaultValue = generar_pass();

});