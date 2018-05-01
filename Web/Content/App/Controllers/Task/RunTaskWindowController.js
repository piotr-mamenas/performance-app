var RunTaskWindowController = function () {

    var openWindow = function() {
        bootbox.dialog({
            title: "Run Task",
            onEscape: function () {
                $(".bootbox.modal").modal("hide");
            },
            message: $("#portfolioReturnsForm").html(),
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

    };

    return {
        init: init
    };
}