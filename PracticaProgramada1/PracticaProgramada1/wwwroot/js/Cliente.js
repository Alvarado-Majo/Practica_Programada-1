(() => {

    const Cliente = {

        tabla: null,

        init() {
            this.inicializarTabla();
            this.registrarEventos();
        },

        inicializarTabla() {

            this.tabla = $('#tbClientes').DataTable({

                ajax: {
                    url: '/Cliente/ObtenerClientes',
                    type: 'GET',
                    dataSrc: 'dato'
                },

                columns: [

                    {
                        data: null,
                        render: function (data) {
                            return `${data.nombre} ${data.apellido}`;
                        }
                    },

                    { data: 'correoElectronico' },
                    { data: 'telefono' },



                    {
                        data: null,

                        orderable: false,
                        render: function (data, type, row) {

                            return `
                                <button
                                    type="button"
                                    class="btn btn-sm btn-warning btnEditar"
                                    data-id="${row.ID}"
                                    data-nombre="${row.nombre}"
                                    data-primerapellido="${row.Apellido}"
                                    data-correo="${row.Email}"
                                    data-telefono="${row.Telefono}"
                                    data-nacimiento="${row.fechaRegistro}"
                                    <i class="bi bi-pencil"></i>
                                </button>

                                <button
                                    type="button"
                                    class="btn btn-sm btn-danger eliminar"
                                    data-id="${row.ID}">
                                    <i class="bi bi-trash"></i>
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

            //logica para editar y eliminar clientes
           
        }
    };

    $(function () {
        Cliente.init();
    });

})();