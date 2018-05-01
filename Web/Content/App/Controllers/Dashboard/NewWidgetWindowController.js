var NewWidgetWindowController = function(resourceService) {
    var availableIcons = [];

    var addIconImageDisplay = function () {
        availableIcons.forEach(function(icon) {
            $(".new-widget-icon-spinner").append("<span class='" + icon + "' display='none'></span>");
        });
        $(".new-widget-icon-spinner").first().show();
    }

    var onNewWidgetClick = function() {
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
                    callback: function() {

                    }
                }
            }
        });
    };

    var init = function() {
        $(".open-new-widget-window").parent("a").on("click", onNewWidgetClick);
        availableIcons = resourceService.getAvailableIcons(addIconImageDisplay, console.log);
    };

    return {
        init: init
    };
}(ResourceService);