var AccountService = function (routing) {

    var getAccounts = function (done, fail) {
        $.ajax({
                url: routing.getApiUri("Account"),
                type: "GET",
                dataSrc: "",
                dataType: "json"
            }).done(done)
              .fail(fail);
    };

    var deleteAccount = function (accountId, done, fail) {
        this.accountId = accountId;

        $.ajax({
                url: routing.getApiUri("Account") + accountId + "/delete",
                type: "POST",
                method: "DELETE",
                contentType: "text/plain"
            }).done(done)
              .fail(fail);
    }

    return {
        getAccounts: getAccounts,
        deleteAccount: deleteAccount
    }
}(Routing);