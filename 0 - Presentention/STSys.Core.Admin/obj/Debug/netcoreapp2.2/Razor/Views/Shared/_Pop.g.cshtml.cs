#pragma checksum "D:\最新\STSys\0 - Presentention\STSys.Core.Admin\Views\Shared\_Pop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbac49acf48b128d67cb2ba4a6185a30535b3b6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Pop), @"mvc.1.0.view", @"/Views/Shared/_Pop.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Pop.cshtml", typeof(AspNetCore.Views_Shared__Pop))]
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
#line 1 "D:\最新\STSys\0 - Presentention\STSys.Core.Admin\Views\_ViewImports.cshtml"
using STSys.Core.Admin.Application;

#line default
#line hidden
#line 2 "D:\最新\STSys\0 - Presentention\STSys.Core.Admin\Views\_ViewImports.cshtml"
using STSys.Core.Admin.Application.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbac49acf48b128d67cb2ba4a6185a30535b3b6b", @"/Views/Shared/_Pop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b863460e66191c6bf2de30e77f193c3fc45d3a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Pop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("gray-bg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(25, 817, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbac49acf48b128d67cb2ba4a6185a30535b3b6b4158", async() => {
                BeginContext(31, 144, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <!--360浏览器优先以webkit内核解析-->\r\n\r\n    ");
                EndContext();
                BeginContext(175, 611, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbac49acf48b128d67cb2ba4a6185a30535b3b6b4697", async() => {
                    BeginContext(210, 562, true);
                    WriteLiteral(@"
        <link rel=""shortcut icon"" href=""favicon.ico"">
        <link href=""/css/bootstrap.min.css?v=3.3.6"" rel=""stylesheet"">
        <link href=""/css/font-awesome.min.css?v=4.4.0"" rel=""stylesheet"">
        <link href=""/css/animate.css"" rel=""stylesheet"">
        <link href=""/css/style.css?v=4.1.0"" rel=""stylesheet"">
        <link href=""/lib/poshytip/tip-yellowsimple/tip-yellowsimple.css"" rel=""stylesheet"" />
        <link href=""/lib/zTree/zTreeStyle/bootstrapStyle.css"" rel=""stylesheet"" />
        <script src=""/js/jquery.min.js?v=2.1.4""></script>
    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(786, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(793, 40, false);
#line 18 "D:\最新\STSys\0 - Presentention\STSys.Core.Admin\Views\Shared\_Pop.cshtml"
Write(RenderSection("Styles", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(833, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(842, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(844, 1452, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbac49acf48b128d67cb2ba4a6185a30535b3b6b7937", async() => {
                BeginContext(866, 84, true);
                WriteLiteral("\r\n    <div class=\"wrapper wrapper-content\">\r\n        <div class=\"row\">\r\n            ");
                EndContext();
                BeginContext(951, 12, false);
#line 23 "D:\最新\STSys\0 - Presentention\STSys.Core.Admin\Views\Shared\_Pop.cshtml"
       Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(963, 34, true);
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n    ");
                EndContext();
                BeginContext(997, 1242, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbac49acf48b128d67cb2ba4a6185a30535b3b6b8785", async() => {
                    BeginContext(1032, 1193, true);
                    WriteLiteral(@"
        <!-- 全局js -->
        <script src=""/js/bootstrap.min.js?v=3.3.6""></script>
        <script src=""/js/plugins/metisMenu/jquery.metisMenu.js""></script>
        <script src=""/js/plugins/slimscroll/jquery.slimscroll.min.js""></script>
        <script src=""/js/plugins/layer/layer.min.js""></script>
        <!-- 自定义js -->
        <script src=""/lib/jquery-validation/dist/jquery.validate.js""></script>
        <script src=""/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js""></script>
        <script src=""/lib/poshytip/jquery.poshytip.js""></script>
        <script src=""/js/layer.js""></script>
        <script src=""/js/page.js""></script>
        <script src=""/js/common.js""></script>
        <script src='/lib/layer-v3.0.3/layer/layer.js'></script>
        <script src=""/js/hAdmin.js?v=4.1.0""></script>
        <script src=""/lib/zTree/jquery.ztree.core.js""></script>
        <script src=""/lib/zTree/jquery.ztree.excheck.js""></script>
        <script src=""/lib/zTree/jquery.ztree.exedit.js"">");
                    WriteLiteral("</script>\r\n        <script src=\"/js/jquery.unobtrusive-ajax.min.js\"></script>\r\n        <!-- 第三方插件 -->\r\n        <script src=\"/js/plugins/pace/pace.min.js\"></script>\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2239, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2246, 41, false);
#line 48 "D:\最新\STSys\0 - Presentention\STSys.Core.Admin\Views\Shared\_Pop.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(2287, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2296, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
