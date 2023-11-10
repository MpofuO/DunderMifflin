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

document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.overlay').forEach(a => {
        a.addEventListener('click', function (e) {
            e.preventDefault();
        });
    });
});

function GoBack() {
    window.history.go(-1);
}

var submit = function (formID) {
    if (formID == 'Delete') {
        if (confirm('Are you sure you want to delete this product from inventory?')) {
            form.submit();
        }
        else {
            return false;
        }
    }
    else {
        let form = document.getElementById(formID);
        form.submit();
    }
}

