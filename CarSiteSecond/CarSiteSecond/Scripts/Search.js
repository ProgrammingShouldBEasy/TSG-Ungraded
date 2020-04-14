//$(document).ready(function () {
//    alert("Ready to go!!!");
//});
$("#new-search-submit").click(function () {
    var searchTerm = $("#new-vehicle-search-text").val();
    var minP = parseInt($("#new-search-min-price").val());
    var maxP = parseInt($("#new-search-max-price").val());
    var minY = parseInt($("#new-search-min-year").val());
    var maxY = parseInt($("#new-search-max-year").val());
    var mileage;
    $.ajax({
        type: "GET",
        url: "http://localhost:53471/Inventory/New/Get",
        contentType: "application/json;charset=UTF-8",
        success: function (list) {
            $.each(list, function (index, vehicle) {
                if (vehicle.Mileage == 0) { mileage = 'New' } else { mileage = vehicle.Mileage };
                if (
                    (toString(vehicle.Make).includes(searchTerm) >= 0 || toString(vehicle.Model).includes(searchTerm) >= 0 || toString(vehicle.Year).includes(searchTerm) >= 0)
                    &&
                    (vehicle.SalePrice >= minP && vehicle.SalePrice <= maxP)
                    &&
                    (vehicle.Year >= minY && vehicle.Year <= maxY)
                ) {
                    $("#new-results-table").append("<tr><td class='bold left-text'>"
                        + vehicle.Year + " " + vehicle.Make + " " + vehicle.Model
                        + "</td>"
                        + "<td></td>"
                        + "<td></td>"
                        + "<td></td>"
                        + "</tr>"
                        + "<tr>"
                        + "<td rowspan='3'><img src='"
                        + vehicle.PictureSrc
                        + "'/></td>"
                        + "<td class='bold right-text'>Body Style:</td>"
                        + "<td class='left-text'>"
                        + vehicle.BodyStyle
                        + "</td>"
                        + "<td class='bold right-text'>Interior:</td>"
                        + "<td class='left-text'>"
                        + vehicle.Interior
                        + "</td>"
                        + "<td class='bold right-text'>Sale Price:</td>"
                        + "<td class='left-text'>"
                        + vehicle.SalePrice
                        + "</td>"
                        + "</tr>"
                        + "<tr>"
                        + "<td class='bold right-text'>Trans:</td>"
                        + "<td class='left-text'>"
                        + vehicle.Transmission
                        + "</td >"
                        + "<td class='bold right-text'>Mileage:</td>"
                        + "<td class='left-text'>"
                        + mileage
                        + "<td class='bold right-text'>MSRP:</td>"
                        + "<td class='left-text'>"
                        + vehicle.MSRP
                        + "</td >"
                        + "</tr>"
                        + "<tr>"
                        + "<td class='bold right-text'>Color:</td>"
                        + "<td class='left-text'>"
                        + vehicle.Color
                        + "</td >"
                        + "<td class='bold right-text' > Vin #:</td > "
                            + "<td class='left-text'>"
                            + vehicle.Vin
                            + "</td >"
                            + "<td></td>"
                        + "<td class='left-text'><a href='./Details/" + vehicle.id
                        +"'"
                        + ">Details</a></td>"
                            + "</tr>").text();                        
                }
            })
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
});
 //$("#search-button").click(function() {
 //    var term = document.forms["search-block"]["search"].value;
 //    var category = document.forms["search-block"]["dvds"].value;
 //    var validate = document.("search-validation");
 //    if (term == "") {
 //        validate.style.visibility = "visible";
 //        return false;
 //    }
 //    if (category == "") {
 //        validate.style.visibility = "visible";
 //        return false;
 //    }
 //});

//$("#search-button").click(function () {

//    $("#rows").empty();
//    if ($("dvds").val() == "search category" || $("#search").val() == "" || $("#search").val() == "Search Term") {
//        $("#search-validation").css("visibility", "visible");
//    }
//    else {
//        $("#search-validation").css("visibility", "hidden");
//        if ($("#dvds").val() == "title") {
//            var search = $("#search").val();
//            $.ajax({
//                type: "GET",
//                url: "http://localhost:44300/dvds/title/" + search,
//                contentType: "application/json;charset=UTF-8",
//                success: function (dvdArray) {
//                    $.each(dvdArray, function (index, dvd) {
//                        $("#rows").append("<tr id="
//                            + dvd.dvdId
//                            + "><td><button type='button' onclick=displayDVD(" + dvd.dvdId + ")>"
//                            + dvd.title
//                            + "</button></td><td>"
//                            + dvd.releaseYear
//                            + "</td><td>"
//                            + dvd.director
//                            + "</td><td>"
//                            + dvd.rating
//                            + "</td><td><button type='button' onclick=displayEdit(" + dvd.dvdId + ")>Edit</button><button type='button' onclick=deleteDVD(" + dvd.dvdId + ")>Delete</button></td></tr>").text();
//                    })
//                },
//                error: function (xhr, status, error) {
//                    alert(xhr.responseText);
//                }
//            });
//        }

//        if ($("#dvds").val() == "release year") {
//            var search = $("#search").val();
//            $.ajax({
//                type: "GET",
//                url: "http://localhost:44300/dvds/year/" + search,
//                contentType: "application/json;charset=UTF-8",
//                success: function (dvdArray) {
//                    $.each(dvdArray, function (index, dvd) {
//                        $("#rows").append("<tr id="
//                            + dvd.dvdId
//                            + "><td><button type='button' onclick=displayDVD(" + dvd.dvdId + ")>"
//                            + dvd.title
//                            + "</button></td><td>"
//                            + dvd.releaseYear
//                            + "</td><td>"
//                            + dvd.director
//                            + "</td><td>"
//                            + dvd.rating
//                            + "</td><td><button type='button' onclick=displayEdit(" + dvd.dvdId + ")>Edit</button><button type='button' onclick=deleteDVD(" + dvd.dvdId + ")>Delete</button></td></tr>").text();
//                    })
//                },
//                error: function (xhr, status, error) {
//                    alert(xhr.responseText);
//                }
//            });
//        }

//        if ($("#dvds").val() == "director name") {
//            var search = $("#search").val();
//            $.ajax({
//                type: "GET",
//                url: "http://localhost:44300/dvds/director/" + search,
//                contentType: "application/json;charset=UTF-8",
//                success: function (dvdArray) {
//                    $.each(dvdArray, function (index, dvd) {
//                        $("#rows").append("<tr id="
//                            + dvd.dvdId
//                            + "><td><button type='button' onclick=displayDVD(" + dvd.dvdId + ")>"
//                            + dvd.title
//                            + "</button></td><td>"
//                            + dvd.releaseYear
//                            + "</td><td>"
//                            + dvd.director
//                            + "</td><td>"
//                            + dvd.rating
//                            + "</td><td><button type='button' onclick=displayEdit(" + dvd.dvdId + ")>Edit</button><button type='button' onclick=deleteDVD(" + dvd.dvdId + ")>Delete</button></td></tr>").text();
//                    })
//                },
//                error: function (xhr, status, error) {
//                    alert(xhr.responseText);
//                }
//            });
//        }

//        if ($("#dvds").val() == "rating") {
//            var search = $("#search").val();
//            $.ajax({
//                type: "GET",
//                url: "http://localhost:44300/dvds/rating/" + search,
//                contentType: "application/json;charset=UTF-8",
//                success: function (dvdArray) {
//                    $.each(dvdArray, function (index, dvd) {
//                        $("#rows").append("<tr id="
//                            + dvd.dvdId
//                            + "><td><button type='button' onclick=displayDVD(" + dvd.dvdId + ")>"
//                            + dvd.title
//                            + "</button></td><td>"
//                            + dvd.releaseYear
//                            + "</td><td>"
//                            + dvd.director
//                            + "</td><td>"
//                            + dvd.rating
//                            + "</td><td><button type='button' onclick=displayEdit(" + dvd.dvdId + ")>Edit</button><button type='button' onclick=deleteDVD(" + dvd.dvdId + ")>Delete</button></td></tr>").text();
//                    })
//                },
//                error: function (xhr, status, error) {
//                    alert(xhr.responseText);
//                }
//            });
//        }
//    }
//});

//$(document).ready(function () {
//    $.ajax({
//        type: "GET",
//        url: "http://localhost:44300/dvds",
//        contentType: "application/json;charset=UTF-8",
//        success: function (dvdArray) {
//            $.each(dvdArray, function (index, dvd) {
//                $("#rows").append("<tr id="
//                    + dvd.dvdId
//                    + "><td><button type='button' onclick=displayDVD(" + dvd.dvdId + ")>"
//                    + dvd.title
//                    + "</button></td><td>"
//                    + dvd.releaseYear
//                    + "</td><td>"
//                    + dvd.director
//                    + "</td><td>"
//                    + dvd.rating
//                    + "</td><td><button type='button' onclick=displayEdit(" + dvd.dvdId + ")>Edit</button><button type='button' onclick=deleteDVD(" + dvd.dvdId + ")>Delete</button></td></tr>").text();
//            })
//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });
//});

//function displayEdit(id) {
//    var card = document.getElementById("edit-dvd-card")
//    card.style.visibility = "visible";
//    $("#editdvdID").val(id);
//    $.ajax({
//        type: "GET",
//        url: "http://localhost:44300/dvd/" + id,
//        contentType: "application/json;charset=UTF-8",
//        success: function (dvd) {
//            // $("#display-year").append(dvd.releaseYear).text();
//            // $("#display-director").append(dvd.director).text();
//            // $("#display-rating").append(dvd.rating).text();
//            // $("#display-notes").append(dvd.notes).text();
//            $("#edit-title").val(dvd.title),
//                $("#edit-release-year").val(dvd.releaseYear),
//                $("#edit-director").val(dvd.director),
//                $("#edit-rating").val(dvd.rating),
//                $("#edit-notes").val(dvd.notes)
//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });
//}

//$("#edit-save").click(function () {
//    $.ajax({
//        type: "PUT",
//        url: "http://localhost:44300/dvd/" + $("#editdvdID").val(),
//        data: JSON.stringify({
//            dvdId: $("#editdvdID").val(),
//            title: $("#edit-title").val(),
//            releaseYear: $("#edit-release-year").val(),
//            director: $("#edit-director").val(),
//            rating: $("#edit-rating").val(),
//            notes: $("#edit-notes").val()
//        }),
//        headers: {
//            "Content-Type": "application/json",
//            "Accept": "application/json"
//        },
//        success: function () {
//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });
//    $("#edit-release-year").empty();
//    $("#edit-director").empty();
//    $("#edit-rating").val("choose rating");
//    $("#edit-notes").empty();
//    setTimeout(function () {
//        $("#rows").empty();
//        $.ajax({
//            type: "GET",
//            url: "http://localhost:44300/dvds",
//            contentType: "application/json;charset=UTF-8",
//            success: function (dvdArray) {
//                $.each(dvdArray, function (index, dvd) {
//                    $("#rows").append("<tr id="
//                        + dvd.dvdId
//                        + "><td><button type='button' onclick=displayDVD(" + dvd.dvdId + ")>"
//                        + dvd.title
//                        + "</button></td><td>"
//                        + dvd.releaseYear
//                        + "</td><td>"
//                        + dvd.director
//                        + "</td><td>"
//                        + dvd.rating
//                        + "</td><td><button type='button' onclick=displayEdit(" + dvd.dvdId + ")>Edit</button><button type='button' onclick=deleteDVD(" + dvd.dvdId + ")>Delete</button></td></tr>").text();
//                })
//            },
//            error: function (xhr, status, error) {
//                alert(xhr.responseText);
//            }
//        });
//    }, 1000);
//});

//function displayDVD(id) {
//    var card = document.getElementById("display-dvd-card")
//    card.style.visibility = "visible";
//    $.ajax({
//        type: "GET",
//        url: "http://localhost:44300/dvd/" + id,
//        contentType: "application/json;charset=UTF-8",
//        success: function (dvd) {
//            $("#display-year").append(dvd.releaseYear).text();
//            $("#display-director").append(dvd.director).text();
//            $("#display-rating").append(dvd.rating).text();
//            $("#display-notes").append(dvd.notes).text();
//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });
//}

//function displayCreate() {
//    var card = document.getElementById("create-dvd-card")
//    card.style.visibility = "visible";
//}

//function resetDisplay() {
//    var cardDisplay = document.getElementById("display-dvd-card")
//    cardDisplay.style.visibility = "hidden";
//    var cardEdit = document.getElementById("edit-dvd-card")
//    cardEdit.style.visibility = "hidden";
//    var cardCreate = document.getElementById("create-dvd-card")
//    cardCreate.style.visibility = "hidden";
//    var validate = document.getElementById("search-validation");
//    validate.style.visibility = "hidden";
//    $("#confirm-delete").css("visibility", "hidden");
//    $("#display-year").empty();
//    $("#display-director").empty();
//    $("#display-rating").empty();
//    $("#display-notes").empty();
//    $("#create-release-year").empty();
//    $("#create-director").empty();
//    $("#create-rating").val("choose rating");
//    $("#create-notes").empty();
//    $("#edit-release-year").empty();
//    $("#edit-director").empty();
//    $("#edit-rating").val("choose rating");
//    $("#edit-notes").empty();
//}

//function deleteDVD(id) {
//    //If I run it through another div element then I'm not sure how to pass the dvdId.
//    $("#confirm-delete").css("visibility", "visible");
//    $("#deletedvdID").val(id);
//    // var isDelete = confirm("Are you sure you want to delete this dvd?");
//    // if (isDelete) {
//    //     $.ajax({
//    //         type: "DELETE",
//    //         url: "http://localhost:44300/dvd/" + id,
//    //         contentType: "application/json;charset=UTF-8",
//    //         success: function () {
//    //         },
//    //         error: function (xhr, status, error) {
//    //             alert(xhr.responseText);
//    //         }
//    //     });
//    // }
//    // $("#deleteConfirmed").click(function(id){
//    //     $.ajax({
//    //         type: "DELETE",
//    //         url: "http://localhost:44300/dvd/" + id,
//    //         contentType: "application/json;charset=UTF-8",
//    //         success: function () {
//    //         },
//    //         error: function(xhr, status, error) {
//    //             alert(xhr.responseText);
//    //         }
//    //     });
//    // });
//}

//$("#deleteConfirmed").click(function () {
//    $.ajax({
//        type: "DELETE",
//        url: "http://localhost:44300/dvd/" + $("#deletedvdID").val(),
//        contentType: "application/json;charset=UTF-8",
//        success: function () {
//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });
//    setTimeout(function () {
//        $("#rows").empty();
//        $.ajax({
//            type: "GET",
//            url: "http://localhost:44300/dvds",
//            contentType: "application/json;charset=UTF-8",
//            success: function (dvdArray) {
//                $.each(dvdArray, function (index, dvd) {
//                    $("#rows").append("<tr id="
//                        + dvd.dvdId
//                        + "><td><button type='button' onclick=displayDVD(" + dvd.dvdId + ")>"
//                        + dvd.title
//                        + "</button></td><td>"
//                        + dvd.releaseYear
//                        + "</td><td>"
//                        + dvd.director
//                        + "</td><td>"
//                        + dvd.rating
//                        + "</td><td><button type='button' onclick=displayEdit(" + dvd.dvdId + ")>Edit</button><button type='button' onclick=deleteDVD(" + dvd.dvdId + ")>Delete</button></td></tr>").text();
//                })
//            },
//            error: function (xhr, status, error) {
//                alert(xhr.responseText);
//            }
//        });
//    }, 1000);
//});

//$("#create-save").click(function () {
//    $.ajax({
//        type: "POST",
//        url: "http://localhost:44300/dvd",
//        data: JSON.stringify({
//            title: $("#create-title").val(),
//            releaseYear: $("#create-release-year").val(),
//            director: $("#create-director").val(),
//            rating: $("#create-rating").val(),
//            notes: $("#create-notes").val()
//        }),
//        headers: {
//            "Content-Type": "application/json",
//            "Accept": "application/json"
//        },
//        success: function () {
//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });
//    $("#create-release-year").empty();
//    $("#create-director").empty();
//    $("#create-rating").val("choose rating");
//    $("#create-notes").empty();
//    setTimeout(function () {
//        $("#rows").empty();
//        $.ajax({
//            type: "GET",
//            url: "http://localhost:44300/dvds",
//            contentType: "application/json;charset=UTF-8",
//            success: function (dvdArray) {
//                $.each(dvdArray, function (index, dvd) {
//                    $("#rows").append("<tr id="
//                        + dvd.dvdId
//                        + "><td><button type='button' onclick=displayDVD(" + dvd.dvdId + ")>"
//                        + dvd.title
//                        + "</button></td><td>"
//                        + dvd.releaseYear
//                        + "</td><td>"
//                        + dvd.director
//                        + "</td><td>"
//                        + dvd.rating
//                        + "</td><td><button type='button' onclick=displayEdit(" + dvd.dvdId + ")>Edit</button><button type='button' onclick=deleteDVD(" + dvd.dvdId + ")>Delete</button></td></tr>").text();
//                })
//            },
//            error: function (xhr, status, error) {
//                alert(xhr.responseText);
//            }
//        });
//    }, 1000);
//});