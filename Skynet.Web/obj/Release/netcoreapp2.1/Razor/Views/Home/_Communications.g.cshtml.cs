#pragma checksum "C:\Work\Skynet 2.0\Skynet.Web\Views\Home\_Communications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f128992d1531b7de53982efd053b570362a266e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Communications), @"mvc.1.0.view", @"/Views/Home/_Communications.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_Communications.cshtml", typeof(AspNetCore.Views_Home__Communications))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f128992d1531b7de53982efd053b570362a266e3", @"/Views/Home/_Communications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a3c382a9203d8a39d7ac0f9908291a86ad1608b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Communications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "SMS", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "iPhone", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("SMSFrom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(2, 956, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18cf9249d2a94c0aa2f586a422b5404c", async() => {
                BeginContext(28, 392, true);
                WriteLiteral(@"
    <table class=""details"">
        <tr>
            <td>
                To
            </td>
            <td colspan=""2"">
                <input type=""text"" id=""ToPhone"" class=""required1"" name=""ToPhone"" />
                &nbsp;&nbsp;&nbsp;
                <span>Message Type: &nbsp;&nbsp;&nbsp;</span>

                <select id=""smsType"" name=""smsType"">
                    ");
                EndContext();
                BeginContext(420, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c0a10ff747e4d04a7225eb2d72706d1", async() => {
                    BeginContext(440, 3, true);
                    WriteLiteral("SMS");
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
                BeginContext(452, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(474, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5201beb70de343fb874e905a7ee0cd54", async() => {
                    BeginContext(497, 6, true);
                    WriteLiteral("iPhone");
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
                BeginContext(512, 439, true);
                WriteLiteral(@"
                </select>
            </td>

        </tr>
        <tr>
            <td>Message</td>
            <td>
                <textarea rows=""3"" cols=""30"" id=""SMSMessage"" name=""SMSMessage"" class=""required""></textarea>
            </td>
            <td>
                <button type=""button"" id=""btnSendMessage"" onclick=""SendSMS();"" class=""btn btn-success"">Send</button>
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(958, 383, true);
            WriteLiteral(@"
<button id=""SMSDiv"" class=""btn btn-success"" style=""font-size:11px;"" onclick=""SMSDiv();"">Send SMS</button>
<br />
<br />
<br />
<table class=""table table-hover"" style=""font-size:12px; margin-top: -9px;"" id=""messageGrid"">
    <thead style=""background-color:#dfe0e6;"">
        <tr>
            <th style=""width:50%;"">Send</th>
            <th style=""width:50%;"">Receive</th>
");
            EndContext();
            BeginContext(1473, 116, true);
            WriteLiteral("        </tr>\r\n    </thead>\r\n    <tbody style=\"background-color:white;\" id=\"tblBodyMessageGrid\"></tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(1630, 1733, true);
            WriteLiteral(@"<hr />
<table class=""table table-hover"" style=""font-size:12px;"" id=""basicJobDetails"">
    <thead style=""background-color:#dfe0e6;"">
        <tr>
            <th colspan=""4"">Basic Job Details</th>
        </tr>
    </thead>
    <tbody style=""background-color:white;"">
        <tr>
            <td><strong>Customer Name</strong></td>
            <td><span id=""comm_CustomerName""></span></td>
            <td><strong>Address</strong></td>
            <td><span id=""comm_Address""></span></td>
        </tr>
        <tr>
            <td><strong>City</strong></td>
            <td><span id=""comm_City""></span></td>
            <td><strong>State</strong></td>
            <td><span id=""comm_State""></span></td>
        </tr>
        <tr>
            <td><strong>Zip</strong></td>
            <td><span id=""comm_Zip""></span></td>
            <td><strong>Job Description</strong></td>
            <td><span id=""comm_JobDescription""></span></td>
        </tr>
        <tr>
            <td><strong>IVR#</stro");
            WriteLiteral(@"ng></td>
            <td><span id=""comm_IVR""></span></td>
            <td><strong>PIN#</strong></td>
            <td><span id=""comm_PIN""></span></td>
        </tr>
        <tr>
            <td><strong>Work Order Number</strong></td>
            <td><span id=""comm_WorkOrderNumber""></span></td>
            <td></td>
            <td></td>
        </tr>
    </tbody>
</table>
<hr />
<table class=""table table-hover"" style=""font-size:12px;"" id=""tblJobContractorDetails"">
    <thead style=""background-color:#dfe0e6;"">
        <tr>
            <th>Contractor Name</th>
            <th>Contact No</th>
        </tr>
    </thead>
    <tbody style=""background-color:white;""></tbody>
</table>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(3382, 356, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
    $(document).ready(function () {

        $(document).on(""change"", ""#smsType"", function() {
           // if ($(this).find(""option:selected"").attr(""value"") == ""iPhone"")
            if ($(this).value == ""iPhone"")
                $(""#ToPhone"").val('(000) 000-0000');
        });

    });

    </script>

");
                EndContext();
            }
            );
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