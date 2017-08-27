var ContactService = function() {
    var getContacts = function (webServerUri, done, fail) {
        $.ajax({
            url: webServerUri + 'api/contacts',
            type: 'GET',
            dataSrc: '',
            dataType: 'json'
        }).done(done)
            .fail(fail);

        return data;
    }

    return {
        getContacts: getContacts
    }
}();
/*
ajax: {
    url: webServerUri + 'api/contacts',
        type: 'GET',
        dataSrc: '',
        dataType: 'json'
},*/