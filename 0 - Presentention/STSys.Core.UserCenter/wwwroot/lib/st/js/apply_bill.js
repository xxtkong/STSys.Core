$(function () {
    // 初始化城市联动插件
    $("#sjld").sjld("#shenfen", "#chengshi", "#quyu");
    // 点击开票类型
    $('.select_type .radio-check').on('click', function () {
        var index = $(this).index();
        console.log(index);
        $('.fapiaoTab .tabContent').eq(index).addClass('selected').siblings().removeClass('selected');
        var curtype = $(this).data('type1');
        console.log(curtype);
        if (curtype == 0) {
            $('.fapiao_con .descType').html('普通发票，即增值税普通发票，适用于大部分公司');
        } else {
            $('.fapiao_con .descType').html('增值税专用发票，适用于一般纳税人公司，增值税已缴纳的额度可以用来抵税。');
        }
    });
    // 点击发票内容
    $('.fapiao_t .fapiaoType').click(function () {
        $(this).addClass('checked').siblings().removeClass('checked');
        var curtype = $(this).data('type');
        console.log(curtype);
        if (curtype == 0) {
            $('.fapiao_con .descCon').html('！发票内容将显示详细服务名称与价格信息');
        } else {
            $('.fapiao_con .descCon').html('！发票内容将显示本单服务所属类别（服务费）及价格信息');
        }
    });
    // 点击历史记录
    $('.history_box .history').on('click', function () {
        $(this).addClass('checked').parent().siblings().find('.history').removeClass('checked');
    });
    // 普通发票保存
    $('.normalBillSaveBtn').on('click', function () {
        checkNoramlSave();
    });
    // 增值税发票保存
    $('.addRevenueBillSaveBtn').on('click', function () {
        checkAddRevenueSave();
    });
    // 普通发票确认
    $('.confirm').on('click', function () {
        checkNormalBill();
    });

});

// 普通发票验证
function checkNormalBill() {
    // 发票抬头
    var $fapiaoTaiTou = $('.fapiaoTaiTou');
    // 新增发票抬头
    var $fapiaoTaiTouNew = $('.fapiaoTaiTouNew');
    // 纳税人识别号
    var $identifyNum = $('.identifyNum');
    // 联系人姓名
    var $contactName = $('.contactName');
    // 联系人电话
    var $contactPhone = $('.contactPhone');
    // 详细地址
    var $addressDetail = $('.addressDetail');
    if ($fapiaoTaiTou.val() == '' || $fapiaoTaiTou.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.taitouWrap').find('p.remind_tips').show();
        return false;
    } else if ($fapiaoTaiTouNew.val() == '' || $fapiaoTaiTouNew.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.newTaiTouWrap').find('p.remind_tips').show();
        return false;
    } else if ($identifyNum.val() == '' || $identifyNum.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.identifyWrap').find('p.remind_tips').show();
        return false;
    } else if ($contactName.val() == '' || $contactName.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.contactNameWrap').find('p.remind_tips').show();
        return false;
    } else if ($contactPhone.val() == '' || $contactPhone.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.contactPhoneWrap').find('p.remind_tips').show();
        return false;
    } else if ($addressDetail.val() == '' || $addressDetail.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.addressDetailWrap').find('p.remind_tips').show();
        return false;
    } else {
        $('.fapiao_con').find('p.remind_tips').hide();
        console.log('成功..');
    }
}

// 普通发票保存
function checkNoramlSave() {
    // 新增发票抬头
    var $fapiaoTaiTouNew = $('.fapiaoTaiTouNew');
    // 纳税人识别号
    var $identifyNum = $('.identifyNum');
    if ($fapiaoTaiTouNew.val() == '' || $fapiaoTaiTouNew.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.newTaiTouWrap').find('p.remind_tips').show();
        return false;
    } else if ($identifyNum.val() == '' || $identifyNum.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.identifyWrap').find('p.remind_tips').show();
        return false;
    } else {
        $('.fapiao_con').find('p.remind_tips').hide();
        console.log('成功..');
    }
}

// 增值税发票验证
function checkAddRevenueBill() {
    // 发票抬头
    var $fapiaoTaiTou1 = $('.fapiaoTaiTou1');
    // 新增发票抬头
    var $fapiaoTaiTouNew1 = $('.fapiaoTaiTouNew1');
    // 纳税人识别号
    var $identifyNum1 = $('.identifyNum1');
    // 公司注册地址
    var $regAddress = $('.regAddress');
    // 公司联系电话
    var $compPhone = $('.compPhone');
    // 公司开户行账号
    var $compAccount = $('.compAccount');
    // 联系人姓名
    var $contactName1 = $('.contactName1');
    // 联系人电话
    var $contactPhone1 = $('.contactPhone1');
    // 详细地址
    var $addressDetail1 = $('.addressDetail1');
    if ($fapiaoTaiTou1.val() == '' || $fapiaoTaiTou1.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.fapiaoTaiTouWrap1').find('p.remind_tips').show();
        return false;
    } else if ($fapiaoTaiTouNew1.val() == '' || $fapiaoTaiTouNew1.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.fapiaoTaiTouNewWrap1').find('p.remind_tips').show();
        return false;
    } else if ($identifyNum1.val() == '' || $identifyNum1.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.identifyNumWrap1').find('p.remind_tips').show();
        return false;
    } else if ($regAddress.val() == '' || $regAddress.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.regAddressWrap').find('p.remind_tips').show();
        return false;
    } else if ($compPhone.val() == '' || $compPhone.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.compPhoneWrap').find('p.remind_tips').show();
        return false;
    } else if ($compAccount.val() == '' || $compAccount.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.compAccountWrap').find('p.remind_tips').show();
        return false;
    } else if ($contactName1.val() == '' || $contactName1.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.contactNameWrap1').find('p.remind_tips').show();
        return false;
    } else if ($contactPhone1.val() == '' || $contactPhone1.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.contactPhonewrap1').find('p.remind_tips').show();
        return false;
    } else if ($addressDetail1.val() == '' || $addressDetail1.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.addressDetailWrap1').find('p.remind_tips').show();
        return false;
    } else {
        $('.fapiao_con').find('p.remind_tips').hide();
        console.log('成功..');
    }
}

// 增值税发票保存
function checkAddRevenueSave() {
    // 新增发票抬头
    var $fapiaoTaiTouNew1 = $('.fapiaoTaiTouNew1');
    // 纳税人识别号
    var $identifyNum1 = $('.identifyNum1');
    // 公司注册地址
    var $regAddress = $('.regAddress');
    // 公司联系电话
    var $compPhone = $('.compPhone');
    // 公司开户行账号
    var $compAccount = $('.compAccount');
    if ($fapiaoTaiTouNew1.val() == '' || $fapiaoTaiTouNew1.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.fapiaoTaiTouNewWrap1').find('p.remind_tips').show();
        return false;
    } else if ($identifyNum1.val() == '' || $identifyNum1.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.identifyNumWrap1').find('p.remind_tips').show();
        return false;
    } else if ($regAddress.val() == '' || $regAddress.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.regAddressWrap').find('p.remind_tips').show();
        return false;
    } else if ($compPhone.val() == '' || $compPhone.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.compPhoneWrap').find('p.remind_tips').show();
        return false;
    } else if ($compAccount.val() == '' || $compAccount.val() == ' ') {
        $('.fapiao_con').find('p.remind_tips').hide();
        $('.compAccountWrap').find('p.remind_tips').show();
        return false;
    } else {
        $('.fapiao_con').find('p.remind_tips').hide();
        console.log('成功..');
    }

}






