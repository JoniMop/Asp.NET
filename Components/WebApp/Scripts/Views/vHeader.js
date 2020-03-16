function vHeader() {

    //header de clientes

    this.Dashboard = function () {
        window.location.href = "/Home/dashboardCliente";
    }

    this.Wallet = function () {
        
        window.location.href = "/Home/RegistroWallet";
    }

    this.Reclamos = function () {
        window.location.href = "/Home/reclamos";
    }

    this.Ordenes = function () {
        $('#carrito').modal('show');
    }


    //header de comercio

    this.DashboardComercio = function () {
        window.location.href = "/Home/dashboardComercio";
    }

    //header admin
    this.dashboardAdmin = function () {
        window.location.href = "/Home/dashboardAdmin";
    }

    this.Bitacora = function () {
        window.location.href = "/Home/Bitacora";
    }

    this.Pagos = function () {
        $('#pagos').modal('show');
    }

    //header transportista
    this.DashboardTransportista = function () {
        window.location.href = "/Home/dashboardTransportista";
    }

    this.Viajes = function () {
        $('#viajes').modal('show');    }

    this.DashboardTransportista = function () {
        $('#pagos').modal('show');
    }
}

