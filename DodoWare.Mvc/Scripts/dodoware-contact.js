function handleSubmit() {
    document.getElementById('form').submit();
}

function handleClear() {
    document.getElementById("name").value = "";
    document.getElementById("email").value = "";
    document.getElementById('topic').value = "Feedback";
    document.getElementById("text").value = "";
}


function createEventHandlers() {
    document.getElementById("go").addEventListener("click", handleSubmit);
    document.getElementById("clear").addEventListener("click", handleClear);
}

document.addEventListener('DOMContentLoaded', createEventHandlers);
