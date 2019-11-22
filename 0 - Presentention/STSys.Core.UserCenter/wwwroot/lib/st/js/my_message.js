$(function () {
    $('.message_content .state ul li').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var index = $(this).index();
        $('.tab_content_wrap .tab_content').eq(index).addClass('selected').siblings().removeClass('selected');
    });
});
