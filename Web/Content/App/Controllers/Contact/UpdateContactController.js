var UpdateContactController = function () {

    var init = function () {
        $(".js-contact-parnum-select").selectpicker({
            liveSearch: true,
            showSubtext: true
        });
    };

    return {
        init: init
    };

}();