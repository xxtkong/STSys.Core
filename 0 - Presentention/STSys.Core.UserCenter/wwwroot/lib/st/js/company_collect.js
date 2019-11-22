// 企业个人中心收藏版块效果


$(function () {
    // 收藏的服务暂时没有效果
    // 收藏的活动 收藏的资讯
    $('.listContent').on('mouseenter', '.listItem', function () {
        $(this).find('.state').hide();
        $(this).find('.cancel').show();
    });
    $('.listContent').on('mouseleave', '.listItem', function () {
        $(this).find('.state').show();
        $(this).find('.cancel').hide();
    });
    // // 收藏的资讯
    // $('.listContent').on('mouseenter', '.listItem', function () {
    //     $(this).find('.state').hide();
    //     $(this).find('.cancel').show();
    // });
    // $('.listContent').on('mouseleave', '.listItem', function () {
    //     $(this).find('.state').show();
    //     $(this).find('.cancel').hide();
    // });
    // 收藏的问答
    $('.wendaContent').on('mouseenter', '.listItem', function () {
        $(this).find('.cancel').show();
    });
    $('.wendaContent').on('mouseleave', '.listItem', function () {
        $(this).find('.cancel').hide();
    });

});





