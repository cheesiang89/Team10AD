//For Requisition cart
//Generate list based on SessionData
$(document).ready(function () {
    //window.alert("Test");

    var cart;
    if (sessionStorage.cart) {
        cart = JSON.parse(sessionStorage.getItem('cart'));
        console.log("got cart");
    } else {
        console.log("no cart");
        cart = [];
    }

    //Make Table
    for (var i = 0; i < cart.length; i++) {
        console.log('2nd page List values:' + cart[i]);
        var obj = JSON.parse(cart[i]);
        console.log('2nd page JSON object: ' + obj.itemCode);
        addRow(obj,i);

    }
});
//Save cart
$(document).ready(
    saveData()
);

function addRow(obj, index) {
       $('<tr>').html(
        //"<tr>" +
        "<td><input type=text readonly='true' id='txtItemCode" + index + "'></input></td><td>"
        + obj.description + "</td><td>"
        + "<input type=text id='txtInput"+index+"'></input></td><td>"
        //+ obj.quantity + "</td><td>"
        + obj.uom + "</td><td id='btnDelete"+index+"'></td></tr>").appendTo('#cartTable tbody');

    //Make quantity editable
       $('#txtInput' + index).val(obj.quantity);

    //Make itemcode an input
       $('#txtItemCode' + index).val(obj.itemCode);

    console.log('Quantity: ' + obj.quantity);

    //Add Button
    addButton(index);
    
}
//Loop through rows and append button
function addButton(index) {
     //Make DELETE Button on 5th <td>
    var cartTab = $('#cartTable tbody');
    console.log("CartTab is:" + cartTab.html());
    var tr = $('#cartTable tr').eq(index+1);
    console.log("CartRow is:" + tr.html());
    let td = $('#btnDelete'+index);
    console.log("CartData is:" + td.html());
    // ADD A BUTTON.
    var button = document.createElement('input');

    // SET INPUT ATTRIBUTE.
    button.setAttribute('type', 'button');
    button.setAttribute('value', 'Remove');
    // ADD THE BUTTON's 'onclick' EVENT.
    button.setAttribute('onclick', 'removeRow(this)');

    td.append(button);
}

// DELETE TABLE ROW.
function removeRow(oButton) {
    var cartTab = document.getElementById('cartTable');
    cartTab.deleteRow(oButton.parentNode.parentNode.rowIndex);       // BUTTON -> TD -> TR.
}

function saveData() {
    $(document).on("click", "[id*=btnSubmitRequisition]", function () {
        //Iterate through rows, create JSON
        var cartObjs = $('#cartTable');
        var values = new Array();

        // LOOP THROUGH EACH ROW OF THE TABLE.
        for (row = 1; row < cartObjs.rows.length - 1; row++) {
            for (c = 0; c < cartObjs.rows[row].cells.length; c++) {   // EACH CELL IN A ROW.

                var element = cartObjs.rows.item(row).cells[c];
                if (element.childNodes[0].getAttribute('type') === 'text') {
                    values.push("'" + element.childNodes[0].value + "'");
                }
            }
        }
        console.log(values);
        return false;
    });
}

function deleteCart() {
    if (sessionStorage.cart) {
        sessionStorage.removeItem('cart');
        //Iterate list check if got delete
        cart = JSON.parse(sessionStorage.getItem('cart'));
        for (var i = 0; i < cart.length; i++) {
            window.alert('Empty cart?? :' + cart[i]);
        }
    }
}

//OLD: Page leave confirmation - Cart will be discarded
//window.onbeforeunload = function () {
//    //Custom message not possible with later versions of Firefox and Chrome
//    return "Do you want to leave?"
//}

//// A jQuery event (I think), which is triggered after "onbeforeunload"
//$(window).unload(function () {
//    alert("Do Reset..");
//    deleteCart();
//});



