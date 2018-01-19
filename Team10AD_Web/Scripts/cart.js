//For Requisition cart
$(document).ready(function () {
    //window.alert("Test");
    //Generate list based on SessionData
    var cart;
    if (sessionStorage.cart) {
        cart = JSON.parse(sessionStorage.getItem('cart'));
        console.log("got cart");
    } else {
        console.log("no cart");
        cart = [];
    }

    //Print list
    for (var i = 0; i < cart.length; i++) {
        console.log('2nd page List values:' + cart[i]);
        var obj = JSON.parse(cart[i]);
        console.log('2nd page JSON object: ' + obj.itemCode);
        makeTable(obj,i);

    }


});
function makeTable(obj, index) {

    $('<tr>').html(
        //"<tr>" +
        "<td>" + obj.itemCode + "</td><td>"
        + obj.description + "</td><td>"
        + "<input type=text id='txtInput"+index+"'></input></td><td>"
        //+ obj.quantity + "</td><td>"
        + obj.uom + "</td></tr>").appendTo('#cartTable tbody');
    $('#txtInput' + index).val(obj.quantity);
    console.log('Quantity: ' + obj.quantity);
}



