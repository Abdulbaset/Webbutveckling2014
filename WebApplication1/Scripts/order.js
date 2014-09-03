
$(document).ready(function() {

    $("#dishes-list").on("click", ".increase-qty", function(e) {

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

    $("#dishes-list").on("click", ".decrease-qty", function(e) {

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
        "            <li class='order-row'>" +
        "               <div class='col-md-2 inline'>" +
        "                   <input type='hidden' class='dish-id'>" +
        "                   <input type='text' class='quantity-box' value='0'>" +
        "                   <button class='glyphicon glyphicon-plus increase-qty'></button>" +
        "                   <button class='glyphicon glyphicon-minus decrease-qty'></button>" +
        "               </div>" +
        "               <div class='col-md-5 inline'>" +
        "                   <span class='dish-name'>Namn</span>" +
        "               </div>" +
        "               <div class='col-md-2 inline'>" +
        "                   <span class='dish-price'>Pris</span>" +
        "               </div>" +
        "               <div class='col-md-3 inline'>" +
        "                   <span class='validation-message'></span>" +
        "               </div>" +
        "           </li>";

    var onGetDishesSuccess = function(data) {

        $(".test").text(JSON.stringify(data));

        var dishesList = $("#dishes-list");

        for (var i = 0; i < data.length; i++) {

            var listItem = $(template);
            dishesList.append(listItem);

            var dish = data[i];

            var idInput = $(".dish-id", listItem);
            idInput.val(dish.Id);

            var nameSpan = $(".dish-name", listItem);
            nameSpan.text(dish.Name);

            var priceSpan = $(".dish-price", listItem);
            priceSpan.text(dish.Price);
        }
    }

    var options = {
        type: "GET",
        success: onGetDishesSuccess,
    }

    $.ajax("/Order/GetDishes", options);

    var onSubmitSuccess = function(data) {
        $(".test").text(JSON.stringify(data));
        var anchor = $("<a href=''>Bekräftelse</a>");
        anchor.attr("href", data.confirmLink);
        $(".test").append(anchor);
    }

    // skicka data
    $("#submit").click(function() {

        // validering??
        var email = $(".email").val();

        var orderRows = $(".order-row");

        // ajax-anropet

        var data = {
            email: email,
            dishes: []
        }

        for (var i = 0; i < orderRows.length; i++) {
            var orderRow = $(orderRows[i]);

            var id = orderRow.find(".dish-id").val();
            var quantity = orderRow.find(".quantity-box").val();

            data.dishes.push({ id: id, quantity: quantity });
        }

        var options = {
            type: "POST",
            success: onSubmitSuccess,
            error: function(error) { console.log(error); },
            data: data
        }

        $.ajax("/Order/Submit", options);
    });

})