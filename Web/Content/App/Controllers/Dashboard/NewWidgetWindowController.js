var NewWidgetWindowController = function(resourceService) {
    var availableIcons = [];
    var currentlySelectedIconId = 0;

    var appendIcon = function () {
        $(".new-widget-icon-spinner").empty();
        $(".new-widget-icon-spinner").append("<span class='" + availableIcons[currentlySelectedIconId] + "'></span>");
    }

    var onLeftCaretClick = function (e) {
        e.preventDefault();
        currentlySelectedIconId = currentlySelectedIconId - 1;
        if (currentlySelectedIconId === -1) {
            currentlySelectedIconId = availableIcons.length - 1;
        }
        appendIcon();
    };

    var onRightCaretClick = function (e) {
        e.preventDefault();
        currentlySelectedIconId = currentlySelectedIconId + 1;
        if (currentlySelectedIconId >= availableIcons.length) {
            currentlySelectedIconId = 0;
        }
        appendIcon();
    };

    var onNewWidgetClick = function () {
        bootbox.dialog({
            title: "Create New Widget",
            onEscape: function() {
                $(".bootbox.modal").modal("hide");
            },
            message: $("#newWidgetForm").html(),
            buttons: {
                cancel: {
                    label: "<i class='fa fa-times'></i> Cancel",
                    className: "btn-danger"
                },
                confirm: {
                    label: "<i class='fa fa-check'></i> Confirm",
                    className: "btn-primary",
                    callback: function () {
                        // TODO: Solve issue with 2 windows
                        var widgetName = $(".js-new-widget-name");//.val();
                        var widgetUrl = $(".js-new-widget-url");//.val();
                        var widgetIcon = $(".js-widget-icon-spinner").children("span").attr("class");
                        console.log(widgetName);
                        console.log(widgetUrl);
                        console.log(widgetIcon);
                    }
                }
            }
        });
        $(".new-widget-caret-left").on("click", onLeftCaretClick);
        $(".new-widget-caret-right").on("click", onRightCaretClick);
    };

    var init = function() {
        $(".open-new-widget-window").parent("a").on("click", onNewWidgetClick);
        resourceService.getAvailableLargeIconClasses(function(data) {
            availableIcons = data;
            appendIcon();
        }, console.log);
    };

    return {
        init: init
    };
}(ResourceService);