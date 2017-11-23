var reportService = function (routing) {

    var getReports = function (done, fail) {
        $.ajax({
                url: routing.getApiUri("Report"),
                type: "GET",
                dataSrc: "",
                dataType: "json"
            }).done(done)
            .fail(fail);
    };

    return {
        getReports: getReports
    }
}(routing);