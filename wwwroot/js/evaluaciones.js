fetch("https://localhost:7295/api/Evaluaciones")
    .then(r => r.json())
    .then(data => {
        const tabla = document.getElementById("tablaEvaluaciones");
        data.forEach(e => {
            tabla.innerHTML += `
                <tr>
                    <td>${e.inscripcion?.estudiante?.nombre}</td>
                    <td>${e.inscripcion?.curso?.nombre}</td>
                    <td>${e.nota}</td>
                    <td>${e.observacion}</td>
                </tr>`;
        });
    });

