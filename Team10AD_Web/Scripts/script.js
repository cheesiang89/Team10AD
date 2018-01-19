//Put custom JS here
//window.alert('text');

$(document).ready(
    showPopupCatalogueDetail()
);


function showPopupCatalogueDetail() {
    $(document).on("click", "[id*=btnAdd]", function () {
        populatePopOut(this);
        $("#dialog").dialog({
            title: "View Details",
            buttons: {
                Show: function () {
                    var quantity = $("[id*='txtInputQty']").val();
                    console.log(quantity);
                    positiveInteger(quantity);
                },
                Ok: function () {
                    //TODO: Cannot get Item Code
                    var itemcode = $("[id*='lblitemcode']").val();
                    console.log('item code is ' + itemcode);
                    var quantity = $("[id*='txtInputQty']").val();
                    console.log('Quantity is ' + quantity);

                    //Exit dialog if successful
                    if (saveToCart(itemCode, quantity) === true) {
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
        //SessionState
        //1. Save jSON(itemCode,quantity)
        var product = { "itemCode": "C001", "quantity": "txt" };
        var myJSON = JSON.stringify(product);
        console.log(myJSON);
        //2. Save quantity
        //var list = ["foo", "bar"];
        //list.push(text);
        return true;
        //Clear Textbox


    }
}
//Check positive Integer only for quantity
function positiveInteger(quantity) {

    var pattern = new RegExp(/^\d*[1-9]\d*$/);
    //console.log(text);

    if (pattern.test(quantity)) {
        console.log('Positive integer!');
        return true;
    }
    else {
        console.log('Not positive integer!');
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

//For number picker
$(document).ready(function () {
    dpUI.numberPicker("#np", OPTIONS);
});

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