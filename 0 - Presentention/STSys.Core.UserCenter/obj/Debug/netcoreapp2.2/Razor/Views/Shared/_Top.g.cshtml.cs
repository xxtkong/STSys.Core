#pragma checksum "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ef421c98aa24f1317e2b13d661c5e226e0640fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Top), @"mvc.1.0.view", @"/Views/Shared/_Top.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Top.cshtml", typeof(AspNetCore.Views_Shared__Top))]
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
#line 1 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
using STSys.Core.UserCenter.HtmlExtensions;

#line default
#line hidden
#line 2 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
using STSys.Core.Domain.Core.Common;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ef421c98aa24f1317e2b13d661c5e226e0640fe", @"/Views/Shared/_Top.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19928e9def3dbdfc808045bb494bf65e512228f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Top : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(84, 333, true);
            WriteLiteral(@"<div class=""site-top"">
    <div class=""container clearfix clear_float"">
        <div class=""top-area lf"" id=""area"">
            <div>
                <div style=""height: 40px;"" class=""area_name"" id=""area"">
                    <i class=""iconfont icon-dingwei""></i>
                    <b id=""b_area"" class=""_top_globals_area"">
");
            EndContext();
            BeginContext(477, 2778, true);
            WriteLiteral(@"                        北京
                    </b>
                    [切换城市]
                </div>
                <!--<div class=""hover_jt""></div>-->
            </div>
            <style>
                .J_header-top-local {
                    position: absolute;
                    top: 40px;
                    left: 0;
                    z-index: 99999;
                    background-color: #fff;
                    display: none;
                    border: 1px solid #f4f4f4;
                }

                .header-top-local {
                    padding: 16px 20px 20px;
                    font-size: 12px;
                    width: 320px;
                }

                .local-city-current {
                    color: #888;
                    border-bottom: 1px dashed #ddd;
                    padding-bottom: 14px;
                    overflow: hidden;
                }

                .header-top-warp-v1 .clearfix:after {
                    display: table");
            WriteLiteral(@";
                    line-height: 0;
                    content: """";
                }

                .header-top-local .fl {
                    float: left;
                }

                .highlight {
                    color: #ff6900;
                }

                .header-top-warp-v1 a {
                    color: #888;
                    cursor: pointer;
                    text-decoration: none;
                }

                .local-city-panel .local-city-panel-bd {
                    padding: 10px 0;
                    border-bottom: 1px dashed #ddd;
                    overflow: hidden;
                }

                .item-bd {
                    float: left;
                    height: 28px;
                    line-height: 28px;
                    width: 20%;
                    text-align: center;
                }

                .local-city-panel a {
                    color: #333;
                    display: block;
                ");
            WriteLiteral(@"    width: 100%;
                    cursor: pointer;
                    text-decoration: none;
                }

                    .local-city-panel a:hover {
                        color: #ff7900;
                    }
            </style>
            <script>
                $(function () {
                    $(""#area"").hover(function () {
                        $(""#areainfo"").show();
                    }, function () {
                        $(""#areainfo"").hide();
                    }
                    )
                    //$.post(""/Util/Aear"", function (result) {
                    //    $(""#b_area"").text(result);
                    //})
                })
            </script>
");
            EndContext();
#line 100 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
              
                var city = new string[] { "北京", "重庆", "安徽", "上海","福建", "甘肃", "广东", "贵州", "广西", "澳门", "海南", "河北", "黑龙江", "河南",
                                     "湖北", "湖南", "江苏", "江西", "吉林", "辽宁", "内蒙古", "宁夏", "青海", "山东","山西","陕西","四川","天津","新疆","西藏","云南","浙江","香港","台湾" };
 var r = new Random().Next(0, city.Length - 1);
 var like = city[r];
            

#line default
#line hidden
            BeginContext(3635, 336, true);
            WriteLiteral(@"            <div class=""J_header-top-local"" id=""areainfo"">
                <div class=""header-top-local"">
                    <div class=""local-city-current "">
                        <div class=""fl"">
                            猜您想要进：<a href=""javascript:void(0)"" class=""highlight j-localize-city"">
                                ");
            EndContext();
            BeginContext(3972, 4, false);
#line 111 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                           Write(like);

#line default
#line hidden
            EndContext();
            BeginContext(3976, 222, true);
            WriteLiteral("\r\n                            </a>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"local-city-panel\">\r\n                        <ul class=\"local-city-panel-bd\" id=\"selectAear\">\r\n");
            EndContext();
#line 117 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                              
                                foreach (var item in city)
                                {

#line default
#line hidden
            BeginContext(4325, 55, true);
            WriteLiteral("                                    <li class=\"item-bd\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4380, "\"", 4393, 1);
#line 120 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
WriteAttributeValue("", 4388, item, 4388, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4394, 71, true);
            WriteLiteral(">\r\n                                        <a href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 4465, "\"", 4478, 1);
#line 121 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
WriteAttributeValue("", 4473, item, 4473, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4479, 71, true);
            WriteLiteral(" class=\"j-localize-city\">\r\n                                            ");
            EndContext();
            BeginContext(4551, 4, false);
#line 122 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                                       Write(item);

#line default
#line hidden
            EndContext();
            BeginContext(4555, 91, true);
            WriteLiteral("\r\n                                        </a>\r\n                                    </li>\r\n");
            EndContext();
#line 125 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(4712, 119, true);
            WriteLiteral("                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
            BeginContext(4885, 89, true);
            WriteLiteral("        <div class=\"top-list-box ri\">\r\n            <div class=\"link-list\" id=\"ul_user\">\r\n");
            EndContext();
#line 139 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                 if (!User.Identity.IsAuthenticated)
                {

#line default
#line hidden
            BeginContext(5251, 155, true);
            WriteLiteral("                    <div class=\"link_item\">\r\n                        <a href=\"javascript:userregister();\" class=\"lf\">免费注册</a>\r\n                    </div>\r\n");
            EndContext();
#line 144 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                }

#line default
#line hidden
            BeginContext(5425, 43, true);
            WriteLiteral("                <div class=\"link_item\">\r\n\r\n");
            EndContext();
#line 147 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                     if (!User.Identity.IsAuthenticated)
                    {

#line default
#line hidden
            BeginContext(5549, 91, true);
            WriteLiteral("                        <a href=\"javascript:userlogin(1);\" class=\"lf org_color\">企业主登录</a>\r\n");
            EndContext();
#line 150 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(5712, 83, true);
            WriteLiteral("                        <a style=\"cursor: default;color:#666;\" class=\"lf\">您好，</a>\r\n");
            EndContext();
#line 154 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                        if (User.IsInRole("company"))
                        {

#line default
#line hidden
            BeginContext(5877, 61, true);
            WriteLiteral("                            <a href=\"/\" class=\"org_color lf\">");
            EndContext();
            BeginContext(5939, 39, false);
#line 156 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                                                        Write(User.Identity.Name.ToStrAsterisk(3,4,4));

#line default
#line hidden
            EndContext();
            BeginContext(5978, 7, true);
            WriteLiteral(" </a>\r\n");
            EndContext();
#line 157 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(6069, 82, true);
            WriteLiteral("                            <a href=\"/consultant/Index.html\" class=\"org_color lf\">");
            EndContext();
            BeginContext(6152, 39, false);
#line 160 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                                                                             Write(User.Identity.Name.ToStrAsterisk(3,4,4));

#line default
#line hidden
            EndContext();
            BeginContext(6191, 7, true);
            WriteLiteral(" </a>\r\n");
            EndContext();
#line 161 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                        }
                    }

#line default
#line hidden
            BeginContext(6248, 604, true);
            WriteLiteral(@"
                </div>
                <div class=""link_item qrcode_item"">
                    <a href=""javascript:void(0);"" target=""_blank"">
                        <span>关注首途</span>
                    </a>
                    <div class=""top-menu-link qrcode"">
                        <img src=""/images/zixun_q.jpg"" />
                    </div>
                </div>
                <div class=""link_item tellnum"">
                    <a href=""javascript:void(0);"" target=""_blank"">
                        <span>热线：4000-222-718</span>
                    </a>
                </div>
");
            EndContext();
#line 178 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                 if (!User.Identity.IsAuthenticated)
                {

#line default
#line hidden
            BeginContext(6925, 168, true);
            WriteLiteral("                    <div class=\"link_item\">\r\n                        <a href=\"javascript:userlogin(2);\" class=\"lf blue_color\">成为首途共享顾问</a>\r\n                    </div>\r\n");
            EndContext();
#line 183 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                }
                else
                {
                    if (User.IsInRole("company"))
                    {

#line default
#line hidden
            BeginContext(7227, 736, true);
            WriteLiteral(@"                        <div class=""link_item bottom-drop-down bottom-drop-down1"">
                            <a href=""/users/Index.html"" class=""downLink""><span>我是企业主</span><i class=""iconfont icon-xiala site-icon""></i><i class=""line iconfont ri""></i></a>
                            <ul class=""top-menu-link  top-menu-link1"">
                                <li><a href=""/users/Index.html"">我是企业主</a></li>
                                <li><a href=""/users/orderIndex.html"">我的订单</a></li>
                                <li><a href=""/Users/FootPrint/Index"">我的足迹</a></li>
                                <li><a href=""/Users/Favorites/ServiceIndex"">我的收藏</a></li>
                            </ul>
                        </div>
");
            EndContext();
#line 197 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                    }
                    if (User.IsInRole("consultant "))
                    {

#line default
#line hidden
            BeginContext(8064, 840, true);
            WriteLiteral(@"                        <div class=""link_item bottom-drop-down bottom-drop-down2"">
                            <a href=""/consultant/Index.html"" class=""downLink"">
                                <span>我是共享顾问</span>
                                <i class=""line iconfont icon-vertical_line""></i>
                            </a>
                            <ul class=""top-menu-link top-menu-link2"">
                                <li><a href=""/consultant/Index.html"">我是共享顾问</a></li>
                                <li><a href=""/Consultants/ConsultantAccount/Index"">我的收支</a></li>
                                <li><a href=""/consultant/orderIndex.html"">订单中心</a></li>
                                <li><a href=""/Consultants/ConsultantCenter/Info"">个人信息</a></li>
                            </ul>
                        </div>
");
            EndContext();
#line 212 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                    }

#line default
#line hidden
            BeginContext(8927, 217, true);
            WriteLiteral("                    <!--退出-->\r\n                    <div class=\"link_item log_out\">\r\n                        <a href=\"/Account/LogOut\" class=\"lf\"><i class=\"iconfont icon-tuichu\"></i>退出</a>\r\n                    </div>\r\n");
            EndContext();
#line 217 "D:\项目\NASys\STSys.Core\0 - Presentention\STSys.Core.UserCenter\Views\Shared\_Top.cshtml"
                }

#line default
#line hidden
            BeginContext(9163, 54, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
