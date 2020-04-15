//$(document).ready(function () {
//    alert("Ready to go!!!");
//});
$("#new-search-submit").click(function () {
    $("#new-results-table").empty();
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
                if (isNaN(minP)) {
                    minP = 100;
                };
                if (isNaN(maxP)) {
                    maxP = 1000000;
                };

                if (isNaN(minY)) {
                    minY = 1990;
                };

                if (isNaN(maxY)) {
                    maxY = 2020;
                };
                if (
                    (toString(vehicle.Make).includes(searchTerm) >= 0 || toString(vehicle.Model).includes(searchTerm) >= 0 || toString(vehicle.Year).includes(searchTerm) >= 0 || (searchTerm == "" || searchTerm == "Enter make, model, or year"))
                    &&
                    ((vehicle.SalePrice >= minP && vehicle.SalePrice <= maxP))
                    &&
                    ((vehicle.Year >= minY && vehicle.Year <= maxY))
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
                        + vehicle.Trans
                        + "</td>"
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
                        + vehicle.VIN
                        + "</td>"
                        + "<td></td>"
                        + "<td class='left-text'><a href='./Details/" + vehicle.id
                        + "'"
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

$("#used-search-submit").click(function () {
    $("#used-results-table").empty();
    var searchTerm = $("#used-vehicle-search-text").val();
    var minP = parseInt($("#used-search-min-price").val());
    var maxP = parseInt($("#used-search-max-price").val());
    var minY = parseInt($("#used-search-min-year").val());
    var maxY = parseInt($("#used-search-max-year").val());
    var mileage;
    $.ajax({
        type: "GET",
        url: "http://localhost:53471/Inventory/Used/Get",
        contentType: "application/json;charset=UTF-8",
        success: function (list) {
            $.each(list, function (index, vehicle) {
                if (vehicle.Mileage == 0) { mileage = 'New' } else { mileage = vehicle.Mileage };
                if (isNaN(minP)) {
                    minP = 100;
                };
                if (isNaN(maxP)) {
                    maxP = 1000000;
                };

                if (isNaN(minY)) {
                    minY = 1990;
                };

                if (isNaN(maxY)) {
                    maxY = 2020;
                };
                if (
                    (toString(vehicle.Make).includes(searchTerm) >= 0 || toString(vehicle.Model).includes(searchTerm) >= 0 || toString(vehicle.Year).includes(searchTerm) >= 0 || (searchTerm == "" || searchTerm == "Enter make, model, or year"))
                    &&
                    ((vehicle.SalePrice >= minP && vehicle.SalePrice <= maxP))
                    &&
                    ((vehicle.Year >= minY && vehicle.Year <= maxY))
                ) {
                    $("#used-results-table").append("<tr><td class='bold left-text'>"
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
                        + vehicle.Trans
                        + "</td>"
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
                        + vehicle.VIN
                        + "</td>"
                        + "<td></td>"
                        + "<td class='left-text'><a href='./Details/" + vehicle.id
                        + "'"
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


$("#sales-search-submit").click(function () {
    $("#sales-results-table").empty();
    var searchTerm = $("#sales-vehicle-search-text").val();
    var minP = parseInt($("#sales-search-min-price").val());
    var maxP = parseInt($("#sales-search-max-price").val());
    var minY = parseInt($("#sales-search-min-year").val());
    var maxY = parseInt($("#sales-search-max-year").val());
    var mileage;
    $.ajax({
        type: "GET",
        url: "http://localhost:53471/Sales/Index/Get",
        contentType: "application/json;charset=UTF-8",
        success: function (list) {
            $.each(list, function (index, vehicle) {
                if (vehicle.Mileage == 0) { mileage = 'New' } else { mileage = vehicle.Mileage };
                if (isNaN(minP)) {
                    minP = 100;
                };
                if (isNaN(maxP)) {
                    maxP = 1000000;
                };

                if (isNaN(minY)) {
                    minY = 1990;
                };

                if (isNaN(maxY)) {
                    maxY = 2020;
                };
                if (
                    (toString(vehicle.Make).includes(searchTerm) >= 0 || toString(vehicle.Model).includes(searchTerm) >= 0 || toString(vehicle.Year).includes(searchTerm) >= 0 || (searchTerm == "" || searchTerm == "Enter make, model, or year"))
                    &&
                    ((vehicle.SalePrice >= minP && vehicle.SalePrice <= maxP))
                    &&
                    ((vehicle.Year >= minY && vehicle.Year <= maxY))
                ) {
                    $("#sales-results-table").append("<tr><td class='bold left-text'>"
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
                        + vehicle.Trans
                        + "</td>"
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
                        + vehicle.VIN
                        + "</td>"
                        + "<td></td>"
                        + "<td class='left-text'><a href='../Sales/Purchase/" + vehicle.id
                        + "'"
                        + ">Purchase</a></td>"
                        + "</tr>").text();
                }
            })
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
});

$("#admin-vehicles-search-submit").click(function () {
    $("#admin-vehicles-results-table").empty();
    var searchTerm = $("#admin-vehicles-vehicle-search-text").val();
    var minP = parseInt($("#admin-vehicles-search-min-price").val());
    var maxP = parseInt($("#admin-vehicles-search-max-price").val());
    var minY = parseInt($("#admin-vehicles-search-min-year").val());
    var maxY = parseInt($("#admin-vehicles-search-max-year").val());
    var mileage;
    $.ajax({
        type: "GET",
        url: "http://localhost:53471/Admin/Vehicles/Get",
        contentType: "application/json;charset=UTF-8",
        success: function (list) {
            $.each(list, function (index, vehicle) {
                if (vehicle.Mileage == 0) { mileage = 'New' } else { mileage = vehicle.Mileage };
                if (isNaN(minP)) {
                    minP = 100;
                };
                if (isNaN(maxP)) {
                    maxP = 1000000;
                };

                if (isNaN(minY)) {
                    minY = 1990;
                };

                if (isNaN(maxY)) {
                    maxY = 2020;
                };
                if (
                    (toString(vehicle.Make).includes(searchTerm) >= 0 || toString(vehicle.Model).includes(searchTerm) >= 0 || toString(vehicle.Year).includes(searchTerm) >= 0 || (searchTerm == "" || searchTerm == "Enter make, model, or year"))
                    &&
                    ((vehicle.SalePrice >= minP && vehicle.SalePrice <= maxP))
                    &&
                    ((vehicle.Year >= minY && vehicle.Year <= maxY))
                ) {
                    $("#admin-vehicles-results-table").append("<tr><td class='bold left-text'>"
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
                        + vehicle.Trans
                        + "</td>"
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
                        + vehicle.VIN
                        + "</td>"
                        + "<td></td>"
                        + "<td class='left-text'><a href='../Admin/EditGet/" + vehicle.id
                        + "'"
                        + ">Edit</a></td>"
                        + "</tr>").text();
                }
            })
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
});

$("#sales-submit").click(function () {
    $("#salesresultsbody").empty();
    var fromDate;
    var toDate;
    var style ="";
    if ($("#fromDateSalesReport").val() == "") {
        fromDate = "1753-01-01";
    }
    else {
        fromDate = $("#fromDateSalesReport").val();
    };

    if ($("#toDateSalesReport").val() == "") {
        toDate = Date.now().toString();
    }
    else {
        toDate = $("#toDateSalesReport").val();
    };
    $.ajax({
        type: "GET",
        url: "http://localhost:53471/Reports/Sales/" + fromDate + "/" + toDate,
        contentType: "application/json;charset=UTF-8",
        success: function (list) {
            if (list.length == 0) {
                alert("Please enter valid dates in the format of YYYY-MM-DD and ensure the before date is before the to date.");
            }
            $.each(list, function (index, report) {

                if (report.UserName == $("#userSelectSalesReport").val() || $("#userSelectSalesReport").val() == "")
                {    
                    style = "";
                }
                else 
                {
                    style = " hidden ";
                };
                $("#salesresultsbody").append("<tr "
                    + style
                    + " ><td>"
                    + report.UserName
                    + "</td>"
                    + "<td>"
                    + report.TotalSales
                    + "</td>"
                    + "<td>"
                    + report.TotalVehicles
                    + "</td>"
                    + "</tr>").text();
            })
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
});