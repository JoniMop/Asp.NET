//asignar valores por defecto
function valoresXdefecto() {

    var hora = document.getElementById("txtBitFechaHora");
    var admin = document.getElementById("txtBitIdUser");

    if ((hora !== undefined && hora !== null) && (admin !== undefined && admin !== null)) {
        hora.defaultValue = Date.now();
        admin.defaultValue = "100101010";
    }
}


function vBitacora() {

    this.tblBitacoraId = 'tbBitacora';
    this.service = 'bitacora';
    this.ctrlActions = new ControlActions();
    this.columns = "FechaHora,DescripcionCRUD,IdUsuario";


    this.URL_API = "http://localhost:57056/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }


    this.PostToAPIBitacora = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            console.log("Se ha registrado el proceso en bitácora")
        })
            .fail(function (response) {
                var data = response.responseJSON;
                console.log(data);
            })
    };



    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblBitacoraId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblBitacoraId, true);
    }

    this.AutoCreate = function (service, user) {
        //Hora Actual
        FechaHoraGo = new Date().toISOString().slice(0, 19).replace('T', ' ');


        let bitData = {
            FechaHora: FechaHoraGo, //Formato "2019-12-17T14:48:58.4514541-06:00"
            DescripcionCRUD: service,
            IdUsuario: user
        };


        //Hace el post al create
        this.PostToAPIBitacora(this.service, bitData);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmBitacora', data);
    }
}



//ON DOCUMENT READY
$(document).ready(function () {

    valoresXdefecto()

    var vbitacora = new vBitacora();
    vbitacora.RetrieveAll();

});


