//asignar valores por defecto a los campos escondidos
let cedulaRegistrada = sessionStorage.getItem('cedulaRegistrada');
let restRegistrado = sessionStorage.getItem('idRestaurante');


//generar codigo de verificacion
function codigo_verificacion() {

    var letras = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I');
    var numeros = new Array('1', '2', '3', '4', '5', '6', '7', '8', '9');

    var letra1 = letras[Math.floor(Math.random() * letras.length)];
    var numero1 = numeros[Math.floor(Math.random() * numeros.length)];
    var letra2 = letras[Math.floor(Math.random() * letras.length)];
    var numero2 = numeros[Math.floor(Math.random() * numeros.length)];
    var letra3 = letras[Math.floor(Math.random() * letras.length)];
    var numero3 = numeros[Math.floor(Math.random() * numeros.length)];

    var codigoVerif = letra1 + numero1 + letra2 + numero2 + letra3 + numero3;
    return codigoVerif;
}

//Inicializar el objeto Bitacora
var vbita = new vBitacora();

//funciones de CRUD cliente
function vComercio() {

    this.tblUsuariosId = 'tbUsuario';
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();

    this.URL_API = "http://localhost:57056/api/";


    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }


    this.PostToAPIComercio1 = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessageComercio1('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.PostToAPIComercio2 = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessageComercio2('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.PostToAPIComercio3 = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessageComercio3('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };



    this.RegistrarUsuario = function () {

        //valores x defecto
        document.getElementById("txtMapa").defaultValue = "mapa";
        document.getElementById("txtRol").defaultValue = "comercio";
        document.getElementById("txtCodigoAsignado").defaultValue = codigo_verificacion();
        document.getElementById("txtCodigoVerificacion").defaultValue = "0";

        var usuarioData = {};

        //obtener data
        usuarioData = this.ctrlActions.GetDataForm('frmUsuario');

        //hacer post
        this.PostToAPIComercio1('usuario', usuarioData);

        //guardar data cedula
        sessionStorage.setItem('cedulaRegistrada', document.getElementById("txtCedula").value);

        //bitacora
        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Registro de socio comercial", document.getElementById("txtCedula").value);
    }



    this.RegistrarRestaurante = function () {

        //valores x defecto
        document.getElementById("txtCategoriaTemp").defaultValue = document.getElementById("txtCategoria").value;
        document.getElementById("txtIdUsuarioRest").defaultValue = cedulaRegistrada;

        var restauranteData = {};

        //obtener data
        restauranteData = this.ctrlActions.GetDataForm('frmRestaurante');

        //Hace el post 
        this.PostToAPIComercio2('restaurante', restauranteData);

        //guardar data cedula juridica
        sessionStorage.setItem('idRestaurante', document.getElementById("txtCedulaJu").value);

        //bitacora
        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Registro de restaurante", cedulaRegistrada);
    }

    this.RegistrarImagenes = function () {

        //valores x defecto
        document.getElementById("txtlogo").defaultValue = document.getElementById("image_preview").src;
        document.getElementById("txtperfil").defaultValue = document.getElementById("image_preview2").src;
        document.getElementById("txtIdRest").defaultValue = restRegistrado;

        var imagenesData = {};

        //obtener data
        imagenesData = this.ctrlActions.GetDataForm('frmImagenes');

        //Hace el post
        this.PostToAPIComercio3('imagenRestaurante', imagenesData);

        //bitacora
        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Registro de imágenes por restaurante", cedulaRegistrada);
    }


    this.Update = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, customerData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, customerData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmUsuario', data);
    }
}


//ON DOCUMENT READY
$(document).ready(function () {


});


