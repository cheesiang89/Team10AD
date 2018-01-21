﻿//Put custom JS here
//window.alert('text');
$(document).ready(
    $('#notifyAdded').hide()
);

$(document).ready(
    showPopupCatalogueDetail()
);

$(document).ready(
    goCart()
);
function showPopupCatalogueDetail() {
    $(document).on("click", "[id*=btnAdd]", function () {
        $('#warningAddToCart').hide();
        populatePopOut(this);
        $("#dialog").dialog({
            title: "View Details",
            buttons: {
                //Show: function () {
                //    //For quantity refer to ID generated by numberPicker, not TextBox
                //    let quantity = $(".dpui-numberPicker-input").val();
                //    console.log(quantity);
                //    positiveInteger(quantity);
                //},
                Ok: function () {
                    let itemCode = $("#MainContent_lblItemCode").html();
                   // console.log('Item code is ' + itemCode);
                    let description = $("#MainContent_lblDescription").html();
                    //console.log('Description is ' + description);
                    let quantity = $(".dpui-numberPicker-input").val();
                   // console.log('Quantity is ' + quantity);
                 
                    let uom = $("#MainContent_lblUOM").html();
                   // console.log('UOM is ' + uom);
                   // console.log(saveToCart(itemCode,description, quantity, uom) === true);

                    //Exit dialog if successful
                    if (saveToCart(itemCode, description, quantity, uom) === true) {
                         //Clear Textbox
                        $(".dpui-numberPicker-input").val(0);
                        $(this).dialog('close');
                        //Show success
                        $.alert("Item Added", {

                            // auto close
                            autoClose: true,

                            // auto close time
                            closeTime: 2000,
                            // Position, the first position, followed by offset, if it is between 1 and -1 percentage
                           position: ['center', [-200,400]],
                           
                        })
                    } else {
                        //Show warning
                        $('#warningAddToCart').show();
                        console.log($('#warningAddToCart').html());
                    }
                },
                Cancel: function () {
                    //Clear Textbox
                    $(".dpui-numberPicker-input").val(0);
                    $(this).dialog('close');
                }
            },
            modal: true
        });
        //  window.alert($(".Category", $(this).closest("tr")).html());
        return false;
    });
}
function saveToCart(itemCode, description, quantity, uom) {
    //Validation
    if (positiveInteger(quantity) === true) {

        let cart = new Object();
        // Create list in SessionState
        if (sessionStorage.cart) {
            cart = JSON.parse(sessionStorage.getItem('cart'));
            console.log("got cart");
        } else {
            console.log("no cart");
            cart = [];
        }
        //Save jSON(itemCode,quantity)
        let product = { "itemCode": itemCode, "description": description, "quantity": quantity, "uom":uom };
        let myJSON = JSON.stringify(product);
        //console.log('JSON is' + myJSON);
        cart.push(myJSON);
        sessionStorage.setItem('cart', JSON.stringify(cart));
        //Print list
        //for (var i = 0; i < cart.length; i++) {
        //    console.log('List values:' + cart[i]);
        //}
       console.log("Cart JSON String is: " + sessionStorage.getItem('cart'));
        
        return true;
      

    } else return false;
}

//Check positive Integer only for quantity
function positiveInteger(quantity) {

    let pattern = new RegExp(/^\d*[1-9]\d*$/);
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
  
    $("#spinner").html("<div id=\"np\"></div >");
    dpUI.numberPicker("#np", OPTIONS);
    //console.log('populatepopout():' + $(".ItemCode", $(item).closest("tr")).html());
}

//Go Cart Page
function goCart() {

    // let dataForServer = encodeURIComponent(sessionStorage.getItem(myKey));
    $(document).on("click", "[id*=imgCart]", function () {
      // CartService.Greeting(onSuccess);
         window.location.href = "RequisitionCart.aspx";
        return false;
    });
}

//function onSuccess(result) {
//    alert(result);
//}  


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
    onReady: function () {
     },
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

