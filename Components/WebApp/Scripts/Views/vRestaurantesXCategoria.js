var Restaurantes = [];
var ImgRestaurantes = [];
let categoria = sessionStorage.getItem('categoria');



function vRestaurantesXCategoria() {


    this.tblRestaurantesId = 'tbRestaurante';
	this.service = 'restaurante';
	this.ctrlActions = new ControlActions();
    this.columns = "CedulaJuridica,NombreComercial,IdEncargado,HorarioOpen,HorarioClose,Categoria";

	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblRestaurantesId, false); 		
	}

	this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblRestaurantesId, true);
	}

	this.Create = function () {
		var restData = {};
        restData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PostToAPI(this.service, restData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

        var restData = {};
        restData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.PutToAPI(this.service, restData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

        var restData = {};
        restData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, restData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
    }

    //obtener los restaurantes desde la base, almacenarlos en una funcion.
    this.ObtenerRestaurantes = function () {

        var return_data = new Array();

        $.get("http://localhost:57056/api/restaurante", function (restaurantes) {

            //hacer un array de objetos
            for (var i = 0; i < restaurantes[Object.keys(restaurantes)[1]].length; i++) {

                return_data.push(restaurantes[Object.keys(restaurantes)[1]][i]);
            }
        });
        return return_data;


    }

    //obtener las imagenes de restaurante desde la base, almacenarlos en una funcion.
    this.ObtenerImagenRestaurante = function () {

        var return_data = new Array();

        $.get("http://localhost:57056/api/imagenRestaurante", function (imgRestaurantes) {

            //hacer un array de objetos
            for (var i = 0; i < imgRestaurantes[Object.keys(imgRestaurantes)[1]].length; i++) {

                return_data.push(imgRestaurantes[Object.keys(imgRestaurantes)[1]][i]);
            }
        });
        return return_data;
    }
}




//funcion para generar los cards de cada producto.
function generarCards() {

    $("#cardsRow").empty();

    var restXcategoria = new Array();
    var imgXcategoria = new Array();


    var cardDeck = document.createElement("div");
    cardDeck.setAttribute("id", "card-deck1");
    cardDeck.setAttribute("class", "card-deck");


    //obtener rest x categoria
    for (let i = 0; i < Restaurantes.length; i++) {

        if (Restaurantes[i].Categoria == categoria && Restaurantes[i].CedulaJuridica == ImgRestaurantes[i].IdRestaurante) {
            restXcategoria.push(Restaurantes[i]);
            imgXcategoria.push(ImgRestaurantes[i]);
        }
    }

    for (let i = 0; i < restXcategoria.length; i++) {

        //crear cards
        var imgFluid = document.createElement("div");
        imgFluid.setAttribute("id", "imgFluid" + restXcategoria[i].CedulaJuridica);
        imgFluid.setAttribute("class", "col-sm-4");

        var innercard = document.createElement("div");
        innercard.setAttribute("id", "innercard" + restXcategoria[i].CedulaJuridica);
        innercard.setAttribute("class", "card my-4");

        var imgLink = document.createElement("a");
        imgLink.setAttribute("id", "imgLink" + restXcategoria[i].CedulaJuridica);
        imgLink.setAttribute("href", "/Home/RestauranteCliente/" + restXcategoria[i].CedulaJuridica); //AQUI ES REST CLIENTE, cambiar despues de hacer debug

        var imgRest = document.createElement("img");
        imgRest.setAttribute("id", "imgRest" + restXcategoria[i].CedulaJuridica);

        if (imgXcategoria[i].IdRestaurante == restXcategoria[i].CedulaJuridica) {
            imgRest.setAttribute("src", imgXcategoria[i].Logo); //aqui va la imagen de cloudinary del logo.
            imgRest.setAttribute("style", "width: 195px; padding: 10px;");
        }

        var bodyCard = document.createElement("div");
        bodyCard.setAttribute("id", "body" + restXcategoria[i].CedulaJuridica);
        bodyCard.setAttribute("class", "card-body");

        var restName = document.createElement("h4");
        restName.setAttribute("id", "nombreRest" + restXcategoria[i].CedulaJuridica);
        restName.setAttribute("class", "card-title");
        restName.innerHTML = restXcategoria[i].NombreComercial; //aqui va el nombre del restaurante.

        //jerarquizar
        document.querySelector("#cardsRow").appendChild(imgFluid);
        document.querySelector("#imgFluid" + restXcategoria[i].CedulaJuridica).appendChild(innercard);
        document.querySelector("#innercard" + restXcategoria[i].CedulaJuridica).appendChild(imgLink);
        document.querySelector("#imgLink" + restXcategoria[i].CedulaJuridica).appendChild(imgRest);
        document.querySelector("#innercard" + restXcategoria[i].CedulaJuridica).appendChild(bodyCard);
        document.querySelector("#body" + restXcategoria[i].CedulaJuridica).appendChild(restName);
    }
}





//ON DOCUMENT READY
$(document).ready(function () {

    var vrest = new vRestaurantesXCategoria();
    vrest.RetrieveAll();

    Restaurantes = vrest.ObtenerRestaurantes();
    ImgRestaurantes = vrest.ObtenerImagenRestaurante();
});

