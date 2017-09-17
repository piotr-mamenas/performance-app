var partnerService = function (routing) {

    var getPartners = function (done, fail) {
        $.ajax({
                url: routing.getApiUri("Partner"),
                type: "GET",
                dataSrc: "",
                dataType: "json"
            }).done(done)
            .fail(fail);
    };

    return {
        getPartners: getPartners
    }
}(routing);