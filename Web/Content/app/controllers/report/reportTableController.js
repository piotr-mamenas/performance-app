var portfolioTableController = function (service) {
    var button;
    var table;

    var initializeDatatable = function (result) {
        table = $("#reportTable").DataTable({
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
        service.getPortfolios(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(reportService)