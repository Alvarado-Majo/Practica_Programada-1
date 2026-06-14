(() => {

    const Cliente = {

        tabla: null,

        init() {
            this.inicializarTabla();
            this.registrarEventos();
        },

        inicializarTabla() {

            this.tabla = $('#tblClientes').DataTable({

                ajax: {
                    url: '/Cliente/ObtenerClientes',
                    type: 'GET',
                    dataSrc: 'dato'
                },

                columns: [

                    { data: 'id' },
                    { data: 'nombre' },
                    { data: 'apellido' },
                    { data: 'email' },

                    {
                        data: 'fechaRegistro',
                        render: function (data) {

                            if (!data)
                                return '';

                            return data.substring(0, 10);
                        }
                    },

                    {
                        data: null,
                        orderable: false,
                        render: function (data, type, row) {

                            return `
                                <button
                                    type="button"
                                    class="btn btn-info btn-sm btnDetalle"
                                    data-id="${row.id}">
                                    Ver detalle
                                </button>

                                <button
                                    type="button"
                                    class="btn btn-warning btn-sm btnEditar"
                                    data-id="${row.id}"
                                    data-nombre="${row.nombre}"
                                    data-apellido="${row.apellido}"
                                    data-email="${row.email}">
                                    Editar
                                </button>

                                <button
                                    type="button"
                                    class="btn btn-danger btn-sm eliminar"
                                    data-id="${row.id}">
                                    Eliminar
                                </button>
                            `;
                        }
                    }
                ],

                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
                }
            });
        },

        registrarEventos() {

              // Ver detalle
            $(document).on('click', '.btnDetalle', function () {
                console.log("Prueba uno")
                const id = $(this).data('id');
                console.log("Prueba dos")
                $.ajax({
                    url: '/Cliente/ObtenerDetalle',
                    type: 'GET',
                    data: {
                        id: id
                    },

                    success: function (respuesta) {
                        console.log("Prueba tres")
                        let html = '';

                        respuesta.dato.telefonos.forEach(tel => {

                            html += `
                    <li>
                        ${tel.numero} (${tel.tipo ?? 'Sin tipo'})
                    </li>
                `;
                        });

                        $('#listaTelefonos').html(html);

                        const modal = new bootstrap.Modal(
                            document.getElementById('modalDetalleCliente')
                        );
                        console.log("preuba cuatro")

                        modal.show();
                        console.log(
                            document.getElementById('modalDetalleCliente').className

                        );
                    }
                });
            });
            

            // Abrir modal editar
            $(document).on('click', '.btnEditar', function () {

                $('#ID').val($(this).data('id'));
                $('#Nombre').val($(this).data('nombre'));
                $('#Apellido').val($(this).data('apellido'));
                $('#Email').val($(this).data('email'));

                const modal = new bootstrap.Modal(
                    document.getElementById('modalEditarCliente')
                );
                console.log(
                    document.getElementById('modalDetalleCliente').outerHTML
                );

                modal.show();
            });

            // Guardar edición
            $('#formEditarCliente').submit(function (e) {

                e.preventDefault();

                $.ajax({

                    url: '/Cliente/Edit',
                    type: 'POST',

                    data: {

                        id: $('#ID').val(),
                        ID: $('#ID').val(),
                        Nombre: $('#Nombre').val(),
                        Apellido: $('#Apellido').val(),
                        Email: $('#Email').val()
                    },

                    success: function (respuesta) {

                        Swal.fire({
                            icon: 'success',
                            title: 'Correcto',
                            text: respuesta.mensaje
                        });

                        bootstrap.Modal.getInstance(
                            document.getElementById('modalEditarCliente')
                        ).hide();

                        $('#tblClientes').DataTable().ajax.reload();
                    }
                });
            });

            //eliminar cliente
            $(document).on('click', '.eliminar', function () {

                const id = $(this).data('id');

                Swal.fire({
                    title: '¿Está seguro?',
                    text: 'Esta acción no se puede deshacer',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Sí, eliminar'
                }).then((result) => {

                    if (result.isConfirmed) {

                        $.ajax({
                            url: '/Cliente/Delete',
                            type: 'POST',
                            data: { id: id },

                            success: function (respuesta) {

                                Swal.fire({
                                    icon: 'success',
                                    title: 'Correcto',
                                    text: respuesta.mensaje
                                });

                                $('#tblClientes').DataTable().ajax.reload();
                            },

                            error: function () {

                                Swal.fire({
                                    icon: 'error',
                                    title: 'Error',
                                    text: 'No se pudo eliminar el cliente'
                                });
                            }
                        });
                    }
                });
            });
        }
    };

    $(function () {
        Cliente.init();
    });

})();