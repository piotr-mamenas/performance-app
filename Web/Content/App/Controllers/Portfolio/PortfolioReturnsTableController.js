var PortfolioReturnsTableController = function(service) {
    var table;
    var calculateAssetButton;
    var calculationPeriods = [];
    var numberOfPeriods = 1;

    var initializeDatatable = function (result) {
        if (table != null) {
            table.destroy();
        }
        table = $("#portfolioReturnsTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Class"
                },
                {
                    data: "Isin"
                },
                {
                    data: "Id",
                    render: function (data) {
                        return "<button href=\"#\" data-asset-id=\"" + data + "\" class=\"btn btn-default btn-block btn-portfolio-calculate-asset-returns\"><span class='fa fa-calculator'></span></button>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }
    
    var initializeDatepicker = function (selector) {
        $(selector).datepicker({
            format: "dd/mm/yyyy",
            autoclose: true
        }).on("changeDate", function () {
            $(this).blur();
            $(this).datepicker("hide");
        });
    }

    var appendPeriod = function() {
        numberOfPeriods++;
        $(".calculation-datepicker").append(
            "<div class='row input-group input-daterange'>" +
                "<div class='col-md-6'>" +
                    "<input type='text' class='form-control' data-date-from-row-id='" + numberOfPeriods + "' placeholder='Date From' />" +
                "</div>" +
                "<div class='col-md-6'>" +
                    "<input type='text' class='form-control' data-date-to-row-id='" + numberOfPeriods + "' placeholder='Date To' />" +
                "</div>" +
            "</div>");
    };

    var onCalculateAssetClick = function(e) {
        calculateAssetButton = $(e.currentTarget);
        numberOfPeriods = 0;
        calculationPeriods = [];

        $(".calculation-datepicker").empty();
        appendPeriod();
        bootbox.dialog({
            title: "Enter Calculation Periods",
            onEscape: function () {
                $(".bootbox.modal").modal("hide");
            },
            message: $("#portfolioReturnsForm").html(),
            buttons: {
                cancel: {
                    label: "<i class=\"fa fa-times\"></i> Cancel",
                    className: "btn-danger"
                },
                confirm: {
                    label: "<i class=\"fa fa-check\"></i> Confirm",
                    className: "btn-primary",
                    callback: function () {
                        console.log("MAIN")
                        $("input[data-date-from-row-id]").each(function () {
                            console.log($(this));
                            console.log("HELLO");
                            calculationPeriods.push({
                                dateFrom: $(this).val()
                            });
                        });
                        
                        $("input[data-date-to-row-id]").each(function (index) {
                            calculationPeriods[index].dateTo = $(this).val();
                        });
                        console.log(calculationPeriods);
                    }
                },
                addPeriod: {
                    label: "<i class=\"fa fa-plus\"></i> Add Period",
                    callback: function () {
                        if (numberOfPeriods > 4) {
                            var periodButton = $("[data-bb-handler='addPeriod']");
                            periodButton.html("MAXIMUM PERIODS REACHED");
                            periodButton.css("font-size", 8);
                            periodButton.css("color", "#F00");
                            periodButton.prop("disabled", true);
                        } else {
                            if ($("input[data-date-from-row-id='" + numberOfPeriods + "']").data()) {
                                appendPeriod();

                                initializeDatepicker("[data-date-from-row-id='" + numberOfPeriods + "']");
                                initializeDatepicker("[data-date-to-row-id='" + numberOfPeriods + "']");                                
                            }
                        }
                        return false;
                    }
                }
            }
        });
        initializeDatepicker("[data-date-from-row-id='1']");
        initializeDatepicker("[data-date-to-row-id='1']");
    };

    var init = function(id) {
        var loadDatatable = function (result) {
            initializeDatatable(result);
            $(".btn-portfolio-calculate-asset-returns").on("click", onCalculateAssetClick);
        }
        service.getAssetsByPortfolios(id, loadDatatable, loadDatatable);
    }

    return {
        init: init
    };

}(AssetService);