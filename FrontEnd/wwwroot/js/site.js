

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});



function EditarQueries(id) {
    $.get("Queries/ObtenerQueryDatos/?id=" + id, function (data) {
        console.log("Data received:", data);
        document.getElementById("nombreid").value = data.id_query;
        document.getElementById("nombrequery").value = data.nombre_query;
        document.getElementById("nombresentencia").value = data.sentenciaSQL;
        document.getElementById("nombrecategoria").value = data.id_categoria;
        document.getElementById("nombreusuario").value = data.id_usuario;
        document.getElementById("nombreunidad").value = data.id_unidad;

        var editor = CodeMirror.fromTextArea(document.getElementById('nombresentencia'), {
            mode: "sql",
            theme: "darcula",
            lineNumbers: true,
            lineWrapping: true,
            autoRefresh: true,
            lint: true
        });

        CodeMirror.registerHelper("lint", "sql", function (text) {
            var found = [];
            var lines = text.split("\n");
            var lastLine = lines[lines.length - 1];
             // Me permite verificar si el ultimo espacio es diferente a un espacio en blanco o un ;
            var endingChar = lastLine.trim().slice(-1);
            if (endingChar !== "" && !/^[a-zA-Z0-9;]*$/.test(endingChar)) {
                found.push({
                    from: CodeMirror.Pos(lines.length - 1, lastLine.length - 1),
                    to: CodeMirror.Pos(lines.length - 1, lastLine.length),
                    message: "Debe terminar la sentencia con un ; o dejar el espacio en blanco",
                    severity: "warning"
                });
            }
            return found;

            // me permite ponerle un tamaño
        // nombresentencia.setSize(600, 300);
        });

        editor.setValue(data.sentenciaSQL);

        // Se agrega un event listener para el submit button
        $('form').on('submit', function (event) {
            event.preventDefault(); // Previene el default form submission

            var queryinicial = data.sentenciaSQL;
            var nombresentencia = editor.getValue(); // Obtiene el valor del editor


            // Verifica en base de datos
            $.get("Queries/ExisteQuery2/?nombresentencia=" + nombresentencia + "&queryinicial=" + queryinicial, function (result) {
                if (result == true) {
                    // nombresentencia existe en base de datos
                    $('input[type="submit"]').prop('disabled', true); // disable submit button
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'La sentencia ya existe, por favor coloque una nueva sentencia.',
                        position: 'top',
                        confirmButtonColor: '#3085d6',
                        confirmButtonText: 'OK'
                    });
                } else {
                    // nombresentencia no existe en base de datos
                    $('input[type="submit"]').prop('disabled', false); // enable submit button
                    $('form').unbind('submit').submit(); //  Se hace submit del form 
                }
            }).fail(function (xhr, status, error) {
                console.log("AJAX request failed:", status, error);
            });
        });

        // Agrega un event listener para que el editor habilite el boton de submit 
        editor.on('change', function () {
            $('input[type="submit"]').prop('disabled', false);
        });

        // Me permite colocar los numeros de cada linea
        setTimeout(function () {
            editor.refresh();
        }, 100);

    }).fail(function (xhr, status, error) {
        console.log("AJAX request failed:", status, error);
    });

    // Boton para copiar sentencia
    function copyFunction(event) {
        event.preventDefault(); // Previene el cierre del modal

        var nombresentencia = document.getElementById("nombresentencia");
        nombresentencia.select();
        navigator.clipboard
            .writeText(nombresentencia.value)
            .then(function () {
                var button = document.getElementById("k2button");
                button.innerHTML = 'Copiado';
                button.classList.add("copied");
                setTimeout(function () {
                    button.innerText = "Copiar";
                    button.classList.remove("copied");
                }, 2000); // Cambia el tiempo que dura el botón en mostrar la palabra "Copiado".
            })
            .catch(function (error) {
                console.error("Copy failed:", error);
            });
    }

    document.getElementById("k2button").addEventListener("click", copyFunction);


}










