// 我的订单
$(function () {
    $('.chooseTime  span,.chooseTtate span').on('click', function (e) {
        $(this).siblings('ul').slideToggle();
    });
    // 我的订单Tab切换
    $('#orderWrap .order_con .order_state_title ul').on('click', 'li', function () {
        $(this).addClass('current').siblings().removeClass('current');
        var index = $(this).index();
        $('#orderWrap .tabcontent1').eq(index).addClass('selected').siblings().removeClass('selected');
    });

    // 点击近7天，近1个月
    $('.chooseTime ul').on('click', 'li', function () {
        var curtext = $(this).html();
        var curValue = $(this).data('value');
        $(this).parents('.chooseTime').find('b').html(curtext);
        $(this).parents('.chooseTime').find('b').data('value', curValue);
        $(this).parent('ul').slideUp();
    });
    // 点击每个状态
    $('.chooseTtate ul').on('click', 'li', function () {
        var curtext = $(this).html();
        var curValue = $(this).data('value');
        console.log(curValue);
        $(this).parents('.chooseTtate').find('b').html(curtext);
        $(this).parents('.chooseTtate').find('b').data('value', curValue);
        $(this).parent('ul').slideUp();
    });

    // 我的评价 Tab切换
    $('#orderState ul').on('click', 'li', function () {
        $(this).addClass('current').siblings().removeClass('current');
        var index = $(this).index();
        $('.order_con .tabcontent').eq(index).addClass('selected').siblings().removeClass('selected');
    });
    // 显示删除
    $('.order_template table thead').mouseenter(function () {
        $(this).find('.delete_icon i').addClass('visi_visible');
    }).mouseleave(function () {
        $(this).find('.delete_icon i').removeClass('visi_visible');
    });
    // 待付款订单倒计时
    // timer(intDiff);
});
