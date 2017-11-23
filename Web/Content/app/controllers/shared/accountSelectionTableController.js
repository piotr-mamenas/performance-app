var accountSelectionTableController = function (service) {
    var table;
    var box;

    var showAccountSelection = function() {
        var container = $("accountSelectionTableContainer").clone();
        container.find("table").attr("id", "accountSelectionTable");

        box = bootbox.dialog({
            show: false,
            message: container.html(),
            title: "DataTables in a Bootbox",
            buttons: {
                ok: {
                    label: "OK",
                    className: "btn-primary",
                    callback: function () {
                        console.log("OK Button");
                    }
                },
                cancel: {
                    label: "Cancel",
                    className: "btn-default"
                }
            }
        });
    };

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

    box.on("shown.bs.modal", function () {
        service.getAccounts(initializeDatatable, initializeDatatable);
    });

    box.modal("show");

    $("#accountSelectionTable tbody").on("click", "tr", function () {
        $(this).toggleClass("active");
    });

    var init = function () {
        $("#openAccountSelectionButton").on("click", showAccountSelection);
    }

    return {
        init: init
    };

}(accountService)