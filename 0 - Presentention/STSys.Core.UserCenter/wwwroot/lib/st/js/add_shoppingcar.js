$(function () {
    // 点击近期热卖，最近浏览...
    $('.recommend_hotlist .hot_title li').click(function () {
        $(this).addClass('active').siblings().removeClass('active');
        var index = $(this).index();
        $('.hotContent .hotItem').eq(index).addClass('selected').siblings().removeClass('selected');
        swiper('.selected .swiper-container');
    });
    // 点击领取优惠券
    $('.operation .getCoupon').on('click', function (e) {
        //var e = e || window.event;
        //e.stopPropagation();
        //$(this).parent().parent().siblings('.coupon_wrap').show();
    });
    // 点击领取按钮。。。
    $('.coupon_wrap').find('.lingqu').on('click', function () {
        $(this).html('已领取');
        $(this).parent('.coupon_item').addClass('already_get');
    });
    $('.coupon_wrap').on('click', function (e) {
        var e = e || window.event;
        e.stopPropagation();
    });
    $(document).on('click', function () {
        $('.coupon_wrap').hide();
    });

    $(".selAll").click(function () {
        var res = $(this).prop('checked');
        $('.ulProduct input').prop('checked', res);
    });

    // 点击下面的input
    $('.ulProduct input').click(function () {
        var allLength = $('.ulProduct input').length;
        console.log(allLength);
        var checkedLength = $('.ulProduct input:checked').length;
        console.log(checkedLength);
        if (allLength == checkedLength) {
            $(".selAll").prop('checked', true);
        } else {
            $(".selAll").prop('checked', false);
        }
        $(".selAll").prop('checked', allLength == checkedLength);
    });
});
