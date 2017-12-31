var CreateAccountController = function () {

    var init = function () {
        $(".js-account-parnum-select").selectpicker({
            liveSearch: true,
            showSubtext: true
        });
    };

    return {
        init: init
    };

}();