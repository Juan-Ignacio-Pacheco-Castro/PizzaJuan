let checkboxesTypes = {};
checkboxesTypes["checkboxesSize"] = document.getElementsByClassName("size");
checkboxesTypes["checkboxesPastaBase"] = document.getElementsByClassName("pastaBase");
checkboxesTypes["checkboxesPizzaType"] = document.getElementsByClassName("pizzaType");

function clearAllButtonsFromRow(checkboxType) {
    let checkboxes = checkboxesTypes[checkboxType];
    for (let checkbox = 0; checkbox < checkboxes.length; ++checkbox) {
        if (checkboxes[checkbox].name == "1") {
            toggleCheck(checkboxes[checkbox]);
        }
    }
}

function activeCheck(target, index, typesOfBoxes) {
    if (index == 1) {
        clearAllButtonsFromRow("checkboxes" + typesOfBoxes);
    }
    toggleCheck(target);
}

function toggleCheck(target) {
    if (target.name == "0") {
        target.classList.add("activeSelection");
        target.name = "1";
        updatePrice(sum, parseInt(target.value), sumString, target.innerHTML);
    } else {
        target.classList.remove("activeSelection");
        target.name = "0";
        updatePrice(substract, parseInt(target.value), delString, target.innerHTML);
    }
}

function updatePrice(priceOperation, value, nameOperation, name) {
    let debitAmountTag = document.getElementById("debitAmount");
    let priceTag = document.getElementById("priceModel");
    let descriptionTag = document.getElementById("descriptionModel");

    let debitAmount = parseInt(debitAmountTag.innerHTML.substring(1));
    let updatedPrice = priceOperation(debitAmount, value);
    let updatedDescription = nameOperation(descriptionTag.value, name);


    debitAmountTag.innerHTML = '₡' + updatedPrice;
    priceTag.value = updatedPrice;
    descriptionTag.value = updatedDescription;
}

function sum(target, source) {
    return target + source;
}

function substract(target, source) {
    return target - source;
}

function sumString(target, source) {
    return target + source + ',';
}

function delString(target, source) {
    return target.replace(source + ',', '');
}