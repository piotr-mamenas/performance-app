var routing = function () {

    var mvc = [
        {
            Name: "Partner",
            Uri: "partners/"
        },
        {
            Name: "Contact",
            Uri: "contacts/"
        }
    ];

    var api = [
        {
            Name: "Partner",
            Uri:  "api/partners/"
        },
        {
            Name: "Contact",
            Uri: "api/contacts/"
        },
        {
            Name: "Account",
            Uri: "api/accounts/"
        },
        {
            Name: "Institution",
            Uri: "api/institutions/"
        },
        {
            Name: "Portfolio",
            Uri: "api/portfolios/"
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

    var getMvcUri = function (service) {
        return _.findWhere(mvc, { Name: service })["Uri"];
    };
    
    var buildUris = function (webServerUrl) {
        _.map(api, function (element, index) {
            api[index]["Uri"] = webServerUrl + element["Uri"];
        });

        _.map(mvc, function (element, index) {
            mvc[index]["Uri"] = webServerUrl + element["Uri"];
        });
    }

    var init = function (webServerUrl) {
        buildUris(webServerUrl);
    };

    return {
        init: init,
        getApiUri: getApiUri,
        getMvcUri: getMvcUri,
        getCurrentPage: getCurrentPage,
        setCurrentPage: setCurrentPage
    };
}();