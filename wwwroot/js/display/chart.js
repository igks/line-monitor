$(document).ready(async function () {
  const data = await loadChartData();
  const { title, line1, line2, data1, data2, axis } = data;
  const chartObj = {
    title: title,
    line1: line1,
    line2: line2,
    data1: data1.split(","),
    data2: data2.split(","),
    axis: axis.split(","),
  };
  let myChart = drawChart(chartObj);

  setInterval(function () {
    updateChart(myChart);
  }, 5000);

  if ($("#alert-success").length > 0) {
    showAlert("success", "Chart data updated successfully.");
    setTimeout(() => {
      $("#alert-success").remove();
    }, 1000);
  }

  $("#btn-update").click(async function () {
    await updateChartData();
  });

  $("#btn-show").click(function () {
    window.location.href = "/display/chart";
  });
});

async function getChartData() {
  const res = await httpGet("/graph/get");
  return res;
}

async function updateChartData() {
  const title = $("#title").val();
  const line1 = $("#line1").val();
  const line2 = $("#line2").val();
  const axis = $(".axis")
    .map(function () {
      return this.value;
    })
    .get()
    .join(",");
  const data1 = $(".data1")
    .map(function () {
      return this.value;
    })
    .get()
    .join(",");
  const data2 = $(".data2")
    .map(function () {
      return this.value;
    })
    .get()
    .join(",");

  const data = {
    id: 1,
    title,
    line1,
    line2,
    data1,
    data2,
    axis,
  };

  const res = await httpPost("/graph/update", data);
  if (res.isSuccess) {
    window.location.href = "/graph/redirectrequest";
  } else {
    showAlert("error", "Updating data failed on save, please try again!");
  }
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

async function loadChartData() {
  const graphData = await getChartData();
  return graphData.isSuccess ? graphData.data : null;
}

async function updateChart(chart) {
  const { isSuccess, data } = await getChartData();
  if (isSuccess) {
    chart.data.labels = data.axis.split(",");
    chart.data.datasets[0].label = data.line1;
    chart.data.datasets[0].data = data.data1.split(",");
    chart.data.datasets[1].label = data.line2;
    chart.data.datasets[1].data = data.data2.split(",");
    chart.options.plugins.title.text = data.title;
    chart.update();
  }
}
