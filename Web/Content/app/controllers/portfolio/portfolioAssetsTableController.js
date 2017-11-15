var portfolioAssetsTableController = function (service) {

    var initializeDatatable = function (result) {
        $("#portfolioAssetsTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Assets."
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
        service.getPortfolioAssets(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(portfolioService)