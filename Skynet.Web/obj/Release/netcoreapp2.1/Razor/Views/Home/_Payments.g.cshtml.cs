#pragma checksum "C:\Work\Skynet 2.0\Skynet.Web\Views\Home\_Payments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "edef94b0be9169e721619cddc29387d262dd6155"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Payments), @"mvc.1.0.view", @"/Views/Home/_Payments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_Payments.cshtml", typeof(AspNetCore.Views_Home__Payments))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Work\Skynet 2.0\Skynet.Web\Views\_ViewImports.cshtml"
using Skynet.Web;

#line default
#line hidden
#line 2 "C:\Work\Skynet 2.0\Skynet.Web\Views\_ViewImports.cshtml"
using Skynet.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edef94b0be9169e721619cddc29387d262dd6155", @"/Views/Home/_Payments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a3c382a9203d8a39d7ac0f9908291a86ad1608b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Payments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "6", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "7", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "8", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("AmountForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 102, true);
            WriteLiteral("<table class=\"details\" style=\"font-size:12px;\">\r\n\r\n    <tr>\r\n        <td colspan=\"100%\">\r\n            ");
            EndContext();
            BeginContext(102, 1490, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3213fb019b904e50b8e18e8ca05d47ca", async() => {
                BeginContext(124, 376, true);
                WriteLiteral(@"
                <table class=""details"">
                    <tr style=""display:none;""><td><input id=""CreditCardId"" type=""hidden"" value="""" /></td></tr>
                    <tr>
                        <td>
                            &nbsp; &nbsp; <select class=""form-control"" id=""PaymentMethodId"" name=""PaymentMethodId"">
                                                ");
                EndContext();
                BeginContext(500, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9eccdadc1a144cc58fded922f7e4b96e", async() => {
                    BeginContext(518, 11, true);
                    WriteLiteral("Master Card");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(538, 50, true);
                WriteLiteral("\r\n                                                ");
                EndContext();
                BeginContext(588, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10a6998081784db5aba03f513501e982", async() => {
                    BeginContext(606, 4, true);
                    WriteLiteral("AMEX");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(619, 50, true);
                WriteLiteral("\r\n                                                ");
                EndContext();
                BeginContext(669, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e932f2b5c4f4b6594be470e916df45f", async() => {
                    BeginContext(687, 4, true);
                    WriteLiteral("Cash");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(700, 50, true);
                WriteLiteral("\r\n                                                ");
                EndContext();
                BeginContext(750, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0764c7f4cfe4a1c966c85896acfc3b7", async() => {
                    BeginContext(768, 5, true);
                    WriteLiteral("Check");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(782, 50, true);
                WriteLiteral("\r\n                                                ");
                EndContext();
                BeginContext(832, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0088bb5e4561409697704ddeb2237843", async() => {
                    BeginContext(850, 8, true);
                    WriteLiteral("Discover");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(867, 50, true);
                WriteLiteral("\r\n                                                ");
                EndContext();
                BeginContext(917, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c079c80cf87b43988e7ce86c672f3784", async() => {
                    BeginContext(935, 8, true);
                    WriteLiteral("Billing ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(952, 50, true);
                WriteLiteral("\r\n                                                ");
                EndContext();
                BeginContext(1002, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77764bcfb56f458caced8c234130cde7", async() => {
                    BeginContext(1020, 5, true);
                    WriteLiteral("Multi");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1034, 55, true);
                WriteLiteral("\r\n                                          </select>  ");
                EndContext();
                BeginContext(1189, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(1489, 96, true);
                WriteLiteral("                        </td>\r\n                    </tr>\r\n                </table>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1592, 2872, true);
            WriteLiteral(@"
        </td>
    </tr>

</table>
<br />


<div id=""PaymentsDiv"">
    <table style=""font-size:12px;"" id=""PaymentsGrid"" class=""table table-hover"">
        <thead style=""background-color:#dfe0e6;"">
            <tr>
                <th>Amount</th>
                <th>Date Paid</th>
                <th>Payment Method</th>
                <th>Approval</th>
                <th>Notes</th>
                <th>Collected By</th>
                <th>Contractor PO</th>
            </tr>
        </thead>
        <tbody style=""background-color:white;"" id=""tblBodyPaymentsGrid""></tbody>
    </table>
</div>
<div id=""CardsDiv"">
    <table style=""font-size:12px;"" id=""CardsGrid"" class=""table table-hover"">
        <thead style=""background-color:#dfe0e6;"">
            <tr>
                <th>Name On Card</th>
                <th>Card Number</th>
                <th>Expiration Date</th>
                <th></th>
            </tr>
        </thead>
        <tbody style=""background-color:white;"" id=");
            WriteLiteral(@"""tbodyCreditCards""></tbody>
    </table>
</div>
<style>
    .paymentNormalField {
        width: 130px;
    }

    #PaymentStateId {
        width: 130px;
    }

    #PaymentMethodId {
        width: 130px;
    }
</style>
<script>
    $(document).ready(function () {

        $(""#CardNumber"").keyup(function () {
            this.value = KeepCreditCardFormatOnly(this.value);
        });


        $(""#Amount"").keyup(function () {
            this.value = KeepDigitsOnly(this.value);
        });



        //Function to save card Information
        $('#SaveCashPayment').click(function () {
            var callslipId = $('#CallSlipId').val();
            var CreditCardFormValid = $('#CreditCardForm').valid();
            var AmountFormValid = $('#AmountForm').valid();
            if (CreditCardFormValid && AmountFormValid) {
                var request = {
                    CallSlipId: callslipId, Amount: $('#Amount').val(), ExistingCard: ""False"",
                    NameOnC");
            WriteLiteral(@"ard: $('#NameOnCard').val(), AddressOnCard: $('#AddressOnCard').val(), CardCity: $('#CardCity').val(),
                    CardZip: $('#CardZip').val(), StateId: $('#StateId').val(), CRVNumber: $('#CRVNumber').val(),
                    CreditCardExpireMonth: $('#CreditCardExpireMonth').val(), CreditCardExpireYear: $('#CreditCardExpireYear').val(),
                    CardNumber: $('#CardNumber').val(), CreditCardType: $('#PaymentMethodId option:selected').text(),
                    PaymentMethodId: $('#PaymentMethodId').val(), ReceiptNumber: $('#ccReceiptNumber').val(), Notes: $('#PaymentNotes').val(), PaidDate: $('#PaidDate').val()
                };
                $.ajax({
                    type: ""POST"",
                    contentType: ""application/json, charset=utf-8"",
                    url: """);
            EndContext();
            BeginContext(4465, 37, false);
#line 105 "C:\Work\Skynet 2.0\Skynet.Web\Views\Home\_Payments.cshtml"
                     Write(Url.Content("~/Home/SaveCashPayment"));

#line default
#line hidden
            EndContext();
            BeginContext(4502, 3501, true);
            WriteLiteral(@""",
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty(""d"")) {
                            data = msg.d;
                        } else
                            data = msg;
                        if (data.success) {
                            Notify(data.message, 'success');
                            ResetCardPaymentFields();
                            ShowJobNotes();
                            GetPaymentsByJobId(callslipId);
                            GetPaymentMethodsByJobId(callslipId);
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

                $('#CreditCardForm .required').each(function () ");
            WriteLiteral(@"{
                    $(this).attr('placeholder', 'Field is required');
                });
                $('#AmountFormValid .required').each(function () {
                    $(this).attr('placeholder', 'Field is required');
                });
            }
            //add return statement
            return true;
        });


        $('#SaveCardPayment').click(function () {

            var cardNumber = $('#CardNumber').val();
            if ($('#cardNotRun').is("":checked"") == true) {
                $('#CardNumber').removeClass(""required"");
                $('#CardNumber').rules('remove');
                $('#CRVNumber').removeClass(""required"");
                $('#CRVNumber').rules('remove');
                $('#NameOnCard').removeClass(""required"");
                $('#NameOnCard').rules('remove');
                cardNumber = """";
                NameOnCard = """";
                CRVNumber = """";
            }
            else {
                $('#CardNumber').addClass(""r");
            WriteLiteral(@"equired"");
                $('#CRVNumber').addClass(""required"");
            }

            var CreditCardFormValid = $('#CreditCardForm').valid();
            var AmountFormValid = $('#AmountForm').valid();
            if (CreditCardFormValid && AmountFormValid) {

                var request = {
                    CardId: $('#CreditCardId').val(), CallSlipId: $('#CallSlipId').val(), Amount: $('#Amount').val(),
                    NameOnCard: $('#NameOnCard').val(), AddressOnCard: $('#AddressOnCard').val(), CardCity: $('#CardCity').val(),
                    CardZip: $('#CardZip').val(), StateId: $('#PaymentStateId option:selected').val(), CRVNumber: $('#CRVNumber').val(),
                    CreditCardExpireMonth: $('#CreditCardExpireMonth  option:selected').text(), CreditCardExpireYear: $('#CreditCardExpireYear').val(),
                    //CardNumber: $('#CardNumber').val(),
                    CardNumber: $('#hdnCreditCardNumber').val(),
                    CardNotRun: $('#cardNotRun').i");
            WriteLiteral(@"s(':checked'), CreditCardType: $('#PaymentMethodId option:selected').text(),
                    PaymentMethodId: $('#PaymentMethodId').val(), ReceiptNumber: $('#ccReceiptNumber').val(), Notes: $('#PaymentNotes').val(), PaidDate: $('#PaidDate').val()
                };
                $.ajax({
                    type: ""POST"",
                    contentType: ""application/json, charset=utf-8"",
                    url: """);
            EndContext();
            BeginContext(8004, 40, false);
#line 178 "C:\Work\Skynet 2.0\Skynet.Web\Views\Home\_Payments.cshtml"
                     Write(Url.Content("~/Home/ProcessCardPayment"));

#line default
#line hidden
            EndContext();
            BeginContext(8044, 2395, true);
            WriteLiteral(@""",
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty(""d"")) {
                            data = msg.d;
                        } else
                            data = msg;
                        if (data.success) {
                            Notify(data.message, 'success');
                            ResetCardPaymentFields();
                            ShowJobNotes();
                            GetPaymentsByJobId();
                            GetPaymentMethodsByJobId();
                            //SelectJob(data.JobId);
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
");
            WriteLiteral(@"            //else {
            //    if ($('#cardNotRun').is("":checked"") == false) {
            //        $('#CreditCardForm .required').each(function () {
            //            $(this).attr('placeholder', 'Field is required');
            //        });
            //        $('#AmountFormValid .required').each(function () {
            //            $(this).attr('placeholder', 'Field is required');
            //        });
            //    }
            //}
            //add return statement
            return true;
        });



        //FUNCTION TO SAVE CHECK PAYMENT
        $('#SaveCheckPayment').click(function () {

            var AmountFormValid = $('#AmountForm').valid();
            var CheckFormValid = $('#CheckForm').valid();
            if (CheckFormValid && AmountFormValid) {
                var request = {
                    CallSlipId: $('#CallSlipId').val(), PaymentMethodId: $('#PaymentMethodId').val(),
                    Amount: $('#Amount').val(), CheckNu");
            WriteLiteral(@"mber: $('#CheckNumber').val(),
                    CheckPaidDate: $('#CheckPaidDate').val(), ReceiptNumber: $('#ccReceiptNumber').val(), Notes: $('#PaymentNotes').val()
                };
                $.ajax({
                    type: ""POST"",
                    contentType: ""application/json, charset=utf-8"",
                    url: """);
            EndContext();
            BeginContext(10440, 38, false);
#line 233 "C:\Work\Skynet 2.0\Skynet.Web\Views\Home\_Payments.cshtml"
                     Write(Url.Content("~/Home/SaveCheckPayment"));

#line default
#line hidden
            EndContext();
            BeginContext(10478, 2181, true);
            WriteLiteral(@""",
                    data: JSON.stringify(request),
                    success: function (msg) {
                        var data;
                        if (msg.hasOwnProperty(""d"")) {
                            data = msg.d;
                        } else
                            data = msg;
                        if (data.success) {
                            Notify(data.message, 'success');
                            ShowJobNotes();
                            //SelectJob(data.JobId);
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
          ");
            WriteLiteral(@"      });
                $('#AmountForm .required').each(function () {
                    $(this).attr('placeholder', 'Field is required');
                });
            }
        });

        $('#CardNumber').focusout(function () {

            var cardNumber = $('#CardNumber').val();
            if (cardNumber.length > 5)//minimum/maximum numbers to be displayed are 4.
            {
                $('#hdnCreditCardNumber').val(cardNumber);
                //cardNumber = cardNumber.replace(""/\d(?=\d{4})/mg"", ""*"");
                cardNumber = cardNumber.replace(/.(?=.{4,}$)/g, '*')
                $('#CardNumber').val(cardNumber);
            }
            else {
                $('#hdnCreditCardNumber').val("""");
            }
        });
        $('#CardNumber').focusin(function () {

            var cardNumber = $('#hdnCreditCardNumber').val();
            if (cardNumber != """") {
                //$('#hdnCreditCardNumber').val(cardNumber);
                //cardNumber = cardN");
            WriteLiteral("umber.replace(\"\\d(?=\\d{4})\", \"*\");\r\n                $(\'#CardNumber\').val(cardNumber);\r\n            }\r\n        });\r\n    });\r\n</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
