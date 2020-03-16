//obtener la info del restaurante actual.

var Restaurantes = [];


function vRestauranteInfo() {

    //obtener las imagenes de perfil restaurante desde la base X ID, almacenarlos en una funcion.
    this.ObtenerImagenRestaurantePorId = function () {

        var return_data = new Array();

        $.get("http://localhost:57056/api/imagenRestaurante", function (imgRestaurantes) {

            //hacer un array de objetos
            for (var i = 0; i < imgRestaurantes[Object.keys(imgRestaurantes)[1]].length; i++) {

                return_data.push(imgRestaurantes[Object.keys(imgRestaurantes)[1]][i]);
            }


            for (var i = 0; i < return_data.length; i++) {

                if (return_data[i].IdRestaurante == idRestaurante) {

                    //asignar perfil a restaurante
                    let perfilImg = document.querySelector("#profImg");
                    perfilImg.setAttribute("src", return_data[i].Perfil); //aqui va la imagen de cloudinary del perfil.
                }
            }
        });
    }


    this.nombreRestaurante = function(){

        var return_data = new Array();
        let restNameHolder = document.querySelector("#nombreComercial");

        $.get("http://localhost:57056/api/restaurante", function (restaurantes) {

            //hacer un array de objetos
            for (var i = 0; i < restaurantes[Object.keys(restaurantes)[1]].length; i++) {

                return_data.push(restaurantes[Object.keys(restaurantes)[1]][i]);
            }

            for (var i = 0; i < return_data.length; i++) {

                if (return_data[i].CedulaJuridica == idRestaurante) {



                    console.log(return_data[i].NombreComercial);

                    //asignar nombre a restaurante
                    restNameHolder.innerHTML = "Bienvenido a " + return_data[i].NombreComercial; //aqui va el nombre del rest.
                }
            }
        });
    }
}


//ON DOCUMENT READY
$(document).ready(function () {

    vrest = new vRestauranteInfo();
    vrest.ObtenerImagenRestaurantePorId();
    vrest.nombreRestaurante();

});

