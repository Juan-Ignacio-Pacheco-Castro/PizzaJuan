let checkboxesTypes = {};
checkboxesTypes["checkboxesSize"] = document.getElementsByClassName("size");
checkboxesTypes["checkboxesPastaBase"] = document.getElementsByClassName("pastaBase");

function clearAllButtonsFromRow(checkboxType) {
    let checkboxes = checkboxesTypes[checkboxType];
    for (let checkbox = 0; checkbox < checkboxes.length; ++checkbox) {
        if (checkboxes[checkbox].name == "1") {
            toggleCheck(checkboxes[checkbox]);
        }
    }
}

function activeCheck(target, index) {
    if (index == 1) {
        clearAllButtonsFromRow("checkboxesSize");
    } else if (index == 2) {
        clearAllButtonsFromRow("checkboxesPastaBase");
    }
    toggleCheck(target);
}

function toggleCheck(target) {
    if (target.name == "0") {
        target.classList.add("activeSelection");
        target.name = "1";
        updatePrice(sum, parseInt(target.value));
    } else {
        target.classList.remove("activeSelection");
        target.name = "0";
        updatePrice(substract, parseInt(target.value));
    }
}

function updatePrice(operation, value) {
    let debitAmountTag = document.getElementById("debitAmount");
    let debitAmount = parseInt(debitAmountTag.innerHTML);
    let updatedPrice = operation(debitAmount, value);
    debitAmountTag.innerHTML = updatedPrice;
    console.log(updatedPrice);
}

function sum(target, source) {
    return target + source;
}

function substract(target, source) {
    return target - source;
}