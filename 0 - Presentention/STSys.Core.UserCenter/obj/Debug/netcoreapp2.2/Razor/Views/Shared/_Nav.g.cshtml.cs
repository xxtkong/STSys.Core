#pragma checksum "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Nav.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87b0fb6ec8b727f203b60bd8f03319d2d07f6a4e"
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
#line 1 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\_ViewImports.cshtml"
using STSys.Core.UserCenter;

#line default
#line hidden
#line 2 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\_ViewImports.cshtml"
using STSys.Core.UserCenter.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87b0fb6ec8b727f203b60bd8f03319d2d07f6a4e", @"/Views/Shared/_Nav.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19928e9def3dbdfc808045bb494bf65e512228f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Nav : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2414, true);
            WriteLiteral(@"<nav>
    <div class=""nav_wrap auto clear_float"">
        <div class=""logo_wrap"">
            <div class=""logo"">
                <a href=""http://www.shoutu.com.cn"">
                    <img src=""/images/center_logo.png"" />
                </a>
            </div>
        </div>
        <!--右边部分-->
        <div class=""right_con"">
            <div class=""center fl"">
                <p>个人中心</p>
                <a href=""./index.html"">返回首途首页</a>
            </div>
            <div class=""my_list fl"">
                <ul class=""clear_float"">
                    <li>
                        <a href=""/"">我的主页</a>
                    </li>
                    <li class=""account_set accountSet"">
                        <a href=""javascript:"" class=""accountBtn"">账户设置<i class=""iconfont icon-jiantou-xia""></i></a>
                    </li>
                    <li class=""msg"">
                        <a href=""#"">消息<i class=""iconfont"">66</i></a>
                    </li>
                    <div class=""");
            WriteLiteral(@"drop_box"">
                        <ul>
                            <li>
                                <a href=""#"">基本信息</a>
                            </li>
                            <li>
                                <a href=""#"">账户安全</a>
                            </li>
                            <li>
                                <a href=""/Set/AccountBind"">账号绑定</a>
                            </li>
                            <li>
                                <a href=""#"">发票信息</a>
                            </li>
                            <li>
                                <a href=""#"">服务地址</a>
                            </li>
                        </ul>
                    </div>
                </ul>
            </div>
            <div class=""extra"">
                <!--搜索框-->
                <div class=""search_box"">
                    <input type=""text"" placeholder=""公司注册"">
                    <i class=""iconfont icon-sousuo""></i>
                </div>
     ");
            WriteLiteral(@"           <!--购物车-->
                <div class=""shoppingcar"">
                    <i class=""iconfont icon-gouwuche""></i>
                    <span>我的购物车</span>
                    <a href=""#""><i class=""iconfont"">0</i></a>
                    <i class=""iconfont icon-jiantou""></i>
                </div>
            </div>
        </div>
    </div>
</nav>");
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
