/*
 * esto se pone en todas las paginas y RESTRINGE el acceso a exclusivamente los usuarios con sesion iniciada.
 * Restaurantes x categoria y todos los restaurantes no tienen restricciones de acceso.
 *
 * */

let estadoSesion = sessionStorage.getItem('estadoSesion');
let rol = sessionStorage.getItem('rolActivo');
var nombreUsuario = sessionStorage.getItem('usuarioActivo');

if (estadoSesion == 'conectado') {
    document.getElementById('datosUsuario').innerHTML = '¡Bienvenid@: ' + ' ' + nombreUsuario + '!';
  

    //esconder todos los header x defecto
    if (window.location.pathname.indexOf("/restauranteCliente/") || window.location.pathname == "/Home/Index" ||
        window.location.pathname == "/Home/RestaurantesXCategoria" || window.location.pathname == "/Home/TodosLosRestaurantes") {

        document.getElementById('menuDefault').classList.add('hide');
        document.getElementById('menuComercio').classList.add('hide');
        document.getElementById('menuTransportista').classList.add('hide');
        document.getElementById('menuAdmin').classList.add('hide');
        document.getElementById('menuCliente').classList.add('hide');
    }
        //headers por rol
        if (rol == 'admin' &&
            (window.location.pathname.indexOf("/restauranteCliente") || window.location.pathname == "/Home/Index" ||
             window.location.pathname == "/Home/RestaurantesXCategoria" || window.location.pathname == "/Home/TodosLosRestaurantes")) {

            document.getElementById('menuAdmin').classList.add('show');
            document.getElementById('menuAdmin').classList.add('menuAdminFix');   

        }
    

        else if (rol == 'cliente' &&
            (window.location.pathname.indexOf("/restauranteCliente") || window.location.pathname == "/Home/Index" ||
            window.location.pathname == "/Home/RestaurantesXCategoria" || window.location.pathname == "/Home/TodosLosRestaurantes")) {

            document.getElementById('menuCliente').classList.add('show');
        }

        else if (rol == 'comercio' &&
            (window.location.pathname.indexOf("/restauranteCliente") || window.location.pathname == "/Home/Index" ||
            window.location.pathname == "/Home/RestaurantesXCategoria" ||window.location.pathname == "/Home/TodosLosRestaurantes")) {

            document.getElementById('menuComercio').classList.add('show');
            document.getElementById('menuComercio').classList.add('menuComercioFix');   


        }

        else if (rol == 'transportista' &&
            (window.location.pathname.indexOf("/restauranteCliente") || window.location.pathname == "/Home/Index" ||
             window.location.pathname == "/Home/RestaurantesXCategoria" || window.location.pathname == "/Home/TodosLosRestaurantes")) {

            document.getElementById('menuTransportista').classList.add('show');
            document.getElementById('menuTransportista').classList.add('menuTransportistaFix');   


        }
    }


    else {
        //paginas con acceso libre

    if (window.location.pathname.indexOf("/restauranteCliente")||
            window.location.pathname == "/Home/RestaurantesXCategoria" ||
            window.location.pathname == "/Home/Index" ||
            window.location.pathname == "/Home/TodosLosRestaurantes") {

            //no restringe, mantiene el header de inicio de sesion:
            document.getElementById('menuDefault').classList.add('show');
            document.getElementById('menuComercio').classList.add('hide');
            document.getElementById('menuTransportista').classList.add('hide');
            document.getElementById('menuAdmin').classList.add('hide');
            document.getElementById('menuCliente').classList.add('hide');
        }

        else { //paginas con acceso restringido
           //window.location.href = "/Home/Index";
        }
    }



window.onload = function () {

    //log out
    document.getElementById("logout").addEventListener("click", function () {
        sessionStorage.clear();
        window.location.href = "/Home/Index";
    });


    if (window.location.pathname.indexOf("/restauranteCliente") || window.location.pathname == "/Home/Index" ||
        window.location.pathname == "/Home/RestaurantesXCategoria" || window.location.pathname == "/Home/TodosLosRestaurantes") {

        document.getElementById("logoutCom").addEventListener("click", function () {
            sessionStorage.clear();
            window.location.href = "/Home/Index";
        });

        document.getElementById("logoutTrans").addEventListener("click", function () {
            sessionStorage.clear();
            window.location.href = "/Home/Index";
        });

        document.getElementById("logoutAdmin").addEventListener("click", function () {
            sessionStorage.clear();
            window.location.href = "/Home/Index";
        });

    }
}