var contactService = function (routing) {

    var getContacts = function (done, fail) {
        $.ajax({
            url: routing.getApiUri("Contact"),
            type: "GET",
            dataSrc: "",
            dataType: "json"
        }).done(done)
          .fail(fail);
    };

    return {
        getContacts: getContacts
    }
}(routing);