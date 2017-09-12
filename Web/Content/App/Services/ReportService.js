var reportService = function () {
    var getReports = function (webServerUri) {
        return {
            url: webServerUri + "api/reports",
            type: "GET",
            dataSrc: "",
            dataType: "json"
        }
    }

    return {
        getReports: getReports
    }
}();