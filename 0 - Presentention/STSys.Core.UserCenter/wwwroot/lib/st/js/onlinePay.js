// 支付方法
$(function () {
    $('#payList li').on('click', function (e) {
        e.stopPropagation();
        $(this).addClass('checked').siblings().removeClass('checked');
        $(this).find('input[type=radio]').prop('checked', 'checked');
    });

});
