function showAlert(icon, message) {
  const Toast = Swal.mixin({
    toast: true,
    position: "top-end",
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
      toast.addEventListener("mouseenter", Swal.stopTimer);
      toast.addEventListener("mouseleave", Swal.resumeTimer);
    },
  });

  Toast.fire({
    icon: icon,
    title: message,
  });
}

async function confirmDialog() {
  return Swal.fire({
    title: "Do you want to remove this data?",
    showCancelButton: true,
    confirmButtonText: "Yes",
  }).then((result) => {
    return result.isConfirmed;
  });
}
