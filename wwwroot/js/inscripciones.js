fetch("https://localhost:7295/api/Inscripciones")
    .then(r => r.json())
    .then(data => {
        const tabla = document.getElementById("tablaInscripciones");
        data.forEach(i => {
            tabla.innerHTML += `
                <tr>
                    <td>${i.estudiante?.nombre} ${i.estudiante?.apellido}</td>
                    <td>${i.curso?.nombre}</td>
                    <td>${i.fecha}</td>
                    <td>${i.estado}</td>
                </tr>`;
        });
    });

