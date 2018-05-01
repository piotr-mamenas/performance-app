var CreatePortfolioController = function () {

    var init = function () {
        $(".js-portfolio-account-select").selectpicker({
            liveSearch: true,
            showSubtext: true
        });
    }

    return {
        init: init
    };

}()