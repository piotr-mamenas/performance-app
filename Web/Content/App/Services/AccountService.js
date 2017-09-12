var accountService = function () {
    var getAccounts = function (webServerUri) {
        return {
            url: webServerUri + "api/accounts",
            type: "GET",
            dataSrc: "",
            dataType: "json"
        }
    }

    return {
        getAccounts: getAccounts
    }
}();