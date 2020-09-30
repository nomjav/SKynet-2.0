
var interval;
var hasWebAddress = "false";
// code executed when page is loaded
$(document).ready(function () {
    var str = window.location.toString();
    if (str.includes("=")) {
        var ext = str.split("=");
        //$("#ByJobId").val(ext[1]);
        //$("#btnsearchjobs").click();
        SelectJob(ext[1]);
    }


    console.log("In $(document).ready");
    // get jobs legends on filter panel and count total of jobs for each status
    GetNumberOfJobsByStatus();

    //$('#JobStatusPopUpmenu').draggable();
    //$("#JobDateHistoryPopup").draggable();
    $('#cbCitiBank').attr('checked', false);
    $('#cbAissJobs').attr('checked', false);
    //$('.action-container #ExpectedFromTime').val($.datepicker.formatDate("mm/dd/yy", new Date()));
    //$('.action-container #ExpectedToTime').val($.datepicker.formatDate("mm/dd/yy", new Date()));
    $('#ContractorId').prepend('<option value="0" selected>All</option>');
    $('#JobStatusId').prepend('<option value="0" selected>All</option>');
    GetJobStatusReport();

    $('#CancelCommissionNotes').click(function () {
        $("#CommissionPopup").dialog("close");
        $('#ExtraCommission').css('border', '1px solid gray');
        $('#ExtraCommission').val("");
        return false;
    });

    if ($("#viewStatusSummary").val() == "true") {
        //LoadDailySummaryReport();
        //$('#tdManagerDailySummaryButton').show();
    }
    else {
        $('#tdManagerDailySummaryButton').hide();
    }

    $('#txtOtherEta').val("");
    $('#txtTrip').val("Trip");
    $('#txtLabor').val("Labor");
    $('#txtParts').val("Parts");
    $('#txtKeys').val("Keys");
    $('#txtCyclinder').val("Cylinder");
    //$('#btnCustomerWebAddress').hide();
    MakeDescriptionsToolTips();
    EquipmentsToolTips();
    //$("#tabs").tabs();
    $(".activateCharms").on('click', function () {
        toggleCharms(interval);
        CloseCharmPanel();
        refreshCallsGrid(0);
        //$("#CustomerNotesPopup").dialog("close");
    });

    $("#CancelCallSlip").on('click', function () { toggleCharms(interval); });
    $('.htmlSection').each(function () {
        $(this).html(unescape($(this).html()));
    });
    // drop down for board types, save on change for user the current board type
    //$("#JobTypeId").change(function () {
    //    refreshCallsGrid(0);
    //});

    //$('#ServiceTimeTo').timepicker(); $('#ServiceTimeFrom').timepicker(); $('#ExpectedTime').timepicker();

    //$('#AlarmTime').timepicker({
    //    timeOnlyTitle: 'Timer',
    //    showButtonPanel: false,
    //    defaultValue: '00:00'
    //});


    $('#PaymentMethodId').change(function () {

        if ($(this).val() == "5") {

            var test = $("#checkFields").html();
            $("#creditCardFields").hide();
            $("#CashForm").hide();
            $("#checkFields").show();
            $('#CardsDiv').hide();

        }
        else if ($(this).val() == "4" || $(this).val() == "7") {
            $("#checkFields").hide();
            $("#creditCardFields").hide();
            $("#CashForm").show();
            $('#CardsDiv').hide();

        } else {
            $("#checkFields").hide();
            $("#creditCardFields").show();
            $("#CashForm").hide();
            $('#CardsDiv').show();
        }
    });
    $('#cHiringDate').datepicker();
    $('#FromDateTime').datepicker();
    $('#EndDateTime').datepicker();
    $('#PaidDate').datepicker();
    $('#CheckPaidDate').datepicker();
    $('#PODateOrdered').datepicker();
    $('#MainDispatchBoardDateFilter').datepicker({
        onSelect: function (selected, evnt) {
            if ($('.action-container').is(':visible')) {
                $('.action-container').hide();
            }

            refreshCallsGrid(0);
        }
    });

    $(".chkbxJobTypeFP").click(function () {
        GetJobStatusReport();
    });

    $('#DayInterval').change(function () {

        if ($(this).val() == "3") {
            $('.singrange').fadeOut(); $('.range').fadeIn();
        } else {
            $('.range').fadeOut(); $('.singrange').fadeIn();
        }
    });
    $("#SameAsBillingAddress").click(function () {
        SameAsBillingAddress($(this).is(":checked"));
    });
    //$("#ToPhone").mask({ mask: "(###) ###-####" });
    $('#ServiceDate').datepicker();
    $('.hasDatePicker').datepicker();
    $("#charms #JobTypeId option[value='1']").val(0);
    $('#PartType').change(function () {

        var v = $(this).val();
        // $('#lblPartPrice').html("");
        $('#sellingPrice').val("");
        if ($(this).val() == '4') {
            $('#PartDescription').parents('tr').hide();
            $('#Name').parents('tr').fadeOut();
            $('#partsMarkup').parents('tr').fadeOut();
            $('#partsDiscount').parents('tr').fadeOut();
            $('#laborOrPartCost').parents('tr').hide();
            // $('#PartPofit').parents('tr').hide();
            $('.profitOnParts').hide();
            $('.sellingPrice').hide();
            $('#NewPartCost').parents('tr').hide();
        }
        else
            if ($(this).val() == '1') {
                $('#PartDescription').parents('tr').hide();
                $('#Name').parents('tr').fadeIn();
                $('#partsMarkup').parents('tr').fadeIn();
                $('#partsDiscount').parents('tr').fadeIn();
                $('#laborOrPartCost').parents('tr').hide();
            }
            else
                if ($(this).val() == '2') {
                    $('#partsMarkup').parents('tr').fadeOut();
                    $('#partsDiscount').parents('tr').fadeOut();
                    $('#PartDescription').parents('tr').hide();
                    $('#Name').parents('tr').fadeIn();
                    $('#laborOrPartCost').parents('tr').show();
                    $('.sellingPrice').hide();
                    $('#NewPartCost').parents('tr').hide();
                    //  GetCustomerMarkupAndDiscount();
                }

                else {
                    $('#laborOrPartCost').parents('tr').hide();
                    $('#PartDescription').parents('tr').hide();
                    $('#Name').parents('tr').fadeIn();
                    $('#partsMarkup').parents('tr').fadeOut();
                    $('#partsDiscount').parents('tr').fadeOut();
                    // $('#PartPofit').parents('tr').hide();
                    $('.profitOnParts').hide();
                    $('.sellingPrice').hide();
                    $('#NewPartCost').parents('tr').hide();
                }
    });
    function GetCustomerMarkupAndDiscount() {

        var customerName = $('#CustomerName').val();
        var request = { CustomerName: customerName };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/GetCustomerMarkupAndDiscount",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {

                    $('#partsMarkup').val(data.partMarkup);
                    $('#partsDiscount').val(data.partDiscount);
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }

    $('#AddPart').click(function () {
        $('#Name').addClass('required');
        if ($('#PartType').val() == '4') {
            $('#Name').removeClass('required');
        }
        var vl = $('#PartsForm').valid();
        if (vl) {

            var totalPartQuantity = $('#TotalPartQuantity').val();
            var partQuantity = $('#PartQuantity').val();
            var type = $('#PartType').val();
            var partFound = $('#lblPartFound').text();

            if (type == '1' && partFound == 'Yes') {
                if (parseInt(partQuantity) > parseInt(totalPartQuantity)) {
                    partOutOfStock();
                }
                else {
                    AddPart();
                }
            }
            else {
                AddPart();
            }

        }
        else {
            $('.required').each(function () {
                $('.required').attr('placeholder', 'Field is required');
            });
        }
    });

    $('#down').show();
    $('#dTime').datepicker();

    $('input[type="radio"][name="IsPrimary"]').click(function () {
        if ($(this).is(":checked")) {
            primaryContractorId = $(this).attr("id");
        } else {
            primaryContractorId = "";
        }
    });


}
);
//$(document).on('mouseover', '#charms', function () {
//    var winWidth = $(window).width() - 180;
//    var minWidth = 1465;
//    $('#charms').css({ width: winWidth + 'px' });
//    $('#charms').css({ "min-width": "1465px" });
//    $('#charms').css({ right: '-' + $(window).width() + 'px' });
//    var mxWidth = $('#charms').width();
//    $('#charms').resizable({
//        handles: 'w',
//        minWidth: 700,
//        maxWidth: mxWidth,
//        autoHide: false,
//        disabled: false
//    });
//});
function DragableDialog() {

}
var status = false;
// show/hide charms panel
function toggleCharms(timer) {

    console.log("In toggleCharms status =" + status);

    if (status == "true" || status == true) {
        clearInterval(timer);
        //$("#datebox").fadeOut(250); 
        //$("#charms").animate({ right: '-=1500px' }, 250, 'easeOutExpo');
        $("#charms").animate({ right: '-=' + $(window).width() + 'px' }, 250, 'easeOutExpo');
        $("#charms ul li").animate({ right: '-=0' }, 500, 'linear');
        status = false;
        $('#btnDockPanel').hide();

    }
    else {
        //$("#datebox").fadeIn(250);
        $("#charms").animate({ right: '0px' }, 500, 'easeOutExpo');
        timer = setTimeout(function () {
            var len = $("#charms ul#charmsLines li").length;
            var i = Math.floor(len / 2); var wait = 0;
            $("#charms ul#charmsLines li").css("right", 0);

            while (i >= 0) {
                $("#charms ul#charmsLines li").eq(i).delay(wait).animate({ right: '+=40' }, 400, 'easeOutExpo');
                if (i != Math.floor(len / 2)) $("#charms ul#charmsLines li").eq(len - 1 - i).delay(wait).animate({ right: '+=40' }, 400, 'easeOutExpo');
                i--;
                wait += 50;
            }
        }, 50);
        status = true;
        $('#btnDockPanel').show();
    }
    var winWidth = $(window).width() - 198;
    var minWidth = 1465;
    if (winWidth <= minWidth) {
        if ($("#charms").width() == minWidth) {
            //$("#btnDockPanel").css('right', '1442px');
            $("#btnDockPanel").animate({ right: '1442px' }, 500, 'easeOutExpo');
        }
        else {
            //$("#btnDockPanel").css('right', winWidth + 'px');
            $("#btnDockPanel").animate({ right: winWidth + 'px' }, 500, 'easeOutExpo');
        }
    }
    else {
        //$("#btnDockPanel").css('right', winWidth + 'px');
        $("#btnDockPanel").animate({ right: winWidth + 'px' }, 500, 'easeOutExpo');
    }
    $('#btnDockPanel').text('Hide Panel');
}

// if key pressed is c, code is equal to 99
//  then close the charms panel
$(document).keydown(function (e) {
    if (e.keyCode == 27) {
        toggleCharms(interval);
        CloseCharmPanel();
        refreshCallsGrid(0);
    }
});

function EquipmentsToolTips() {
    $('#callslip-grid .EquipmentTip').each(function () {
        var pn = $(this).closest('td').prev('td').text();
        $(this).attr('title', pn).tooltip({
            show: null,
            open: function (event, ui) {
                ui.tooltip.siblings(".tooltip").remove();
            }
        });

        $(this).text($(this).text().substring(0, 100));
    });
}

function SameAsBillingAddress(sameAsShipping) {
    //if (sameAsShipping) {
    //    FetchAndPopulateShippingAddress();
    //}
    //else {
    //    FetchAndPopulateBillingAddress();
    //}

    $('#BillingCompanyName').val(sameAsShipping ? $('#ShippingCompanyName').val() : "");

    $('#BillingFirstName').val(sameAsShipping ? $('#ShippingFirstName').val() : "");
    $('#BillingLastName').val(sameAsShipping ? $('#ShippingLastName').val() : "");
    $('#BillingCity').val(sameAsShipping ? $('#ShippingCity').val() : "");
    $('#BillingAddress1').val(sameAsShipping ? $('#ShippingAddress1').val() : "");
    $('#BillingAddress2').val(sameAsShipping ? $('#ShippingAddress2').val() : "");
    $('#BillingZipCode').val(sameAsShipping ? $('#ShippingZipCode').val() : "");
    $('#BillingPhone').val(sameAsShipping ? $('#ShippingPhone').val() : "");
    $('#BillingStateId').val(sameAsShipping ? $('#ShippingStateId').val() : "0").trigger("chosen:updated");
    $('#BillingCountyId').val(sameAsShipping ? $('#ShippingCountyId').val() : "0").trigger("chosen:updated");
}
function CloseCharmPanel() {
    var CallSlipId = $('#CallSlipId').val();
    var request = { CallSlipId: CallSlipId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/removeCache",
        data: JSON.stringify(request)
    });
}

function populateJobAlert(id) {

    console.log("In populateJobAlert");
    var request = { CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/populateJobAlert",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                var winH = $(window).height() - 10;
                $('#JobAlertsPopUpmenu').dialog({
                    title: 'Job Mobile Alerts History',
                    resizable: true,
                    width: '600px',
                    height: winH,
                    modal: false,
                    position: ['left', 'bottom']
                });

                if (data.model.length > 0) {
                    var table = "<table class='table table-advance'>";
                    table += "<thead><tr>";
                    table += "<th>Message</th>";
                    table += "<th>Contractor</th>";
                    table += "<th>User Name</th>";
                    table += "<th>Created On</th></tr></thead>";
                    for (var i = 0; i < data.model.length; i++) {
                        var date = data.model[i].CreatedOn;
                        var value = new Date(parseInt(date.replace(/(^.*\()|([+-].*$)/g, '')));
                        var hours = value.getHours();
                        var minutes = value.getMinutes();
                        var ampm = hours >= 12 ? 'pm' : 'am';
                        hours = hours % 12;
                        hours = hours ? hours : 12;
                        minutes = minutes < 10 ? '0' + minutes : minutes;
                        var strTime = hours + ':' + minutes + ' ' + ampm;
                        var dateFormat = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear() + " - " + strTime;
                        table += "<tr><td>" + data.model[i].Message + "</td>";
                        table += "<td>" + data.model[i].Contractor + "</td>";
                        table += "<td>" + data.model[i].User + "</td>";
                        table += "<td>" + dateFormat + "</td></tr>";
                    }
                    table += "</table>";
                    $('#JobAlertsPopUpmenu').html(table);
                    var test = $('#JobAlertsPopUpmenu').html();
                }
                else {
                    var message = "<h4 style = 'color: red;'>Job Status History Does not exist</h4>";
                    $('#JobAlertsPopUpmenu').html(message);
                }
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}




function resetDiv() {
    $('#StoreAcitivityContainer').html("");
    $('#PurchaseOrdersGrid tbody').html("");
    $('#ContractorHistoryContainer').html("");
    $('#purchaseOrderTable').html("");
    $('#Contractors').html("");
    //$('#btnCustomerWebAddress').hide();
    $('#cardNotRun').prop('checked', false);
    $('#lblPortalmessage').hide();
}
var x;


function OpenJob(id) {
    var prevCallSlipId = "";
    var backgroundColor;
    var textColor;
    var winH = $(window).height() - 5;
    var winW = $(window).width() - 240;
    var Left = '240px';
    if ($(window).width() <= 1366) {
        winW = 1156;
        Left = '210px';
    }
    $('<div id="'+id+'"></div>').dialog({
        title: id,
        resizable: true,
        draggable: false,
        width: winW,
        height: winH,
        modal: false,
        open: function (e) {
            $(e.target).parent().css('background-color', '#f1f2f7');
            
            var request = { CallSlipId: id, prevCallSlipId: prevCallSlipId };
            var jobNotFound = false;

            $.ajax({
                type: "POST",
                contentType: "application/json, charset=utf-8",
                url: "Home/GetJobDetailsById",
                data: JSON.stringify(request),
                cache: false,
                success: function (msg) {
                    var data;
                    if (msg.hasOwnProperty("d")) {
                        data = msg.d;
                    } else
                        data = msg;
                    if (data.success) {
                        $("#" + id + "").html(data.serviceView);
                        backgroundColor = data.backgroundColor;
                        textColor = data.textColor;
                        $(e.target).parent().find('.ui-widget-header').css("background", backgroundColor);
                        $(e.target).parent().find('.ui-widget-header').css("color", textColor);
                        GetContractorsByJobId(id);
                        GetJobStatusHistoryByJobId(id);
                        GetNotesAndDocumentsByJobId(id);
                        GetProgressBarDetailsByJobId(id);
                        GetTablesDataByJobId(id);
                        //FillCallSlipDetails(data.model, data.OnDateDayName, data.ftString, data.ttString, data.lat, data.lng);
                    } else {
                        //Notify(data.message, 'error');
                        jobNotFound = true;
                    }
                }
            });

            //$(this).html("");
        },  close: function(ev, ui) {
            $(this).dialog('destroy').remove()
        }
    }).dialogExtend({
        "closable": true,
        "minimizable": true,
        "icons": { "minimize": "ui-icon-circle-minus" },
        //"beforeMinimize": function (evt, dlg) {
        //    $('#' + id).parent().find('.ui-widget-header').css("background", backgroundColor);
        //    $('#' + id).parent().find('.ui-widget-header').css("color", textColor);
        //},
        //"beforeRestore": function (evt, dlg) {
        //    debugger;
        //    $('#' + id).parent().find('.ui-widget-header').css("background", "#949597");
        //    $('#' + id).parent().find('.ui-widget-header').css("color", "black");
        //},
    })
        .parent()
        .css({ position: 'fixed', top: '0.508px', left:Left })
        .end()
        .position({ my: 'left', at: 'right', of: window })
        .css({ position: 'static' });

    var winWidth = $(window).width() - 180;
    var minWidth = 1465;
    $('#charms').css({ width: winWidth + 'px' });
    $('#charms').css({ "min-width": "1465px" });
    $('#charms').css({ right: '-' + $(window).width() + 'px' });
    winWidth = $(window).width() - 198;
}

function showServicesDiv(id) {
    $('#ServiceDivs_' + id).show();
    //-----------------------------
    $('#EstimateDivs_' + id).hide();
    $('#CommunicationDivs_' + id).hide();
    $('#PaymentsDivs_' + id).hide();
}

function showEstimatesDiv(id) {
    $('#EstimateDivs_' + id).show();
    GetPartsByCallSlipId(id);
    //-----------------------------
    $('#ServiceDivs_' + id).hide();
    $('#CommunicationDivs_' + id).hide();
    $('#PaymentsDivs_' + id).hide();
}

function showCommunicationDiv(id) {
    $('#CommunicationDivs_' + id).show();
    //-----------------------------
    $('#EstimateDivs_' + id).hide();
    $('#ServiceDivs_' + id).hide();
    $('#PaymentsDivs_' + id).hide();
}

function showPaymentsDiv(id) {
    $('#PaymentsDivs_' + id).show();
    //GetPaymentsByJobId();
    //-----------------------------
    $('#ServiceDivs_' + id).hide();
    $('#EstimateDivs_' + id).hide();
    $('#CommunicationDivs_' + id).hide();
}

function GetNotesAndDocumentsByJobId(id) {
    var request = { CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: "Home/GetNotesAndDocumentsByJobId",
        data: JSON.stringify(request),
        global: false,
        cache: false,
        success: function (msg) {
            
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                PopulateNotes(data.Notes, id);
                PopulateDocuments(data.Documents, id);
            }
            else {
                alert("Error");
            }
        },
        error: function () {
            //CommunicationError();
        }
    });
}

function PopulateNotes(notes, id) {
    $('#' + id).parent().find('#JobNotesContainer').html("");
    //$('#JobNotesContainer').html("");
    var note = "<table class='table table-hover' style='word-break: break-word; font-size:11px; border-bottom:groove;'>";
    note += "<thead style='background-color: #dfe0e6;'><tr><th style='text-align: center;'><span style='float: left;'>Notes &nbsp;&nbsp;";
    note += "<button class='btn btn-primary' onclick='AddNotesPopup();'><i class='fa fa-plus'></i></button></span>";
    note += "<button class='btn btn-primary' onclick='ShowJobNotes();return false;' style='float: right;'><i class='fa fa-refresh'></i></button>";
    note += "<button class='btn btn-primary' title='' id='linkJobId' onclick='LinkJobPopup();return false;' style='float: Left;margin-left:2px;'>Link Job</button>";


    if (notes.length > 0) {
        if (notes[0].TechSummary == true) {
            //note += "<span>Tech Summary &nbsp;&nbsp;<button class='btn btn-success'  onclick='populateTechSumary();'><i class='icon-plus'></i></button></span>";
            note += "<span>Tech Summary &nbsp;&nbsp;<button class='btn btn-success'  onclick='radioselection();'><i class='fa fa-plus'></i></button></span>";
            note += "<span>&nbsp;&nbsp;<button class='btn btn-success'  onclick='radioselection1();'>Tech Summary Reminder</button></span>";
            //note += "<span><button class='btn btn-success' title='' id='linkJobId'  onclick='LinkJobPopup();'>Link Job</button></span>";
            //getTechSummaryList($("input[type=radio][name=contractorForNoticeForm]:checked").attr("id"));

        }
        else {
            note += "<span>Tech Summary &nbsp;&nbsp;<button class='btn btn-success'  onclick='radioselection();'><i class='fa fa-plus'></i></button></span>";
            note += "<span>&nbsp;&nbsp;<button class='btn btn-success'  onclick='radioselection1();'>Tech Summary Reminder</button></span>";
            //note += "<span>Tech Summary &nbsp;&nbsp;<button class='btn btn-large btn-primary'  onclick='populateTechSumary();'><i class='icon-plus'></i></button></span>";
        }
    }
    else {
        note += "<span>Tech Summary &nbsp;&nbsp;<button class='btn btn-success'  onclick='radioselection();'><i class='fa fa-plus'></i></button></span>";
        note += "<span>&nbsp;&nbsp;<button class='btn btn-success'  onclick='radioselection1();'>Tech Summary Reminder</button></span>";
        //note += "<span style = 'float:right;'>Tech Summary &nbsp;&nbsp;<button class='btn btn-large btn-primary'  onclick='populateTechSumary();'><i class='icon-plus'></i></button></span>";
    }

    //+ "</span></b>" + "<b><span class='notesAuthor pull-right'>" + notes[i].Days +
    //    " D " + notes[i].Hours + " H " + notes[i].Minutes + " M " + "</span></b></td></tr>
    note += "</th></tr></thead><tbody class='tableBody'>";
    if (notes.length > 0) {
        for (var i = 0; i < notes.length; i++) {
            note += "<tr><td>" + notes[i].Notes;

            if (notes[i].Days > 0) {
                note += "<b><span class='notesAuthor pull-right'>" + notes[i].CreatedOn + " - " + notes[i].CreatedBy + "&nbsp<span style='color:red;'>" + "<span style='font-size: 10px;'>" + notes[i].Days + "d</span>" + " </span></span></b>";
            }
            else if (notes[i].Hours > 0) {
                note += "<b><span class='notesAuthor pull-right' >" + notes[i].CreatedOn + " - " + notes[i].CreatedBy + "&nbsp<span style='color:red;'>" + "<span style='font-size: 10px;'>" + notes[i].Hours + "h</span>" + " </span></span></b>";
                //note += "<b><span class='pull-right'  style='color:Red;'>&nbsp;" + notes[i].Hours + " H </span></b><b><span class='notesAuthor pull-right'>" + notes[i].CreatedOn +
                //    " - " + notes[i].CreatedBy + "</span></b>";
            }
            else if (notes[i].Minutes > 0) {
                note += "<b><span class='notesAuthor pull-right'>" + notes[i].CreatedOn + " - " + notes[i].CreatedBy + "&nbsp<span style='color:red;'>" + "<span style='font-size: 10px;'>" + notes[i].Minutes + "m</span>" + "</span></span></b>";
                //note += "<b><span class='pull-right'  style='color:Red;'>&nbsp;" + notes[i].Minutes + " M </span></b><b><span class='notesAuthor pull-right'>" + notes[i].CreatedOn +
                //    " - " + notes[i].CreatedBy + "</span></b>";
            }
            else if (notes[i].Seconds > 0) {
                note += "<b><span class='notesAuthor pull-right'>" + notes[i].CreatedOn + " - " + notes[i].CreatedBy + "&nbsp<span style='color:red;'>" + "<span style='font-size: 10px;'>" + notes[i].Seconds + "s</span>" + "</span></span></b>";
                //note += "<b><span class='pull-right'  style='color:Red;'>&nbsp;" + notes[i].Minutes + " M </span></b><b><span class='notesAuthor pull-right'>" + notes[i].CreatedOn +
                //    " - " + notes[i].CreatedBy + "</span></b>";
            }
            else {
                note += "<b><span class='notesAuthor pull-right'>" + notes[i].CreatedOn + "</span></b>";
            }
            note += "</td ></tr>";
        }
    }
    else {
        note += "<tr><td colspan='1'><h6 style='color:#d33838;'>Notes does not exist.</h6></td></tr>";
    }
    note += "</tbody></table>";
    $('#' + id).parent().find('#JobNotesContainer').html(note);
    $('#JobNotesContainer').find("table p").css("margin", "0");
    //if (linkJobId != null) {
    //    $("#linkJobId").removeAttr("class");
    //    $("#linkJobId").removeAttr("onclick");
    //    $("#linkJobId").tooltip(
    //        {
    //            content: "Job is Linked with JobId : " + linkJobId
    //        });
    //    $("#linkJobId").addClass("btn btn-danger");
    //    $("#linkJobId").text("");
    //    $("#linkJobId").text("Linked");
    //}
}

function getBaseUrl() {
    var baseUrl = window.location.href.split('/')[0] + "//" + window.location.href.split('/')[2] + "/" + window.location.href.split('/')[3];
    if (baseUrl.indexOf('#') > 0) {
        baseUrl = baseUrl.replace("#", "")
    }
    if (baseUrl.includes('Home')) {
        baseUrl = baseUrl.replace("/Home", "");
    }
    return baseUrl;
}

function PopulateDocuments(documents, id) {
    var documentslist = "<table id='docList' style='font-size:11px; border-bottom:groove;' class='table table-hover'><thead style='background-color: #dfe0e6;'><tr><th>Document  &nbsp;&nbsp; ";
    documentslist += "<button class='btn btn-large btn-primary' onclick='AddDocumentPopup();'><i class='fa fa-plus'> </i></button>";
    documentslist += "</select> </th><th></th><th style='vertical-align: middle;'>Delete</th><th><button id='RefreshDocuments' style='float: right;' onclick='GetDocumentsByCallSlipId();return false;' class='btn btn-primary'><i class='fa fa-refresh'></i></button></th></tr></thead><tbody class='tableBody'>";
    if (documents.length > 0) {

        for (var i = 0; i < documents.length; i++) {

            var filepath = documents[i].Path;

            if (filepath.indexOf('~') >= 0) {
                //filepath = getBaseUrl() + escape( documents[i].Path.replace('~/', ''));
                filepath = getBaseUrl() + filepath.substring(1);
            }
            else if (filepath.indexOf("https:") >= 0) {
                var filename = "/" + escape(documents[i].Title);
                var updatedpath = filepath.substr(0, documents[i].Path.lastIndexOf("/"));
                filepath = updatedpath + filename;
            }
            //else {
            //    filepath = escape(documents[i].Path);
            //}


            //if (filepath.indexOf('~') >= 0) {
            //    filepath = getBaseUrl() + filepath.substring(1);
            //}
            documentslist += "<tr><td><a style='width:200px;color:#000;' target='_blank' href='" + filepath + "'>" + documents[i].Title + "</a>" +
                "</td><td><b>" + documents[i].UserName + " - " + documents[i].CreatedOn + "</b></td><td><a onclick='DeleteDocumentByCallSlipIdDocumentId(" + documents[i].Id + ");return false;' class='btn btn-danger'><i class='fa fa-trash'></i></a></td><td></td>";
            documentslist += "<td style = 'display:none;'>" + documents[i].Path + "</td></tr>";
        }
    } else {
        documentslist += "<tr><td colspan='100%' style='border:none;'><h6 style='color:#d33838;'>Documents does not exist.</h6></td></tr>";
    }

    documentslist += "</tbody></table>";
    $('#' + id).parent().find('#SPdocumentlist').html("");
    $('#' + id).parent().find('#SPdocumentlist').html(documentslist);

}

function GetContractorsByJobId(id) {
    var request = { CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: "Home/GetContractorsByJobId",
        data: JSON.stringify(request),
        global: false,
        cache: false,
        success: function (msg) {
            
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                PopulateContractors(data.contractors, data.technicians, id);
            }
            else {
                alert("Error");
            }
        },
        error: function () {
            //CommunicationError();

        }
    });
}

function PopulateContractors(cList, technicians, id) {

    console.log("IN PopulateContractors :: " + JSON.stringify(cList));
    $('#' + id).parent().find('#contractorsBody').html("");
    var contractors = "";
    var contractorCommunicationList = " ";
    var primaryContractorPhone = "";
    if (cList.length > 0) {
        contractorAssigned = "";
        for (var i = 0; i < cList.length; i++) {

            //complianceSummary(cList[i].ContractorId);
            contractorAssigned += cList[i].ContractorId + ",";
            contractors += "<tr id='" + cList[i].ContractorId + "' class='contRowId'>";
            contractors += "<td><div style='display: inline-flex;'>";
            contractors += "<div style='float:left;'><input name='contractorForNoticeForm' type='radio' onclick='CheckNoticeForm(" + cList[i].ContractorId + ")' id='" + cList[i].ContractorId + "' />";


            if (cList[i].IsFiftyFifty)
                contractors += "  &nbsp;&nbsp;&nbsp;<span style='color:red;font-weight:bold;font-size:14px;'>50</span>";

            contractors += "</div>";


            var contractorBusinessName = cList[i].BusinessName != null ? cList[i].BusinessName.trim() : "";

            var contractorName = cList[i].ContractorName != null ? cList[i].ContractorName.trim() : "";

            contractors += "<div style='float:left;width: 183px;'>";



            if (cList[i].hasTechSumary) {
                if (contractorBusinessName == contractorName) {
                    if (isCompliance == true) {
                        contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; color: green;' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + cList[i].ContractorName + "</a> &nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:forestgreen; font-size: 20px; cursor:pointer;'>C</span>";
                    }
                    else {
                        contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; color: green;' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + cList[i].ContractorName + "</a> &nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:red; font-size: 20px; cursor:pointer;'>C</span>";
                    }

                }
                else {
                    if (contractorBusinessName != null && contractorBusinessName != "") {
                        if (isCompliance == true) {
                            contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; color: green;' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + "<span style='margin-left:8px; display:inline-block;'>" + contractorBusinessName + "<br/>" + cList[i].ContractorName + "</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:forestgreen; font-size: 20px; cursor:pointer;'>C</span>";
                        }
                        else {
                            contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; color: green;' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + "<span style='margin-left:8px; display:inline-block;'>" + contractorBusinessName + "<br/>" + cList[i].ContractorName + "</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:red; font-size: 20px; cursor:pointer;'>C</span>";
                        }

                    }
                    else {
                        if (isCompliance == true) {
                            contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; color: green;' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + contractorBusinessName + cList[i].ContractorName + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:forestgreen; font-size: 20px; cursor:pointer;'>C</span>";
                        }
                        else {
                            contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; color: green;' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + contractorBusinessName + cList[i].ContractorName + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:red; font-size: 20px; cursor:pointer;'>C</span>";
                        }
                    }
                }
            }
            else {
                if (contractorBusinessName == contractorName) {
                    if (isCompliance == true) {
                        contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; ' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + cList[i].ContractorName + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:forestgreen; font-size: 20px; cursor:pointer;'>C</span>";
                    }
                    else {
                        contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; ' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + cList[i].ContractorName + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");'  style='color:red; font-size: 20px; cursor:pointer;'>C</span>";

                    }
                }
                else {
                    if (contractorBusinessName != null && contractorBusinessName != "") {
                        if (isCompliance == true) {
                            contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; ' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + "<span style='margin-left:8px; display:inline-block;'>" + contractorBusinessName + "<br/>" + cList[i].ContractorName + "</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:forestgreen; font-size: 20px; cursor:pointer;'>C</span>";
                        }
                        else {
                            contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; ' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + "<span style='margin-left:8px; display:inline-block;'>" + contractorBusinessName + "<br/>" + cList[i].ContractorName + "</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:red; font-size: 20px; cursor:pointer;'>C</span>";
                        }
                    }
                    else {
                        if (isCompliance == true) {
                            contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; ' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + contractorBusinessName + cList[i].ContractorName + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:forestgreen; font-size: 20px; cursor:pointer;'>C</span>";
                        }
                        else {
                            contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline;display: inline-block; ' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + contractorBusinessName + cList[i].ContractorName + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<span id='compliance_Service' onclick = 'showComplianceSummary(" + cList[i].ContractorId + ");' style='color:red; font-size: 20px; cursor:pointer;'>C</span>";
                        }
                    }
                }
            }


            contractors += "</div></div>";
            //contractors += "<a class='' style='cursor:pointer;color:#000;text-decoration:underline; padding: 3px;  margin: 2px; margin-left:5px; ' onclick='AddExtraCommission(" + cList[i].ContractorId + "," + false + ")'>" + contractorBusinessName + " &diams; " + cList[i].ContractorName + "</a>";
            contractors += "</td><td style='width: 125px;font-size: medium;font-weight: bold;  onMouseOut= this.style.fontSize='100%'><span class = 'ContractorPhone'>" + cList[i].Phone + "</span></td>";
            //contractors += "<td>" + cList[i].State + "</td>";
            //contractors += "<td style='display:none;' style='width: 60px;'>" + parseFloat(cList[i].Commission).toFixed(2) + "%</td>";
            var nte = parseFloat(cList[i].NTEAmount == null ? 0 : cList[i].NTEAmount).toFixed(2);
            var orgNTE = parseFloat(cList[i].OriginalNTEAmount == null ? 0 : cList[i].OriginalNTEAmount).toFixed(2);
            contractors += "<td id='contractorTBLNte'><span class = 'ContractorNTE' id='contractorTBLNtespan' style='cursor: pointer;'>$" + nte + "</span><br />"
            if (orgNTE != 0 && nte != orgNTE)
                contractors += "<span style='text-decoration:line-through;'>$" + parseFloat(cList[i].OriginalNTEAmount == null ? 0 : cList[i].OriginalNTEAmount).toFixed(2) + "</span>";

            contractors += "</td>";

            contractors += "<td><button class='btn btn-primary' style='padding: 0 7px;' onclick='AddContractorNotesPopup(" + cList[i].ContractorId + ");'><i class='fa fa-plus'></i></button>";
            //if (isAuthorizedToViewReceipts) {
                if (cList[i].ReceiptExist) {

                    contractors += "<button style='padding:3px 7px; font-weight: bold; margin:2px;' class='btn btn-primary btnViewPayable' onclick='ViewReceipt(" + cList[i].Id + "," + cList[i].ContractorId + "," + cList[i].JobId + ")'>P</button>";
               }
                else {
                    contractors += "<button style='padding:3px 7px; font-weight: bold; margin:2px; margin-left:2px;'  class='btn btn-success btnViewPayable' onclick='ViewReceipt(" + cList[i].Id + "," + cList[i].ContractorId + "," + cList[i].JobId + ")'>P</button>";
                }
            //}


            contractors += "<button  style='padding:3px 7px; font-weight: bold; margin:2px; margin-left: 2px;' class='btn btn-primary' onclick='CreateSignOff(" + cList[i].ContractorId + "," + true + ")'>D</button>";

            if (cList[i].hasSubContractors) {
                contractors += "<button  style='padding:3px 7px; font-weight: bold; margin:2px; margin-left: 2px;' class='btn btn-large btn-danger' onclick='OpenSubTechnicians(" + cList[i].ContractorId + ")'>T</button>";
            }

            //if (cList[i].TechniciansList != null) {
            //    if (cList[i].TechniciansList.length > 0) {
            //        var JobId = $('#CallSlipId').val();
            //        populateSubTechnicans(JobId, cList[i].TechniciansList);
            //    }
            //    else {
            //        $('#SubTechContainer').hide();
            //    }
            //}
            // contractors += "<td></td>";
            contractors += "</td></tr>";
            //contractors += "<tr id='" + cList[i].ContractorId + "' >";
            contractors += "<tr id='" + cList[i].ContractorId + "' >";

            contractors += "<td colspan='3' style= 'border-top: 0px; margin-top: 0px;'>"
                + "<div style='margin: 0;max-height: 75px;overflow: auto;padding: 0;' id = 'txtContractorRecentNotes'>"
                + cList[i].RecentNotes
                + "</div>"
                + "</td>";
            primaryContractorId = cList[i].ContractorId;
            primaryContractorPhone = cList[i].Phone;

            contractors += "<td style= 'border-top: 0px; margin-top: 0px;'><div id='showratingDiv' onclick = 'ratingDiv(" + cList[i].ContractorId + ");'  class='" + cList[i].ContractorId + "' style =' ;width:120px; float:right;'>";
            var rating = GetContractorRatingsHTMLByRating(cList[i].ContractorRatings);
            var totalRatings = "  (" + cList[i].TotalContractorRatings + ")";

            contractors += "<div id='star-ratings' style = 'background-color:white;'>";
            contractors += rating + totalRatings;
            contractors += "</div></td>";
            contractors += "</tr>";
            contractorCommunicationList += "<tr><td>" + cList[i].ContractorName + "</td><td>" + cList[i].Phone + "</td></tr>";

        }
        
        if (technicians != null) {
            if (technicians.length > 0) {
                var JobId = $('#CallSlipId').val();
                populateSubTechnicans(JobId, technicians);
            }
            else {
                $('#SubTechContainer').hide();
            }
        }

    } else {
        $('#SubTechContainer').hide();
        contractorAssigned = "";
        contractorsRemove = "";
        contractors += "<tr id ><td colspan='100%'><h4 style='color:red;'>No contractors assigned to this job.</h4></td></tr>";
        contractorCommunicationList += "<tr><td colspan='2'><h4 style='color:red;'>No Contractors Found!</h4></td></tr>";
    }

    //contractors += "</table>";
    $('#' + id).parent().find('#contractorsBody').html(contractors);
    //$('#contractorsBody').html(contractors);

    $("#ToPhone").val(primaryContractorPhone);

    $('#tblJobContractorDetails tbody').html("");
    $('#tblJobContractorDetails tbody').html(contractorCommunicationList);
}


function GetTablesDataByJobId(id) {
    
    var address = $("#SP_Address").val();
    var storeNo = $('#SP_StoreNumber').val();

    var request = { address: address, storeNo: storeNo, CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: "Home/GetTablesDataByJobId",
        data: JSON.stringify(request),
        global: false,
        cache: false,
        success: function (msg) {
            
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                PopulateMessages(data.listMessages);
                PopulateJobHistoryTable(data.Location, id);
                displayCustomerEmailLog(data.Emails, id);
                PopulateContractorHistoryTable(data.ContractorActiveJobs, id);
                PopulateTechnicianHistoryTable(data.TechnicianHistoryList, id);
            }
            else {
                alert("Error");
            }
        },
        error: function () {
            //CommunicationError();

        }
    });
}


$('#ServiceTab_StoreNumber1').autocomplete({

    source: function (request, response) {

        $.ajax({
            url: baseURL + "Customer/GetStoresOnDispatchBoard",
            data: { query: request.term, CustomerId: $('#CustomerId').val() },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName,
                        value: item.Id
                    };
                }));
            }
        });
    },
    focus: function (event, ui) {

        $('#Stores').val(ui.item.label);
        event.preventDefault();
    },
    select: function (event, ui) {

        //GetCustomerDetailsByStoreNumberOrCustomerId("", ui.item.value);
        $('#ServiceTab_StoreNumber1').val(ui.item.value);
        $('#ServiceTab_StoreNumber1').val(ui.item.label);
        //LoadJobLocationHistory1();
        return false;
    },
    minLength: 1
});


function myStopFunction() {
    clearInterval(x);
}

function GetEmailsLogsByCustomerId() {
    $("#tblCustEmailLogBdy").html("");
    var customerId = $("#CustomerId").val();
    var jobId = $("#CallSlipId").val();
    if (customerId != null) {
        var request = { CustomerId: customerId, JobId: jobId };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Customer/GetEmailsLogsByCustomerId",
            data: JSON.stringify(request),
            global: false,
            cache: false,
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.hasOwnProperty("d");
                }
                else
                    data = msg;
                if (data.success) {
                    displayCustomerEmailLog(data.list);
                }
                else {
                    var message = "<tr><td colspan='3'>No email log exists.</td></tr>";
                    $("#tblCustEmailLogBdy").html(message);
                }
            },
            error: function () {
                CommunicationError();
            },
            complete: function () {
                GetContractorsByJobId();
            }
        });
    }
    else {
        var message = "<tr><td colspan='3'>No email log exists.</td></tr>";
        $("#tblCustEmailLogBdy").html(message);
    }
}

function ResetJobDataOnSP() {
    for (var i = 1; i <= 6; i++) {
        $('#tabs li:nth-child(' + i + ')').removeAttr('style');
        $('#tabs li:nth-child(' + i + ')').find('a').removeAttr('style');
    }
    $('#CreateInvoice').html("Mark Up");
    $('#CreateInvoice').removeClass("btn-Markup");
    $('.SPdocumentlist').html("");
    //$('#charmsRightMost').html("");
    $('#Contractors').html("");
    $('#profitAndLostGrid').html("");
    $('#tblBodyPartsGrid').html("");
    $('#PurchaseOrdersGrid').html("");
    //$('#tblBodyPurchaseOrdersGrid').html("");
    $('#tblBodyPaymentsGrid').html("");
    $('#tblBodyMessageGrid').html("");
    $('#TechnicianHistoryContainer').html("");
    $('#JobNotesContainer').html("");
    $('#ContractorHistoryContainer').html("");
    $('#StoreAcitivityContainer').html("");
    $('#SubTechContainer').html("");
    $('.purchaseOrderTable').html("");
    $('#cardNotRun').prop('checked', false);
    $('#lblPortalmessage').hide();
    $('#tbodyCreditCards').html("");
    $('#StatusHistoryColors').html("");
    $("#tblCustEmailLogBdy").html("");
    $("#divProgressBar").html("");
}

//var CutomerNotesForPopup = "";
//var StoreNotesForPopup = "";
var CustomerWrapupNotes = "";





// populate call slip details on charms panel
function FillCallSlipDetails(callslip, OnDateDayName, ftString, ttString, lat, lng) {
    clearInterval();
    //$('#equipment_name').prop("disabled", true);
    //$('#equipment_name').attr('readonly', 'true');
    $('#equipment_name').css('background-color', '#fff');
    $('#equipment_name').css('border-width', '2px');
    $('#equipment_name').css('border-style', 'inset');
    $('#equipment_name').css('border-color', 'initial');
    $('#equipment_name').css('border-image', 'initial');

    var nteAmountt = callslip.CustomerNTEAmount;
    $('#customerNteAmount').val(callslip.CustomerNTEAmount);

    //if (nteAmountt != "" && nteAmountt != null) {
    //    var nteAmount = parseFloat(nteAmountt).toFixed(2);
    //    if (nteAmount != null && nteAmount != "" && !isNaN(nteAmount)) {
    //        var nteNotes = "<p style = 'color:red!important' > <span style = 'font-size:medium;' ><b>Customer NTE Amount: " + nteAmount + "</b></span></p>";
    //        CutomerNotesForPopup = nteNotes + callslip.CustomerNotes;
    //    }
    //}
    //else {
    //    CutomerNotesForPopup = callslip.CustomerNotes;
    //}
    $('#CustomerNoteDetails').val(callslip.UrgentNoteDetails);
    $('#StoreUrgentNoteDetails').val(callslip.StoreUrgentNoteDetails);
    $('#CustomerTripCharges').val(callslip.CustomerTripCharges);
    $('#CustomerHourlyLabour').val(callslip.CustomerHourlyLabour);
    //StoreNotesForPopup = callslip.StoreNotes;
    CustomerWrapupNotes = callslip.CustomerWrapupNotes;
    var latitude = lat == null ? 0 : lat;
    var longtitude = lng == null ? 0 : lng;
    $('#Latitude').val(latitude);
    $('#Longtitude').val(longtitude);
    $('#CallSlipId').val(callslip.Id);
    $('.Service_tab_CallSlipId').text(callslip.Id);
    $('#CustomerId').val(callslip.CustomerId);
    $('#StoreId').val(callslip.StoreId);
    $('#CustomerName').val(callslip.CustomerName);
    $('#CustomerType').val(callslip.CustomerTypeId);

    if (callslip.CustomerTypeId == "2") {
        $('.store').hide();
    }
    else {
        $('.store').show();
    }
    if (callslip.isServiceChannelJob == true) {
        $('#serviceChannelDiv').show();
    }
    else {
        $('#serviceChannelDiv').hide();
    }

    $('#OrderFromDispatchBoardType').val('');
    $('#OrderFromDispatchBoardType').val(callslip.DispatchBoardType);
    $('#cbAutoJob').prop('checked', callslip.IsAuto);
    $('#charms #JobTypeId').val(callslip.JobTypeId);
    $('#Stores').val(callslip.StoreNumber);
    $('#ServiceTab_BookedByUserName').html(callslip.BookedByUserName);
    $('#ServiceTab_BookedByUserName').css("font-size", "16px");
    $('#ContactPerson').val(unescape(callslip.ContactPerson));
    $('#CalledInBy').val(callslip.CalledInBy);
    $('#PaymentMethodId').val(callslip.PaymentMethodId);
    $('#CountryId').val(callslip.CountryId);

    if (callslip.PaymentMethodId == "5") {
        $("#checkFields").show();
        var terst = $('#checkFields').html();
        $("#creditCardFields").hide();
        $("#CashForm").hide();
    }
    else if (callslip.PaymentMethodId == "4" || callslip.PaymentMethodId == "7") {
        $("#checkFields").hide();
        $("#creditCardFields").hide();
        $("#CashForm").show();
    }
    else {
        $("#checkFields").hide();
        $("#creditCardFields").show();
        $("#CashForm").hide();
    }

    if (callslip.TaxExempt) {
        $("#TaxExempt").attr("checked", "checked");
    }
    else {
        $("#TaxExempt").removeAttr("checked");
    }

    $('#Email').val(callslip.EmailAddress);
    $('#EstimateEmail').val(callslip.EmailAddress);
    $('#equipment_name').val(callslip.EquipmentName);
    $('#ServiceTab_Buzzer').val(callslip.BuzzerCode);
    $('#ServiceTab_WorkOrder').val(callslip.PONumber);
    $('#ServiceTab_StoreNumber').html((callslip.StoreNumber).length > 0 ? callslip.StoreNumber : "");
    $('#ServiceTab_StoreNumber1').val((callslip.StoreNumber).length > 0 ? callslip.StoreNumber : "");
    // $('#ServiceTab_StoreNumber12').val(callslip.StoreNumber).length > 0 ? callslip.StoreNumber : "");
    $('#ServiceTab_StoreName').html((callslip.StoreLocationName).length > 0 ? callslip.StoreLocationName : "");
    $('#ServiceTab_AlternatePhone').val(callslip.AlternatePhone);
    $('#ServiceTab_AdTypeName').val(callslip.AdTypeId).attr("selected", "selected");
    $('#InternetAdType').val(callslip.AdTypeWebSource);
    $('#OtherAdType').val(callslip.AdTypeOtherOption);
    $('#CurrentUserName').val(callslip.CurrentUserName);
    $('#ServiceTab_Fax').val(callslip.Fax);
    $('#ServiceTab_HistoricalData').html(callslip.HistoricalData);
    $('#IsEmergency').prop('checked', callslip.IsEmergency);
    $('#CustomerAutoUpdates').html(callslip.AutoUpdateCustomer);
    //------------------------
    //task #1473
    if (callslip.IsWarrantyJob)
        $('#IsWarrantyJob').val("1");
    else
        $('#IsWarrantyJob').val("0")
    $('#WarrantyStateChanged').val("0")
    //$('#IsWarrantyJob').prop('checked', callslip.IsWarrantyJob);
    //------------------------

    //in acc with task #1189
    if (callslip.IsEmergency && !callslip.CanEditEmergencyCheckbox) {
        $('#IsEmergency').prop('disabled', true);
    }
    else {
        $('#IsEmergency').prop('disabled', false);
    }

    if (callslip.CanAccessInvoices) {
        $('#tabMarkup').show();
    }
    else {
        $('#tabMarkup').hide();
    }


    if (callslip.IsEmergency) {
        $('#CustomerName').css({ "background-color": "red" });
        $('#CustomerName').css({ "color": "white" });
        $('#StoreNumber').css({ "background-color": "red" });
        $('#StoreNumber').css({ "color": "white" });
        $('#StoreName').css({ "background-color": "red" });
        $('#StoreName').css({ "color": "white" });
    }
    else {
        $('#CustomerName').css({ "background-color": "#2fade7" });
        $('#CustomerName').css({ "color": "white" });
        $('#StoreNumber').css({ "background-color": "#2fade7" });
        $('#StoreNumber').css({ "color": "white" });
        $('#StoreName').css({ "background-color": "#2fade7" });
        $('#StoreName').css({ "color": "white" });
    }

    $('#PreferedCommunicationMethod').prop('checked', callslip.PreferredMethodOfCummunication);
    $('#AdTypeId').val(callslip.AdTypeId);
    $('#WebSource').val(callslip.AdTypeWebSource);
    $('#EquipmentId').val(callslip.EquipmentId);
    $('#DayInterval').val(callslip.DateIntervalType);
    $('#ServiceDate').val(callslip.OnDate);
    $('#ServiceTimeFrom').val(callslip.FromTime);
    $('#ExpectedTime').val(callslip.FromTime);
    $('#ServiceTimeTo').val(callslip.ToTime);

    $('#Notes').val(unescape(callslip.Notes));
    $('#InternetAdType').val(callslip.AdTypeWebSource);
    $('#OtherAdType').val(callslip.AdTypeOtherOption);
    $('#dTime').val(callslip.TimeDispatched);
    $(".day-of-week").html('');
    $(".today").html('');
    $("#time").html('');

    if (callslip.DateIntervalType == 3) {
        $('.range').show();
        $('.singrange').hide();
        $(".today").text(OnDateDayName);
        $("#time").text(ftString + " - " + ttString);
        $("#time").css('font-size', '15px');
        $("#time").css('font-weight', 'bold');
    }
    else {
        $('.range').hide();
        $('.singrange').show();
        $(".today").text(OnDateDayName);
        $("#time").html(ftString);
        $("#time").removeAttr('style');
    }
    if (callslip.IsAuto) {
        $('#Year').val(callslip.Year);
        $('#Model').val(callslip.Model);
        $('#Make').val(callslip.Make);
        $('#Color').val(callslip.Color);
        $('#JobDescription').html(callslip.JobDescription);
        //$('#JobDescription').data('tEditor').value(callslip.JobDescription);
        //$('#CustomerType').val("3");
        $('.auto-fields').fadeIn('slow');
    }
    else {
        $('.auto-fields').fadeOut('slow');
        //$('#JobDescription').data('tEditor').value(callslip.JobDescription);
        $('#JobDescription').html(callslip.JobDescription);
    }

    $('#taSpecialInstructions').val(unescape(callslip.SpecialInstructions));
    $('#bTime').val(callslip.CreatedOn);
    $('#dTime').val(callslip.TimeDispatched);
    $('#CurrentStatus').html("");
    $('#CurrentStatus').html(callslip.CurrentStatus);
    $('#ChangedBy').html(callslip.ChangedBy);

    if (callslip.IsCOW) {
        $('#CallOnTheWay').hide();
    }
    else {
        $('#CallOnTheWay').show();
    }

    $('#Phone').val(callslip.Phone);
    $('#Address').val(unescape(callslip.Address));
    $('#ServiceTab_Zip').val(callslip.ZipCode);
    $('#NotExceedAmount').val(callslip.NTEAmount);
    $('#ServiceTab_State').val(callslip.StateId);
    $('#AddressType').val(callslip.AddressTypeId);
    $('#ServiceTab_City').val(callslip.City);
    $('#CountyId').val(callslip.CountyId);
    $('#CrossStreet').val(unescape(callslip.Street));
    //$("#PreferedCommunicationMethod").prop("checked", callslip.PreferedCommunicationMethod);

    //setUpdateCustomerDetails(callslip);
    //if (callslip.PreferredMethodOfCummunication) {
    //    $("#btnUpdateCustomer_ServicePanel").show();
    //}
    //else {
    //    $("#btnUpdateCustomer_ServicePanel").hide();
    //}

    // if invoice is created then upate the text of the
    // inovice button to View invoice else, to create invoice
    $('#CreateInvoice').html("Mark Up");

    if (callslip.InvoiceExist) {
        if (callslip.IsApproved) {
            $('#CreateInvoice').addClass("btn-Markup");
        }
        else {
            $('#CreateInvoice').addClass("btn-Markup-NotApproved");
        }
    }
    else {
        $('#CreateInvoice').removeClass("btn-Markup-NotApproved");
        $('#CreateInvoice').removeClass("btn-Markup");
    }

    $('#WorkOrder2').val(callslip.WorkOrder2);

    if (callslip.Locked) {
        $('#charms button').attr('disabled', 'disabled');
    }
    else {
        $('#charms button').removeAttr('disabled');
    }

    // make the buttons for print and email colored as red if the the estimate is printed or sent in email

    if (callslip.EstimatePrinted) {
        $('#printEstimate').css('background', '#ff0000');
    }
    else {
        $('#printEstimate').removeAttr('style');
    }
    if (callslip.EstimateEmailed) {
        $('#emailEstimate').css('background', '#ff0000');
    }
    else {
        $('#emailEstimate').removeAttr('style');
    }
    // basic job information on communication tab
    $('#comm_CustomerName').html(callslip.CustomerName);
    $('#comm_Address').html(callslip.Address);
    $('#comm_City').html(callslip.City);
    $('#comm_State').html($("#ServiceTab_State option:selected").text());
    $('#comm_Zip').html(callslip.ZipCode);
    $('#comm_JobDescription').html(callslip.JobDescription);
    $('#comm_IVR').html(callslip.IVRNumber);
    $('#comm_PIN').html(callslip.IVRPin);
    $('#comm_WorkOrderNumber').html(callslip.PONumber);

    if ($("#charms #JobStatusId option[value='0']").length == 0) {
        $("#charms #JobStatusId").prepend($('<option value="0" selected="selected">--Select--</option>'));
    }
    else {
        $("#charms #JobStatusId").val('0');
    }

    //get Job Margin and Show on Dispatch Board
    ShowJobMargin();
}


//get job margin
function ShowJobMargin() {
    $('#JobMarginDiv').html("");
    var CallSlipId = $('#CallSlipId').val();
    var request = { JobId: CallSlipId };
    $.ajax({
        type: "POST",
        url: baseURL + "Home/GetJobContractorMargin",
        data: JSON.stringify(request),
        contentType: "application/json, charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {

                var margins = data.JobMargin;

                if (margins.length > 0) {
                    var div = "";
                    for (var x = 0; x < margins.length; x++) {
                        if (margins[x] != "") {
                            if (parseFloat(margins[x].split('%')[0]) > 0)
                                div += "<div style='display: inline-block;background-color:green;color:white;border-radius:50%;font-size:16px;padding:3%;'>" + margins[x] + "</div>";
                            else
                                div += "<div style='display: inline-block;background-color:red;color:white;border-radius:50%;font-size:16px;padding:3%;'>" + margins[x] + "</div>";
                        }
                    }
                    $('#JobMarginDiv').html(div);
                }

            } else {
                Notify(data.message, 'error');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        },
        complete: function () {
        }
    });
}



//*****Function open dialog onclick Update Customer

function UpdateNotification() {
    $('#CustomerUpdateDialog').dialog({
        title: 'Customer Update Status',
        width: 430,
        resizable: true,
        modal: true
    });
}

//*****Function to update notification name and email for automatic status update email
function UpdateNotificationEmail() {

    var otherEmail = "";
    $('.otherEmailsServicePan').each(function () {
        if ($(this).val() != null && $(this).val() != "" && $(this).val() != "0") {
            otherEmail += $(this).val();
            otherEmail += ",";
        }
    });
    otherEmail = otherEmail.slice(0, -1);
    var name = $('#NotificationName').val();
    var email = $('#NotificationEmail').val();
    var callslipId = $('#CallSlipId').val();
    var OnCreated = $('#ServicePanel_chkOnCreated').is(':checked');
    var OnCompleted = $('#ServicePanel_chkOnCompleted').is(':checked');
    var request = { CallslipId: callslipId, notificationName: name, notificationEmail: email, updateOnCreated: OnCreated, updateOnCompleted: OnCompleted, OtherEmails: otherEmail };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/UpdateEmailNotification",
        data: JSON.stringify(request)
    });
    $('#CustomerUpdateDialog').dialog("destroy");
}

$('#btnSaveCustomerUpdateStatus').click(function () {
    UpdateNotificationEmail();
});

// renders documents grid for individual call slip
function RenderDocuments(documents) {
    console.log("In Render Documents total: " + documents.length);

    var documentslist = "<table id='docList' class='table table-advance'><thead><tr><th>Document  &nbsp;&nbsp; ";
    documentslist += "<button class='btn btn-large btn-primary' onclick='AddDocumentPopup();'><i class='icon-plus'> </i></button>";
    documentslist += "</select> </th><th></th><th style='vertical-align: middle;'>Delete</th><th><button id='RefreshDocuments' style='float: right;' onclick='GetDocumentsByCallSlipId();return false;' class='btn btn-primary'><i class='icon-refresh'></i></button></th></tr></thead>";
    if (documents.length > 0) {

        for (var i = 0; i < documents.length; i++) {
            var filepath = documents[i].Path;
            if (filepath.indexOf('~') >= 0) {
                filepath = getBaseUrl() + filepath.substring(1);
            }
            documentslist += "<tr><td><a style='width:200px;color:#000;' target='_blank' href='" + filepath + "'>" + documents[i].Title + "</a>" +
                "</td><td><b>" + documents[i].UserName + " - " + documents[i].CreatedOn + "</b></td><td><a onclick='DeleteDocumentByCallSlipIdDocumentId(" + documents[i].Id + ");return false;' class='btn btn-danger'><i class='icon-trash'></i></a></td><td></td>";

        }
    } else {
        documentslist += "<tr><td colspan='100%' style='border:none;'><h4 style='color:red;'>Documents does not exist.</h4></td></tr>";
    }

    documentslist += "</table>";

    $('.SPdocumentlist').html("");
    $('.SPdocumentlist').html(documentslist);
}

// documents tab => delete document by getting of document
// and passing to server with call slip id as well
function DeleteDocumentByCallSlipIdDocumentId(docId) {

    $("<div></div>").dialog({
        title: "Please confirm",
        buttons: [{
            text: "Yes",
            id: "btnConfirm",
            click: function () {
                var request = { CallSlipId: $('#CallSlipId').val(), DocumentId: docId };
                $.ajax({
                    type: "POST",
                    contentType: "application/json, charset=utf-8",
                    url: baseURL + "CallSlip/DeleteDocument",
                    global: false,
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty("d")) {
                            data = msg.d;
                        } else
                            data = msg;
                        if (data.success) {
                            GetDocumentsByCallSlipId();
                        } else {
                            Notify(data.message, 'error');
                        }
                    },
                    error: function () {
                        CommunicationError();
                    }
                });
                $(this).dialog("close");
            }
        }, {
            text: "No",
            id: "btnCancel",
            click: function () {
                $(this).dialog("destroy");
            }
        }],
        open: function () {

            StyleWarningDiagle($(this));

            $(this).html("<div class='warning'><h2>Are you sure to delete ?</h2></div>");

            $('#btnConfirm').removeAttr("class");
            $('#btnCancel').removeAttr("class");

            $('#btnConfirm').addClass("btn btn-success");
            $('#btnCancel').addClass("btn btn-danger");

        }
    });


}

// show hide the search panel
function toggleaction(ctrl, action) {

    $('.action-container').slideToggle(500);
}

// display popup for contractors grid
function LoadContractors() {
    var lat = $('#Latitude').val();
    var long = $('#Longtitude').val();
    var callslipId = $('#CallSlipId').val();
    console.log("IN LoadContractors" + lat + " long:" + long + " jobId:" + callslipId);
    var JobState = $('#ServiceTab_State').val();
    //7 (9),18 23 27 34 ,  35,   37 ,  40 , 44 ,45,  54 , 55 ,  59
    if (JobState == "2" || JobState == "7" || JobState == "9" || JobState == "18" || JobState == "23" || JobState == "27" || JobState == "34" || JobState == "35" || JobState == "37" || JobState == "40" || JobState == "44" || JobState == "45" || JobState == "54" || JobState == "55" || JobState == "59") {
        $('#LicenseState').html('Contractor License Required in ' + $('#ServiceTab_State').text());
        $('#LicenseState').show();
    }
    //$('#technicians').load(baseURL + "Home/ContractorPartial" + "?callslip=" + callslipId + "?latitude=" + lat + "&longtitude=" + long);

    $('#technicians').load(baseURL + "Home/ContractorPartial" + "?callslip=" + callslipId);

    $('#technicians').dialog({
        title: 'Assign Contractor',
        resizable: true,
        width: $(window).width() - 80,
        height: $(window).height() - 40,
        modal: true,
        buttons: [{
            text: "Confirm",
            id: "ConfirmContractors",
            click: function () {
                DoAssigningContractors();
            }
        },
        {
            text: "Close",
            id: "btnCancel",
            click: function () {
                $(this).dialog("destroy");
                //DoAssigningContractors();
                $('#divManageuserPermissions').html("");
            }
        }],
        close: function (event, ui) {
            $(this).dialog('destroy');
            $('#technicians').html("");
            primaryContractorId = "";
        },
        open: function () {
            $('#btnCancel').removeAttr("class");
            $('#ConfirmContractors').removeAttr("class");
            $('#btnCancel').addClass("cancel btn btn-danger");
            $('#ConfirmContractors').addClass("success btn btn-primary");
        }
    });
}

// function called on grid for both contractors
// and callslip current does nothing
function onDataBinding(e) {
    console.log("onDataBinding");
}

function contractors_grid_Binded(e) {

    console.log("IN contractor grid Binded");
    $('#Contractors table tr').each(function () {
        //
        var id = $(this).attr('id');
        $('input[type="checkbox"][id="' + id + '"]').attr('checked', 'checked');
        primaryContractorId = primaryContractorId;
        $('input[type="radio"][name="IsPrimary"][id="' + primaryContractorId + '"]').attr('checked', 'checked');

        //var contractorRatings = $(this).attr('ContractorRatings');
        //var html = GetContractorRatingsHTMLByRating(contractorRatings);
        //var origional = $(this).find('td:nth-child(2)').text();
        //$(this).find('td:nth-child(2)').text(origional + html);
    }
    );
}

function SubTechnicians_grid_Binded(e) {

    console.log("IN Binded");
    $('#SubTechContainer table tr').each(function () {
        var id = $(this).attr('id');
        $('input[type="checkbox"][id="' + id + '"]').attr('checked', 'checked');
        primaryContractorId = primaryContractorId;
        $('input[type="radio"][name="IsPrimary"][id="' + primaryContractorId + '"]').attr('checked', 'checked');
    }
    );
}

function contractorsGrid_onRowDataBound(e) {
    console.log("IN contractorsGrid_onRowDataBound");
    //the DOM element (<tr>) representing the row which is being databound
    var row = e.row;
    var dataItem = e.dataItem;
    //You can use the OnRowDataBound event to customize the way data is presented on the client-side
    if (dataItem.ContractorRatings > 0)
        row.cells[6].innerHTML += GetContractorRatingsHTMLByRating(dataItem.ContractorRatings);
    //row.cells[1].innerHTML = dataItem.BusinessName +"<br>"+ GetContractorRatingsHTMLByRating(dataItem.ContractorRatings);
    if (dataItem.PriorityName == "Suspended") {
        //row.cells[1].innerHTML.style["background-color"] = "red";
        e.row.style["color"] = "#256bda";
        var id = e.row.cells[0].firstChild.id;
        $("#" + id).attr("disabled", true);
        e.row.cells[0].style["disabled"] = true;
        e.row.style["text-decoration"] = "line-through";
    }
}

$('.legendContainer input[type="text"]').keydown(function (e) {
    if ((e.keyCode ? e.keyCode : e.which) == 13) {
        $('#btnSearchJobs').trigger('click');
    }
});

function ResetMainSearchField() {
    if ($('.action-container').is(':visible')) {
        $('.action-container').hide();
    }
    $('#MainDispatchBoardDateFilter').val("");
    refreshCallsGrid(0);

}

function refreshCallsGrid(pageNo) {
    console.log("In refreshCallsGrid");
    var grid = $('#callslip-grid').data('kendoGrid');
    grid.dataSource.page(1);
    grid.dataSource.read();

    grid.refresh();
    //if (pageNo != null && pageNo > 0) {
    //    //console.log("IN refreshCallsGrid Calling grid.pageTo(pageNo);");
    //    grid.pageTo(pageNo);
    //} else {
        //console.log("IN refreshCallsGrid Calling grid.ajaxRequest();");
        //grid.ajaxRequest();
    //}
}


//SearchJob 3 = Dispatch, 4 = Dispatch Manager, 5 = Accounting, 6 = CSR
function SearchJobs(searchType) {
    $("#rowMarker").hide();
    $("#txtSearchType").val(searchType);
    var jobTypeId = $('.action-container #JobTypeId').val();
    var cbInState = $('.action-container #cbInState').is(':checked');
    var cbOutOfState = $('.action-container #cbOutOfState').is(':checked');
    var cbCitiBank = $('.action-container #cbCitiBank').is(':checked');
    var cbAissJobs = $('.action-container #cbAissJobs').is(':checked');
    var cbProjects = $('.action-container #cbProjects').is(':checked');
    var customerTypeId = $('.action-container #CustomerTypeId').val();
    var jobStatusId = $('.action-container #JobStatusId').val();
    var contractorNameFilterPanel = $('.action-container #ContractorNameFilterPanel').val();
    var expectedFromTime = $('.action-container #ExpectedFromTime').val();
    var expectedToTime = $('.action-container #ExpectedToTime').val();
    var BookedFromTime = $('.action-container #ExpectedFromTime1').val();
    var BookedToTime = $('.action-container #ExpectedToTime1').val();
    var filterPanelWorkOrder = $('.action-container #FilterPanel_WorkOrder').val();
    var filterPanelPhoneNumber = $('.action-container #FilterPanel_PhoneNumber').val();
    var byCustomerName = $('.action-container #ByCustomerName').val();
    var byStoreNumber = $('.action-container #ByStoreNumber').val();
    var byStoreName = $('.action-container #ByStoreName').val();
    var byCity = $('.action-container #ByCity').val();
    var byJobId = $('.action-container #ByJobId').val();
    var byState = $('.action-container #ByState').val();
    var techFirstName = $('.action-container #TechFirstName').val();
    var techLastName = $('.action-container #TechLastName').val();
    var techCompanyName = $('.action-container #TechCompanyName').val();
    var filterPanelAddress = $('.action-container #FilterPanel_Address').val();
    var filterPanelPoTrackingNumber = $('.action-container #FilterPanel_POTrackingNumber').val();
    var byCustomerWO = $('.action-container #ByCustomerWO').val();

    if (/*jobTypeId === "1" */ cbInState == 1 && cbOutOfState == 1 && cbCitiBank == 1 && cbAissJobs == 1 && cbProjects == 1 && customerTypeId === "5" && jobStatusId === "0" && contractorNameFilterPanel === "" && expectedFromTime === "" &&
        expectedToTime === "" && expectedFromTime1 === "" && expectedToTime1 === "" && filterPanelWorkOrder === "" && filterPanelPhoneNumber === "" && byCustomerName === "" && byCustomerWO === "" && byStoreNumber === "" && byStoreName === "" && byCity === "" && byJobId === "" &&
        byState === "0" && techFirstName === "" && techLastName === "" && techCompanyName === "" && filterPanelAddress === "" && filterPanelPoTrackingNumber === "") {
        $("<div></div>").dialog({
            title: "Please confirm",
            width: 430,
            height: 200,
            buttons: [{
                text: "Yes",
                id: "btnConfirm",
                click: function () {
                    $(this).dialog("close");
                    refreshCallsGrid(1);
                }
            }, {
                text: "No",
                id: "btnCancel",
                click: function () {
                    $(this).dialog("destroy");
                }
            }],
            open: function () {

                StyleWarningDiagle($(this));

                $(this).html("<div class='warning'><h2>No filter criteria has been selected, <br> Do you want to search all the records?</h2></div>");

                $('#btnConfirm').removeAttr("class");
                $('#btnCancel').removeAttr("class");

                $('#btnConfirm').addClass("btn btn-success");
                $('#btnCancel').addClass("btn btn-danger");

            }
        });
    }
    else {
        refreshCallsGrid(1);
    }
}



function TodaysJobs() {
    var fromDate = new Date();
    fromDate.setMonth(fromDate.getMonth() - 1);
    $('.action-container #ExpectedFromTime').val($.datepicker.formatDate("mm/dd/yy", fromDate));
    $('.action-container #ExpectedToTime').val($.datepicker.formatDate("mm/dd/yy", new Date()));
};

function ClearFilters() {
    $('.action-container #JobTypeId').val(0);

    //$('.action-container #CustomerTypeId').val(5);
    //$('.action-container #JobStatusId').val(0);

    $('.action-container #CustomerTypeId').val('5').trigger('chosen:updated');
    $('.action-container #JobStatusId').val('0').trigger('chosen:updated');
    //$('.action-container #ContractorId').val('0').trigger('chosen:updated');
    $('.action-container #ExpectedFromTime').val("");
    $('.action-container #ExpectedToTime').val("");
    $('.action-container #BookedFromTime').val("");
    $('.action-container #BookedToTime').val("");
    $('.action-container #FilterPanel_WorkOrder').val("");
    $('.action-container #FilterPanel_PhoneNumber').val("");
    $('.action-container #ByCustomerName').val("");
    $('.action-container #ByCustomerWO').val("");

    $('.action-container #ByStoreNumber').val("");
    $('.action-container #ByStoreName').val("");
    $('.action-container #ByCity').val("");
    $('.action-container #ByJobId').val("");
    $('.action-container #ByState').val('0').trigger('chosen:updated');
    $('.action-container #TechFirstName').val("");
    $('.action-container #TechLastName').val("");
    $('.action-container #TechCompanyName').val("");
    $('.action-container #FilterPanel_Address').val("");
    $('.action-container #FilterPanel_POTrackingNumber').val("");
    $('#MainDispatchBoardDateFilter').val("");
};


function GetHistory() {
    ClearFilters();
    $("#ByStoreNumber").val($('#ServiceTab_StoreNumber').text());
    $("#ByCity").val($('#ServiceTab_City').val());
    var storeNumber = $("#ByStoreNumber").val();
    if (storeNumber == "" || storeNumber == null) {
        $("#FilterPanel_Address").val($("#Address").val());
    }

    if ($('#charms').is(':visible') || ($('#btnDockPanel').html().indexOf("Hide") > 0)) {
        //if ($('#charms').is(':visible')) {
        toggleCharms(interval);
        $('#rowMarker').css({ top: '225px' });
    }
    $("#btnsearchjobs").click();
}

// function used to call on the COW click to save Call on the way details
function CallOnTheWay() {
    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/CallOnTheWay",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                Notify(data.message, 'success');
                SelectJob(data.JobId);
                //refreshCallsGrid(0);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

// refreshing the contractors in grid
function refreshcontractorsGrid() {
    var grid = $("#contractors-grid").data("tGrid");
    grid.filter('');
    grid.ajaxRequest();
}

function onContractorGridDataBinding(e) {
    var searchModel = {
        latitude: $('#Latitude').val(),
        longtitude: $('#Longtitude').val()
    };
    e.data = searchModel;
}

var contractorAssigned = "";
var contractorsRemove = "";
var primaryContractorId = "";
var SubcontractorAssigned = "";
var SubcontractorsRemove = "";

function BuildContractorsArray(id, cbox) {
    var contractorId = id;

    if ($(cbox).is(':checked')) {

        //show blackballlist popup if list exists
        var request = { ContractorId: contractorId };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Contractor/GetBlackBallList",
            data: JSON.stringify(request),
            global: false,
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {

                    if (data.message != null) {
                        ShowBlackBallList(data.message);
                    }
                    if (data.hasLicense == false && $("#LicenseState").is(":visible")) {
                        Notify1("You have selected a Contractor who is not licensed, proceed with caution.", "warning");
                    }

                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });

        contractorAssigned += id + ",";
        contractorsRemove = RemoveContractor(contractorsRemove, id, ',');
    } else {
        contractorAssigned = RemoveContractor(contractorAssigned, id, ',');
        contractorsRemove += id + ",";
    }
}


function OpenSubTechnicians(ContractorId) {
    $('#SubTechnicianDiv').load(baseURL + "Home/SubTechniciansPartial" + "?Id=" + ContractorId);
    $('#SubTechnicianDiv').dialog({
        title: 'Assign Technician',
        resizable: true,
        width: $(window).width() - 1000,
        height: $(window).height() - 300,
        modal: true,
        buttons: [{
            text: "Confirm",
            id: "ConfirmSubContractors",
            click: function () {
                DoAssigningSubContractors(ContractorId);
            }
        },

        ],
        open: function () {
            $('#ConfirmSubContractors').addClass("success btn btn-primary");
        }
    });
}

function BuildSubContractorsArray(id, cbox) {
    if ($(cbox).is(':checked')) {
        SubcontractorAssigned += id + ",";
        SubcontractorsRemove = RemoveSubContractor(contractorsRemove, id, ',');
    } else {
        SubcontractorAssigned = RemoveSubContractor(contractorAssigned, id, ',');
        SubcontractorsRemove += id + ",";
    }
}

function RemoveContractor(list, value, separator) {

    separator = separator || ",";
    var values = list.split(separator);
    for (var i = 0; i < values.length; i++) {
        if (values[i] == value) {
            values.splice(i, 1);
            return values.join(separator);
        }
    }
    return list;
}

function RemoveSubContractor(list, value, separator) {

    separator = separator || ",";
    var values = list.split(separator);
    for (var i = 0; i < values.length; i++) {
        if (values[i] == value) {
            values.splice(i, 1);
            return values.join(separator);
        }
    }
    return list;
}

// assign contractor
function AssignContractor(ids, rids) {
    var request = { CallSlipId: $('#CallSlipId').val(), ContractorToBeAssignedIds: ids, contractorsToBeRemovedIds: rids, PrimaryContractorId: primaryContractorId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/AssignContractor",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                if (data.showStatus != '') {
                    $('#CurrentStatus').html("");
                    $('#CurrentStatus').html(data.showStatus);
                    $('#ChangedBy').html("");
                    $('#ChangedBy').html(data.changedBy);
                }
                //SelectJob(data.JobId);
                //refreshCallsGrid(0);
                //Notify(data.message, 'success');
                $("#technicians").dialog("close");
                primaryContractorId = "";
                //if (data.emailBody != null && data.emailBody != "") {
                //    showUpdateCustomerPopupOrPortal(data.emailBody);
                //}
                GetContractorsByJobId();

            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        },
        complete: function () {
            //GetEmailsLogsByCustomerId();
        }
    });
}

// assign contractor
function AssignSubContractor(ids, rids, mainContractorId) {

    var request = { CallSlipId: $('#CallSlipId').val(), SubContractorToBeAssignedIds: ids, contractorsToBeRemovedIds: rids, MaincontractorId: mainContractorId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/AssignSubContractor",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                //SelectJob(data.JobId);
                //refreshCallsGrid(0);
                //Notify(data.message, 'success');
                SubcontractorAssigned = "";
                $('#SubTechnicianDiv').dialog("close");
                primaryContractorId = "";
                GetContractorsByJobId();
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        },
        complete: function () {
            //GetEmailsLogsByCustomerId();
        }
    });
}


function DoAssigningContractors() {
    AssignContractor(contractorAssigned, contractorsRemove);
}


function DoAssigningSubContractors(mainContractor) {

    AssignSubContractor(SubcontractorAssigned, contractorsRemove, mainContractor);
}


// Send Complex Email Task# 1490

function SendComplexJob() {
    var customerID = $('#CustomerId').val();
    var CallSlipId = $('#CallSlipId').val();
    var request = { cID: customerID, JobId: CallSlipId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/SendComplexJobEmail",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                Notify(data.message, 'success');
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        },
        complete: function () {
        }
    });
}

function populateSubTechnicans(JobId, TechList) {
    $('#SubTechContainer').html("");
    var tech = TechList;
    var SubTech = "<strong>Sub Technicians:</strong><br><table class='table table-advance'><thead><tr><th>Name</th><th>Main Contractor</th><th>Phone</th><th></th><th></th></tr></thead>";
    for (var i = 0; i < tech.length; i++) {
        SubTech += "<tr id='" + tech[i].Id + "'><td ><input name='RemoveTech' type='radio' onclick='RemoveTech(" + tech[i].Id + ")' id='" + tech[i].ContractorId + "' />" +
            "<a class='' style='cursor:pointer;color:#000;text-decoration:underline; padding: 3px;  margin: 2px; margin-left:5px; ' onclick='ShowTechnicianInfo(" + tech[i].Id + "," + false + ")'>" + tech[i].BussinessName + "</a>"; + "</td>";
        SubTech += "<td >" + tech[i].AssignContractor + "</td>";
        SubTech += "<td >" + tech[i].MainTechnicianPhone + "</td>";
        SubTech += "  " + "<td ></a><button class='btn btn-primary' style='padding: 0 7px;' onclick='AddTechnicianNotesPopup(" + tech[i].Id + ");'><i class='fa fa-plus'></i></button>";
        SubTech += "<td><button  style='padding:3px 7px; font-weight: bold; margin:2px; margin-left: 2px;' class='btn btn-primary' onclick='ShowTechnicianInfo(" + tech[i].Id + "," + true + ")'>D</button></td>";
    }

    SubTech += "</tr></table>"
    $('#SubTechContainer').show();
    $('#SubTechContainer').html(SubTech);
}

function RemoveTech(TechId) {

    $('#btnRemoveTechnician').show();
    $('#btnRemoveTechnician').attr('value', TechId);
}

function ShowTechnicianInfo(TechnicianId, dispatchType) {
    if (dispatchType == false) {
        $('#divTechETAInfo').hide();
    }
    else {
        $('#divTechETAInfo').show();
    }

    $('#IsTechDispatch').val(dispatchType);
    var test = TechnicianId;
    var request = { Id: TechnicianId, CallSlipId: $("#CallSlipId").val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Technician/GetTechnician",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else data = msg;
            if (data.success) {
                populateTechnician(data.Technician, data.TechNotes);

            } else {

            }
        },
        error: function () { CommunicationError(); }
    });
}


function populateTechnician(Technician, Notes) {
    $('#TechnicianInfo').dialog({
        title: 'Technician Info',
        resizable: false,
        minHeight: '800px',
        width: '800px',
        top: '5px',
        left: '224px',
        modal: true
    });
    $("input[type='radio']").each(function () {
        $(this).prop('checked', false);
        $('#txtTechOtherEta').val("");
        $('#txtTechOtherEta').hide();
    });
    $('#TechnicianDetailsNotes').html(Technician.Notes);
    var note = "<table class='table table-advance'>";
    if (Notes.length > 0) {
        for (var i = 0; i < Notes.length; i++) {
            note += "<tr><td>" + Notes[i].Notes + "<b><span class='notesAuthor pull-right'>[" + Notes[i].CreatedOn +
                " - " + Notes[i].UserName + "]</span></b></td></tr>";
        }
    }
    else {
        note += "<tr><td colspan='1'><h4 style='color:red;'>Notes does not exist.</h4></td></tr>";
    }
    note += "</table>";
    $('#TechnicianDetailsNotes').html("");
    $('#TechnicianDetailsNotes').html(note);
    $('#hdnTechnicianId').val(Technician.Id);
    $('#TechInfoFirstName').val(Technician.FirstName);
    $('#TechInfoLastName').val(Technician.LastName);
    $('#TechBusinessName').val(Technician.BussinessName);
    $('#TechMainPhone').val(Technician.MainTechnicianPhone);
    $('#TechMainEmail').val(Technician.MainEmailAddress);
    $('#TechLoginPassword').val(Technician.LoginPassword);
    $('#TechContractorId').val(Technician.ContractorId).trigger("chosen:updated");
    $('#TechIsDeleted').prop('checked', Technician.IsDeleted);
    $('#techFax').val(Technician.TechnicianFax);
    $('#TechContactPerson').val(Technician.ContactPerson);


}


function OpenNewWindowForTechDispatch() {

    DispatchUrl = getBaseUrl() + "/Home/CreateWorkorderSignOff/" + "?CallSlipId=" + $("#CallSlipId").val() + "&TechnicianId=" + $("#hdnTechnicianId").val();
    console.log("url:" + DispatchUrl);
    window.open(DispatchUrl, '_blank');
    //SelectJob($("#CallSlipId").val());

}

function UpdateTechnicianInfo() {
    console.log(" In UpdateTechnicianInfo");

    var request = {
        Id: $('#hdnTechnicianId').val(), FirstName: $('#TechInfoFirstName').val(), LastName: $('#TechInfoLastName').val(), BussinessName: $('#TechBusinessName').val(),
        MainTechnicianPhone: $('#TechMainPhone').val(), MainEmailAddress: $('#TechMainEmail').val(), LoginPassword: $('#TechLoginPassword').val(), ContractorId: $('#TechContractorId').val(),
        TechnicianFax: $('#techFax').val(), IsDeleted: $('#TechIsDeleted').is(":checked"), CallSlipId: $('#CallSlipId').val(), ContactPerson: $('#TechContactPerson').val()
    }

    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Technician/SaveAndDispatchTech",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else data = msg;

            if (data.success) {
                Notify(data.message, 'success');

                //
            } else {
                Notify(data.message, 'error');
            }
            $('#TechnicianInfo').dialog("close");
        },
        error: function () { CommunicationError(); }
    });
}

$('#btnDispatchTech').click(function (e) {
    var selectedVal = "";
    var selected = $("#divTechETAInfo input[type='radio']:checked");
    if (selected.length > 0) {
        selectedVal = selected.val();
        if (selectedVal == 'Other') {
            selectedVal = $('#txtTechOtherEta').val();
        }
    }

    if (selectedVal == "") {
        Notify("Please Select Eta For Technician", 'error');
    }
    else {
        var request = {
            Id: $('#hdnTechnicianId').val(), FirstName: $('#TechInfoFirstName').val(), LastName: $('#TechInfoLastName').val(), BussinessName: $('#TechBusinessName').val(),
            MainTechnicianPhone: $('#TechMainPhone').val(), MainEmailAddress: $('#TechMainEmail').val(), LoginPassword: $('#TechLoginPassword').val(), ContractorId: $('#TechContractorId').val(),
            TechnicianFax: $('#techFax').val(), IsDeleted: $('#TechIsDeleted').is(":checked"), TechETA: selectedVal, CallSlipId: $('#CallSlipId').val(), ContactPerson: $('#TechContactPerson').val()
        }

        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Technician/SaveAndDispatchTech",
            data: JSON.stringify({ 'model': request }),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else data = msg;

                if (data.success) {

                    if ($('#IsTechDispatch').val() == "true") {
                        e.preventDefault();
                        $("#TechnicianInfo").dialog("close");
                        OpenNewWindowForTechDispatch();
                    }
                    else {
                        Notify("Tech Updated!", 'success');
                        //SelectJob($("#CallSlipId").val());
                        ShowJobNotes();
                    }
                } else {
                    Notify(data.message, 'error');
                }
                $('#TechnicianInfo').dialog("close");
            },
            error: function () { CommunicationError(); }
        });

    }
});

/// Function te remove contractor
function RemoveSubTech() {

    var request = { TechnicianId: $('#btnRemoveTechnician').attr('value'), JobId: $(".Service_tab_CallSlipId").text() }
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Technician/RemoveTechnician",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else data = msg;
            if (data.success) {
                //Notify("Technician Removed Successfully!", "success");
                //SelectJob($(".Service_tab_CallSlipId").text());
                $('#btnRemoveTechnician').hide();
                //$('#btnFirstNoticeForm').hide();
                GetContractorsByJobId();
            } else {
                Notify("Technician couldn't be removed!", "error");
            }
        },
        error: function () { CommunicationError(); }
    });

}

function showJobWrapupNotesDialog() {
    $('#ConfirmJobWrapupNotes').removeAttr('disabled');
    $('#CustomerJobWrapupNotesPopup').dialog({
        title: "Customer's Job Wrap-up Instructions/Notes",
        resizable: true,
        width: '500px',
        modal: true,
    });
    $('#txtCustomerJobWrapupNotes').html(CustomerWrapupNotes);
}

function ShowCustomerJobWrapupNotes() {
    var statusArrayForUrgentNotice = [11, 10, 23, 9, 22, 8, 27, 7, 6, 5, 31, 32];
    var newStatus = $('#charms #JobStatusId').val();

    if (newStatus == 4) {
        showJobWrapupNotesDialog();
    }
    else if (newStatus == 26) {
        CheckIfUrgentDetailsExist(newStatus);

    }
    else if ($.inArray(parseInt(newStatus), statusArrayForUrgentNotice) != -1) {
        CheckIfUrgentDetailsExist(newStatus);

    }
    else {
        console.log("Calling UpdateJob");
        UpdateJob();
    }

}
$('#cancelJobWrapupNotes').click(function () {
    $('#charms #JobStatusId').val(0);
    $("#CustomerJobWrapupNotesPopup").dialog("close");
});

$('#ConfirmJobWrapupNotes').click(function () {

    $('#ConfirmJobWrapupNotes').attr("disabled", "disabled");

    console.log("Calling UpdateJob ");
    var IVRInOut = "";
    var UpdateCustomer = "";
    var FollowedUp = "";
    var BillType = "";
    var RequiredInfo = "";
    var JobCompletionNote = "Job completed: ";
    $("input:checkbox[name=IVRTechInOut]:checked").each(function () {

        IVRInOut = $(this).val();

    });
    $("input:checkbox[name=UpdateCustomer]:checked").each(function () {

        UpdateCustomer = $(this).val();
        JobCompletionNote = JobCompletionNote + UpdateCustomer + ",";
    });
    $("input:checkbox[name=FollowedUp]:checked").each(function () {

        FollowedUp = $(this).val();
        JobCompletionNote = JobCompletionNote + "; followed up with " + FollowedUp + ",";
    });
    $("input:checkbox[name=BillType]:checked").each(function () {

        BillType = $(this).val();
        JobCompletionNote = JobCompletionNote + "; " + BillType + " ";
    });
    JobCompletionNote = JobCompletionNote + " Billing; "
    $("input:checkbox[name=RequiredInfo]:checked").each(function () {

        RequiredInfo = $(this).val();
        JobCompletionNote = JobCompletionNote + RequiredInfo + " Work order";
    });

    SaveJobCompletionNotes(JobCompletionNote, IVRInOut);
    uncheckCompletedCheckList();

    $("#CustomerJobWrapupNotesPopup").dialog("close");
    UpdateJob();

});

$('#cancelJobWrapupNotesPrepaid').click(function () {
    $('#charms #JobStatusId').val(0);
    $('#PrepaidJobWrapupNotesPopup').dialog("close");
});
var checkJobPrepaid = false;
$('#ConfirmJobWrapupNotesPrepaid').click(function () {

    console.log("Prepaid Job working");
    var prepaidAmount = $("#txtPrepaidAmount").val();
    var contractor = (($("#contractorListPrepaidJob").val() != "") || ($("#contractorListPrepaidJob").val() != "")) ? $("#contractorListPrepaidJob").val() : 0;
    if (prepaidAmount != null && prepaidAmount != "" && contractor != null && contractor != "") {
        JobPrepaidAmount(prepaidAmount, contractor);

    }
    UpdateJob();

    $('#PrepaidJobWrapupNotesPopup').dialog("close");

});


function uncheckCompletedCheckList() {

    $("input:checkbox[name=UpdateCustomer]:checked").each(function () {

        $(this).attr('checked', false);
    });
    $("input:checkbox[name=FollowedUp]:checked").each(function () {
        $(this).attr('checked', false);
    });
    $("input:checkbox[name=BillType]:checked").each(function () {
        $(this).attr('checked', false);
    });
    $("input:checkbox[name=RequiredInfo]:checked").each(function () {
        $(this).attr('checked', false);
    });
}

function JobPrepaidAmount(Amount, contractorId) {

    console.log("In JobPrepaidAmount");
    var request = { CallSlipId: $("#CallSlipId").val(), ContractorId: contractorId, PrepaidAmount: Amount };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/SaveJobPrepaidAmount",
        data: JSON.stringify(request),
        success: function (msg) {

        },
        error: function () {
            CommunicationError();
        }
    });
}


function SaveJobCompletionNotes(notes, IVRInOut) {

    var request = { jobId: $('#CallSlipId').val(), message: notes, RelatedToInvoice: false, Ivr: IVRInOut };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/JobNotes",
        data: JSON.stringify(request),
        success: function (msg) {

        },
        error: function () {
            CommunicationError();
        }
    });
}

function getContractorListPrepaid() {
    $("#contractorListPrepaidJob").empty();
    var request = {
        CallSlipId: $("#CallSlipId").val()
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetContractorForJobPO",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else data = msg;
            if (data.success) {
                var test = data.contractor;
                var newOption = "";
                for (var i = 0; i < test.length; i++) {
                    //
                    var name = test[i].Text;
                    var Id = test[i].Value;

                    newOption += "<option value='" + Id + "'>" + name + "</option>";
                }
                $("#contractorListPrepaidJob").append(newOption);
                $("#contractorListPaywithCc").append(newOption);

            }
            else {
                Notify(data.message, 'error');
            }
        }
    });

}


// update job from service panel
function UpdateJob() {
    console.log("In UpdateJob");
    if (($('#DayInterval').val() == 1 || $('#DayInterval').val() == 2) && $('#ExpectedTime').val() == "") {
        $('#ExpectedTime').css('border', '1px solid red');
        return false;
    } else if ($('#DayInterval').val() == 3 && $('#ServiceTimeFrom').val() == "") {
        $('#ServiceTimeFrom').css('border', '1px solid red');
        return false;
    }
    else if ($('#DayInterval').val() == 3 && $('#ServiceTimeTo').val() == "") {
        $('#ServiceTimeFrom').css('border', '1px solid red');
        return false;
    }


    var OtherOrInternet = $('#OtherAdType').val();
    if ($("#ServiceTab_AdTypeName").val() == '16') {
        OtherOrInternet = $("#OtherAdType").val();

    }
    else
        if ($("#ServiceTab_AdTypeName").val() == '1') {
            OtherOrInternet = $("#InternetAdType").val();
        }

    var otherEmail = "";
    $('.otherEmailsServicePan').each(function () {
        if ($(this).val() != null && $(this).val() != "" && $(this).val() != "0") {
            otherEmail += $(this).val();
            otherEmail += ",";
        }
    });
    otherEmail = otherEmail.slice(0, -1);

    var statusId = $('#jStatusId').val();
    if ($('#charms #JobStatusId').val() != '0') {
        statusId = $('#charms #JobStatusId').val();
    }
    var autoUpdateCustomer = false;
    var allowComm = false;
    var request = {
        CallSlipId: $('#CallSlipId').val(), CustomerType: $('#charms #CustomerType').val(), JobTypeId: $('#charms #JobTypeId').val(),
        Phone: $('#Phone').val(), Email: $('#Email').val(), CalledInBy: $('#CalledInBy').val(),
        ContactPerson: $('#ContactPerson').val(), Address: $('#Address').val(), Notes: "",
        JobStatusId: statusId, DispatchedTime: $('#dTime').val(), ExpectedTime: $('#ExpectedTime').val(),
        ServiceTimeFrom: $('#ServiceTimeFrom').val(), ServiceTimeTo: $('#ServiceTimeTo').val(), DayInterval: $('#DayInterval').val(),
        ServiceDate: $('#ServiceDate').val(), JobDescription: $('#JobDescription').html(), specialInstructions: $('#taSpecialInstructions').val(), IsEmergency: $('#IsEmergency').is(":checked"), Ask: $('#Ask').is(":checked"), NotExceedAmount: $('#NotExceedAmount').val(),
        StateId: $('#ServiceTab_State').val(), City: $('#ServiceTab_City').val(), Zip: $('#ServiceTab_Zip').val(),
        WorkOrder: $('#ServiceTab_WorkOrder').val(), BuzzerCode: $('#ServiceTab_Buzzer').val(), AdTypeWebSource: $('#WebSource').val(), AdType: $('#ServiceTab_AdTypeName').val(),
        OtherAdType: OtherOrInternet, OtherEmails: otherEmail,
        AlternatePhone: $('#ServiceTab_AlternatePhone').val(), Fax: $('#ServiceTab_Fax').val(), CountryId: $("#CountryId").val(), TaxExempt: $('#TaxExempt').is(":checked"),
        WorkOrder2: $('#WorkOrder2').val(), PreferredMethodOfCummunication: $('#PreferedCommunicationMethod').is(":checked"), AlarmTime: $('#AlarmTime').val(),
        StoreNo: $('#ServiceTab_StoreNumber1').val(), Equipment: $('#equipment_name').val()
        //updateOnCompleted: $('#ServicePanel_chkOnCompleted').is(":checked"),
        //IsTangible: $('#chkTangableProperty').is(':checked')
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/UpdateJob",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                Notify(decodeURIComponent(data.message), 'success');

                autoUpdateCustomer = data.sendAutoUpdates;
                allowComm = data.communicationAllowed;

                SelectJob(data.JobId);

                GetNumberOfJobsByStatus();
                GetJobStatusReport();
                //if (data.emailBody != null && data.emailBody != "") {
                //    showUpdateCustomerPopupOrPortal(data.emailBody);
                //}
            } else {
                Notify(data.message, 'error');
            }
        },
        complete: function () {
            if (autoUpdateCustomer) {
                UpdateCustomer();
            }
            if (allowComm) {
                UpdateContractorViaEmailOrSMS();
            }
        },
        error: function () {
            CommunicationError();
        }
    });
    return true;
}

function UpdateContractorViaEmailOrSMS() {
    var request = {
        CallSlipId: $('#CallSlipId').val()
    }

    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/SendUpdatesToContractor",
        data: JSON.stringify(request),
        cache: false,
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                //GetEmailsLogsByCustomerId();
            } else {
                //Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function UpdateCustomer() {
    var request = {
        CallSlipId: $('#CallSlipId').val()
    }

    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/SendAutoUpdatesToCustomer",
        data: JSON.stringify(request),
        cache: false,
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                //GetEmailsLogsByCustomerId();
            } else {
                //Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}


// Upload Document PopUp
function AddDocumentPopup() {
    $('#DocumentPopup').dialog({
        title: 'Add Documents',
        resizable: true,
        width: '330px',
        modal: true,
        open: function (event, ui) {
            $("#DocumentPopup").children().find('ul').remove();
        }
    });

    $('#Other').click(function () {
        $('#relatedToIphoneDiv').hide();
        $("#relatedToIphone").prop("checked", false);
        if ($('#Other').is(':checked')) {
            $('#OtherText').show();
        }
        else if ($('#Other').is(':checked') == false) {
            $('#OtherText').hide();
        }
    });

    $('.ho').click(function () {
               
        $('#OtherText').hide();
        $('#relatedToIphoneDiv').hide();
        $("#relatedToIphone").prop("checked", false);
        
    });
    $('#Pic').click(function () {
        $('#relatedToIphoneDiv').show();
    });
    

    $('#cancelDoc').click(function () {
        $('#DocumentPopup> input[type=radio]').prop("checked", false);
        $('#DocumentPopup> input[type=text]').hide();
        $("#DocumentPopup").dialog("close");

    });
    $('#ConfirmDoc').click(function () {
        $('#DocumentPopup> input[type=radio]').prop("checked", false);
        $('#DocumentPopup> input[type=text]').hide();
        $("#DocumentPopup").dialog("close");
        GetDocumentsByCallSlipId();

    });
}
// file is going to upload
function SPDocumentonUpload(e) {
    var invalidName = false;
    //for (var i = 0; i < e.files.length; i++) {
    //    var name = e.files[i].name;
    //    if (/^[a-zA-Z0-9-_. ]*$/.test(name) == false) {
    //        Notify("File name:" + name + " contain special character(s) which are not allowed.", 'error');
    //        invalidName = true;
    //    }
    //}
    if (!invalidName) {
        if ($('#WO').attr('checked') ? true : false) {

            var checkedValue = 'WorkOrder';
            e.data = {
                CallSlipId: $('#CallSlipId').val(),
                check: checkedValue
            };
        }
        else if ($('#Inv').attr('checked') ? true : false) {

            var checkedValue = 'Invoice';
            e.data = {
                CallSlipId: $('#CallSlipId').val(),
                check: checkedValue
            };
        }
        else if ($('#SO').attr('checked') ? true : false) {

            var checkedValue = 'SO';
            e.data = {
                CallSlipId: $('#CallSlipId').val(),
                check: checkedValue
            };
        }
        else if ($('#Pic').attr('checked') ? true : false) {

            var checkedValue = 'Picture';
            e.data = {
                CallSlipId: $('#CallSlipId').val(),
                check: checkedValue,
                relatedToIphone: $('#relatedToIphone').is(':checked')
            };
        }
        else if ($('#Other').attr('checked') ? true : false) {

            var checkedValue = 'Other';
            e.data = {
                CallSlipId: $('#CallSlipId').val(),
                check: checkedValue,
                otherval: $('#OtherText').val()
            };
        }
        else {
            e.preventDefault();
            Notify("Please select a Type", "error");
        }
    }
    else
        e.preventDefault();
}

// file is uploaded sucessfully
function SPDocumentonSuccess(e) {

    if (e.response.success == true) {
        $('#relatedToIphoneDiv').hide();
        $("#relatedToIphone").prop("checked", false);
        if (e.response.POId.length > 0) {
            var Id = e.response.POId;
            if (Id > 0) {
                $('#UploadedDocumentId').val(e.response.POId);
            }
            Notify(e.message, "success");
            $(".t-widget .t-upload").find("ul").remove();
            GetDocumentsByCallSlipId();
            UpdateServicePanelForMarkup();
        }

        //else if (e.response.msg = "Error") {

        //    Notify(e.message, "success");
        //}
    }
    else if (e.response.success == false) {
        Notify("Upload Correct Document", "error");
    }

}


// is about to be removed 
function SPDocumentonRemove(e) {
    // var files = e.files;
    //e.data = { 'POId': $('#UploadedDocumentId').val() };
}



function AddPart(id) {

    var type = $('#PartType').val();

    var request = {
        CallSlipId: id, PartId: $('#PartIdOfEstimate').val(), PartType: $('#PartType').val(), PartName: $('#Name').val(),
        PartDescription: $('#PartDescription').val(), PartPrice: $('#PartPrice').val(), PartQuantity: $('#PartQuantity').val(),
        Markup: $('#partsMarkup').val(), Discount: $('#partsDiscount').val(), LaborOrPartCost: $('#laborOrPartCost').val(), NewPartCost: $('#NewPartCost').val()
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/AddPart",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                RenderParts(data.parts, data.total, id);
                $('#PartsPanel').slideToggle(500);
                GetNotesByJobId();
                ClearInvoiceForm();
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}
// show alert if part is out of stock
function partOutOfStock() {

    console.log("in partOutOfStock");
    var outOfStockMessage = "<p style='margin: 10px 10px 10px 10px; color:red; font-size:13px; font-weight: bold;'> This Part is out of stock. </p>";
    $("#partsOutOfStock").html(outOfStockMessage);
    $("#partsOutOfStock").dialog({
        title: 'Warning',
        resizable: true,
        //width: 400,
        modal: true,
        buttons: [
            {
                text: "Ok",
                id: "btnOkOutOfStock",
                // class: "btn-primary",
                //class: "btn btn-primary btn-large",
                click: function () {
                    $(this).dialog('close');
                    AddPart();
                }
            },
            {
                text: "Cancel",
                id: "btnCancelOutOfStock",
                //class: "btn-danger",
                //class: "btn btn-danger btn-large",
                click: function () {
                    $(this).dialog('close');
                }
            }],
        close: function (event, ui) {
            $(this).dialog('destroy');
        },
        open: function () {
            $("#btnOkOutOfStock").removeAttr("class");
            $("#btnOkOutOfStock").addClass("btn btn-primary btn-large");
            $("#btnCancelOutOfStock").removeAttr("class");
            $("#btnCancelOutOfStock").addClass("btn btn-danger btn-large");
        }
    });
}


// reload parts after adding the new part
function RenderParts(parts, total, id) {
    if (parts.length > 0) {

        var part = "";
        var totalss = "";
        var profitLossTblParts = "";
        var totalProfit = 0;
        var totalPartsProfit = 0;
        var totalPartCost = 0;
        var profitLossTblLabor = "";
        var totalEstimate = 0;
        profitLossTblParts += "<thead style='background-color: #dfe0e6;'><tr><td colspan='7' style='text-align:left; color:black; background-color:#dfe0e6;'> <h6> Profit And Loss</h6> </td></tr><tr><th> Name </th><th>Purchase Price </th><th>Qty</th><th> Margin </th><th> Discount </th> <th>Total Price </th><th> Profit </th></tr></thead><tbody style='Background-Color:White;'>";
        for (var i = 0; i < parts.length; i++) {
            var markup = parts[i].MarkupPercentage != null ? parts[i].MarkupPercentage : 0;
            var discount = parts[i].DiscountPercentage != null ? parts[i].DiscountPercentage : 0;
            part += "<tr id='" + parts[i].Id + "'><td>" + parts[i].Title + "</td><td>" + parts[i].Type + "</td><td>" +
                parts[i].Quantity + "</td><td>$ " +
                parseFloat(parts[i].UnitPrice).toFixed(2) + "</td><td>$ " + parseFloat(parts[i].UnitPrice * parts[i].Quantity).toFixed(2) + "</td><td> [" +
                parts[i].CreatedOn + " - " + parts[i].CreatedByUser + "]</td><td style='display:none;'>" + markup + "</td><td style='display:none;'>" + discount + "</td><td style='display:none;'>" + parseFloat(parts[i].LaborCost).toFixed(2) + "</td><td style='display:none;'>" + parseFloat(parts[i].APTA).toFixed(2) + "</td><td style='display:none;'>" + parseFloat(parts[i].Profit).toFixed(2) + "</td><td>" +
                "<a onclick='DeletePartFromCallSip(" + parts[i].Id + ");return false;' class='btn btn-danger'><i class='fa fa-trash'></i></a>" +
                "<a onclick='EditPartOnEstimate(" + parts[i].Id + ");return false;' class='btn btn-success'><i class='fa fa-pencil'></i></a>" + "</td></tr>";
            totalProfit += parseFloat(parts[i].Profit);
            if (parts[i].Type == "Parts") {
                totalEstimate += parts[i].TotalPartCost;
                //profitLossTblParts += "<tr id='" + "profitLoss" + parts[i].Id + "'><td>" + parts[i].Title + "</td><td>" + parts[i].MarkupPercentage + "%</td><td>" + parts[i].DiscountPercentage + "%</td><td>" + parts[i].PurchasePrice + "</td><td>" + parts[i].TotalPartCost + "</td><td>" + parts[i].Profit + "</td></tr>";
                profitLossTblParts += "<tr id='" + "profitLoss" + parts[i].Id + "'><td>" + parts[i].Title + "</td><td>" + parseFloat(parts[i].PurchasePrice).toFixed(2) + "</td><td>" + parts[i].Quantity + "</td><td>" + parts[i].MarkupPercentage.toFixed(2) + "%</td><td>" + parseFloat(parts[i].DiscountPercentage).toFixed(2) + "%</td><td>" + parseFloat(parts[i].TotalPartCost).toFixed(2) + "</td><td>" + parseFloat(parts[i].Profit).toFixed(2) + "</td></tr>";

                totalPartsProfit += parts[i].Profit;
                totalPartCost += parts[i].TotalPartCost;
            }
            if (parts[i].Type == "Labor") {
                //var totalLabor = parseFloat(parts[i].UnitPrice) * parseFloat(parts[i].Quantity);
                totalEstimate += parts[i].TotalPartCost;

                var a = parseFloat(parts[i].PurchasePrice);

                //profitLossTblLabor += "<tr id='" + "profitLoss" + parts[i].Id + "'><td>" + parts[i].Title + "</td><td>" + parts[i].MarkupPercentage + "</td> <td>" + parts[i].UnitPrice + "</td> <td>" + parts[i].TotalPartCost.toFixed(2) + "</td><td></td> </tr>";
                profitLossTblLabor += "<tr id='" + "profitLoss" + parts[i].Id + "'><td>" + parts[i].Title + "</td><td>" + parseFloat(parts[i].PurchasePrice).toFixed(2) + "</td><td>" + parts[i].Quantity + "</td><td></td><td></td><td>" + parseFloat(parts[i].TotalPartCost).toFixed(2) + "</td><td>" + parseFloat(parts[i].Profit).toFixed(2) + "</td> </tr>";

            }

        }

        if (profitLossTblLabor != "") {
            //var profitLossTblLaborHdr = "<tr><td></td><td></td><td style='font-weight:bold;'>Labor</td><td style='font-weight:bold;'>" + totalPartCost + "</td><td style='font-weight:bold;' id='TotalPartsProfit'>" + totalPartsProfit + "</td></tr>";
            //profitLossTblParts += profitLossTblLaborHdr;
            profitLossTblParts += profitLossTblLabor;
        }
        profitLossTblParts += "<tr><td></td><td></td><td></td><td></td><td></td><td style='font-weight:bold;'> Total Estimate </td><td style='font-weight:bold;'>Total Profit</td></tr>";
        profitLossTblParts += "<tr id='profitLossTotalProfit'><td></td><td></td><td></td><td></td><td></td><td>" + totalEstimate.toFixed(2) + " </td><td>" + totalProfit.toFixed(2) + "</td><tr></tbody>";
        $('#' + id).parent().find('#profitAndLostGrid').html("");
        $('#' + id).parent().find('#profitAndLostGrid').append(profitLossTblParts);
        $('#' + id).parent().find('#profitAndLostGrid').parent('div').show();

        totalss += "<td style='border: none;'></td><td style='border: none;'></td><td style='border: none;'></td><td style='border: none;'></td>" +
            "<td colspan='3' style='border: none; text-align:right;padding-right:10px;'><div><strong>Parts Sub Total: $ <label id = 'PartsSubTotal'>" + parseFloat(total.PartsSubTotal).toFixed(2) +
            "</label></strong></div>" + "<div><strong>Labor:  $ " + parseFloat(total.LaborTotal).toFixed(2) + "</strong></div>" +
            //"<div><strong>Service Charge:  $ " + parseFloat(total.ServiceCharge).toFixed(2) +
            "<div><strong>Trip Charge:  $ " + parseFloat(total.ServiceCharge).toFixed(2) +
            "</strong></div>" +
            "<div><strong>Other Charges: $ " + parseFloat(total.OtherCharges).toFixed(2) + "</strong></div>" +
            "<div><strong>Tax: $<label id = 'PartsTax'> " + total.PartsTax + "</label></input></strong></div>" +
            "<div><strong>Parts Total: $ " + parseFloat(total.PartsTotal).toFixed(2) + "</strong></div>"
            + "<div><strong>Total: $ <label id = 'PartsTotal'>" + parseFloat(total.Total.replace(/,/g, '')).toFixed(2) + "</label></strong></div></td>";
        $('#' + id).parent().find('#tblBodyPartsGrid').html("");
        $('#' + id).parent().find('#tblBodyPartsGrid').html(part);
        $('#' + id).parent().find('#tblBodyPartsTotals').html("");
        $('#' + id).parent().find('#tblBodyPartsTotals').html(totalss);
        $('#tabs li:nth-child(2)').attr('style', 'background: green;border: green;');
        $('#tabs li:nth-child(2)').find('a').attr('style', 'color:#fff;');
    } else {
        $('#' + id).parent().find('#profitAndLostGrid').html("");
        $('#' + id).parent().find('#tblBodyPartsTotals').html("");
        $('#' + id).parent().find('#tblBodyPartsGrid').html("");
        $('#' + id).parent().find('#tblBodyPartsTotals').html("");
        $('#' + id).parent().find('#tblBodyPartsGrid').html("<tr><td colspan='100%'><h6 style='color:#d33838;'>Part does not exist .</h6></td></tr>");
        $('#tabs li:nth-child(2)').removeAttr('style');
        $('#tabs li:nth-child(2)').find('a').removeAttr('style');
    }
}

// edit line item on estimate
function EditPartOnEstimate(partId) {

    $('#PartIdOfEstimate').val(partId);
    $("#Name").val($('tr#' + partId + ' td:nth-child(1)').text());
    $("#PartPrice").val($('tr#' + partId + ' td:nth-child(4)').text().replace('$', '').replace(' ', ''));
    $("#PartQuantity").val($('tr#' + partId + ' td:nth-child(3)').text());
    if ($('tr#' + partId + ' td:nth-child(2)').text() == "ServiceCharge") {
        $("#PartType option:contains('Service Charges')").attr('selected', true);
    }
    else {
        $("#PartType option:contains(" + $('tr#' + partId + ' td:nth-child(2)').text() + ")").attr('selected', true);
        if ($("#PartType").val() == 2) {
            $('#lblPartPrice').html("");
        }
    }
    LoadParts();
    $("#partsMarkup").val($('tr#' + partId + ' td:nth-child(7)').text());
    $("#partsDiscount").val($('tr#' + partId + ' td:nth-child(8)').text());
    $('#APTAPrice').val($('tr#' + partId + ' td:nth-child(10)').text());

    if ($("#PartType").val() == '1') {
        $('#laborOrPartCost').parents('tr').hide();
        var request = { JobPartId: partId };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/GetJobPartDescription",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {

                    $('#PartDescription').val(data.JobPartDescription);
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
    //else {
    //    
    //    $('#partsMarkup').parents('tr').hide();
    //    $('#partsDiscount').parents('tr').hide();
    //    $('#lblPartPrice').html("");
    //}
    if ($("#PartType").val() == '2') {

        $('#PartDescription').parents('tr').hide();
        $('#partsMarkup').parents('tr').hide();
        $('#partsDiscount').parents('tr').hide();
        $("#laborOrPartCost").val($('tr#' + partId + ' td:nth-child(9)').text());
        $('#laborOrPartCost').parents('tr').show();
        $('#NewPartCost').parents('tr').hide();
        $('#PartPofit').val($('tr#' + partId + ' td:nth-child(11)').text());
        // $('#PartPofit').parents('tr').show();
        $('.profitOnParts').show();
        $('.purchasePrice').hide();
        $('.sellingPrice').hide();
    }
    if ($("#PartType").val() == '3') {

        // $('#lblPartPrice').html("");
        $('#sellingPrice').val("");
        $('#PartDescription').parents('tr').hide();
        $('#partsMarkup').parents('tr').hide();
        $('#partsDiscount').parents('tr').hide();
        $('#laborOrPartCost').parents('tr').hide();
        //$('#PartPofit').parents('tr').hide();
        $('.profitOnParts').hide();
        $('.purchasePrice').hide();
        $('.sellingPrice').hide();
    }
    if ($("#PartType").val() == '4') {

        // $('#lblPartPrice').html("");
        $('#sellingPrice').val("");
        $('#PartDescription').parents('tr').hide();
        $('#partsMarkup').parents('tr').hide();
        $('#partsDiscount').parents('tr').hide();
        $('#laborOrPartCost').parents('tr').hide();
        //$('#PartPofit').parents('tr').hide();
        $('.profitOnParts').hide();
        $('.purchasePrice').hide();
        $('.sellingPrice').hide();
    }
    $('#PartsPanel').slideToggle(500);
}

// load part on the auto complete
function LoadParts(e) {

    console.log(" In LoadParts");
    if ($('#PartType').val() == "1") {

        var sectionName = $("#Name").data("tAutoComplete").value();
        var customerName = $("#CustomerName").val();
        var jobPartId = $('#PartIdOfEstimate').val();
        if (sectionName.length > 0) {
            var selectedItem = sectionName;
            var request = { PartName: selectedItem, CustomerName: customerName, JobPartId: jobPartId };

            $.ajax({
                type: "POST",
                data: JSON.stringify(request),
                url: baseURL + "Home/GetPartDetails",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var msg;
                    if (data.hasOwnProperty("d")) {
                        msg = data.d;
                    } else
                        msg = data;
                    PopulatePartDetails(msg.part);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    CommunicationError();
                }
            });
        }
    }
}

function PopulatePartDetails(part) {
    console.log(" In PopulatePartDetails");
    if (part != undefined) {

        $('#APTAPrice').val(part.APTA);
        // $('#lblPartPrice').html("*(" + part.UnitPrice + ")");
        $('#sellingPrice').val(part.UnitPrice);
        $('.sellingPrice').show();
        $('#lblPartFound').html(part.partFound);
        $('#TotalPartQuantity').val(part.Quantity);
        //$('#PartPrice').val();
        $('#purchasePrice').val(part.PurchasePrice);
        $('.purchasePrice').show();
        $('#partsMarkup').val(part.MarkupPercentage);
        $('#partsDiscount').val(part.DiscountPercentage);
        $('#partsMarkup').parents('tr').show();
        $('#partsDiscount').parents('tr').show();
        $('#PartDescription').parents('tr').hide();
        $('#laborOrPartCost').parents('tr').hide();
        $('#NewPartCost').parents('tr').hide();
        //----------- calculation for part profit on estimate, while loading pards------------

        //  var profit = parseFloat(part.profit);
        if (part.Profit != null) {
            $('#PartPofit').val(part.Profit);
            //  $('#PartPofit').parents('tr').show();
            $('.profitOnParts').show();
        }



    }
    if (part.Title == null) {

        $('#lblPartFound').html(part.partFound);
        $('#partsMarkup').parents('tr').show();
        $('#partsMarkup').val(part.MarkupPercentage);
        $('#partsDiscount').val(part.DiscountPercentage);
        $('#partsDiscount').parents('tr').show();
        $('#PartDescription').parents('tr').show();
        // $('#sellingPrice').val("");
        //$('#lblPartPrice').html("");
        $('#NewPartCost').val(part.LaborCost);
        $('#NewPartCost').parents('tr').show();
        $('.sellingPrice').hide();

    }
}


function CheckJobByCallSlipId() {
    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/CheckJobByCallSlipId",
        data: JSON.stringify(request),
        global: false,
        cache: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                if (data.PartsExists) {
                    $('#tabs li:nth-child(2)').attr('style', 'background: green;border: green;');
                    $('#tabs li:nth-child(2)').find('a').attr('style', 'color:#fff;');
                }
                else {
                    $('#tabs li:nth-child(2)').removeAttr('style');
                    $('#tabs li:nth-child(2)').find('a').removeAttr('style');
                }

                if (data.PoExists) {
                    $('#tabs li:nth-child(5)').attr('style', 'background: green;border: green;');
                    $('#tabs li:nth-child(5)').find('a').attr('style', 'color:#fff;');
                }
                else {
                    $('#tabs li:nth-child(5)').removeAttr('style');
                    $('#tabs li:nth-child(5)').find('a').removeAttr('style');
                }

                if (data.PaymentExists) {
                    $('#tabs li:nth-child(4)').attr('style', 'background: green;border: green;');
                    $('#tabs li:nth-child(4)').find('a').attr('style', 'color:#fff;');
                } else {
                    $('#tabs li:nth-child(4)').removeAttr('style');
                    $('#tabs li:nth-child(4)').find('a').removeAttr('style');
                }

            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}


// get all parts for call slip on load
function GetPartsByCallSlipId(id) {
    var request = { CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url:"Home/GetPartsByCallSlipId",
        data: JSON.stringify(request),
        global: false,
        cache: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                if (data.stateExempt != undefined && data.stateExempt != null && data.stateExempt != "") {
                    $('#stateExempt').text('The Customer is Tax Exempt in the State of ' + data.stateExempt);
                }
                else {
                    $('#stateExempt').text('');
                }
                RenderParts(data.parts, data.total, id);
                if (data.parts.length > 0) {
                    $('#tabs li:nth-child(2)').attr('style', 'background: green;border: green;');
                    $('#tabs li:nth-child(2)').find('a').attr('style', 'color:#fff;');
                }
                else {
                    $('#tabs li:nth-child(2)').removeAttr('style');
                    $('#tabs li:nth-child(2)').find('a').removeAttr('style');
                }
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

// delete added part from the call slip
function DeletePartFromCallSip(pId) {
    $("<div></div>").dialog({
        title: "Please confirm",
        buttons: [{
            text: "Yes",
            id: "btnConfirm",
            click: function () {
                var request = { CallSlipId: $('#CallSlipId').val(), JobPartMappingId: pId };
                $.ajax({
                    type: "POST",
                    contentType: "application/json, charset=utf-8",
                    url: baseURL + "Home/DeletePartFromCallSlip",
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty("d")) {
                            data = msg.d;
                        } else
                            data = msg;
                        if (data.success) {

                            GetNotesByJobId();
                            RenderParts(data.parts, data.total);
                        } else {
                            Notify(data.message, 'error');
                        }
                    },
                    error: function () {
                        CommunicationError();
                    }
                });
                $(this).dialog("close");
            }
        },
        {
            text: "No",
            id: "btnCancel",
            click: function () {
                $(this).dialog("destroy");
            }
        }],

        open: function () {
            StyleWarningDiagle($(this));
            $(this).html("<div class='warning'><h2>Are you sure to delete ?</h2></div>");
            $('#btnConfirm').removeAttr("class");
            $('#btnCancel').removeAttr("class");
            $('#btnConfirm').addClass("btn btn-success");
            $('#btnCancel').addClass("btn btn-danger");
        }
    });
}

function ClearInvoiceForm() {
    $('#PartType').val("1");
    $('#Name').val("");
    $('#PartDescription').val("");
    $('#PartPrice').val("");
    $('#PartQuantity').val("");
    $('#PartIdOfEstimate').val("");
    $('#partsMarkup').val('');
    $('#partsDiscount').val('');
    // $('#lblPartPrice').html('');
    $('#sellingPrice').val("");
    $('#laborOrPartCost').val("");
    $('#PartPofit').val("");
    $('#NewPartCost').val("");
}

function RedirectToEstimate() {
    var baseURL = getBaseUrl();
    if (baseURL.includes("Home")) {
        baseURL = baseURL.slice(0, -4);
    }
    url = baseURL + "/Home/Estimate1/" + "?CallSlipId=" + $("#CallSlipId").val();
    window.open(url, '_blank');
}

function CreateSignOff(id, type) {

    //var JobState = $('#ServiceTab_State').val();
    //if (JobState == "2" || JobState == "7" || JobState == "9" || JobState == "18" || JobState == "23" || JobState == "27" || JobState == "34" || JobState == "35" || JobState == "37" || JobState == "40" || JobState == "44" || JobState == "45" || JobState == "54" || JobState == "55" || JobState == "59") {

    //    var licensed = false;
    //    var request = { Id: id };
    //    $.ajax({
    //        type: "POST",
    //        contentType: "application/json, charset=utf-8",
    //        url: baseURL + "Contractor/GetContractor",
    //        global: false,
    //        data: JSON.stringify(request),
    //        success: function (msg) {
    //            var data;
    //            if (msg.hasOwnProperty("d")) {
    //                data = msg.d;
    //            } else data = msg;
    //            if (data.success) {
    //                if (data.documents.length > 0) {
    //                    for (var x = 0; x < data.documents.length; x++) {
    //                        var docType = data.documents[x].ContractorDocumentType;
    //                        if (docType == 4)
    //                        { licensed = true; }
    //                    }
    //                }
    //                if (data.contractor.LicenseNumber != "" && data.contractor.LicenseNumber != null)
    //                { licensed = true; }


    //                //prompt user based on settings
    //                if (!licensed) {
    //                    AddExtraCommission(id, type);
    //                    Notify1("This State requires license and Contractor is not licensed", 'error');
    //                }
    //                else {
    //                    AddExtraCommission(id, type);
    //                }
    //            }
    //        },
    //        error: function () { CommunicationError(); }
    //    });
    //}
    //else {
    AddExtraCommission(id, type);
    //}

}

// forward estimate to the client on the email address entered in the
// input field for email
function SendEstimate() {
    if ($('#EstimateEmail').val() < 1) {
        $('#EstimateEmail').css('border', '1px solid red');
    }
    else {
        var request = {
            CallSlipId: $('#CallSlipId').val(),
            EstimateEmail: $('#EstimateEmail').val()
        };

        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/SendEstimate",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    Notify(data.message, 'success');
                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
}

// Get number of jobs for top boxes
function GetNumberOfJobsByStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: "Home/GetNumberOfJobsByStatus",
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                CreateCountTabs(data.Totals);
            } else {
                //Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function CreateStatusTabs(model) {
    if (model.DailyJobStatusList.length > 0) {
        var dataCSR = "";
        var dataDispatcher = "";
        var dataDispatchMgr = "";
        var typeid = "";
        var statusCode = "";
        var style = "display:inline-block; text-align:center; margin:3px;min-width:41px;";
        for (var i = 0; i < model.DailyJobStatusList.length; i++) {
            typeid = model.DailyJobStatusList[i].Id; // primary key of the status in table
            statusCode = model.DailyJobStatusList[i].StatusCode; // status code for each status

            var customStyle = "background-color: " + model.DailyJobStatusList[i].Colour + ";color:" + model.DailyJobStatusList[i].FontColor + ";";
            if (statusCode == '4.5' || statusCode == '5' || statusCode == '5.3') {
                dataCSR += '<div style="' + style + '"><div onclick="LoadByModifiedStatus(' + typeid + ',this)" title="' + model.DailyJobStatusList[i].Status + '" style="' + customStyle + '" class="myClass">' +
                    '<a data-original-title="" >' +
                    '<div class="info" style="font-size:18px;color:' + model.DailyJobStatusList[i].FontColor + '">' + model.DailyJobStatusList[i].TotalJobs + '</div></a></div><span style="font-size:14px;">' + statusCode + '</span></div>';
                style = "display:inline-block; text-align:center;margin:3px;min-width:41px;";
            }

            else if (statusCode == '0' || statusCode == '4' || statusCode == '5.2') {
                dataDispatcher += '<div style="' + style + '"><div onclick="LoadByModifiedStatus(' + typeid + ',this)" title="' + model.DailyJobStatusList[i].Status + '" style="' + customStyle + '" class="myClass">' +
                    '<a data-original-title="" >' +
                    '<div class="info" style="font-size:18px;color:' + model.DailyJobStatusList[i].FontColor + '">' + model.DailyJobStatusList[i].TotalJobs + '</div></a></div><span style="font-size:14px;">' + statusCode + '</span></div>';
                style = "display:inline-block; text-align:center;margin:3px;min-width:41px;";
            }

            else if (statusCode == '-1' || statusCode == '-1.5' || statusCode == '-2') {
                dataDispatchMgr += '<div style="' + style + '"><div onclick="LoadByModifiedStatus(' + typeid + ',this)" title="' + model.DailyJobStatusList[i].Status + '" style="' + customStyle + '" class="myClass">' +
                    '<a data-original-title="" >' +
                    '<div class="info" style="font-size:18px;color:' + model.DailyJobStatusList[i].FontColor + '">' + model.DailyJobStatusList[i].TotalJobs + '</div></a></div><span style="font-size:14px;">' + statusCode + '</span></div>';
                style = "display:inline-block; text-align:center;margin:3px;min-width:41px;";
            }
        }
        document.getElementById("divCSRJobs").innerHTML = dataCSR;
        document.getElementById("divDispatcherJobs").innerHTML = dataDispatcher;
        document.getElementById("divDispatchMgrJobs").innerHTML = dataDispatchMgr;
        $('.metro-nav-block').tooltip();
    }
}


function GetCustomFilterJobsByStatus() {

    var jobTypeId = $('.action-container #JobTypeId').val();
    var cbInState = $('.action-container #cbInState').is(':checked');
    var cbOutOfState = $('.action-container #cbOutOfState').is(':checked');
    var cbCitiBank = $('.action-container #cbCitiBank').is(':checked');
    var cbAissJobs = $('.action-container #cbAissJobs').is(':checked');
    var cbProjects = $('.action-container #cbProjects').is(':checked');
    var fromDateTime = $('.action-container #FromDateTime').val();
    var endDateTime = $('.action-container #EndDateTime').val();
    var customerTypeId = $('.action-container #CustomerTypeId').val();
    var jobStatusId = $('.action-container #JobStatusId').val();
    var contractorNameFilterPanel = $('.action-container #ContractorNameFilterPanel').val();
    var expectedFromTime = $('.action-container #ExpectedFromTime').val();
    var expectedToTime = $('.action-container #ExpectedToTime').val();
    var byCustomerName = $('.action-container #ByCustomerName').val();
    var byStoreNumber = $('.action-container #ByStoreNumber').val();
    var byStoreName = $('.action-container #ByStoreName').val();
    var byCustomerWO = $('.action-container #ByCustomerWO').val();


    var request = {
        JobTypeId: jobTypeId, cbInState: cbInState, cbOutOfState: cbOutOfState, cbCitiBank: cbCitiBank, cbAissJobs: cbAissJobs, cbProjects: cbProjects, FromDate: fromDateTime, OnDate: endDateTime,
        CustomerTypeId: customerTypeId, JobStatusId: jobStatusId, ContractorName: contractorNameFilterPanel, ExpectedFromTime: expectedFromTime, ExpectedToTime: expectedToTime,
        CustomerName: byCustomerName, WorkOrder2: byCustomerWO, StoreNumber: byStoreNumber, StoreLocationName: byStoreName
    };

    $.ajax({

        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetCustomFilterJobsByStatus",
        data: JSON.stringify(request),
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                CreateCustomFilterTabs(data.Totals);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}


function CreateCountTabs(count) {
    if (count.length > 0) {
        var data = "";
        var typeid = "";
        var statusCode = "";
        var style = "display:inline-block; text-align:center;margin:3px;"

        for (var i = 0; i < count.length; i++) {
            typeid = count[i].split(',')[2]; // primary key of the status in table
            statusCode = count[i].split(',')[5]; // status code for each status

            var customStyle = "background-color: " + count[i].split(',')[3] + ";color:" + count[i].split(',')[4] + ";";

            //if (count[i].split(',')[5] == "0" || count[i].split(',')[5] == "6" || count[i].split(',')[5] == "-3" || count[i].split(',')[5] == "20") {
            //    style += "margin-right: 15px;";
            //}

            data += '<div style="' + style + '"><div onclick="LoadByStatus(' + typeid + ',this)" title="' + count[i].split(',')[0] + '" style="' + customStyle + '" class="myClass">' +
                '<a data-original-title="" >' +
                '<div class="info" style="font-size:18px; color:' + count[i].split(',')[4] + '">' + count[i].split(',')[1] + '</div></a></div><span style="font-size:14px;">' + statusCode + '</span></div>';
            style = "display:inline-block; text-align:center;margin:3px;min-width:41px;";
        }
        document.getElementById("topBoxes").innerHTML = data;
        $('.metro-nav-block').tooltip();
    }
}
function CreateCustomFilterTabs(count) {

    if (count.length > 0) {
        var data = "";
        var typeid = "";
        var statusCode = "";
        var style = "display:inline-block;";
        for (var i = 0; i < count.length; i++) {
            typeid = count[i].split(',')[2]; // primary key of the status in table
            statusCode = count[i].split(',')[5]; // status code for each status
            var customStyle = "background-color: " + count[i].split(',')[3] + ";color:" + count[i].split(',')[4] + ";";

            if (count[i].split(',')[5] == "0" || count[i].split(',')[5] == "6" || count[i].split(',')[5] == "-3" || count[i].split(',')[5] == "20") {
                style += "margin-right: 20px;";
            }

            data += '<div style="' + style + '"><div onclick="LoadByStatus(' + typeid + ',this)" title="' +
                count[i].split(',')[0] + '" style="' + customStyle + '" class="CustomJobFilter-block"><a data-original-title="" >' +
                '<div class="info" style="color:' + count[i].split(',')[4] + '">' + count[i].split(',')[1] + '</div></a></div><span style="font-size:14px;">' + statusCode + '</span></div>';
            style = "display: inline-block;";
        }
        $('.CustomJobFilter').show();
        $('.CustomJobFilter').html("");
        $('.CustomJobFilter').html(data);
        $('.CustomJobFilter-block').tooltip();
    }
}
function LoadByStatus(tid, ctrl) {
    $('.action-container #JobStatusId').val(tid);

    $('#txtExcludeWallMartJobs').val(false);
    SearchJobs(1);
}

function LoadByModifiedStatus(tid, ctrl) {

    $('.action-container #JobStatusId').val(tid);

    $('#txtExcludeWallMartJobs').val(true);
    //$('#txtExcludeWallMartJobs').val(false);

    SearchJobs(1);
}

function PopulatePOPartDetailsForm(part) {
    if (part != undefined) {
        $('#PartPODescription').val(part.Description);
        $('#PoPrice').val(part.APTA);
        $('#PoQuantity').val(1);
        $("#POAddPartsField").focus();
    }
}

// Purchase order tab
function TogglePartPOPanel(togglePanel) {

    if (togglePanel) {
        $('#PartsPOPanel').slideToggle(500);
        //document.getElementById("POAddPartsField").tabIndex = "1";
        $("#POAddPartsField").focus();
    }
    $('#POPartId').val("");
    $('#POAddPartsField').val("");
    $('#PoPrice').val("");
    $('#PoQuantity').val("");
    $('#PoShippingCharges').val("");
    $('#PartPODescription').val("");
    $('#PoSalesTax').val("");
    $("#InventoryPart").prop("checked", false);
    $('#InventoryPart').attr("disabled", true);
}

$('#HidePOPartPanel').click(function () {
    $('#PartsPOPanel').slideToggle(500);
});
function SaveReturnOrder() {
     
    console.log(" in js add to parts");

    $('#mySelect').addClass('required');
    var vl = $('#PartsROForm').valid();
    if (vl) {
        AddPartToRO();
    }
    else {
        $('#PurchaseOrderPartForm .required').each(function () {
            $('#PurchaseOrderPartForm .required').attr('placeholder', 'Field is required');
        });
    }
}

$('#AddPartToPO').click(function () {
    console.log(" in js add to parts");

    $('#POAddPartsField').addClass('required');
    var vl = $('#PartsPOForm').valid();
    if (vl) {
        AddPartToPO();
    }
    else {
        $('#PurchaseOrderPartForm .required').each(function () {
            $('#PurchaseOrderPartForm .required').attr('placeholder', 'Field is required');
        });
    }
});

$('#CreateOrUpdatedPO').click(function () {

    var vl = $('#PurchaseOrdeForm').valid();
    if (vl) {
        CreateOrUpdatePurchaseOrder();
    }
    else {
        $('#PurchaseOrdeForm .required').each(function () {
            $('#PurchaseOrdeForm .required').attr('placeholder', 'Field is required');
        });
    }
});
function CreateOrUpdatePurchaseOrder() {

    var ShipedByother = "";
    var ShipedByother = $('#shipMethod').val();
    console.log(ShipedByother);
    if (ShipedByother == "Others") {
        ShipedByother = $('#ShippedByOther').val();
    }
    if ($("#shipMethod").val() == '1' || $("#shipMethod").val() == '') {
        Notify("Please select a shipping method.", "error");
    }
    else {
        var request = {
            Id: printPurchaseOrderId,
            JobId: $('#CallSlipId').val(),
            PurchaseOrderNumber: $('#PurchaseOrderNumber').val(),
            InvoiceBy: $('#InvoiceBy').val(),
            DateOrdered: $('#PODateOrdered').val(),
            OrderedBy: $('#OrderedBy').val(),
            ShippedBy: ShipedByother,
            TrackingNumber: $('#TrackingNumber').val(),
            ShippingDetails: $('#ShippingDetails').val(),
            OrderStatus: $('#OrderStatus').val(),
            AISSParts: $('#AISSParts').is(':checked'),
            BillingAddress: {
                CompanyName: $('#BillingCompanyName').val(),
                FirstName: $('#BillingFirstName').val(),
                LastName: $('#BillingLastName').val(),
                City: $('#BillingCity').val(),
                Address1: $('#BillingAddress1').val(),
                Address2: $('#BillingAddress2').val(),
                ZipPostalCode: $('#BillingZipCode').val(),
                PhoneNumber: $('#BillingPhone').val(),
                StateId: $('#BillingStateId').val(),
                CountyId: $('#BillingCountyId').val()
            },
            ShippingAddress: {
                CompanyName: $('#ShippingCompanyName').val(),
                FirstName: $('#ShippingFirstName').val(),
                LastName: $('#ShippingLastName').val(),
                City: $('#ShippingCity').val(),
                Address1: $('#ShippingAddress1').val(),
                Address2: $('#ShippingAddress2').val(),
                ZipPostalCode: $('#ShippingZipCode').val(),
                PhoneNumber: $('#ShippingPhone').val(),
                StateId: $('#ShippingStateId').val(),
                CountyId: $('#ShippingCountyId').val()
            }
        };

        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/CreateOrUpdatePurchaseOrder",
            data: JSON.stringify({ 'model': request }),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    if ($('#AISSParts').is(':checked')) {
                        GetContractorsByJobId();
                    }
                    var smsg = "";
                    smsg = "Puchase Order Updated Successfully.";
                    Notify(smsg, 'success');
                } else {
                    Notify(data.message, 'error');
                }
            },
            complete: function () {
                ShowJobNotes();
            },
            error: function () {
                CommunicationError();
            }
        });
    }
}
function AddPartToPO() {
    var request = {
        CallSlipId: $('#CallSlipId').val(), PurchaseOrderId: printPurchaseOrderId, POPartId: $('#POPartId').val(),
        PartName: $('#POAddPartsField').val(), PoPrice: $('#PoPrice').val(), PoQuantity: $('#PoQuantity').val(),
        PoShippingCharges: $('#PoShippingCharges').val(), PartPODescription: $('#PartPODescription').val(), SalesTax: $('#PoSalesTax').val(), InventoryPart: $('#InventoryPart').is(':checked')
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/AddPartToPO",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                RenderPOParts(data.parts, data.total);
                $('#PartsPOPanel').slideToggle(500);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}
function AddPartToRO() {
    var request = {
        CallSlipId: $('#CallSlipId').val(), PurchaseOrderId: printPurchaseOrderId, POPartId: $('#ROPartId').val(),
        PartName: $("#mySelect option:selected").text(), PoPrice: $('#ROPrice').val(), PoQuantity: $("#ROQuantity").val(),
        PoShippingCharges: $('#ROShippingCharges').val(), PartPODescription: $('#PartRODescription').val(), SalesTax: $('#ROSalesTax').val(), InventoryPart: $('#InventoryPart').is(':checked')
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/AddPartToPO",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                RenderROParts(data.parts, data.total);
                // $('#PartsPOPanel').slideToggle(500);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

// reload parts after adding the new part
function RenderROParts(parts, total, type) {
     
    $('#PartsPOPanel').hide();
    $('#ROSalesTax').val("");
    $('#ROQuantity').val("");
    $('#ROShippingCharges').val("");
    $('#PartRODescription').val("");
    $('#ROPrice').val("");

    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetPartsForReturn",
        data: JSON.stringify(request),
        cache: false,
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                 
                //$('#PartsROPanel').slideToggle(500);
                var OptionDiv = '';
                //foreach(keyVar in data.partslist)
                //{
                //    OptionDiv += '<option value="">' + keyVar.NAme + '</option>'; value= " + partslist.Value +"

                //}
                if (partList.length > 0) {
                    var part = "";
                    part += "<option value='0'>--Select Part--</option > ";
                    for (var i = 0; i < partList.length; i++) {
                        part += '<option value=' + partList[i].Value + '>' + partList[i].NAme + '</option > '

                    }
                    $('#ROPartsPanel').show();
                    //$('#partsforRO').html(part); ROPartsPanel
                    $('#ROPartsPanel select').html("");
                    $('#ROPartsPanel select').html(part);
                    $('#TogglePartPOPanel').hide();
                }
                else {
                    $('#ROPartsPanel select').html("");
                    var part = "";
                    part += "<option value='0'>--Select Part--</option > ";
                    $('#ROPartsPanel select').html(part);
                    $('#ROPartsPanel tbody').html("");
                    $('#ROPartsPanel tbody').html("<tr><td colspan='100%'><h4 style='color:red;'>Part does not exist .</h4></td></tr>");
                }

            }

        },

    });
    if (parts.length > 0) {
        var part = "";
        for (var i = 0; i < parts.length; i++) {
            console.log("parts[i].SalesTax:" + parts[i].SalesTax);
            if (parts[i].SalesTax == null)
                parts[i].SalesTax = 0;

            part += "<tr><td>" + parts[i].Name + "</td><td>$ " +
                parseFloat(parts[i].Price).toFixed(2) + "</td><td>" + parts[i].Quantity + "</td>" +
                "<td>$ " + parseFloat(parts[i].ShippingCharges).toFixed(2) + "</td>" +
                "<td>$ " + parseFloat(parts[i].SalesTax).toFixed(2) + "</td>" +
                "<td>$ " + parseFloat((parts[i].Price * parts[i].Quantity) + parts[i].ShippingCharges + parts[i].SalesTax).toFixed(2) + "</td>"+
                "<td><a onclick='DeleteROPartFromCallSip(" + parts[i].Id + ");return false;' class='btn btn-danger'><i class='icon-trash'></i></a>" +
                "<a onclick='EditROPart(" + parts[i].Id + ");return false;' class='btn btn-success'><i class='icon-pencil'></i></a>" + "</td></tr>";

        }
        part += "<tr><td colspan='6' style='text-align:right'>" +
            "<div><strong>Parts Sub Total: $ " + parseFloat(total.PartsSubTotal).toFixed(2) + "</strong></div>" +
            "<div><strong>Parts Total: $ " + parseFloat(total.PartsTotal).toFixed(2) + "</strong></div>" +
            "<div><strong>Shipping Charges: $ " + parseFloat(total.ShippingCharges).toFixed(2) + "</strong></div>" +
            "<div><strong>Sales Tax: $ " + parseFloat(total.SalesTax).toFixed(2) + "</strong></div>" +
            "<div><strong>Total: $ " + parseFloat(total.Total).toFixed(2) + "</strong></div></td></tr>";
        $('#POPartsPanel tbody').html("");
        $('#POPartsPanel tbody').html(part);

    } else {
        $('#POPartsPanel tbody').html("");
        $('#POPartsPanel tbody').html("<tr><td colspan='100%'><h4 style='color:red;'>Part does not exist .</h4></td></tr>");
    }


}

function RenderPOParts(parts, total) {

     
    $('#ROPartsPanel').hide();
    $('#POPartsPanel').show();
    $('#TogglePartPOPanel').show();

    if (parts.length > 0) {
        var part = "";
        for (var i = 0; i < parts.length; i++) {
            console.log("parts[i].SalesTax:" + parts[i].SalesTax);
            if (parts[i].SalesTax == null)
                parts[i].SalesTax = 0;

            part += "<tr><td>" + parts[i].Name + "</td><td>$ " +
                parseFloat(parts[i].Price).toFixed(2) + "</td><td>" + parts[i].Quantity + "</td>" +
                "<td>$ " + parseFloat(parts[i].ShippingCharges).toFixed(2) + "</td>" +
                "<td>$ " + parseFloat(parts[i].SalesTax).toFixed(2) + "</td>" +
                "<td>$ " + parseFloat((parts[i].Price * parts[i].Quantity) + parts[i].ShippingCharges + parts[i].SalesTax).toFixed(2) + "</td>" +
                //"<td>" + parts[i].LastUpdatedOnDate + "</td>" +
                "<td><a onclick='DeletePOPartFromCallSip(" + parts[i].Id + ");return false;' class='btn btn-danger'><i class='icon-trash'></i></a>" +
                "<a onclick='EditPOPart(" + parts[i].Id + ");return false;' class='btn btn-success'><i class='icon-pencil'></i></a>" + "</td></tr>";
        }
        part += "<td></td><td></td><td></td><td colspan='3' style='text-align:right;padding-right:10px;'>" +
            "<div><strong>Parts Sub Total: $ " + parseFloat(total.PartsSubTotal).toFixed(2) + "</strong></div>" +
            "<div><strong>Parts Total: $ " + parseFloat(total.PartsTotal).toFixed(2) + "</strong></div>" +
            "<div><strong>Shipping Charges: $ " + parseFloat(total.ShippingCharges).toFixed(2) + "</strong></div>" +
            "<div><strong>Sales Tax: $ " + parseFloat(total.SalesTax).toFixed(2) + "</strong></div>" +
            "<div><strong>Total: $ " + parseFloat(total.Total).toFixed(2) + "</strong></div></td>";
        $('#POPartsPanel tbody').html("");
        $('#POPartsPanel tbody').html(part);
    } else {
        $('#POPartsPanel tbody').html("");
        $('#POPartsPanel tbody').html("<tr><td colspan='100%'><h4 style='color:red;'>Part does not exist .</h4></td></tr>");
    }


}
function ROPartsDetails(value, pl) {

    value = value - 1;
    var saletax = pl[value].SalesTax;
    var apta = pl[value].Apta;
    var shipping = pl[value].ShipingCharges;
    var quantity = pl[value].Quantity;
    var desc = pl[value].Description;
    $('#ROSalesTax').val("");
    $('#ROSalesTax').val(saletax);
    $('#ROQuantity').val("");
    $('#ROQuantity').val(quantity);
    $('#ROShippingCharges').val("");
    $('#ROShippingCharges').val(shipping);
    $('#PartRODescription').val("");
    $('#PartRODescription').val(desc);
    $('#ROPrice').val("");
    $('#ROPrice').val(apta);
}
function EditPOPart(partId) {
    var request = { Id: partId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "PurchaseOrders/GetPOPart",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                 
                TogglePartPOPanel(true);
                var porderPart = data.porderPart;
                $('#POPartId').val(porderPart.Id);
                $('#POAddPartsField').val(porderPart.Name);
                $('#PoPrice').val(porderPart.Price);
                $('#PoQuantity').val(porderPart.Quantity);
                $('#PoShippingCharges').val(porderPart.ShippingCharges);
                $('#PartPODescription').val(porderPart.Description);
                $('#PoSalesTax').val(porderPart.SalesTax);
                if (porderPart.InventoryPart) {
                    $("#InventoryPart").prop('checked', true);
                }
                else {
                    $("#InventoryPart").prop('checked', false);
                }
                if (porderPart.partExists == false) {
                    $('#InventoryPart').attr("disabled", true);
                }
                else {
                        $("#InventoryPart").removeAttr("disabled");
                }
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });

}

function EditROPart(partId) {
    var request = { Id: partId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "PurchaseOrders/GetPOPart",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                var porderPart = data.porderPart;
                $('#ROPartId').val(porderPart.Id);
                $('#mySelect').val(porderPart.partID).prop('selected', true);
                $('#ROSalesTax').val(porderPart.SalesTax);
                $('#ROQuantity').val(porderPart.Quantity);
                $('#ROShippingCharges').val(porderPart.ShippingCharges);
                $('#PartRODescription').val(porderPart.Description);
                $('#ROPrice').val(porderPart.Price);
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });

}


function CheckPurchaseOrderExists() {
    $("#PurchaseOrdersGrid").html("");
    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/CheckPurchaseOrderDetails",
        data: JSON.stringify(request),
        cache: false,
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {

                if (data.exists) {
                    $('#tabs li:nth-child(5)').attr('style', 'background: green;border: green;');
                    $('#tabs li:nth-child(5)').find('a').attr('style', 'color:#fff;');
                }
                else {
                    $('#tabs li:nth-child(5)').removeAttr('style');
                    $('#tabs li:nth-child(5)').find('a').removeAttr('style');
                }
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}
var partList;
function GetPurchaseOrderDetails(POtype) {
     
    var jobid = $('#CallSlipId').val();
    $("#PurchaseOrdersGrid").html("");
    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetPurchaseOrderDetails",
        data: JSON.stringify(request),
        cache: false,
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;  
            if (data.success) {
                partList = data.Result;
                if (data.Result.length < 1) {
                    partList = [];
                }
                FillPurchaseOrderDetails(data.listPurchaseOrder, jobid);
            }
            else {
                Notify(data.message, 'error');
            }
        },
        complete: function () {
            HideLoaderSP();
        },
        error: function () {
            CommunicationError();
        }
    });
}

function FillPurchaseOrderDetails(pOrders, jobid) {
     
    //var po = "<table class = 'purchaseOrderTable' >";
    var po = "<table class = 'purchaseOrderTable' ><thead><tr><th>PO#</th><th>Tracking Number</th><th>Ordered By</th><th>Shipped By</th><th>Dated</th><th>Total</th><th></th></tr></thead><tbody>";

    if (pOrders.length > 0) {
        var address = "";
        for (var i = 0; i < pOrders.length; i++) {
            var Total = 0.00;
            if (pOrders[i].POParts.length > 0) {
                for (var t = 0; t < pOrders[i].POParts.length; t++) {
                    var total = (parseFloat(pOrders[i].POParts[t].Quantity) * parseFloat(pOrders[i].POParts[t].Price) + parseFloat(pOrders[i].POParts[t].ShippingCharges) + parseFloat(pOrders[i].POParts[t].SalesTax));
                    Total += Math.round(total * 100) / 100;
                }

            }
            //onclick = 'ViewReceipt(" + cList[i].Id + "," + cList[i].ContractorId + "," + cList[i].JobId + ")' > P</button > ";
            Rtype = "Return"; Ptype = "PO";
            var shippedto = pOrders[i].ShippedTo != null ? pOrders[i].ShippedTo : "";
            //po += "<tr><td style = 'width:20%'><b>" + pOrders[i].PurchaseOrderNumber + "</b></td><td onclick='showTrackingInfo(\"" +  pOrders[i].TrackingNumber  +"\");' style = 'width:auto;'><b>" +
            if (pOrders[i].Type == "Return") {
                 
                po += "<tr><td style = 'width:20%'><b>Return" + jobid + "</b></td><td style = 'width:auto;'><b>" +
                    pOrders[i].TrackingNumber + "</b></td><td style = 'width:20%'><b>" + pOrders[i].OrderedBy + "</b></td>" +
                    "<td style = 'width:20%'><b>" + pOrders[i].ShippedBy + "</b></td>" +
                    "<td style = 'width:20%'><b>" + pOrders[i].DateOrdered + "</b></td>" +
                    "<td style = 'width:20%'><b>" + Total.toFixed(2) + "</b></td>" +
                    "<td><a onclick='ManagePurchaseOrder(" + pOrders[i].Id + ");return false;' class='btn btn-success'><i class='icon-edit'></i></a>" + "</td></tr>";
            }
            else {
                po += "<tr><td style = 'width:20%'><b>" + pOrders[i].PurchaseOrderNumber + "</b></td><td style = 'width:auto;'><b>" +
                    pOrders[i].TrackingNumber + "</b></td><td style = 'width:20%'><b>" + pOrders[i].OrderedBy + "</b></td>" +
                    "<td style = 'width:20%'><b>" + pOrders[i].ShippedBy + "</b></td>" +
                    "<td style = 'width:20%'><b>" + pOrders[i].DateOrdered + "</b></td>" +
                    "<td style = 'width:20%'><b>" + Total.toFixed(2) + "</b></td>" +
                    "<td><a onclick='ManagePurchaseOrder(" + pOrders[i].Id + ");return false;' class='btn btn-success'><i class='icon-edit'></i></a>" + "</td></tr>";
            }
            if (pOrders[i].POParts.length > 0) {
                po += "<tr ><td colspan= '7' style= 'border-top: 0px; color:#000;'><table  style = 'border-bottom-color: #ff0000;' ><thead>" +
                    "<tr><th  colspan= '4'>Item Name</th><th >Price</th><th >Quantity</th><th>Shipping CHarges</th><th >Total</th></tr></thead>";
                for (var j = 0; j < pOrders[i].POParts.length; j++) {
                    var total = ((pOrders[i].POParts[j].Quantity * pOrders[i].POParts[j].Price) + pOrders[i].POParts[j].ShippingCharges + pOrders[i].POParts[j].SalesTax).toFixed(2);
                    po += "<tr><td colspan= '4' style = 'width:70%'>" + pOrders[i].POParts[j].Name + "</td>" + "<td style = 'width:10%' >"
                        + pOrders[i].POParts[j].Price + "</td>" + "<td style = 'width:10%'  >"
                        + pOrders[i].POParts[j].Quantity + "</td>" + "<td style = 'width:10%'  >"
                        + pOrders[i].POParts[j].ShippingCharges + "</td>" + "<td style = 'width:10%'  >" + total + "</td></tr>";
                }

                //po += "</table>";

            }

            po += "<tr style = 'border-bottom: 5pt solid black;' ><td colspan = '5'><span style = 'font-size:12px'>Ship To: &nbsp;" + shippedto + "</span></td><td colspan='2'>" + pOrders[i].OrderStatusName + "</td></tr></table>";
        }


    }
    else {
        po += '<tr><td colspan="6"><h4 style="color:red;">PO does not exist .</h4></td><td></td</tr></table>';
    }
    po += "</tbody>";
    //var tes2t = po;
    $('#PurchaseOrdersGrid').html("");
    $('#PurchaseOrdersGrid').html(po);

    //var test = $('#PurchaseOrdersGrid').text();
    if (pOrders.length > 0) {
        $('#tabs li:nth-child(5)').attr('style', 'background: green;border: green;');
        $('#tabs li:nth-child(5)').find('a').attr('style', 'color:#fff;');
    }
    else {
        $('#tabs li:nth-child(5)').removeAttr('style');
        $('#tabs li:nth-child(5)').find('a').removeAttr('style');
    }

}

function PurchaseOrderByEstimate() {
    CreatePO();
    AddPartsFromEstimate($('#CallSlipId').val());
}


function AddPartsFromEstimate(JobId) {
    var request = { JobID: JobId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "PurchaseOrders/AddPartsToPO",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                Notify('Purchase Order Created Successfully.', 'success');
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}



var printPurchaseOrderId = 0;

function ManagePurchaseOrder(pOrderId) {
     
    printPurchaseOrderId = pOrderId;


    var request = { PurchaseOrderId: pOrderId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetPurchaseOrderDetailsByPurchaseOrderId",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                 

                if (data.purchaseOrderModel.Type == "Return") { RenderROParts(data.parts, data.total, data.purchaseOrderModel.Type); }
                else {
                    RenderPOParts(data.parts, data.total);
                }

                var poDetail = data.purchaseOrderModel;
                $('#PODateOrdered').val('');
                $('#InvoiceBy').val('');
                $('#OrderedBy').val('');
                $('#ShippedBy').val('');
                $('#PurchaseOrderNumber').val('');
                $('#ShippingDetails').val('');
                $('#TrackingNumber').val('');
                $("#contact").text('');
                $("#calledby").text('');
                $('#ShippingDetails').val(poDetail.ShippingDetails);
                $('#TrackingNumber').val(poDetail.TrackingNumber);
                $('#PODateOrdered').val(poDetail.DateOrdered);
                $('#InvoiceBy').val(poDetail.InvoiceBy);
                $('#OrderedBy').val(poDetail.OrderedBy);

                var OptionDiv = '<option value="1">-- Select --</option>';
                OptionDiv += '<option value="Ground">FedEx Ground</option>';
                OptionDiv += '<option value="FedEx Express Saver">FedEx Express Saver</option>';
                OptionDiv += '<option value="FedEx Economy Service">FedEx Economy Service</option>';
                OptionDiv += '<option value="FedEx Economy AM Service">FedEx Economy AM Service</option>';
                OptionDiv += '<option value="FedEx Standard Overnight">FedEx Standard Overnight</option>';
                OptionDiv += '<option value="FedEx Priority Overnight">FedEx Priority Overnight</option>';
                OptionDiv += '<option value="FedEx First Overnight">FedEx First Overnight</option>';
                OptionDiv += '<option value="AI:  Will Call">AI:  Will Call</option>';
                OptionDiv += '<option value="IML: Will Call">IML: Will Call</option>';
                OptionDiv += '<option value="HL Flake: Will Call">HL Flake: Will Call</option>';
                OptionDiv += '<option value="Others">Others</option>';

                if (data.ContactPerson != null) {
                    $("#contact").text(data.ContactPerson);
                }
                if (data.CalledBy != null) {
                    $("#calledby").text(data.CalledBy);
                }

                $('#ShippedBy').html(OptionDiv);

                if (poDetail.ShippedBy != null) {
                    $('#shipMethod').val(poDetail.ShippedBy);

                    if ($('#shipMethod').val() != poDetail.ShippedBy) {
                        //$('#shipMethod').html('<option value="' + poDetail.ShippedBy + '">' + poDetail.ShippedBy + '</option>' + $('#shipMethod').html());
                        $('#shipMethod').val(poDetail.ShippedBy);
                    }
                }



                $('#PurchaseOrderNumber').val(poDetail.PurchaseOrderNumber);
                $('#OrderStatus').val(poDetail.OrderStatus);
                $('#AISSParts').prop('checked', poDetail.AISSParts);

                $('#BillingFirstName').val(poDetail.BillingAddress.FirstName);
                $('#BillingLastName').val(poDetail.BillingAddress.LastName);
                $('#BillingCity').val(poDetail.BillingAddress.City);
                $('#BillingAddress1').val(poDetail.BillingAddress.Address1);
                $('#BillingAddress2').val(poDetail.BillingAddress.Address2);
                $('#BillingZipCode').val(poDetail.BillingAddress.ZipPostalCode);
                $('#BillingPhone').val(poDetail.BillingAddress.PhoneNumber);
                $('#BillingStateId').val(poDetail.BillingAddress.StateId).trigger("chosen:updated");
                $('#BillingCountyId').val(poDetail.BillingAddress.CountyId).trigger("chosen:updated");

                // Shipping Address
                $('#ShippingFirstName').val(poDetail.ShippingAddress.FirstName);
                $('#ShippingLastName').val(poDetail.ShippingAddress.LastName);
                $('#ShippingCity').val(poDetail.ShippingAddress.City);
                $('#ShippingAddress1').val(poDetail.ShippingAddress.Address1);
                $('#ShippingAddress2').val(poDetail.ShippingAddress.Address2);
                $('#ShippingZipCode').val(poDetail.ShippingAddress.ZipPostalCode);
                $('#ShippingPhone').val(poDetail.ShippingAddress.PhoneNumber);
                $('#ShippingStateId').val(poDetail.ShippingAddress.StateId).trigger("chosen:updated");
                $('#ShippingCountyId').val(poDetail.ShippingAddress.CountyId).trigger("chosen:updated");

                $("#noid").dialog({

                    autoOpen: true, title: 'Manage Purchase Order# ' + pOrderId,
                    resizable: true,
                    width: $(window).width() - 100,
                    height: $(window).height() - 100,
                    modal: true,
                    close: function () {
                        $(this).dialog("destroy");
                        GetPurchaseOrderDetails();
                        if ($('#InvoiceForm').is(':visible'))
                            GetPurchaseOrderDetailsOnMarkups();
                    }
                });


            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}
function DeletePOPartFromCallSip(pid) {
    $("<div></div>").dialog({
        title: "Please confirm",
        buttons: [{
            text: "Yes",
            id: "btnConfirm",
            click: function () {
                var request = { CallSlipId: $('#CallSlipId').val(), PurchaseOrderId: printPurchaseOrderId, PODetailId: pid };
                $.ajax({
                    type: "POST",
                    contentType: "application/json, charset=utf-8",
                    url: baseURL + "Home/DeletePOPartFromCallSip",
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty("d")) {
                            data = msg.d;
                        } else
                            data = msg;
                        if (data.success) {
                            RenderPOParts(data.parts, data.total);
                        } else {
                            Notify(data.message, 'error');
                        }
                    },
                    error: function () {
                        CommunicationError();
                    }
                });
                $(this).dialog("close");
            }
        },
        {
            text: "No",
            id: "btnCancel",
            click: function () {
                $(this).dialog("destroy");
            }
        }],
        open: function () {

            StyleWarningDiagle($(this));

            $(this).html("<div class='warning'><h2>Are you sure to delete ?</h2></div>");
            $('#btnConfirm').removeAttr("class");
            $('#btnCancel').removeAttr("class");
            $('#btnConfirm').addClass("btn btn-success");
            $('#btnCancel').addClass("btn btn-danger");

        }
    });
}

function DeleteROPartFromCallSip(pid) {
    $("<div></div>").dialog({
        title: "Please confirm",
        buttons: [{
            text: "Yes",
            id: "btnConfirm",
            click: function () {
                var request = { CallSlipId: $('#CallSlipId').val(), PurchaseOrderId: printPurchaseOrderId, PODetailId: pid };
                $.ajax({
                    type: "POST",
                    contentType: "application/json, charset=utf-8",
                    url: baseURL + "Home/DeletePOPartFromCallSip",
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty("d")) {
                            data = msg.d;
                        } else
                            data = msg;
                        if (data.success) {
                            $('#ROPartId').val('');
                            RenderROParts(data.parts, data.total);
                        } else {
                            Notify(data.message, 'error');
                        }
                    },
                    error: function () {
                        CommunicationError();
                    }
                });
                $(this).dialog("close");
            }
        },
        {
            text: "No",
            id: "btnCancel",
            click: function () {
                $(this).dialog("destroy");
            }
        }],
        open: function () {

            StyleWarningDiagle($(this));

            $(this).html("<div class='warning'><h2>Are you sure to delete ?</h2></div>");
            $('#btnConfirm').removeAttr("class");
            $('#btnCancel').removeAttr("class");
            $('#btnConfirm').addClass("btn btn-success");
            $('#btnCancel').addClass("btn btn-danger");

        }
    });
}

function CreatePO() {
    var type = $('#POType').val();
    var request = { CallSlipId: $('#CallSlipId').val(), POType: $('#POType').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/CreatePO",
        data: JSON.stringify(request),
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                GetPurchaseOrderDetails(type);
            }
            else {
                Notify(data.message, 'error');
            }
        },
        complete: function () {
            GetNotesByJobId();
        },
        error: function () {
            CommunicationError();
        }
    });
}
function CreateReturn() {
    
    var request = { CallSlipId: $('#CallSlipId').val(), POType: "Return" };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/CreateReturn",
        data: JSON.stringify(request),
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                GetPurchaseOrderDetails("Return");
            }
            else {
                Notify(data.message, 'error');
            }
        },
        complete: function () {
            GetNotesByJobId();
        },
        error: function () {
            CommunicationError();
        }
    });
}
function checkIsSRFirstOrNot() {
    var request = { PrintPurchaseOrderId: printPurchaseOrderId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "PurchaseOrders/checkIsSRFirstOrNot",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {

                var count = data.count;
                if (count == '0') {

                    userPermissionForPO();
                }
                else {

                    RedirectToPO(3);
                }
            }
            else {
                //Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function userPermissionForPO() {

    var PoMessage = "<p style='margin: 10px 10px 10px 10px; font-size:13px; font-weight: bold;'> Are you sure to generate the Sales Receipt for this Job? </p>";
    $('#userPermissionPO').html(PoMessage);
    $('#userPermissionPO').dialog({
        title: "Create First PO",
        //height: 280,
        //width: 450,
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Yes',
            id: 'btnOkPOPermission',
            click: function () {

                RedirectToPO(3);
                $(this).dialog('close');
            }

        },
        {
            text: 'No',
            id: 'btnNoPoPermission',
            click: function () {
                $(this).dialog('close');
            }

        }],

        close: function (event, ui) {
            $(this).dialog('destroy');
        },
        open: function () {
            $("#btnOkPOPermission").removeAttr("class");
            $("#btnOkPOPermission").addClass("btn btn-primary btn-large");
            $("#btnNoPoPermission").removeAttr("class");
            $("#btnNoPoPermission").addClass("btn btn-danger btn-large");
        }
    });
}
function RedirectToPO(id) {

    var url = "";
    if (id == 1) {
        url = getBaseUrl() + "/PurchaseOrders/PurchaseOrder/" + "?PurchaseOrderId=" + printPurchaseOrderId;
        if (url.includes('Home')) {
            url = url.replace('Home', '')
        }
    }
    if (id == 2) {
        url = getBaseUrl() + "/PurchaseOrders/GeneratePackingSlip/" + "?PurchaseOrderId=" + printPurchaseOrderId;
        if (url.includes('Home')) {
            url = url.replace('Home', '')
        }
    }
    if (id == 3) {
        url = getBaseUrl() + "/PurchaseOrders/GenerateSalesReceipt/" + "?PurchaseOrderId=" + printPurchaseOrderId;
        if (url.includes('Home')) {
            url = url.replace('Home', '')
        }
    }
    window.open(url, '_blank');
    if (id == 3) {
        setTimeout(function () {
            GetContractorsByJobId();
        }, 3000);
    }
}

//function checkIsSRFirstOrNot() {
//    var request = { PrintPurchaseOrderId: printPurchaseOrderId };
//    $.ajax({
//        type: "POST",
//        contentType: "application/json, charset=utf-8",
//        url: baseURL + "PurchaseOrders/checkIsSRFirstOrNot",
//        data: JSON.stringify(request),
//        success: function (msg) {
//            var data;
//            if (msg.hasOwnProperty("d")) {
//                data = msg.d;
//            } else
//                data = msg;
//            if (data.success) {

//                var count = data.count;
//                if (count == '0') {

//                    userPermissionForPO();
//                }
//                else {

//                    RedirectToPO(3);
//                }
//            }
//            else {
//                //Notify(data.message, 'error');
//            }
//        },
//        error: function () {
//            CommunicationError();
//        }
//    });
//}

function userPermissionForPO() {
    var PoMessage = "<p style='margin: 10px 10px 10px 10px; font-size:13px; font-weight: bold;'> Are you sure to generate the Sales Receipt for this Job? </p>";
    $('#userPermissionPO').html(PoMessage);
    $('#userPermissionPO').dialog({
        title: "Create First PO",
        //height: 280,
        //width: 450,
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Yes',
            id: 'btnOkPOPermission',
            click: function () {

                RedirectToPO(3);
                $(this).dialog('close');
            }

        },
        {
            text: 'No',
            id: 'btnNoPoPermission',
            click: function () {
                $(this).dialog('close');
            }

        }],

        close: function (event, ui) {
            $(this).dialog('destroy');
        },
        open: function () {
            $("#btnOkPOPermission").removeAttr("class");
            $("#btnOkPOPermission").addClass("btn btn-primary btn-large");
            $("#btnNoPoPermission").removeAttr("class");
            $("#btnNoPoPermission").addClass("btn btn-danger btn-large");
        }
    });
}

function SaveAndClosePurchaseOrder() {

    var request = { PurchaseOrderId: printPurchaseOrderId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "PurchaseOrders/SendOrderAcknowledgement",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                Notify(data.message, 'success');
                GetPurchaseOrderDetails();
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });

    $('#noid').dialog("destroy");
}

// process payments
$('#ProcessCheckPayment').click(function () {
    var AmountFormValid = $('#AmountForm').valid();
    var CheckFormValid = $('#CheckForm').valid();
    if (CheckFormValid && AmountFormValid) {
        var request = {
            CallSlipId: $('#CallSlipId').val(), PaymentMethodId: $('#PaymentMethodId').val(),
            Amount: $('#Amount').val(), CheckNumber: $('#CheckNumber').val(),
            CheckPaidDate: $('#CheckPaidDate').val(), ReceiptNumber: $('#ccReceiptNumber').val(), Notes: $('#PaymentNotes').val()
        };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/ProcessCheckPayment",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    Notify(data.message, 'success');
                    SelectJob(data.JobId);
                    //refreshCallsGrid(0);
                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
    else {
        $('#CheckForm .required').each(function () {
            $(this).attr('placeholder', 'Field is required');
        });
        $('#AmountForm .required').each(function () {
            $(this).attr('placeholder', 'Field is required');
        });
    }
});

$('#ProcessCashPayment').click(function () {
    var AmountFormValid = $('#AmountForm').valid();
    if (AmountFormValid) {
        var request = {
            CallSlipId: $('#CallSlipId').val(),
            PaymentMethodId: $('#PaymentMethodId').val(),
            Amount: $('#Amount').val(),
            PaidDate: $('#PaidDate').val(),
            Notes: $('#PaymentNotes').val(), ReceiptNumber: $('#ccReceiptNumber').val()
        };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/ProcessCashPayment",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    Notify(data.message, 'success');
                    SelectJob(data.JobId);
                    //refreshCallsGrid(0);
                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    } else {
        $('#AmountForm .required').each(function () {
            $(this).attr('placeholder', 'Field is required');
        });
    }
});
//$('#CreditCardForm').validate({
//    rules: {
//        CardNumber: {
//            required: true,
//            min: 13,
//            creditcard: true
//        }
//    }
//});

$('#ProcessCardPayment').click(function () {

    var cardNumber = $('#CardNumber').val();
    if ($('#cardNotRun').is(":checked") == true) {
        $('#CardNumber').removeClass("required");
        $('#CardNumber').rules('remove');
        $('#CRVNumber').removeClass("required");
        $('#CRVNumber').rules('remove');
        $('#NameOnCard').removeClass("required");
        $('#NameOnCard').rules('remove');
        cardNumber = "";
        NameOnCard = "";
        CRVNumber = "";
    }
    else {
        $('#CardNumber').addClass("digits required");
    }

    var CreditCardFormValid = $('#CreditCardForm').valid();
    var AmountFormValid = $('#AmountForm').valid();
    if (CreditCardFormValid && AmountFormValid) {
        var request = {
            CallSlipId: $('#CallSlipId').val(), Amount: $('#Amount').val(), ExistingCard: "False",
            NameOnCard: $('#NameOnCard').val(), AddressOnCard: $('#AddressOnCard').val(), CardCity: $('#CardCity').val(),
            CardZip: $('#CardZip').val(), StateId: $('#StateId').val(), CRVNumber: $('#CRVNumber').val(),
            CreditCardExpireMonth: $('#CreditCardExpireMonth').val(), CreditCardExpireYear: $('#CreditCardExpireYear').val(), CardNotRun: $('#cardNotRun').is(":checked"),
            CardNumber: cardNumber, CreditCardType: $('#PaymentMethodId option:selected').text(),
            PaymentMethodId: $('#PaymentMethodId').val(), ReceiptNumber: $('#ccReceiptNumber').val(), Notes: $('#PaymentNotes').val()
        };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/ProcessCardPayment",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    if ($('#cardNotRun').is(":checked") == true) {
                        Notify(data.message, 'success');
                    }
                    else {
                        Notify('Payment Processed Successfully.', 'success');
                    }

                    SelectJob(data.JobId);
                    //refreshCallsGrid(0);
                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
    else {
        $('#CreditCardForm .required').each(function () {
            $(this).attr('placeholder', 'Field is required');
        });
        $('#AmountFormValid .required').each(function () {
            $(this).attr('placeholder', 'Field is required');
        });
    }

    return true;
});

//Save Card Payment Function
function UseCardForPayment(id) {
    var request = { CardId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetCardDetailsByCardId",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                FillCardDetails(data.card);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function FillCardDetails(card) {

    if (card != undefined) {
        $('#CreditCardId').val(card.CardId);
        $('#NameOnCard').val(card.NameOnCard);
        var cardNumber = card.CustomerCreditCardNumber;
        if (cardNumber != '' && cardNumber.length > 5) {
            cardNumber = cardNumber.replace(/.(?=.{4,}$)/g, '*');
        }

        $('#CardNumber').val(cardNumber);
        $('#hdnCreditCardNumber').val(card.CustomerCreditCardNumber);
        $('#CRVNumber').val(card.cvv);
        $('#CreditCardExpireMonth').val(card.CreditCardExpireMonth);
        $('#CreditCardExpireYear').val(card.CreditCardExpireYear);
        $('#AddressOnCard').val(card.AddressOnCard);
        $('#CardZip').val(card.CardZip);
        $('#CardCity').val(card.CardCity);
        $('#PaymentStateId').val(card.StateId);
        $('#cardNotRun').attr('checked', card.CardNotRun);

        //$('#CreditCardDetails').find('input[type=text],input[type=password], select').attr('disabled', true);

    } else {
        ResetCardPaymentFields();
    }
}
function ResetCardPaymentFields() {
    $('#CreditCardId').val("");
    $('#hdnCreditCardNumber').val("");
    $('#NameOnCard').val("");
    $('#CardNumber').val("");
    $('#CRVNumber').val("");
    $('#CreditCardExpireMonth').val("");
    $('#CreditCardExpireYear').val("");
    $('#AddressOnCard').val("");
    $('#CardZip').val("");
    $('#CardCity').val("");
    $('#PaymentStateId').val("");
    $('#Amount').val("");
    $('#PaymentNotes').val("");
    $('#PaidDate').val("");
    $('#cardNotRun').attr('checked', false);
}
// send message
function SendSMS() {
    var SMSFrom = $('#SMSFrom').valid();
    if (SMSFrom) {

        var message = "jobId #" + $('#CallSlipId').val() + "#" + "\n" + $('#SMSMessage').val();
        if ($('#smsType').val() == "iPhone")
            message = $('#SMSMessage').val();
        var request = {
            CallSlipId: $('#CallSlipId').val(),
            Message: message,
            ToPhone: $('#ToPhone').val(),
            smsType: $('#smsType').val(),
        };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/SendSMS",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    Notify(data.message, 'success');
                    GetMessagesAndNotificationsByJobId($('#CallSlipId').val());
                    //SelectJob(data.JobId);
                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
    else {
        $('#SMSFrom .required').each(function () {
            $(this).attr('placeholder', 'Field is required');
        });
    }
}

// send message
function DuplicateJob() {
    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/DuplicateJob",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                Notify(data.message, 'success');
                refreshCallsGrid(0);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}


// Notes popup
function AddNotesPopup() {
    $('#NotesPopup').dialog({
        title: 'Add Notes',
        resizable: true,
        width: '570px',
        modal: false,
        position: ['left', 'top'],
    });

    $('#cancelNotes').click(function () {
        $("#NotesPopup").dialog("close");
        $('#NotesInPopup').val("");
    });
}



function populateNTEInfo(nteInfoList) {

    var total = 0;
    for (var i = 0; i < nteInfoList.length; i++) {
        var disc = nteInfoList[i].Description;
        switch (disc) {
            case "Trip Charges":
                $('#NTETechTripCharges').val(nteInfoList[i].Charges);
                total += parseFloat(nteInfoList[i].Charges);
                break;
            case "Labour Charges":
                $('#NTETechLaborCharges').val(nteInfoList[i].Charges);
                total += parseFloat(nteInfoList[i].Charges);
                break;
            case "Parts Charges":
                $('#NTETechPartsCharges').val(nteInfoList[i].Charges);
                total += parseFloat(nteInfoList[i].Charges);
                break;
            case "Keys Charges":
                $('#NTETechKeysCharges').val(nteInfoList[i].Charges);
                total += parseFloat(nteInfoList[i].Charges);
                break;
            default:
                if ($('#txtNteOther1').val() == "") {
                    $('#txtNteOther1').val(nteInfoList[i].Description);
                    $('#NTETechOther1Charges').val(nteInfoList[i].Charges);
                    total += parseFloat(nteInfoList[i].Charges);
                } else
                    if ($('#txtNteOther2').val() == "") {
                        $('#txtNteOther2').val(nteInfoList[i].Description);
                        $('#NTETechOther2Charges').val(nteInfoList[i].Charges);
                        total += parseFloat(nteInfoList[i].Charges);
                    } else
                        if ($('#txtNteOther3').val() == "") {
                            $('#txtNteOther3').val(nteInfoList[i].Description);
                            $('#NTETechOther3Charges').val(nteInfoList[i].Charges);
                            total += parseFloat(nteInfoList[i].Charges);
                        }
                        else
                            if ($('#txtNteOther4').val() == "") {
                                $('#txtNteOther4').val(nteInfoList[i].Description);
                                $('#NTETechOther4Charges').val(nteInfoList[i].Charges);
                                total += parseFloat(nteInfoList[i].Charges);
                            }
                break;
        }
        $('#NTETechTotalCharges').val(total);
        $('#txtNteTrip').val("Trip");
        $('#txtNteLabor').val("Labor");
        $('#txtNteParts').val("Parts");
        $('#txtNteKeys').val("Keys");
    }


}

function LinkJobsValidation() {

    var vl = true;
    if ($('#LinkedJobId').val() == "") {
        errorStyle($('#LinkedJobId'));
        vl = false;
    }
    else {
        //$('#C_Email').css('border', 'none');
    }
    $('.requiredjob').each(function () {
        if ($(this).val().length < 1) {
            $(this).css('border', '1px solid red');
            vl = false;
        }
        else {
            removerErrorStyle($(this));
        }
    });
    if (vl == true) {
        LinkJobs();
    }
}
function LinkJobs() {
    var linkID = $('#LinkedJobId').val();
    var request = { JobId: $('#dispatchcallslipID').text(), LinkedJobId: $('#LinkedJobId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/LinkJobs",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {

                $('#LinkedJobId').val("");

                $("#LinkJobsPopup").dialog("close");

                $("#linkJobId").removeAttr("class");
                $("#linkJobId").removeAttr("onclick");
                $("#linkJobId").tooltip(
                    {
                        content: "Job is Linked with JobId : " + linkID
                    });
                $("#linkJobId").addClass("btn btn-danger");
                $("#linkJobId").text("");
                $("#linkJobId").text("Linked");


            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function SaveNotes() {

    if ($('#NotesInPopup').val() != "") {
        var request = { CallSlipId: $('#CallSlipId').val(), Notes: $('#NotesInPopup').val(), RelatedToInvoice: $('#RelatedToInvoice').is(":checked"), RelatedToServiceChannel: $('#RelatedToServiceChannel').is(":checked"), RelatedToIphone: $('#RelatedToIphone').is(":checked") };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/SaveNotes",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    $('#NotesInPopup').css('border', 'none');
                    $('#NotesInPopup').val("");
                    $('#RelatedToInvoice').removeAttr('checked');
                    $("#NotesPopup").dialog("close");
                    ShowJobNotes();
                    GetNotesOnMarkup();
                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
    else {
        $('#NotesInPopup').css('border', '1px solid red');
        $("#NotesPopup").dialog("open");
    }
}
//Function to refresh notes section on service panel without refreshing whole screen
function ShowJobNotes() {
    var request = { callSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetJobNotes",
        global: false,
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                PopulateJobNotes(data.notes, data.linkJobId);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

// Customer Notes PopUp
function CustomerNotesPopup() {

    var request = { CustomerId: $('#CustomerId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Customer/GetCustomerNotes",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                PopulateCustomerNotes(data.Notes);
            } else {
                PopulateCustomerNotes(data.Notes);
                $('#btnSaveCustomerNotesFromSP').hide();
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function PopulateCustomerNotes(notes) {
    var winH = $(window).height() - 100;
    var winW = $(window).width() - 600;

    $('#CustomerNotesPopup').dialog({
        title: 'Customer Instructions/Notes',
        resizable: true,
        width: winW,
        height: winH,
        modal: true,
        position: ['center', 'center'],
        buttons: [{
            text: 'Save',
            id: 'btnSaveCustomerNotesFromSP',
            click: function () {
                var notes = $('#CustomerNotesOnSP').data('tEditor').value();
                SaveCustomerNotesFromSP(notes);
                $(this).dialog('close');
            }
        },
        {
            text: 'Cancel',
            id: 'btnCancelCustomerNotes',
            click: function () {
                $(this).dialog('close');
            }
        }],

        close: function (event, ui) {
            $(this).dialog('destroy');
        },
        open: function () {
            $("#btnSaveCustomerNotesFromSP").removeAttr("class");
            $("#btnSaveCustomerNotesFromSP").addClass("btn btn-primary btn-large");
            $("#btnCancelCustomerNotes").removeAttr("class");
            $("#btnCancelCustomerNotes").addClass("btn btn-danger btn-large");
            $('#CustomerNotesOnSP').data('tEditor').value("");
            if (notes != null) {
                $('#CustomerNotesOnSP').data('tEditor').value(notes);
            }
        }
    });
}

// Store Notes PopUp
function StoreNotesPopup() {

    var request = { StoreId: $('#StoreId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Customer/GetStoreNotes",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                PopulateStoreNotes(data.Notes);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function PopulateStoreNotes(notes) {
    var winH = $(window).height() - 100;
    var winW = $(window).width() - 600;

    $('#StoreNotesPopup').dialog({
        title: 'Store Instructions/Notes',
        resizable: true,
        width: winW,
        height: winH,
        modal: true,
        position: ['center', 'center'],
        buttons: [{
            text: 'Save',
            id: 'btnSaveStoreNotesFromSP',
            click: function () {
                var notes = $('#StoreNotesOnSP').data('tEditor').value();
                SaveStoreNotesFromSP(notes);
                $(this).dialog('close');
            }
        },
        {
            text: 'Cancel',
            id: 'btnCancelStoreNotes',
            click: function () {
                $(this).dialog('close');
            }
        }],

        close: function (event, ui) {
            $(this).dialog('destroy');
        },
        open: function () {
            $("#btnSaveStoreNotesFromSP").removeAttr("class");
            $("#btnSaveStoreNotesFromSP").addClass("btn btn-primary btn-large");
            $("#btnCancelStoreNotes").removeAttr("class");
            $("#btnCancelStoreNotes").addClass("btn btn-danger btn-large");
            $('#StoreNotesOnSP').data('tEditor').value("");
            if (notes != null) {
                $('#StoreNotesOnSP').data('tEditor').value(notes);
            }
        }
    });
}

function CloseCustomerNotes() {
    $("#CustomerNotesPopup").dialog("close");
}

//function StoreNotesPopup() {
//    var winH = $(window).height() - 10;
//    $('#StoreNotesPopup').dialog({

//        title: 'Store Instructions/Notes',
//        resizable: true,
//        width: '400px',
//        height: winH,
//        modal: false,
//        position: ['left', 'bottom'],
//    });

//    $('#txtStoreNotes').html(StoreNotesForPopup);
//}

function EmailLogPopup() {
    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetEmailLog",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                var winH = $(window).height() - 130;
                var winW = $(window).width() - 200;
                $('#emailLogPopUpMenu').dialog({
                    title: 'Email Log',
                    resizable: true,
                    width: winW,
                    height: winH,
                    modal: false,
                    position: ['center', 'center'],
                });

                if (data.listModel.length > 0) {
                    var table = "<table class='table table-advance'>";
                    table += "<thead><tr>";
                    table += "<th>Subject</th>";
                    table += "<th>Message</th>";
                    table += "<th>To</th>";
                    table += "<th>Date</th>";
                    table += "<th>From</th>";
                    table += "</tr></thead>";
                    for (var i = 0; i < data.listModel.length; i++) {
                        var date = data.listModel[i].date;
                        var value = new Date
                            (
                            parseInt(date.replace(/(^.*\()|([+-].*$)/g, ''))
                            );
                        var hours = value.getHours();
                        var minutes = value.getMinutes();
                        var ampm = hours >= 12 ? 'pm' : 'am';
                        hours = hours % 12;
                        hours = hours ? hours : 12; // the hour '0' should be '12'
                        //if minute less than zero add 0 at the start
                        minutes = minutes < 10 ? '0' + minutes : minutes;
                        var strTime = hours + ':' + minutes + ' ' + ampm;
                        var dat = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear() + " - " + strTime;
                        table += "<tr><td>" + data.listModel[i].subject + "</td>";
                        table += "<td>" + data.listModel[i].message + "</td>";
                        table += "<td>" + data.listModel[i].to + "</td>";
                        table += "<td>" + dat + "</td>";
                        table += "<td>" + data.listModel[i].from + "</td></tr>";
                    }

                    table += "</table>";
                    $('#emailLogPopUpMenu').html(table);
                }
                else {
                    var message = "<h4 style = 'color: red;'>Email log for this job does not exist</h4>";
                    $('#emailLogPopUpMenu').html(message);
                }
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function JobStatusPopup() {
    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/JobStatusHistory",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                var winH = $(window).height() - 10;
                $('#JobStatusPopUpmenu').dialog({
                    title: 'Job Status History',
                    //resizable: true,
                    draggable: false,
                    width: '400px',
                    height: winH,
                    modal: true,
                    position: ['left', 'bottom'],
                });

                if (data.listModel.length > 0) {
                    var table = "<table class='table table-advance'>";
                    table += "<thead><tr>";
                    table += "<th>Previous Status</th>";
                    table += "<th>New Status</th>";
                    table += "<th>Updated On</th>";
                    table += "<th>Updated By</th>";
                    table += "</tr></thead>";
                    for (var i = 0; i < data.listModel.length; i++) {
                        var date = data.listModel[i].TimeStamp;
                        var value = new Date
                            (
                            parseInt(date.replace(/(^.*\()|([+-].*$)/g, ''))
                            );
                        var hours = value.getHours();
                        var minutes = value.getMinutes();
                        var ampm = hours >= 12 ? 'pm' : 'am';
                        hours = hours % 12;
                        hours = hours ? hours : 12; // the hour '0' should be '12'
                        //if minute less than zero add 0 at the start
                        minutes = minutes < 10 ? '0' + minutes : minutes;
                        var strTime = hours + ':' + minutes + ' ' + ampm;
                        var dat = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear() + " - " + strTime;
                        table += "<tr><td>" + data.listModel[i].PreviousStatusName + "</td>";
                        table += "<td>" + data.listModel[i].NewStatusName + "</td>";
                        table += "<td>" + dat + "</td>";
                        table += "<td>" + data.listModel[i].UserName + "</td><tr>";
                    }

                    table += "</table>"

                    $('#JobStatusPopUpmenu').html(table);
                }
                else {
                    var message = "<h4 style = 'color: red;'>Job Status History Does not exist</h4>";
                    $('#JobStatusPopUpmenu').html(message);
                }
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });

}


function SaveInvoiceTax() {

    var request = {
        JobId: $("#CallSlipId").val(),
        InvoiceId: $('#InvoiceId').val(),
        taxAmount: $('#lblTax').val()
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Invoice/OverrideTax",
        data: JSON.stringify(request),
        async: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {

                if ($('#lblTax').val().trim() === "") {
                    var stateTax = parseFloat($('#lblStateTax').html());
                    var newTotal = parseFloat(parseFloat($('#GrandTotal').html()) + stateTax).toFixed(2);
                    $('#GrandTotal').html(newTotal);
                }
                Notify(data.message, 'success');
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });

}



function JobDateHistoryPopup() {
    var request = { CallSlipId: $('#CallSlipId').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/JobDateHistory",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                var winH = $(window).height() - 10;
                $('#JobStatusPopUpmenu').dialog({
                    title: 'Date History',
                    //resizable: true,
                    width: '400px',
                    height: winH,
                    modal: true,
                    position: ['left', 'bottom'],
                });

                if (data.listModel.length > 0) {


                    var table = "<table class='table table-advance'>";
                    table += "<thead><tr>";
                    table += "<th>Date Changed</th>";
                    table += "<th>Changed By</th>";
                    table += "<th>Log Message</th>";
                    table += "</tr></thead>";
                    for (var i = 0; i < data.listModel.length; i++) {
                        var date = data.listModel[i].TimeStamp;
                        //convert timestamp into date format
                        //var value = new Date
                        //            (
                        //                 parseInt(date.replace(/(^.*\()|([+-].*$)/g, ''))
                        //            );
                        //var hours = value.getHours();
                        //var minutes = value.getMinutes();
                        //var ampm = hours >= 12 ? 'pm' : 'am';
                        //hours = hours % 12;
                        //hours = hours ? hours : 12; // the hour '0' should be '12'
                        ////if minute less than zero add 0 at the start
                        //minutes = minutes < 10 ? '0' + minutes : minutes;
                        //var strTime = hours + ':' + minutes + ' ' + ampm;
                        //var dat = value.getMonth() +
                        //                         1 +
                        //                       "/" +
                        //           value.getDate() +
                        //                       "/" +
                        //       value.getFullYear() + " - " + strTime;
                        table += "<tr><td>" + date + "</td>";
                        table += "<td>" + data.listModel[i].UserName + "</td>";
                        table += "<td>" + data.listModel[i].LogMessage + "</td></tr>";


                    }

                    table += "</table>"

                    $('#JobStatusPopUpmenu').html(table);
                }
                else {
                    var message = "<h4 style = 'color: red;'>Job Date History Does not exist</h4>";
                    $('#JobStatusPopUpmenu').html(message);
                }
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });



}

function conEmailValidation() {
    var vl = true;
    if ($('#C_Email').val() == "") {
        errorStyle($('#C_Email'));
        vl = false;
    }
    else {
        //$('#C_Email').css('border', 'none');
    }
    $('.required_email').each(function () {
        if ($(this).val().length < 1) {
            $(this).css('border', '1px solid red');
            vl = false;
        }
        else {
            removerErrorStyle($(this));
        }
    });
    if (vl == true) {
        SendConEmail();
    }
}

function SendConEmail() {


    var request = { JobId: $('#dispatchcallslipID').text(), ContractorId: $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id"), Email: $('#C_Email').val(), Subject: $('#ConEmailSub').val(), Body: $('#ConEmailBody').val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "BaseALS/EmailViaContractorAssign",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            $('#conEmail').val("");
            $('#ConEmailSub').val("");
            $('#ConEmailBody').val("");
            $("#EmailPopup").dialog("close");
            ShowJobNotes();
            Notify('Email Sent successfully', 'success');
        },
        error: function () {
            Notify('Unable to send Email', 'error');
        }
    });
}



function LinkJobPopup() {


    $('#LinkJobsPopup').dialog({
        title: 'Link Another Job',
        resizeable: true,
        width: '400px',
        modal: false,
        position: ['center', 'center'],


    });


    $('#cancelLinkJobs').click(function () {
        $("#LinkJobsPopup").dialog("close");
        $("#LinkedJobId").val("");

    });
}
function SendEmailOnContractorSelection() {

    var request = { JobId: $('#dispatchcallslipID').text(), ContractorId: $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id") };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "BaseALS/ConEmailTo",
        data: JSON.stringify(request),
        success: function (msg) {
            $('#C_EmailTo').val(msg.MainEmailAddress);
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;

            } else
                data = msg;

        },
        error: function () {
            Notify('Contractor has no Email', 'error');
        }
    });

    $('#EmailPopup').dialog({
        title: 'Send Email',
        resizeable: true,
        width: '500px',
        modal: false,
        position: ['left', 'top'],


    });

    $('#CancelEmailPopup').click(function () {
        $("#EmailPopup").dialog("close");
        $("#emailList").val("");
        $('#conEmail').val("");
        $('#ConEmailSub').val("");
        $('#ConEmailBody').val("");
    });
}

function ResetJobforiPhone(contID, JobId) {
    var request = { ContractorId: contID, JobId: JobId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/ResetJobForiPhone",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            Notify("Job Invoice reset on iPhone", "success");
            ShowJobNotes();
        },
        error: function () {
        }
    });
}

function AddContractorNotesPopup(cId) {
    contractorId = cId;
    $('#ContractorNotesPopup').dialog({
        title: 'Add Contractor Notes',
        resizable: true,
        width: '500px',
        modal: false,
        position: ['left', 'top'],
    });

    $('#cancelContractorNotes').click(function () {
        $("#ContractorNotesPopup").dialog("close");
        $('#ContractorNotesInPopup').val("");
    });
}


function SaveContractorNotes() {

    if ($('#ContractorNotesInPopup').val() != "") {
        var request = { ContractorId: contractorId, Notes: $('#ContractorNotesInPopup').val() };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Contractor/CreateNotes",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {

                    if ($('#chkboxBlackList').is(":checked")) {
                        var request = { ContractorId: contractorId, Notes: $('#ContractorNotesInPopup').val() };
                        $.ajax({
                            type: "POST",
                            contentType: "application/json, charset=utf-8",
                            url: baseURL + "Contractor/AddtoBlackBallList",
                            data: JSON.stringify(request),
                            success: function (msg) {
                                var data;
                                if (msg.hasOwnProperty("d")) {
                                    data = msg.d;
                                } else
                                    data = msg;
                            },
                            error: function () {
                            }
                        });
                    }

                    $('#ContractorNotesInPopup').val("");
                    $("#ContractorNotesPopup").dialog("close");
                    //reset blacklist checkbox
                    $('#chkboxBlackList').removeAttr('checked');
                    //SelectJob($('#CallSlipId').val());
                    GetContractorsByJobId();

                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
    else {
        $('#ContractorNotesInPopup').css('border', '1px solid red');
        $("#ContractorNotesPopup").dialog("open");
    }
}

function AddTechnicianNotesPopup(TechId) {
    TechnicianId = TechId;
    $('#TechnicianNotesPopup').dialog({
        title: 'Add Technician Notes',
        resizable: true,
        width: '500px',
        modal: false,
        position: ['left', 'top'],
    });

    $('#cancelTechniciaNotes').click(function () {
        $("#TechnicianNotesPopup").dialog("close");
        $('#TechnicianNotesInPopup').val("");
    });

    var count = 1;
    $('#ConfirmTechNotes').click(function () {

        if ($('#TechnicianNotesInPopup').val() != "" && count == 1) {
            var request = { TechnicianId: TechId, Notes: $('#TechnicianNotesInPopup').val() };
            $.ajax({
                type: "POST",
                contentType: "application/json, charset=utf-8",
                url: baseURL + "Technician/CreateTechNotes",
                data: JSON.stringify(request),
                success: function (msg) {
                    var data;
                    if (msg.hasOwnProperty("d")) {
                        data = msg.d;
                    } else
                        data = msg;
                    if (data.success) {
                        $('#TechnicianNotesInPopup').val("");
                        $("#TechnicianNotesPopup").dialog("close");

                    } else {
                        Notify(data.message, 'error');
                    }
                },
                error: function () {
                }
            });
        }
        else {
            $('#TechnicianNotesInPopup').css('border', '1px solid red');
            $("#TechnicianNotesPopup").dialog("open");
        }
        count++;
    });
}

function GetContrInfo(cId, type) {
    contractorId = cId;
    $('#CommissionPopup').dialog({
        title: 'Contractor Info',
        resizable: false,
        minHeight: '500px',
        //maxHeight: '100vh',
        width: '900px',
        top: '5px',
        left: '224px',
        modal: true,
        buttons: [
            //{
            //    text: "Save",
            //    id: "btnSaveConInfoSP",
            //    click: function () {
            //        UpdateContractorInfo();
            //    }
            //},
            {
                text: "Cancel",
                id: "btnCancelDispatch",
                click: function () {
                    $(this).dialog('close');
                }
            }
        ],
        open: function () {

            //$('#CommissionPopup').css("height", "86vh");
            $('.btnSaveConInfoSP').removeAttr("class");
            $('#btnCancelDispatch').removeAttr("class");
            $('.btnSaveConInfoSP').addClass("btn btn-success");
            $('#btnCancelDispatch').addClass("btn btn-danger");
            if ($('#IsWarrantyJob').val() == "1") {
                $('.chkIsWarrantyJob').prop('checked', true);
            }
            else {
                $('.chkIsWarrantyJob').prop('checked', false);
            }
            if (type == 3) {

                $('#panel2').hide();
                $('#contractorDispatchDiv').hide();

            }
        }
    });

    GetContractorInfo(cId);
}

// save extra comission
var contractorId = "";
function AddExtraCommission(cId, type) {
    console.log("In AddExtraCommission");
    contractorId = cId;

    $('.customerratesondispatchpopup').hide();
    $('#divContractorButtons').hide();
    $('.CustTripCharges').text($('#CustomerTripCharges').val());
    $('.CustHourlyLabor').text($('#CustomerHourlyLabour').val());

    if (($('#CustomerTripCharges').val() != "" && parseFloat($('#CustomerTripCharges').val()) > 0) || ($('#CustomerHourlyLabour').val() != "" && parseFloat($('#CustomerHourlyLabour').val()) > 0)) {
        $('.customerratesondispatchpopup').show();
    }
    else {

        $('.customerratesondispatchpopup').hide();
    }

    $("input[type='radio']").each(function () {
        $(this).prop('checked', false);
        $('#txtNTEOtherEta').val("");
        $('#txtNTEOtherEta').hide();
    });
    //$('#NTETechTotalCharges').val("");


    var currentCommistion = $("tr#" + contractorId + " td:nth-child(3)").text();
    var nteAmount = $("tr#" + contractorId + " td:nth-child(4)").text();
    $('#ExtraCommission').val(currentCommistion.substring(0, currentCommistion.length - 1));
    $('#IsDispatch').val(type);
    $('#ContractorNTEAmount').val(nteAmount);
    $('#NTETechTripCharges').val("");
    $('#NTETechLaborCharges').val("");
    $('#NTETechPartsCharges').val("");
    $('#NTETechKeysCharges').val("");
    $('#NTETechOther1Charges').val("");
    $('#NTETechOther2Charges').val("");
    $('#NTETechOther3Charges').val("");
    $('#NTETechOther4Charges').val("");
    $('#txtNteOther1').val("");
    $('#txtNteOther2').val("");
    $('#txtNteOther3').val("");
    $('#txtNteOther4').val("");
    $('#NTETechTotalCharges').val("");
    $('.ContractorContactPerson').val("");
    $('.ContractorInfoNTEAmount').val("");
    $("#NTEChangeReason").val("");


    ViewContractorsBasicInformation(cId, type);


    //get customer default rates
    //PopulateCustomerDetails();

}


function PopulateCustomerDetails() {

    var custID = $('#CustomerId').val();

    var request = { Id: custID };

    $.ajax({
        type: "POST",
        url: baseURL + "Customer/GetCustomer",
        data: JSON.stringify(request),
        contentType: "application/json, charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {

                $('.CustTripCharges').text(data.customer.TripCharges);
                $('.CustHourlyLabor').text(data.customer.HourlyLabour);

            } else {
                Notify(data.message, 'error');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        },
        complete: function () {
        }
    });

}

/// FUNCTION TO VIEW  MARKUP DETAILS FROM PAYABLE SCREEN
function ViewMarkup() {

    $('#ViewMarkupPopup').load(baseURL + "Invoice/Create/" + "?CallSlipId=" + $('#CallSlipId').val());
    $('#ViewMarkupPopup').dialog({
        title: 'Mark up Details',
        resizable: true,
        width: 650,
        modal: true,
        buttons: [
            {
                text: "Close",
                id: "Close Purchase Order",
                click: function () {
                    $(this).dialog('close');
                }
            }],
        close: function (event, ui) {
            $(this).dialog('destroy');
            $('#ViewMarkupPopup').html("");
        }
    });
}

function PopuplateInvoiceWithEstimateDetails() {

    // CreateInvoiceBeforeParts(true);
    console.log("In PopuplateInvoiceWithEstimateDetails 2 ");

    var request = {
        CallSlipId: $("#CallSlipId").val()
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Invoice/PopuplateInvoiceWithEstimateDetails",
        data: JSON.stringify(request),
        async: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                if (data.NewInvoice)
                    Notify("Markup Created Successfully.", 'success');
                $('#InvoiceId').val(data.InvoiceId);
                CreateInvoice();
                UpdateServicePanelForMarkup();
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
    // });
}
//**************** Function to Download Invoice on Click Save button markup panel
function GeneratePdf(InvoiceId) {
    var request = { InvoicesIds: InvoiceId };

    $.ajax({
        type: "POST",
        url: baseURL + "Invoice/PrepareInvoicePdf",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                Notify1(data.message + "Path to the Document is: <a href='/Documents/Invoices/)" + data.invoiceName + "' target='_blank'>Click to Download the Pdf.</a>", 'success', data.filePath);
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () { CommunicationError(); }
    });
}






// function to alert for nte amount while making a payment on right panel or creating receipt

function FlagNTEAmount() {
    console.log("Calling dispatchboard.cshtml  FlagNTEAmount");

    var element = $("#Contractors table tr[id==''] :nth-child(4)").text();
    if (parseFloat($('#Amount').val()) > parseFloat(element)) {
        //if (GreaterThanNTEAmountEntryAllowed != 1) {
        Notify('NTE Amount exceeded! You are not allowed to enter exceeding NTE amounts.', 'error');
    }
    //else {
    //    Notify('You are entering an amount which is exceeding the default NTE amount.', 'error');
    //}
}

var contractorNTEAmount = 0;

function DeletePartFromInvoice(partId) {
    $("<div></div>").dialog({
        title: "Please confirm",
        buttons: [{
            text: "Yes",
            id: "btnConfirm",
            click: function () {
                var request = { CallSlipId: $('#CallSlipId').val(), PartId: partId };
                $.ajax({
                    type: "POST",
                    contentType: "application/json, charset=utf-8",
                    url: baseURL + "Invoice/DeletePartFromInvoice",
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty("d")) {
                            data = msg.d;
                        } else data = msg;
                        if (data.success) {
                            //if (!data.InvoiceExists) {
                            //    $('#CreateInvoice').removeClass("btn-Markup-NotApproved");
                            //    $('#CreateInvoice').removeClass("btn-Markup");
                            //}
                            $('.ReceiptPopup').dialog('destroy');
                            $('.ReceiptPopup').html("");
                            CreateInvoice();
                            UpdateServicePanelForMarkup();
                            GetDocumentsByCallSlipId();
                        } else {
                            Notify(data.message, 'error');
                        }
                    },
                    error: function () { CommunicationError(); }
                });
                $(this).dialog("close");
            }
        }, {
            text: "No",
            id: "btnCancel",
            click: function () {
                $(this).dialog("destroy");
            }
        }],
        open: function () {

            StyleWarningDiagle($(this));
            $(this).html("<div class='warning'><h2>Are you sure to delete ?</h2></div>");
            $('#btnConfirm').removeAttr("class");
            $('#btnCancel').removeAttr("class");
            $('#btnConfirm').addClass("btn btn-success");
            $('#btnCancel').addClass("btn btn-danger");

        }
    });
}
function IssueNoticeForm(formNumber) {

    var callslipId = $(".Service_tab_CallSlipId").text();
    if ($('input[type="radio"][name="contractorForNoticeForm"]:checked').length > 0) {
        url = getBaseUrl() + "/Invoice/NoticeForm/" + "?CallSlipId=" + $(".Service_tab_CallSlipId").text() + "&FormNumber=" + formNumber + "&ContractorId=" + $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id");
        window.open(url, '_blank');
    }
    else {
        Notify("No contractor is selected", "error");
    }
}

/// Function te remove contractor
function RemoveContractors() {
    //
    var request = { ContractorId: $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id"), JobId: $(".Service_tab_CallSlipId").text() }
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/RemoveContractors",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else data = msg;
            if (data.success) {
                //Notify("Contractor Removed Successfully!", "success");
                //SelectJob($(".Service_tab_CallSlipId").text());
                $('#divContractorButtons').hide();
                //$('#btnRemoveContractor').hide();
                //$('#btnFirstNoticeForm').hide();
                //$('#btnCreateJobNotes').hide();
                //$('#btnPayWithCC').hide();
                //$('#btnPaidPaywithCC').hide();
                GetContractorsByJobId();

            } else {
                Notify("Contractor have payable! Cannot be deleted", "error");
            }
        },
        error: function () { CommunicationError(); }
    });


}

// check if receipt does not exist for any contractor display the notice form button
function CheckNoticeForm(contractorId) {
    $('#divContractorButtons').css("display", "inline-block");
    //$('#btnRemoveContractor').show();
    //$('#btnCreateJobNotes').show();
    //$('#btnPayWithCC').show();
    //$('#btnPaidPaywithCC').show();
    //$('#btnFirstNoticeForm').show();
    var request = { CallSlipId: $('#CallSlipId').val(), ContractorId: contractorId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Invoice/CheckNoticeForm",
        data: JSON.stringify(request),
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else data = msg;
            if (data.success) {
                if (!data.ReceiptExist) {
                    if (data.FormNumber == 0) {
                        $('#btnFirstNoticeForm').show();
                        $('#btnSecondNoticeForm').hide();
                        $('#btnThirdNoticeForm').hide();
                    }
                    if (data.FormNumber == 1) {
                        $('#btnFirstNoticeForm').hide();
                        $('#btnSecondNoticeForm').show();
                        $('#btnThirdNoticeForm').hide();
                    }
                    if (data.FormNumber == 2) {
                        $('#btnFirstNoticeForm').hide();
                        $('#btnSecondNoticeForm').hide();
                        $('#btnThirdNoticeForm').show();
                    }
                    if (data.FormNumber == 3) {
                        $('#btnFirstNoticeForm').hide();
                        $('#btnSecondNoticeForm').hide();
                        $('#btnThirdNoticeForm').hide();
                    }
                }
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () { CommunicationError(); }
    });

}
// get alerts for job having schedule time too close
var delay = 30000; // 1 Minute
function GetDelayingJobs() {
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetDelayingJobs",
        global: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else data = msg;
            if (data.success) {
                if (data.model.length > 0) {
                    for (var i = 0; i < data.model.length; i++) {
                        var jobs = "";
                        jobs += '<div class="jobAlerts">';
                        jobs += '<div><strong>Job Id:</strong><span style="font-size: 14px;font-weight: bold;">';
                        jobs += data.model[i].Id;
                        jobs += '</span><div>';
                        jobs += '<div><strong>Customer Name:</strong><span style="font-size: 14px;font-weight: bold;">';
                        jobs += data.model[i].CustomerName;
                        jobs += '</span><div>';
                        jobs += '<div><strong>City:</strong><span style="font-size: 14px;font-weight: bold;">';
                        jobs += data.model[i].City;
                        jobs += '</span><div>';
                        jobs += '<div><strong>Phone:</strong><span style="font-size: 14px;font-weight: bold;">';
                        jobs += data.model[i].Phone;
                        jobs += '</span><div>';
                        jobs += '<div><strong>Time Scheduled:</strong><span style="font-size: 14px;font-weight: bold;">';
                        jobs += data.model[i].TimeScheduled;
                        jobs += '</span><div>';
                        jobs += '<div><strong>Contractors:</strong><span style="font-size: 14px;font-weight: bold;">';
                        jobs += data.model[i].Contractors;
                        jobs += '</span><div>';
                        jobs += '<div>';
                        $.growl({ title: "Job Alert", message: jobs });

                    }
                }
            }
        },
        error: function () { CommunicationError(); }
    });
}

//setInterval(function () {
//    GetDelayingJobs();
//}, delay);
function OpenEditContractors() {

    url = getBaseUrl() + "/Contractor/editContractor/ " + " ?ContractorId =  " + $('#hdnContractorId').val();
    window.open(url, '_blank');
}

function GetContractorInfo(cId) {


    //
    $('#panel1').show();
    $('.contractorDispatchDiv').hide();
    $('#txtNteOtherEta').val("");
    $('#txtNteTrip').val("Trip");
    $('#txtNteLabor').val("Labor");
    $('#txtNteParts').val("Parts");
    $('#txtNteKeys').val("Keys");
    var test = $('#txtNteKeys').val();
    var selectedVal = "";
    var selected = $("#SendSignOffEtaDiv input[type='radio']:checked");
    if (selected.length > 0) {
        selectedVal = selected.val();

    }
    var request = { Id: cId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Contractor/GetContractorInfo",
        global: false,
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else data = msg;
            if (data.success) {

                $('.contractorDetailsNotes').html("");
                var notes = data.notes;
                var documentInfo = data.documents;
                data = data.contractor;
                if (data.ContPictureUrl != "") {
                    $('.ContractorImage').attr('src', baseURL + data.ContPictureUrl.replace('~/', ''));
                }
                $("#hdnContractorId").val(cId);

                $(".ContractorContactPerson").val(data.ContactPerson);
                //($($(".ContractorContactPerson")[0]).val() != null) ? $($(".ContractorContactPerson")[1]).val(data.ContactPerson) : $($(".ContractorContactPerson")[0]).val(data.ContactPerson),

                $(".cFirstName").val(data.FirstName);
                $(".cLastName").val(data.LastName);
                $(".MainEmailAddress").val(data.MainEmailAddress);
                $(".cBusinessName").val(data.BusinessName);
                $(".MainCompanyPhone").val(data.MainCompanyPhone);
                $("#cAddress").val(data.CorporateAddress1);
                $('.cCommissionRate').val(data.CommissionRate);
                $('#cHiringDate').val(data.StartDate);
                $('.cActive').prop('checked', data.Active);
                if (data.Active) {
                    $('#cInActiveContractorAlert').hide();
                }
                else {
                    $('#cInActiveContractorAlert').show();
                }
                $('.BestMethodOfCommunication').val(data.PreferedCommunicationMethod);
                //if (data.Commissioned) {
                //    $('#cCommissioned').attr('checked', 'checked');
                //} else {
                //    $('#cCommissioned').removeAttr('checked');
                //}
                if (data.DefaultNTEAmount != null) {
                    $('.cDefaultNTEAmount').val("$" + data.DefaultNTEAmount);
                }
                else {
                    $('.cDefaultNTEAmount').val("$0");
                }

                if (data.LicenseNumber != null) {
                    $('.cLicenseNumber').val(data.LicenseNumber);
                }
                else {
                    $('.cLicenseNumber').val("");
                }

                if (data.ServiceCallCharges != null) {
                    $('.ServiceCall').val("$" + data.ServiceCallCharges);
                }
                else {
                    $('.ServiceCall').val("$0");
                }
                if (data.HourlyLaborRate != null) {
                    $('.HourlyLabor').val("$" + data.HourlyLaborRate);
                }
                else {
                    $('.HourlyLabor').val("$0");
                }

                if (data.RekeyCharges != null) {
                    $('.Rekey').val("$" + data.RekeyCharges);
                }
                else {
                    $('.Rekey').val("$0");
                }

                if (data.DuplicatesCharges != null) {
                    $('.Duplicates').val("$" + data.DuplicatesCharges);
                }
                else {
                    $('.Duplicates').val("$0");
                }

                if (data.AfterHoursCharges != null) {
                    $('.AfterHoursEmergencyServiceCall').val("$" + data.AfterHoursCharges);
                }
                else {
                    $('.AfterHoursEmergencyServiceCall').val("$0");
                }

                if (data.AfterHoursLaborRate != null) {
                    $('.AfterHourEmergencyLaborRate').val("$" + unescape(data.AfterHoursLaborRate));
                }
                else {
                    $('.AfterHourEmergencyLaborRate').val("$0");
                }
                $('.AfterHoursAlternatePhone').val(data.AfterHoursAlternatePhone);
                $('.MainCompanyFax').val(data.MainCompanyFax);
                $('#ContractorSource').val(data.Source);

                $('.shippingAddress').val(data.completeAddress);
                $('.cTotalJobs').html(data.TotalJobs);
                var TripCharges = data.TripCharges == null ? "0" : data.TripCharges;
                $('.TripCharges').val(unescape("$" + TripCharges));
                var LaborCharges = data.LaborCharges == null ? "0" : data.LaborCharges;
                $('.LaborCharges').val(unescape("$" + LaborCharges));

                //$('#ContractorInfoNTEAmount').val(data.JobNteAmount);
                $('.ContractorInfoExtraCommission').val(data.ExtraCommision);
                $('.ContractorCorporateZip').val(data.CorporateZipPostalCode);
                $('.paymentMethod').val(data.PaymentPreference);
                var note = "<table class='table table-advance' id='contractorNotesOnDB'>";
                if (notes.length > 0) {

                    if (data.DeleteDocumentAllowed) {
                        for (var i = 0; i < notes.length; i++) {
                            note += "<tr id='" + notes[i].NoteId + "'><td>" + notes[i].Notes + "<b><span class='notesAuthor pull-right'>[" + notes[i].CreatedOn +
                                " - " + notes[i].UserName + "]</span></b></td><td><a class='btn btn-danger' onclick='DeleteNote(" + notes[i].NoteId + "," + true + ")'><i class='icon-trash'> </i></a> </td></tr>";
                        }
                    }
                    else {
                        for (var i = 0; i < notes.length; i++) {
                            note += "<tr><td>" + notes[i].Notes + "<b><span class='notesAuthor pull-right'>[" + notes[i].CreatedOn +
                                " - " + notes[i].UserName + "]</span></b></td></tr>";
                        }
                    }


                }
                else {
                    note += "<tr><td colspan='1'><h4 style='color:red;'>Notes does not exist.</h4></td></tr>";

                }
                note += "</table>";
                $('.contractorDetailsNotes').html(note);

                var compNotes = "<h3 align='center'><b>Contractor Documents Status</b></h3><table class='table table-advance'><tbody style='color: red;'>";
                var w9Form = 0; var contrForm = 0; var insurCert = 0; var licenseDoc = 0;
                var w9FormUpload = 0; var contrFormUpload = 0; var insurCertUpload = 0; var licenseDocUpload = 0;
                var InsurExpiry = 0;
                if (documentInfo.length > 0) {
                    for (var x = 0; x < documentInfo.length; x++) {
                        var docType = documentInfo[x].ContractorDocumentType;
                        if (docType == 1) { w9Form = 1; w9FormUpload = documentInfo[x].CreatedOn; }
                        if (docType == 2) { contrForm = 1; contrFormUpload = documentInfo[x].CreatedOn; }
                        if (docType == 3) {
                            insurCert = 1;
                            insurCertUpload = documentInfo[x].CreatedOn;
                            InsurExpiry = documentInfo[x].ExpiryDate;
                            //InsurExpiry = getJSONDate(documentInfo[x].ExpiryDate);
                        }
                        if (docType == 4) { licenseDoc = 1; licenseDocUpload = documentInfo[x].CreatedOn; }
                    }

                    compNotes += "<tr>";

                    if (w9Form == 0) { compNotes += "<td>W-9 Form is missing!</td>"; }
                    else { compNotes += "<td style='color: green !important;'>W-9 Form is attached on " + w9FormUpload + "</td>"; }

                    if (contrForm == 0) { compNotes += "<td>Sub-Contractor Form is missing!</td>"; }
                    else { compNotes += "<td style='color: green !important;'>Sub-Contractor Form is attached on " + contrFormUpload + "</td>"; }

                    compNotes += "</tr><tr>";

                    if (insurCert == 0) { compNotes += "<td>Insurance Document is missing!</td>"; }
                    else { compNotes += "<td style='color: green !important;'>Insurance Document is attached on " + insurCertUpload + ".<br> Insurance Document is Expiring on " + InsurExpiry + "</td>"; }

                    if (licenseDoc == 0) { compNotes += "<td>License Document is missing!</td>"; }
                    else { compNotes += "<td style='color: green !important;'>License Document is attached on " + licenseDocUpload + "</td>"; }

                    compNotes += "</tr>";


                    if (w9Form == 1 && contrForm == 1 && insurCert == 1 && licenseDoc == 1) {
                        compNotes += "<tr><td style='color: green !important;'> No documents are missing.</td></tr>";
                    }

                    compNotes += "</tbody></table>";
                    $('.complianceData').html(compNotes);
                }
                else {
                    compNotes += "<tr><td>W-9 Form is missing!</td><td>Sub-Contractor Form is missing!</td></tr><tr><td>Insurance Document is missing!</td><td>License Document is missing!</td></tr>";
                    compNotes += "</tbody></table>";
                    $('.complianceData').html(compNotes);
                }

                var html12 = GetContractorRatingsHTMLByRating(data.ContractorRatings);
                var totalRating = "  (" + data.TotalContractorRatings + ")";
                console.log(html12 + totalRating);

                $('.cntStarRating').html(html12 + totalRating);
                PopulateContractorReconciledJob(cId);
            }
        },
        error: function () { CommunicationError(); }
    });
}

function ViewContractorsBasicInformation(cId, type) {
    if (type == false) {
        $('#panel1').hide();
        $('#panel2').show();
        $('#contractorinfodiv').hide();
        $('#contractorNteInfoDiv').hide();
        $('#btnSaveContractorNTEInfo').hide();
        //$('.btnSaveConInfoSP1').show();
        $('.seperator').hide();
        //$('#contactInfoHeading').text("Contractor Pricing Agreement");
        $('#NTEChangeReason').show();
    }
    else {
        $("#panel2").hide();
        $('#panel1').show();
        $('#contractorinfodiv').show();
        $('#contractorNteInfoDiv').show();
        $('#btnSaveContractorNTEInfo').show();
        //$('.btnSaveConInfoSP1').hide();
        $('.seperator').show();
        //$('#contactInfoHeading').text("Contact Information");
        $('#NTEChangeReason').hide();
    }


    $('#txtNteOtherEta').val("");
    $('#txtNteTrip').val("Trip");
    $('#txtNteLabor').val("Labor");
    $('#txtNteParts').val("Parts");
    $('#txtNteKeys').val("Keys");
    var test = $('#txtNteKeys').val();
    var selectedVal = "";
    var selected = $("#SendSignOffEtaDiv input[type='radio']:checked");
    if (selected.length > 0) {
        selectedVal = selected.val();

    }
    var callslipId = $('#CallSlipId').val();

    var request = { Id: cId, CallSlipId: callslipId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Contractor/GetContractor",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else data = msg;
            if (data.success) {

                if (data.nteInformation.length > 0) {
                    populateNTEInfo(data.nteInformation);
                }
                $($(".ContractorBillingEstimate")[1]).val(data.contractor.BillingEstimate);
                $('.contractorDetailsNotes').html("");
                var notes = data.notes;
                var documentInfo = data.documents;
                var NTEChange = data.nteChange;

                //set if contractor has a license on file or not

                data = data.contractor;
                var JobState = $('#ServiceTab_State').val();
                if (JobState == "2" || JobState == "7" || JobState == "9" || JobState == "18" || JobState == "23"
                    || JobState == "27" || JobState == "34" || JobState == "35" || JobState == "37" || JobState == "40" || JobState == "44"
                    || JobState == "45" || JobState == "54" || JobState == "55" || JobState == "59") {
                    if (type && !data.IsLicensed) {
                        Notify1("This state requires license and contractor is not licensed.", 'warning');
                    }
                }

                if (data.ContPictureUrl != "") {
                    $('.ContractorImage').attr('src', baseURL + data.ContPictureUrl.replace('~/', ''));
                }
                //clear some fields
                //$('.ContractorBillingEstimate').val('');
                ($($(".ContractorBillingEstimate")[0]).val() != null) ? $($(".ContractorBillingEstimate")[0]).val('') : $($(".ContractorBillingEstimate")[1]).val('');
                $('.JobMargin').text('');
                $("#congrade").text(data.ProfitabilityRating);
                $("#hdnContractorId").val(cId);

                $(".ContractorContactPerson").val(data.ContactPerson);
                $("#congrade").text = data.ProfitabilityRating;
                $(".cFirstName").val(data.FirstName);
                $(".cLastName").val(data.LastName);
                $(".MainEmailAddress").val(data.MainEmailAddress);
                $(".cBusinessName").val(data.BusinessName);
                $(".MainCompanyPhone").val(data.MainCompanyPhone);
                $("#cAddress").val(data.CorporateAddress1);
                $('.cCommissionRate').val(data.CommissionRate);
                $('#cHiringDate').val(data.StartDate);
                $('.cActive').prop('checked', data.Active);
                $('.cSource').val(data.Source);
                if (data.Active) {
                    $('#cInActiveContractorAlert').hide();
                }
                else {
                    $('#cInActiveContractorAlert').show();
                }

                $('.BestMethodOfCommunication').val(data.PreferedCommunicationMethod);




                if (data.DefaultNTEAmount != null) {
                    $('.cDefaultNTEAmount').val("$" + data.DefaultNTEAmount);
                }
                else {
                    $('.cDefaultNTEAmount').val("$0");
                }

                if (data.LicenseNumber != null) {
                    $('.cLicenseNumber').val(data.LicenseNumber);
                }
                else {
                    $('.cLicenseNumber').val("");
                }

                if (data.ServiceCallCharges != null) {
                    $('.ServiceCall').val("$" + data.ServiceCallCharges);
                }
                else {
                    $('.ServiceCall').val("$0");
                }
                if (data.HourlyLaborRate != null) {
                    $('.HourlyLabor').val("$" + data.HourlyLaborRate);
                }
                else {
                    $('.HourlyLabor').val("$0");
                }

                if (data.RekeyCharges != null) {
                    $('.Rekey').val("$" + data.RekeyCharges);
                }
                else {
                    $('.Rekey').val("$0");
                }

                if (data.DuplicatesCharges != null) {
                    $('.Duplicates').val("$" + data.DuplicatesCharges);
                }
                else {
                    $('.Duplicates').val("$0");
                }

                if (data.AfterHoursCharges != null) {
                    $('.AfterHoursEmergencyServiceCall').val("$" + data.AfterHoursCharges);
                }
                else {
                    $('.AfterHoursEmergencyServiceCall').val("$0");
                }

                if (data.AfterHoursLaborRate != null) {
                    $('.AfterHourEmergencyLaborRate').val("$" + unescape(data.AfterHoursLaborRate));
                }
                else {
                    $('.AfterHourEmergencyLaborRate').val("$0");
                }

                $('.AfterHoursAlternatePhone').val(data.AfterHoursAlternatePhone);
                $('.MainCompanyFax').val(data.MainCompanyFax);
                $('#ContractorSource').val(data.Source);
                $('.shippingAddress').val(data.completeAddress);
                $('.cTotalJobs').html(data.TotalJobs);
                var TripCharges = data.TripCharges == null ? "0" : data.TripCharges;
                $('.TripCharges').val(unescape("$" + TripCharges));
                var LaborCharges = data.LaborCharges == null ? "0" : data.LaborCharges;
                $('.LaborCharges').val(unescape("$" + LaborCharges));
                //$('#ContractorInfoNTEAmount').val(data.JobNteAmount);
                $('.ContractorInfoExtraCommission').val(data.ExtraCommision);
                $('.ContractorCorporateZip').val(data.CorporateZipPostalCode);
                $('.paymentMethod').val(data.PaymentPreference);
                var note = "<table class='table table-advance' id='contractorNotesOnDB'>";
                if (notes.length > 0) {

                    if (data.DeleteDocumentAllowed) {
                        for (var i = 0; i < notes.length; i++) {
                            note += "<tr id='" + notes[i].NoteId + "'><td>" + notes[i].Notes + "<b><span class='notesAuthor pull-right'>[" + notes[i].CreatedOn +
                                " - " + notes[i].UserName + "]</span></b></td><td><a class='btn btn-danger' onclick='DeleteNote(" + notes[i].NoteId + "," + true + ")'><i class='icon-trash'> </i></a> </td></tr>";
                        }
                    }
                    else {
                        for (var i = 0; i < notes.length; i++) {
                            note += "<tr><td>" + notes[i].Notes + "<b><span class='notesAuthor pull-right'>[" + notes[i].CreatedOn +
                                " - " + notes[i].UserName + "]</span></b></td></tr>";
                        }
                    }
                }
                else {
                    note += "<tr><td colspan='1'><h4 style='color:red;'>Notes does not exist.</h4></td></tr>";

                }
                note += "</table>";

                $('.contractorDetailsNotes').html(note);


                var compNotes = "<h3 align='center'><b>Contractor Documents Status</b></h3><table class='table table-advance'><tbody style='color: red;'>";
                var w9Form = 0; var contrForm = 0; var insurCert = 0; var licenseDoc = 0;
                var w9FormUpload = 0; var contrFormUpload = 0; var insurCertUpload = 0; var licenseDocUpload = 0;
                var InsurExpiry = 0;
                if (documentInfo.length > 0) {
                    for (var x = 0; x < documentInfo.length; x++) {
                        var docType = documentInfo[x].ContractorDocumentType;
                        if (docType == 1) { w9Form = 1; w9FormUpload = documentInfo[x].CreatedOn; }
                        if (docType == 2) { contrForm = 1; contrFormUpload = documentInfo[x].CreatedOn; }
                        if (docType == 3) {
                            insurCert = 1;
                            insurCertUpload = documentInfo[x].CreatedOn;
                            InsurExpiry = documentInfo[x].ExpiryDate;
                            //InsurExpiry = getJSONDate(documentInfo[x].ExpiryDate);
                        }
                        if (docType == 4) { licenseDoc = 1; licenseDocUpload = documentInfo[x].CreatedOn; }
                    }

                    compNotes += "<tr>";

                    if (w9Form == 0) { compNotes += "<td>W-9 Form is missing!</td>"; }
                    else { compNotes += "<td style='color: green !important;'>W-9 Form is attached on " + w9FormUpload + "</td>"; }

                    if (contrForm == 0) { compNotes += "<td>Sub-Contractor Form is missing!</td>"; }
                    else { compNotes += "<td style='color: green !important;'>Sub-Contractor Form is attached on " + contrFormUpload + "</td>"; }

                    compNotes += "</tr><tr>";

                    if (insurCert == 0) { compNotes += "<td>Insurance Document is missing!</td>"; }
                    else { compNotes += "<td style='color: green !important;'>Insurance Document is attached on " + insurCertUpload + ".<br> Insurance Document is Expiring on " + InsurExpiry + "</td>"; }

                    if (licenseDoc == 0) { compNotes += "<td>License Document is missing!</td>"; }
                    else { compNotes += "<td style='color: green !important;'>License Document is attached on " + licenseDocUpload + "</td>"; }

                    compNotes += "</tr>";


                    if (w9Form == 1 && contrForm == 1 && insurCert == 1 && licenseDoc == 1) {
                        compNotes += "<tr><td style='color: green !important;'> No documents are missing.</td></tr>";
                    }

                    compNotes += "</tbody></table>";
                    $('.complianceData').html(compNotes);
                }
                else {
                    compNotes += "<tr><td>W-9 Form is missing!</td><td>Sub-Contractor Form is missing!</td></tr><tr><td>Insurance Document is missing!</td><td>License Document is missing!</td></tr>";
                    compNotes += "</tbody></table>";
                    $('.complianceData').html(compNotes);
                }


                var html12 = GetContractorRatingsHTMLByRating(data.ContractorRatings);
                var totalRating = "  (" + data.TotalContractorRatings + ")";
                console.log(html12 + totalRating);

                $('.cntStarRating').html(html12 + totalRating);
                $('.contractorDispatchDiv').show();

                $('#CommissionPopup').dialog({
                    title: 'Contractor Info',
                    resizable: false,
                    minHeight: '500px',
                    //maxHeight: '100vh',
                    width: '900px',
                    top: '5px',
                    left: '224px',
                    modal: true,
                    buttons: [
                        //{
                        //    text: "Save",
                        //    id: "btnSaveConInfoSP",
                        //    click: function () {
                        //        UpdateContractorInfo();
                        //    }
                        //},
                        {
                            text: "Cancel",
                            id: "btnCancelDispatch",
                            click: function () {
                                $(this).dialog('close');
                            }
                        }
                    ],
                    open: function () {
                        //$('#CommissionPopup').css("height", "86vh");
                        $('.btnSaveConInfoSP').removeAttr("class");
                        $('#btnCancelDispatch').removeAttr("class");
                        $('.btnSaveConInfoSP').addClass("btn btn-success");
                        $('#btnCancelDispatch').addClass("btn btn-danger");

                        if ($('#IsWarrantyJob').val() == "1") {
                            $('.chkIsWarrantyJob').prop('checked', true);
                        }
                        else {
                            $('.chkIsWarrantyJob').prop('checked', false);
                        }
                        if (NTEChange) {
                            $(".ContractorInfoNTEAmount").removeAttr('disabled');
                            $(".ContractorInfoNTEAmount").removeAttr("title");
                            $("#NTEChangeReason").removeAttr('disabled');
                        }
                        else {
                            $(".ContractorInfoNTEAmount").attr('disabled', 'disabled');
                            $("#NTEChangeReason").attr('disabled', 'disabled');
                            // Make your change to the element's title
                            $(".ContractorInfoNTEAmount").attr("title", "User dont have permission to change NTE !");

                            $(function () {
                                $(".ContractorInfoNTEAmount").tooltip();
                            });
                        }

                        if ($('#contractorinfodiv').is(":visible")) {
                            $(".ContractorInfoNTEAmount").removeAttr('disabled');
                            $(".ContractorInfoNTEAmount").removeAttr("title");
                        }
                    }
                });
                PopulateContractorReconciledJob(cId);
            }
        },
        error: function () { CommunicationError(); }
    });
}

function getJSONDate(jsonDate) {
    var m, day;
    var d = new Date(parseInt(jsonDate.substr(6)));
    m = d.getMonth() + 1;
    if (m < 10)
        m = "0" + m;
    if (d.getDate() < 10)
        day = "0" + d.getDate();
    else
        day = d.getDate();

    return (m + "/" + day + "/" + d.getFullYear());
}

function UpdateContractorNteInfo() {

    if ($('#panel2').is(":visible")) {
        if ($('#NTEChangeReason').is(":visible") && $('#NTEChangeReason').val() == "" && $($(".ContractorInfoNTEAmount")[1]).val() != "") {
            Notify('Please Add NTE Change Reason.', 'error');
        }
        else if ($('#NTEChangeReason').is(":visible") && $('#NTEChangeReason').val() != "" && $($(".ContractorInfoNTEAmount")[1]).val() == "") {
            Notify('Please Add NTE amount first.', 'error');
        }
        else {
            var request1 = {

                Id: $("#hdnContractorId").val(),

                DefaultNTEAmount: $($(".cDefaultNTEAmount")[1]).val().replace("$", "").trim(),
                //CommissionRate: $($(".cCommissionRate")[1]).val().replace("%", "").trim(),
                //CreatedOn: $('#cHiringDate').val(),
                //MainEmailAddress: $($(".MainEmailAddress")[1]).val(),
                //MainCompanyPhone: $($(".MainCompanyPhone")[1]).val(),
                //BusinessName: $($(".cBusinessName")[1]).val(),
                //FirstName: $($(".cFirstName")[1]).val(),
                //LastName: $($(".cLastName")[1]).val(),
                //MainCompanyFax: $($(".MainCompanyFax")[1]).val(),
                //Source: $('#ContractorSource').val(),
                //ShippingAddress: $($(".shippingAddress")[1]).val(),
                //AccountingContact: $('#AccountingContact').val(),
                //MainAccountingEmailAddress: $('#MainAccountingEmailAddress').val(),
                //CorporateAddress1: $('#cAddress').val(),
                //LicenseNumber: $($(".cLicenseNumber")[1]).val(),
                //ServiceCallCharges: $($(".ServiceCall")[1]).val().replace("$", "").trim(),
                //HourlyLaborRate: $($(".HourlyLabor")[1]).val().replace("$", "").trim(),
                //RekeyCharges: $($(".Rekey")[1]).val().replace("$", "").trim(),
                //DuplicatesCharges: $($(".Duplicates")[1]).val().replace("$", "").trim(),
                //AfterHoursCharges: $($(".AfterHoursEmergencyServiceCall")[1]).val().replace("$", "").trim(),
                //AfterHoursLaborRate: $($(".AfterHourEmergencyLaborRate")[1]).val().replace("$", "").trim(),
                //AfterHoursAlternatePhone: $($(".AfterHoursAlternatePhone")[1]).val(),
                //TripCharges: $($(".TripCharges")[1]).val().replace("$", "").trim(),
                //LaborCharges: $($(".LaborCharges")[1]).val().replace("$", "").trim(),
                Active: $('.cActive').is(':checked'),
                //PreferedCommunicationMethod: $($(".BestMethodOfCommunication")[1]).val(),
                CallSlipId: $('#CallSlipId').val(),
                ExtraCommission: $($(".ContractorInfoExtraCommission")[1]).val(),
                ConctractorNTEAmount: $($(".ContractorInfoNTEAmount")[1]).val(),
                nteChangeReason: $("#NTEChangeReason").val(),
                //AssignedZipCode: $($(".ContractorCorporateZip")[1]).val(),
                PaymentPreference: $($(".paymentMethod")[1]).val(),
                //ContactPerson: $(".ContractorContactPerson").val()
                ContactPerson: $($(".ContractorContactPerson")[1]).val(),
                BillingEstimate: $($(".ContractorBillingEstimate")[1]).val()
            };
        }

    }
    if (request1 != null && request1 != undefined) {
        $.ajax({
            type: "POST",
            url: baseURL + "Contractor/UpdateContractorNTE",
            data: JSON.stringify({ 'model': request1 }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    GetContractorsByJobId();
                    Notify(data.message, 'success');
                    $("#CommissionPopup").dialog("close");

                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () { CommunicationError(); }

        });
    }

}

function UpdateContractorInfo() {

    var contNTE = $('.ContractorInfoNTEAmount').val();
    var contId = $("#hdnContractorId").val();
    var request;
    if ($('#panel1').is(":visible")) {
        if ($('#NTEChangeReason').is(":visible") && $('#NTEChangeReason').val() == "" && $($(".ContractorInfoNTEAmount")[1]).val() != "") {
            Notify("Please Add NTE Change Reason.", "error");
        }
        else if ($('#NTEChangeReason').is(":visible") && $('#NTEChangeReason').val() != "" && $($(".ContractorInfoNTEAmount")[1]).val() == "") {
            Notify("Please Add NTE amount first.", "error");
        }
        else {
            //var firstOBJ = { DefaultNTEAmount : $(".cDefaultNTEAmount")[i], test : asdsa[i] };

            request = {
                Id: $("#hdnContractorId").val(),
                DefaultNTEAmount: $($(".cDefaultNTEAmount")[0]).val().replace("$", "").trim(),
                CommissionRate: $($(".cCommissionRate")[0]).val().replace("%", "").trim(),
                CreatedOn: $('#cHiringDate').val(),
                MainEmailAddress: $($(".MainEmailAddress")[1]).val(),
                MainCompanyPhone: $($(".MainCompanyPhone")[0]).val(),
                BusinessName: $($(".cBusinessName")[0]).val(),
                FirstName: $($(".cFirstName")[0]).val(),
                LastName: $($(".cLastName")[0]).val(),
                MainCompanyFax: $($(".MainCompanyFax")[0]).val(),
                Source: $('#ContractorSource').val(),
                ShippingAddress: $($(".shippingAddress")[0]).val(),
                AccountingContact: $('#AccountingContact').val(),
                MainAccountingEmailAddress: $('#MainAccountingEmailAddress').val(),
                CorporateAddress1: $('#cAddress').val(),
                LicenseNumber: $($(".cLicenseNumber")[0]).val(),
                ServiceCallCharges: $($(".ServiceCall")[0]).val().replace("$", "").trim(),
                HourlyLaborRate: $($(".HourlyLabor")[0]).val().replace("$", "").trim(),
                RekeyCharges: $($(".Rekey")[0]).val().replace("$", "").trim(),
                DuplicatesCharges: $($(".Duplicates")[0]).val().replace("$", "").trim(),
                AfterHoursCharges: $($(".AfterHoursEmergencyServiceCall")[0]).val().replace("$", "").trim(),
                AfterHoursLaborRate: $($(".AfterHourEmergencyLaborRate")[0]).val().replace("$", "").trim(),
                AfterHoursAlternatePhone: $($(".AfterHoursAlternatePhone")[0]).val(),
                TripCharges: $($(".TripCharges")[0]).val().replace("$", "").trim(),
                LaborCharges: $($(".LaborCharges")[0]).val().replace("$", "").trim(),
                Active: $('.cActive').is(':checked'),
                PreferedCommunicationMethod: $($(".BestMethodOfCommunication")[0]).val(),
                CallSlipId: $('#CallSlipId').val(),
                ExtraCommission: $($(".ContractorInfoExtraCommission")[0]).val(),
                ConctractorNTEAmount: $($(".ContractorInfoNTEAmount")[0]).val(),
                nteChangeReason: $("#NTEChangeReason").val(),
                AssignedZipCode: $($(".ContractorCorporateZip")[0]).val(),
                PaymentPreference: $($(".paymentMethod")[0]).val(),
                //ContactPerson: $(".ContractorContactPerson").val()
                ContactPerson: $($(".ContractorContactPerson")[0]).val()
            };
        }

    }
    else if ($('#panel2').is(":visible")) {
        if ($('#NTEChangeReason').is(":visible") && $('#NTEChangeReason').val() == "" && $($(".ContractorInfoNTEAmount")[1]).val() != "") {
            Notify('Please Add NTE Change Reason.', 'error');
        }
        else if ($('#NTEChangeReason').is(":visible") && $('#NTEChangeReason').val() != "" && $($(".ContractorInfoNTEAmount")[1]).val() == "") {
            Notify('Please Add NTE amount first.', 'error');
        }
        else {
            request = {
                Id: $("#hdnContractorId").val(),
                DefaultNTEAmount: $($(".cDefaultNTEAmount")[1]).val().replace("$", "").trim(),
                CommissionRate: $($(".cCommissionRate")[1]).val().replace("%", "").trim(),
                CreatedOn: $('#cHiringDate').val(),
                MainEmailAddress: $($(".MainEmailAddress")[2]).val(),
                MainCompanyPhone: $($(".MainCompanyPhone")[1]).val(),
                BusinessName: $($(".cBusinessName")[1]).val(),
                FirstName: $($(".cFirstName")[1]).val(),
                LastName: $($(".cLastName")[1]).val(),
                MainCompanyFax: $($(".MainCompanyFax")[1]).val(),
                Source: $('#ContractorSource').val(),
                ShippingAddress: $($(".shippingAddress")[1]).val(),
                AccountingContact: $('#AccountingContact').val(),
                MainAccountingEmailAddress: $('#MainAccountingEmailAddress').val(),
                CorporateAddress1: $('#cAddress').val(),
                LicenseNumber: $($(".cLicenseNumber")[1]).val(),
                ServiceCallCharges: $($(".ServiceCall")[1]).val().replace("$", "").trim(),
                HourlyLaborRate: $($(".HourlyLabor")[1]).val().replace("$", "").trim(),
                RekeyCharges: $($(".Rekey")[1]).val().replace("$", "").trim(),
                DuplicatesCharges: $($(".Duplicates")[1]).val().replace("$", "").trim(),
                AfterHoursCharges: $($(".AfterHoursEmergencyServiceCall")[1]).val().replace("$", "").trim(),
                AfterHoursLaborRate: $($(".AfterHourEmergencyLaborRate")[1]).val().replace("$", "").trim(),
                AfterHoursAlternatePhone: $($(".AfterHoursAlternatePhone")[1]).val(),
                TripCharges: $($(".TripCharges")[1]).val().replace("$", "").trim(),
                LaborCharges: $($(".LaborCharges")[1]).val().replace("$", "").trim(),
                Active: $('.cActive').is(':checked'),
                PreferedCommunicationMethod: $($(".BestMethodOfCommunication")[1]).val(),
                CallSlipId: $('#CallSlipId').val(),
                ExtraCommission: $($(".ContractorInfoExtraCommission")[1]).val(),
                ConctractorNTEAmount: $($(".ContractorInfoNTEAmount")[1]).val(),
                nteChangeReason: $("#NTEChangeReason").val(),
                AssignedZipCode: $($(".ContractorCorporateZip")[1]).val(),
                PaymentPreference: $($(".paymentMethod")[1]).val(),
                //ContactPerson: $(".ContractorContactPerson").val()
                ContactPerson: $($(".ContractorContactPerson")[1]).val()
            };
        }

    }
    if (request != null && request != undefined) {
        $.ajax({
            type: "POST",
            url: baseURL + "Contractor/UpdateContractor",
            data: JSON.stringify({ 'model': request }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                    GetContractorsByJobId();
                    Notify(data.message, 'success');
                    $("#CommissionPopup").dialog("close");

                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () { CommunicationError(); }

        });
    }
}



function POTechPopup(ContractorOrStore) {

    $('#PoContractorId').empty();
    var request = {
        CallSlipId: $('#CallSlipId').val()

    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetContractorForJobPO",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else data = msg;
            if (data.success) {
                var test = data.contractor;
                var newOption = "";
                for (var i = 0; i < test.length; i++) {
                    var name = test[i].Text;
                    var Id = test[i].Value;
                    newOption += "<option value='" + Id + "'>" + name + "</option>";
                }
                $("#PoContractorId").append(newOption);
            }
            else {
                Notify(data.message, 'error');
            }
        }
    });
    if (ContractorOrStore == 1) {
        $('#ContractorForPODiv').dialog({
            title: 'Select Contractor For PO',
            resizable: true,
            width: 300,
            height: 250,
            modal: false,

            close: function (event, ui) {
                $(this).dialog('destroy');
            }
        });

        $('#ContractorForPO').click(function () {
            $('#ContractorForPODiv').dialog('destroy');
            LoadTechOrStoreAddress(1);
        });
    }
}



function LoadTechOrStoreAddress(ContractorOrStore) {

    var request = {
        CallSlipId: $('#CallSlipId').val(),
        ContractorOrStore: ContractorOrStore,
        ContractorId: $('#PoContractorId :selected').val()
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "PurchaseOrders/LoadTechOrStoreAddress",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else data = msg;
            if (data.success) {

                $('#BillingCompanyName').val(data.address.CompanyName);
                $('#BillingFirstName').val(data.address.FirstName);
                $('#BillingLastName').val(data.address.LastName);
                $('#BillingCity').val(data.address.City);
                $('#BillingAddress1').val(data.address.Address1);
                $('#BillingAddress2').val(data.address.Address2);
                $('#BillingZipCode').val(data.address.ZipPostalCode);
                $('#BillingPhone').val(data.address.PhoneNumber);
                $('#BillingStateId').val(data.address.StateId).trigger("chosen:updated");
                $('#BillingCountyId').val(data.address.CountyId).trigger("chosen:updated");

                $('#ShippingCompanyName').val(data.address.CompanyName);
                $('#ShippingFirstName').val(data.address.FirstName);
                $('#ShippingLastName').val(data.address.LastName);
                $('#ShippingCity').val(data.address.City);
                $('#ShippingAddress1').val(data.address.Address1);
                $('#ShippingAddress2').val(data.address.Address2);
                $('#ShippingZipCode').val(data.address.ZipPostalCode);
                $('#ShippingPhone').val(data.address.PhoneNumber);
                $('#ShippingStateId').val(data.address.StateId).trigger("chosen:updated");
                $('#ShippingCountyId').val(data.address.CountyId).trigger("chosen:updated");

            }
            else {
                Notify(data.message, 'error');
            }
        }
    });

}
$('#equipment_name').autocomplete({
    source: function (request, response) {
        $.ajax({

            url: baseURL + "Home/LoadEquipments",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.Name,
                        //value: item.Id
                    };
                }));
            }
        });
    },
    minLength: 2
});

$('#PartPODescription').autocomplete({
    source: function (request, response) {
        $.ajax({

            url: baseURL + "Home/LoadDescriptionOnPO",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName,
                        value: item.Id
                    };
                }));
            }
        });
    },
    focus: function (event, ui) {
        $('#POAddPartsField').val(ui.item.label);
        //$("#POAddPartsField").focus();
        event.preventDefault();
    },
    select: function (event, ui) {
        $('#POAddPartsField').val(ui.item.label);
        var request = "{'PartId':'" + ui.item.value + "'}";
        $.ajax({
            type: "POST",
            data: request,
            url: baseURL + "Home/GetPartDetailsById",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var msg;
                if (data.hasOwnProperty("d")) {
                    msg = data.d;
                } else
                    msg = data;
                PopulatePOPartDetailsForm(msg.part);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                CommunicationError();
            }
        });
        $(".ui-menu-item").hide();
        $("#POAddPartsField").focus();
        return false;
    },
    minLength: 2
});

$('#POAddPartsField').autocomplete({
    source: function (request, response) {
        $.ajax({

            url: baseURL + "Home/LoadPartsOnPO",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                if (data.length == 0) {
                    $("#InventoryPart").prop("checked", false);
                    $('#InventoryPart').attr("disabled", true);
                }
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName,
                        value: item.Id
                    };
                }));
                //$("#ui-id-1").css('display', 'block');
                //$("#ui-id-1").css('z-index', '9999999');
                // $("#POAddPartsField").focus();
            }
        });
    },
    focus: function (event, ui) {
        $('#POAddPartsField').val(ui.item.label);
        //$("#POAddPartsField").focus();
        event.preventDefault();
    },
    select: function (event, ui) {
        $('#POAddPartsField').val(ui.item.label);
        var request = "{'PartId':'" + ui.item.value + "'}";
        $.ajax({
            type: "POST",
            data: request,
            url: baseURL + "Home/GetPartDetailsById",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var msg;
                if (data.hasOwnProperty("d")) {
                    msg = data.d;
                } else
                    msg = data;
                $("#InventoryPart").removeAttr("disabled");
                PopulatePOPartDetailsForm(msg.part);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                CommunicationError();
            }
        });
        $(".ui-menu-item").hide();
        $("#POAddPartsField").focus();
        return false;
    },
    minLength: 2
});



$('#ByCustomerName').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetCustomers",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName,
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#ByCustomerName').val($.trim(ui.item.label));
        return false;
    },
    minLength: 3
});

$('#ByCustomerWO').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetCustomerWOs",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#ByCustomerWO').val($.trim(ui.item.label));
        return false;
    },
    minLength: 3
});


$('#ByStoreNumber').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetStoresOnDispatchBoard",


            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#ByStoreNumber').val(ui.item.label);
        return false;
    },
    minLength: 2
});

$('#ByStoreName').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetStoresNameOnDispatchBoard",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#ByStoreName').val(ui.item.label);
        return false;
    },
    minLength: 3
});

$('#FilterPanel_PhoneNumber').autocomplete({

    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetPhoneNumbers",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#FilterPanel_PhoneNumber').val(ui.item.label);
        return false;
    },
    minLength: 3
});

$('#FilterPanel_WorkOrder').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetPurchaseOrderNumber",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#FilterPanel_WorkOrder').val(ui.item.label);
        return false;
    },
    minLength: 3
});

$('#ByCity').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetCityNames",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#ByCity').val(ui.item.label);
        return false;
    },
    minLength: 3
});
$('#ccReceiptNumber').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetReceiptNumbers",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#ccReceiptNumber').val(ui.item.label);
        return false;
    },
    minLength: 3
});

$('#TechFirstName').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetTechFirstNames",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#TechFirstName').val(ui.item.label);
        return false;
    },
    minLength: 2
});
$('#TechLastName').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetTechLastNames",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#TechLastName').val(ui.item.label);
        return false;
    },
    minLength: 2
});
$('#TechCompanyName').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetTechCompanyName",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#TechCompanyName').val(ui.item.label);
        return false;
    },
    minLength: 3
});
$('#FilterPanel_Address').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetAddresses",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#FilterPanel_Address').val(ui.item.label);
        return false;
    },
    minLength: 2
});
$('#FilterPanel_POTrackingNumber').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetTrackingNumbers",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        $('#FilterPanel_POTrackingNumber').val(ui.item.label);
        return false;
    },
    minLength: 3
});

$('#ByJobId').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "Customer/GetJobIds",
            data: { query: request.term },
            dataType: 'json',
            type: 'GET',
            global: false,
            success: function (data) {
                response($.map(data, function (item) {
                    return {
                        label: item.FirstName,
                        value: item.FirstName
                    };
                }));
            }
        });
    },
    select: function (event, ui) {
        var id = ui.item.label;
        $('#ByJobId').val(id);
        SelectJob(id);
    },
    minLength: 3
});


function ViewMap() {
    var TEST = $('#Latitude').val();
    var callslipId = $('#CallSlipId').val();
    // $('#SubTechnicianDiv').load(baseURL+ "Home/SubTechniciansPartial" + "?Id=" + ContractorId);
    //$('#divMap').load(baseURL + "Contractor/ViewMap" + "?latitude=" + $('#Latitude').val() + "&longtitude=" + $('#Longtitude').val());
    $('#divMap').load(baseURL + "Contractor/ViewMap" + "?callslip=" + callslipId);
    $('#divMap').dialog({
        title: 'View Map',
        resizable: true,
        width: $(window).width() - 40,
        height: $(window).height() - 40,
        modal: true,
        buttons: [{
            text: "Close",
            id: "btnCancel",
            click: function () {
                $(this).dialog("destroy");
                $('#divMap').html("");
            }
        }],
        close: function (event, ui) {
            $(this).dialog('destroy');
            $('#divMap').html("");
        },
        open: function () {
            $('#btnCancel').removeAttr("class");
            $('#btnCancel').addClass("cancel btn btn-danger");
        }
    });
}

/***********************************************************************************/
function LoadJobLocationHistory(jobId) {
    
    console.log("In LoadJobLocationHistory");
    var address = $("#Address").val();
    var storeNo = $('#ServiceTab_StoreNumber').text();

    var request = { address: address, storeNo: storeNo, jobId: jobId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetJobLocationHistoryByAddress",
        data: JSON.stringify(request),
        global: false,
        cache: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                PopulateJobHistoryTable(data.jobs, jobId);
                $('#storeHistoryBtn').hide();
            } else {
            }
        },
        complete: function () {
            counter++;
        }
    });
}

function PopulateJobHistoryTable(notes, id) {
    console.log("In PopulateJobHistoryTable");
    $('#' + id).parent().find('#LocationHistoryBody').html("");
    
    var warranty = false;
    if (notes.length > 0) {
        for (i = 0; i < notes.length; i++) {
            if (notes[i].IsWarrantyBanner == true) {
                warranty = true;
                break;
            }
        }
    }

    if (warranty == true) {
        $('#warrantyBannerDiv').show();
    }
    else {
        $('#warrantyBannerDiv').hide();
    }
    var note = "";
    //note += "<thead><tr>";
    //note += "<th>Id</th>";
    //note += "<th>Expected Date</th>";
    //note += "<th>City</th>";
    //note += "<th>Description</th>";
    //note += "<th>Primary Contractor</th>";
    //note += "<th>Amt Paid</th>";
    //note += "</tr></thead>";

    if (notes.length > 0) {
        for (var i = 0; i < notes.length; i++) {
            var data = notes[i];

            var title = "<b>ID:</b> " + data.Id + " <br /><b>Time:</b> " + data.ExpectedDateTime + " <br /><b>Customer Name:</b> " + data.CustomerName;
            title += "<br /><b>Store:</b> " + data.StoreLocationName + "<br /><b>Primary Contractor:</b>" + data.PrimaryContractor +
                "<br /><b>Amt Paid:</b> " + data.ReceiptTotal + " <br /> <br /><b>State:</b> " + data.State + " <br /><b>Phone:</b> " + data.Phone + " <br /><b>Problem:</b> " + data.JobDescription;
            //" <br /><b>City:</b> " + data.City + " <br /><b>State:</b> " + data.State + " <br /><b>Phone:</b> " + data.Phone + " <br /><b>Problem:</b> " + data.JobDescription;
            //title = title.replace("'", "");//Used to replace just one quote char(i.e. first) that caused issue on SP.
            title = title.replace(/'/g, "");//Replaces all the chars(i.e. single quotes) and issue is solved on SP now.
            title = title.replace(/"/g, "");
            note += '<tr  title="' + title + '" class="htmlSection1">';
            note += "<td  style='color:" + notes[i].FontColor + "; background-color:" + notes[i].BackgroundColor +
                ";'><span  class='htmlSection1'  title='" + notes[i].JobStatus + "'><span style='cursor: pointer;' id = '" + notes[i].Id + "' " +
                "onclick = 'LocHistoryPopUp(" + notes[i].Id + ");'>" + notes[i].Id + "</span></td>";
            note += "<td>" + notes[i].ExpectedDateTime + "</td>";
            //note += "<td>" + notes[i].City + "</td>";

            note += "<td> <span  class='htmlSection1'  title='" + notes[i].JobDescription + "'>" + notes[i].JobDescription.substring(0, 20) + "</span></td>";
            note += "<td>" + (notes[i].PrimaryContractor != null ? notes[i].PrimaryContractor : "") + "</td>";
            note += "<td>" + notes[i].ReceiptTotal + "</td>";
            note += "</tr>";
        }
    } else {
        note += "<tr><td colspan='5'><h6 style='color:#d33838;'>No Location History for This Job exists.</h6></td></tr>";
    }
    //note += "</table>";
    $('#' + id).parent().find('#LocationHistoryBody').html(note);
    //$('#LocationHistoryBody').show();


    $('.htmlSection1').tooltip({
        content: function () {
            return this.getAttribute("title");
        },
    });
}


function LocHistoryPopUp(callslipId) {

    var winH = $(window).height() - 10;
    var request = { CallSlipId: callslipId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetJobLocHistory",
        data: JSON.stringify(request),

        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {

                $('#JobLocHistoryPopupMenu').dialog({
                    title: 'Job Location History',
                    resizable: true,
                    width: '400px',
                    height: winH,
                    modal: false,
                    position: ['left', 'bottom'],
                });

                var array = data.message;
                var decription = data.description != null ? data.description : "";
                var note = "<div style=' margin: 10px;text-align: justify;' ><b>Job Description:</b>&nbsp &nbsp" + decription + "<br></div>";
                note += "<table class='table table-advance'>";
                note += "<thead><tr><th>Job Notes  ";
                note += "</th></tr></thead>";

                if (array.length > 0) {


                    if (array.length > 0) {

                        for (var i = 0; i < array.length; i++) {
                            var data = array[i];
                            note += "<tr><td>" + data.Notes + "<b><span class='notesAuthor pull-right'>[" + data.CreatedOn +
                                " - " + data.CreatedBy + "]</span></b></td></tr>";
                        }

                    }

                }
                else {
                    note += "<tr><td colspan='6'><h4 style='color:red;'>No Notes for This Job  exists.</h4></td></tr>";
                }
                note += "</table>";

                $('#JobLocHistoryPopupMenu').html("");
                $('#JobLocHistoryPopupMenu').html(note);

            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}


function LoadJobContractorHistory(jobId) {
    console.log("In LoadJobContractorHistory");

    var request = { jobId: jobId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetJobContractorHistory",
        data: JSON.stringify(request),
        global: false,
        cache: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                PopulateContractorHistoryTable(data.jobs);
                $('#contActiveJob').hide();
            } else {
                Notify(data.message, 'error');
            }
        },
        complete: function () {
            counter++;
        },
        error: function () {
            CommunicationError();
        }
    });
}
function LoadJobTechnicianHistory(jobId) {
    console.log("In LoadJobtechnicianrHistory");

    var request = { jobId: jobId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetJobTechnicianHistory",
        data: JSON.stringify(request),
        global: false,
        cache: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                PopulateTechnicianHistoryTable(data.jobs);
                $('#techActiveJob').hide();
            } else {
                Notify(data.message, 'error');
            }
        },
        complete: function () {
            HideLoaderSP();
        },
        error: function () {
            CommunicationError();
        }
    });
}

//$("#ContractorActiveJob").live('click', function () {
//    var jobId = $(this).text();
//    SelectJob(jobId);
//});

function PopulateContractorHistoryTable(notes, id) {
    console.log("In PopulateContractorHistoryTable");
    $('#' + id).parent().find('#ContractorActiveJobBody').html("");

    var note = "";
    //note += "<thead><tr>";
    //note += "<th>Id</th>";
    //note += "<th>Store</th>";
    //note += "<th>Expected Date</th>";
    //note += "<th>City</th>";
    //note += "<th>Description</th>";
    //note += "<th>Primary Contractor</th>";
    //note += "</tr></thead>";
    //note += "<tbody>";
    if (notes.length > 0) {
        for (var i = 0; i < notes.length; i++) {

            var data = notes[i];
            var title = "<b>ID:</b> " + data.Id + " <br /><b>Time:</b> " + data.ExpectedDateTime + " <br /><b>Customer Name:</b> " + data.CustomerName
                + " <br /><b>Store:</b> " + data.StoreLocationName + " <br /><b>Primary Contractor:</b> " + data.PrimaryContractor
                + " <br /><b>City:</b> " + data.City + " <br /><b>State:</b> " + data.State + " <br /><b>Phone:</b> " + data.Phone + " <br /><b>Problem:</b> " + data.JobDescription;
            //title = title.replace("'", "");//Used to replace just one quote char(i.e. first) that caused issue on SP.
            title = title.replace(/'/g, "");//Replaces all the chars(i.e. single quotes) and issue is solved on SP now.
            note += "<tr  title='" + title + "' class='htmlSection2'>";
            note += "<td  style='color:" + notes[i].FontColor + "; background-color:" + notes[i].BackgroundColor +
                ";'><span  class='htmlSection2'  title='" + notes[i].JobStatus + "'><a id='ContractorActiveJob' style='cursor:pointer; color:black;'>" + notes[i].Id + "</a></span></td>";
            note += "<td>" + notes[i].StoreLocationName + "</td>";
            note += "<td>" + notes[i].ExpectedDateTime + "</td>";
            note += "<td>" + notes[i].City + "</td>";
            //note += "<td> <span  class='htmlSection2'  title='" + notes[i].JobDescription + "'>" + notes[i].JobDescription.substring(0, 20) + "</span></td>";
            note += "<td>" + notes[i].PrimaryContractor + "</td>";
            note += "</tr>";
        }

    }
    else {
        note += "<tr><td colspan='6'><h6 style='color:#d33838;'>No History for This Contractor exists.</h6></td></tr>";
    }
    //note += "</tbody></table>";

    $('#' + id).parent().find('#ContractorActiveJobBody').html(note);

    $('.htmlSection2').tooltip({
        content: function () {
            return this.getAttribute("title");
        },
    });
}

function PopulateTechnicianHistoryTable(notes, id) {
    console.log("In PopulateTechnicianrHistoryTable");
    $('#' + id).parent().find('#TechnicianDailyActivityBody').html("");
    var note = "";
    //note += "<thead><tr>";
    //note += "<th>Id</th>";
    //note += "<th>Store</th>";
    //note += "<th>Expected Date</th>";
    //note += "<th>City</th>";
    //note += "<th>Description</th>";
    //note += "<th>Primary Contractor</th>";
    //note += "</tr></thead>";
    if (notes.length > 0) {

        for (var i = 0; i < notes.length; i++) {
            var data = notes[i];
            var date = data.ExpectedDate;
            var value = new Date
                (
                parseInt(date.replace(/(^.*\()|([+-].*$)/g, ''))
                );
            var hours = value.getHours();
            var minutes = value.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12;
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;
            var dat = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear() + " - " + strTime;

            var title = "<b>ID:</b> " + data.Id + " <br /><b>Time:</b> " + data.ExpectedDateTime + " <br /><b>Customer Name:</b> " + data.CustomerName;
            title += " <br /><b>Store:</b> " + data.StoreLocationName + " <br /><b>Primary Contractor:</b> " + data.PrimaryContractor + " <br /><b>City:</b> " + data.City + " <br /><b>State:</b> " + data.State + " <br /><b>Phone:</b> " + data.Phone + " <br /><b>Problem:</b> " + data.JobDescription;

            //title = title.replace("'", "");//Used to replace just one quote char(i.e. first) that caused issue on SP.
            title = title.replace(/'/g, "");//Replaces all the chars(i.e. single quotes) and issue is solved on SP now.
            note += "<td>" + notes[i].Id + "</td>";
            note += "<td>" + notes[i].StoreLocationName + "</td>";
            note += "<td>" + dat + "</td>";
            note += "<td>" + notes[i].City + "</td>";
            note += "<td> <span  class='htmlSection2'  title='" + notes[i].JobDescription + "'>" + notes[i].JobDescription.substring(0, 20) + "</span></td>";
            note += "<td>" + notes[i].PrimaryContractor + "</td>";
            note += "</tr>";
        }
    }
    else {
        note += "<tr><td colspan='6'><h6 style='color:#d33838;'>No History for This Technician exists.</h6></td></tr>";
    }
    note += "</table>";

    $('#' + id).parent().find('#TechnicianDailyActivityBody').html(note);

    //$('.htmlSection2').tooltip({
    //    content: function () {
    //        return this.getAttribute("title");
    //    },
    //});
}
function PopulateContractorReconciledJob(contractorId) {
    console.log("In PopulateReconciledContractorHistoryTable");

    var note = "<table class='table table-advance'>";
    note += "<thead><tr>";
    note += "<th>Id</th>";
    note += "<th>Store</th>";
    note += "<th>City</th>";
    note += "<th>Description</th>";
    note += "<th>Payable - Markup</th>";
    note += "</tr></thead><tbody>";
    //
    var request = { cId: contractorId };
    $.ajax({
        type: "POST",
        data: JSON.stringify(request),
        url: baseURL + "Home/GetContractorRecociledJob",
        contentType: "application/json; charset=utf-8",
        global: false,
        success: function (msg) {

            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                if (data.jobs.length > 0) {
                    for (var i = 0; i < data.jobs.length; i++) {
                        notes = data.jobs[i];

                        var title = "<b>ID:</b> " + notes.Id + " <br /><b>Time:</b> " + notes.ExpectedDateTime + " <br /><b>Customer Name:</b> " + notes.CustomerName;
                        title += " <br /><b>Store:</b> " + notes.StoreLocationName + " <br /><b>Primary Contractor:</b> " + notes.PrimaryContractor +
                            " <br /><b>City:</b> " + notes.City + " <br /><b>State:</b> " + notes.State + " <br /><b>Phone:</b> " + notes.Phone + " <br /><b>Problem:</b> " + notes.JobDescription;
                        //title = title.replace("'", "");//Used to replace just one quote char(i.e. first) that caused issue on SP.
                        title = title.replace(/'/g, "");//Replaces all the chars(i.e. single quotes) and issue is solved on SP now.
                        note += "<tr title = '" + title + "' class='htmlSection3'>";
                        note += "<td style='color:" + notes.FontColor + "; background-color:" + notes.BackgroundColor +
                            ";'><span  class='htmlSection3'>" + notes.Id + "</span></td>";
                        note += "<td>" + notes.StoreLocationName + "</td>";
                        note += "<td>" + notes.City + "</td>";
                        note += "<td>" + notes.JobDescription.substring(0, 60) + "</td>";
                        note += "<td>" + "$" + notes.ReceiptTotal + " - $" + notes.InvoiceTotal + "</td>";
                        note += "</tr>";
                    }
                }
                else {
                    note += "<tr><td colspan='100%'><h4 style='color:red;'>No Record Found</h4></td></tr>";
                }
                note += "</tbody></table>";

                $('.ContractorReconciledJob').html("");
                $('.ContractorReconciledJob').html(note);
                $('.htmlSection3').tooltip({
                    content: function () {
                        return this.getAttribute("title");
                    }
                });
            }
            else {
                note += "<tr><td colspan='6'><h4 style='color:red;'>No Reconciled jobs for This Contractor exists.</h4></td></tr>";
                note += "</table>";

                $('.ContractorReconciledJob').html("");
                $('.ContractorReconciledJob').html(note);
            }
        }
    });
}


function GetContractorRatingsHTMLByRating(averageRatings) {
    console.log("In GetContractorRatingsHTMLByRating");

    var star1 = "<img src='images/whitestar1.png' alt='' />   ";
    var star2 = "<img src='images/whitestar1.png' alt='' />   ";
    var star3 = "<img src='images/whitestar1.png' alt='' />  ";
    var star4 = "<img src='images/whitestar1.png' alt='' />   ";
    var star5 = "<img src='images/whitestar1.png' alt='' />  ";
    if (averageRatings > 0 && averageRatings < 1.5) {

        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
    }
    else if (averageRatings >= 1.5 && averageRatings < 2) {

        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
        star2 = "<img src='images/half-star.png' alt='' />   ";
    }
    else if (averageRatings >= 2 && averageRatings < 2.5) {
        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
        star2 = "<img src='images/yellowstar1.png' alt='' />   ";

    }
    else if (averageRatings >= 2.5 && averageRatings < 3) {
        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
        star2 = "<img src='images/yellowstar1.png' alt='' />   ";
        star3 = "<img src='images/half-star.png' alt='' />   ";

    }
    else if (averageRatings >= 3 && averageRatings < 3.5) {
        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
        star2 = "<img src='images/yellowstar1.png' alt='' />   ";
        star3 = "<img src='images/yellowstar1.png' alt='' />   ";
    }

    else if (averageRatings >= 3.5 && averageRatings < 4) {
        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
        star2 = "<img src='images/yellowstar1.png' alt='' />   ";
        star3 = "<img src='images/yellowstar1.png' alt='' />   ";
        star4 = "<img src='images/half-star.png' alt='' />   ";

    }
    else if (averageRatings >= 4 && averageRatings < 4.5) {
        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
        star2 = "<img src='images/yellowstar1.png' alt='' />   ";
        star3 = "<img src='images/yellowstar1.png' alt='' />   ";
        star4 = "<img src='images/yellowstar1.png' alt='' />   ";

    }
    else if (averageRatings >= 4.5 && averageRatings < 4.8) {
        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
        star2 = "<img src='images/yellowstar1.png' alt='' />   ";
        star3 = "<img src='images/yellowstar1.png' alt='' />   ";
        star4 = "<img src='images/yellowstar1.png' alt='' />   ";
        star5 = "<img src='images/half-star.png' alt='' />   ";

    }
    else if (averageRatings > 4.8) {
        star1 = "<img src='images/yellowstar1.png' alt='' />   ";
        star2 = "<img src='images/yellowstar1.png' alt='' />   ";
        star3 = "<img src='images/yellowstar1.png' alt='' />   ";
        star4 = "<img src='images/yellowstar1.png' alt='' />   ";
        star5 = "<img src='images/yellowstar1.png' alt='' />   ";
    }
    return star1 + star2 + star3 + star4 + star5;
}


//****************** Contractor rating functions****************************//
var clickedFlag = false;
var rating;
$("#ratingDiv img").click( function () {
    if ($(this).attr("src", baseURL + "Images/big-yellow.png")) {
        $("#ratingDiv img").attr("src", baseURL + "Images/big-white.png");
    }

    $(this).attr("src", baseURL + "Images/big-yellow.png").prevAll("#ratingDiv img").attr("src", baseURL + "Images/big-yellow.png");
    rating = $(this).attr("data-value");
});
//var clickedFlag = false;
//$("#ratingDiv img").live('mouseover', function () {
//    if ($(this).attr("src", baseURL + "Images/big-yellow.png")) {
//        $("#ratingDiv img").attr("src", baseURL + "Images/big-white.png");
//    }
//    $(this).attr("src", baseURL + "Images/big-yellow.png").prevAll("#ratingDiv img").attr("src", baseURL + "Images/big-yellow.png");
//});
//$("#ratingDiv img").live('mouseout', function () {

//});

//$(".ratingStars").live('click', function () {
//    var ContractorId = $(this).parent().attr('class');
//    clickedFlag = true;
//    $("Stars").unbind("mouseout mouseover click").css("cursor", "default");

//    var rating = $(this).attr("data-value");
//    var request = { ratingstars: rating, contractorId: ContractorId }
//    $.ajax({
//        type: "POST",
//        contentType: "application/json, charset=utf-8",
//        url: baseURL + "Contractor/ContractorRating",
//        data: JSON.stringify(request),
//        success: function (msg) {
//            Notify("Contractor Rated Successfully!", 'success');
//            $('#ContractorRatingDiv').dialog('close');
//            //SelectJob($('#CallSlipId').val());
//            GetContractorsByJobId();
//        }
//    });
//});
$("#loadPreviousRatings").mouseover( function () {
    this.style.color = "#2fade7";
    this.style.cursor = "pointer";
});
$("#loadPreviousRatings").mouseover( function () {
    this.style.color = "black";
});


function ratingStar() {
    var ContractorId = $('.ratingStars').parent().attr('class');
    var RatingNotes = $('#ratingNotes').val();
    clickedFlag = true;
    //$("Stars").unbind("mouseout mouseover click").css("cursor", "default");

    //var rating = $('.ratingStars').attr("data-value");
    var request = { ratingstars: rating, contractorId: ContractorId, RatingNotes }
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Contractor/ContractorRating",
        data: JSON.stringify(request),
        success: function (msg) {
            Notify("Contractor Rated Successfully!", 'success');
            $('#ContractorRatingDiv').dialog('close');
            //SelectJob($('#CallSlipId').val());
            GetContractorsByJobId();
        }
    });
}
function previousratings() {

    if ($('#previousRatings').css('display') === 'none') {
        $('#previousRatings').show();
    }
    else {
        $('#previousRatings').hide();
    }


}




function ratingDiv(ContractorId) {
    var request = { contractorId: ContractorId };

    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Contractor/ContractorPreviousRatings",
        data: JSON.stringify(request),
        success: function (msg) {

            var contractors = "<h3 style = 'align:center;'>Rate This Contractor</h3>";
            contractors += " <div id='ratingDiv' class='" + ContractorId + "'   style ='width:99%;margin-top:5px; text-align:center;'>" +
                "<img src='images/big-white.png' data-alt-src = 'images/big-white.png' alt='' class='ratingStars' data-value='1'   /><img src='images/big-white.png' alt='' class='ratingStars' data-value='2' /><img src='images/big-white.png' alt='' class='ratingStars' data-value='3' /><img src='images/big-white.png' alt='' class='ratingStars' data-value='4' /><img src='images/big-white.png' alt='' class='ratingStars' data-value='5' />";
            contractors += "</div>";
            contractors += "<h3 style = 'align:center;'>Notes</h3>";
            contractors += "<textarea id='ratingNotes' name='RatingNotes' style='height: 35px; width: 85%; margin-left: 5%; margin-right: 5%;' class=''></textarea>";
            contractors += "<div id='loadPreviousRatings' onclick='previousratings();'><h3>Previous Ratings</h3></div>";
            contractors += "<div id='previousRatings' style='display:none;'>";
            contractors += "<table class='table table-advance' style='width: 100%; height:15%;'>";
            contractors += "<thead><tr>";
            contractors += "<th><b>Username</b></th>";
            contractors += "<th><b>Rating</b></th>";
            contractors += "<th><b>Date</b></th>";
            contractors += "</tr></thead>";
            contractors += "<tbody>";


            (msg.data).forEach(function (item) {
                contractors += "<tr>";
                contractors += "<td>" + item.Username + "</td>";
                contractors += "<td>" + item.Ratings + "</td>";
                contractors += "<td>" + item.date + "</td>";
                contractors += "</tr>";


                //contractors += "<div>'" + item.Username + "' &nbsp;&nbsp; '" + item.Ratings + "' ";
            })
            contractors += "</tbody></table>";

            contractors += "</div>";


            //var note = "<table class='table table-advance' style='width: 100.1%;'>";
            //note += "<thead><tr>";
            //note += "<th>Id</th>";
            //note += "<th>Expected Date</th>";
            ////note += "<th>City</th>";
            //note += "<th>Description</th>";
            //note += "<th>Primary Contractor</th>";
            //note += "<th>Amt Paid</th>";
            //note += "</tr></thead>";

            //if (notes.length > 0) {
            //    for (var i = 0; i < notes.length; i++) {
            //        var data = notes[i];

            //        var title = "<b>ID:</b> " + data.Id + " <br /><b>Time:</b> " + data.ExpectedDateTime + " <br /><b>Customer Name:</b> " + data.CustomerName;
            //        title += "<br /><b>Store:</b> " + data.StoreLocationName + "<br /><b>Primary Contractor:</b>" + data.PrimaryContractor +
            //            "<br /><b>Amt Paid:</b> " + data.ReceiptTotal + " <br /> <br /><b>State:</b> " + data.State + " <br /><b>Phone:</b> " + data.Phone + " <br /><b>Problem:</b> " + data.JobDescription;
            //        //" <br /><b>City:</b> " + data.City + " <br /><b>State:</b> " + data.State + " <br /><b>Phone:</b> " + data.Phone + " <br /><b>Problem:</b> " + data.JobDescription;
            //        //title = title.replace("'", "");//Used to replace just one quote char(i.e. first) that caused issue on SP.
            //        title = title.replace(/'/g, "");//Replaces all the chars(i.e. single quotes) and issue is solved on SP now.
            //        title = title.replace(/"/g, "");
            //        note += '<tr  title="' + title + '" class="htmlSection1">';
            //        note += "<td  style='color:" + notes[i].FontColor + "; background-color:" + notes[i].BackgroundColor +
            //            ";'><span  class='htmlSection1'  title='" + notes[i].JobStatus + "'><span style='cursor: pointer;' id = '" + notes[i].Id + "' " +
            //            "onclick = 'LocHistoryPopUp(" + notes[i].Id + ");'>" + notes[i].Id + "</span></td>";
            //        note += "<td>" + notes[i].ExpectedDateTime + "</td>";
            //        //note += "<td>" + notes[i].City + "</td>";

            //        note += "<td> <span  class='htmlSection1'  title='" + notes[i].JobDescription + "'>" + notes[i].JobDescription.substring(0, 20) + "</span></td>";
            //        note += "<td>" + (notes[i].PrimaryContractor != null ? notes[i].PrimaryContractor : "") + "</td>";
            //        note += "<td>" + notes[i].ReceiptTotal + "</td>";
            //        note += "</tr>";
            //    }
            //} else {
            //    note += "<tr><td colspan='5'><h4 style='color:red;'>No Location History for This Job exists.</h4></td></tr>";
            //}
            //note += "</table>";
            //$('#StoreAcitivityContainer').html(note);
            //$('#StoreAcitivityContainer').show();




            //contractors += "<div id='previousRatings' 

            $('#ContractorRatingDiv').html(contractors);

            $('#ContractorRatingDiv').dialog({
                title: 'Contractor Ratings',
                resizable: true,
                width: '400px',
                modal: false,
                position: ['left', 'top'],
                buttons: [
                    {
                        text: "Save",
                        id: "btnSaveRating",
                        click: function () {

                            ratingStar();

                        }
                    },
                    {
                        text: "Close",
                        id: "btnCancel",
                        click: function () {
                            $(this).dialog("destroy");
                        }
                    }
                ],
                close: function (event, ui) {
                    $(this).dialog('destroy');
                    primaryContractorId = "";
                }
            });
        }
    });



}


$('#btnSaveContractorNTEInfo').click(function (e) {
    var isValid = false;
    console.log(" In btnSaveContractorNTEInfo");
    var selectedVal = "";
    var selected = $("#contractorinfodiv input[type='radio']:checked");
    if (selected.length > 0) {
        selectedVal = selected.val();
        if (selectedVal == 'Other') {
            selectedVal = $('#txtNTEOtherEta').val();
        }
    }

    var jobNte = $("#NotExceedAmount").val();
    var nte = $('.ContractorInfoNTEAmount').val();
    var newEmail = $('.MainEmailAddress').val();
    //var billingEst = $('.ContractorBillingEstimate').val();
    var billingEst = ($($(".ContractorBillingEstimate")[0]).val() != null) ? $($(".ContractorBillingEstimate")[0]).val() : $($(".ContractorBillingEstimate")[1]).val();

    var errorMessage = "";

    if (selectedVal == "") {
        Notify("Please Select ETA For Contractor", 'error');
    }
    else if (!($(".chkIsWarrantyJob").is(":checked")) && billingEst == "") {
        Notify("Please enter Billing Estimate", 'error');
    }
    else if (!($(".chkIsWarrantyJob").is(":checked")) && nte == "") {
        Notify("Please enter NTE Amount", 'error');
    }
    else {
        if ($('.paymentMethod').val() == 0) {
            isValid = false;
            errorStyle('.paymentMethod');
            //$('#paymentMethod').css('border', '1px solid red');
        }
        else {
            isValid = true;
        }
        if (isValid == true) {
            removerErrorStyle('.paymentMethod');
            //$('#paymentMethod').css('border', '1px solid black');

            if (jobNte != null && jobNte != "" && nte != null && nte != "") {
                var twentyPercentOfJobNte = 0.2 * parseFloat(jobNte);
                var eightyPercentOfJobNte = parseFloat(jobNte) - twentyPercentOfJobNte;
                var saveNotes = false;
                if (parseFloat(nte) > parseFloat(jobNte)) {
                    //var errorMessage = "The Contractor’s NTE amount exceeds the corporate NTE amount of " + jobNte + ". Please get a bump from Corporate or proceed with caution.";
                    var errorMessage = "You exceeded the Customer's NTE.";
                    saveNotes = true;
                    contNTEGreaterThenCustNTE(e, selectedVal, errorMessage, saveNotes);
                }
                else
                    if (parseFloat(nte) > eightyPercentOfJobNte && parseFloat(nte) <= parseFloat(jobNte)) {
                        //var errorMessage = "Be advised that the Contractor's NTE exceeds the Customer's NTE.";
                        var errorMessage = "You are close to the Customer's NTE.";

                        contNTEGreaterThenCustNTE(e, selectedVal, errorMessage, saveNotes);
                    }
                    else {
                        saveAndDispatch(e, selectedVal);
                    }
            }
            else {
                saveAndDispatch(e, selectedVal);
            }
        }


    }

});

//-------------------------when contractor NTE amount is greater then Customer Nte ------------------------------------
function contNTEGreaterThenCustNTE(e, selectedVal, errorMessage, saveNotes) {

    $("#errorDivNTE").html(errorMessage);
    $("#errorDivNTE").dialog({
        title: "Warning",
        resizable: false,
        width: 300,
        height: 150,
        buttons: [{
            text: "Ok",
            id: "btnNTEOkay",
            modal: true,
            click: function () {
                saveAndDispatch(e, selectedVal);
                if (saveNotes == true) {
                    var message = "<p style='color:red;'> Contractor's NTE exceeded the Customer's NTE.</p>"
                    saveContNteGreaterThenJobNotes(message);
                }
                $(this).dialog('close');
            }
        },
        {
            text: "Cancel",
            id: "btnNTECancel",
            click: function () {
                $(this).dialog('close');
            }
        }

        ],
        close: function (event, ui) {
            $(this).dialog('destroy');
        },
        open: function (event, ui) {
            StyleWarningDiagle($(this));
            $("#btnNTEOkay").removeAttr('class');
            $("#btnNTECancel").removeAttr('class');
            $("#btnNTEOkay").addClass("btn btn-primary btn-large");
            $("#btnNTECancel").addClass("btn btn-danger btn-large");
        }
    });
}


//-------------------------save notes when contractor NTE amount is greater then Customer Nte while dispatching a job and while crating tech summary ------------------------------------
function saveContNteGreaterThenJobNotes(message) {
    var request = { jobId: $('#CallSlipId').val(), message: message, RelatedToInvoice: false };
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: baseURL + "BaseALS/SaveJobNotes",
        data: JSON.stringify(request),
        dataType: "json",
        success: function (msg) {
        },
        error: function () {
            CommunicationError();
        }
    });
}

function saveAndDispatch(e, selectedVal) {
    var TripCharges = parseFloat($('#NTETechTripCharges').val());
    var LaborCharges = parseFloat($('#NTETechLaborCharges').val());
    var PartsCharges = parseFloat($('#NTETechPartsCharges').val());
    var KeysCharges = parseFloat($('#NTETechKeysCharges').val());
    var Other1Charges = parseFloat($('#NTETechOther1Charges').val());
    var Other2Charges = parseFloat($('#NTETechOther2Charges').val());
    var Other3Charges = parseFloat($('#NTETechOther3Charges').val());
    var Other4Charges = parseFloat($('#NTETechOther4Charges').val());
    var txtOther1Charges = $('#txtNteOther1').val();
    var txtOther2Charges = $('#txtNteOther2').val();
    var txtOther3Charges = $('#txtNteOther3').val();
    var txtTripCharges = $('#txtNteTrip').val();
    var txtLaborCharges = $('#txtNteLabor').val();
    var txtPartsCharges = $('#txtNteParts').val();
    var txtKeyscharges = $('#txtNteKeys').val();
    var totalTechCharges = $('#NTETechTotalCharges').val();
    var notes = "";
    if (!isNaN(totalTechCharges) && totalTechCharges != 0) {
        notes += "  <b>Total-: " + totalTechCharges + "</b>==> ";
    }
    if (!isNaN(TripCharges) && TripCharges != 0) {
        notes += txtTripCharges + "-" + TripCharges + ", ";
    }
    if (!isNaN(LaborCharges) && LaborCharges != 0) {
        notes += txtLaborCharges + "-" + LaborCharges + ", ";
    }
    if (!isNaN(PartsCharges) && PartsCharges != 0) {
        notes += txtPartsCharges + "-" + PartsCharges + ", ";
    }
    if (!isNaN(KeysCharges) && KeysCharges != 0) {
        notes += txtKeyscharges + "-" + KeysCharges + ", ";
    }
    if (!isNaN(Other1Charges) && Other1Charges != 0) {
        notes += txtOther1Charges + "-" + Other1Charges + ", ";
    }
    if (!isNaN(Other2Charges) && Other2Charges != 0) {
        notes += txtOther2Charges + "-" + Other2Charges + ", ";
    }
    if (!isNaN(Other3Charges) && Other3Charges != 0) {
        notes += txtOther3Charges + "-" + Other3Charges + ", ";
    }
    //e.preventDefault();
    console.log("In saveAndDispatch");
    var request;
    if ($('#panel1').is(":visible")) {

        request = {
            Id: $("#hdnContractorId").val(),
            DefaultNTEAmount: $($(".cDefaultNTEAmount")[0]).val().replace("$", "").trim(),
            CommissionRate: $($(".cCommissionRate")[0]).val().replace("%", "").trim(),
            CreatedOn: $('#cHiringDate').val(),
            MainEmailAddress: $($('.MainEmailAddress')[0]).val(),
            MainCompanyPhone: $($(".MainCompanyPhone")[0]).val(),
            BusinessName: $($(".cBusinessName")[0]).val(),
            FirstName: $($(".cFirstName")[0]).val(),
            LastName: $($(".cLastName")[0]).val(),
            MainCompanyFax: $($(".MainCompanyFax")[0]).val(),
            Source: $('#ContractorSource').val(),
            AccountingContact: $('#AccountingContact').val(),
            MainAccountingEmailAddress: $('#MainAccountingEmailAddress').val(),
            CorporateAddress1: $('#cAddress').val(),
            LicenseNumber: $($(".cLicenseNumber")[0]).val(),
            ServiceCallCharges: $($(".ServiceCall")[0]).val().replace("$", "").trim(),
            HourlyLaborRate: $($(".HourlyLabor")[0]).val().replace("$", "").trim(),
            RekeyCharges: $($(".Rekey")[0]).val().replace("$", "").trim(),
            DuplicatesCharges: $($(".Duplicates")[0]).val().replace("$", "").trim(),
            AfterHoursCharges: $($(".AfterHoursEmergencyServiceCall")[0]).val().replace("$", "").trim(),
            AfterHoursLaborRate: $($(".AfterHourEmergencyLaborRate")[0]).val().replace("$", "").trim(),
            AfterHoursAlternatePhone: $($(".AfterHoursAlternatePhone")[0]).val(),
            TripCharges: $($(".TripCharges")[0]).val().replace("$", "").trim(),
            LaborCharges: $($(".LaborCharges")[0]).val().replace("$", "").trim(),
            Active: $('.cActive').is(':checked'),
            //Commissioned: $('#cCommissioned').is(':checked'),
            PreferedCommunicationMethod: $($(".BestMethodOfCommunication")[0]).val(),
            CallSlipId: $('#CallSlipId').val(),
            ExtraCommission: $($(".ContractorInfoExtraCommission")[0]).val(),
            ConctractorNTEAmount: $($(".ContractorInfoNTEAmount")[0]).val(),
            JobContractorETA: selectedVal,
            PaymentPreference: $($(".paymentMethod")[0]).val(),
            //ContactPerson: $(".ContractorContactPerson").val()
            ContactPerson: $($(".ContractorContactPerson")[0]).val(),
            Type: true,
            BillingEstimate: $($(".ContractorBillingEstimate")[0]).val()

        };
    }
    else if ($('#panel2').is(":visible")) {

        request = {
            Id: $("#hdnContractorId").val(),
            DefaultNTEAmount: $($(".cDefaultNTEAmount")[1]).val().replace("$", "").trim(),
            CommissionRate: $($(".cCommissionRate")[1]).val().replace("%", "").trim(),
            CreatedOn: $('#cHiringDate').val(),
            MainEmailAddress: $($(".MainEmailAddress")[1]).val(),
            MainCompanyPhone: $($(".MainCompanyPhone")[1]).val(),
            BusinessName: $($(".cBusinessName")[1]).val(),
            FirstName: $($(".cFirstName")[1]).val(),
            LastName: $($(".cLastName")[1]).val(),
            MainCompanyFax: $($(".MainCompanyFax")[1]).val(),
            Source: $('#ContractorSource').val(),
            AccountingContact: $('#AccountingContact').val(),
            MainAccountingEmailAddress: $('#MainAccountingEmailAddress').val(),
            CorporateAddress1: $('#cAddress').val(),
            LicenseNumber: $($(".cLicenseNumber")[1]).val(),
            ServiceCallCharges: $($(".ServiceCall")[1]).val().replace("$", "").trim(),
            HourlyLaborRate: $($(".HourlyLabor")[1]).val().replace("$", "").trim(),
            RekeyCharges: $($(".Rekey")[1]).val().replace("$", "").trim(),
            DuplicatesCharges: $($(".Duplicates")[1]).val().replace("$", "").trim(),
            AfterHoursCharges: $($(".AfterHoursEmergencyServiceCall")[1]).val().replace("$", "").trim(),
            AfterHoursLaborRate: $($(".AfterHourEmergencyLaborRate")[1]).val().replace("$", "").trim(),
            AfterHoursAlternatePhone: $($(".AfterHoursAlternatePhone")[1]).val(),
            TripCharges: $($(".TripCharges")[1]).val().replace("$", "").trim(),
            LaborCharges: $($(".LaborCharges")[1]).val().replace("$", "").trim(),
            Active: $('.cActive').is(':checked'),
            //Commissioned: $('#cCommissioned').is(':checked'),
            PreferedCommunicationMethod: $($(".BestMethodOfCommunication")[1]).val(),
            CallSlipId: $('#CallSlipId').val(),
            ExtraCommission: $($(".ContractorInfoExtraCommission")[1]).val(),
            ConctractorNTEAmount: $($(".ContractorInfoNTEAmount")[1]).val(),
            JobContractorETA: selectedVal,
            PaymentPreference: $($(".paymentMethod")[1]).val(),
            //ContactPerson: $(".ContractorContactPerson").val()
            ContactPerson: $($(".ContractorContactPerson")[1]).val(),
            Type: false,
            BillingEstimate: $($(".ContractorBillingEstimate")[0]).val()
        };
    }


    $.ajax({
        type: "POST",
        url: baseURL + "Contractor/UpdateContractorFromDispatchScreen",
        data: JSON.stringify({ 'model': request }),
        contentType: "application/json, charset=utf-8",
        dataType: "json",
        //async: false,
        success: function (msg) {
            console.log("UpdateContractorNTEInfo :success");
            PopulateETAOnNotes();
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                if ($('#IsDispatch').val() == "true") {
                    //e.preventDefault();
                    $("#CommissionPopup").dialog("close");
                    openNewWindow();
                }
                else {

                    Notify("Contractor NTE Amount Updated!", 'success');
                    //SelectJob($("#CallSlipId").val());
                }

            } else {
                Notify(data.message, 'error');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            $('#result').html('<p>status code: ' + jqXHR.status + '</p><p>errorThrown: ' + errorThrown + '</p><p>jqXHR.responseText:</p><div>' + jqXHR.responseText + '</div>');
            console.log('jqXHR:');
            console.log(jqXHR);
            console.log('textStatus:');
            console.log(textStatus);
            console.log('errorThrown:');
            console.log(errorThrown);
        },
        complete: function () {
            //if ($("#chkIsWarrantyJob").is(":checked")) {
            UpdateJobContrMapping();
            //}
            //SelectJob($("#CallSlipId").val());
            GetContractorsByJobId();
            GetNotesByJobId();
        }
    });
}

function UpdateJobContrMapping() {


    //var estimate = $('.ContractorBillingEstimate').val();
    var estimate = ($($(".ContractorBillingEstimate")[0]).val() != null) ? $($(".ContractorBillingEstimate")[1]).val() : $($(".ContractorBillingEstimate")[0]).val();
    var jobMargin = $('.JobMargin').text();
    jobMargin = jobMargin.split('%')[0];
    var conId = $("#hdnContractorId").val();
    var CallSlipId = $('#CallSlipId').val();

    if (!isNaN(estimate) && estimate != '' && !isNaN(jobMargin) && jobMargin != '') {
        var request = { JobId: CallSlipId, ContractorId: conId, BillingEstimate: estimate, JobMargin: jobMargin };

        $.ajax({
            type: "POST",
            url: baseURL + "Home/UpdateJobContractorEstimates",
            data: JSON.stringify(request),
            contentType: "application/json, charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                } else
                    data = msg;
                if (data.success) {
                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
            },
            complete: function () {
                ShowJobMargin();
            }
        });
    }

    if ($('#WarrantyStateChanged').val() == "1") {
        UpdateWarrantyCheck();
    }
}


///FUNCTION TO POUPOLATE ON NOTES When DISPATCHING JOB
function PopulateETAOnNotes() {
    console.log(" In PopulateETAOnNotes");
    var selectedVal = "";
    var selected = $("#contractorinfodiv input[type='radio']:checked");
    if (selected.length > 0) {
        selectedVal = selected.val();
        if (selectedVal == 'Other') {
            selectedVal = $('#txtNTEOtherEta').val();
        }
    }
    var TripCharges = parseFloat($('#NTETechTripCharges').val());
    var LaborCharges = parseFloat($('#NTETechLaborCharges').val());
    var PartsCharges = parseFloat($('#NTETechPartsCharges').val());
    var KeysCharges = parseFloat($('#NTETechKeysCharges').val());
    var Other1Charges = parseFloat($('#NTETechOther1Charges').val());
    var Other2Charges = parseFloat($('#NTETechOther2Charges').val());
    var Other3Charges = parseFloat($('#NTETechOther3Charges').val());
    var Other4Charges = parseFloat($('#NTETechOther4Charges').val());
    var txtOther1Charges = $('#txtNteOther1').val();
    var txtOther2Charges = $('#txtNteOther2').val();
    var txtOther3Charges = $('#txtNteOther3').val();
    var txtOther4Charges = $('#txtNteOther4').val();
    var txtTripCharges = $('#txtNteTrip').val();
    var txtLaborCharges = $('#txtNteLabor').val();
    var txtPartsCharges = $('#txtNteParts').val();
    var txtKeyscharges = $('#txtNteKeys').val();
    //var TaxCharges = parseFloat($('#TechTaxCharges').val());
    var totalTechCharges = $('#NTETechTotalCharges').val();
    var notes = "";
    if (!isNaN(totalTechCharges) && totalTechCharges != 0) {
        notes += "  <b>Total-: " + totalTechCharges + "</b>==> ";
    }
    if (!isNaN(TripCharges) && TripCharges != 0) {
        notes += txtTripCharges + "-" + TripCharges + ", ";
    }
    if (!isNaN(LaborCharges) && LaborCharges != 0) {
        notes += txtLaborCharges + "-" + LaborCharges + ", ";
    }
    if (!isNaN(PartsCharges) && PartsCharges != 0) {
        notes += txtPartsCharges + "-" + PartsCharges + ", ";
    }
    if (!isNaN(KeysCharges) && KeysCharges != 0) {
        notes += txtKeyscharges + "-" + KeysCharges + ", ";
    }
    if (!isNaN(Other1Charges) && Other1Charges != 0) {
        notes += txtOther1Charges + "-" + Other1Charges + ", ";
    }
    if (!isNaN(Other2Charges) && Other2Charges != 0) {
        notes += txtOther2Charges + "-" + Other2Charges + ", ";
    }
    if (!isNaN(Other3Charges) && Other3Charges != 0) {
        notes += txtOther3Charges + "-" + Other3Charges + ", ";
    }
    if (!isNaN(Other4Charges) && Other4Charges != 0) {
        notes += txtOther4Charges + "-" + Other4Charges + ", ";
    }

    var request = {
        CallSlipId: $('#CallSlipId').val(),
        ContractorId: $('#hdnContractorId').val(),
        RelatedToInvoice: false,
        SelectedValue: selectedVal,
        TechSummary: notes,
        type: "Nte Information",
        Notes: notes,
        Other1: $('#txtNteOther1').val(), Other2: $('#txtNteOther2').val(), Other3: $('#txtNteOther3').val(), Other4: $('#txtNteOther4').val(),
        TechTripCharges: $('#NTETechTripCharges').val(), TechLaborCharges: $('#NTETechLaborCharges').val(), TechPartsCharges: $('#NTETechPartsCharges').val(),
        TechKeysCharges: $('#NTETechKeysCharges').val(),
        TechOther1Charges: $('#NTETechOther1Charges').val(), TechOther2Charges: $('#NTETechOther2Charges').val(), TechOther3Charges: $('#NTETechOther3Charges').val(),
        TechOther4Charges: $('#NTETechOther4Charges').val()
    };

    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/insertNTESummary",
        data: JSON.stringify(request)
    });

}
function openNewWindow() {

    DispatchUrl = getBaseUrl() + "/Home/CreateWorkorderSignOff/" + "?CallSlipId=" + $("#CallSlipId").val() + "&ConractorId=" + $("#hdnContractorId").val();
    if (DispatchUrl.includes("Home/Home/")) {
        DispatchUrl = getBaseUrl() + "/CreateWorkorderSignOff/" + "?CallSlipId=" + $("#CallSlipId").val() + "&ConractorId=" + $("#hdnContractorId").val();
    }
    console.log("url:" + DispatchUrl);
    window.open(DispatchUrl, '_blank');
    //SelectJob($("#CallSlipId").val());
}

function openServicePanel(JobId) {

    DispatchUrl = getBaseUrl() + "/Home/ServicePanel/" + "?CallSlipId=" + JobId;
    console.log("url:" + DispatchUrl);
    window.open(DispatchUrl, '_blank');

}

//$('#btnCustomerWebAddress').click(function () {
$('#btnSendEmailOnCustomerUpdateDialog').click(function () {

    UpdateNotificationEmail();
    sendEmail();
});

function sendEmail() {
    var request = {
        CallSlipId: $('#CallSlipId').val()
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/SendEmailOnCustomerUpdateDialog",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                Notify(data.message, 'success');
                GetEmailsLogsByCustomerId();
                GetProgressBarDetailsByJobId();
                GetNotesByJobId();
                //refreshCallsGrid(0);
                //SelectJob(data.JobId);
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
    $('#CustomerUpdateDialog').dialog("destroy");
}

//$('#btnShowEmail').click(function () {
//    showEmailDialog();
//});

$('#btnUpdateCustomer').click(function () {
    showUpdateCustomerPopupOrPortal();
});

function showUpdateCustomerPopupOrPortal(emailBody) {
    if (hasWebAddress == "true") {
        showWebAddressDialog();
    }
    else {
        showCustomerUpdateMsgBox(emailBody);
    }
}

function showWebAddressDialog() {

    var request = { CallslipId: $('#CallSlipId').val() }
    $.ajax({
        type: "POST",
        data: JSON.stringify(request),
        url: baseURL + "Home/CustomerWebAddressInfo",
        contentType: "application/json; charset=utf-8",
        global: false,
        success: function (msg) {

            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                $('#ViewCustomerWebAddresses').dialog({
                    title: 'Customer Web Address',
                    resizable: true,
                    width: '450px',
                    height: 'auto',
                    modal: false,
                    position: ['left', 'top'],
                    buttons: [{
                        text: "Close",
                        id: "btnCancel",
                        click: function () {
                            $(this).dialog("destroy");
                            isFromProgressBar = false;
                            updateInEmail = false;
                        }
                    }],
                    open: function (event, ui) {
                        if (data.model.WebAddressFound) {
                            $('#CustomerWebAddressTitle').html(data.model.Title);
                            $('#CustomerWebAddressUserName').html(data.model.UserName);
                            $('#CustomerWebAddressPassword').html(data.model.Password);
                            $('#lblCustomerWebAddress').html(data.model.WebAddress);
                            $("#CustomerWebAddress").attr("target", "_blank");
                            $("#CustomerWebAddress").attr("href", data.model.WebAddress);
                            $('.PortalInfo').show();
                            $('.PortalMessage').hide();
                        } else {
                            $('.PortalInfo').hide();
                            $('.PortalMessage').show();
                        }
                    },
                    close: function (event, ui) {
                        $(this).dialog('destroy');
                        primaryContractorId = "";
                        isFromProgressBar = false;
                        updateInEmail = false;
                    },
                });

            }

        }, error: function () {
            CommunicationError();
        }

    });
}

$("#CustomerWebAddress").click(function () {
    if (isFromProgressBar) {
        if ($('#progressStatus').val() != '' && listElement != null && $('#UpdateType').val() != '') {
            if ($('#UpdateType').val() == 'p') {
                ToggleCustomerUpdate(listElement, false, $('#UpdateType').val());
            }
            else if ($('#UpdateType').val() == 'pe') {
                LogPortalUpdate($('#progressStatus').val());
                updateInEmail = true;
                showCustomerUpdateMsgBox();
            }
        }
    }
});


//******************************************** Function to create job note when selecting contratcor radio button from service panel ****************************************************//
function CreateJobNotes() {

    $("#CreateJobNoteDiv input[type='radio']:checked").each(function (i) {
        this.checked = false;
    });
    $('#CreateJobNoteDiv').dialog({
        title: 'Create Job Note',
        width: 600,
        resizeable: true,
        modal: false,
        buttons: [{
            text: "Save",
            id: "btnSaveJobNotes",
            click: function () {

                console.log(" In btnSaveJobNotes");
                var selectedVal = "";
                var selected = $("#CreateJobNoteDiv input[type='radio']:checked");
                if (selected.length > 0) {
                    selectedVal = selected.val();
                    if (selectedVal == 'others') {
                        selectedVal = $('#txtOtherCreateJobNote').val();
                    }
                }
                var request = { ContractorId: $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id"), CallSlipId: $(".Service_tab_CallSlipId").text(), Notes: selectedVal };
                $.ajax({
                    type: "POST",
                    contentType: "application/json, charset=utf-8",
                    url: baseURL + "Home/SaveCreateJobNotes",
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty("d")) {
                            data = msg.d;
                        } else
                            data = msg;
                        if (data.success) {

                            ShowJobNotes();

                        } else {
                            Notify(data.message, 'error');
                        }
                    },
                    error: function () {
                        CommunicationError();
                    }
                });
                $(this).dialog("destroy");
            }
        },
        {
            text: "Close",
            id: "btnCancel",
            click: function () {
                $(this).dialog("destroy");
                //DoAssigningContractors();

            }
        }],
        close: function (event, ui) {
            $(this).dialog('destroy');


        },
        open: function () {
            $('#btnCancel').removeAttr("class");
            $('#btnSaveJobNotes').removeAttr("class");
            $('#btnCancel').addClass("cancel btn btn-danger");
            $('#btnSaveJobNotes').addClass("success btn btn-primary");
            $('#txtOtherCreateJobNote').val("");
        }

    });

}

function CheckIfPayableExists() {

    var request = { JobId: $('#CallSlipId').val(), ContractorId: $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id") };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Contractor/CheckIfPayableCreated",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;

            if (data.success) {

                Notify(data.message, 'error');
            } else {
                payWithCC();
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function payWithCC() {
    var JobState = $('#ServiceTab_State').val();
    var PoMessage = "";
    if (JobState == "7" || JobState == "55") {
        PoMessage = "<p style='margin: 10px 10px 10px 10px; font-size:13px; font-weight: bold;'> Make sure the technician is not charging Sales tax for this job. Academy has a resale certificate for this State. Please talk with the Contractor and have them remove the sales tax before the funding request occurs. </p>";
    }
    else {
        PoMessage = "<p style='margin: 10px 10px 10px 10px; font-size:13px; font-weight: bold;'> Are you sure you want to pay Contractor with a credit card? </p>";
    }
    $('#payWithCCDiv').html(PoMessage);
    $('#payWithCCDiv').dialog({
        title: "Pay with CC",
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Yes',
            id: 'btnOkPOPermission',
            click: function () {
                openPrepaidAmountDialog()
                $(this).dialog('close');
            }

        },
        {
            text: 'No',
            id: 'btnNoPoPermission',
            click: function () {
                $(this).dialog('close');
            }

        }],

        close: function (event, ui) {
            $(this).dialog('destroy');
        },
        open: function () {
            $("#btnOkPOPermission").removeAttr("class");
            $("#btnOkPOPermission").addClass("btn btn-primary btn-large");
            $("#btnNoPoPermission").removeAttr("class");
            $("#btnNoPoPermission").addClass("btn btn-danger btn-large");
        }
    });
}

function openPrepaidAmountDialog() {
    getContractorListPrepaid();
    $('#PayWithCCPrepaidAmountDiv').dialog({
        title: "Prepaid Amount",
        resizable: true,
        width: '500px',
        modal: true,
        open: function () {
            $("#txtPayWithccAmount").val("");
            $("#txtPayWithccTaxAmount").val("");

            var span = $('input[type="radio"][name="contractorForNoticeForm"]:checked').siblings('span:first')[0];
            if (span != undefined && span != null && span.innerHTML == "50") {
                $("#trTaxAmount").hide();
                $("#lblCAJobMsg").hide();
            }
            else if ($("#ServiceTab_State option:selected").text() == "California" || $("#ServiceTab_State option:selected").text() == "Texas") {
                $("#LabelID").empty();
                $("#lblCAJobMsg").hide();

                if ($("#ServiceTab_State option:selected").text() == "California") {
                    $("#lblCAJobMsg").html('**The job is located in California. Academy Locksmith is tax exempt in California. So, our technicians should not be charging us tax. Please insure their invoice does not reflect tax.**');
                }
                else {
                    $("#lblCAJobMsg").html('**The job is located in Texas. Academy Locksmith is tax exempt in Texas. So, our technicians should not be charging us tax. Please insure their invoice does not reflect tax.**');
                }
                $("#lblCAJobMsg").show();
            }
            else {
                $("#trTaxAmount").show();
                $("#lblCAJobMsg").hide();
            }
        }
    });
}

function PaidWithCC() {
    var PoMessage = "<p style='margin: 10px 10px 10px 10px; font-size:13px; font-weight: bold;'> Are you sure? </p>";
    $('#paidDiv').html(PoMessage);
    $('#paidDiv').dialog({
        title: "Pay",
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Yes',
            id: 'btnYes',
            click: function () {

                paid()
                $(this).dialog('close');
            }

        },
        {
            text: 'No',
            id: 'btnNo',
            click: function () {
                $(this).dialog('close');
            }

        }],

        close: function (event, ui) {
            $(this).dialog('destroy');
        },
        open: function () {
            $("#btnYes").removeAttr("class");
            $("#btnYes").addClass("btn btn-primary btn-large");
            $("#btnNo").removeAttr("class");
            $("#btnNo").addClass("btn btn-danger btn-large");
        }

    });


}
function paid() {
    var request = { CallSlipId: $('#CallSlipId').val(), contractorId: $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id") };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/SavePrepaidJobPaidNotes",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {

                ShowJobNotes();
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

$('#cancelPayWithCC').click(function () {
    $('#PayWithCCPrepaidAmountDiv').dialog('close');
});

$('#ConfirmPayWithCC').click(function () {
    $("#contractorListPrepaidJob").empty();

    var CallSlipId = $('#CallSlipId').val();
    var contractorId = $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id");
    var vl = true;
    var prepaid = $('#txtPayWithccAmount').val();
    var taxAmount = "";
    if ($("#trTaxAmount").is(":visible")) {
        if ($('#txtPayWithccTaxAmount').val() == "") {
            vl = false;
            errorStyle($('#txtPayWithccTaxAmount'));
        }
        else {
            removerErrorStyle($('#txtPayWithccTaxAmount'));
            taxAmount = $('#txtPayWithccTaxAmount').val();
        }
    }

    if (prepaid == "" || prepaid == null) {
        vl = false;
        errorStyle($('#txtPayWithccAmount'));
    }
    else {
        removerErrorStyle($('#txtPayWithccAmount'));
    }

    if (vl) {
        $('#PayWithCCPrepaidAmountDiv').dialog('close');
        var request = {
            callSlipId: CallSlipId, ContractorId: contractorId, prepaidAmount: prepaid, TaxAmount: taxAmount
        };
        $.ajax({
            type: "POST",
            contentType: "application/json, charset=utf-8",
            url: baseURL + "Home/payWithCc",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                }
                else data = msg;
                if (data.success) {
                    Notify(data.message, 'success');
                    GetContractorsByJobId();
                    ShowJobNotes();
                    //SelectJob(CallSlipId);
                    populateTechSumary();
                }
                else {
                    Notify(data.message, 'error');
                }
            }
        });
    }


});

$(document).on('click', '.ContractorNTE', function () {
    var contractorId = $(this).parents('tr').find("input:radio[name=contractorForNoticeForm]").attr('id');
    var request = { JobId: $('#CallSlipId').val(), ContractorId: contractorId };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        data: JSON.stringify(request),
        url: baseURL + "Contractor/GetContractorNTEHistory",
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                ContractorNTEHistoryPopup(data.NTEHistoryList)
            }
            else {
                alert("error");
            }
        },
        error: function () {
            CommunicationError();
        }
    });
});

function ContractorNTEHistoryPopup(NTEHistoryList) {
    var table = "";
    if (NTEHistoryList.length > 0) {
        table = "<div><table class='table table-advance'><thead><tr><th>Change</th><th>Reason</th><th>Updated On</th><th>Updated By</th></tr></thead><tbody>";
        for (var i = 0; i < NTEHistoryList.length; i++) {
            table += "<tr><td>" + NTEHistoryList[i].LogMessage + "</td><td>" + NTEHistoryList[i].nteReason + "</td><td>" + NTEHistoryList[i].UpdatedOn + "</td><td>" + NTEHistoryList[i].UserName + "</td></tr>";
        }
        table += "</tbody></table></div>";
    }
    else {
        table += "<div><p style='color:red;font-weight:bold;margin:6px 0px 0px 12px'>Contractor's NTE not changed.</p></div>";
    }
    var windowHeight = $(window).height() - 10;
    $(table).dialog({
        title: "Contractor NTE History",
        width: '420px',
        height: windowHeight,
        resizable: true,
        modal: true,
        position: ['left', 'bottom'],
        close: function (event, ui) {
            $(this).dialog('close');
        }
    });
}

function MakeDescriptionsToolTips() {
    $('#callslip-grid .htmlSection').each(function () {
        $(this).attr('title', $(this).text()).tooltip({
            show: null,
            open: function (event, ui) {
                ui.tooltip.siblings(".tooltip").remove();
            }
        });

        $(this).text($(this).text().substring(0, 100));
    });
}

function contractorsGridMap_onRowDataBound(e) {
    console.log("IN contractorsGrid_onRowDataBound");
    //the DOM element (<tr>) representing the row which is being databound
    var row = e.row;
    var dataItem = e.dataItem;
    //You can use the OnRowDataBound event to customize the way data is presented on the client-side
    if (dataItem.ContractorRatings > 0)
        row.cells[1].innerHTML = dataItem.BusinessName + GetContractorRatingsHTMLByRating(dataItem.ContractorRatings);
    if (dataItem.PriorityName == "Suspended") {
        //row.cells[1].innerHTML.style["background-color"] = "red";
        e.row.style["color"] = "#256bda";
        e.row.style["text-decoration"] = "line-through";
    }
}

function ShowBlackBallList(msg) {
    $("<div style='padding: 10px;'></div>").dialog({
        title: "BlackBall List",
        modal: true,
        width: $(window).width() - 600,
        height: $(window).height() - 300,
        resizable: true,
        modal: true,
        position: ['center', 'center'],
        buttons: [{
            text: "OK",
            id: "btnOk",
            click: function () {
                $(this).dialog("close");
            }
        }],
        open: function () {
            StyleWarningDiagle($(this));
            $(this).html(msg);
            $('#btnOk').removeAttr("class");
            $('#btnOk').addClass("btn btn-success");
        },
        close: function () {
            $(this).dialog("close");
        }
    });
}



