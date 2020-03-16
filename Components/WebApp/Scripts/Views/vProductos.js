var ProdXRestaurante = [];

//obtener el path con el id del restaurante
var url = window.location.pathname;
let idRestaurante = url.substring(url.lastIndexOf('/') + 1);



//asignar valores por defecto a los campos escondidos
function valoresXdefecto() {
    document.getElementById("txtidRest").defaultValue = idRestaurante;
    document.getElementById("txtidRest2").defaultValue = idRestaurante;

    document.getElementById("txtCodigoProd2").disabled = true;
  
}

function vProductos() {

    //Inicializar el objeto Bitacora
    var vbita = new vBitacora();


    this.tblProductosId = 'tbProducto';
    this.service = 'producto';
    this.ctrlActions = new ControlActions();
    this.columns = "CodigoProducto,NombreProducto,DescripcionProducto,PrecioProducto,Descuento,IdRestaurante,Imagen";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblProductosId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblProductosId, true);
    }

    this.Create = function () {
        var productoData = {};
        productoData = this.ctrlActions.GetDataForm('frmCreate');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, productoData);

        //bitacora
        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Registro de producto", '100101010');
    }

    this.Update = function () {

        var productoData = {};
        productoData = this.ctrlActions.GetDataForm('frmUpdate');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, productoData);
        //Refresca la tabla
        this.ReloadTable();

        //bitacora
        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Actualización de producto", '100101010');

    }

    this.Delete = function () {

        var productoData = {};
        productoData = this.ctrlActions.GetDataForm('frmUpdate');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, productoData);
        //Refresca la tabla
        this.ReloadTable();

        //Ejecutar funcion de AutoCreate(["Descripcion"],[IdUsuario])
        vbita.AutoCreate("Eliminación de producto", document.getElementById("txtidRest").value);

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmUpdate', data);
    }


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
        editBtn.setAttribute("id", "UpdateProducto" + listaProdXRestaurante[i].CodigoProducto);
        editBtn.setAttribute("class", "cardbutton");
        var btnIcon = document.createElement("i");
        btnIcon.setAttribute("class", "fa fa-edit");

        //jerarquizar
        document.querySelector("#MenuContainer").appendChild(productCards);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(prodImg);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(prodName);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(prodPrecio);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(prodDesc);
        document.querySelector("#cardProduct" + listaProdXRestaurante[i].CodigoProducto).appendChild(editBtn);
        document.querySelector("#UpdateProducto" + listaProdXRestaurante[i].CodigoProducto).appendChild(btnIcon);

        //asignar funcion a botones
        $("#UpdateProducto" + listaProdXRestaurante[i].CodigoProducto).click(function () {

            //llenar el formulario
            let txtCodigoProd2 = document.querySelector("#txtCodigoProd2");
            let txtNombreProd2 = document.querySelector("#txtNombreProd2");
            let txtDescripcionProd2 = document.querySelector("#txtDescripcionProd2");
            let txtPrecio2 = document.querySelector("#txtPrecio2");
            let txtDescuento2 = document.querySelector("#txtDescuento2");
            let txtImg2 = document.querySelector("#txtImg2");
            let image_preview2 = document.querySelector("#image_preview2");

            txtCodigoProd2.value = listaProdXRestaurante[i].CodigoProducto;
            txtNombreProd2.value = listaProdXRestaurante[i].NombreProducto;
            txtDescripcionProd2.value = listaProdXRestaurante[i].DescripcionProducto;
            txtPrecio2.value = listaProdXRestaurante[i].PrecioProducto;
            txtDescuento2.value = listaProdXRestaurante[i].Descuento;
            txtImg2.value = listaProdXRestaurante[i].Imagen;
            image_preview2.src = listaProdXRestaurante[i].Imagen;

            //mostrar modal de update
            $('#ActualizarProducto').modal('show')
        });
    }


}







//ON DOCUMENT READY
$(document).ready(function () {

   
    valoresXdefecto();

    var vprod = new vProductos();
    ProdXRestaurante = vprod.ObtenerProductos(idRestaurante);

});
