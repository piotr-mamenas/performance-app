var PortfolioService = function (routing) {

    var getPortfolios = function (done, fail) {
        $.ajax({
            url: routing.getApiUri("Portfolio"),
            type: "GET",
            dataSrc: "",
            dataType: "json",
            xhrFields: { withCredentials: true }
            }).done(done)
              .fail(fail);
    };

    return {
        getPortfolios: getPortfolios
    };
}(Routing);