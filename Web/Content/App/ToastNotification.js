var ToastNotification = function () {
    var notificationSelector;

    var init = function (selector) {
        notificationSelector = selector;
    };

    var notify = function (message) {
        console.log(message);
        if (typeof message === "string") {
            $(notificationSelector).html(message);
        } else {
            $(notificationSelector).html(message.responseJSON.ExceptionMessage);
        }
        $(notificationSelector).addClass("animating");
        $(notificationSelector).show();

        setTimeout(function() {
            $(notificationSelector).hide();
            $(notificationSelector).removeClass("animating");
        }, 3000);
    };

    return {
        init: init,
        notify: notify
    }
}();