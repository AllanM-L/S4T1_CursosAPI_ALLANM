fetch("https://localhost:7295/api/Estudiantes")
    .then(r => r.json())
    .then(data => {
        const tabla = document.getElementById("tablaEstudiantes");
        data.forEach(e => {
            tabla.innerHTML += `
                <tr>
                    <td>${e.nombre}</td>
                    <td>${e.apellido}</td>
                    <td>${e.email}</td>
                    <td>${e.telefono}</td>
                </tr>`;
        });
    });

