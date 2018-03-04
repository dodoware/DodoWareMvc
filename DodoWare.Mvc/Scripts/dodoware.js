function clearModalAlert() {
    var modalAlertElem = document.getElementById("modal-alert");
    modalAlertElem.style.display = "none";
}

function createEventHandlers() {
    var modalOkButtonElem = document.getElementById("modal-ok");
    if (modalOkButtonElem) {
        modalOkButtonElem.addEventListener("click", clearModalAlert);
    }
}

document.addEventListener('DOMContentLoaded', createEventHandlers);
