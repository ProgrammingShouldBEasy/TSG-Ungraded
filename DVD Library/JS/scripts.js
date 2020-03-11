// $(document).ready(function () {
//     alert("Ready to go!!!");
// });

function validateForm() {
    var term = document.forms["search-block"]["search"].value;
    var category = document.forms["search-block"]["dvds"].value;
    var validate = document.getElementById("search-validation");
    if (term == "") {
        validate.style.visibility = "visible";
        return false;
    }
    if (category == "search category" || category == "")
    {
        validate.style.visibility = "visible";
        return false;
    }
}

function displayEdit() {
    var card = document.getElementById("edit-dvd-card")
    card.style.visibility = "visible";
}

function displayDVD() {
    var card = document.getElementById("display-dvd-card")
    card.style.visibility = "visible";
}

function displayCreate() {
    var card = document.getElementById("create-dvd-card")
    card.style.visibility = "visible";
}

function resetDisplay() {
    var cardDisplay = document.getElementById("display-dvd-card")
    cardDisplay.style.visibility = "hidden";
    var cardEdit = document.getElementById("edit-dvd-card")
    cardEdit.style.visibility = "hidden";
    var cardCreate = document.getElementById("create-dvd-card")
    cardCreate.style.visibility = "hidden";
    var validate = document.getElementById("search-validation");
    validate.style.visibility = "hidden";
}

function deleteDVD(){
    alert("Are you sure you want to delete this DVD from your collection?");
}