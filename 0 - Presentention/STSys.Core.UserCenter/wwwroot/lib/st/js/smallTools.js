$(function () {
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
        console.log(curType);
        if (curType == '1') {

            $(this).parents('.categoryInfo-wrap').find('.row-industry1').hide();
        } else {
            $(this).parents('.categoryInfo-wrap').find('.row-industry1').show();
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
    // 点击审查费说明
    $('.danger_info_btn').on('click', function () {
        $('.pop_div,.dangerInfoBox').show();
    });

});

$(document).ready(function () {
    //资料审查费提示
    $("#icon-img1").on({
        'mouseenter': function () {
            layer.tips('为保障您的合法权益，首途知识产权顾问将会对您提交的资料是否合规进行必要的审查，保障成功提交。', '.icon-img', {
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
            layer.tips('为保障您的合法权益，首途所有服务都将为您开具发票，若有疑问请咨询在线客服。', '.icon-img1', {
                tips: [1, '#f08b2f'],
                time: 0
            });
        },
        'mouseleave': function () {
            layer.closeAll();
        }
    });
});

function isEmptyObject(e) {
    var t;
    for (t in e)
        return !1;
    return !0
}