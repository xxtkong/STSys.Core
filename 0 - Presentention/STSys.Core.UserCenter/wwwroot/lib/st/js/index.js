/**
 * Created by LeeNing on 2018/3/19.
 */

$(function () {
    var numScroll = $('.numberScroll');
    numScroll.numScroll();
    //推荐顾问
    $('.tuijie_wrap .tuijie_con li .guwen_jieshao').mouseenter(function () {
        $(this).css({
            backgroundColor: '#ff7900',
            color: '#fff'
        });
        $(this).find('.p1').css({
            backgroundColor: '',
            color: '#fff'
        });
        $(this).find('.address i').css({
            color: '#fff'
        });
        $(this).find('.chengji').css({
            backgroundColor: '',
            color: '#fff'
        });
        $(this).find('.chengji >div').css({
            borderRight: '1px solid #fff',
            borderTop: '1px dashed #fff'

        });
        $(this).find('.chengji >div:last-child').css({
            borderRight: '0'

        });
        $(this).find('.susse').css({
            color: '#fff'
        });
        $(this).find('.susse_num').css({
            color: '#fff'
        });

        $(this).find('.haopin').css({
            color: '#fff'
        });
        $(this).find('.haopin_num').css({
            color: '#fff'
        });
        $(this).find('.phone_ask').css({
            backgroundColor: '#fff',
            color: '#ff7900'
        });
    });
    $('.tuijie_wrap .tuijie_con li .guwen_jieshao').mouseleave(function () {
        $(this).css({
            backgroundColor: '#fff',
            color: ''
        });
        $(this).find('.p1').css({
            backgroundColor: '',
            color: '#333'
        });
        $(this).find('.address i').css({
            color: '#ff7900'
        });
        $(this).find('.chengji').css({
            backgroundColor: '#fff',
            color: '#ff7900'
        });
        $(this).find('.chengji >div').css({
            borderRight: '1px solid #ff7900',
            borderTop: '1px dashed #ff7900'

        });
        $(this).find('.chengji >div:last-child').css({
            borderRight: '0'

        });
        $(this).find('.susse').css({
            color: '#ff7900'
        });
        $(this).find('.susse_num').css({
            color: '#ff7900'
        });

        $(this).find('.haopin').css({
            color: '#ff7900'
        });
        $(this).find('.haopin_num').css({
            color: '#ff7900'
        });
        $(this).find('.phone_ask').css({
            backgroundColor: '#ff7900',
            color: '#fff'
        });
    });
    // 产品推荐
    $('.recommend_prodwrap .recommend_prod ul li').mouseenter(function () {
        $(this).find('.pro_des').css({
            color: '#ff7900'
        });
        $(this).find('.pro_des p').css({
            color: '#ff7900'
        });

        $(this).find('.detail').css({
            backgroundColor: '#ff7900',

        });
    });
    $('.recommend_prodwrap .recommend_prod ul li').mouseleave(function () {
        $(this).find('.pro_des').css({
            color: '#333'
        });
        $(this).find('.pro_des p').css({
            color: '#999'
        });
        $(this).find('.pro_des .p1').css({
            color: '#333'
        });
        $(this).find('.pro_des .money').css({
            color: '#fd982d'
        });
        $(this).find('.detail').css({
            backgroundColor: '#fd982d'
        });
    });
    // 小工具切换
    $('.toolsLink a').on('click', function () {
        $(this).addClass('checked').siblings().removeClass('checked');
        var index = $(this).index();
        $('.serachBox .tab_content').eq(index).addClass('selected').siblings().removeClass('selected');
    });
    // 企业服务切换
    $('.compamyServiceType ul').on('click', 'li', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var index = $(this).index();
        $('.serviceContent .serviceProdItem').eq(index).addClass('selected').siblings().removeClass('selected')
    });
    // 最新活动效果
    $('.latest_actives ul li').mouseenter(function () {
        $(this).find('.des').css({
            backgroundColor: '#ff7900',
            color: '#fff'
        });
        $(this).find('.des i').css({
            backgroundColor: '#ff7900',
            color: '#fff'
        });
        $(this).find('.des .money').css({
            backgroundColor: '#ff7900',
            color: '#fff'
        });
    }).mouseleave(function () {
        $(this).find('.des').css({
            backgroundColor: '#f4f4f4',
            color: '#333'
        });
        $(this).find('.des i').css({
            backgroundColor: '#f4f4f4',
            color: '#999'
        });
        $(this).find('.des .money').css({
            backgroundColor: '#f4f4f4',
            color: '#ff7900'
        });
    });

});


var area = document.getElementById('scrollBox');
var iliHeight = 26;//单行滚动的高度
var speed = 50;//滚动的速度
var time;
var delay = 2000;
area.scrollTop = 0;
area.innerHTML += area.innerHTML;//克隆一份一样的内容
function startScroll() {
    time = setInterval("scrollUp()", speed);
    area.scrollTop++;
}

function scrollUp() {
    if (area.scrollTop % iliHeight == 0) {
        clearInterval(time);
        setTimeout(startScroll, delay);
    } else {
        area.scrollTop++;
        if (area.scrollTop >= area.scrollHeight / 2) {
            area.scrollTop = 0;
        }
    }
}

setTimeout(startScroll, delay);

$('#scrollBox').on('mouseenter', 'li', function () {
    $(this).find('a').addClass('hover_class').siblings().removeClass('hover_class');
}).on('mouseleave', 'li', function () {
    $(this).find('a').removeClass('hover_class');
});

// 当页面滚动的时候，
$(window).scroll(function () {
    var windowScrollTop = $(window).scrollTop();
    if (windowScrollTop > 630) {
        $('.leftbar_fix').show();

    } else {
        $('.leftbar_fix').hide();
    }

    var listHeight = [];
    var height = $('.hot_demand_wrap:eq(0)').offset().top;
    // 页面滚动距离
    var scrollY = document.documentElement.scrollTop || document.body.scrollTop;
    listHeight.push(height);
    // 所有模块
    var hot_demand_wraps = $('.hot_demand_wrap');
    for (var i = 0; i < hot_demand_wraps.length; i++) {
        var item = hot_demand_wraps[i];
        height += item.clientHeight;
        listHeight.push(height);
    }
    for (var i = 0; i < listHeight.length; i++) {
        // 当前索引值对应li的高度
        var curIndexHeight = listHeight[i];
        // 下一个索引值对应li的高度
        var nextIndexHeight = listHeight[i + 1];
        // 如果不是最后一个li 或者 在两者的区间
        if (!nextIndexHeight || scrollY >= curIndexHeight && scrollY < nextIndexHeight) {
            $('.leftbar_fix li').eq(i).addClass('active').siblings().removeClass('active');
        }
    }
});










