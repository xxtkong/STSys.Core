// 功能：企业主服务顾问提现
$(function () {
    // 点击获取验证码
    $('#getsmsCode').on('click', function () {
        time(this);
    });
    // 点击提现账号
    $('.account_type .input_box span').on('click', function (e) {
        var e = e || window.event;
        stopPropagation(e);
        $(this).parent().find('.account_type_ul').slideDown();
    });
    // 选择支付宝 微信
    $('.account_type_ul li').on('click', function (e) {
        var e = e || window.event;
        stopPropagation(e);
        var curHtml = $(this).html();
        var curValue = $(this).data('value');
        $(this).parents('.account_type .input_box').find('span').data('data-value', curValue)
        $(this).parents('.account_type .input_box').find('span').html(curHtml);
        $(this).parent('.account_type_ul').slideUp();
        // 当前选中的value
        var sel_value = $(this).parents('.account_type .input_box').find('span').data('data-value');
        if (sel_value == 1) {
            //微信
            $(this).parents('.input_box').find('.desc').html(
                '<b>已绑定微信账号：</b>' +
                '<a href="JavaScript:;"  class="wx_img">' +
                '<img src="" alt="">' +
                '</a>' +
                '<b>asdfgh</b>');
            return false;
        } else if (sel_value == 2) {
            //支付宝
            $(this).parents('.input_box').find('.desc').html(
                '<b>已绑定支付宝账号：</b>' +
                '<b>123456789</b>');
            return false;
        }
    });
    // 点击页面其他地方
    $(document).click(function () {
        $('.account_type .input_box .account_type_ul').slideUp();
    });
});
