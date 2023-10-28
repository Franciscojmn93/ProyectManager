$(document).ready(function () {
    $('#tablaqueries').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.13.2/i18n/es-ES.json"
        },
        dom: 'Bfrtip',
        stateSave: true,
        buttons: [
            '', '', ''


            , {
                extend: 'pdfHtml5', className: "btn btn-outline-secondary btn-sm",
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5],
                }
            }

            , {
                extend: 'excelHtml5', className: "btn btn-outline-secondary btn-sm",
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                }
            }
            , {
                extend: 'csvHtml5', className: "btn btn-outline-secondary btn-sm",
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                }
            }
            , {
                extend: 'print', className: "btn btn-outline-secondary btn-sm",
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                }
            }
        ],
    });
});



