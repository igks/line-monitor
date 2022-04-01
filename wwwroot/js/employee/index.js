$(document).ready(function () {
  if ($("#alert-create").length > 0) {
    showAlert("success", "Record created successfully");
    $("#alert-create").remove();
  }
  if ($("#alert-update").length > 0) {
    showAlert("success", "Record updated successfully");
    $("#alert-update").remove();
  }
  if ($("#alert-delete").length > 0) {
    showAlert("success", "Record deleted successfully");
    $("#alert-delete").remove();
  }

  $("#image-loader").change(function () {
    if (this.files.length > 0) {
      $("#image-url").val(this.files[0].name);
    }
  });

  $(".btn-edit").click(async function () {
    $("#btn-add").html("SAVE");
    const id = $(this).data("id");
    const res = await httpGet("/employee/get/" + id);
    if (res.isSuccess) {
      const { id, code, name, batchId, productId, processName, imageUrl } =
        res.data;
      $("#employee-id").val(id);
      $("#code").val(code);
      $("#name").val(name);
      $("#batch").val(batchId);
      $("#product").val(productId);
      $("#process").val(processName);
      $("#image-url").val(imageUrl);
    } else {
      alert("Failed to load the data!");
    }
  });

  $(".btn-delete").click(async function () {
    const isConfirm = await confirmDialog();
    if (!isConfirm) return;
    const id = $(this).data("id");
    const res = await httpDelete("/employee/delete/" + id);
    if (res.isSuccess) {
      window.location.href = "/employee/redirectrequest";
    } else {
      showAlert("error", res.message);
    }
  });

  $(".btn-show").click(async function () {
    const isShow = $(this).data("show");
    if (isShow == "False") {
      showAlert(
        "error",
        "Can not show the employee when the current status disable!"
      );
      return;
    }
    const process = $(this).data("process");
    window.location.href = "/display?id=" + process;
  });

  $(".current-flag").click(async function () {
    const id = $(this).data("id");
    const value = $(this).is(":checked");
    const data = { id: id, value: value };
    const res = await httpPost("/employee/flag", data);
    if (res.isSuccess) {
      showAlert("success", "Flag updated successfully");
    }
  });
});
