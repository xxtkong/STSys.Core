/**
 * Created by LeeNing on 2018/3/17.
 */
$(function () {
    $('.select li.select-text').on('click', function (e) {
        e.stopPropagation();
        $(this).siblings('li').stop().slideToggle(500);
    });
});

$(window).click(function (event) {
    event.stopPropagation();
    //下拉选框
    var className = event.target.className;
    var $selectList = $('.select-list');
    var $select = $('.select');
    $select.removeClass('select-index');
    $selectList.hide();
    switch (className) {
        case 'select-text':
            var selectText = $(event.target);
            var ul = selectText.parents('ul');
            ul.addClass('select-index');
            ul.find('.select-list').show();
            break;
        case 'drp-item':
            var span = $(event.target);
            var ul = span.parents('ul');
            var text = ul.find('.select-text');
            var val = span.attr('value');
            var html = span.html() + '<i class="iconfont icon-xiala"></i>';
            ul.attr('value', val);
            text.html(html);
            break;
    }
});