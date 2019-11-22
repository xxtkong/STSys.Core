using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using STSys.Core.Domain.Core.Common;
using STSys.Core.UserCenter.Common;
using STSys.Core.UserCenter.Models;
using System;
using System.Data;

namespace STSys.Core.UserCenter.Controllers
{
    public class ShareController : Controller
    {

        private readonly AppSetting _appSettings;
        public ShareController(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// 微信绑定
        /// </summary>
        public ActionResult WecharBind(string code, string state)
        {
            //LogHelper.WriteLogFile("测试1111", code, state);
            string appid = _appSettings.WxWebAppId;
            string secret = _appSettings.WxWebAppSecret;
            string Url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + secret + "&code=" + code + "&grant_type=authorization_code";
            //DataSet ds = WXAPIHelper.GetApiInfo(Url);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    var openid = ds.Tables[0].Rows[0]["openid"].ToString();
            //    var nickname = ds.Tables[0].Rows[0]["nickname"].ToString();
            //    int uid = 11; //GetUsers.GetUser().Id; 当前登录用户id
            //    AccountBindInfoViewModel account = new AccountBindInfoViewModel();
            //    account.UserId = uid;
            //    account.UserType = (int)E_UserType.企业用户;
            //    account.AccountType = (int)E_WithdrawalsType.微信;
            //    account.AccountName = nickname;
            //    account.AccountNo = openid;
            //    account.CreateTime = DateTime.Now;
            //    var result = ApiHelper.Post<bool>("/api/UserCenter/GetUsers?uid=4539", account.MapToKeyValuePair());
            //}
            return Redirect("/users/set/accountbind");
        }
    }
}
