$(function () {
    // 点击套餐显示对应的内容
    $('.productTypeList li, #conItem li').on('click', function (e) {
        var e = e || window.event;
        var index = $(this).index();
        $(this).addClass('active').siblings().removeClass('active');
        $(this).parent().siblings('.con_item').show().find('li').eq(index).show().siblings().hide();
        $('#hideAddress').hide();
        $('#hideBaoxian').hide();
        // e.stopPropagation();
        stopPropagation(e);
    });
    // 服务地址
    var $serverAddress = $('.service_item .server_address');
    // 隐藏地址里面 的标题
    var $serverUl = $('.service_item .hide_address .hide_title ul');

    // 点击服务地址
    $serverAddress.on('click', function (e) {
        var e = e || window.event;
        $(this).parent().find('.hide_address').toggle();
        $('#hideBaoxian').hide();
        // e.stopPropagation();
        stopPropagation(e);

    });
    // 点击里面内容
    $serverUl.on('click', 'li', function (e) {
        var e = e || window.event;
        $(this).addClass('active').siblings().removeClass('active');
        var index = $(this).index();
        var $hide_cont = $('.product-service-provider .service_item .hide_address .hide_cont');
        $hide_cont.show();
        $hide_cont.find('.cont').eq(index).addClass('selected').siblings().removeClass('selected');
        $hide_cont.css({
            borderTop: '2px solid #2180f6'
        });
        $(this).parent().css({
            borderBottomColor: '#fff'
        });
        // e.stopPropagation();
        stopPropagation(e);
    });
    // 点击微信咨询
    $('.product-service-top .wx_btn').on('click', function (e) {
        var e = e || window.event;
        stopPropagation(e);
        $(this).parents('.online_ask').find('.wx_ask_pop').toggleClass('show');
    });
    // 点击页面其他地方
    $(document).click(function () {
        $('#conItem,#hideAddress,#hideBaoxian').hide();
        $('.wx_ask_pop').removeClass('show');
    });
   
    // 点击保险
    $('#serviceBaoxian').on('click', function (e) {
        var e = e || window.event;
        // e.stopPropagation();
        $(this).parent().find('#hideBaoxian').toggle();
        stopPropagation(e);
    });

    // 点击保险列表，改变上面span内容
    $('.hide_baoxian ul').on('click', 'li', function () {
        var _html = $(this).html();
        var value = $(this).attr("value");
        $('#serviceBaoxian').find('span').html(_html).attr("value", value);

        $('.hide_baoxian').hide();
    });


    // 推荐服务商
    $('.recommendServiceList ul li').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
    });
    // 切换服务介绍，雇主评价...
    $('.relatedRightNav li').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var index = $(this).index();
        $('.producrInfo .productItem').eq(index).addClass('selected').siblings().removeClass('selected');
    });

    // 点击领取优惠券
    //$('.other-discount .manjian,.other-discount .taocan').on('click', function () {
    //    $('#toolbarFix').css({
    //        right: '270px'
    //    });
    //    $('.fixed_coupon_box').show(200);
    //});
    // 点击右侧领取优惠券图标
    $('.coupon_icon').on('click', function () {
        $('.coupon_icon .icon_box').css({
            background: '#ff7900',
            color: '#fff'
        });
        $('.coupon_icon a i').css({
            background: '#ff7900',
            color: '#fff'
        });
        $('#toolbarFix').css({
            right: '270px'
        });
        $('.fixed_coupon_box').show(200);
    });
    //// 点击弹框里面的领取...
    //$('.getCouponBtn').on('click',function(){
    //    $(this).html('已领取');
    //    $(this).parent('.coupon_item').addClass('already_get');
    //    $(this).parent('.coupon_item').find('.tips').hide();
    //});
    //// 点击关闭
    //$('.coupon_top .close').on('click', function () {
    //    $('#toolbarFix').css({
    //        right: '0px'
    //    });
    //    $('.fixed_coupon_box').hide(200);
    //    $('.coupon_icon a').css({
    //        background: '#333',
    //        color: '#fff'
    //    });
    //    $('.coupon_icon a i').css({
    //        background: '#333',
    //        color: '#fff'
    //    });
    //});


    // 左边图片轮播


});

