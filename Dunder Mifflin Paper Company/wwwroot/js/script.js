$(document).ready(function () {
    setTimeout(function () {
        $(".alert").alert('close');
    }, 4000);
});

document.addEventListener("DOMContentLoaded", function () {
    var alertDiv = document.getElementById("disappearingAlert");
    setTimeout(function () {
        alertDiv.style.opacity = "1";
    }, 1000);
});

document.addEventListener("DOMContentLoaded", function () {
    var alertDiv = document.getElementById("disappearingAlert");
    setTimeout(function () {
        alertDiv.style.opacity = "0";
        alertDiv.style.zIndex = "-999";
    }, 4000);
});

function GoBack() {
    window.history.go(-1);
}


