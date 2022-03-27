$(document).ready(function () {
  $("#image-loader").change(function () {
    if (this.files.length > 0) {
      $("#image-url").val(this.files[0].name);
    }
  });

  $(".btn-edit").click(async function () {
    const id = $(this).data("id");
    const res = await httpGet("/employee/get/" + id);
    if (res.isSuccess) {
      const { id, code, name, batchId, productId, imageUrl } = res.data;
      $("#employee-id").val(id);
      $("#code").val(code);
      $("#name").val(name);
      $("#batch").val(batchId);
      $("#product").val(productId);
      $("#image-url").val(imageUrl);
    } else {
      alert("Failed to load the data!");
    }
  });

  $(".btn-delete").click(async function () {
    const isConfirm = confirm("Do you want to remove the data?");
    if (!isConfirm) return;

    const id = $(this).data("id");
    const res = await httpDelete("/employee/delete/" + id);
    if (res.isSuccess) window.location.reload();
    else alert(res.message);
  });
});
