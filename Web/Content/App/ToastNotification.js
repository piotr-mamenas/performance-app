var ToastNotification = function () {
    var notificationSelector;

    var init = function (selector) {
        notificationSelector = selector;
    };

    var notify = function (message) {
        $(notificationSelector).html = message;
        $(notificationSelector).show();

        setTimeout(function() {
            $(notificationSelector).hide();
        }, 3000);
    };

    return {
        init: init,
        notify: notify
    }
}();