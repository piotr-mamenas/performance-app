var InstitutionService = function (routing) {

    var getInstitutions = function (done, fail) {
        $.ajax({
                url: routing.getApiUri("Institution"),
                type: "GET",
                dataSrc: "",
                dataType: "json"
            }).done(done)
            .fail(fail);
    };

    return {
        getInstitutions: getInstitutions
    }
}(Routing);