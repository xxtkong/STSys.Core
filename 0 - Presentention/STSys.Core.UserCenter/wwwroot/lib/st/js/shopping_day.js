$(function () {
    // 点击蒙版，关闭pop
    $('.pop_div').on('click', hidePop);
    // 点击活动细则
    $('.couponBtn').on('click', function () {
        $('.pop_div,.coupon_wrap').show();
    });
    //立即购买~立即抢购~
    $("body").on('click', '.optionBtn', function () {
        var res_text = $(this).data('text');
        if (res_text == '商标智能注册') {
            // window.location.href = '';
            alert('跳转到注册商标的页面');
            return false;
        } else if (res_text == '领取优惠券') {
            $('.pop_dialog .form').find('.input_style1').hide();
            $('.pop_dialog').find('.operateBtn').css({'margin-top': '40px'});
            $('.pop_dialog').find('.operateBtn').text('立即领取');
            showDialog(res_text);
            return false;
        } else {
            $('.pop_dialog .form').find('.input_style1').show();
            $('.pop_dialog').find('.operateBtn').css({'margin-top': '0px'});
            $('.pop_dialog').find('.operateBtn').text('立即购买');
            showDialog(res_text);
        }
    });
});

function showDialog(res_text) {
    $('.pop_div,.pop_dialog').show();
    $('.pop_dialog').find('.title').text(res_text);
}
