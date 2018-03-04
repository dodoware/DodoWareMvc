function clear(elem) {
    elem.value = elem.id;
    elem.style.color = 'lightsteelblue';
}

function handleMousedown() {
    if (this.value == this.id) {
        this.value = "";
        this.style.color = 'black';
    }
}

function handleMouseout() {
    if (this.value.trim() == '') {
        clear(this);
    }
}

function handleSubmit() {
    var array = ['A', 'B', 'C', 'D'];
    for (var i = 0; i < 4; i++) {
        var id = array[i];
        var elem = document.getElementById(id);
        var hiddenElem = document.getElementById(id + '-hidden');
        if (elem.value == elem.id) {
            hiddenElem.value = '';
        } else {
            hiddenElem.value = elem.value;
        }
    }
    var formElem = document.getElementById('ratio-form');
    formElem.submit();
}

function handleClear() {
    clear(document.getElementById('A'));
    clear(document.getElementById('B'));
    clear(document.getElementById('C'));
    clear(document.getElementById('D'));
}

function createEventHandlers() {
    document.getElementById("A").addEventListener("focus", handleMousedown);
    document.getElementById("B").addEventListener("focus", handleMousedown);
    document.getElementById("C").addEventListener("focus", handleMousedown);
    document.getElementById("D").addEventListener("focus", handleMousedown);
    document.getElementById("A").addEventListener("blur", handleMouseout);
    document.getElementById("B").addEventListener("blur", handleMouseout);
    document.getElementById("C").addEventListener("blur", handleMouseout);
    document.getElementById("D").addEventListener("blur", handleMouseout);
    document.getElementById("Go").addEventListener("click", handleSubmit);
    document.getElementById("Clear").addEventListener("click", handleClear);
}

document.addEventListener('DOMContentLoaded', createEventHandlers);
