var ResourceService = function (routing) {

    var getAvailableIconClasses = function (done, fail) {
        $.ajax({
            url: routing.getApiUri("Resource") + "/icons",
            type: "GET",
            dataSrc: "",
            dataType: "json",
            xhrFields: { withCredentials: true }
        }).done(done)
            .fail(fail);
    }

    var getAvailableLargeIconClasses = function (done, fail) {
        $.ajax({
            url: routing.getApiUri("Resource") + "/largeicons",
            type: "GET",
            dataSrc: "",
            dataType: "json",
            xhrFields: { withCredentials: true }
        }).done(done)
            .fail(fail);
    }

    return {
        getAvailableIconClasses: getAvailableIconClasses,
        getAvailableLargeIconClasses: getAvailableLargeIconClasses
    };
}(Routing);