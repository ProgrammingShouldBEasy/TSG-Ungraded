$(document).ready(function (){
    load();
});

function load() {
    $("#menu").empty();
    $.ajax({
        type: "GET",
        url: "http://tsg-vending.herokuapp.com/items",
        success: function(itemArray) {
            $.each(itemArray, function(index, item) {
                $("#menu").append(
                "<button type='button'class='menu-selections' id="
                +item.id+" onclick='select(this)'><div class='item-id'>"+item.id
                +"</div><br>"+item.name
                +"<br>$"+item.price.toFixed(2)
                +"<br><br>Quantity Left: "+item.quantity
                +"</button>").text();
            })
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    })
};

var sum = parseFloat("0");

$("#add-Dollar").click(function(){
    sum += parseFloat("1");
    $("#mAmount").val(sum.toFixed(2));
});

$("#add-Quarter").click(function(){
    sum += parseFloat(".25");
    $("#mAmount").val(sum.toFixed(2));
});

$("#add-Dime").click(function(){
    sum += parseFloat(".1");
    $("#mAmount").val(sum.toFixed(2));
});

$("#add-Nickel").click(function(){
    sum += parseFloat(".05");
    $("#mAmount").val(sum.toFixed(2));
});

// $(".menu-selections").click(function() {
//     $("#item-id").val($(this).attr('id'));
// });

function select(x) {
    $("#item-id").val($(x).attr('id'));
};

$("#submit-purchase").click(function() {
    if ($("#item-id").val() == "")
    {
        $("#message").val("Please make a selection");
        setTimeout(function(){
           load();
        }, 100)
    }
    else {
        $.ajax({
            type: "POST",
            url: "http://tsg-vending.herokuapp.com/money/"+ $("#mAmount").val()
            +"/item/"
            +$("#item-id").val(),
            success: function(change) {
                $("#change").val(change.quarters+" quarters, "+
                change.dimes+" dimes, "+
                change.nickels+" nickels, "+
                change.pennies+" pennies");
                $("#message").val("Thank You!!!");
                $("#mAmount").val(0.00);
                setTimeout(function(){
                    $("#menu").empty();
                    $.ajax({
                        type: "GET",
                        url: "http://tsg-vending.herokuapp.com/items",
                        success: function(itemArray) {
                            $.each(itemArray, function(index, item) {
                                $("#menu").append(
                                "<button type='button'class='menu-selections' id="
                                +item.id+" onclick='select(this)'><div class='item-id'>"+item.id
                                +"</div><br>"+item.name
                                +"<br>$"+item.price.toFixed(2)
                                +"<br><br>Quantity Left: "+item.quantity
                                +"</button>").text();
                            })
                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText);
                        }
                    })
                }, 100)
                },
            error: function (error) {
                $("#message").val(JSON.parse(error.responseText).message);
                load();
            }
        })
    }
});

$("#change-return").click(function() {
    if($("#mAmount").val() == 0.00) {
        $("#change-return").val(0.00)
    }

    else {
        var total = $("#mAmount").val();
        var quarters = Math.floor((total/.25));
        total = (total - quarters*.25).toFixed(2);
        var dimes = Math.floor((total/.10));
        total= (total-dimes%.1).toFixed(2);
        var nickels = Math.floor((total/.05));
        $("#change").val(quarters + " quarters, "+
        dimes + " dimes, "+
        nickels + " nickels");
    }
});