#pragma checksum "C:\Work\Skynet 2.0\Skynet.Web\Views\Home\_Estimates.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f78d3f2f555c50a71e613e3e87a3c95c02bd4d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Estimates), @"mvc.1.0.view", @"/Views/Home/_Estimates.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_Estimates.cshtml", typeof(AspNetCore.Views_Home__Estimates))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f78d3f2f555c50a71e613e3e87a3c95c02bd4d1", @"/Views/Home/_Estimates.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a3c382a9203d8a39d7ac0f9908291a86ad1608b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Estimates : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("PartsForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(187, 1434, true);
            WriteLiteral(@"<style>
</style>
<button id=""reviewEstimates"" class=""btn btn-success"" style=""background:#fb9800; font-size:11px; float:right;"" onclick=""reviewEstimates();"">Submit For Review</button>
<a onclick=""PurchaseOrderByEstimate(); return false;"" target=""_blank"" style=""color: #fff; font-size:11px; float: right; margin-right:5px"" id=""CreatePOButton"" class=""btn btn-primary"">Create PO By Estimate</a>
<button type=""button"" id=""ShowPartPanel"" class=""btn btn-success"" style=""font-size:11px;"">Add line item</button>
<button id=""emailEstimate"" style=""font-size:11px;"" class=""btn btn-success"">Email</button>

<a onclick=""RedirectToEstimate();"" target=""_blank"" style=""color: #fff; font-size:11px;""  id=""printEstimate"" class=""btn btn-primary"">Print</a><br /><br />


<div class=""emailPanel"" style=""display: none;"">
    <table>
        <tr>
            <td><span style=""color: #fff;"">Enter Email</span></td>
            <td>
                <input type=""text"" name=""EstimateEmail"" id=""EstimateEmail"" style=""width: 245px; font-s");
            WriteLiteral(@"ize:12px;"" />
            </td>
            <td>
                <button type=""button"" onclick=""SendEstimate()"" id=""btnSendEstimateEmail"" class=""btn btn-success"" style=""font-size:11px;"">Send</button>
            </td>
        </tr>
    </table>
</div>
<span style=""font-size:11px; color:#d33838;"" id=""stateExempt""></span>
<div id=""PartsPanel"" style=""display: none; padding: 10px 0;"">
    <hr />
    ");
            EndContext();
            BeginContext(1621, 5085, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52cc9aba1a83484491ab605128ad44d4", async() => {
                BeginContext(1642, 184, true);
                WriteLiteral("\r\n        <table style=\"color: white;\">\r\n            <tr>\r\n                <td colspan=\"2\">\r\n                    <input type=\"hidden\" id=\"PartIdOfEstimate\" name=\"PartIdOfEstimate\" />\r\n");
                EndContext();
                BeginContext(1915, 429, true);
                WriteLiteral(@"                    <input type=""hidden"" id=""TotalPartQuantity"" name=""TotalPartQuantity"" />
                    <label id=""lblPartFound"" style=""display: none;""></label>
                    <input type=""hidden"" id=""APTAPrice"" name=""APTAPrice"" />
                </td>
            </tr>
            <tr>
                <td>Type</td>
                <td>
                    <select id=""PartType"">
                        ");
                EndContext();
                BeginContext(2344, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fc2d42cbc5644a79c63e801eb75d038", async() => {
                    BeginContext(2362, 5, true);
                    WriteLiteral("Parts");
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
                BeginContext(2376, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(2402, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82439dacecb94c9b892b2e09c2ecc4ae", async() => {
                    BeginContext(2420, 5, true);
                    WriteLiteral("Labor");
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
                BeginContext(2434, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(2460, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a51b7315e4c348ae915568b19cc855be", async() => {
                    BeginContext(2478, 11, true);
                    WriteLiteral("Trip Charge");
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
                BeginContext(2498, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(2524, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f02eaafdfb4643f987acb9d046aa2a19", async() => {
                    BeginContext(2542, 5, true);
                    WriteLiteral("Other");
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
                BeginContext(2556, 217, true);
                WriteLiteral("\r\n                    </select>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>Part No:</td>\r\n                <td>\r\n                    <input type=\"text\" id=\"Name\" name=\"Name\" />\r\n\r\n");
                EndContext();
                BeginContext(3174, 1686, true);
                WriteLiteral(@"                </td>
            </tr>
            <tr style=""display:none;"">
                <td>Description</td>
                <td>
                    <textarea style=""width: 98%; height: 60px;"" id=""PartDescription"" name=""PartDescription"" class=""required""></textarea>
                </td>
            </tr>
            <tr>
                <td>
                    Margin %:
                </td>
                <td>
                    <input type=""text"" id=""partsMarkup"" name=""partsMarkup"" class=""onlyNumberAllowed"" />
                </td>
            </tr>
            <tr>
                <td>
                    Discount %:
                </td>
                <td>
                    <input type=""text"" id=""partsDiscount"" name=""partsDiscount"" class=""onlyNumberAllowed"" />
                </td>

                <td class=""purchasePrice"">Purchase Price:</td>
                <td>
                    <input type=""text"" id=""purchasePrice"" name=""purchasePrice"" class=""purchasePrice o");
                WriteLiteral(@"nlyNumberAllowed"" disabled=""disabled"" />
                </td>
            </tr>
            <tr style=""display:none;"">
                <td>Labor Cost:</td>
                <td>
                    <input type=""text"" id=""laborOrPartCost"" name=""laborOrPartCost"" class=""onlyNumberAllowed"" />

                </td>
            </tr>
            <tr style=""display:none;"">
                <td>Part Cost:</td>
                <td>
                    <input type=""text"" id=""NewPartCost"" name=""NewPartCost"" class=""onlyNumberAllowed"" />

                </td>
            </tr>
            <tr>
                <td>Price:</td>
                <td>
");
                EndContext();
                BeginContext(5071, 432, true);
                WriteLiteral(@"                    <input type=""text"" id=""PartPrice"" maxlength=""8"" name=""PartPrice"" class=""calculator number required"" autocomplete=""Off"" />
                </td>
                <td class=""sellingPrice"">Selling Price:</td>
                <td>
                    <input type=""text"" id=""sellingPrice"" name=""sellingPrice"" class=""sellingPrice onlyNumberAllowed"" disabled=""disabled"" />
                </td>
            </tr>
");
                EndContext();
                BeginContext(5786, 913, true);
                WriteLiteral(@"            <tr>
                <td>Quantity</td>
                <td>
                    <input type=""text"" id=""PartQuantity"" maxlength=""8"" name=""PartQuantity"" class=""number required"" />
                </td>

                <td class=""profitOnParts"">Profit:</td>
                <td>
                    <input type=""text"" id=""PartPofit"" name=""PartPofit"" class=""profitOnParts onlyNumberAllowed"" disabled=""disabled"" />
                </td>
            </tr>
            <tr>
                <td colspan=""2"">
                    <div class=""buttons-align-right"">
                        <button type=""button"" class=""btn btn-success"" style=""font-size:11px;"" id=""AddPart"">Save</button>
                        <button type=""button"" id=""HidePartPanel"" style=""font-size:11px;"" class=""btn"">Cancel</button>
                    </div>
                </td>
            </tr>
        </table>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6706, 18062, true);
            WriteLiteral(@"
    <hr />
</div>

<div style=""max-height: 500px; overflow: auto; margin-top: 15px;"">
    <table id=""PartsGrid"" class=""table table-hover"" style=""font-size:12px; border-bottom:groove; max-width:100%;"">
        <thead style=""background-color:#dfe0e6;"">
            <tr>
                <th>Description</th>
                <th>Type</th>
                <th>Qty</th>
                <th>Unit Price</th>
                <th>Price</th>
                <th>Created By</th>
                <th></th>
            </tr>
        </thead>

        <tbody style=""background-color:white;"" id=""tblBodyPartsGrid""></tbody>
        <tfoot id=""tblBodyPartsTotals"" style=""background-color:white;""></tfoot>
    </table>
</div>

<br />
<br />
<div style=""display:none;"">
    <table id=""profitAndLostGrid"" class=""table table-hover"" style=""font-size:12px; border-bottom:groove; max-width:100%;""></table>
</div>
<div style=""display:none;"" id=""partsOutOfStock"" class=""warning"">

</div>
<style>
    #Name {
        w");
            WriteLiteral(@"idth: 98%;
    }
    /*.ui-autocomplete {
        z-index: 99999999 !important;
    }*/
</style>


<script>
    $(document).ready(function () {

        $('#laborOrPartCost').parents('tr').fadeOut();

    });

    // load Part details on name selection
    function StopPosting(e) {
        if ($('#PartType').val() != ""1"") {
            return false;
        }
        return true;
    }



    $('#ShowPartPanel').click(function () {
        $('#PartsPanel').slideToggle(500);
        $('#PartDescription').parents('tr').hide();
        $('.profitOnParts').hide();
        $('.purchasePrice').hide();
        $('.sellingPrice').hide();
        ClearInvoiceForm();
    });
    $('#HidePartPanel').click(function () {
        $('#PartsPanel').slideToggle(500); ClearInvoiceForm();
    });

    $('#partsMarkup').focusout(function () {
        ProfitCalculations();
    });
    $('#partsDiscount').focusout(function () {
        ProfitCalculations();
    });
    $('#laborOrPartCost");
            WriteLiteral(@"').focusout(function () {
        ProfitCalculations();
    });
    $('#PartPrice').focusout(function () {
        ProfitCalculations();
    });
    $('#PartQuantity').focusout(function () {
        ProfitCalculations();
    });


    function ProfitCalculations() {

        // profitCalculationOnEstimate();
        var jobPartId = $('#PartIdOfEstimate').val();
        if (jobPartId != null && jobPartId != """") {
            var type = $('#PartType').val();
            if (type == '1') {
                partProfitCalculations(jobPartId);
            }
            else
                if (type == '2') {
                    laborProfitCalculations(jobPartId);
                }

        }
        else {
            var type = $('#PartType').val();

            if (type == '1') {
                AddPartProfitCalculations();
            }
            else
                if (type == '2') {
                    AddLaborProfitCalculations();
                }




            //-");
            WriteLiteral(@"---------------------
            //var itemName = $('#Name').val();
            //var AptaPrice = parseFloat($('#APTAPrice').val());
            //var UnitPrice = $(""#profitLoss"" + jobPartId).children('td:nth-child(2)').text();
            //var purchasePrice = parseFloat($('#purchasePrice').val());
            //if (itemName != null && itemName != """" && purchasePrice != null && purchasePrice != """" && !isNaN(purchasePrice)) {
            //    var markup = parseFloat($('#partsMarkup').val());
            //    var sellingPrice = AptaPrice / (1 - (parseFloat(markup) / 100));
            //    var discount = parseFloat($('#partsDiscount').val());
            //    var markupPrice = (markup / 100) * purchasePrice;
            //    var totalMarkup = markupPrice + parseFloat(UnitPrice);
            //    var discountPrice = (discount / 100) * totalMarkup;
            //    //var displayPrice = displayPrice - discountPrice;
            //    sellingPrice = sellingPrice - discountPrice;
            /");
            WriteLiteral(@"/    if (sellingPrice != null && sellingPrice != """" && !isNaN(sellingPrice)) {
            //        $('#lblPartPrice').html(""*("" + sellingPrice.toFixed(2) + "")"");
            //    }
            //}
        }
    }

    //--------------Profit Calculations for Part on add---------------------------
    function AddPartProfitCalculations() {
        var found = $('#lblPartFound').text();

        if (found == ""Yes"") {
            var aptaPrice = parseFloat($('#APTAPrice').val());
            var markup = $('#partsMarkup').val();
            var discount = $('#partsDiscount').val();
            var quantity = $(""#PartQuantity"").val();
            var purchasePrice = $('#purchasePrice').val();

            var sellingPrice = aptaPrice / (1 - (parseFloat(markup) / 100));
            var markupPrice = (markup / 100) * purchasePrice;
            var totalMarkup = markupPrice + parseFloat(purchasePrice);
            var discountPrice = (discount / 100) * totalMarkup;

            sellingPrice ");
            WriteLiteral(@"= sellingPrice - discountPrice;
            if (sellingPrice != null && !isNaN(sellingPrice)) {
                // $('#lblPartPrice').html(""*("" + sellingPrice.toFixed(2) + "")"");
                $('#sellingPrice').val(sellingPrice.toFixed(2));
            }

            var profit = sellingPrice - aptaPrice;
            var totalProfit = profit * parseFloat(quantity);
            if (totalProfit != null && !isNaN(totalProfit)) {
                $('#PartPofit').val(totalProfit.toFixed(2));
                // $('#PartPofit').parents('tr').show();
                $('.profitOnParts').show();
            }
        }
        else {

            var markup = $('#partsMarkup').val();
            var discount = $('#partsDiscount').val();
            var quantity = $(""#PartQuantity"").val();
            var newPartCost = parseFloat($('#NewPartCost').val());

            var sellingPrice = newPartCost / (1 - (parseFloat(markup) / 100));
            var markupPrice = (markup / 100) * newPartCost;
   ");
            WriteLiteral(@"         var totalMarkup = markupPrice + parseFloat(newPartCost);
            var discountPrice = (discount / 100) * totalMarkup;

            sellingPrice = sellingPrice - discountPrice;
            if (sellingPrice != null && !isNaN(sellingPrice)) {
                // $('#lblPartPrice').html(""*("" + sellingPrice.toFixed(2) + "")"");
                $('#sellingPrice').val(sellingPrice.toFixed(2));
            }

            var profit = sellingPrice - newPartCost;
            var totalProfit = profit * parseFloat(quantity);
            if (totalProfit != null && !isNaN(totalProfit)) {
                $('#PartPofit').val(totalProfit.toFixed(2));
                // $('#PartPofit').parents('tr').show();
                $('.profitOnParts').show();
            }

        }


    }
    //--------------Profit Calculations for Labor on add---------------------------
    function AddLaborProfitCalculations() {

        var laborCost = parseFloat($(""#laborOrPartCost"").val());
        var unitPric");
            WriteLiteral(@"e = parseFloat($('#PartPrice').val());
        var quantity = parseFloat($(""#PartQuantity"").val());

        //var laborTotal = quantity * laborCost;
        var total = quantity * unitPrice;
        var profit = parseFloat(total) - laborCost;
        if (profit != null && !isNaN(profit)) {
            $('#PartPofit').val(profit.toFixed(2));
            // $('#PartPofit').parents('tr').show();
            $('.profitOnParts').show();
        }


    }
    //--------------Profit Calculations for Labor on edit---------------------------
    function laborProfitCalculations(jobPartId) {

        var oldProfit = $(""#profitLoss"" + jobPartId).children('td:nth-child(7)').text();
        var quantity = $(""#PartQuantity"").val();
        var oldPartTotal = parseFloat($(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text());
        var laborCost = parseFloat($(""#laborOrPartCost"").val());
        var unitPrice = parseFloat($('#PartPrice').val());
        if (quantity != null && quantity != """);
            WriteLiteral(@""" && !isNaN(quantity)) {
            $(""#profitLoss"" + jobPartId).children('td:nth-child(3)').text(quantity);
        }
        if (laborCost != null && !isNaN(laborCost)) {
            $(""#profitLoss"" + jobPartId).children('td:nth-child(2)').text(laborCost.toFixed(2));
            var oldTotalPrice = parseFloat($('#profitLossTotalProfit').children('td:nth-child(6)').text());
            var oldTotal = parseFloat($(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text());
            var newTotal = oldTotalPrice - oldTotal;
            //var total = parseFloat(quantity) * laborCost;
            newTotal += laborCost;
            if (newTotal != null && !isNaN(newTotal)) {
                $('#profitLossTotalProfit').children('td:nth-child(6)').text(newTotal.toFixed(2));
            }
            $(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text(laborCost.toFixed(2));

        }
        var oldTotalProfit = parseFloat($('#profitLossTotalProfit').children('td:nth-child(7)').text");
            WriteLiteral(@"());
        var totalPrice = parseFloat(quantity) * parseFloat(unitPrice);
        //var totalLabor = parseFloat(quantity) * laborCost;
        var newProfit = totalPrice - laborCost;
        if (newProfit != null && !isNaN(newProfit)) {
            $(""#profitLoss"" + jobPartId).children('td:nth-child(7)').text(newProfit.toFixed(2));
            $('#PartPofit').val(newProfit.toFixed(2));
        }

        var newTotalProfit = oldTotalProfit - parseFloat(oldProfit);
        newTotalProfit += parseFloat(newProfit);
        if (newTotalProfit != null && !isNaN(newTotalProfit)) {
            $('#profitLossTotalProfit').children('td:nth-child(7)').text(newTotalProfit.toFixed(2));
        }


    }

    //--------------Profit Calculations for Part on edit---------------------------
    function partProfitCalculations(jobPartId) {
        var found = $('#lblPartFound').text();

        // if part present in database
        if (found == ""Yes"") {
            var oldProfit = $(""#profitLoss"" + ");
            WriteLiteral(@"jobPartId).children('td:nth-child(7)').text();
            var oldMarkup = $(""#profitLoss"" + jobPartId).children('td:nth-child(4)').text();
            var oldPartTotal = parseFloat($(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text());
            var aptaPrice = parseFloat($('#APTAPrice').val());
            var markup = $('#partsMarkup').val();
            var sellingPrice = aptaPrice / (1 - (parseFloat(markup) / 100));

            $(""#profitLoss"" + jobPartId).children('td:nth-child(4)').text(markup + ""%"");
            var discount = $('#partsDiscount').val();
            $(""#profitLoss"" + jobPartId).children('td:nth-child(5)').text(discount + ""%"");
            var unitPrice = $(""#profitLoss"" + jobPartId).children('td:nth-child(2)').text();
            var quantity = $(""#PartQuantity"").val();
            if (quantity != null && !isNaN(quantity)) {
                $(""#profitLoss"" + jobPartId).children('td:nth-child(3)').text(quantity);
                var oldTotalPrice = parseFloat");
            WriteLiteral(@"($('#profitLossTotalProfit').children('td:nth-child(6)').text());
                var oldTotal = parseFloat($(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text());
                var newTotal = oldTotalPrice - oldTotal;

                var total = parseFloat(quantity) * parseFloat(unitPrice);
                newTotal += total;
                if (newTotal != null && !isNaN(newTotal)) {
                    $('#profitLossTotalProfit').children('td:nth-child(6)').text(newTotal.toFixed(2));
                }
                $(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text(total.toFixed(2));
            }
            var oldTotalProfit = parseFloat($('#profitLossTotalProfit').children('td:nth-child(7)').text());
            var totalPrice = parseFloat(quantity) * parseFloat(unitPrice);
            var markupAmount = (parseFloat(markup) / 100) * parseFloat(unitPrice);
            var totalMarkup = markupAmount + parseFloat(unitPrice);
            var discountAmount = (parseFl");
            WriteLiteral(@"oat(discount) / 100) * totalMarkup;
            sellingPrice = sellingPrice - discountAmount;

            if (sellingPrice != null && !isNaN(sellingPrice)) {
                // $('#lblPartPrice').html(""*("" + sellingPrice.toFixed(2) + "")"");
                $('#sellingPrice').val(sellingPrice.toFixed(2));
            }
            var newProfit = (sellingPrice - aptaPrice) * parseFloat(quantity);
            if (newProfit != null && !isNaN(newProfit)) {
                $(""#profitLoss"" + jobPartId).children('td:nth-child(7)').text(newProfit.toFixed(2));
            }
            $('#PartPofit').val(newProfit.toFixed(2));

            var newTotalProfit = oldTotalProfit - parseFloat(oldProfit);
            newTotalProfit += parseFloat(newProfit);
            $('#profitLossTotalProfit').children('td:nth-child(7)').text(newTotalProfit.toFixed(2));
        }
            // if part not present in database
        else {
            var oldProfit = $(""#profitLoss"" + jobPartId).children('td:nth-chil");
            WriteLiteral(@"d(7)').text();
            var oldMarkup = $(""#profitLoss"" + jobPartId).children('td:nth-child(4)').text();
            var oldPartTotal = parseFloat($(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text());
            // var aptaPrice = parseFloat($('#APTAPrice').val());
            var newPartCoct = parseFloat($('#NewPartCost').val());
            var markup = $('#partsMarkup').val();
            var sellingPrice = newPartCoct / (1 - (parseFloat(markup) / 100));

            $(""#profitLoss"" + jobPartId).children('td:nth-child(4)').text(markup + ""%"");
            var discount = $('#partsDiscount').val();
            $(""#profitLoss"" + jobPartId).children('td:nth-child(5)').text(discount + ""%"");
            var unitPrice = $(""#profitLoss"" + jobPartId).children('td:nth-child(2)').text();
            var quantity = $(""#PartQuantity"").val();
            if (quantity != null && !isNaN(quantity)) {
                $(""#profitLoss"" + jobPartId).children('td:nth-child(3)').text(quantity);
     ");
            WriteLiteral(@"           var oldTotalPrice = parseFloat($('#profitLossTotalProfit').children('td:nth-child(6)').text());
                var oldTotal = parseFloat($(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text());
                var newTotal = oldTotalPrice - oldTotal;

                var total = parseFloat(quantity) * parseFloat(unitPrice);
                newTotal += total;
                if (newTotal != null && !isNaN(newTotal)) {
                    $('#profitLossTotalProfit').children('td:nth-child(6)').text(newTotal.toFixed(2));
                }
                $(""#profitLoss"" + jobPartId).children('td:nth-child(6)').text(total.toFixed(2));
            }
            var oldTotalProfit = parseFloat($('#profitLossTotalProfit').children('td:nth-child(7)').text());
            var totalPrice = parseFloat(quantity) * parseFloat(unitPrice);
            var markupAmount = (parseFloat(markup) / 100) * parseFloat(unitPrice);
            var totalMarkup = markupAmount + parseFloat(unitPrice);
");
            WriteLiteral(@"            var discountAmount = (parseFloat(discount) / 100) * totalMarkup;
            sellingPrice = sellingPrice - discountAmount;

            if (sellingPrice != null && !isNaN(sellingPrice)) {
                // $('#lblPartPrice').html(""*("" + sellingPrice.toFixed(2) + "")"");
                $('#sellingPrice').val(sellingPrice.toFixed(2));
            }
            var newProfit = (sellingPrice - newPartCoct) * parseFloat(quantity);
            if (newProfit != null && !isNaN(newProfit)) {
                $(""#profitLoss"" + jobPartId).children('td:nth-child(7)').text(newProfit.toFixed(2));
            }
            $('#PartPofit').val(newProfit.toFixed(2));

            var newTotalProfit = oldTotalProfit - parseFloat(oldProfit);
            newTotalProfit += parseFloat(newProfit);
            $('#profitLossTotalProfit').children('td:nth-child(7)').text(newTotalProfit.toFixed(2));
        }

    }


    function profitCalculationOnEstimate() {

        var aptaPrice = parseFloat($('");
            WriteLiteral(@"#APTAPrice').val());
        var purchasePrice = parseFloat($('#purchasePrice').val());
        var marginPercentage = parseFloat($('#partsMarkup').val());
        var discount = parseFloat($('#partsDiscount').val());
        if (aptaPrice != null && !isNaN(aptaPrice) && marginPercentage != null && marginPercentage != """" && !isNaN(marginPercentage)) {
            var sellingPrice = aptaPrice / (1 - (marginPercentage / 100));
            var marginPrice = (marginPercentage / 100) * purchasePrice;
            marginPrice += purchasePrice;
            var discountPrice = (discount / 100) * marginPrice;
            sellingPrice = sellingPrice - discountPrice;

            //$('#lblPartPrice').html(""*("" + sellingPrice.toFixed(2) + "")"");
            $('#PartPrice').val(sellingPrice.toFixed(2));
            var profit = sellingPrice - aptaPrice;
            if (profit != null && !isNaN(profit) && profit != """") {
                $('#PartPofit').val(profit.toFixed(2));
            }
        }

    }");
            WriteLiteral(@"


    function ClearInvoiceForm() {
        $('#PartType').val(""1"");
        $('#Name').val("""");
        $('#PartDescription').val("""");
        $('#PartPrice').val("""");
        $('#PartQuantity').val("""");
        $('#PartIdOfEstimate').val("""");
        $('#partsMarkup').val('');
        $('#partsDiscount').val('');


    }
    $('#emailEstimate').click(function () {
        {
            $('.emailPanel').slideToggle(500);
        }
    });
    $('#btnSendEmail').click(function () {
        {
            Notify('Invoice forwarded succesfully.', 'success'); $('.emailPanel').slideToggle(500);
        }
    });


</script>");
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
