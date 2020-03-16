$(document).ready(function (){
    $.ajax({
        type: "GET",
        url: "http://tsg-vending.herokuapp.com/items",
        success: function(itemArray) {
            $.each(itemArray, function(index, item) {
                $("#menu").append(
                "<button type='button'class='menu-selections' id="
                +item.id+"><div class='item-id'>"+item.id
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
});

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

$(".menu-selections").click(function() {
    $("#item-id").val($(this).attr('id'));
});