// 圆环进度条
$(function () {
    var total_score = 0;
    // 环形图
    $('.my_circle').each(function () {
        var num = $(this).find('span').text() * 3.6;
        // var score = parseInt($(this).find('span').html());
        // total_score += score;
        if (num <= 180) {
            $(this).find('.right').css('transform', "rotate(" + num + "deg)");
        } else {
            $(this).find('.right').css('transform', "rotate(-180deg)");
            $(this).find('.left').css('transform', "rotate(" + (num - 180) + "deg)");
        }
    });
    // $('.total_score').html(total_score);
});