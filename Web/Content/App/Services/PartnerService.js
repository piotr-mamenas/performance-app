var partnerService = function () {
    var getPartners = function (webServerUri) {
        return {
            url: webServerUri + "api/partners",
            type: "GET",
            dataSrc: "",
            dataType: "json"
        }
    }

    return {
        getPartners: getPartners
    }
}();