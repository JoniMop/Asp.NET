var ProdXRestaurante = [];

//obtener el path con el id del restaurante
var url = window.location.pathname;
let idRestaurante = url.substring(url.lastIndexOf('/') + 1);



function vProductos() {
    //obtener los productos desde la base, (SOLO LOS DE UN RESTAURANTE POR ID) almacenarlos en una funcion.
    this.ObtenerProductos = function (id) {

        var return_data = new Array();
        var productosXrest = new Array();

        $.get("http://localhost:57056/api/producto", function (productos) {

            //hacer un array de objetos
            for (var i = 0; i < productos[Object.keys(productos)[1]].length; i++) {

                return_data.push(productos[Object.keys(productos)[1]][i]);
            }

            for (var i = 0; i < return_data.length; i++) {

                if (return_data[i].IdRestaurante == id) {

                    productosXrest.push(return_data[i]);
                }
            }
        });
        return productosXrest;

    }
}
 

//funcion para generar los cards de cada producto.
function generarCards() {

    $("#MenuContainer").empty(); 

    var listaProdXRestaurante = ProdXRestaurante;

    for (let i = 0; i < listaProdXRestaurante.length; i++) {

        var productCards = document.createElement("div");
        productCards.setAttribute("id", "cardProduct" + listaProdXRestaurante[i].CodigoProducto);
        productCards.setAttribute("class", "card cardProduct");
        var prodImg = document.createElement("img");
        prodImg.setAttribute("src", listaProdXRestaurante[i].Imagen); //aqui va la imagen de cloudinary del producto.
        prodImg.setAttribute("style", "width: 100%");
        prodImg.setAttribute("class", "prodImg");
        var prodName = document.createElement("h3");
        prodName.innerHTML = listaProdXRestaurante[i].NombreProducto; //aqui va el nombre del producto.
        var prodPrecio = document.createElement("p");
        prodPrecio.innerHTML = listaProdXRestaurante[i].PrecioProducto; //aqui va el nombre del producto.
        var prodDesc = document.createElement("p");
        prodDesc.innerHTML = listaProdXRestaurante[i].DescripcionProducto; //aqui va descripcion del producto.
        var editBtn = document.createElement("button");
        editBtn.setAttribute("id", "AddtoCar" + listaProdXRestaurante[i].CodigoProducto);
        editBtn.setAttribute("class", "cardbutton");
        var btnIcon = document.createElement("i");
        btnIcon.setAttribute("class", "fa fa-plus-square");

        //jerarquizar
        document.querySelector("#MenuContainer").appendChild(productCards);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(prodImg);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(prodName);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(prodPrecio);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(prodDesc);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(editBtn);
        document.querySelector("#AddtoCar" + listaProdXRestaurante[i].CodigoProducto).appendChild(btnIcon);

        //asignar funcion a botones
        $("#AddtoCar" + listaProdXRestaurante[i].CodigoProducto).click(function () {
            Swal.fire({
                type: 'info',
                title: 'Producto agregado al carrito imaginario :(',
                confirmButtonText: 'Ok'
            });
        });
    }
}





//ON DOCUMENT READY
$(document).ready(function () {

    var vprod = new vProductos();
    ProdXRestaurante = vprod.ObtenerProductos(idRestaurante);
});
