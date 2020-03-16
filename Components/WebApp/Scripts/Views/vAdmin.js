function rejectUser() {


    Swal.fire({
        title: 'Eliminar Solicitud',
        text: "¿Confirma que desea eliminar este usuario?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Cancelar',
        confirmButtonText: '¡Sí, eliminar!'
    }).then((result) => {
        if (result.value) {
            Swal.fire(
                'Eliminado',
                'El usuario se ha eliminado.',
                'success'
            )
        }
    });
    this.ctrlActions2 = new ControlActions();
    this.ctrlActions2.PostToAPI('membresiaXD');

}