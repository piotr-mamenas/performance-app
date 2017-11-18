var portfolioCreateViewController = function () {
    var dialog;

    var openSelectAccountDialog = function () {
        dialog = bootbox.dialog({
            title: "Hello",
            message: "World"
        });
    }

    var init = function () {
        $(".portfolio-create-js-select-account").on("click", openSelectAccountDialog);
    }

    return {
        init: init
    };

}()