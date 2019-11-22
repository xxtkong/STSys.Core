$(function () {
    // 点击修改登录名
    $('.change').on('click', function (e) {
        var e = e || window.event;
        var $u_name = $('.u_name').html();
        $(this).siblings('input').attr('type', 'text');
        $(this).siblings('input').attr('value', $u_name);
        $('.base_info .name').find('input').show();
        $(this).siblings('span').hide();
        $('.change').show();
        e.stopPropagation();
        // 点击页面其他地方
        $(document).click(function () {
            var $u_name = $('.base_info .name').find('input').val();
            $('.u_name').show();
            $('.u_name').html($u_name);
            $('.base_info .name').find('input').hide();
            $('.base_info .name').find('a').show();
        });
    });

    $('.base_info .name').find('input').click(function (e) {
        var e = e || window.event;
        $(this).show();
        e.stopPropagation();
    });


    // 点击兴趣爱好
    $('.hobby_sort a').on('click', function () {
        $(this).toggleClass("checked");
    });
});
