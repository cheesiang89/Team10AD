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
        console.log('2nd page JSON object: ' + obj.ItemCode);
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
           "<td>" + obj.itemCode+"</td><td>"
        + obj.description + "</td><td>"
        + "<input type=text id='txtInput"+index+"'></input></td><td>"
        //+ obj.quantity + "</td><td>"
        + obj.uom + "</td><td id='btnDelete"+index+"'></td></tr>").appendTo('#cartTable tbody');

    //Make quantity editable
       $('#txtInput' + index).val(obj.quantity);

       //console.log('Quantity: ' + obj.quantity);

    //Add Button
    addButton(index);
    
}
//Loop through rows and append button
function addButton(index) {
     //Make DELETE Button on 5th <td>
    //var cartTab = $('#cartTable tbody');
    //console.log("CartTab is:" + cartTab.html());
    //var tr = $('#cartTable tr').eq(index+1);
    //console.log("CartRow is:" + tr.html());
    let td = $('#btnDelete'+index);
   // console.log("CartData is:" + td.html());
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
        //console.log('Cart table is:'+$('#cartTable').html());
        //Iterate through rows, create JSON
        
        var jsonData = "{\"cart\": " + tableToJson() + " }";
        console.log("Json is " + jsonData);

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: 'http://localhost:3000/Service/CartService.svc/GetJSON',
            data: jsonData,
            success: function (r) {
                console.log('Success: ' + r.d);
                //Redirect if success
            },
            error: function (r) {
                console.log(r.responseText);
            },
            failure: function (r) {
                console.log('Error: '+ r);
            }
        }); 
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


function tableToJson() {

    var rows = [];
    $('table tr').each(function (i, n) {
        var $row = $(n);
        if (i != 0) {
            rows.push({
                itemCode: $row.find('td:eq(0)').text(),
               // description: $row.find('td:eq(1)').text(),
                quantity: $row.find('td:eq(2) input').val(),
               // uom: $row.find('td:eq(3)').text(),
            });
        }
    });
    return JSON.stringify(rows);
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

//OLD:
//function tableToJson() {
//    (function ($) {
//        var convertTableToJson = function () {
//            var rows = [];
//            $('table tr').each(function (i, n) {
//                var $row = $(n);
//                if (i != 0) {
//                    rows.push({
//                        itemCode: $row.find('td:eq(0)').text(),
//                        description: $row.find('td:eq(1)').text(),
//                        quantity: $row.find('td:eq(2) input').val(),
//                        uom: $row.find('td:eq(3)').text(),
//                    });
//                }
//            });
//            return JSON.stringify(rows);
//        };
//        $(function () {
//           console.log(convertTableToJson());
//            return convertTableToJson;
//        });
//    })(jQuery);
//}

