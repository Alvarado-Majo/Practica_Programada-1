(() => {

    const Cliente = {

        tabla: null,

        init() {
            this.inicializarTabla();
            this.registrarEventos();
        },

        inicializarTabla() {

            this.tabla = $('#tblClientes').DataTable({
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
                }
            });
        },

        registrarEventos() {

            $('#tblClientes tbody').on('click', '.btnEditar', function () {

                const btn = $(this);

                $('#modalEditarCliente input[name="ID"]').val(btn.data('id'));
                $('#modalEditarCliente input[name="nombre"]').val(btn.data('nombre'));
                $('#modalEditarCliente input[name="apellido"]').val(btn.data('apellido'));
                $('#modalEditarCliente input[name="email"]').val(btn.data('email'));

                const modal = new bootstrap.Modal(document.getElementById('modalEditarCliente'));
                modal.show();
            });

            $('#tblClientes tbody').on('click', '.btnEliminar', function () {

                const id = $(this).data('id');

                if (confirm("¿Eliminar cliente?")) {

                    fetch(`/Cliente/Delete/${id}`, {
                        method: 'POST'
                    })
                        .then(() => {
                            location.reload();
                        });
                }
            });

            $('#btnGuardarCliente').click(function () {
                $('#formCrearCliente').submit();
            });

            $('#btnActualizarCliente').click(function () {
                $('#formEditarCliente').submit();
            });
        }
    };

    $(function () {
        Cliente.init();
    });

})();