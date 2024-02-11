// Premissa: Estou considerando um documento chamado "dados.json" com as opções da caixa de seleção.

document.addEventListener("DOMContentLoaded", function() {
    const botao = document.getElementById("botao");
    botao.addEventListener("click", function() {
        alert("Agora escolha uma das opções na caixa de seleção a seguir.");

        const xhr = new XMLHttpRequest();
        xhr.open("GET", "dados.json", true);
        xhr.onload = function() {
            if (xhr.status === 200) {
                const data = JSON.parse(xhr.responseText);
                const selectBox = document.getElementById("caixaSelecao");
                data.forEach(function(item) {
                    const option = document.createElement("option");
                    option.value = item.id;
                    option.textContent = item.nome;
                    selectBox.appendChild(option);
                });
            } else {
                alert("Erro ao carregar dados!");
            }
        };
        xhr.send();
    });
});