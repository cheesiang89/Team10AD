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
       // console.log('2nd page List values:' + cart[i]);
        var obj = JSON.parse(cart[i]);
        //console.log('2nd page JSON object: ' + obj.itemCode);
        addRow(obj,i);
    }
});
//Save cart, create Requisition
$(document).ready(
    makeRequisition()
);
//Empty Cart
$(document).ready(
   emptyCart()
);

//Test
$(document).ready(
   
);
function addRow(obj, index) {
       $('<tr>').html(
        //"<tr>" +
           "<td>" + obj.itemCode+"</td><td>"
        + obj.description + "</td><td>"
           + "<input type=text id='txtInput" + index
           + "' class='txtInput' onKeyUp='return saveCartSession()'></input><div class='lblError'"
           + "style='color:red'>Positive Integer only</div></td><td>"
        //+ obj.quantity + "</td><td>"
        + obj.uom + "</td><td id='btnDevare"+index+"'></td></tr>").appendTo('#cartTable tbody');

    //Make quantity editable
       $('#txtInput' + index).val(obj.quantity);
    //Hide warning labels
       $('.lblError').hide();
      // console.log($('div').val());
       //console.log('Quantity: ' + obj.quantity);

    //Add Button
    addButton(index);
    
}
//Loop through rows and append button
function addButton(index) {
     //Make DEvarE Button 
    //var cartTab = $('#cartTable tbody');
    //console.log("CartTab is:" + cartTab.html());
    //var tr = $('#cartTable tr').eq(index+1);
    //console.log("CartRow is:" + tr.html());
    var td = $('#btnDevare'+index);
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

// DEvarE TABLE ROW.
function removeRow(oButton) {
    var cartTab = document.getElementById('cartTable');
    cartTab.deleteRow(oButton.parentNode.parentNode.rowIndex);       // BUTTON -> TD -> TR.
    saveCartSession();
}

function makeRequisition() {
    $(document).on("click", "[id*=btnSubmitRequisition]", function () {
        //console.log('Cart table is:'+$('#cartTable').html());
        //Iterate through rows, create JSON
        if (qtyGotError() === false) {
            let jsonData = "{\"cart\": " + tableToJson() + " }";
            console.log("Json is " + jsonData);

            $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: 'http://localhost:3000/Service/CartService.svc/GetJSON',
                data: jsonData,
                success: function (r) {
                    console.log('Success: ' + r.d);
                    //Devare session data
                    deleteCartSession();
                    //Redirect if success
                   // window.location.href = "RequisitionStatus.aspx";
                },
                error: function (r) {
                    console.log(r.responseText);
                },
                failure: function (r) {
                    console.log('Error: ' + r);
                }
            });
        } else { console.log("Error with qty");}
        return false;
    });
}
function emptyCart() {
    $(document).on("click", "[id*=btnEmptyCart]", function () {
        deleteCartSession();
        //Delete Table
        $("#cartTable").find("tr:gt(0)").remove();
        return false;
    });
}
function deleteCartSession() {
    if (sessionStorage.cart) {
        sessionStorage.removeItem('cart');
    }
}

function tableToJson() {
    let reqID = $('input[id$=reqID]').val().toString();
    //console.log("Requestor id is: "+ reqID);
    var rows = [];
    $('table tr').each(function (i, n) {
        let $row = $(n);
        if (i != 0) {
            rows.push({
                itemCode: $row.find('td:eq(0)').text(),
                description: $row.find('td:eq(1)').text(),
                quantity: $row.find('td:eq(2) input').val(),
                uom: $row.find('td:eq(3)').text(),

                //Save employee id here
                reqid: reqID,
            });
        }
    });
    return JSON.stringify(rows);
}

function saveCartSession() {
    //$(document).on("click", "[id*=btnTest]", function () {
        //Create JSON string 
        var savedState = JSON.parse(tableToJson());
        var savedCart = [];
        for (var i = 0; i < savedState.length; i++) {
   
            var product = {
                "itemCode": savedState[i]["itemCode"],
                "description": savedState[i]["description"],
                "quantity": savedState[i]["quantity"],
                "uom": savedState[i]["uom"]
            };
            var myJSON = JSON.stringify(product);
            //console.log("Showing session data:" + product["itemCode"]);
            savedCart.push(myJSON);
        }
        
        deleteCartSession();
        sessionStorage.setItem('cart', JSON.stringify(savedCart));
        return false;
    //});
}
function qtyGotError() {
    
    var gotError = false;
    $(".txtInput").each(function () {
        var input = $(this).val();
        
        if (!positiveInteger(input)) {
            $(this).next().show();
            gotError = true;
        } else {
            $(this).next().hide();
        }
            //console.log("Is positive?"+input);
    });
   
        return gotError;
}


