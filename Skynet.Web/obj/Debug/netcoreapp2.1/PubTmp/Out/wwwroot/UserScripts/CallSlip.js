$('#imgUpdateCustomerPopupShowClSlp').click(function () {

    //if (this.checked) {
    updateCustomerPopupShow();
    //$('#CustomerUpdateDialog').dialog({
    //    title: 'Customer Update Status',
    //    resizeable: true,
    //    width: 400,
    //    modal: true

    //});
    //}
});

//-----------------------Function to fill update customer details in popup in call slip--------------------------
function setUpdateCustomerDetailsInCalSlip(customer) {
    
    //$("#PreferedCommunicationMethod").prop("checked", customer.PreferedCommunicationMethod);
    //$("#PreferedCommunicationMethod").prop("checked", customer.SendCustomerUpdatesDetails);
    $("#updateCustFNamePrimaryClSLp").val(customer.customerNotificationName);
    $("#updateCustLNamePrimaryClSLp").val(customer.customerNotificationLastName);
    $("#updateCustTitlePrimaryClSLp").val(customer.customerNotificationTitle);
    $("#updateCustEmailPrimaryClSLp").val(customer.customerNotificationEmail);
    if (customer.customerNotificationEmail != null && customer.customerNotificationEmail != "") {
        $("#popupDescriptionNote").show();
    }
    else {
        $("#popupDescriptionNote").hide();
    }
    
    var otherFirstNames = customer.OtherFirstName.split(',');
    var otherLastNames = customer.OtherLastName.split(',');
    var otherTitles = customer.OtherTitle.split(',');
    var otherEmails = customer.otherEmails.split(',');
    var f = 1;
    $(".updateCustomerOthersRow").each(function () {
        if (f > 3) {
            $(this).remove();
        }
        f++;
    });
    var totalRows = otherEmails.length;
    for (i = 1; i <= totalRows; i++) {
        if (i > 3) {
            $('#updateCustomrDetailsTable').append("<tr class='updateCustomerOthersRow'><td><input type='text' id='updateCustomerFirstName' class='updateCustomerFirstName' /></td><td><input type='text' id='updateCustomerLastName' class='updateCustomerLastName' /></td><td><input type='text' id='updateCustomerTitle' class='updateCustomerTitle' /></td><td><input type='text' id='updateCustomerEmailAddress' class='updateCustomerEmailAddress' /></td><td></td></tr>");
        }
    }
    
    var i = 0;
    $(".updateCustomerFirstName").each(function () {
        
        $(this).val(otherFirstNames[i]);
        $(this).parents("tr").find(".updateCustomerLastName").val(otherLastNames[i]);
        $(this).parents("tr").find(".updateCustomerTitle").val(otherTitles[i]);
        $(this).parents("tr").find(".updateCustomerEmailAddress").val(otherEmails[i]);
        i++;
        
    });
    $("#updateCustomerOnCreate").attr("checked", customer.SendUpdateOnJobCreated);
    $("#updateCustomerOnAssign").attr("checked", customer.SendUpdateOnAssigned);
    $("#updateCustomerOnDispatch").attr("checked", customer.SendUpdateOnJobDispatched);
    $("#updateCustomerOnDelay").attr("checked", customer.SendUpdateOnJobDelay);

    $("#updateCustomerOnComplete").attr("checked", customer.SendUpdateOnJobCompleted);
    $("#updateCustomerInPortal").attr("checked", customer.SendUpdateInCustomerPortal);
    $("#updateCustomerInEmail").attr("checked", customer.SendUpdateInCustomerEmail);

    //$("#updateCustomerOnReturn").attr("checked", customer.SendUpdateOnReturn);
    //$("#updateCustomerOnPartsOrder").attr("checked", customer.SendUpdateOnPartsOnOrder);

    var otherEmails = customer.otherEmails;
    if (otherEmails != null && otherEmails != "") {
        var arrayOtherEmails = otherEmails.split(",");
        var i = 0;
        $('.otherEmailsCallSlip').each(function () {

            var v = $(this).val();

            if ($(this).val() == "" && arrayOtherEmails[i] != null && arrayOtherEmails[i] != "" && arrayOtherEmails[i] != 0) {
                $(this).val(arrayOtherEmails[i]);
            }
            i++;
        });
    }
}

function CreateOrUpdateCallSlip(cub) {
   
    
    var isValid = false;
    var primaryFirstName = "";
    var primaryLastName = "";
    var primaryTitle = "";
    var primaryEmail = "";
    
    primaryFirstName = $("#updateCustFNamePrimaryClSLp").val();
    primaryLastName = $("#updateCustLNamePrimaryClSLp").val();
    primaryTitle = $("#updateCustTitlePrimaryClSLp").val();
    primaryEmail = $("#updateCustEmailPrimaryClSLp").val();

    var OtherFirstNames = "";
    var OtherLastNames = "";
    var OtherTitles = "";
    var OtherEmails = "";
    $(".updateCustomerOthersRow").each(function () {
        
        var OtherFirstName = $(this).find(".updateCustomerFirstName").val();
        var OtherLastName = $(this).find(".updateCustomerLastName").val();
        var OtherTitle = $(this).find(".updateCustomerTitle").val();
        var OtherEmail = $(this).find(".updateCustomerEmailAddress").val();

        if (OtherEmail != null && OtherEmail != "") {
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
    var otherEmail = "";
    $('.otherEmailsCallSlip').each(function () {
        if ($(this).val() != null && $(this).val() != "") {
            otherEmail += $(this).val();
            otherEmail += ",";
        }
    });
    otherEmail = otherEmail.slice(0, -1);
    var emergency = $('#IsEmergency').is(':checked');
    var id = $('#CustomerId').val();
    var stores = $('#CustomerType').val() == '2' ? "" : $('#CustomerType').val();
    if ($('#projs').is(":visible") && $("#projs").val() == '' && $('#regularJob').is(":visible") && !$("#regularJob").is(':checked')) {
        Notify('Please Select a Project or Check the Regular Job.', 'error');
    }
    else{
        var request = {
            
            CallSlipId: $('#CallSlipId').val(),
            CustomerId: id,
            ProjectId: $("#projs").val(),
            isRegularJob: $("#regularJob").is(':checked'),
            AddressId: $('#AddressId').val(),
            StoreId: $('#StoreId').val(),
            POId: $('#POId').val(),
            CustomerType: $('#CustomerType').val(),
            IsAutoJob: $('#cbAutoJob').is(':checked'),
            JobTypeId: $('#JobTypeId').val(),
            Salutation: $('#Salutation').val(),
            CustomerName: escapeHTML($('#CustomerName').val()),
            Stores: stores,
            BookedBy: $('#BookedBy').val(),
            ContactPerson: escapeHTML($('#ContactPerson').val()),
            CallInBy: $('#CallInBy').val(),
            PaymentMethodId: $('#PaymentMethodId').val(),
            Email: $('#Email').val(),
            BuzzerCode: $('#BuzzerCode').val(),
            PO: $('#PO').val(),
            WorkOrder2: $('#WorkOrder2').val(),
            Year: $('#Year').val(),
            Make: $('#Make').val(),
            Model: $('#Model').val(),
            Color: $('#Color').val(),
            AdTypeId: $('#AdTypeId').val(),
            EquipmentId: $('#EquipmentId').val(),
            Day: $('#Day').val(),
            ServiceDate: $('#ServiceDate').val(),
            ServiceTimeFrom: $('#ServiceTimeFrom').val(),
            ServiceTimeTo: $('#ServiceTimeTo').val(),
            ExpectedTime: $('#ExpectedTime').val(),
            JobDescription: $('#JobDescription').data('tEditor').value(),  // escapeHTML($('#JobDescription').val()),
            SpecialInstructions: escapeHTML($('#taSpecialInstructions').val()),
            IsEmergency: $('#IsEmergency').is(":checked"),
            Address: escapeHTML($('#Address').val()),
            Phone: $('#Phone').val(),
            City: escapeHTML($('#City').val()),
            Zip: $('#Zip').val(),
            StateId: $('#StateId').val(),
            CountyId: $('#CountyId').val(),
            CrossStreet: escapeHTML($('#CrossStreet').val()),
            AddressType: $('#AddressType').val(),
            IsCub: cub,
            NTEAmount: $('#NTEAmount').val(),
            AlternatePhone: $('#AlternatePhone').val(),
            ServiceAddressFax: $('#ServiceAddressFax').val(),
            BillingAddressType: $('input[type="radio"][name="BillingAddress"]:checked').val(),
            ExistingAddressId: $('#ExistingBillingAddresses').val(),
            BillToAddress: escapeHTML($('#BillToAddress').val()),
            BillToCrossStreet: escapeHTML($('#BillToCrossStreet').val()),
            BillToZip: $('#BillToZip').val(),
            BillToCity: escapeHTML($('#BillToCity').val()),
            BillToCountryId: $('#BillToCountryId').val(),
            BillToCountyId: $('#BillToCountyId').val(),
            BillToStateId: $('#BillToStateId').val(),
            BillToPhone: $('#BillToPhone').val(),
            BillToFax: $('#BillToFax').val(),
            BillToAddressType: $('#BillToAddressType').val(),
            CountryId: $("#CountryId").val(),
            AdTypeOtherOption: $('#AdTypeOtherOption').val(),
            AdTypeWebSource: $('#AdTypeWebSource').val(),
            PreferedCommunicationMethod: $('#PreferedCommunicationMethod').is(":checked"),
            //NotificationName: $('#NotificationName').val(),
            //NotificationEmail: $('#NotificationEmail').val(),
            //updateOnCreated: $('#chkOnCreated').is(":checked"),
            //updateOnCompleted: $('#chkOnCompleted').is(":checked"),
            //OtherEmails: otherEmail,
            PrimaryFirstName: primaryFirstName, PrimaryLastName: primaryLastName, PrimaryTitle: primaryTitle, PrimaryEmail: primaryEmail, OtherFirstNames: OtherFirstNames, OtherLastNames: OtherLastNames,
            OtherTitles: OtherTitles, OtherEmails: OtherEmails,
            UpdateOnCreate: $("#updateCustomerOnCreate").is(":checked"),
            UpdateOnAssign: $("#updateCustomerOnAssign").is(":checked"),
            UpdateOnDispatch: $("#updateCustomerOnDispatch").is(":checked"),
            UpdateOnDelay: $("#updateCustomerOnDelay").is(":checked"),
            UpdateOnComplete: $("#updateCustomerOnComplete").is(":checked"),
            UpdateInCustomerPortal: $("#updateCustomerInPortal").is(":checked"), UpdateInCustomerEmail: $("#updateCustomerInEmail").is(":checked")
            //UpdateOnReturn: $("#updateCustomerOnReturn").is(":checked"), UpdateOnPartsOnOrder: $("#updateCustomerOnPartsOrder").is(":checked")
        };
        $.ajax({
            //url: '@Url.Content("~/CallSlip/CreateCallSlip")',
            url: baseURL + "CallSlip/CreateCallSlip",
            type: 'POST',
            contentType: 'application/json, charset=utf-8',
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

                    ShowOptions(data.CallSlipId);
                    //$('#CallSlipId').val(data.CallSlipId);
                    ResetFields();
                    ClearDropDownsOnClearAndAfterSavingCallSlip();
                    ResetCustomerId();
                    $('#ExpectedTime').val("00:00");
                    refreshcubGrid();
                    $('.documentlist').html("");
                    $('.t-upload-files').remove();
                    $("#addDocumentToCallslip").prop('value', 'Select');
                    $('#JobDescription').data('tEditor').value("");
                    $("#ServiceDate").val(moment().format("MM/DD/YYYY"));

                } else {
                    Notify(data.message, 'error');
                }
            },
            error: function () {
                CommunicationError();
            }
        });
    }
   // ShowOptions();
}

function ShowOptions(jobId) {
    var JobId = jobId;
    $.ajax({
        //url: '@Url.Content("~/CallSlip/CreateCallSlip")',
        url: baseURL + "Home/GetLastJobId",
        type: 'POST',
        contentType: 'application/json, charset=utf-8',
        //data: JSON.stringify(request),
        success: function (msg) {
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                
                //Notify(data.message, 'success');
                JobId = data.job;
            } else {
                Notify(data.message, 'error');
            }
        },
        error: function () {
            CommunicationError();
        }
    });


    var table = "<table  class='table table-advance' style='margin:5px 0px 0px 9px;width:95%;'><tbody>";
    table += "<tr><td colspan='2'><b><span style = 'color:black;'>Job # " + jobId + "</span></b></td></tr>";
    table += "<tr><td colspan='2'><b><span style = 'color:black;'>Call slip sent to dispatch board successfully.</span></b></td></tr>"
    table += "</tbody></table>";
    

    //var table = "<p>Call slip added to the cub list successfully." + " : " + "Call slip sent to dispatch board successfully.</p>";
    //var jobId = $('#CallSlipId').val();
    $("<div id='divShowOptions'></div>").dialog({
        width: 400,
        height: 200,
        title: "Call Slip Created",
        modal: true,
        buttons: [
            {
                text: "Edit Job ",
                id: "EditJobbtn",
                click: function () {
                    location.href = baseURL + "Home/Index?Id=" + JobId;
                }
            },
            {
                text: "Return To Dashboard",
                id: "DispatchBoardbtn",
                click: function () {
                    location.href = baseURL + "Home/Index";
                }
            }
        ],
        open: function () {
            StyleApplicationDiagle($(this));
            $(this).html(table);
            $("#TechContractorsbtnConfirm").removeAttr('class');
            $("#TechContractorsbtnCancel").removeAttr('class');
            $("#TechContractorsbtnConfirm").addClass("btn btn-primary btn-large");
            $("#TechContractorsbtnCancel").addClass("btn btn-danger btn-large");
        }
    });

}












//--------------------------Function to add a new line in Update Customer Popup----------------------------------
function btnAddNewLineUpdateCustCalSlip() {
    
    $('#updateCustomrDetailsTable').append("<tr class='updateCustomerOthersRow'><td><input type='text' id='updateCustomerFirstName' class='updateCustomerFirstName' /></td><td><input type='text' id='updateCustomerLastName' class='updateCustomerLastName' /></td><td><input type='text' id='updateCustomerTitle' class='updateCustomerTitle' /></td><td><input type='text' id='updateCustomerEmailAddress' class='updateCustomerEmailAddress' /></td><td></td></tr>");
}

// function to get only update customer details.
function GetUpdateCustomerDetailsInCallSlip(CustomerId) {
    
    var request = { CustomerId: CustomerId };
    $.ajax({
        type: "POST",
        contentType: "application/json charset = utf-8",
        url: baseURL + "Customer/GetCustomerUpdateDetailsCallSlip",
        data: JSON.stringify(request),
        success: function (msg) {
            
            var data;
            if (msg.hasOwnProperty("d")) {
                data = msg.d;
            }
            else
                data = msg;
            if (data.success) {
                setUpdateCustomerDetailsInCalSlip(data.customerUpdateDetail);
            }
            else {
                Notify(data.message, 'error');
            }
        },
        onComplete: function () {

        },
        error: function () {
            CommunicationError();
        }
    });
}


