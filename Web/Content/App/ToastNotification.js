var ToastNotification = function () {
    var notificationSelector;

    var init = function (selector) {
        notificationSelector = selector;
        Message.parent = document.getElementsByClassName("prophet")[0];
    };

    var notify = function (message, msgType) {
        var displayMessage;
        if (typeof message === "string") {
            displayMessage = message;
        } else {
            displayMessage = message.responseJSON.ExceptionMessage;
        }

        if (!msgType) {
            msgType = "default";
        }

        var toast = new Message(displayMessage, { type: msgType });
        toast.show();
    };

    return {
        init: init,
        notify: notify
    };
}();