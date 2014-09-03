

var onSuccess = function(data) {
    $(".data").text(JSON.stringify(data));
}

var onError = function(error) {
     console.log(error);
}

var klickhanterare = function () {

    var options = {
        type: "GET",
        success: onSuccess,
        error: onError
    }

    $.ajax("/TestData", options);
}

$(".clickme").click(klickhanterare);


var onSendSuccess = function() {
    console.log("send ok");
}

var onSendClick = function() {

    var options = {
        type: "POST",
        data: { greeting: "Hello, server!" },
        success: onSendSuccess,
        error: onError
    }

    $.ajax("/TestData/Send", options);

}

$(".send-btn").click(onSendClick);