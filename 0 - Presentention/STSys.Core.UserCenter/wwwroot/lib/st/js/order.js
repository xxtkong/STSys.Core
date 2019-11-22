// 我的订单
$(function () {
    $('#chooseTime span,#chooseTtate span').on('mouseenter', function () {
        $(this).siblings('ul').slideDown();
    });
    $('#chooseTime ul,#chooseTtate ul').on('mouseleave', function () {
        $(this).slideUp();
    });
    $('#chooseTime span,#chooseTtate span').on('click', function () {
        $(this).siblings('ul').slideToggle();
    });
});
