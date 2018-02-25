var PortfolioReturnsTableController = function(service) {
    var table;

    var initializeDatatable = function (result) {
        if (table != null) {
            table.destroy();
        }
        table = $("#portfolioReturnsTable").DataTable({
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
                    data: "HoldingPeriodReturnRate"
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