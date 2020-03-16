
function vReclamos() {

	this.tbReclamoId = 'tbOrdenCompra';
	this.service = 'ordenCompra';
	this.ctrlActions = new ControlActions();
    this.columns = "Reclamo,RespuestaReclamo";

	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tbReclamoId, false); 		
	}

	this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tbReclamoId, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vreclamo = new vReclamos();
    vreclamo.RetrieveAll();

});

