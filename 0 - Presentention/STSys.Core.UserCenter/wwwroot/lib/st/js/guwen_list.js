$(function () {
    $('.select_container .select_resitem').mouseenter(function () {
        $(this).css({
            border: '1px solid #ff7900'
        });
    }).mouseleave(function () {
        $(this).css({
            border: ''
        });
    });
    // $('.select_container .select_resitem').find('a').on('click', function (e) {
    //    e.stopPropagation();
    //    showPop();
    // });
    // 选择工作经验
    $('.more_select .jingyan li').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
    });
    $('.pro_type').on('click', 'a', function () {
        $(this).addClass('checked').siblings().removeClass('checked');
    });
});
