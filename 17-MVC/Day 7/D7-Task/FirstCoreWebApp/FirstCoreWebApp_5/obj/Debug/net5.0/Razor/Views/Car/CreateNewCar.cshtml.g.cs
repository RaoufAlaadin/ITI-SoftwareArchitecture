#pragma checksum "E:\ITI intake 43 SD\24- MVC\Day 7\FirstCoreWebApp\FirstCoreWebApp_5\Views\Car\CreateNewCar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46f4540c7fc2a93707be7052626cd77f15ed7ff6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Car_CreateNewCar), @"mvc.1.0.view", @"/Views/Car/CreateNewCar.cshtml")]
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
#line 1 "E:\ITI intake 43 SD\24- MVC\Day 7\FirstCoreWebApp\FirstCoreWebApp_5\Views\Car\CreateNewCar.cshtml"
using FirstCoreWebApp_5.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46f4540c7fc2a93707be7052626cd77f15ed7ff6", @"/Views/Car/CreateNewCar.cshtml")]
    #nullable restore
    public class Views_Car_CreateNewCar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\ITI intake 43 SD\24- MVC\Day 7\FirstCoreWebApp\FirstCoreWebApp_5\Views\Car\CreateNewCar.cshtml"
  
    ViewBag.Title = "CreateNewCar";
    int newCarID = ViewBag.newCarID;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>CreateNewCar</h2>\r\n\r\n\r\n\r\n\r\n<form method=\"post\" action=\"/Car/CreateNewCar\">\r\n\r\n    <input type=\"text\" name=\"Num\"");
            BeginWriteAttribute("value", " value=\"", 234, "\"", 251, 1);
#nullable restore
#line 15 "E:\ITI intake 43 SD\24- MVC\Day 7\FirstCoreWebApp\FirstCoreWebApp_5\Views\Car\CreateNewCar.cshtml"
WriteAttributeValue("", 242, newCarID, 242, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <input type=\"text\" name=\"Color\" value=\"green\" />\r\n    <input type=\"text\" name=\"Model\" value=\"honda cevic\" />\r\n    <input type=\"text\" name=\"Manfacture\" value=\"Toyotaaa\" />\r\n\r\n    <input type=\"submit\" value=\"Add Car\" />\r\n\r\n</form>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591