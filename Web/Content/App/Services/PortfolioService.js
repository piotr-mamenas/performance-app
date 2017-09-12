var portfolioService = function () {
    var getPortfolios = function (webServerUri) {
        return {
            url: webServerUri + "api/portfolios",
            type: "GET",
            dataSrc: "",
            dataType: "json"
        }
    }

    return {
        getPortfolios: getPortfolios
    }
}();