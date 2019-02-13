var AssetPriceTableController = function(service) {
    var table;

    var initializeDatatable = function(result) {
        table = $("#assetPriceTable").DataTable({
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
                    data: "Amount"
                },
                {
                    data: "CurrencyCode"
                },
                {
                    data: "Timestamp"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    };

    var init = function() {
        service.getAssetPrices(initializeDatatable, initializeDatatable);
    };

    return {
        init: init
    };

}(AssetService);