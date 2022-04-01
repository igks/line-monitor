$(document).ready(async function () {
  $("#id").change(function () {
    const id = $(this).val();
    if (id == "") {
      showAlert("error", "Please fill in the input field!");
      return;
    }
    window.location.href = `/display?id=${id}`;
  });

  // $("#btn-reload").click(function () {
  //   const id = $("#id").val();
  //   if (id == "") {
  //     showAlert("error", "Please fill in the input field!");
  //     return;
  //   }
  //   window.location.href = `/display?id=${id}`;
  // });

  $("#btn-search").click(function () {
    if ($("#req-form").attr("hidden")) {
      $("#req-form").removeAttr("hidden");
    } else {
      $("#req-form").attr("hidden", true);
    }
  });
});
