function activeCheck(target) {
    let priceTag = document.getElementById("priceModel");
    let descriptionTag = document.getElementById("descriptionModel");
    let descriptionTemp = document.getElementById(target.name);
    console.log(descriptionTemp)
    console.log(target.value)
    priceTag.value = target.value;
    descriptionTag.value = descriptionTemp.innerHTML;
}
