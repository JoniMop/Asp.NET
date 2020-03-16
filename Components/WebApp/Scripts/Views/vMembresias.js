
function vMembresias() {

    //Inicializar el objeto Bitacora
    var vbita = new vBitacora();

	this.tblMembresiasId = 'tblMembresias';
	this.service = 'membresia';
	this.ctrlActions = new ControlActions();
    this.columns = "IdUsuario,MontoMembresiaAnual,Estado";

	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblMembresiasId, false); 		
	}

	this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblMembresiasId, true);
	}

	this.Create = function () {
		var membresiaData = {};
        membresiaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PostToAPI(this.service, membresiaData);
		//Refresca la tabla
		this.ReloadTable();
    }

    this.CreateAndMail = function () {
        var membresiaData = {};
        membresiaData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, membresiaData);
        //Refresca la tabla
        this.ReloadTable();

        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Creacion de la  Membresia", 100101010);


    }

	this.Update = function () {

        var membresiaData = {};
        membresiaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PutToAPI(this.service, membresiaData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

        var membresiaData = {};
        membresiaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, membresiaData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vmembresia = new vMembresias();
    vmembresia.RetrieveAll();

});

