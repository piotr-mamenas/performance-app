var ReportService = function (routing) {

    var getReports = function (done, fail) {
        $.ajax({
            url: routing.getApiUri("Report"),
            type: "GET",
            dataSrc: "",
            dataType: "json",
            xhrFields: { withCredentials: true }
        }).done(done)
            .fail(fail);
    };

    var getDownloadUri = function (id) {
        return routing.getApiUri("Report") + id + "/download";
    };

    return {
        getReports: getReports,
        getDownloadUri: getDownloadUri
    }
}(Routing);