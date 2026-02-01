fetch("https://localhost:7295/api/Profesores")
    .then(r => r.json())
    .then(data => {
        const tabla = document.getElementById("tablaProfesores");
        data.forEach(p => {
            tabla.innerHTML += `
                <tr>
                    <td>${p.nombre}</td>
                    <td>${p.especialidad}</td>
                    <td>${p.email}</td>
                    <td>${p.telefono}</td>
                </tr>`;
        });
    });


