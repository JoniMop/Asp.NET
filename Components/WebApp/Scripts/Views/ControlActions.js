
function ControlActions() {

	this.URL_API = "http://localhost:57056/api/";


	this.GetUrlApiService = function (service) {
		return this.URL_API + service;
	}

    this.GetTableColumsDataName = function (tableId) {
		var val = $('#' + tableId).attr("ColumnsDataName");

		return val;
	}

	this.FillTable = function (service, tableId,refresh) {

		if (!refresh) {
			columns = this.GetTableColumsDataName(tableId).split(',');
			var arrayColumnsData = [];


			$.each(columns, function (index, value) {
				var obj = {};
				obj.data = value;
				arrayColumnsData.push(obj);
			});

			$('#' + tableId).DataTable({
				"processing": true,
				"ajax": {
					"url": this.GetUrlApiService(service),
					dataSrc: 'Data'
				},
				"columns": arrayColumnsData
			});
		} else {
			//RECARGA LA TABLA
			$('#' + tableId).DataTable().ajax.reload();
		}
		
	}

	this.GetSelectedRow = function () {
		var data = sessionStorage.getItem(tableId + '_selected');

		return data;
	};

	this.BindFields = function (formId, data) {
        console.log(data);
     

		$('#' + formId +' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			this.value = data[columnDataName];
		});
	}

	this.GetDataForm = function (formId) {
		var data = {};
		
		$('#' + formId + ' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			data[columnDataName] = this.value;
		});
        console.log(data);
		return data;
	}

	this.ShowMessage = function (type,message) {
        if (type == 'E') {

            //Aqui salen los sweet alert de error!
            Swal.fire({
                type: 'error',
                title: 'Error',
                text: message,
                confirmButtonText: 'Ok'
            })

        } else if (type == 'I') {

            //aqui salen los sweet alert de info...
            Swal.fire({
                title: '¡Proceso finalizado con éxito!',
                text: message,
                type: 'success',
                confirmButtonText: '¡Entendido!'
            })
		}
    };

    //---------------------------------------------------------------
    this.ShowMessageComercio1 = function (type, message) {
        if (type == 'E') {

            //Aqui salen los sweet alert de error!
            Swal.fire({
                type: 'error',
                title: 'Error',
                text: message,
                confirmButtonText: 'Ok'
            });

        } else if (type == 'I') {

            //aqui salen los sweet alert de info...
            Swal.fire({
                title: '¡Proceso finalizado con éxito!',
                text: 'Se ha registrado como socio comercial',
                type: 'success',
                confirmButtonText: 'Ir al Paso 2'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "/Home/FormComercioParte2/"
                }
            });
        }
    }
    //---------------------------------------------------------------
    this.ShowMessageComercio2 = function (type, message) {
        if (type == 'E') {

            //Aqui salen los sweet alert de error!
            Swal.fire({
                type: 'error',
                title: 'Error',
                text: message,
                confirmButtonText: 'Ok'
            });

        } else if (type == 'I') {

            //aqui salen los sweet alert de info...
            Swal.fire({
                title: '¡Proceso finalizado con éxito!',
                text: 'Se ha registrado su restaurante',
                type: 'success',
                confirmButtonText: 'Ir al Paso 3'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "/Home/FormComercioParte3/"
                }
            });
        }
    }
    //---------------------------------------------------------------
    this.ShowMessageComercio3 = function (type, message) {
        if (type == 'E') {

            //Aqui salen los sweet alert de error!
            Swal.fire({
                type: 'error',
                title: 'Error',
                text: message,
                confirmButtonText: 'Ok'
            });

        } else if (type == 'I') {

            //aqui salen los sweet alert de info...
            Swal.fire({
                title:'¡El restaurante se registró exitosamente!',
                text: 'Le enviamos un correo con más información.',
                type: 'success',
                confirmButtonText: '¡Entendido!'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "/Home/Index/"

                }
            });
        }
    }

    //---------------------------------------------------------------
    this.ShowMessageTransportista1 = function (type, message) {
        if (type == 'E') {

            //Aqui salen los sweet alert de error!
            Swal.fire({
                type: 'error',
                title: 'Error',
                text: message,
                confirmButtonText: 'Ok'
            });

        } else if (type == 'I') {

            //aqui salen los sweet alert de info...
            Swal.fire({
                title: '¡Proceso finalizado con éxito!',
                text: 'Se ha registrado como socio transportista',
                type: 'success',
                confirmButtonText: 'Ir al Paso 2'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "/Home/FormTransportistaParte2/"
                }
            });
        }
    }
    //---------------------------------------------------------------
    this.ShowMessageTransportista2 = function (type, message) {
        if (type == 'E') {

            //Aqui salen los sweet alert de error!
            Swal.fire({
                type: 'error',
                title: 'Error',
                text: message,
                confirmButtonText: 'Ok'
            });

        } else if (type == 'I') {

            //aqui salen los sweet alert de info...
            Swal.fire({
                title: '¡Los documentos se registraron exitosamente!',
                text: 'Le enviamos un correo con más información.',
                type: 'success',
                confirmButtonText: '¡Entendido!'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "/Home/Index/"
                }
            });
        }
    }

    //---------------------------------------------------------------
    this.ShowMessageActivar = function (type, message) {
        if (type == 'E') {

            //Aqui salen los sweet alert de error!
            Swal.fire({
                type: 'error',
                title: 'Error',
                text: message,
                confirmButtonText: 'Ok'
            });

        } else if (type == 'I') {

            //aqui salen los sweet alert de info...
            Swal.fire({
                title: '¡Su cuenta fue activada exitosamente!',
                text: 'Bienvenido a la plataforma',
                type: 'success',
                confirmButtonText: '¡Entendido!'
            }).then((result) => {
                if (result.value) {
                    window.location.reload();
                }
            });
        }
    }



	this.PostToAPI = function (service, data) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};

	this.PutToAPI = function (service, data) {
		var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
			})
	};

	this.DeleteToAPI = function (service, data) {
		var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();

            //confirmar?
            Swal.fire({
                title: '¿Confirma que desea eliminar?',
                text: "¡Este cambio no se puede revertir!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, eliminar!'
            }).then((result) => {
                if (result.value) {

                    //continuar
                    ctrlActions.ShowMessage('I', response.Message); 
                }
            })
        })   
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
			})
    };

}



//Custom jquery actions

$.put = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'PUT',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}

$.delete = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'DELETE',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}
