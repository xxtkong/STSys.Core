$(function () {
    // 选择领域
    $(".allsort").hoverForIE6({current: "allsorthover", delay: 0});

    $(".allsort .item").hoverForIE6({delay: 0});


    // 填写商标信息的选择领域
    $('.smartRegister-page .subitem ul').on('click', 'li', function () {
        var currentTypt = $(this).html();
        var $tradePayBox = $('.tradePayBoxFix');
        $('.allsort .mt').find('a').html(currentTypt);
        $('.allsort').removeClass('allsorthover');
        $('.smartRegister-page').css({
            paddingBottom: '156px'
        });
    });



    // 弹窗里面的选择领域
    $('.changeTradeTypePop .subitem ul').on('click', 'li', function () {
        var currentTypt = $(this).html();
        var $tradePayBox = $('.tradePayBoxFix');
        $('.allsort .mt').find('a').html(currentTypt);
        $('.allsort').removeClass('allsorthover');
    });


    /* 初始化文字、图形、文字及图形的单选按钮 */
    $('#selectBrandType .label').myRadio({
        select: function (that) {
            var data_type = $(that).attr('data-type');
            var brandName = $("[name=brandName]").val();
            if (data_type == 1) {
                $('.row-tuyang').addClass('show1').removeClass('show2 show3 show-create1');
                $('.row-name').removeClass('hide');
                $('.row-tip').removeClass('show');
                $('#create-tuyang .label').eq(0).click();
            } else if (data_type == 2) {
                $('.row-tuyang').addClass('show2').removeClass('show1 show3 show-create1');
                $('.row-name').addClass('hide');
                $('.row-tip').removeClass('show');
            } else {
                $('.row-tuyang').addClass('show3').removeClass('show1 show2 show-create1');
                $('.row-name').removeClass('hide');
                $('.row-tip').addClass('show');
            }
        }
    });
    /* 初始化手动上传、自动生成的单选按钮 */
    $('#create-tuyang .label').myRadio({
        select: function (that) {
            var data_type = $(that).attr('data-type');
            if (data_type == 0) {
                $('.row-tuyang').removeClass('show-create1');
            } else {
                $('.row-tuyang').addClass('show-create1');
            }
        }
    });

    // 点击添加
    $('.btn-add').on('click', function () {
        $(this).parent('.add-category').toggleClass('open');
    });

    $('.c-row-content .btn-choice').on('click', function () {
        var index = $(this).index();
        $(this).addClass('active').siblings().removeClass('active');
        var curType = $(this).data('type');
        if (curType == '1') {
            // 自主选择
            $(this).parents('.categoryInfo-wrap').find('.row-industry1').hide();
            $('.changeTradeTypePop .has_selecter_category').hide();
        } else {
            // 智能推荐
            $(this).parents('.categoryInfo-wrap').find('.row-industry1').show();
            $('.changeTradeTypePop .has_selecter_category').show();
        }
        $('.brandInfo-wrap .choiceTab').eq(index).addClass('selected').siblings().removeClass('selected');
    });

    $('#section-selfchoice .group li').on('click', function () {
        $(this).toggleClass('open');
    });
    $('#section-selfchoice .group li .title-second').on('click', function (e) {
        var e = e || window.event;
        e.stopPropagation();
        console.log(this);
        $(this).toggleClass('open');

    });
    $('#section-selfchoice .group li .title-second .second-sm').on('click', function (e) {
        var e = e || window.event;
        e.stopPropagation();

    });
    // 点击查看上传商标图样注意事项
    $('.zhuyiBtn').on('click', function () {
        $('.pop_div,.zhuyiBox').show();
    });
    // 点击审查费说明弹窗
    $('.danger_info_btn').on('click', function () {
        $('.pop_div,.dangerInfoBox').show();
    });
    // 显示选择商标类型弹窗
    $('.chooseTradeTypeBtn').on('click', function () {
        $('.pop_div,.TradeTypePop').show();
    });
    // 显示如何选择弹窗
    $('.howToChangeBtn').on('click', function () {
        $('.pop_div,.howToChangePop').show();
    });
    // 确认提交页面修改商标信息
    $('.changeTradeInfoBtn').on('click', function () {
        $('.pop_div,.changeTradeInfoPop').show();
    });
    // 修改委托材料
    $('.changeEntrustBtn').on('click', function () {
        $('.entrust_list_wrap').hide();
        $('.change_entrust_wrap').show();
    });
    // 修改委托材料里的取消
    $('.change_entrust_wrap .cancle').on('click', function () {
        $('.entrust_list_wrap').show();
        $('.change_entrust_wrap').hide();
    });
    // 修改商标类别
    $('.changeTradeTypeBtn').on('click', function () {
        $('.pop_div,.changeTradeTypePop').show();
        $('body').css({
            overflow: 'hidden'
        });
    });
    // 修改订单联系人信息
    $('.changeOrderInfoBtn').on('click', function () {
        $('.pop_div,.changeOrderInfoPop').show();
        $('body').css({
            overflow: 'hidden'
        });
    });
    // 修改企业申请人信息
    $('.changeApplyCompanyBtn').on('click', function () {
        $('.pop_div,.changeApplyCompanyPop').show();
        $('body').css({
            overflow: 'hidden'
        });
    });

    // 修改个人申请人信息
    $('.changeApplyPersonBtn').on('click', function () {
        $('.pop_div,.changeApplyPersonPop').show();
        $('body').css({
            overflow: 'hidden'
        });
    });
    // 顾问端商标说明添加与修改
    $('.changeTradeShuomingBtn').on('click', function () {
        $('.tradeShuomingContent').show();

    })
    $('.tradeShuomingContent .cancel').on('click', function () {
        $('.tradeShuomingContent').hide();

    });

    // 怎么填商标说明？
    $('.tradeMarkBtn').on('click', function () {
        $('.pop_div,.trade_mark_Pop').show();

    })
    $('.pop_content .close').on('click', function () {
        $('body').css({
            overflow: 'auto'
        });
    });
    var targetLocation = $('.kindNums .nums').scrollTop() + $(document).scrollTop();
    console.log(targetLocation);

    $('.stateBtn').on('click', function () {
        // var idx = $(this).parents('.layui-timeline').index();
        // console.log(idx);
        // var dongtainums = $(this).siblings('.nums').html();
        // var kindNumsLocation = $('.kindNums .nums').offset().top;


        // console.log($('.kindNums .nums').scrollTop());
        var kindNumsLocation = 1500;
        // console.log(kindNumsLocation);
        $('.service_tab .serv_title li').removeClass('checked').eq(0).addClass('checked');
        $('.serv_tabcon .serv_item').removeClass('selected').eq(0).addClass('selected');

        // setTimeout(function () {
        document.documentElement.scrollTop = document.body.scrollTop = kindNumsLocation;
        // }, 0)
    });
});

$(document).ready(function () {
    //资料审查费提示
    $("#icon-img1").on({
        'mouseenter': function () {
            layer.tips('为保障您的合法权益，首途知识产权顾问将会对您提交的资料是否合规进行必要的审查，保障成功提交。', '.icon-img1', {
                tips: [1, '#f08b2f'],
                time: 0
            });
        },
        'mouseleave': function () {
            layer.closeAll();
        }
    });
    //发票税费提示
    $("#icon-img2").on({
        'mouseenter': function () {
            layer.tips('为保障您的合法权益，首途所有服务都将为您开具发票，若有疑问请咨询在线客服。', '.icon-img2', {
                tips: [1, '#f08b2f'],
                time: 0
            });
        },
        'mouseleave': function () {
            layer.closeAll();
        }
    });

    $('.submitOrderBtn').on('click', submitOrderPop);
});

function isEmptyObject(e) {
    var t;
    for (t in e)
        return !1;
    return !0
}

function addFixed(obj) {
    $(obj).addClass('fixed');
}

function cancelFixed(obj) {
    $(obj).removeClass('fixed');
}


function submitOrderPop() {
    $('.pop_div,.submitOrderPop').show();
}
