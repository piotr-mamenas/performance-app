var navbarController = function () {

    var presetNavbar = function (currentPage) {
        var currentNavbarTab = $("ul" + currentPage + ".nav");

        $("#subnavbar").children("ul").not(":hidden").slideUp(0).hide(0);
        currentNavbarTab.show(0).slideDown(400);

        $("[data-target=" + currentPage + "]").parent("li").toggleClass("active");
    };

    var onTabClick = function () {
        $("[data-toggle=collapse]").click(function () {
            var targetSubNav = $($(this).data("target"));

            $("#subnavbar").children("ul").not(":hidden").slideUp(0).hide(0);
            targetSubNav.show(0).slideDown(400);
            $("[data-toggle=collapse]").parent("li").removeClass("active");

            $(this).parent("li").toggleClass("active");
        });
    }();

    var init = function (currentPage) {
        presetNavbar(currentPage);
    }

    return {
        init: init
    }
}();