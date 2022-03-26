$(document).ready(() => {
  $("#image-loader").change(function () {
    if (this.files.length > 0) {
      $("#image-url").val(this.files[0].name);
    }
  });

  $(".btn-edit").click(function () {
    const id = $(this).data("id");
    $.ajax({
      method: "get",
      url: "/home/get",
      data: {
        id: id,
      },
      success: function (res) {
        document.getElementById("employee-id").value = res.id;
        $("#code").val(res.code);
        $("#name").val(res.name);
        $("#batch").val(res.batchId);
        $("#product").val(res.productId);
        $("#image-url").val(res.imageUrl);
      },
    });
  });

  $(".btn-delete").click(function () {
    const isConfirm = confirm("Do you want to remove the data?");
    if (!isConfirm) return;

    const id = $(this).data("id");
    $.ajax({
      method: "post",
      url: "/home/delete",
      data: {
        id: id,
      },
      success: function (res) {
        window.location.reload();
      },
    });
  });
});
