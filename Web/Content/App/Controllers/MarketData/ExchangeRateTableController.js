var ExchangeRateTableController = function(service) {
    var table;

    var initializeDatatable = function(result) {
        table = $("#exchangeRateTable").DataTable({
            data: result,
            columns: [
                {
                    data: "BaseCurrency.Code"
                },
                {
                    data: "TargetCurrency.Code"
                },
                {
                    data: "Rate"
                },
                {
                    data: "Min"
                },
                {
                    data: "Max"
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
        service.getExchangeRates(initializeDatatable, initializeDatatable);
    };

    return {
        init: init
    };

}(ExchangeRateService);