using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using STSys.Core.UserCenter.Models;
using System;

namespace STSys.Core.UserCenter.Controllers
{
    public class SetController : Controller
    {
        private readonly AppSetting _appSettings;
        public SetController(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        #region  账号绑定
        //加载绑定数据
        public ActionResult AccountBind()
        {
            //这里要以当前登录用户id 作为参数。目前只写测试数据IEnumerable<dynamic>
            //var model = await ApiHelper.GetAsync<dynamic>("/api/UserCenter/GetUsers?uid=4539");
            string appid = _appSettings.WxWebAppId;
            //WxWebAppSecret
            string secret = _appSettings.WxWebAppSecret;
            return View();
        }

        //微信绑定
        public void WeChatLogin()
        {
            //var audienceConfig = _appSettings.WxWebAppId;
            //当前登录用户id
            string userid = "4539";
            //当前登录用户类型
            string usertype = "1";
            //WxWebAppId
            string appid = _appSettings.WxWebAppId;
            //WxWebAppSecret
            string secret = _appSettings.WxWebAppSecret;
            string starte = Guid.NewGuid().ToString();
            //服务网址 
            string weburl = System.Net.WebUtility.UrlEncode("http://localhost:48038//share/wecharbind?userid=" + userid + "&usertype=" + usertype);
            string Url = "https://open.weixin.qq.com/connect/qrconnect?appid=" + appid + "&redirect_uri=" + weburl + "&response_type=code&scope=snsapi_login&state=" + starte + "#wechat_redirect";
            Response.Redirect(Url);
        }
        #endregion

        #region  安全中心
        //public JsonResult PostUsersEmail(string email)
        //{
        //    //验证企业主邮箱的唯一性

        //    //var users = ApiHelper.GetAsync<dynamic>("/api/UserCenter/CheckUsers",);
        //}
        #endregion

    }
}
