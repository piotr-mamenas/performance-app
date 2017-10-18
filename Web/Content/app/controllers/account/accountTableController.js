var accountTableController = function (service) {
    var button;
    var table;

    var initializeDatatable = function (result) {
        $("#accountTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Number"
                },
                {
                    data: "DateOpened"
                },
                {
                    data: "DateClosed"
                },
                {
                    data: "Id",
                    render: function (data) {
                        return "<a href=\"" + "update/" + data + "\" class=\"btn btn-default btn-block\"><span class='fa fa-pencil'></span>";
                    }
                },
                {
                    data: "Id",
                    render: function (data) {
                        return "<button href=\"#\" data-account-id=\"" + data + "\" class=\"btn btn-default btn-block account-delete-account\"><span class='fa fa-trash'></span></button>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var deleteSelectedRow = function (e) {
        button = $(e.target);

        service.deleteAccount(button.attr("data-account-id"),
            function () {
                table.row(button.parents("tr"))
                    .remove()
                    .draw();
            },
            function () {
                alert("Unexpected Error");
            });
    };

    var openDeletePrompt = function (e) {

        bootbox.confirm({
            title: "Delete account?",
            message: "Are you sure you want to delete this account? This cannot be undone.",
            buttons: {
                cancel: {
                    label: "<i class=\"fa fa-times\"></i> Cancel"
                },
                confirm: {
                    label: "<i class=\"fa fa-check\"></i> Confirm"
                }
            },
            callback: function (isConfirmed) {
                if (isConfirmed === true) {
                    deleteSelectedRow(e);
                }
            }
        });
    };

    var init = function () {
        var loadDatatable = function (result) {
            initializeDatatable(result);
            $(".account-delete-account").on("click", openDeletePrompt);
        }
        service.getAccounts(loadDatatable, loadDatatable);
    }

    return {
        init: init
    };

}(accountService)