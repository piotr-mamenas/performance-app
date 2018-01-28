var PortfolioReturnsTableController = function (service) {
    var table;

    var initializeDatatable = function (result) {
        table = $("#portfolioTable").DataTable({
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

}(PortfolioService)