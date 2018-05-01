var ExchangeRateService = function (routing) {

    var getExchangeRates = function (done, fail) {
        $.ajax({
                url: routing.getApiUri("ExchangeRate"),
                type: "GET",
                dataSrc: "",
                dataType: "json"
            }).done(done)
            .fail(fail);
    };

    return {
        getExchangeRates: getExchangeRates
    }
}(Routing);