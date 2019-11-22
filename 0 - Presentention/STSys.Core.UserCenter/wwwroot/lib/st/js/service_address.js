$(function () {
    // 点击新增地址
    $('.add_newaddress').on('click', function () {
        $('.pop_div').show();
        $('.new_address').show();
        $('.pop_content .title').html('新增服务地址');
    });
    // 点击取消
    $('.cancel1').on('click', function () {
        $('.pop_div').hide();
        $('.new_address').hide();
    });
    // 点击关闭
    $('.close').on('click', function () {
        $('.pop_div').hide();
        $('.new_address').hide();
    });
    // 点击编辑地址
    $('.edit').on('click', function () {
        $('.pop_div').show();
        $('.new_address').show();
        $('.pop_content .title').html('编辑服务地址');
    });

});








