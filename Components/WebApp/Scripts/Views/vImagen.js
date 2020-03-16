
$(function () {
    let imagenUrl = '';
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'veromorera', api_key: '481452668495596' });



    // Upload button
    let uploadButton = $('#btnSubirFoto');
    let uploadButton2 = $('#btnSubirFoto2');



    // Upload button event
    uploadButton.on('click', function (e) {
        // Initiate upload
        cloudinary.openUploadWidget({ cloud_name: 'veromorera', upload_preset: 'educatecr', tags: ['cgal'] },
            function (error, result) {
                if (error) console.log(error);
                // If NO error, log image data to console
                let id = result[0].public_id;
                console.log(id);
                imagenUrl = 'https://res.cloudinary.com/veromorera/image/upload/' + id;

                //agregar un preview de la imagen
                document.querySelector('#image_preview').src = imagenUrl;

                //asignar el link de la imagen al formulario de registro.
                $('#txtImg').val(imagenUrl);
            });
    });


    // Upload button event
    uploadButton2.on('click', function (e) {
        // Initiate upload
        cloudinary.openUploadWidget({ cloud_name: 'veromorera', upload_preset: 'educatecr', tags: ['cgal'] },
            function (error, result) {
                if (error) console.log(error);
                // If NO error, log image data to console
                let id2 = result[0].public_id;
                imagenUrl2 = 'https://res.cloudinary.com/veromorera/image/upload/' + id2;

                //agregar un preview de la imagen
                document.querySelector('#image_preview2').src = imagenUrl2;

                //asignar el link de la imagen al formulario de registro.
                $('#txtImg2').val(imagenUrl2);
            });
    });





})

function processImage(id) {
    let options = {
        client_hints: true,
    };
    return $.cloudinary.url(id, options);
}
