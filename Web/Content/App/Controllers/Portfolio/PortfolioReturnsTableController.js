var PortfolioReturnsTableController = function(service) {
    var table;

    var initializeDatatable = function(result) {
        table = $("#portfolioReturnsTable").DataTable({
            data: result,
            columns: [
                {
                    data: "AssetName"
                },
                {
                    data: "ClassName"
                },
                {
                    data: "Isin"
                },
                {
                    data: "HoldingPeriodReturn"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function(id) {
        service.getAssetsByPortfolios(id, initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(AssetService);