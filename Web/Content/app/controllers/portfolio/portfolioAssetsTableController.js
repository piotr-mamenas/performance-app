var portfolioAssetsTableController = function (service) {
    var table;

    var initializeDatatable = function (result) {
        table = $("#portfolioAssetsTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Assets.Name"
                },
                {
                    data: "Assets.Class"
                },
                {
                    data: "Assets.Isin"
                },
                {
                    data: "Assets.CurrentPrice"
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