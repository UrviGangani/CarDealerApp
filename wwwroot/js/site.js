//  JavaScript for Inquiry Form 
document.addEventListener("DOMContentLoaded", function () {
  document.querySelectorAll(".inquire-btn").forEach((button) => {
    button.addEventListener("click", function () {
      let carId = this.getAttribute("data-id");
      document.getElementById(`inquiry-form-${carId}`).style.display = "block";
    });
  });

  document.querySelectorAll(".close-form").forEach((button) => {
    button.addEventListener("click", function () {
      let carId = this.getAttribute("data-id");
      document.getElementById(`inquiry-form-${carId}`).style.display = "none";
    });
  });
});