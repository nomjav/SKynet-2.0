$("#imgUpdateCustPopupShowSrPnl").click(function () {
    clearUpdateCustomerPopup();
    getUpdateCustomerDetailsFrmSrvcPnl(true);
});
$("#showSendEmailPopup").click(function () {
    showCustomerUpdateMsgBox();
    $("#updateCustomerPopupManageCust").dialog('close');
});
$('.dBoard').keypress(function (e) {
    
    if (e.keyCode == 13) {
        SearchJobs(1);
    }
});
$("#chkIsWarrantyJob").on('change', function () {
    if (($(this).is(":checked") && $("#IsWarrantyJob").val() == "0") || (!($(this).is(":checked")) && $("#IsWarrantyJob").val() == "1"))
        $("#WarrantyStateChanged").val("1");
    else
        $("#WarrantyStateChanged").val("0");
});


//----------------------------------Funtion to set Update Customer Details in Service Panel (send email porion) ------------------------------------------------
function setUpdateCustomerDetailsMsgBox(callslipDetails) {


    //if (callslipDetails.SendUpdateInCustomerPortal) {
    if (!callslipDetails.SendUpdateInCustomerEmail) {
        $("#updateCustomerContactsDetails").hide();
        $("#updateCustomerPreviousUpdate").hide();
        $("#updateCustomerHeaderRow").hide();
        $("#updateCustomerTbl2").hide();
        $("#updateCustomerInPortalMsg").show();
        $(".updateCustOthersRowServiceP").hide();
        $("#updateCustomerMsgPopup").css('height', 150);
    }
    else {
        $("#updateCustomerMsgPopup").css('height', 577);
        $("#updateCustomerHeaderRow").show();
        $("#updateCustomerInPortalMsg").hide();
        $("#updateCustomerTbl2").show();

        //--------------fill details in update customer popup that is open when we click on update customer button in Service pannel
        $("#updateCustomerPrimaryFName").text(callslipDetails.NotificationName);
        $("#updateCustomerPrimaryLName").text(callslipDetails.NotificationLastName);
        $("#updateCustomerPrimaryTitle").text(callslipDetails.NotificationTitle);
        $("#updateCustomerPrimaryEmail").text(callslipDetails.NotificationEmail);


        $("#updateCustomerPreviousUpdate").html("");
        $("#updateCustomerPreviousUpdate").html(callslipDetails.PreviousUpdate);

        var otherFirstNames = callslipDetails.OtherFirstNames.split(',');
        var otherLastNames = callslipDetails.otherLastNames.split(',');
        var otherTitles = callslipDetails.otherTitles.split(',');
        var otherEmails = callslipDetails.otherEmails.split(',');
        var totalRows = otherEmails.length;
        //------ this will remove the extra rows of others
        $(".updateCustOthersRowServiceP").each(function () {
            $(this).remove();
        });
        //------ this will add rows of others
        for (i = 1; i <= totalRows; i++) {
            $('.updateCustDetailsTblServiceP').append("<tr class='updateCustOthersRowServiceP'><td><label class='lblUpdateCustFirstName'></label></td><td><label class='lblUpdateCustLastName'></label></td><td><label class='lblUpdateCustTitleName'></label></td><td><label class='lblUpdateCustEmail'></label></td><td></td></tr>");

        }

        var i = 0;
        $(".updateCustOthersRowServiceP").each(function () {

            $(this).find(".lblUpdateCustFirstName").text(otherFirstNames[i]);
            $(this).find(".lblUpdateCustLastName").text(otherLastNames[i]);
            $(this).find(".lblUpdateCustTitleName").text(otherTitles[i]);
            $(this).find(".lblUpdateCustEmail").text(otherEmails[i]);
            i++;

        });


        $("#updateCustomerContactsDetails").show();
        $("#updateCustomerPreviousUpdate").show();
    }
}


//------------------------------------------Function to update the "Update customer details" in job-------------------------------------------------
function saveUpdateCustomerDetailsInJob(jobId) {

    var isValid = false;
    var primaryFirstName = "";
    var primaryLastName = "";
    var primaryTitle = "";
    var primaryEmail = "";
    //$(".updateCustomerIsPrimaryAddress").each(function () {

    //if(this.checked){
    primaryFirstName = $("#updateCustomerFNamePrimary").val();
    primaryLastName = $("#updateCustomerLNamePrimary").val();
    primaryTitle = $("#updateCustomerTitlePrimary").val();
    primaryEmail = $("#updateCustomerEmailPrimary").val();

    if ($("#updateCustomerOnCreateCust").is(":checked") || $("#updateCustomerOnDispatchCust").is(":checked") || $("#updateCustomerOnDelayCust").is(":checked") || $("#updateCustomerOnCompleteCust").is(":checked") || $("#updateCustomerInPortalCust").is(":checked") || $("#updateCustomerInEmailCust").is(":checked") || $("#updateCustomerOnAssignedCust").is(":checked") || $("#updateCustomerOnReturnCust").is(":checked") || $("#updateCustomerOnPartsOrderCust").is(":checked")) {

        if (primaryEmail != "") {
            $("#updateCustomerEmailPrimary").css('border', '1px solid gray');

            if (primaryFirstName == "" && primaryLastName == "" && primaryTitle == "") {
                $("#updateCustomerFNamePrimary").css('border', '1px solid red');
                $("#PreferedCommunicationMethod").prop("checked", false);
                isValid = false;
                return false;
            }
            else {
                $("#updateCustomerFNamePrimary").css('border', '1px solid gray');
                $("#PreferedCommunicationMethod").prop("checked", true);
                isValid = true;
            }
        }
        else if (primaryFirstName != "" || primaryLastName != "" || primaryTitle != "") {
            if (primaryEmail == "") {
                $("#updateCustomerEmailPrimary").css('border', '1px solid red');
                $("#PreferedCommunicationMethod").prop("checked", false);
                isValid = false;
                return false;
            }
            else {
                $("#updateCustomerEmailPrimary").css('border', '1px solid gray');
                $("#PreferedCommunicationMethod").prop("checked", true);
                isValid = true;
            }
        }
        else {
            $("#updateCustomerEmailPrimary").css('border', '1px solid red');
            $("#updateCustomerFNamePrimary").css('border', '1px solid red');
            $("#PreferedCommunicationMethod").prop("checked", false);
            isValid = false;
            return false;
        }
    }
    else {

        $("#PreferedCommunicationMethod").prop("checked", false);
        if (primaryEmail != "") {
            if (primaryFirstName == "" && primaryLastName == "" && primaryTitle == "") {
                $("#updateCustomerFNamePrimary").css('border', '1px solid red');
                isValid = false;
                return false;
            }
            else {
                $("#updateCustomerFNamePrimary").css('border', '1px solid gray');
                isValid = true;
            }
        }
        else if (primaryFirstName != "" || primaryLastName != "" || primaryTitle != "") {
            if (primaryEmail == "") {
                $("#updateCustomerEmailPrimary").css('border', '1px solid red');
                isValid = false;
                return false;
            }
            else {
                $("#updateCustomerEmailPrimary").css('border', '1px solid gray');
                isValid = true;
            }
        }
        else {
            $("#updateCustomerEmailPrimary").css('border', '1px solid gray');
            $("#updateCustomerFNamePrimary").css('border', '1px solid gray');
            isValid = true;
        }
    }

    var OtherFirstNames = "";
    var OtherLastNames = "";
    var OtherTitles = "";
    var OtherEmails = "";

    $(".updateCustomerOthersRowCust").each(function () {

        var OtherFirstName = $(this).find(".updateCustomerFirstName").val();
        var OtherLastName = $(this).find(".updateCustomerLastName").val();
        var OtherTitle = $(this).find(".updateCustomerTitle").val();
        var OtherEmail = $(this).find(".updateCustomerEmailAddress").val();

        if ($("#updateCustomerOnCreateCust").is(":checked") || $("#updateCustomerOnDispatchCust").is(":checked") || $("#updateCustomerOnDelayCust").is(":checked") || $("#updateCustomerOnCompleteCust").is(":checked") || $("#updateCustomerInPortalCust").is(":checked") || $("#updateCustomerInEmailCust").is(":checked")) {

            if (OtherEmail != "") {
                if (OtherFirstName == "" && OtherLastName == "" && OtherTitle == "") {
                    $(this).find(".updateCustomerFirstName").css('border', '1px solid red');
                    $("#PreferedCommunicationMethod").prop("checked", false);
                    isValid = false;
                    return false;
                }
                else {
                    $(this).find(".updateCustomerFirstName").css('border', '1px solid gray');
                    $("#PreferedCommunicationMethod").prop("checked", true);
                    isValid = true;
                }
            }
            else if (OtherFirstName != "" || OtherLastName != "" || OtherTitle != "") {
                if (OtherEmail == "") {
                    $(this).find(".updateCustomerEmailAddress").css('border', '1px solid red');
                    $("#PreferedCommunicationMethod").prop("checked", false);
                    isValid = false;
                    return false;
                }
                else {
                    $(this).find(".updateCustomerEmailAddress").css('border', '1px solid gray');
                    $("#PreferedCommunicationMethod").prop("checked", true);
                    isValid = true;
                }
            }
            else {
                $(this).find(".updateCustomerEmailAddress").css('border', '1px solid gray');
                $(this).find(".updateCustomerFirstName").css('border', '1px solid gray');
                isValid = true;
            }
        }
        else {
            $("#PreferedCommunicationMethod").prop("checked", false);
            if (OtherEmail != "") {
                if (OtherFirstName == "" && OtherLastName == "" && OtherTitle == "") {
                    $(this).find(".updateCustomerFirstName").css('border', '1px solid red');
                    isValid = false;
                    return false;
                }
                else {
                    $(this).find(".updateCustomerFirstName").css('border', '1px solid gray');
                    isValid = true;
                }
            }
            else if (OtherFirstName != "" || OtherLastName != "" || OtherTitle != "") {
                if (OtherEmail == "") {
                    $(this).find(".updateCustomerEmailAddress").css('border', '1px solid red');
                    isValid = false;
                    return false;
                }
                else {
                    $(this).find(".updateCustomerEmailAddress").css('border', '1px solid gray');
                    isValid = true;
                }
            }
            else {
                $(this).find(".updateCustomerEmailAddress").css('border', '1px solid gray');
                $(this).find(".updateCustomerFirstName").css('border', '1px solid gray');
                isValid = true;
            }
        }
        if (OtherEmail != "") {
            OtherFirstNames += OtherFirstName + ",";

            OtherLastNames += OtherLastName + ",";

            OtherTitles += OtherTitle + ",";

            OtherEmails += OtherEmail + ",";
        }
    });

    OtherFirstNames = OtherFirstNames.slice(0, -1);
    OtherLastNames = OtherLastNames.slice(0, -1);
    OtherTitles = OtherTitles.slice(0, -1);
    OtherEmails = OtherEmails.slice(0, -1);

    if (isValid == true) {
        var request = {
            JobId: jobId,
            PrimaryFirstName: primaryFirstName, PrimaryLastName: primaryLastName, PrimaryTitle: primaryTitle, PrimaryEmail: primaryEmail, OtherFirstNames: OtherFirstNames, OtherLastNames: OtherLastNames,
            OtherTitles: OtherTitles, OtherEmails: OtherEmails,
            UpdateOnCreate: $("#updateCustomerOnCreateCust").is(":checked"),
            UpdateOnAssign: $("#updateCustomerOnAssignedCust").is(":checked"),
            UpdateOnDispatch: $("#updateCustomerOnDispatchCust").is(":checked"),
            UpdateOnDelay: $("#updateCustomerOnDelayCust").is(":checked"),
            UpdateOnComplete: $("#updateCustomerOnCompleteCust").is(":checked"),
            UpdateInCustomerPortal: $("#updateCustomerInPortalCust").is(":checked"), UpdateInCustomerEmail: $("#updateCustomerInEmailCust").is(":checked"), UpdateCustomer: $("#PreferedCommunicationMethod").is(":checked"),
           //UpdateOnReturn: $("#updateCustomerOnReturnCust").is(":checked"), UpdateOnPartsOnOrder: $("#updateCustomerOnPartsOrderCust").is(":checked")
        };

        $.ajax({
            type: "POST",
            contentType: "application/json charset=utf-8",
            url: baseURL + "Home/SaveCustomerUpdateDetailsInJob",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                }
                else
                    data = msg;

                if (data.success) {
                    Notify(data.message, 'success');
                    $("#updateCustomerPopupManageCust").dialog('destroy');
                }
                else {
                    Notify(data.message, 'error')
                }

            },
            error: function () {
                CommunicationError();
            },
            complete: function () {
                GetProgressBarDetailsByJobId();
            }
        });
    }
}
//--------------------- Set Update Customer details ---------------------------------
function fillCustomerUpdateDetails(callslipDetails) {

    if (callslipDetails != null) {

        //--------------fill details in update customer popup that is open when we click on check box of update customer in Service pannel
        $("#showSendEmailPopup").show();
        $(".updateCustomerFNamePrimary").val(callslipDetails.NotificationName);
        $(".updateCustomerLNamePrimary").val(callslipDetails.NotificationLastName);
        $(".updateCustomerTitlePrimary").val(callslipDetails.NotificationTitle);
        $(".updateCustomerEmailPrimary").val(callslipDetails.NotificationEmail);
        var otherFirstNames = callslipDetails.OtherFirstNames.split(',');
        var otherLastNames = callslipDetails.otherLastNames.split(',');
        var otherTitles = callslipDetails.otherTitles.split(',');
        var otherEmails = callslipDetails.otherEmails.split(',');
        var totalRows = otherEmails.length;
        //------ this will remove the extra rows of others

        var f = 1;
        $(".updateCustomerOthersRowCust").each(function () {

            if (f > 3) {
                $(this).remove();
            }
            f++;
        });
        //------ this will add rows of others

        var totalRows = otherEmails.length;
        for (i = 1; i <= totalRows; i++) {
            if (i > 3) {
                $('.updateCustomrDetailsTable').append("<tr class='updateCustomerOthersRowCust'><td><input type='text' id='updateCustomerFirstName' class='updateCustomerFirstName' /></td><td><input type='text' id='updateCustomerLastName' class='updateCustomerLastName' /></td><td><input type='text' id='updateCustomerTitle' class='updateCustomerTitle' /></td><td><input type='text' id='updateCustomerEmailAddress' class='updateCustomerEmailAddress' /></td><td></td></tr>");
            }
        }

        var j = 0;
        $(".updateCustomerOthersRowCust").each(function () {

            $(this).find(".updateCustomerFirstName").val(otherFirstNames[j]);
            $(this).find(".updateCustomerLastName").val(otherLastNames[j]);
            $(this).find(".updateCustomerTitle").val(otherTitles[j]);
            $(this).find(".updateCustomerEmailAddress").val(otherEmails[j]);
            j++;

        });
        $("#updateCustomerOnCreateCust").attr("checked", callslipDetails.UpdateOnCreated);
        $("#updateCustomerOnAssignedCust").attr("checked", callslipDetails.UpdateOnAssigned);

        $("#updateCustomerOnDispatchCust").attr("checked", callslipDetails.UpdateOnDispatched);
        $("#updateCustomerOnDelayCust").attr("checked", callslipDetails.UpdateOnDelay);

        $("#updateCustomerOnCompleteCust").attr("checked", callslipDetails.UpdateOnCompleted);
        $("#updateCustomerInPortalCust").attr("checked", callslipDetails.SendUpdateInCustomerPortal);
        $("#updateCustomerInEmailCust").attr("checked", callslipDetails.SendUpdateInCustomerEmail);

        //$("#updateCustomerOnReturnCust").attr("checked", callslipDetails.UpdateOnReturn);
        //$("#updateCustomerOnPartsOrderCust").attr("checked", callslipDetails.UpdateOnPartsOnOrder);
    }
}

//---------------------Function to display udpate customer details when click on Update Customer button in service panel --------------------
function showCustomerUpdateMsgBox(emailBody) {

    clearUpdateCustomerPopupFields();

    getUpdateCustomerDetailsFrmSrvcPnl(false, emailBody);
}


//----------------------Function to get details of update Customer From sevice panel-----------------------------------------
function getUpdateCustomerDetailsFrmSrvcPnl(IsUpdateCustomerEditForm, emailBody) {
    
    var request = { JobId: $("#CallSlipId").val() };

    $.ajax({
        type: "POST",
        contentType: "application/json charset=utf-8",
        url: baseURL + "Home/GetUpdateCustomerDetailsByJobId",
        data: JSON.stringify(request),
        success: function (msg) {

            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;

            if (data.success) {
                
                //Notify(data.message, 'success');
                var updateCustomerDetailsInJob = data.customerUpdateDetail;
                if (IsUpdateCustomerEditForm != true) {
                    if (updateCustomerDetailsInJob != null && updateCustomerDetailsInJob != "") {

                        setUpdateCustomerDetailsMsgBox(updateCustomerDetailsInJob, emailBody);
                        openCustomerUpdateMsgBox(emailBody);

                        if (emailBody != null) {
                            
                            emailBody = emailBody.replace(/(<([^>]+)>)/g, "");
                            ("#updateCustomerMsgArea").val(emailBody);
                            $("#isManual").val("true");
                        }

                        if ($('#progressStatus').val() != '') {
                            var messg = '';
                            if ($('#progressStatus').val() == "Accepted") {
                                messg = "The job has been accepted.";
                            }
                            else if ($('#progressStatus').val() == "Dispatched") {
                                messg = "The job has been dispatched.";
                            }
                            else if ($('#progressStatus').val() == "Delayed") {
                                messg = "This job has been delayed.";
                            }
                            else if ($('#progressStatus').val() == "Complete") {
                                messg = "This job has been completed.";
                            }
                            messg += '\n';
                            $("#updateCustomerMsgArea").val(messg);
                        }
                    }
                }
                else {
                    fillCustomerUpdateDetails(updateCustomerDetailsInJob);
                    showCusotomerUpdateEditFormInSrvcPnl();
                }
            }
            else {

                Notify(data.message, 'error');
            }

        },
        error: function () {

            CommunicationError();
        },
        failure: function () {

            alert("Failure");
        }
    });
}

function openCustomerUpdateMsgBox(emailBody) {

    var height = $("#updateCustomerMsgPopup").height();
    
    $("#updateCustomerMsgPopup").dialog({
        title: "Update Customer",
        height: height,
        width: 745,
        position: ['right', 'top'],
        modal: true,
        buttons: [{
            id: "btnCancelUpdateCustPopup",
            text: "Cancel",
            click: function () {
                $(this).dialog('close');
                $("#lblUpdateInPortalMsg").html("");
                isFromProgressBar = false;
                updateInEmail = false;
            }
        }],
        open: function () {
            
            if (emailBody != null && emailBody != "") {
                //$("#updateCustomerMsgPopup").css("height", "80px");
                var msg = "<b>" + emailBody + "</b>";
                $("#lblUpdateInPortalMsg").html(msg);
            }
            StyleApplicationDiagle(this);
            $("#btnCancelUpdateCustPopup").removeAttr("class");
            $("#btnCancelUpdateCustPopup").addClass("btn btn-danger btn-large");
        },
        close: function () {
            $(this).dialog('close');
            $("#lblUpdateInPortalMsg").html("");
            isFromProgressBar = false;
            updateInEmail = false;
        }
    });
}


//--------------------Function to send manual updates to customer from service panel ----------------------------------
function sendUpdateToCustomer() {

    var isValid = false; 
    if ($("#updateCustomerMsgArea").val() == "" || $("#updateCustomerMsgArea").val() == "") {
        isValid = false;
        $("#updateCustomerMsgArea").css("border", "1px solid red");
    }
    else {
        isValid = true;
        $("#updateCustomerMsgArea").css("border", "1px solid gray");
    }
    if (isValid == true) {
        var isManual = false;
        if ($("#isManual").val() == "true") {
            isManual = true;
        }
        else {
            isManual = false;
        }
        
        var request = { CallSlipId: $('#CallSlipId').val(), ManualMessageFromServicePanel: $("#updateCustomerMsgArea").val(), IsManualMsg: isManual, ProgressBarStatus: $('#progressStatus').val() };

        $.ajax({
            type: "POST",
            contentType: "application/json charset=utf-8",
            url: "Home/SendEmailOnCustomerUpdateDialog",
            data: JSON.stringify(request),
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d")) {
                    data = msg.d;
                }
                else
                    data = msg;

                if (data.success) {
                    Notify(data.message, 'success');
                    if (isFromProgressBar) {
                        if ($('#progressStatus').val() != '' && listElement != null && $('#UpdateType').val() != '' && updateInEmail) {
                            ToggleCustomerUpdate(listElement, false, $('#UpdateType').val());
                        }
                    }
                    if ($("#updateCustomerMsgPopup").is(':visible')) {
                        $("#updateCustomerMsgPopup").dialog('close');
                    }
                    if ($('#ViewCustomerWebAddresses').is(':visible')) {
                        $('#ViewCustomerWebAddresses').dialog('close');
                    }
                }
                else {
                    Notify(data.message, 'error')
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
}

function showCusotomerUpdateEditFormInSrvcPnl() {
    $(".updateCustomerPopupManageCust").dialog({
        title: "Update Customer",
        height: 450,
        width: 800,
        modal: true,
        buttons: [{
            id: "btnCancelUpdateCustomerPupup",
            text: "Cancel",
            click: function () {
                $(this).dialog('destroy');
                //clearUpdateCustomerPopup();
            }
        },
        {
            id: "btnSaveUpdateCustomerDetails",
            text: "Save",
            click: function () {
                saveUpdateCustomerDetailsInJob($("#CallSlipId").val());
            }
        }
        ],
        open: function () {
            StyleApplicationDiagle(this);


            //if ($('#PreferedCommunicationMethod').is(':checked')) {
            //    $('#updateCustomerPopupManageCust').children().find('*').attr('disabled', false);
            //    $('#btnCancelUpdateCustomerPupup').show();
            //    $('#btnSaveUpdateCustomerDetails').show();
            //}
            //else {
            //    $('#updateCustomerPopupManageCust').children().find('*').attr('disabled', 'disabled');
            //    $('#btnCancelUpdateCustomerPupup').hide();
            //    $('#btnSaveUpdateCustomerDetails').hide();
            //}

            $("#btnSaveUpdateCustomerDetails").removeAttr("class");
            $("#btnSaveUpdateCustomerDetails").addClass("btn btn-primary btn-large");
            $("#btnCancelUpdateCustomerPupup").removeAttr("class");
            $("#btnCancelUpdateCustomerPupup").addClass("btn btn-danger btn-large");
        },
        close: function () {
            clearUpdateCustomerPopup();
            $(this).dialog('destroy');
        }
    });
}

function clearUpdateCustomerPopupFields() {

    $(".lblUpdateCustFirstName").each(function () {
        $(this).text("");
    });
    $(".lblUpdateCustLastName").each(function () {
        $(this).text("");
    });
    $(".lblUpdateCustTitleName").each(function () {
        $(this).text("");
    });
    $(".lblUpdateCustEmail").each(function () {
        $(this).text("");
    });

    $("#updateCustomerPrimaryFName").text("");
    $("#updateCustomerPrimaryLName").text("");
    $("#updateCustomerPrimaryTitle").text("");
    $("#updateCustomerPrimaryEmail").text("");
    $("#updateCustomerPreviousUpdate").text("");
    $("#updateCustomerMsgArea").val("");
}

//$('#PreferedCommunicationMethod').click(function () {
//    
//    if (this.checked) {
//        //showUpdateCustomerPopupInCustomers(null,$('#CallSlipId').val());
//        clearUpdateCustomerPopup();
//        getUpdateCustomerDetailsFrmSrvcPnl(true);
//    }
//});

$("#lblCorporateNTEAmount").click(function () {
    var request = { JobId: $("#CallSlipId").val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetCorporateAmountHistory",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                CorporateNTEHistoryPopup(msg.nteHistoryList);
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }

    });
});

function CorporateNTEHistoryPopup(nteHistoryList) {
    var table = "";
    if (nteHistoryList.length > 0) {
        table = "<div><table class='table table-advance'><thead><tr><th>Change</th><th>Updated On</th><th>Updated By</th></tr></thead><tbody>";
        for (i = 0; i < nteHistoryList.length; i++) {
            table += "<tr><td>" + nteHistoryList[i].LogMessage + "</td><td>" + nteHistoryList[i].UpdatedOn + "</td><td>" + nteHistoryList[i].UserName + "</td></tr>";
        }
        table += "</tbody></table></div>";
    }
    else {
        table += "<div><p style='color:red;font-weight:bold;margin:6px 0px 0px 12px'>Corporate NTE not changed.</p></div>";
    }
    var windowHeight = $(window).height() - 10;
    $(table).dialog({
        title: "Corporate NTE History",
        width: '375px',
        height: windowHeight,
        resizable: true,
        modal: true,
        position: ['left', 'bottom'],
        close: function (event, ui) {
            $(this).dialog('close');
        }
    });
}

var counter = 0;

function GetPaymentsByJobId(id) {
    var request = { CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: "Home/GetPaymentsByJobId",
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
                PopulatePayments(data.payments);
                GetPaymentMethodsByJobId(id)
            }
            else {
                Notify(data.message, 'error');
            }
        },
        complete: function () {
            //HideLoaderSP();
        },
        error: function () {
            //CommunicationError();
        }
    });
}

// Populate Payments
function PopulatePayments(payments) {
    var payment = "";
    $('#tblBodyPaymentsGrid').html("");
    if (payment != undefined) {
        if (payments != null && payments.length > 0) {
            payment = "";
            for (var i = 0; i < payments.length; i++) {
                payment += "<tr><td>$ " + parseFloat(payments[i].Amount).toFixed(2) + "</td><td>" + payments[i].DatePaid + "</td><td>" + payments[i].PaymentMethod + "</td><td>" + payments[i].Approval + "</td><td>" + payments[i].Notes + "</td><td>" + payments[i].UserName + "</td><td>" + payments[i].ReceiptNumber + "</td></tr>";
            }
            $('#PaymentsDiv').show();
            $('#tabs li:nth-child(4)').attr('style', 'background: green;border: green;');
            $('#tabs li:nth-child(4)').find('a').attr('style', 'color:#fff;');
        } else {
            payment += "<tr><td colspan='4'><h4 style='color:red;'>Payments does not exist.</h4></td></tr>";
            $('#PaymentsDiv').hide();
            $('#tabs li:nth-child(4)').removeAttr('style');
            $('#tabs li:nth-child(4)').find('a').removeAttr('style');
        }
    }
    else {
        payment += "<tr><td colspan='4'><h4 style='color:red;'>Payments does not exist.</h4></td></tr>";
        $('#PaymentsDiv').hide();
        $('#tabs li:nth-child(4)').removeAttr('style');
        $('#tabs li:nth-child(4)').find('a').removeAttr('style');
    }

    $('#tblBodyPaymentsGrid').html(payment);
}

function GetPaymentMethodsByJobId(id) {
    var request = { CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetPaymentMethodsByJobId",
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
                PopulatePaymentMethods(data.cards);
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

// Populate Payment Methods
function PopulatePaymentMethods(pMethods) {
    var pMethod = "";
    if (pMethods.length > 0) {
        pMethod = "";
        for (var i = 0; i < pMethods.length; i++) {
            var cardNumber = pMethods[i].CustomerCreditCardNumber;
            if (cardNumber != '' && cardNumber.length > 5) {
                cardNumber = cardNumber.replace(/.(?=.{4,}$)/g, '*');
            }
            pMethod += "<tr><td>" + pMethods[i].NameOnCard + "</td><td>" + cardNumber +
                "</td><td>" + pMethods[i].CreditCardExpireMonth + "/" + pMethods[i].CreditCardExpireYear + "</td>" +
                "<td><button onclick='UseCardForPayment(" + pMethods[i].PaymentMethodId + ")' class='btn btn-success'>Use This Card</button></td>" + "</tr>";
        }
    }
    else {
        pMethod += "<tr><td colspan='4'><h4 style='color:red;'>Credit Cards do not exist.</h4></td></tr>";

    }

    $('#tbodyCreditCards').html(pMethod);
}


// populate messages
function PopulateMessages(messages) {
    var message = "";
    for (var i = 0; i < messages.length; i++) {
        message += '<div class = "itemDiv dialogdiv">';
        if (messages[i].Sent) {
            message += "<tr><td style='background-color:#a8cce5;'>" + messages[i].Body + "<br /><span style='float:right;'>" + messages[i].DateCreated +"</span></td>";
            message += "<td></td> </tr>"
        }
        else {
            message += "<tr><td></td>";
            message += "<td style='background-color:#d0dadd;'>" + messages[i].Body + "<br /><span style='float:right;'>" + messages[i].DateCreated +"</span></td> </tr>"
        }
    }
    $('#tblBodyMessageGrid').html("");
    $('#tblBodyMessageGrid').html(message);
}

function GetNotesByJobId() {
    var request = { CallSlipId: $("#CallSlipId").val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/GetNotesByJobId",
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
                PopulateJobNotes(data.notes, data.linkedJobId);
            }
            else {
                Notify(data.message, 'error');
            }
        },
        complete: function () {
            HideLoaderSP();
            GetProgressBarDetailsByJobId();
        },
        error: function () {
            CommunicationError();
        }
    });
}

function radioselection() {
    getTechSummaryList1($("input[type = radio][name = contractorForNoticeForm]:checked").attr('id'));
}

function radioselection1() {
    var jobId = $("#CallSlipId").val();
    var contratorId = $("input[type = radio][name = contractorForNoticeForm]:checked").attr('id');
    if (contratorId != null) {
        TechSummaryReminder(contratorId, jobId);
    }
    //TechSummaryReminder($("input[type = radio][name = contractorForNoticeForm]:checked").attr('id'))
    else {
        getJobContractorsList1();
    }
    
}




var isCompliance = false;
// Task # 1576
function complianceSummary(ID) {
    
    var request = { contractorId: ID };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Contractor/GetComplianceSummary",
        data: JSON.stringify(request),
        async: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                isCompliance = data.allTrue;
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });

}

// Task # 1578

function showComplianceSummary(ID)
{
    var request = { contractorId: ID };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Contractor/GetComplianceSummary",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                $('#compliance_ServiceDialog').dialog({
                    title: 'Compliance Summary',
                    resizable: true,
                    width: 800,
                    height: 300,
                    modal: true,
                    buttons: [
                        {
                            text: "Send Compliance Reminder",
                            id: "SendComplianceReminder",
                            click: function () {
                                sendComplianceReminderEmail(ID, data.W9, data.Agreement, data.Insurance, data.License);
                            }
                        }
                        ,{
                        text: "Close",
                        id: "cancelCompliance_service",
                        click: function () {
                            $('#compliance_ServiceDialog').html("");
                            $(this).dialog("destroy");
                        }
                    }],
                    close: function (event, ui) {
                        $(this).dialog('destroy');
                        $('#compliance_ServiceDialog').html("");
                    },
                    open: function () {

                        //var summary = '<br /><div><b>&nbsp;Contractor Id: </b>' + data.ContractorID + '<div>';
                        //summary += '<div><b>&nbsp;Business Name: </b>' + data.ContractorName + '<div>';
                        //summary += data.W9 == true ? '<br /><br /><br /><div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;W9 Document: </b> Available </div>' : '<br /><br /><br /><div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;W9 Document: </b> Not Available </div>';
                        //summary += data.Agreement == true ? '<br /><div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub Contractor Agreement: </b> Available </div>' : '<br /><div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub Contractor Agreement: </b> Not Available </div>';
                        //summary += data.Insurance == true ? '<br /><div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Insurance Document: </b> Available </div>' : '<br /><div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Insurance Document: </b> Not Available </div>';
                        //summary += data.License == true ? '<br /><div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;License Document: </b> Available </div>' : '<br /><div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;License Document: </b> Not Available </div>';
                        var summary = '<br /><table class="table"><tr style="background-color:#6eb8f8;"><th>Documentation</th><th>Date Processed</th><th>Expiration</th><th>License #</th><th>Insurance Type</th><th>Minimum Coverage</th><th>Verified</th></tr>';
                        summary += '<tr><td>License</td><td>' + data.License + '</td><td>' + data.licenseExpire + '</td><td>' + data.licenseLicence + '</td><td></td><td></td><td>' + data.licenseVerifier + '</td></tr>';
                        summary += '<tr><td>W-9 Form</td><td>' + data.W9 + '</td><td>' + data.w9Expire + '</td><td>' + data.w9Licence + '</td><td></td><td></td><td>' + data.w9Verifier + '</td></tr>';
                        summary += '<tr><td>Subcontractor Agreement</td><td>' + data.Agreement + '</td><td>' + data.agreementExpire + '</td><td>' + data.agreementLicence + '</td><td></td><td></td><td>' + data.agreementVerifier + '</td></tr>';
                        summary += '<tr><td>Certificate Of Insurance</td><td>' + data.Insurance + '</td><td>' + data.insuranceExpire + '</td><td>' + data.insuranceLicence + '</td><td>' + data.InsuranceType + '</td><td>' + data.minimumCoverage + '</td><td>' + data.insuranceVerifier + '</td></tr>';
                        summary += '</table>'
                        $('#compliance_ServiceDialog').html(summary);
                        $('#cancelCompliance_service').removeAttr("class");
                        $('#SendComplianceReminder').removeAttr("class");

                        $('#cancelCompliance_service').addClass("cancel btn btn-danger");
                        $('#SendComplianceReminder').addClass("success btn btn-primary");
                    }
                });
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function sendComplianceReminderEmail(ID, W9, Agreement, Insurance, License)
{
    var request = { contractorId: ID, W9: W9, Agreement: Agreement, Insurance: Insurance, License: License };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Contractor/sendComplianceReminderEmail",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                Notify("Reminder Sent Successfully", "success")
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function HideLoaderSP() {
    counter++;
    if (counter > 4) {
        //if ($('#img_LoadOnSP').is(':visible'))
            $('#img_LoadOnSP').hide();
    }
}



function GetJobStatusReport() {
    var request = {
        InState: $('#cbInState').prop('checked'),
        OutOfState: $('#cbOutOfState').prop('checked'),
        Citibank: $('#cbCitiBank').prop('checked'),
        Aiss: $('#cbAissJobs').prop('checked'),
        Project: $('#cbProjects').prop('checked')
    };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: "Home/DailyJobStatusReport",
        data: JSON.stringify(request),
        global: false,
        success: function (msg) {

            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                CreateStatusTabs(data.model);
            } else {
                //Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function LoadDailySummaryReport() {
    $('#ManagerDailySheet').load(baseURL + "HeadSheet/ManagerDailyReportOnDispatchBoard").ajaxStart(UnBlockUI());
}



function displayCustomerEmailLog(list, id) {
    $('#' + id).parent().find('#CustomerCommLogBody').html("");
    if (list.length > 0) {
        var tblBody = "";
        for (var i = 0; i < list.length; i++) {
            tblBody += "<tr>";
            tblBody += "<td style='display:none;'>" + list[i].Id + "</td>";
            if (list[i].LogMessage.indexOf("portal") < 0) {
                tblBody += "<td class='emailupdate' onclick='getFullEmailMessage(" + list[i].Id + ")'>" + list[i].LogMessage + "</td>";
            }
            else {
                tblBody += "<td>" + list[i].LogMessage + "</td>";
            }
            tblBody += " <td>" + list[i].MailedOn + "</td><td>" + list[i].Sender + "</td>";
            tblBody += "</tr>";
        }
        $('#' + id).parent().find('#CustomerCommLogBody').html(tblBody);
    }
    else {
        var message = "<tr><td colspan='3' style='color:#d33838;'><h6>No email log exists.</h6></td></tr>";
        $('#' + id).parent().find('#CustomerCommLogBody').html(message);
    }
}

function getFullEmailMessage(Id) {

    var request = { EmailLogId: Id }
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Customer/GetFullEmailMessage",
        data: JSON.stringify(request),
        success: function (msg) {

            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.hasOwnProperty("d");
            }
            else
                data = msg;
            if (data.success) {
                displayEmailMessagePopup(data.log);
            }
            else {
                Notify("Message not found. Please try again.", "error");
            }
        },
        error: function () {

            CommunicationError();
        }
    });
}

function displayEmailMessagePopup(Log) {
    
    if (Log != 'undefined') {
        //var div = "<div style='padding:10px 10px 10px 10px;'>" + fullMessage.Body + "</div>";
        $("#EmailLogDetails").dialog({
            title: "Email Details",
            width: 700,
            height: 550,
            modal: true,
            buttons: [{
                id: "btnCancelEmailLogMesssage",
                text: "Close",
                click: function () {
                    $(this).dialog('close');
                }
            }],
            open: function () {
                $('#btnCancelEmailLogMesssage').removeAttr("class");
                $('#btnCancelEmailLogMesssage').addClass("btn btn-danger");
                StyleApplicationDiagle(this);
                $("#EmailTo").html(Log.to);
                $("#EmailFrom").html(Log.from);
                $("#EmailSubject").html(Log.subject);
                $("#EmailMessage").html(Log.message);
                if (Log.CCEmailAddresses.length > 0) {
                    if ($("#trCCMails") != 'undefined' && $("#trCCMails").is(':visible')){
                        $("#CCEmails").html(Log.CCEmailAddresses);
                    }
                    else{
                        var row = "<tr id='trCCMails'><td><strong>CC</strong></td><td><div id='CCEmails'></div></td></tr>";
                        $('.emaildetails tr:first').after(row);
                        $("#CCEmails").html(Log.CCEmailAddresses);
                    }
                }
                else {
                    if ($("#trCCMails") != 'undefined' && $("#trCCMails").is(':visible'))
                        $("#trCCMails").remove();
                }


            }
        });
    }
   
}


//Job Descrepencies Functions
function showDesc() {
    if ($('#DescType').val() > 0) {
        $('#jobDescDiv').show();
        $('#DescDescription').val('');
    }
    else { $('#jobDescDiv').hide(); }
}

function hideDesc() {
    //$('#jobDescDiv').find('select option:eq(0)').prop('selected', true);
    $('#DescType').val(0);
    $('#DescType').trigger("chosen:updated");
    $('#jobDescDiv').hide();
}



function PerformDescValidation() {
    var vl = true;


    if ($('#DescDescription').val() == "") {
        errorStyle($('#DescDescription'));
        vl = false;
    }
    else {
        $('#DescDescription').css('border', '1px solid gray');
    }

    if (vl == true) {
        //
        //if ($('#TechContractorId_chosen .chosen-single').text().indexOf("Select ") > 0) {
        //    errorStyle($('#TechContractorId_chosen'));
        //}
        //else {
        //    $('#TechContractorId_chosen').css('border', 'none');
        SaveDiscrepancies();
        //}
    }
}

function errorStyle(ctrl) {
    $(ctrl).css('border', '1px solid red');
}
function removerErrorStyle(ctrl) {
    $(ctrl).css('border', '1px solid gray');
}

function SaveDiscrepancies() {

    var request = { Type: $('#DescType').val(), TypeName: $('#DescType option:selected').text(), JobId: $('#dispatchcallslipID').text(), Description: $('#DescDescription').val() };
    $.ajax({

        type: "POST",
        url: baseURL + "JobsDiscrepancies/SaveDiscrepancies",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data = msg.hasOwnProperty("d") ? msg.d : msg;
            if (data.success) {
                Notify("Saved Successfully", "success");
                $('#DescDescription').val("");
                $('#jobDescDiv').hide();
                $('#DescType').val(0);
                $('#DescType').trigger("chosen:updated");
                //$('#DescType').prop('disabled', 'disabled');
                ShowJobNotes();
            }
            else {
                Notify(data.message, 'error');
            }
        },
        error: function () { CommunicationError(); }
    });
}


function GetJobStatusHistoryByJobId(id) {
    var request = { CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: "Home/JobStatusHistory",
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
                
                if (data.listModel.length > 0) {
                    var table = "<table class=''>";
                    table += "<tr>";
                    for (var i = data.listModel.length - 1; i >= 0 ; i--) {
                        table += "<td style='border: none;height: 25px; width: 25px; background-color:" + data.listModel[i].NewStatusColorHex + ";'></td>";
                        //table += "<td style='border: none;height: 25px; width: 17px; background-color:" + data.listModel[i].NewStatusColorHex + ";'></td>";
                    }

                    table += "</tr></table>";
                    $('#' + id).parent().find('#StatusHistoryColors').html('');
                    $('#' + id).parent().find('#StatusHistoryColors').html(table);
                    //$('#StatusHistoryColors').html(table);
                    $('#' + id).parent().find('#StatusHistoryColors').show();
                    $('#' + id).parent().find('#StatusHistoryColors').css("display", "inline-block");
                }
                else {
                    $('#' + id).parent().find('#StatusHistoryColors').html("");
                    $('#' + id).parent().find('#StatusHistoryColors').hide();
                }
            }
        },
        error: function () {
            CommunicationError(); 
        }
    });

}

function GetProgressBarDetailsByJobId(id) {
    var request = { CallSlipId: id };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: "Home/GetJobProgressBarDetails",
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
                SetUpProgressBar(data.model, id);
            }
        },
        complete: function () {
            HideLoaderSP();
            
           // GetEmailsLogsByCustomerId();
        },
        error: function () {
            CommunicationError();
        }
    });
}

function SetUpProgressBar(callslip, id) {

    if (callslip != null) {
        if (callslip.RequireUpdates) {
            //Created
            if (callslip.UpdateOnCreated) {
                $('.accepted').removeClass('bg-white');
                $('.accepted').addClass('bg-success');
            }
            else {
                $('.accepted').addClass('bg-white');
                $('.accepted').removeClass('bg-success');
            }

            //Dispatched
            if (callslip.UpdateOnDispatched) {
                $('.dispatched').removeClass('bg-white');
                $('.dispatched').addClass('bg-success');
            }
            else {
                $('.dispatched').addClass('bg-white');
                $('.dispatched').removeClass('bg-success');
            }

            //Delayed
            if (callslip.UpdateOnDelayed) {
                $('.delayed').removeClass('bg-white');
                $('.delayed').addClass('bg-danger');
            }
            else {
                $('.delayed').addClass('bg-white');
                $('.delayed').removeClass('bg-danger');
            }

            //Completed
            if (callslip.UpdateOnCompleted) {
                $('.complete').removeClass('bg-white');
                $('.complete').addClass('bg-success');
            }
            else {
                $('.complete').addClass('bg-white');
                $('.complete').removeClass('bg-success');
            }

            if (callslip.SendUpdateInCustomerPortal && !callslip.SendUpdateInCustomerEmail) {
                $('#UpdateType').val("p");
            }
            else if (!callslip.SendUpdateInCustomerPortal && callslip.SendUpdateInCustomerEmail) {
                $('#UpdateType').val("e");
            }
            else if (callslip.SendUpdateInCustomerPortal && callslip.SendUpdateInCustomerEmail) {
                $('#UpdateType').val("pe");
            }
            else {
                $('#UpdateType').val("");
            }
        }
        else {
            $('.accepted').removeClass('active');
            $('.accepted').removeClass('visited');

            $('.dispatched').removeClass('active');
            $('.dispatched').removeClass('visited');

            $('.delayed').removeClass('active');
            $('.delayed').removeClass('visited');

            $('.complete').removeClass('active');
            $('.complete').removeClass('visited');

            $('#UpdateType').val("");
        }
    }
}

function SaveCustomerNotesFromSP(notes) {
    var request = { CustomerId: $('#CustomerId').val(), Notes: notes };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Customer/SaveCustomerNotesFromSP",
        data: JSON.stringify(request),
        cache: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                Notify(data.message, 'success');
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
function SaveStoreNotesFromSP(notes) {
    var request = { StoreId: $('#StoreId').val(), Notes: notes };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Customer/SaveStoreNotesFromSP",
        data: JSON.stringify(request),
        cache: false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                Notify(data.message, 'success');
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

$('#ServiceTab_City').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: baseURL + "State/GetCitiesByState",
            data: { input: request.term, stateId: $("#ServiceTab_State").val(), zip: $("#ServiceTab_Zip").val() },
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
        $('#ServiceTab_City').val(ui.item.label);
        return false;
    },
    minLength: 3
});

function CheckIfCustomerHasEmail() {
    var customerEmailAddress = "";
    if ($("#updateCustomerEmailPrimary").val() != "") {
        customerEmailAddress = $("#updateCustomerEmailPrimary").val();
    }
    else if ($("#Email").val() != "") {
        customerEmailAddress = $("#Email").val();
    }

    if (customerEmailAddress != "") {
        SendImageToCustomer();
    }
    else {
        Notify("Customer email address couldn't be found. Please update the address first.", 'error');
    }
}
function SendImageToCustomer() {
    var contractorId = $('input[type="radio"][name="contractorForNoticeForm"]:checked').attr("id");
    if (contractorId != null || contractorId != "") {
        var request = { CallSlipId: $('#CallSlipId').val(), ContractorId: contractorId };
        $.ajax({
            url: baseURL + "Contractor/SendPicture",
            data: JSON.stringify(request),
            dataType: 'json',
            type: 'POST',
            contentType: 'application/json',
            success: function (msg) {
                var data;
                if (msg.hasOwnProperty("d"))
                    data = msg.d;
                else
                    data = msg;

                if (data.success) {
                    Notify(data.message, 'success');
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
    else {
        Notify("Please select a contractor first.", 'error');
    }
}

function CheckIfUrgentDetailsExist(statusId) {
    if ($('#CustomerNoteDetails').val() != "" || $('#StoreUrgentNoteDetails').val() != "") {
        $('#divCustomerUrgentNotes').dialog({
            title: "Urgent Customer Notice",
            resizable: true,
            width: $(window).width() - 600,
            height: $(window).height() - 300,
            modal: true,
            closeOnEscape: false,
            buttons: [
                {
                    text: "OK",
                    id: "btnOK",
                    click: function () {
                        if (statusId == 26) {
                            ShowPrepaidAmountDialog();
                        }
                        else {
                            console.log("Calling UpdateJob");
                            UpdateJob();
                        }
                        $('#divCustomerUrgentNotes').dialog('close');
                    }
                }
            ],
            open: function () {
                StyleWarningDiagle($(this));
                $(".ui-dialog-titlebar-close").hide();
                var notes = "";
                if ($('#CustomerNoteDetails').val() != "") {
                    var cnotes = $('#CustomerNoteDetails').val().replace(/\r?\n/g, '<br/>')
                    notes += "<strong style='font-size:15px;'>Customer Urgent Notes:</strong><br /><br />";
                    notes += cnotes;
                }
                if ($('#StoreUrgentNoteDetails').val() != "") {
                    var snotes = $('#StoreUrgentNoteDetails').val().replace(/\r?\n/g, '<br/>')
                    notes += "<br /><br /><strong style='font-size:15px;'>Store Urgent Notes:</strong><br /><br />";
                    notes += snotes;
                }
                $(this).html(notes);
                $('#btnOK').removeAttr("class");
                $('#btnOK').addClass("btn btn-success");
            },
            close: function () {
                $('#divCustomerUrgentNotes').dialog('close');
            }
        });
    }
    else {
        if (statusId == 26) {
            ShowPrepaidAmountDialog()
        }
        else {
            console.log("Calling UpdateJob");
            UpdateJob();
        }
    }
}

function ShowPrepaidAmountDialog (){
    getContractorListPrepaid();
    $('#PrepaidJobWrapupNotesPopup').dialog({
        title: "Prepaid Amount",
        resizable: true,
        width: '500px',
        modal: true,
    });
}

function RefreshJobNotesOnSP() {
    GetNotesByJobId();
}

function UpdateServicePanelForMarkup() {
    var request = { JobId: $("#CallSlipId").val() };
    $.ajax({
        type: "POST",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Invoice/GetInvoiceInfoToUpdateSP",
        data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                UpdateTabColor(data.InvoiceExist, data.IsApproved);
                UpdateStatusOnSP(data.CurrentStatus, data.ChangedBy, data.JobStatusId);
                ShowJobNotes();
            } else {
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}

function UpdateTabColor(InvoiceExist, IsApproved) {
    if (InvoiceExist) {
        if (IsApproved) {
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
}

function UpdateStatusOnSP(CurrentStatus, ChangedBy, JobStatusId) {
    $('#CurrentStatus').html("");
    $('#ChangedBy').html("");
    $('#jStatusId').html("");

    $('#CurrentStatus').html(CurrentStatus);
    $('#ChangedBy').html(ChangedBy);
    $('#jStatusId').val(JobStatusId);
}

function UpdateContrFromSP() {
    UpdateContractorInfo();
    if ($('#WarrantyStateChanged').val() == "1") {
        UpdateWarrantyCheck();
    }
}

function UpdateContrNTEFromSP() {
    UpdateContractorNteInfo();
}


function UpdateWarrantyCheck() {
    var request = { JobId: $("#CallSlipId").val(), IsWarrantyJob: $('#chkIsWarrantyJob').is(":checked") };
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json, charset=utf-8",
        url: baseURL + "Home/UpdateWarrantyCheck",
        data: JSON.stringify(request),
        global:false,
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            } else
                data = msg;
            if (data.success) {
                $('#chkIsWarrantyJob').is(":checked") ? $('#IsWarrantyJob').val("1") : $('#IsWarrantyJob').val("0");
                $('#WarrantyStateChanged').val("0");
            }
        },
        error: function () {
            CommunicationError();
        }
    });
}