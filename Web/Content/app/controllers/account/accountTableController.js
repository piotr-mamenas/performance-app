var accountTableController = function (service) {

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
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function () {
        service.getAccounts(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(accountService)