var portfolioDetailsViewController = function () {

    var showPortfolioAssetsTable = function () {
        $("#portfolioAssetsTable").show();
        $("#portfolioPartnersTable").hide();
    }

    var showPortfolioPartnersTable = function () {
        $("#portfolioAssetsTable").hide();
        $("#portfolioPartnersTable").show();
    }

    var changeTable = function (e) {
        var selected = $(e.currentTarget).find(":selected").val();

        console.log(selected);
        switch(selected) {
            case "1":
                showPortfolioAssetsTable();
                break;
            case "2":
                showPortfolioPartnersTable();
                break;
            default:
                alert("Unexpected error occurred");
        }
    }

    var init = function () {
        $(".portfolio-details-view-js-select").on("change", changeTable);
    }

    return {
        init: init
    };

}()