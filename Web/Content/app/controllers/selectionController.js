var selectionController = function () {

    var displaySelectByPartnerSearch = function () {
        $("#js-select-partner").click(function () {
            $("div#byPortfolio").slideUp(500);
            $("div#byContainer").slideUp(500);
            $("div#byPartner").slideDown(1000);

            $("#js-select-partner").parent("li").addClass("active");
            $("#js-select-portfolio").parent("li").removeClass("active");
            $("#js-select-container").parent("li").removeClass("active");
        });
    }

    var displaySelectByPortfolioSearch = function () {
        $("#js-select-portfolio").click(function () {
            $("div#byPartner").slideUp(500);
            $("div#byContainer").slideUp(500);
            $("div#byPortfolio").slideDown(1000);

            $("#js-select-partner").parent("li").removeClass("active");
            $("#js-select-portfolio").parent("li").addClass("active");
            $("#js-select-container").parent("li").removeClass("active");
        });
    }

    var displaySelectByContainerSearch = function () {
        $("#js-select-container").click(function () {
            $("div#byPartner").slideUp(500);
            $("div#byPortfolio").slideUp(500);
            $("div#byContainer").slideDown(1000);
            
            $("#js-select-partner").parent("li").removeClass("active");
            $("#js-select-portfolio").parent("li").removeClass("active");
            $("#js-select-container").parent("li").addClass("active");
        });
    }

    var init = function() {
        displaySelectByPartnerSearch();
        displaySelectByPortfolioSearch();
        displaySelectByContainerSearch();
    }

   return {
       init: init
   } 
}()