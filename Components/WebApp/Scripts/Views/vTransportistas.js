let cedulaRegistrada = sessionStorage.getItem('cedulaRegistrada');


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
function vTransportistas() {

    this.tblUsuariosId = 'tbUsuario';
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();

    this.URL_API = "http://localhost:57056/api/";


    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }



    this.PostToAPITransportista1 = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessageTransportista1('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.PostToAPITransportista2 = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessageTransportista2('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };





    this.RegistrarTransportista = function () {

        document.getElementById("txtMapa").defaultValue = "mapa";
        document.getElementById("txtRol").defaultValue = "transportista";
        document.getElementById("txtCodigoAsignado").defaultValue = codigo_verificacion();
        document.getElementById("txtCodigoVerificacion").defaultValue = "0";

        var usuarioData = {};

        //obtener data
        usuarioData = this.ctrlActions.GetDataForm('frmUsuario');

        //Hace el post a los 2 create
        this.PostToAPITransportista1('usuario', usuarioData);

        //guardar data cedula
        sessionStorage.setItem('cedulaRegistrada', document.getElementById("txtCedula").value);

        //bitacora
        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Registro de transportista", document.getElementById("txtCedula").value);

    }

    this.RegistrarDocumentos = function () {

        //valores x defecto
        document.getElementById("txtIdUsuario").defaultValue = cedulaRegistrada;
        document.getElementById("txtMinisterio").defaultValue = "null";
        document.getElementById("txtLicenciaConducir").defaultValue = document.getElementById("doc_preview").href;


        var documentoData = {};

        //obtener data
        documentoData = this.ctrlActions.GetDataForm('frmDocumento');

        //Hace el post 
        this.PostToAPITransportista2('documento', documentoData);

        //bitacora
        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Registro de documentos transportista", cedulaRegistrada);
    }



    this.Create = function () {
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        console.log(customerData);
        this.ctrlActions.PostToAPI(this.service, customerData);
        //Refresca la tabla
       // this.ReloadTable();
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
        this.ctrlActions.BindFields('frmEdition', data);
    }
}
