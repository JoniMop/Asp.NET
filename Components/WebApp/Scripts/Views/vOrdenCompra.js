 
function vOrdenCompra() {

    this.tblOrdenCompraId = 'tbOrdenCompra';
	this.service = 'ordenCompra';
	this.ctrlActions = new ControlActions();
    this.columns = "IdRestaurante,NombreComercial,IdCliente,NombreCliente,IdViaje,Subtotal,IVA,Total,CodigoQR,CalificacionRestaurante,CalificacionTransporte,EstadoOrden,IdProducto,Reclamo,RespuestaReclamo";

	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblOrdenCompraId, false); 		
	}

	this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblOrdenCompraId, true);
	}

	this.Create = function () {
		var ordenData = {};
        ordenData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PostToAPI(this.service, ordenData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

        var ordenData = {};
        ordenData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PutToAPI(this.service, ordenData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

        var ordenData = {};
        ordenData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, ordenData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vorden = new vOrdenCompra();
    vorden.RetrieveAll();

});

