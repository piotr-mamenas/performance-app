var portfolioAssetsTableController = function (service) {

    var initializeDatatable = function (result) {
        $("#portfolioTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: ""
                },
                {
                    data: "Account.Number"
                },
                {
                    data: "Account.Partner.Name"
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

}(portfolioService)