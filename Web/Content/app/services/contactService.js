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

    var deleteContact = function(contactId, done, fail) {
        $.ajax({
                url: routing.getApiUri("Contact") + "delete/" + contactId,
                method: "DELETE"
            }).done(done)
              .fail(fail);
    }

    return {
        getContacts: getContacts,
        deleteContact: deleteContact
    }
}(routing);