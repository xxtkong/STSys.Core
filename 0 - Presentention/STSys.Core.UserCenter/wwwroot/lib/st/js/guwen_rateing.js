$(function () {
    $('.tabTitle>ul>li').on('click', function () {
        $(this).addClass('checked').siblings().removeClass('checked');
        var index = $(this).index();
        $('.tabContent .content_list').eq(index).addClass('selected').siblings().removeClass('selected');
    });
    // 点击好评中评差评
    $('.rateTit>ul>li').on('click', function () {
        $(this).addClass('checked').siblings().removeClass('checked');
    });
})
