var assetService = function (routing) {
    var getAssetsByPortfolios = function (portfolioId, done, fail) {
        $.ajax({
            url: routing.getApiUri("Asset") + "byportfolios/" + portfolioId,
                type: "GET",
                dataSrc: "",
                dataType: "json"
            }).done(done)
            .fail(fail);
    };

    return {
        getAssetsByPortfolios: getAssetsByPortfolios
    }
}(routing);