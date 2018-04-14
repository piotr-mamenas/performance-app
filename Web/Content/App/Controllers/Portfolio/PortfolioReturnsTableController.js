var PortfolioReturnsTableController = function(service) {
    var table;
    var calculateAssetButton;
    var calculationPeriods = [];
    var numberOfPeriods = 1;
    var selectedAssetId = 0;
    var portfolioId = 0;

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
        $(".bootbox-body").find(".calculation-datepicker").append(
            "<div class='row input-group input-daterange'>" +
                "<div class='col-md-6'>" +
                    "<input type='text' required='required' class='form-control' data-date-from-row-id='" + numberOfPeriods + "' placeholder='Date From' />" +
                "</div>" +
                "<div class='col-md-6'>" +
                    "<input type='text' required='required' class='form-control' data-date-to-row-id='" + numberOfPeriods + "' placeholder='Date To' />" +
                "</div>" +
            "</div>");
    };

    var onCalculateAssetClick = function(e) {
        calculateAssetButton = $(e.currentTarget);
        selectedAssetId = calculateAssetButton.data("asset-id");
        numberOfPeriods = 0;
        calculationPeriods = [];

        $(".calculation-datepicker").empty();

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
                        for (var cnt = 1; cnt <= numberOfPeriods; cnt++) {
                            calculationPeriods.push({
                                dateFrom: $("input[data-date-from-row-id='" + cnt + "']").val(),
                                dateTo: $("input[data-date-to-row-id='" + cnt + "']").val()
                            });
                        }
                        console.log(JSON.stringify(calculationPeriods));
                        service.getReturnsByIdAndPeriod(selectedAssetId,
                            portfolioId,
                            JSON.stringify(calculationPeriods),
                            function(e) {
                                console.log(e);
                            },
                            function(e) {
                                console.log(e);
                            });
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
        appendPeriod();
        initializeDatepicker("[data-date-from-row-id='1']");
        initializeDatepicker("[data-date-to-row-id='1']");
    };

    var init = function(id) {
        var loadDatatable = function (result) {
            initializeDatatable(result);
            $(".btn-portfolio-calculate-asset-returns").on("click", onCalculateAssetClick);
        }
        portfolioId = id;
        service.getAssetsByPortfolios(portfolioId, loadDatatable, loadDatatable);
    }

    return {
        init: init
    };

}(AssetService);