var navbarController = function() {

    var init = function () {

        $("[data-toggle=collapse]").click(function (e) {
            var targetSubNav = $($(this).data("target"));

                $("#subnavbar").children("ul").not(":hidden").slideUp(0).hide(0);
                targetSubNav.show(0).slideDown(400);
                console.log("1");
                $("[data-toggle=collapse]").parent("li").removeClass("active");

                $(this).parent("li").toggleClass("active");
        });
    }

    return {
        init: init
    }
}();