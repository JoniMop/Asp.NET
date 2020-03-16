
function vTransaccion() {

    this.tblTransaccionesId = 'tbTransaccion';
	this.service = 'transaccion';
	this.ctrlActions = new ControlActions();
    this.columns = "IdUsuario,Debito,Credito,Detalle,Fecha";

	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblTransaccionesId, false); 		
	}

	this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblTransaccionesId, true);
	}

	this.Create = function () {
        var transData = {};
        transData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PostToAPI(this.service, transData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

        var transData = {};
        transData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PutToAPI(this.service, transData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

        var transData = {};
        transData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, transData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
    }


    this.RedirigirPaypal = function () {
        window.location.href = "/Home/pagosPaypal";
    }

    this.RedirigirWallet = function () {
        window.location.href = "/Home/pagosWallet";
    }


}

//ON DOCUMENT READY
$(document).ready(function () {

   // var vtrans = new vTransaccion();
   // vtrans.RetrieveAll();

});

