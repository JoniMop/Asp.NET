
function vDocumentos() {

	this.tblDocumentosId = 'tblDocumentos';
	this.service = 'documento';
	this.ctrlActions = new ControlActions();
    this.columns = "IdUsuario,VehiculoEcologico,TipoVehiculo,LicenciaConducir,PermisoMinSalud";

	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblDocumentosId, false); 		
	}

	this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblDocumentosId, true);
	}

	this.Create = function () {
		var docsData = {};
        docsData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PostToAPI(this.service, docsData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

        var docsData = {};
        docsData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PutToAPI(this.service, docsData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

        var docsData = {};
        docsData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, docsData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vdocs = new vDocumentos();
    vdocs.RetrieveAll();

});

