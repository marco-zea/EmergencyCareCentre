#pragma checksum "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f3c58fb0d8e56d68b841be1fcdfb2385ac1a358"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
using ECC.WebApp.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f3c58fb0d8e56d68b841be1fcdfb2385ac1a358", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.Models.HomeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Patient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Admit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Comment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Discharge", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Emergency Care Centre App</h1>

    <table class=""table"">
        <thead>
            <tr>
                <td>
                    Bed
                </td>
                <td>
                    Status
                </td>
                <td>
                    Patient
                </td>
                <td>
                    DOB
                </td>
                <td>
                    Presenting Issue
                </td>
                <td>
                    Last comment
                </td>
                <td>
                    Last update
                </td>
                <td>
                    Nurse
                </td>
                <td>
                    Action
                </td>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 45 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
             foreach (var item in Model.BedDetails)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.BedId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 52 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 55 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                         if (item.State == "In use")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3c58fb0d8e56d68b841be1fcdfb2385ac1a3586987", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 58 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PatientName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                      WriteLiteral(item.PatientId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 60 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 63 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                         if (item.State == "In use")
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DateOfBirth));

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                                           
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 69 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                         if (item.State == "In use")
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AdmissionReason));

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                                               
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 75 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                         if (item.State == "In use")
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.LastComment));

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                                           
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 81 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                         if (item.State == "In use")
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.LastUpdate));

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                                          
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 87 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                         if (item.State == "In use")
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Staff));

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                                     
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 93 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                         if (item.State == "Free")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3c58fb0d8e56d68b841be1fcdfb2385ac1a35814583", async() => {
                WriteLiteral("Admit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 95 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                    WriteLiteral(item.BedId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 96 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3c58fb0d8e56d68b841be1fcdfb2385ac1a35817072", async() => {
                WriteLiteral("Add comment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 99 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                      WriteLiteral(item.BedId);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 99 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                                  WriteLiteral(item.PatientId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <br>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3c58fb0d8e56d68b841be1fcdfb2385ac1a35819619", async() => {
                WriteLiteral("Discharge");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 101 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                        WriteLiteral(item.BedId);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 101 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                                                    WriteLiteral(item.PatientId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 102 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 105 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div>\r\n    <statistics class=\"text-left\">\r\n        <span>Beds in use: ");
#nullable restore
#line 111 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                      Write(Model.UsedBeds);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n        <span>Beds free: ");
#nullable restore
#line 112 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                    Write(Model.FreeBeds);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n        <span>Total patients admitted today: ");
#nullable restore
#line 113 "C:\Users\MZea\Documents\GitHub\EmergencyCareCentre\src\ECC.WebApp\Views\Home\Index.cshtml"
                                        Write(Model.TotalAdmissionsToday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </statistics>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public EmergencyCareService Service { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Models.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
