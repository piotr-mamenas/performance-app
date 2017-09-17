var accountService = function (routing) {

    var getAccounts = function (done, fail) {
        $.ajax({
                url: routing.getApiUri("Account"),
                type: "GET",
                dataSrc: "",
                dataType: "json"
            }).done(done)
            .fail(fail);
    };

    return {
        getAccounts: getAccounts
    }
}(routing);