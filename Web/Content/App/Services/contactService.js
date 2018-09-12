var ContactService = function (routing) {

    var getContacts = function (done, fail) {
        $.ajax({
            url: routing.getApiUri("Contact"),
            type: "GET",
            dataSrc: "",
            dataType: "json",
            xhrFields: { withCredentials: true }
        }).done(done)
          .fail(fail);
    };

    var deleteContact = function (contactId, done, fail) {
        this.contactId = contactId;

        $.ajax({
            url: routing.getApiUri("Contact") + contactId + "/delete",
            type: "POST",
            method: "DELETE",
            contentType: "text/plain",
            xhrFields: { withCredentials: true }
            }).done(done)
              .fail(fail);
    }

    return {
        getContacts: getContacts,
        deleteContact: deleteContact
    }
}(Routing);