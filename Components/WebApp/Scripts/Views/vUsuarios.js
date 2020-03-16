function vUsuarios() {

    //Inicializar el objeto Bitacora

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


//ON DOCUMENT READY
$(document).ready(function () {

    var vusuario = new vUsuarios();
    vusuario.RetrieveAll();
});
