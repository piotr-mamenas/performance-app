var portfolioDetailsViewController = function () {

    var showPortfolioAssetsTable = function () {
        $("#portfolioPartnersTable").parents("div.dataTables_wrapper").first().hide();
        $("#portfolioAssetsTable").parents("div.dataTables_wrapper").first().show();
    }

    var showPortfolioPartnersTable = function () {
        $("#portfolioAssetsTable").parents("div.dataTables_wrapper").first().hide();
        $("#portfolioPartnersTable").parents("div.dataTables_wrapper").first().show();
    }

    var changeTable = function (e) {
        var selected = $(e.currentTarget).find(":selected").val();
        
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
        $(".portfolio-details-js-selection").on("change", changeTable);
    }

    return {
        init: init
    };

}()