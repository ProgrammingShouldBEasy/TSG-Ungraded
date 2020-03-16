// $(document).ready(function () {
//     alert("Ready to go!!!");
// });

// $("#search-button").click(function() {
//     var term = document.forms["search-block"]["search"].value;
//     var category = document.forms["search-block"]["dvds"].value;
//     var validate = document.("search-validation");
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
        $("#search-validation").css("visibility", "hidden");
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
                            + "><td><button type='button' onclick=displayDVD("+dvd.dvdId+")>"
                            + dvd.title
                            + "</button></td><td>"
                            + dvd.realeaseYear
                            + "</td><td>"
                            + dvd.director
                            + "</td><td>"
                            + dvd.rating
                            + "</td><td><button type='button' onclick=displayEdit("+dvd.dvdId+")>Edit</button><button type='button' onclick=deleteDVD("+dvd.dvdId+")>Delete</button></td></tr>").text();
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
                            + "><td><button type='button' onclick=displayDVD("+dvd.dvdId+")>"
                            + dvd.title
                            + "</button></td><td>"
                            + dvd.realeaseYear
                            + "</td><td>"
                            + dvd.director
                            + "</td><td>"
                            + dvd.rating
                            + "</td><td><button type='button' onclick=displayEdit("+dvd.dvdId+")>Edit</button><button type='button' onclick=deleteDVD("+dvd.dvdId+")>Delete</button></td></tr>").text();
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
                url: "http://localhost:8080/dvds/director/" + search,
                contentType: "application/json;charset=UTF-8",
                success: function (dvdArray) {
                    $.each(dvdArray, function(index, dvd) {
                        $("#dvd-results-table").append("<tr id="
                            + dvd.dvdId
                            + "><td><button type='button' onclick=displayDVD("+dvd.dvdId+")>"
                            + dvd.title
                            + "</button></td><td>"
                            + dvd.realeaseYear
                            + "</td><td>"
                            + dvd.director
                            + "</td><td>"
                            + dvd.rating
                            + "</td><td><button type='button' onclick=displayEdit("+dvd.dvdId+")>Edit</button><button type='button' onclick=deleteDVD("+dvd.dvdId+")>Delete</button></td></tr>").text();
                    })
                },
                error: function(xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }

        if($("#dvds").val() == "rating") {
            var search = $("#search").val();
            $.ajax({
                type: "GET",
                url: "http://localhost:8080/dvds/rating/" + search,
                contentType: "application/json;charset=UTF-8",
                success: function (dvdArray) {
                    $.each(dvdArray, function(index, dvd) {
                        $("#dvd-results-table").append("<tr id="
                            + dvd.dvdId
                            + "><td><button type='button' onclick=displayDVD("+dvd.dvdId+")>"
                            + dvd.title
                            + "</button></td><td>"
                            + dvd.realeaseYear
                            + "</td><td>"
                            + dvd.director
                            + "</td><td>"
                            + dvd.rating
                            + "</td><td><button type='button' onclick=displayEdit("+dvd.dvdId+")>Edit</button><button type='button' onclick=deleteDVD("+dvd.dvdId+")>Delete</button></td></tr>").text();
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
                    + "><td><button type='button' onclick=displayDVD("+dvd.dvdId+")>"
                    + dvd.title
                    + "</button></td><td>"
                    + dvd.realeaseYear
                    + "</td><td>"
                    + dvd.director
                    + "</td><td>"
                    + dvd.rating
                    + "</td><td><button type='button' onclick=displayEdit("+dvd.dvdId+")>Edit</button><button type='button' onclick=deleteDVD("+dvd.dvdId+")>Delete</button></td></tr>").text();
            })
        },
        error: function(xhr, status, error) {
            alert(xhr.responseText);
          }
    });
});

function displayEdit(id) {
    var card = document.getElementById("edit-dvd-card")
    card.style.visibility = "visible";
}

function displayDVD(id) {
    var card = document.getElementById("display-dvd-card")
    card.style.visibility = "visible";
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/dvd/" + id,
        contentType: "application/json;charset=UTF-8",
        success: function (dvd) {
            $("#display-year").append(dvd.realeaseYear).text();
            $("#display-director").append(dvd.director).text();
            $("#display-rating").append(dvd.rating).text();
            $("#display-notes").append(dvd.notes).text();
        },
        error: function(xhr, status, error) {
            alert(xhr.responseText);
          }
    });
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
    $("#confirm-delete").css("visibility", "hidden");
    $("#display-year").empty();
    $("#display-director").empty();
    $("#display-rating").empty();
    $("#display-notes").empty();
}

function deleteDVD(id) {
    $("#confirm-delete").css("visibility", "visible");
    $("#deleteConfirmed").click(function(id){
        $.ajax({
            type: "DELETE",
            url: "http://localhost:8080/dvd/" + id,
            contentType: "application/json;charset=UTF-8",
            success: function () {
            },
            error: function(xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    });
}