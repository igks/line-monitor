function drawChart(xAxisLabel, data1, data1Label, data2, data2Label) {
  const ctx = document.getElementById("perf-chart");
  const myChart = new Chart(ctx, {
    type: "line",
    data: {
      labels: xAxisLabel,
      datasets: [
        {
          label: data1Label,
          data: data1,
          borderColor: "#04bd16",
          borderWidth: 2,
          backgroundColor: "rgba(4, 189, 22, 0.3)",
          yAxisID: "y",
          tension: 0.2,
          pointStyle: "circle",
          pointRadius: 5,
          pointHoverRadius: 10,
        },
        {
          label: data2Label,
          data: data2,
          borderColor: "#0420bd",
          borderWidth: 2,
          backgroundColor: "rgba(4, 32, 189, 0.3)",
          yAxisID: "y1",
          tension: 0.2,
          pointStyle: "circle",
          pointRadius: 5,
          pointHoverRadius: 10,
        },
      ],
    },
    options: {
      responsive: true,
      interaction: {
        mode: "index",
        intersect: false,
      },
      stacked: false,
      plugins: {
        title: {
          display: true,
          text: "Performance Trend",
        },
      },
      scales: {
        y: {
          type: "linear",
          display: true,
          position: "left",
          title: {
            display: true,
            text: data1Label,
          },
        },
        y1: {
          type: "linear",
          display: true,
          position: "right",
          title: {
            display: true,
            text: data2Label,
          },

          // grid line settings
          grid: {
            drawOnChartArea: false, // only want the grid lines for one axis to show up
          },
        },
      },
    },
  });

  return myChart;
}
