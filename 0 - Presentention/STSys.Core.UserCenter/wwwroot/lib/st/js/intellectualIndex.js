$(function () {
    // 知识产权首页
    $('.data_list .numberScroll').numScroll();
    // 商标按钮
    $('.tradeBtn').on('click', function () {
        var $tradeName1 = $('#tradeName1').val();
        $('.tradeForm [name="tradeName2"]').val($tradeName1);
        $('.pop_div,.popTrade').show();
        $('.popTrade .numberScroll').numScroll();

    });
    // 专利按钮
    $('.zhuanliBtn').on('click', function () {
        var $zhuanliName = $('#zhuanliName').val();
        console.log($zhuanliName);
        $('.zhuanliForm [name="tradeName2"]').val($zhuanliName);
        $('.pop_div,.popZhuanLi').show();
        $('.popZhuanLi .numberScroll').numScroll();
    });
    // 版权按钮
    $('.banquanBtn').on('click', function () {
        var $banquanName = $('#banquanName').val();
        console.log($banquanName);
        $('.banquanForm [name="tradeName2"]').val($banquanName);
        $('.pop_div,.popBanQuan').show();
        $('.popBanQuan .numberScroll').numScroll();
    });
    // 点击获取结果(商标查询)
    $('.tradeFormBtn').on('click', submitTrade);
     // 点击获取结果(专利查询)
    $('.zhuanliFormBtn').on('click', submitZhuanli);
    // 点击获取结果(版权查询)
    $('.banquanFormBtn').on('click', submitBanquan);
    //成功弹窗里的确认
    $(".confirmBtn1").click(function () {
        $(".pop_success_wrap,.pop_div").hide();
        $('.tradeForm #tradeName1').val('');
        $('.tradeForm #ContentName2').val('');
        $(".tradeForm [name='tradeName2']").val('');
        $(".tradeForm [name='Mobile']").val('');
        $(".tradeForm [name='UserName']").val('');
        $('.zhuanliForm #tradeName1').val('');
        $('.zhuanliForm #ContentName2').val('');
        $(".zhuanliForm [name='tradeName2']").val('');
        $(".zhuanliForm [name='Mobile']").val('');
        $(".zhuanliForm [name='UserName']").val('');
        $('.banquanForm #tradeName1').val('');
        $('.banquanForm #ContentName2').val('');
        $(".banquanForm [name='tradeName2']").val('');
        $(".banquanForm [name='Mobile']").val('');
        $(".banquanForm [name='UserName']").val('');
    });
    //专利弹窗里的确认

    //版权弹窗里的确认
    $('.tab_ul .tab_li').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var index = $(this).index();
        $('.tab_content_wrap .tab_content').eq(index).addClass('selected').siblings().removeClass('selected');
    });
    $('.tradeLists .item').on('click', function () {
        $(this).toggleClass('open').siblings().removeClass('open');
    });
    // $('.tradeLists .item').on('click', function () {
    //     $(this).find('.tit_con').slideToggle();
    //     // $(this).parents('item').siblings().find('.tit_con').slideUp();
    // });

    //dom 点击的当前元素   drop  下一级菜单
    function dropsSwift(dom, drop) {

    }
    
});
function isPhoneNo(phone) {
    var pattern = /^1[3456789]\d{9}$/;
    return pattern.test(phone);
}
//提交商标查询
function submitTrade() {
    if ($(".tradeForm [name='tradeName2']").val() == "") {
        layer.msg("请输入您的商标名称", { time: 3000, icon: 5 });
        return;
    }
    if ($(".tradeForm [name='Mobile']").val() == "") {
        layer.msg("请输入您的联系电话", { time: 3000, icon: 5 });
        return;
    }
    if (!isPhoneNo($(".tradeForm [name='Mobile']").val())) {
        layer.msg("请输入正确的手机号", { time: 3000, icon: 5 });
        return;
    }
    if ($(".tradeForm [name='UserName']").val() == "") {
        layer.msg("请输入联系人", { time: 3000, icon: 5 });
        return;
    }
    var model = {
        CompanyName: $(".tradeForm [name='tradeName2']").val(),
        UserName: $(".tradeForm [name='UserName']").val(),
        Mobile: $(".tradeForm [name='Mobile']").val(),
        Source: $(".tradeForm [name='Source']").val(),
    }
    //var model = $(".tradeForm").serialize();
    $.post("/MobileMsg/AddMobileMsg", model, function (d) {
        if (d.success) {
            $('.popTrade').hide();
            $('.pop_success_wrap,.pop_div').show();
            $(".tradeForm [name='tradeName']").val('');
            $(".tradeForm [name='Mobile']").val('');
            $(".tradeForm [name='UserName']").val('');
        } else {
            layer.msg(data, { time: 3000, icon: 2 });
        }
    });
}
// 提交专利查询
function submitZhuanli() {
    if ($(".zhuanliForm [name='tradeName2']").val() == "") {
        layer.msg("请输入专利名称", { time: 3000, icon: 5 });
        return;
    }
    if ($(".zhuanliForm [name='Mobile']").val() == "") {
        layer.msg("请输入您的联系电话", { time: 3000, icon: 5 });
        return;
    }
    if (!isPhoneNo($(".zhuanliForm [name='Mobile']").val())) {
        layer.msg("请输入正确的手机号", { time: 3000, icon: 5 });
        return;
    }
    if ($(".zhuanliForm [name='UserName']").val() == "") {
        layer.msg("请输入联系人", { time: 3000, icon: 5 });
        return;
    }
    var model = {
        CompanyName: $(".zhuanliForm [name='tradeName2']").val(),
        UserName: $(".zhuanliForm [name='UserName']").val(),
        Mobile: $(".zhuanliForm [name='Mobile']").val(),
        Source: $(".zhuanliForm [name='Source']").val(),
    }
    //var model = $(".zhuanliForm").serialize();
    $.post("/MobileMsg/AddMobileMsg", model, function (d) {
        if (d.success) {
            $('.popZhuanLi').hide();
            $('.pop_success_wrap,.pop_div').show();
            $(".zhuanliForm [name='tradeName']").val('');
            $(".zhuanliForm [name='Mobile']").val('');
            $(".zhuanliForm [name='UserName']").val('');
        } else {
            layer.msg(data, { time: 3000, icon: 2 });
        }
    });
}
// 版权提交
function submitBanquan() {
    if ($(".banquanForm [name='tradeName2']").val() == "") {
        layer.msg("请输入您的版权名称", { time: 3000, icon: 5 });
        return;
    }
    if ($(".banquanForm [name='Mobile']").val() == "") {
        layer.msg("请输入您的联系电话", { time: 3000, icon: 5 });
        return;
    }
    if (!isPhoneNo($(".banquanForm [name='Mobile']").val())) {
        layer.msg("请输入正确的手机号", { time: 3000, icon: 5 });
        return;
    }
    if ($(".banquanForm [name='UserName']").val() == "") {
        layer.msg("请输入联系人", { time: 3000, icon: 5 });
        return;
    }
    var model = {
        CompanyName: $(".banquanForm [name='tradeName2']").val(),
        UserName: $(".banquanForm [name='UserName']").val(),
        Mobile: $(".banquanForm [name='Mobile']").val(),
        Source: $(".banquanForm [name='Source']").val(),
    }
    //var model = $(".banquanForm").serialize();
    $.post("/MobileMsg/AddMobileMsg", model, function (d) {
        if (d.success) {
            $('.popBanQuan').hide();
            $('.pop_success_wrap,.pop_div').show();
            $(".banquanForm [name='tradeName']").val('');
            $(".banquanForm [name='Mobile']").val('');
            $(".banquanForm [name='UserName']").val('');
        } else {
            layer.msg(data, { time: 3000, icon: 2 });
        }
    });
}

