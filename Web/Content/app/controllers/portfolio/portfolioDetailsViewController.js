var portfolioDetailsViewController = function () {

    var changeTable = function (e) {
        var selected = $(e.currentTarget).find(":selected").val();

        console.log(selected);
        switch(selected) {
            case "1":
                $("#portfolioAssetsTable").show();
                $("#portfolioPartnersTable").hide();
                break;
            case "2":
                $("#portfolioAssetsTable").hide();
                $("#portfolioPartnersTable").show();
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