using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Models
{
    public class OrderDetailsViewModel
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string OrderNo { get; set; }
        public string SonOrderNo { get; set; }
        public short Status { get; set; }
        public Nullable<bool> UserIsSign { get; set; }
        public Nullable<bool> ConsultantIsSign { get; set; }
        public Nullable<int> ContractId { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> AreaId { get; set; }
        public Nullable<int> SetMealAreaId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> DiscountPrice { get; set; }
        public Nullable<decimal> InsurancePrice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ConsultantId { get; set; }
        public Nullable<decimal> PaymentPrice { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public short OrderSource { get; set; }
        public Nullable<bool> EvaluateIsSign { get; set; }
        public Nullable<bool> IsComplaint { get; set; }
        public Nullable<decimal> PayablePrice { get; set; }
        public Nullable<DateTime> ConsultantCompleteTime { get; set; }
        public Nullable<DateTime> UsersCompleteTime { get; set; }
        public Nullable<bool> ConsultantSign { get; set; }
        public Nullable<bool> UsersSign { get; set; }
        public string Explain { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<decimal> RedPrice { get; set; }
        public Nullable<decimal> IntegralPrice { get; set; }
        public Nullable<decimal> RefundPrice { get; set; }
        public Nullable<decimal> AcquirePercentage { get; set; }
        public Nullable<decimal> AcquirePrice { get; set; }
        public Nullable<DateTime> PayTime { get; set; }
        public string SpecificationsName { get; set; }
        public string ProductName { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantPic { get; set; }
        public string CouponCode { get; set; }
        public short PayType { get; set; }
        public Nullable<bool> IsPeriod { get; set; }
        public Nullable<int> PeriodNum { get; set; }
        public Nullable<int> PeriodTimePoint { get; set; }
        public Nullable<int> PendingPaymentSendMessageCount { get; set; }
        public Nullable<int> PendingSignedSendMessageCount { get; set; }
        public string TradeNo { get; set; }
        public Nullable<int> DigestConsultantId { get; set; }
        public string DigestConsultantName { get; set; }
        public string DigestConsultantPic { get; set; }
        public Nullable<int> RefundStatus { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> IsPayPeriod { get; set; }
        public Nullable<int> NumPayPeriod { get; set; }
        public string RatioPayPeriod { get; set; }
        public string PayPeriodOrderNo { get; set; }
        public Nullable<bool> ProductIsPayPeriod { get; set; }
        public Nullable<decimal> SalePercentage { get; set; }
        public Nullable<decimal> SaleAcquirePrice { get; set; }
        public Nullable<decimal> RevisionPrice { get; set; }

        //非实体字段 start
        public string BasicPicUrl { get; set; }
        public string InsuranceInfo { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }
        public string UserPicUrl { get; set; }
        public string UserMobile { get; set; }
        public string ProductSummary { get; set; }
        //非实体字段 end
    }
}
