$(function () {
    // 点击蒙版，关闭pop
    $('.pop_div').on('click', hidePop);
    // 新用户注册
    $('.register_btn').on('click', function () {
        window.location.href = 'http://www.shoutu.com.cn/register.html';
    });
    // 点击活动细则
    $('.section1_main .a_link').on('click', function () {
        $('.pop_div,.active_rule_wrap').show();
    });
    //立即预定 按钮弹窗
    $("body").on('click', '.book_btn', function () {
        var res_type = $(this).data('type');
        $('.pop_dialog .form').find('.input_style1').hide();
        $('.pop_dialog').find('.operateBtn').css({ 'margin-top': '40px' });
        $('.pop_dialog').find('.operateBtn').text('立即预定');
        if (res_type == 0) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        } else if (res_type == 1) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        }

    });
    //专利申请 按钮弹窗
    $("body").on('click', '.apply_btn', function () {
        var res_type = $(this).data('type');
        $('.pop_dialog .form').find('.input_style1').hide();
        $('.pop_dialog').find('.operateBtn').css({ 'margin-top': '40px' });
        $('.pop_dialog').find('.operateBtn').text('立即申请');
        if (res_type == 0) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        } else if (res_type == 1) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        } else if (res_type == 2) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        }

    });
    //商标抢购 按钮弹窗
    $("body").on('click', '.shopping_btn', function () {
        var res_type = $(this).data('type');
        $('.pop_dialog .form').find('.input_style1').show();
        $('.pop_dialog').find('.operateBtn').css({ 'margin-top': '0px' });
        $('.pop_dialog').find('.operateBtn').text('立即抢购');
        if (res_type == 0) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        } else if (res_type == 1) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        } else if (res_type == 2) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        } else if (res_type == 3) {
            var res_text = $(this).data('text');
            showDialog(res_text);
            return false;
        }

    });
});

function showDialog(res_text) {
    $('.pop_div,.pop_dialog').show();
    $('.pop_dialog').find('.title').text(res_text);
}
