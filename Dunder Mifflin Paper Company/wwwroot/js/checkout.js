function SelectDeliveryMethod(type) {
    var form = document.forms.OrderReview;
    form.deliveryMethod.value = type;

    let selected;
    let unselected;

    let addressDiv = document.getElementById('address');

    if (type == 'Delivery') {
        selected = document.getElementById('Delivery');
        unselected = document.getElementById('Collection');
        addressDiv.hidden = false;
    }
    else {
        unselected = document.getElementById('Delivery');
        selected = document.getElementById('Collection');
        addressDiv.hidden = true;
    }

    selected.className = 'btn btn-primary';
    unselected.className = 'btn btn-outline-primary';
}

function Show(show) {
    moreAddresses = document.getElementById('moreAddresses');
    btnMore = document.getElementById('showMore');
    btnLess = document.getElementById('showLess');

    if (show == 'more') {
        btnMore.hidden = true;
        moreAddresses.hidden = false;
        btnLess.hidden = false;
    }
    else {
        btnMore.hidden = false;
        moreAddresses.hidden = true;
        btnLess.hidden = true;
    }
}

function ShowDetails() {
    minProducts = document.getElementById('minProducts');
    maxProducts = document.getElementById('maxProducts');
    btnShowDetails = document.getElementById('showDetails');

    minProducts.hidden = maxProducts.hidden;
    maxProducts.hidden = !maxProducts.hidden;
    btnShowDetails.innerText = maxProducts.hidden ? 'Show Details' : 'Hide Details';
}