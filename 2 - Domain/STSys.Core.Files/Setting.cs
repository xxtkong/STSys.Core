using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Files
{
    public static class Settings
    {
        /// <summary>
        /// 文件存储路径
        /// </summary>
        public static string Address => SettingHelper.Configuration["address"];
        /// <summary>
        /// 主机Ip
        /// </summary>
        public static string Host => SettingHelper.Configuration["host"];
        /// <summary>
        /// 主机端口
        /// </summary>
        public static string Port => SettingHelper.Configuration["port"];
        /// <summary>
        /// 获取ServiceProvider
        /// </summary>
        public static ServiceProvider serviceProvider => SettingHelper.serviceProvider;

        public static string WebFile => SettingHelper.Configuration["webfile"];
    }
}
