#pragma checksum "D:\最新\STSys.Core\0 - Presentention\STSys.Core.Admin\Views\Shared\_Nav.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c9b6cbfb4bd0a6816c31fd9e4f0a9e85b39d8d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Nav), @"mvc.1.0.view", @"/Views/Shared/_Nav.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Nav.cshtml", typeof(AspNetCore.Views_Shared__Nav))]
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
#line 1 "D:\最新\STSys.Core\0 - Presentention\STSys.Core.Admin\Views\_ViewImports.cshtml"
using STSys.Core.Admin.Application;

#line default
#line hidden
#line 2 "D:\最新\STSys.Core\0 - Presentention\STSys.Core.Admin\Views\_ViewImports.cshtml"
using STSys.Core.Admin.Application.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c9b6cbfb4bd0a6816c31fd9e4f0a9e85b39d8d0", @"/Views/Shared/_Nav.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b863460e66191c6bf2de30e77f193c3fc45d3a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Nav : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 196, true);
            WriteLiteral("<nav class=\"navbar-default navbar-static-side\" role=\"navigation\">\r\n    <div class=\"nav-close\">\r\n        <i class=\"fa fa-times-circle\"></i>\r\n    </div>\r\n    <div class=\"sidebar-collapse\">\r\n        ");
            EndContext();
            BeginContext(197, 34, false);
#line 6 "D:\最新\STSys.Core\0 - Presentention\STSys.Core.Admin\Views\Shared\_Nav.cshtml"
   Write(await Component.InvokeAsync("Nav"));

#line default
#line hidden
            EndContext();
            BeginContext(231, 24, true);
            WriteLiteral("\r\n    </div>\r\n</nav>\r\n\r\n");
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
