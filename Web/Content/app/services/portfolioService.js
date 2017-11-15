var portfolioService = function (routing) {

    var getPortfolios = function (done, fail) {
        $.ajax({
            url: routing.getApiUri("Portfolio"),
            type: "GET",
            dataSrc: "",
            dataType: "json"
            }).done(done)
              .fail(fail);
    };

    return {
        getPortfolios: getPortfolios
    }
}(routing);