function show(m, n) {
    var wholeNumberElem = document.getElementById("whole-number-" + m);
    var numeratorElem = document.getElementById("numerator-" + m);
    var fractionBarElem = document.getElementById("fraction-bar-" + m);
    var denominatorElem = document.getElementById("denominator-" + m);
    var wholeNumberInputElem = document.getElementById("whole-number-input-" + m);
    var numeratorInputElem = document.getElementById("numerator-input-" + m);
    var denominatorInputElem = document.getElementById("denominator-input-" + m);
    if (n === 0) {
        numeratorElem.className = "numerator-hidden";
        fractionBarElem.className = "fraction-bar-hidden";
        denominatorElem.className = "denominator-hidden";
        numeratorInputElem.value = "";
        denominatorInputElem.value = "";
        wholeNumberElem.className = "whole-number-center";
    } else if (n === 1) {
        wholeNumberElem.className = "whole-number-hidden";
        wholeNumberInputElem.value = "";
        numeratorElem.className = "numerator-center";
        fractionBarElem.className = "fraction-bar-center";
        denominatorElem.className = "denominator-center";
    } else {
        wholeNumberElem.className = "whole-number-left";
        numeratorElem.className = "numerator-right";
        fractionBarElem.className = "fraction-bar-right";
        denominatorElem.className = "denominator-right";
    }
}

function handleClear() {
    for (var m = 1; m <= 2; m++) {
        document.getElementById("whole-number-" + m).value = "";
        document.getElementById("numerator-" + m).value = "";
        document.getElementById("fraction-bar-" + m).value = "";
        document.getElementById("denominator-" + m).value = "";
        document.getElementById("whole-number-input-" + m).value = "";
        document.getElementById("numerator-input-" + m).value = "";
        document.getElementById("denominator-input-" + m).value = "";
    }
}

function handleSubmit() {
    document.getElementById('fraction-form').submit();
}

function createEventHandlers() {
    document.getElementById("go").addEventListener("click", handleSubmit);
    document.getElementById("clear").addEventListener("click", handleClear);
}

document.addEventListener('DOMContentLoaded', createEventHandlers);
