using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Models
{
    public class ProductViewModel
    {



        ///<summary>
        ///Id
        ///</summary>
        public int Id { set; get; }


        ///<summary>
        ///标题
        ///</summary>
        public string Title { set; get; }


        ///<summary>
        ///分类ID
        ///</summary>
        public int CategoryId { set; get; }


        ///<summary>
        ///分类编号
        ///</summary>
        public string CategoryCode { set; get; }


        ///<summary>
        ///需求详情
        ///</summary>
        public string DemandContent { set; get; }


        ///<summary>
        ///服务地区ID
        ///</summary>
        public int AreaId { set; get; }


        ///<summary>
        ///联系方式
        ///</summary>
        public string Mobile { set; get; }


        ///<summary>
        ///发布人ID
        ///</summary>
        public int UserId { set; get; }


        ///<summary>
        ///发布人
        ///</summary>
        public string UserName { set; get; }


        ///<summary>
        ///顾问ID
        ///</summary>
        public string ConsultantId { set; get; }


        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime CreateTime { set; get; }


        ///<summary>
        ///IP
        ///</summary>
        public string Ip { set; get; }


        ///<summary>
        ///状态
        ///</summary>
        public int Status { set; get; }


        ///<summary>
        ///IsHots
        ///</summary>
        public bool IsHots { set; get; }


        ///<summary>
        ///Price
        ///</summary>
        public decimal Price { set; get; }


        ///<summary>
        ///ProvinceId
        ///</summary>
        public int ProvinceId { set; get; }


        ///<summary>
        ///CityId
        ///</summary>
        public int CityId { set; get; }


        ///<summary>
        ///ManagerID
        ///</summary>
        public int ManagerID { set; get; }


        ///<summary>
        ///CheckDate
        ///</summary>
        public DateTime CheckDate { set; get; }


        ///<summary>
        ///CheckRemark
        ///</summary>
        public string CheckRemark { set; get; }


        ///<summary>
        ///UpdateTime
        ///</summary>
        public DateTime UpdateTime { set; get; }


        ///<summary>
        ///ManagerName
        ///</summary>
        public string ManagerName { set; get; }


        ///<summary>
        ///fulfilDate
        ///</summary>
        public DateTime fulfilDate { set; get; }


        ///<summary>
        ///BasicPicUrl
        ///</summary>
        public string BasicPicUrl { set; get; }
        public string Summary { get; set; }
        public Nullable<decimal> SalePrice { get; set; }

    }
}
