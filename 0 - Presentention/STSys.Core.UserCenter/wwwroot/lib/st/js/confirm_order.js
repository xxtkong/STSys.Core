// 确认订单
$(function () {
    // 初始化城市联动插件
    //$("#sjld").sjld("#shenfen", "#chengshi", "#quyu");
    // 点击需要发票
    $('#needBillCheckbox').click(function () {
        $('.bill_con .bill_message').toggleClass('disnone');
    });

    // 点击修改发票
    $('.changeFaPiao').on('click', function () {
        $('.pop_div').show();
        $('.fapiao_message').show(0, function () {
            var invoiceId = $("#hidInvoiceId").val();
            if (invoiceId === null || invoiceId === 0 || invoiceId === "" || invoiceId === undefined) {
                //获取默认的收货地址或者选中的收货地址
                var defaultValue;
                var select = $("#address_ul li.selected");
                if (select.length === 0) {
                    //选择默认地址
                    select = $("#address_ul li:first");
                }
                if (select.length !== 0) {
                    $("#likeman").val(select.find(".addr_name").text());
                    $("#mobile").val(select.attr("mobile"));
                    defaultValue = select.attr("addressName");
                    $("#address").val(select.attr("address"));
                    $("#hidSearchArea").val(defaultValue);
                }
                //加载地区插件
                $("#fpdq").selectAddress({
                    province: "fpdq_province", city: "fpdq_city", town: "fpdq_town", defaultValue: defaultValue, callback: function (area,text,alltext) {
                        $("#hidSearchArea").val(alltext);
                    }
                });
            } else {
                $("#fpdq").selectAddress({
                    province: "fpdq_province", city: "fpdq_city", town: "fpdq_town", defaultValue: $("#hidSearchArea").val(), callback: function (area, text, alltext) {
                        $("#hidSearchArea").val(alltext);
                    }
                });
            }
            
        });
       

        $('.pop_content .title').html('发票信息');
    });
    // 点击取消
    $('.cancel').on('click', hidePop);

    // 点击选中优惠券
    $('.coupleItem').on('click', function () {
        $(this).toggleClass('checked').siblings().removeClass('checked');
    });
    // 鼠标移入地址
    $('.addressList ul').on('mouseenter', 'li', function () {
        $(this).addClass('li_hover');

    }).on('mouseleave', 'li', function () {
        $(this).removeClass('li_hover');

    });
    // 鼠标点击选择服务地址
    $('.addressList ul').on('click', 'li', function () {
        $(this).addClass('selected').siblings().removeClass('selected');
    });
    // 点击新增地址
    //$('.addNewaddress').on('click', function () {
    //    $('.pop_div').show();
    //    $('.new_address').show();
    //    $('.pop_content .title').html('新增服务地址');
    //});
    // 点击更多地址
    //$('.switch_on ').on('click', function () {
    //    var curHtml = $(this).find('span').html();
    //    if (curHtml == '更多地址') {
    //        $('.address_list_more').show();
    //        $(this).find('span').html('收起地址');
    //    } else if (curHtml == '收起地址') {
    //        $('.address_list_more').hide();
    //        $(this).find('span').html('更多地址');
    //    }

    //});
    // 点击编辑地址
    //$('.editAddress').on('click', function () {
    //    $('.pop_div').show();
    //    $('.new_address').show();
    //    $('.pop_content .title').html('编辑服务地址');
    //})


    // 选择开票主体
    //$('.fapiaoType .list').on('click', function () {
    //    $(this).addClass('active').siblings().removeClass('active');
    //    var curTxt = $(this).data('text');
    //    console.log(curTxt);
    //    if (curTxt == '个人') {
    //        $('.fapiaoCon .itemKind').hide();
    //        $('.fapiaoCon .bill_tips').show();
    //        $('.fapiao_message').css({
    //            height: '306px'
    //        });
    //        return;
    //    } else {
    //        $('.fapiaoCon .itemKind').show();
    //        $('.fapiaoCon .bill_tips').hide();
    //        $('.fapiao_message').css({
    //            height: '460px'
    //        });
    //        return;

    //    }
    //});

    $('.fapiaoType .list').on('click', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var curTxt = $(this).data('text');
        console.log(curTxt);
        if (curTxt == '个人') {
            $('.fapiaoCon .itemKind').hide();
            $('.fapiaoCon .bill_tips').show();
            $('.fapiao_message').css({
                height: '484px'
            });
            return;
        } else {
            // 企业
            $('.fapiaoCon .itemKind').show();
            $('.fapiaoCon .bill_tips').hide();
            $('.fapiao_message').css({
                height: '594px'
            });
            return;

        }
    });
});
