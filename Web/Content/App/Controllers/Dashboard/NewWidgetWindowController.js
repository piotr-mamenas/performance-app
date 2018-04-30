var NewWidgetWindowController = function() {

    var onNewWidgetClick = function() {
        bootbox.dialog({
            title: "Create New Widget",
            onEscape: function() {
                $(".bootbox.modal").modal("hide");
            },
            message: $("#newWidgetForm").html(),
            buttons: {
                cancel: {
                    label: "<i class=\"fa fa-times\"></i> Cancel",
                    className: "btn-danger"
                },
                confirm: {
                    label: "<i class=\"fa fa-check\"></i> Confirm",
                    className: "btn-primary",
                    callback: function() {

                    }
                }
            }
        });
    };

    var init = function() {
        $(".open-new-widget-window").parent("a").on("click", onNewWidgetClick);
        console.log($(".open-new-widget-window").parent("a"));
    };

    return {
        init: init
    };
}();