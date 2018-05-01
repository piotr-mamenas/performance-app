var ResourceService = function (routing) {

    var getAvailableIcons = function (done, fail) {
        $.ajax({
            url: routing.getApiUri("Resource") + "/icons",
            type: "GET",
            dataSrc: "",
            dataType: "json"
        }).done(done)
            .fail(fail);
    }

    return {
        getAvailableIcons: getAvailableIcons
    };
}(Routing);