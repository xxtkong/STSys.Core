$(function () {
    $('#companyLeft dl').on('click', 'dt', function () {
        // $(this).toggleClass('current');
        $(this).parent().find('dd').slideToggle();
    });
    // PLUS会员特权进入
    $('#plusBox .item').on('mouseenter', function () {
        $(this).find('.img').css({
            backgroundColor: '#ff7900'
        });
        $(this).find('i').css({
            color: '#fff'
        });
        $(this).find('p').css({
            color: '#ff7900'
        });
    });
    // PLUS会员特权离开
    $('#plusBox .item').on('mouseleave', function () {
        $(this).find('.img').css({
            backgroundColor: '#fff'
        });
        $(this).find('i').css({
            color: '#ff7900'
        });
        $(this).find('p').css({
            color: '#323232'
        })
    });
    // 点击账户设置
    $('.accountSet').on('click', function (e) {
        var e = e || window.e;
        e.stopPropagation();
        $(this).parent().find('.drop_box').slideToggle();
        $(this).toggleClass('active');
    });
    // 点击页面其他地方
    $(document).click(function () {
        $('.drop_box').hide();
        $('.account_set').removeClass('active');
    });
    // 账户中心充值页面。点击充值方式
    $('.payList ul').on('click', 'li', function () {
        $(this).addClass('checked').siblings().removeClass('checked');
    });
});
