var newContactWizardController = function() {
    var getCurrentStep = function () {
        return $("#contact-newcontact-currentstep").data("current-step");
    }

    var setCurrentStep = function (step) {
        if ($("#contact-newcontact-form").valid()) {
            $("#contact-newcontact-form").children("fieldset").hide();
            switch (Number(step)) {
            case 1:
                $("#contact-newcontact-firststep").show();
                console.log("1");
                break;
            case 2:
                $("#contact-newcontact-secondstep").show();
                console.log("2");
                break;
            case 3:
                $("#contact-newcontact-finalstep").show();
                console.log("3");
                break;
            }
            $("#contact-newcontact-currentstep").data("current-step", step);
        }
    }

    $("#contact-newcontact-previousstep").click(function () {

        switch (Number(getCurrentStep())) {
            case 2:
                setCurrentStep(1);
                break;
            case 3:
                setCurrentStep(2);
                break;
        }
    });

    $("#contact-newcontact-nextstep").click(function () {
        // validate if correct
        // change step label
        // hide current step
        // show next step
        switch (Number(getCurrentStep())) {
            case 1:
                setCurrentStep(2);
                break;
            case 2:
                setCurrentStep(3);
                break;
        }

    });

    $("form input").on("keyup", function (e) {
        return e.which !== 13;
    });

    var init = function() {
        $("#contact-newcontact-currentstep").data("current-step", 1);
        $.validator.unobtrusive.parse($("#contact-newcontact-form"));
    }

    return {
        init: init
    };
}()