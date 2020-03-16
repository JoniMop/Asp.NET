var Restaurantes = [];
var ImgRestaurantes = [];


function vRestaurantes() {


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



//funcion para generar los cards de cada restaurante.
function generarCards() {

    $("#cardsRow").empty(); 

    var listaRestaurante = Restaurantes;
    var listaImagenesRestaurante = ImgRestaurantes;

    var cardDeck = document.createElement("div");
    cardDeck.setAttribute("id", "card-deck1");
    cardDeck.setAttribute("class", "card-deck");



    for (let i = 0; i < listaRestaurante.length; i++) {

        //crear cards
        var imgFluid = document.createElement("div");
        imgFluid.setAttribute("id", "imgFluid" + listaRestaurante[i].CedulaJuridica);
        imgFluid.setAttribute("class", "col-sm-4");
            
        var innercard = document.createElement("div");
        innercard.setAttribute("id", "innercard" + listaRestaurante[i].CedulaJuridica);
        innercard.setAttribute("class", "card my-4");

        var imgLink = document.createElement("a");
        imgLink.setAttribute("id", "imgLink" + listaRestaurante[i].CedulaJuridica);
        imgLink.setAttribute("href", "/Home/RestauranteCliente/" + listaRestaurante[i].CedulaJuridica); //AQUI ES REST CLIENTE, cambiar despues de hacer debug

        var imgRest = document.createElement("img");
        imgRest.setAttribute("id", "imgRest" + listaRestaurante[i].CedulaJuridica);


            if (listaImagenesRestaurante[i].IdRestaurante == listaRestaurante[i].CedulaJuridica) {
                imgRest.setAttribute("src", listaImagenesRestaurante[i].Logo); //aqui va la imagen de cloudinary del logo.
                imgRest.setAttribute("style", "width: 195px; padding: 10px;");
            }
        

        var bodyCard = document.createElement("div");
        bodyCard.setAttribute("id", "body" + listaRestaurante[i].CedulaJuridica);
        bodyCard.setAttribute("class", "card-body");

        var restName = document.createElement("h4");
        restName.setAttribute("id", "nombreRest" + listaRestaurante[i].CedulaJuridica);
        restName.setAttribute("class", "card-title");
        restName.innerHTML = listaRestaurante[i].NombreComercial; //aqui va el nombre del restaurante.

        //jerarquizar
        document.querySelector("#cardsRow").appendChild(imgFluid);
        document.querySelector("#imgFluid" + listaRestaurante[i].CedulaJuridica).appendChild(innercard);
        document.querySelector("#innercard" + listaRestaurante[i].CedulaJuridica).appendChild(imgLink);
        document.querySelector("#imgLink" + listaRestaurante[i].CedulaJuridica).appendChild(imgRest);
        document.querySelector("#innercard" + listaRestaurante[i].CedulaJuridica).appendChild(bodyCard);
        document.querySelector("#body" + listaRestaurante[i].CedulaJuridica).appendChild(restName);
        }
}


 
//ON DOCUMENT READY
$(document).ready(function () {

    var vrest = new vRestaurantes();
    vrest.RetrieveAll();

    Restaurantes = vrest.ObtenerRestaurantes();
    ImgRestaurantes = vrest.ObtenerImagenRestaurante();
    console.log(ImgRestaurantes)

});

