//obtener el id del restaurante basado en la cedula del usuario
var url = window.location.pathname;
let idUser = url.substring(url.lastIndexOf('/') + 1);

let Restaurante = [];
let idRestaurante2 = "";


function ObtenerRestaurantes() {

    var return_data = new Array();
    var rest = new Array();


    $.get("http://localhost:57056/api/restaurante", function (restaurantes) {

        //hacer un array de objetos
        for (var i = 0; i < restaurantes[Object.keys(restaurantes)[1]].length; i++) {

            return_data.push(restaurantes[Object.keys(restaurantes)[1]][i]);
        }

        for (var i = 0; i < return_data.length; i++) {

            if (return_data[i].IdEncargado == idUser) {
                rest.push(return_data[i]);
            }
        }
      
    });
    return rest;
}

function vDashboardComercio() {

    this.miRestaurante = function () {

        //obtener cedula juridica basada en restaurante
        for (var i = 0; i < Restaurante.length; i++) {
            idRestaurante2 = Restaurante[i].CedulaJuridica;
        }
        console.log(idRestaurante2);

        window.location.href = "/Home/RestauranteEdit/" + idRestaurante2;


    }


}




//ON DOCUMENT READY
$(document).ready(function () {

    Restaurante = ObtenerRestaurantes();
});