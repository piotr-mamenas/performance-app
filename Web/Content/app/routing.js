var routing = function () {

    var api = [
        {
            Name: "Partner",
            Uri:  "api/partners/"
        },
        {
            Name: "Contact",
            Uri: "api/contacts/"
        }
    ];

    var getCurrentPage = function () {
        return $("div#app-body").data("currentPage");
    };

    var setCurrentPage = function (selector) {
        $("div#app-body").data("currentPage", selector);
    };

    var getApiUri = function (service) {
        return _.findWhere(api, { Name: service })["Uri"];
    };

    var buildUris = function (webServerUrl) {
        _.map(api, function (element, index) {
            api[index]["Uri"] = webServerUrl + element["Uri"];
        });
    }

    var init = function (webServerUrl) {
        buildUris(webServerUrl);
    };

    return {
        init: init,
        getApiUri: getApiUri,
        getCurrentPage: getCurrentPage,
        setCurrentPage: setCurrentPage
    };
}();