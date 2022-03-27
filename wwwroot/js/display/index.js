$(document).ready(function () {
  const xAxisLabel = ["Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul"];
  const data1 = Array.from({ length: 7 }, () =>
    Math.floor(Math.random() * 100)
  );
  const data1label = "Line 1";
  const data2 = Array.from({ length: 7 }, () =>
    Math.floor(Math.random() * 1000)
  );
  const data2Label = "Line 2";

  let myChart = drawChart(xAxisLabel, data1, data1label, data2, data2Label);
  console.log(myChart);

  setInterval(function () {
    myChart.data.datasets[0].data = Array.from({ length: 7 }, () =>
      Math.floor(Math.random() * 100)
    );
    myChart.data.datasets[1].data = Array.from({ length: 7 }, () =>
      Math.floor(Math.random() * 100)
    );
    myChart.update();
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
