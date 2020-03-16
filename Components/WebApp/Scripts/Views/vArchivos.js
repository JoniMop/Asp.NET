$(function () {
    let fileUrl = '';
    $.cloudinary.config({ cloud_name: 'veromorera', api_key: '481452668495596' });

    // Upload button
    let uploadButton = $('#btnSubirDoc');

    // Upload button event
    uploadButton.on('click', function (e) {
        // Initiate upload
            cloudinary.openUploadWidget({ cloud_name: 'veromorera', upload_preset: 'educatecr', tags: ['cgal'] },
                function (error, result) {
                    if (error) console.log(error);
                // If NO error, log image data to console
                let url = result[0].url;
                let fileName = result[0].original_filename;
                console.log(result);
                fileUrl = url;

                //agregar un preview del doc
                link = document.querySelector('#doc_preview');
                    link.setAttribute("href", fileUrl);

                    document.getElementById('doc_preview').innerHTML = fileName;



                //asignar el link del doc al formulario de registro.
                $('#txtMin').val(fileUrl);

                console.log(fileUrl);
            });
    });
})

function processImage(id) {
    let options = {
        client_hints: true,
    };
    return $.cloudinary.url(id, options);
};


