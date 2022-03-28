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
  }, 2000);

  $("#btn-reload").click(function () {
    const id = $("#employee-id").val();
    const process = $("#process").val();
    if (id == "" || process == "") {
      alert("Please fill in the input field!");
      return;
    }
    window.location.href = `/display?id=${id}&process=${process}`;
  });
});

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
