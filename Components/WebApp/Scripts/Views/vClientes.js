//asignar valores por defecto a los campos escondidos
function valoresXdefecto() {

    document.getElementById("txtMapa").defaultValue = "mapa";
    document.getElementById("txtRol").defaultValue = "cliente";
    document.getElementById("txtCodigoAsignado").defaultValue = codigo_verificacion();
    document.getElementById("txtCodigoVerificacion").defaultValue = "0";
}


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



//funciones de CRUD cliente
function vClientes() {

    //Inicializar el objeto Bitacora
    var vbita = new vBitacora();

    this.tblUsuariosId = 'tbUsuario';
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,Apellidos,Provincia,Canton,Distrito,Mapa,Telefono,Email,Contrasena,Rol,IdPaypal,CodigoAsignado,CodigoVerificacion";
    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsuariosId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsuariosId, true);
    }

    this.Create = function () {
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, customerData);
        //Refresca la tabla
       // this.ReloadTable();

        //bitacora
        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Registro de cliente", document.getElementById("txtCedula").value);
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


//ON DOCUMENT READY
$(document).ready(function () {

    valoresXdefecto();

   // var vcliente = new vCliente();
    //vcliente.RetrieveAll();

});


