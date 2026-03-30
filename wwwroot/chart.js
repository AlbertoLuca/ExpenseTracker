window.categoryChartInstance = null;

window.createCategoryChart = (labels, values) => {
    const canvas = document.getElementById("categoryChart");
    if (!canvas) {
        console.log("Canvas non trovato");
        return;
    }

    const ctx = canvas.getContext("2d");

    if (window.categoryChartInstance) {
        window.categoryChartInstance.destroy();
    }

    window.categoryChartInstance = new Chart(ctx, {
        type: "pie",
        data: {
            labels: labels,
            datasets: [{
                label: "Spese per categoria",
                data: values,
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });

    console.log("Grafico creato");
};