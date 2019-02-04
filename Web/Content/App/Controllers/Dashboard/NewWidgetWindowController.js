var NewWidgetWindowController = function(resourceService, widgetService, toastNotification) {
    var availableIcons = [];
    var currentlySelectedIconId = 0;

    var appendIcon = function() {
        $(".new-widget-icon-spinner").empty();
        $(".new-widget-icon-spinner").append("<span class='" + availableIcons[currentlySelectedIconId] + "'></span>");
    };

    var onLeftCaretClick = function (e) {
        e.preventDefault();
        currentlySelectedIconId -= 1;
        if (currentlySelectedIconId < 0) {
            currentlySelectedIconId = availableIcons.length - 1;
        }
        appendIcon();
    };

    var onRightCaretClick = function (e) {
        e.preventDefault();
        currentlySelectedIconId += 1;
        if (currentlySelectedIconId >= availableIcons.length) {
            currentlySelectedIconId = 0;
        }
        appendIcon();
    };

    var onNewWidgetClick = function () {
        bootbox.dialog({
            title: "Create New Widget",
            onEscape: function () {
                $(".bootbox.modal").modal("hide");
            },
            message: function () {
                var formHtml = $("#newWidgetForm").html();
                return formHtml;
            },
            buttons: {
                cancel: {
                    label: "<i class='fa fa-times'></i> Cancel",
                    className: "btn-danger"
                },
                confirm: {
                    label: "<i class='fa fa-check'></i> Confirm",
                    className: "btn-primary",
                    callback: function () {
                        var modalSelector = $(".modal-dialog");

                        var newWidget = {
                            name: modalSelector.find(".js-new-widget-name").val(),
                            bookmark: null,
                            icon: modalSelector.find(".new-widget-icon-spinner").children("span").attr("class")
                        };
                        widgetService.createWidget(newWidget, function() {
                            toastNotification.notify("Widget created successfully");
                            window.location.reload(false);
                        }, function () {
                            toastNotification.notify("Encountered error: " + data, "error");
                        });
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
}(ResourceService, WidgetService, ToastNotification);