
$(document).ready(function() {

    $(".increase-qty").click(function(e) {

        var input = $(this).parent().find(".quantity-box");

        var originalvalue = parseInt(input.val());

        if (isNaN(originalvalue)) {
            originalvalue = 0;
        }

        if (originalvalue < 10) {
            var newValue = originalvalue + 1;
            input.val(newValue);
        }

        e.preventDefault();
        return false;
    });

    $(".decrease-qty").click(function(e) {

        var input = $(this).parent().find(".quantity-box");

        var originalvalue = parseInt(input.val());

        if (isNaN(originalvalue)) {
            originalvalue = 1;
        }

        if (originalvalue > 0) {
            var newValue = originalvalue - 1;
            input.val(newValue);
        }

        e.preventDefault();
        return false;
    });

    // hämta data

    var template = "" +
        "            <li>" +
        "               <div class='col-md-2 inline'>" +
        "                   <input type='hidden'>" +
        "                   <input type='text' class='quantity-box'>" +
        "                   <button class='glyphicon glyphicon-plus increase-qty'></button>" +
        "                   <button class='glyphicon glyphicon-minus decrease-qty'></button>" +
        "               </div>" +
        "               <div class='col-md-5 inline'>" +
        "                   <span class='dish-name'></span>" +
        "               </div>" +
        "               <div class='col-md-2 inline'>" +
        "                   <span class='dish-price'></span>" +
        "               </div>" +
        "               <div class='col-md-3 inline'>" +
        "                   <span class='validation-message'></span>" +
        "               </div>" +
        "           </li>";

    var onGetDishesSuccess = function(data) {
        
    }

    var options = {
        type: "GET",
        success: onGetDishesSuccess,    }

    $.ajax("/Order/GetDishes", options);

    // skicka data
    $("#submit").click(function() {

        // validering??

        // ajax-anropet
        //var options = {
        //    type: "POST",
        //    success: function() {},
        //    error: function (){},
        //    data: {
        //            dishes: [
        //            {
        //                id: ...,
        //                quantity: ...
        //            }, 
        //            ...
        //        ],
        //        email: $(".email").val()
        //    }
        //}
        //$.ajax("/Order/SubmitOrder", options);
    });

})