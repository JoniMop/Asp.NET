//en el index:
if (window.location.pathname == "/Home/Index") {

    //limpiar el session storage cada que regresa al inicio.
    sessionStorage.setItem('categoria', '');


    //hamburguesas
    document.getElementById('Hamburguesas').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'Hamburguesas');
        window.location.href = '/Home/RestaurantesXCategoria';

    });

    //Pizzas
    document.getElementById('Pizzas').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'Pizzas');
        window.location.href = '/Home/RestaurantesXCategoria';
    });

    //Pollo
    document.getElementById('Pollo').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'Pollo');
        window.location.href = '/Home/RestaurantesXCategoria';
    });

    //Asiatica
    document.getElementById('Asiatica').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'Asiatica');
        window.location.href = '/Home/RestaurantesXCategoria';
    });

    //Nacional
    document.getElementById('Nacional').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'Nacional');
        window.location.href = '/Home/RestaurantesXCategoria';
    });

    //India
    document.getElementById('India').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'India');
        window.location.href = '/Home/RestaurantesXCategoria';
    });

    //Saludable
    document.getElementById('Saludable').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'Saludable');
        window.location.href = '/Home/RestaurantesXCategoria';
    });

    //Reposteria
    document.getElementById('Reposteria').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'Reposteria');
        window.location.href = '/Home/RestaurantesXCategoria';
    });

    //Postres
    document.getElementById('Postres').addEventListener("click", function () {
        sessionStorage.setItem('categoria', 'Postres');
        window.location.href = '/Home/RestaurantesXCategoria';
    });
}


//en el de categorias
if (window.location.pathname == "/Home/RestaurantesXCategoria") {

    sessionStorage.getItem('categoria');

    switch (categoria) {

        case 'Hamburguesas':
            document.getElementById('Hamburguesas').classList.remove('hide');
            document.getElementById('Hamburguesas').classList.add('show');
            break;

        case 'Pizzas':
            document.getElementById('Pizzas').classList.remove('hide');
            document.getElementById('Pizzas').classList.add('show');
            break;

        case 'Pollo':
            document.getElementById('Pollo').classList.add('show');
            document.getElementById('Pollo').classList.remove('hide');
            break;

        case 'Asiatica':
            document.getElementById('Asiatica').classList.add('show');
            document.getElementById('Asiatica').classList.remove('hide');
            break;

        case 'Nacional':
            document.getElementById('Nacional').classList.add('show');
            document.getElementById('Nacional').classList.remove('hide');
            break;

        case 'India':
            document.getElementById('India').classList.add('show');
            document.getElementById('India').classList.remove('hide');
            break;

        case 'Saludable':
            document.getElementById('Saludable').classList.add('show');
            document.getElementById('Saludable').classList.remove('hide');
            break;

        case 'Reposteria':
            document.getElementById('Reposteria').classList.add('show');
            document.getElementById('Reposteria').classList.remove('hide');
            break;

        case 'Postres':
            document.getElementById('Postres').classList.add('show');
            document.getElementById('Postres').classList.remove('hide');
            break;
    }


}
   