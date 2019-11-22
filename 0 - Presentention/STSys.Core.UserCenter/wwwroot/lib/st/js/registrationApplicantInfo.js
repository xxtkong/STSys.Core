
$(function(){
    $('.applyType li').on('click',function(){
        $(this).addClass('checked').siblings().removeClass('checked');
        var index = $(this).index();
        $('.info_item .content .tab_content').eq(index).addClass('selected').siblings().removeClass('selected');
        var curType = $(this).data('type');

        if(curType == 1) {
            // 企业
            $('.info_item .itemIdentity').hide();
            $('.businessLicense .businessLicenseBox img').attr('src','/Content/st/images/shangbiao3a.png');
        }else {
            // 个体户
            $('.info_item .itemIdentity').show();
            $('.businessLicense .businessLicenseBox img').attr('src','/Content/st/images/shangbiao3.png');

        }
    });
    // 点击上传文件注意事项
    $('.uploadfileBtn').on('click',function(){
        $('.pop_div,.uploadfileBox').show();
    });
});




