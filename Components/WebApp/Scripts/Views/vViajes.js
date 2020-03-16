
function vViajes() {

	this.tblViajesId = 'tbViaje';
	this.service = 'viaje';
	this.ctrlActions = new ControlActions();
    this.columns = "IdTransportista,NombreTransportista,TarifaBasica,KilometrosRecorridos,DescuentoEcologico,PagoTotal,Mapa,PuntoPartidaLatitud,PuntoPartidaLongitud,PuntoLlegadaLatitud,PuntoLlegadaLongitud";

	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblViajesId, false); 		
	}

	this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblViajesId, true);
	}

	this.Create = function () {
        var viajeData = {};
        viajeData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PostToAPI(this.service, viajeData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var viajeData = {};
        viajeData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PutToAPI(this.service, viajeData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

        var viajeData = {};
        viajeData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, viajeData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vviaje = new vViajes();
    vviaje.RetrieveAll();

});

