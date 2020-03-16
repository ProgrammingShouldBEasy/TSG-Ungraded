// $(document).ready(function () {
//     alert("Ready to go!!!");
// });

// $("#search-button").click(function() {
//     var term = document.forms["search-block"]["search"].value;
//     var category = document.forms["search-block"]["dvds"].value;
//     var validate = document.getElementById("search-validation");
//     if (term == "") {
//         validate.style.visibility = "visible";
//         return false;
//     }
//     if (category == "") {
//         validate.style.visibility = "visible";
//         return false;
//     }
// });

$("#search-button").click( function() {

    $("#dvd-results-table").empty();
    $("#dvd-results-table").append("<tr><th>Title</th><th>Release Date</th><th>Director</th><th>Rating</th><th></th></tr>").text();
    if($("dvds").val() == "search category" || $("#search").val() == "" || $("#search").val() == "Search Term")
    {
        $("#search-validation").css("visibility", "visible");
    }
    else
    {
        if($("#dvds").val() == "title") {
            var search = $("#search").val();
            $.ajax({
                type: "GET",
                url: "http://localhost:8080/dvds/title/" + search,
                contentType: "application/json;charset=UTF-8",
                success: function (dvdArray) {
                    $.each(dvdArray, function(index, dvd) {
                        $("#dvd-results-table").append("<tr id="
                            + dvd.dvdId
                            + "><td><button type='button' onclick=displayDVD()>"
                            + dvd.title
                            + "</button></td><td>"
                            + dvd.realeaseYear
                            + "</td><td>"
                            + dvd.director
                            + "</td><td>"
                            + dvd.rating
                            + "</td><td><button type='button' onclick=displayEdit()>Edit</button><button type='button' onclick=deleteDVD()>Delete</button></td></tr>").text();
                    })
                },
                error: function(xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }

        if($("#dvds").val() == "release year") {
            var search = $("#search").val();
            $.ajax({
                type: "GET",
                url: "http://localhost:8080/dvds/year/" + search,
                contentType: "application/json;charset=UTF-8",
                success: function (dvdArray) {
                    $.each(dvdArray, function(index, dvd) {
                        $("#dvd-results-table").append("<tr id="
                            + dvd.dvdId
                            + "><td><button type='button' onclick=displayDVD()>"
                            + dvd.title
                            + "</button></td><td>"
                            + dvd.realeaseYear
                            + "</td><td>"
                            + dvd.director
                            + "</td><td>"
                            + dvd.rating
                            + "</td><td><button type='button' onclick=displayEdit()>Edit</button><button type='button' onclick=deleteDVD()>Delete</button></td></tr>").text();
                    })
                },
                error: function(xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }

        if($("#dvds").val() == "director name") {
            var search = $("#search").val();
            $.ajax({
                type: "GET",
                url: "http://localhost:8080/dvds/year/" + search,
                contentType: "application/json;charset=UTF-8",
                success: function (dvdArray) {
                    $.each(dvdArray, function(index, dvd) {
                        $("#dvd-results-table").append("<tr id="
                            + dvd.dvdId
                            + "><td><button type='button' onclick=displayDVD()>"
                            + dvd.title
                            + "</button></td><td>"
                            + dvd.realeaseYear
                            + "</td><td>"
                            + dvd.director
                            + "</td><td>"
                            + dvd.rating
                            + "</td><td><button type='button' onclick=displayEdit()>Edit</button><button type='button' onclick=deleteDVD()>Delete</button></td></tr>").text();
                    })
                },
                error: function(xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }
    }
});

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/dvds",
        contentType: "application/json;charset=UTF-8",
        success: function (dvdArray) {
            $.each(dvdArray, function(index, dvd) {
                $("#dvd-results-table").append("<tr id="
                    + dvd.dvdId
                    + "><td><button type='button' onclick=displayDVD()>"
                    + dvd.title
                    + "</button></td><td>"
                    + dvd.realeaseYear
                    + "</td><td>"
                    + dvd.director
                    + "</td><td>"
                    + dvd.rating
                    + "</td><td><button type='button' onclick=displayEdit()>Edit</button><button type='button' onclick=deleteDVD()>Delete</button></td></tr>").text();
            })
        },
        error: function(xhr, status, error) {
            alert(xhr.responseText);
          }
    });
});

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

function deleteDVD() {
    alert("Are you sure you want to delete this DVD from your collection?");
}