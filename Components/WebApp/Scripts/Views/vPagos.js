
function vPagos() {

    this.RedirigirPaypal = function () {

        window.location.href = "/Home/pagosPaypal";
    }

    this.RedirigirWallet = function () {

        window.location.href = "/Home/pagosWallet";
    }

}