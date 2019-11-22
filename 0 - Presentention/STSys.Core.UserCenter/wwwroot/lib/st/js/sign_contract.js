$(function () {
    // tab切换
    $('.service_tab .serv_title ul').on('click', 'li', function () {
        $(this).addClass('checked').siblings().removeClass('checked');
        var index = $(this).index();
        $('.serv_tabcon .serv_item').eq(index).addClass('selected').siblings().removeClass('selected');
    });
    // 点击添加新进程(首次)
    $('.add_newJinDu1').on('click', function () {
        $(this).parent().parent().siblings('.uploadWrap').show();
        // $('.yanshouBtn').show();
        $('.txt_wrap').hide();
    });
    // 无数据点击取消
    $('.noDataCancelBtn').on('click', function () {
        $(this).parents('.uploadWrap').hide();
        $('.txt_wrap').show();
    });
    // 有数据添加新进程
    $('.add_newJinDu2').on('click', function () {
        $(this).parent().find('.uploadWrap').slideDown();
    });
    // 有数据中的取消
    $('.hasDataCancelBtn').on('click', function () {
        $(this).parents('.uploadWrap').slideUp();
    });
    // 服务顾问点击服务完成,显示提交交付成果
    $('.guwen_yanshouBtn').on('click', function () {
        $(this).parent().find('.uploadWrap').slideDown();
    });
    // 交付结果的提交
    $('.deliverySubmitlBtn').on('click', function () {
        $(this).parents('.uploadWrap').slideUp();
        $(this).parents('.yanshou_wrap').find('.yanshouBtn').hide();
    });
    // 有数据的提交
    $('.hasDatasubmitlBtn').on('click', function () {
        $(this).parents('.uploadWrap').slideUp();
    });
    // // 点击补充合同
    // $('.buchongContactBtn').on('click', function () {
    //     $('.pop_div').show();
    //     $('.buchong_contact_con').show();
    // });
    // // 点击修改价格
    // $('.modifyPriceBtn').on('click', function () {
    //     // 每次打开，清空input的内容
    //     $('.modify_price_pop .order_template .input_box').val('');
    //     $('.pop_div').show();
    //     $('.modify_price_pop').show();
    // });
    // 点击取消
    $('.cancel').on('click', hidePop);
    // 服务顾问合同工期切换时间
    $('.gongqi_content .tab_title li').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var index = $(this).index();
        $('.gongqi_content .tab_con_wrap .tab_con').eq(index).addClass('selected').siblings().removeClass('selected');
    });

    // 企业主点击签订合同
    $('.SignContractBtn').on('click', function () {
        $('.pop_div,.contract_pop').show();
    });
    // 企业主签订合同----点击确定按钮
    // $('.qyzSignContractConfirm').on('click', function () {
    //     $('.pop_div,.contract_pop').hide();
    // });

    // 服务顾问签订合同----点击确定按钮
    $('.GWSignContractConfirm').on('click', function () {
        $('.qiyezhuContract').append('<div class="contract_seal_img_wrap qyzContractSealImg">' +
            '<img src="./images/contract_seal_img.png" alt="">' +
            '</div>');
    });
    // 企业主点击验收弹框
    //$('.qiyezhu_yanshouBtn').on('click', function () {
    //    $('.pop_div').show();
    //    $('.qiyezhu_acceptance_pop').show();
    //});
    // 10.23新增
    // 服务顾问查看分期商品
    $('.stage_t ul li').on('click', function () {
        var cuText = $(this).data('text');
        if (cuText == '查看当前期') {
            $('.previous_stage').hide();
            $('.normal_pro_wrap').show();
            return;
        } else {
            $('.previous_stage').show();
            $('.normal_pro_wrap').hide();
            return;
        }
    });

    // 查看往期详情
    $('.show_statedetail').on('click', function () {
        $(this).parents('.previous_stage').find('.previous_jindu').show();
    });
    //订单详情各产品模块切换
    $('.orderTitleBtn').on('click', function () {
        // $('.order_detail_wrap .order_detail_panel').removeClass('open');
        $(this).parents('.order_detail_panel').toggleClass('open').siblings('.order_detail_panel').removeClass('open');
    });

    //$('.list_item_box').mouseenter(function () {
    //    $(this).find('.top_fixed_mask').show();
    //}).mouseleave(function () {
    //    $(this).find('.top_fixed_mask').hide();

    //});

});


