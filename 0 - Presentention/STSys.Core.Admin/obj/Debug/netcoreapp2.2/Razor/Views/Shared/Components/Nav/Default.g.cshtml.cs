#pragma checksum "D:\最新\STSys.Core\0 - Presentention\STSys.Core.Admin\Views\Shared\Components\Nav\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "355556a024375c904eac9e5982fd463d253518d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Nav_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Nav/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Nav/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Nav_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"355556a024375c904eac9e5982fd463d253518d8", @"/Views/Shared/Components/Nav/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b863460e66191c6bf2de30e77f193c3fc45d3a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Nav_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(310, 2417, true);
            WriteLiteral(@"

<ul class=""nav"" id=""side-menu"">
    <li class=""nav-header"">
        <div class=""dropdown profile-element"">
            <a data-toggle=""dropdown"" class=""dropdown-toggle"" href=""/main/index"">
                <span class=""clear"">
                    <span class=""block m-t-xs"" style=""font-size:20px;"">
                        <i class=""fa fa-area-chart""></i>
                        <strong class=""font-bold"">后台管理系统</strong>
                    </span>
                </span>
            </a>
        </div>
        <div class=""logo-element"">
            BBW
        </div>
    </li>
    <li class=""hidden-folded padder m-t m-b-sm text-muted text-xs"">
        <span class=""ng-scope"">分类</span>
    </li>
    <li>
        <a class=""J_menuItem"" href=""/main/index"">
            <i class=""fa fa-home""></i>
            <span class=""nav-label"">主页</span>
        </a>
    </li>
    <li class=""active"">
        <a href=""#"">
            <i class=""fa fa-gear""></i>
            <span class=""nav-label"">后台功能<");
            WriteLiteral(@"/span>
            <span class=""fa arrow""></span>
        </a>
        <ul class=""nav nav-second-level"">
            <li>
                <a class=""J_menuItem"" href=""/manager/index"">后台用户管理</a>
            </li>
            <li>
                <a class=""J_menuItem"" href=""/module/index"">后台模块管理</a>
            </li>
            <li>
                <a class=""J_menuItem"" href=""/role/index"">后台角色管理</a>
            </li>
            <li>
                <a class=""J_menuItem"" href=""/syserrorlog/index"">系统错误日志</a>
            </li>
            <li>
                <a class=""J_menuItem"" href=""graph_peity.html"">系统数据库执行</a>
            </li>

        </ul>
    </li>
    <li>
        <a href=""#"">
            <i class=""fa fa-compass""></i>
            <span class=""nav-label"">前台功能</span>
            <span class=""fa arrow""></span>
        </a>
        <ul class=""nav nav-second-level collapse"">
            <li>
                <a class=""J_menuItem"" href=""/users/index"">前台用户管理</a>
            </li>");
            WriteLiteral(@"
            <li>
                <a class=""J_menuItem"" href=""graph_flot.html"">首页配置</a>
            </li>
            <li>
                <a class=""J_menuItem"" href=""graph_morris.html"">前台广告设置</a>
            </li>
            <li>
                <a class=""J_menuItem"" href=""graph_rickshaw.html"">友情链接</a>
            </li>


        </ul>
    </li>
</ul>");
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
