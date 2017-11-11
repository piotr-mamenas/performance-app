var taskTableController = function (service) {
    var table;
    var button;

    var initializeDatatable = function (result) {
        table = $("#taskTable").DataTable({
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

    var init = function () {
        service.getTaskRuns(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(portfolioService)