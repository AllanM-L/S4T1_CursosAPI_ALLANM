fetch("https://localhost:7295/api/Cursos")
    .then(r => r.json())
    .then(data => {
        const tabla = document.getElementById("tablaCursos");
        data.forEach(c => {
            tabla.innerHTML += `
                <tr>
                    <td>${c.nombre}</td>
                    <td>${c.descripcion}</td>
                    <td>${c.duracion} horas</td>
                    <td>${c.profesor?.nombre ?? 'Sin asignar'}</td>
                </tr>`;
        });
    });


