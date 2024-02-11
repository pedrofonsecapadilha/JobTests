const xhr = new XMLHttpRequest();
xhr.open("GET", "dados.json", true); // Inserir o nome do arquivo com os dados.
xhr.onload = function() {
    if (xhr.status === 200) {
        const data = JSON.parse(xhr.responseText);
        const topicosDiv = document.getElementById("topicos");
        
        data.forEach(function(objeto) {
            const lista = document.createElement("ul");
            for (const propriedade in objeto) {
                if (Object.hasOwnProperty.call(objeto, propriedade)) {
                    const item = document.createElement("li");
                    item.textContent = `${objeto[propriedade]}`;
                    lista.appendChild(item);
                }
            }
            topicosDiv.appendChild(lista);
        });
    } else {
        console.error("Erro ao carregar dados");
    }
};
xhr.send();