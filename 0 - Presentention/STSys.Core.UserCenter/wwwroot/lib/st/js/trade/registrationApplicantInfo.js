
$(function(){
    $('.applyType li').on('click',function(){
        $(this).addClass('checked').siblings().removeClass('checked');
        var index = $(this).index();
        $('.info_item .content .tab_content').eq(index).addClass('selected').siblings().removeClass('selected');
        var curType = $(this).data('type');

        if(curType == 1) {
            // 企业
            $('.info_item .itemIdentity').hide();
            $('.businessLicense .businessLicenseBox img').attr('src','./images/shangbiao3a.png');
        }else {
            // 个体户
            $('.info_item .itemIdentity').show();
            $('.businessLicense .businessLicenseBox img').attr('src','./images/shangbiao3.png');

        }
    });
    // 点击上传文件注意事项
    $('.uploadfileBtn').on('click',function(){
        $('.pop_div,.uploadfileBox').show();
    });

    // 历史记录
    $('.inputHook').on('click', function (e) {
        var e = e || window.event;
        stopPropagation(e);
        $(this).parents('.item').find('.history_box').show();
    });

    $('.historyBox .hisList').on('click', function (e) {
        var e = e || window.event;
        stopPropagation(e);
        var curVal = $(this).data('value');
        $(this).parents('.item').find('.inputHook').attr('value', curVal);
        $(this).parents('.history_box ').hide();
    });

    $(document).on('click', function () {
        $('.history_box').hide();
    });
});




