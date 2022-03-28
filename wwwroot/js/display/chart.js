$(document).ready(function () {
  $("#btn-update").click(async function () {
    await updateChartData();
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
  console.log(data);

  const res = await httpPost("/graph/update", data);
  if (res.isSuccess) {
    alert("Data updated successfully");
    window.location.reload();
  } else {
    alert("Updating data failed on save, please try again!");
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
