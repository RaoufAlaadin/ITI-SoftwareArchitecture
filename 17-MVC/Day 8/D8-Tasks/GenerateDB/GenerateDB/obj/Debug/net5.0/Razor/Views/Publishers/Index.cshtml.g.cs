#pragma checksum "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8116e7ee63ccf372786148f331f95cf4ff65a859"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Publishers_Index), @"mvc.1.0.view", @"/Views/Publishers/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8116e7ee63ccf372786148f331f95cf4ff65a859", @"/Views/Publishers/Index.cshtml")]
    #nullable restore
    public class Views_Publishers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GenerateDB.Models.Publisher>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PubName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PubName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1159, "\"", 1185, 1);
#nullable restore
#line 46 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
WriteAttributeValue("", 1174, item.PubId, 1174, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1238, "\"", 1264, 1);
#nullable restore
#line 47 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
WriteAttributeValue("", 1253, item.PubId, 1253, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1319, "\"", 1345, 1);
#nullable restore
#line 48 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
WriteAttributeValue("", 1334, item.PubId, 1334, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 51 "E:\ITI intake 43 SD\24- MVC\Day 8\D8-Tasks\GenerateDB\GenerateDB\Views\Publishers\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GenerateDB.Models.Publisher>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
