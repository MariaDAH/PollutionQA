#pragma checksum "c:\Users\mixid\Documents\PollutionQA\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b2e30ad65c761d40e5435bcaaf04714bdaf568d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "c:\Users\mixid\Documents\PollutionQA\Views\_ViewImports.cshtml"
using PollutionQA;

#line default
#line hidden
#line 2 "c:\Users\mixid\Documents\PollutionQA\Views\_ViewImports.cshtml"
using PollutionQA.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b2e30ad65c761d40e5435bcaaf04714bdaf568d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03fcf06bf59bbdffdd528cc420a909b9a8796f53", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PollutionQA.Models.IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "c:\Users\mixid\Documents\PollutionQA\Views\Home\Index.cshtml"
   ViewBag.Title = "Home Page"; 

#line default
#line hidden
            BeginContext(79, 325, true);
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome to PollutionQA</h1>
    <p>You are accesing to the Quality Assurance Query System.</p>
</div>
 <div class=""row"">
        <div class=""col-sm-4 col-sm-offset-4 mx-auto"">
            <div class=""panel panel-default"">
                <div class=""panel-body"">
");
            EndContext();
#line 13 "c:\Users\mixid\Documents\PollutionQA\Views\Home\Index.cshtml"
                     using (Html.BeginForm()) {
                        

#line default
#line hidden
            BeginContext(509, 82, true);
            WriteLiteral("                        <div class=\"form-group\">\r\n                            <!--");
            EndContext();
            BeginContext(592, 40, false);
#line 16 "c:\Users\mixid\Documents\PollutionQA\Views\Home\Index.cshtml"
                           Write(Html.LabelFor(m => m.SelectedStrategyId));

#line default
#line hidden
            EndContext();
            BeginContext(632, 33, true);
            WriteLiteral("-->\r\n                            ");
            EndContext();
            BeginContext(666, 129, false);
#line 17 "c:\Users\mixid\Documents\PollutionQA\Views\Home\Index.cshtml"
                       Write(Html.DropDownListFor(m => m.SelectedStrategyId, Model.Strategies,"- Please select a QA System -",new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(795, 126, true);
            WriteLiteral("\r\n                        </div>\r\n                        <button type=\"submit\" class=\"btn btn-primary\">Start query</button>\r\n");
            EndContext();
#line 20 "c:\Users\mixid\Documents\PollutionQA\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(944, 75, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PollutionQA.Models.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
