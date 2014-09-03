
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
    var options = {
        type: "GET",

    }
    $.ajax("/Order/GetDishes", options);

})