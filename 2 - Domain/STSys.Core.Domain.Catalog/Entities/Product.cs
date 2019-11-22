using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Domain.Catalog.Entities
{
    public class Product : Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; }
        /// <summary>
        /// 主图
        /// </summary>
        public string BasicPicUrl { get; set; }
        /// <summary>
        /// 下载价格
        /// </summary>
        public double? SalePrice { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        public int? SaleCount { get; set; }
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int? ReadCount { get; set; }
        /// <summary>
        /// 后缀
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 展示图
        /// </summary>
        public IList<ProductImages> ProductImages { get; set; }
    }
}
