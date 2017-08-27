var ContactService = function() {
    var getContacts = function (webServerUri) {
        return {
            url: webServerUri + "api/contacts",
            type: "GET",
            dataSrc: "",
            dataType: "json"
        }
    }

    return {
        getContacts: getContacts
    }
}();