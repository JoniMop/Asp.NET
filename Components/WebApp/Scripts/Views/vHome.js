
function vHome() {

    this.TodosLosRest = function () {
        window.location.href = "/Home/TodosLosRestaurantes";
    }

    this.FormTransportista = function () {
        window.location.href = "/Home/FormTransportistaParte1";
    }

    this.FormComercio = function () {
        window.location.href = "/Home/FormComercioParte1";
    }

    this.RegCliente = function () {
        window.location.href = "/Home/FormCliente";
    }


    this.OlvidoPass = function () {
        $('#iniSesion').on('hidden.bs.modal', function () {
            // Load up a new modal...
            $('#olvidoPass').modal('show')
        })    }


}