
function vFacturas() {

	this.tblFacturasId = 'tblFacturas';
	this.service = 'factura';
	this.ctrlActions = new ControlActions();
    this.columns = "FacturaPDF,IdUsuario";

	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblFacturasId, false); 		
	}

	this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblFacturasId, true);
	}

	this.Create = function () {
		var facturaData = {};
        facturaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PostToAPI(this.service, facturaData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var usuariosData = {};
        facturaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PutToAPI(this.service, facturaData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

        var facturaData = {};
        facturaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, facturaData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vfactura = new vFacturas();
    vfactura.RetrieveAll();

});

