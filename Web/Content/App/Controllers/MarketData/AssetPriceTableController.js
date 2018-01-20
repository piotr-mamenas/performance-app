var AssetPriceTableController = function (service) {
    var table;

    var initializeDatatable = function (result) {
        table = $("#assetPriceTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Asset.Name"
                },
                {
                    data: "Asset.Class"
                },
                {
                    data: "Asset.Isin"
                },
                {
                    data: "Amount"
                },
                {
                    data: "Currency.Code"
                },
                {
                    data: "Timestamp"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function () {
        service.getAssetPrices(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(AssetService)