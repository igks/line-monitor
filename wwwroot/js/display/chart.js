async function getChartData() {
  const res = await httpGet("/graph/get");
  return res;
}

function drawChart(chartObj) {
  const ctx = document.getElementById("perf-chart");
  const myChart = new Chart(ctx, {
    type: "line",
    data: {
      labels: chartObj.axis,
      datasets: [
        {
          label: chartObj.line1,
          data: chartObj.data1,
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
          label: chartObj.line2,
          data: chartObj.data2,
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
          text: chartObj.title,
        },
      },
      scales: {
        y: {
          type: "linear",
          display: true,
          position: "left",
          title: {
            display: true,
            text: chartObj.line1,
          },
        },
        y1: {
          type: "linear",
          display: true,
          position: "right",
          title: {
            display: true,
            text: chartObj.line2,
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
