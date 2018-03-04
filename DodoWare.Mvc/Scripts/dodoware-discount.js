function handleSubmit() {
    document.getElementById('form').submit();
}

function handleClear() {
    document.getElementById("BasePrice").value = "";
    document.getElementById("SalesTaxPercent").value = "";
    document.getElementById("DiscountPercent").value = "";
    document.getElementById("DiscountedPrice").value = "";
    document.getElementById("FinalPrice").value = "";
}


function createEventHandlers() {
    document.getElementById("go").addEventListener("click", handleSubmit);
    document.getElementById("clear").addEventListener("click", handleClear);
}

document.addEventListener('DOMContentLoaded', createEventHandlers);
