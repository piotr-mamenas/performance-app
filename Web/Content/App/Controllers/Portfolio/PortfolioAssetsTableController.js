var PortfolioAssetsTableController = function(service) {
    var table;

    var initializeDatatable = function(result) {
        table = $("#portfolioAssetsTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Class"
                },
                {
                    data: "Isin"
                },
                {
                    data: "CurrentPrice"
                },
                {
                    data: "CurrencyCode"
                },
                {
                    data: "HoldingPeriodReturnRate"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    };

    var init = function(id) {
        service.getAssetsByPortfolios(id, initializeDatatable, initializeDatatable);
    };

    return {
        init: init
    };

}(AssetService);