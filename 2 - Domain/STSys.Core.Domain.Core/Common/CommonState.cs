using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace STSys.Core.Domain.Core.Common
{
    public enum CommonState
    {
        正常,
        禁止,
        删除
    }
    /// <summary>
    /// 是否可用标识
    /// </summary>
    public enum E_Flag
    {
        可用,
        不可用
    }
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum E_UserType
    {
        游客 = 0,
        企业用户 = 1,
        服务顾问 = 2,
        管理员 = 3
    }
    /// <summary>
    /// 提现方式
    /// </summary>
    public enum E_WithdrawalsType
    {
        微信 = 1,
        支付宝 = 2,
        银行卡 = 3
    }

    /// <summary>
    /// 优惠券使用状态
    /// </summary>
    public enum E_CouponStatus
    {
        初始,
        已使用,
        已过期,
        已领取,
        使用中 = 4
    }
    /// <summary>
    /// 订单资料数据类型
    /// </summary>
    public enum E_OrderFileDataType
    {
        资料模板 = 0,
        资料图片 = 1,
        资料文档 = 2
    }
    /// <summary>
    /// 订单所需资料状态
    /// </summary>
    public enum E_OrderFileDataStatus
    {
        初始 = 0,
        待审核 = 1,
        审核通过 = 2,
        审核不通过 = 3
    }
    public enum E_OrderDetailRefundStatus
    {
        未申请退款 = 0,
        退款审核中 = 1,
        退款审核通过 = 2,
        退款审核失败 = 3
    }
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum E_Order_Status
    {
        已失效 = -2,
        已取消 = -1,
        待付款 = 0,
        已付款,
        待设定价格,
        已拆单
    }
    /// <summary>
    /// 订单明细状态
    /// </summary>
    public enum E_OrderDetails_Status
    {
        已失效 = -2,
        已取消 = -1,
        待付款 = 0,
        已付款,
        待设定价格,
        已签合同,
        服务完成,
        买家已确认,
        申请退款,
        退款审核通过,
        退款审核失败,
        已完结,
        //无选择 = 100
    }

    public enum E_RefundState
    {
        初始,
        审核通过,
        审核不通过,
        平台审核通过,
        平台审核不通过,
        财务审核通过,
        财务审核不通过,
        已退款
    }
    /// <summary>
    /// 普通订单进程类型
    /// </summary>
    public enum E_DocumentaryType
    {
        服务进程 = 1,
        服务成果 = 2,
    }
    /// <summary>
    /// 分期订单进程类型
    /// </summary>
    public enum E_DocumentaryPeriodType
    {
        普通动态 = 1,
        服务完成 = 2,
        企业主验收 = 3,
    }
    /// <summary>
    /// 消费记录类型
    /// </summary>
    public enum E_UsersBalanceInfoType
    {
        充值 = 1,
        商城消费 = 2,
        红包兑换 = 3,
        提现 = 4,
        开通PLUS = 5,
        商标注册消费 = 6,
        分享赠送红包 = 7,
        提现驳回 = 8,
        退款 = 9
    }
    /// <summary>
    /// 合同模板类型
    /// </summary>
    public enum E_ContractModuleType
    {
        文本 = 0,
        工期 = 1,
        基本模块 = 2
    }

    public enum E_Product
    {
        初始,
        审核未通过,
        审核通过,
        删除
    }

    /// <summary>
    /// 企业主状态显示
    /// </summary>
    public enum E_UsersDisplayState
    {
        a已取消 = -2,
        b已取消 = -1,
        a待付款 = 0,
        a待签合同 = 1,
        a待设定价格 = 2,
        a服务中 = 3,
        b服务中 = 4,
        a已完成 = 5,
        c服务中 = 6,
        d服务中 = 7,
        e服务中 = 8,
        b已完成 = 9
    }
    /// <summary>
    /// 服务顾问记录类型
    /// </summary>
    public enum E_ConsultantLoginLogType
    {
        登录 = 0,
        上班打卡 = 1,
        退出 = 2,
        下班打卡 = 3
    }

    /// <summary>
    /// 验证码验证类型
    /// </summary>
    public enum E_VerificationCodeType
    {
        注册 = 0,
        手机动态码登录 = 1,
        发布需求 = 2,
        企业修改密码 = 3,
        企业修改新手机号对旧手机号验证 = 4,
        企业修改新手机号对新手机号验证 = 5,
        企业修改邮箱 = 6,
        服务顾问修改密码 = 7,
        服务顾问修改新手机号对旧手机号验证 = 8,
        服务顾问修改新手机号对新手机号验证 = 9,
        服务顾问修改邮箱 = 10,
        服务顾问提现 = 11,
        企业用户提现 = 15,
        企业找回密码 = 16,
        顾问找回密码 = 17,
        企业绑定支付宝 = 18,
        顾问绑定支付宝 = 19
    }
}
/// <summary>
/// 个人认证审核
/// </summary>
public enum E_ConsultantPerAuthenStatus
{
    编辑资料 = -1,
    待审核 = 0,
    审核未通过 = 1,
    审核通过 = 2
}
/// <summary>
/// 实名认证审核状态
/// </summary>
public enum E_ConsultantIsRealName
{
    待填写认证资料 = 0,
    已填写资料 = 1,
    审核未通过 = 2,
    审核通过 = 3
}

public enum E_Column_DataSource
{
    自定义   
}
public enum E_Column_Source
{
    pc,
    wap,
    微信,
    其他
}

public enum E_Column_identify
{
    [Description("cptj")]
    产品推荐
}

public class EnumExtend
{
    static public List<SelectListItem> ToListItem<T>()
    {
        List<SelectListItem> li = new List<SelectListItem>();
        foreach (int s in Enum.GetValues(typeof(T)))
        {
            li.Add(new SelectListItem
            {
                Value = s.ToString(),
                Text = Enum.GetName(typeof(T), s)
            }
            );
        }
        return li;
    }

    /// <summary>
    /// 枚举转换SelectListItem
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selectValeue"></param>
    /// <returns></returns>
    static public List<SelectListItem> ToListItem<T>(int selectValeue)
    {
        List<SelectListItem> li = new List<SelectListItem>();
        foreach (int s in Enum.GetValues(typeof(T)))
        {
            li.Add(new SelectListItem
            {
                Value = s.ToString(),
                Text = Enum.GetName(typeof(T), s),
                Selected = s == selectValeue ? true : false
            }
            );
        }
        return li;
    }
    /// <summary>
    /// 获取枚举描述
    /// </summary>
    /// <param name="en"></param>
    /// <returns></returns>
    static public string GetEnumDesc(Enum en)
    {
        Type type = en.GetType();
        MemberInfo[] memInfo = type.GetMember(en.ToString());
        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attr = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attr != null && attr.Length > 0)
                return ((DescriptionAttribute)attr[0]).Description;
        }
        return en.ToString();
    }

    static public List<SelectListItem> ToListItemDesc<T>()
    {
        List<SelectListItem> li = new List<SelectListItem>();
        Type type = typeof(T);
        MemberInfo[] memInfo = type.GetMembers();
        foreach (var item in memInfo)
        {
            object[] attr = item.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attr != null && attr.Length > 0)
            {
                li.Add(new SelectListItem
                {
                    Value = ((DescriptionAttribute)attr[0]).Description,
                    Text = item.Name
                });

            }
        }
        return li;
    }
}

