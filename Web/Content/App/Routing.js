var Routing = function () {

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
            Name: "ExchangeRate",
            Uri: "api/exchangerates/"
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
        },
        {
            Name: "Asset",
            Uri: "api/assets/"
        },
        {
            Name: "Report",
            Uri: "api/reports/"
        },
        {
            Name: "Task",
            Uri: "api/tasks/"
        },
        {
            Name: "Resource",
            Uri: "api/resources/"
        },
        {
            Name: "Widget",
            Uri: "api/widget/"
        }
    ];

    var getCurrentPage = function () {
        return localStorage.getItem("currentRoute");
    };

    var setCurrentPage = function (selector) {
        localStorage.setItem("currentRoute", selector);
    };

    var getApiUri = function (service) {
        return _.findWhere(api, { Name: service })["Uri"];
    };

    var getMvcUri = function (service) {
        return _.findWhere(mvc, { Name: service })["Uri"];
    };

    var buildUris = function(webServerUrl) {
        _.map(api,
            function(element, index) {
                api[index]["Uri"] = webServerUrl + element["Uri"];
            });

        _.map(mvc,
            function(element, index) {
                mvc[index]["Uri"] = webServerUrl + element["Uri"];
            });
    };

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