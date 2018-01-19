﻿//Put custom JS here
//window.alert('text');

$(document).ready(
    showPopupCatalogueDetail()
);

$(document).ready(
    goCart()
);

function showPopupCatalogueDetail() {
    $(document).on("click", "[id*=btnAdd]", function () {
        populatePopOut(this);
        $("#dialog").dialog({
            title: "View Details",
            buttons: {
                //Show: function () {
                //    //For quantity refer to ID generated by numberPicker, not TextBox
                //    var quantity = $(".dpui-numberPicker-input").val();
                //    console.log(quantity);
                //    positiveInteger(quantity);
                //},
                Ok: function () {
                    var itemCode = $("#MainContent_lblItemCode").html();
                   // console.log('Item code is ' + itemCode);
                    var quantity = $(".dpui-numberPicker-input").val();
                   // console.log('Quantity is ' + quantity);
                    var description = $("#MainContent_lblDescription").html();
                    //console.log('Description is ' + description);
                    var uom = $("#MainContent_lblUOM").html();
                   // console.log('UOM is ' + uom);
                   // console.log(saveToCart(itemCode,description, quantity, uom) === true);

                    //Exit dialog if successful
                    if (saveToCart(itemCode,quantity) === true) {
                        $(this).dialog('close');
                    }
                },
                Cancel: function () {
                    //TODO: Clear Textbox
                    $(this).dialog('close');
                }
            },
            modal: true
        });
        //  window.alert($(".Category", $(this).closest("tr")).html());
        return false;
    });
}
function saveToCart(itemCode, quantity) {
    //Validation
    if (positiveInteger(quantity) === true) {

        var cart = new Object();
        // Create list in SessionState
        if (sessionStorage.cart) {
            cart = JSON.parse(sessionStorage.getItem('cart'));
            console.log("got cart");
        } else {
            console.log("no cart");
            cart = [];
        }
        //Save jSON(itemCode,quantity)
        var product = { "itemCode": itemCode, "quantity": quantity};
        var myJSON = JSON.stringify(product);
        //console.log('JSON is' + myJSON);
        cart.push(myJSON);
        sessionStorage.setItem('cart', JSON.stringify(cart));
        //Print list
        for (var i = 0; i < cart.length; i++) {
            console.log('List values:' + cart[i]);
        }

        return true;
        //TODO: Clear Textbox

    } else return false;
}

//Check positive Integer only for quantity
function positiveInteger(quantity) {

    var pattern = new RegExp(/^\d*[1-9]\d*$/);
    //console.log(text);

    if (pattern.test(quantity)) {
      //  console.log('Positive integer!');
        return true;
    }
    else {
        //console.log('Not positive integer!');
        return false;
    }
}
function populatePopOut(item) {
    $("#MainContent_lblCategory").html($(".Category", $(item).closest("tr")).html());
    $("#MainContent_lblDescription").html($(".Description", $(item).closest("tr")).html());
    $("#MainContent_lblUOM").html($(".UnitOfMeasure", $(item).closest("tr")).html());
    $("#MainContent_lblItemCode").html($(".ItemCode", $(item).closest("tr")).html());
    console.log('populatepopout():' + $(".ItemCode", $(item).closest("tr")).html());
}

//Go Cart Page
function goCart() {

    // var dataForServer = encodeURIComponent(sessionStorage.getItem(myKey));
    $(document).on("click", "[id*=imgCart]", function () {
        Service.Greeting(onSuccess);
       // postData();
        //window.location.href = "RequisitionCart.aspx";
        return false;
    });
}
function postData() {
    var data = {};
    data.ItemCode = "this";
    data.Quantity = "1";

    $.ajax({
        url: "/Service/Service.svc/GetJSON",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "data": data }),
        dataType: "json",
        success: function (result) {
            console.log("Success"+ result);
            
        },
        error: function (error) {
            alert("Error: " + error.Error);
        }
    });
}
function onSuccess(result) {
    alert(result);
}  

//For number picker
var OPTIONS = {
    // initial value
    start: 0,

    // minimum value
    min: 0,

    // maximum value
    max: false,

    // amount of increment on each step
    step: 1,

    // custom number format
    format: false,

    // number formtatter
    formatter: function (x) { return x; },

    // increase/decrease text
    increaseText: "+",
    decreaseText: "-",

    // callbacks
    onReady: function () { },
    onMin: function () { },
    onMax: function () { },
    beforeIncrease: function () { },
    beforeDecrease: function () { },
    beforeChange: function () { },
    afterIncrease: function () { },
    afterDecrease: function () { },
    afterChange: function () { }
};
$(document).ready(function () {
    dpUI.numberPicker("#np", OPTIONS);

});


//function saveToCartOld(itemCode, description, quantity, uom) {
//    //Validation
//    if (positiveInteger(quantity) === true) {

//        var cart = new Object();
//        // Create list in SessionState
//        if (sessionStorage.cart) {
//            cart = JSON.parse(sessionStorage.getItem('cart'));
//            console.log("got cart");
//        } else {
//            console.log("no cart");
//            cart = [];
//        }
//        //Save jSON(itemCode,quantity)
//        var product = { "itemCode": itemCode, "description": description, "quantity": quantity,"uom": uom };
//        var myJSON = JSON.stringify(product);
//        //console.log('JSON is' + myJSON);
//         cart.push(myJSON);
//         sessionStorage.setItem('cart', JSON.stringify(cart));
//         //Print list
//         for (var i = 0; i < cart.length; i++) {
//           console.log('List values:' + cart[i]);
//        }

//        return true;
//        //TODO: Clear Textbox

//    } else return false;
//}
