$(document).ready(async function () {
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
