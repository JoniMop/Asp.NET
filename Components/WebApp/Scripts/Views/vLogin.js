/*-------------------------------------LOGIN-------------------------------------------*/
var Usuarios = [];

function vLogin() {

    this.tblUsuariosId = 'tbUsuario';


    //obtener los usuarios desde la base, almacenarlos en una funcion.
    this.ObtenerInfo = function () {

        var return_data = new Array();

        $.get("http://localhost:57056/api/usuario", function (usuarios) {

            //hacer un array de objetos
            for (var i = 0; i < usuarios[Object.keys(usuarios)[1]].length; i++) {

                return_data.push(usuarios[Object.keys(usuarios)[1]][i]);
            }
        });
        return return_data;
    }

    /*-----------------------------------------------------------------------*/

    //iniciar sesion
    this.iniciarSesion = function () {
        var sCorreo = '';
        var sContrasena = '';
        var bAcceso = false;
        var bActivo = false;

        sCorreo = document.querySelector('#txtCorreoModal').value;
        sContrasena = document.querySelector('#txtContrasenaModal').value;

        bAcceso = this.validadCredenciales(sCorreo, sContrasena);

        //verificar cuenta activa
        bActivo = this.validarCuentaActiva();
        console.log(bActivo);

        if (bActivo == true) {
            this.ingresar();

        } else {
            $('#iniSesion').modal('hide');
            $('#codigoVerif').modal('show');
        }


    }

    //funcion para redirigir por roles
    this.ingresar = function () {

        'use strict';
        let conectado = sessionStorage.getItem('estadoSesion');
        var rol = sessionStorage.getItem('rolActivo');
        var usuarioActivo = sessionStorage.getItem('usuarioActivo');
        var idUsuario = sessionStorage.getItem('idUsuario');



        if (conectado) {

            switch (rol) {

                case 'admin':
                    for (var i = 0; i < Usuarios.length; i++) {

                        //asociar la cedula del usuario a su respectivo dashboard
                        if (Usuarios[i].Cedula == idUsuario) {
                            window.location.href = "/Home/dashboardAdmin/" + Usuarios[i].Cedula;
                        }
                    }
                    break;

                case 'cliente':
                    for (var i = 0; i < Usuarios.length; i++) {

                        //asociar la cedula del usuario a su respectivo dashboard
                        if (Usuarios[i].Cedula == idUsuario) {
                            window.location.href = "/Home/dashboardCliente/" + Usuarios[i].Cedula;
                        }
                    }
                    break;

                case 'comercio':
                    for (var i = 0; i < Usuarios.length; i++) {

                        //asociar la cedula del usuario a su respectivo dashboard
                        if (Usuarios[i].Cedula == idUsuario) {
                            window.location.href = "/Home/dashboardComercio/" + Usuarios[i].Cedula;
                        }
                    }
                    break;

                case 'transportista':
                    for (var i = 0; i < Usuarios.length; i++) {

                        //asociar la cedula del usuario a su respectivo dashboard
                        if (Usuarios[i].Cedula == idUsuario) {
                            window.location.href = "/Home/dashboardTransportista/" + Usuarios[i].Cedula;
                        }
                    }
                    break;

                default:
                    break;
            }
        }
    }


    //validar correo y contrasena
    this.validadCredenciales = function (pCorreo, pContrasena) {

        var bAcceso = false;
        var listaUsuarios = Usuarios;

        //si los formularios estan vacios.
        if (pCorreo == '' || pContrasena == '') {
            Swal.fire({
                type: 'warning',
                title: 'Datos Incompletos',
                text: "Por favor complete todos los datos",
                confirmButtonText: 'Entendido'
            });
        }
        else {

            for (var i = 0; i < listaUsuarios.length; i++) {

                //si los datos estan bien:
                if (pCorreo == listaUsuarios[i].Email && pContrasena == listaUsuarios[i].Contrasena) {

                    //obtener codigo asignado y verificacion
                    sessionStorage.setItem('codigoAsignado', listaUsuarios[i].CodigoAsignado);
                    sessionStorage.setItem('codigoVerificacion', listaUsuarios[i].CodigoVerificacion);


                    bAcceso = true;
                    //obtener los otros datos
                    sessionStorage.setItem('estadoSesion', 'conectado');
                    sessionStorage.setItem('idUsuario', listaUsuarios[i].Cedula);
                    sessionStorage.setItem('usuarioActivo', listaUsuarios[i].Nombre + ' ' + listaUsuarios[i].Apellidos);
                    sessionStorage.setItem('rolActivo', listaUsuarios[i].Rol);

                }
            }
            //si los datos no coinciden
            if (bAcceso == false) {
                Swal.fire({
                    type: 'warning',
                    title: 'Datos Incorrectos',
                    text: "El correo o la contraseña no coinciden",
                    confirmButtonText: 'Entendido'
                });
            }

            return bAcceso;
        }
    }


    this.validarCuentaActiva = function () {

        var bCuentaActiva = false;

        let codigoAsignado = sessionStorage.getItem('codigoAsignado');
        let codigoVerificacion = sessionStorage.getItem('codigoVerificacion');


        //si el codigo verificacion es 0 (usuario no activo)
        if (codigoAsignado != codigoVerificacion) {

            bCuentaActiva = false;

        } else { //el usuario esta activo
            bCuentaActiva = true;
            return bCuentaActiva;
        }
        return bCuentaActiva;

    }



    //===============================activar cuenta full=======================================//
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();
    this.URL_API = "http://localhost:57056/api/";
    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.PutToAPIActivar = function (service, data) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions2 = new ControlActions();
            ctrlActions2.ShowMessageActivar('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };


    this.Update = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition2');
        //Hace el post al create
        this.PutToAPIActivar(this.service, customerData);
    }


    //funcion para activar cuenta
    this.activarCuenta = function () {

        let codigoAsignado2 = sessionStorage.getItem('codigoAsignado');
        console.log(codigoAsignado2);

        var listaUsuarios = Usuarios;

        if (document.getElementById("txtCodigoVerificacion2").value == codigoAsignado2) {

            console.log(document.getElementById("txtCodigoVerificacion2").value)

            //llenar todos los datos del formulario
            for (var i = 0; i < listaUsuarios.length; i++) {

                //si los datos estan bien:
                if (listaUsuarios[i].CodigoAsignado == codigoAsignado2) {

                    document.getElementById("txtCedula2").defaultValue = listaUsuarios[i].Cedula;
                    document.getElementById("txtNombre2").defaultValue = listaUsuarios[i].Nombre;
                    document.getElementById("txtApellidos2").defaultValue = listaUsuarios[i].Apellidos;
                    document.getElementById("txtProvincia2").defaultValue = listaUsuarios[i].Provincia;
                    document.getElementById("txtCanton2").defaultValue = listaUsuarios[i].Canton;
                    document.getElementById("txtDistrito2").defaultValue = listaUsuarios[i].Distrito;
                    document.getElementById("txtMapa2").defaultValue = listaUsuarios[i].Mapa;
                    document.getElementById("txtTelefono2").defaultValue = listaUsuarios[i].Telefono;
                    document.getElementById("txtEmail3").defaultValue = listaUsuarios[i].Email;
                    document.getElementById("txtPass2").defaultValue = listaUsuarios[i].Contrasena;
                    document.getElementById("txtRol2").defaultValue = listaUsuarios[i].Rol;
                    document.getElementById("txtIdPaypal2").defaultValue = listaUsuarios[i].IdPaypal;
                    document.getElementById("txtCodigoAsignado2").defaultValue = listaUsuarios[i].CodigoAsignado;
                    document.getElementById("txtCodigoVerificacion2").value;

                    this.Update();
                    $('#codigoVerif').modal('hide');

                    //limpiar los datos del storage para prevenir que se inicie sesion sin haber ingresado datos
                    sessionStorage.clear();
                }
            }
        } else { //si el codigo escrito no coincide.
                Swal.fire({
                    type: 'warning',
                    title: 'No se pudo activar cuenta',
                    text: "Verifique que el código coincida",
                    confirmButtonText: 'Ok'
                });  
        }
    }
}


//ON DOCUMENT READY
$(document).ready(function () {

    vlog = new vLogin();
    Usuarios = vlog.ObtenerInfo();
});