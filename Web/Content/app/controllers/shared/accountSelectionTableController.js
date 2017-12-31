var AccountSelectionTableController = function (service) {
    var table;
    var box;

    var initializeDatatable = function (result) {
        table = $("#accountSelectionTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Number"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var loadSelection = function () {
        service.getAccounts(initializeDatatable, initializeDatatable);
    };

    var showAccountSelection = function() {
        var container = $("#accountSelectionTableContainer").clone();
        container = container.find("table").attr("id", "accountSelectionTable");

        box = bootbox.dialog({
            show: true,
            message: container.html(),
            title: "Select an Account",
            buttons: {
                cancel: {
                    label: "<i class='fa fa-times'></i> Cancel",
                    className: "btn-default"
                },
                ok: {
                    label: "<i class='fa fa-check'></i> OK",
                    className: "btn-primary",
                    callback: function () {
                        console.log("OK Button");
                    }
                }
            }
        });

        if (table == null || table === undefined) {
            $("div.bootbox.modal").on("shown.bs.modal", loadSelection);
        }
    };

    var highlightRow = function () {
        $(this).toggleClass("active");
    };
    
    var init = function () {
        $("#openAccountSelectionButton").on("click", showAccountSelection);
        $("#accountSelectionTable tbody").on("click", "tr", highlightRow);
    }

    return {
        init: init
    };

}(AccountService)