$(document).ready(function () {
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
