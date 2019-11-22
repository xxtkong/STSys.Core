// 关于我们
$(function(){
    // fullpage 初始化
    $('#fullpage').fullpage({
        anchors: ['', 'firstPage', 'secondPage', 'thirdPage', 'forthPage'],
        menu: '#myMenu',
        afterLoad: function (anchorLink, index) {
            var logoSrcHei = '/Content/st/images/aboutus/logo_hei.png';
            var logoSrcBai = '/Content/st/images/aboutus/logo_bai.png';
            var color4747 = '#474747';
            var colorff79 = '#ff7900';
            var colorfff = '#fff';
            // 把所有的移除
            $('.section').removeClass('current');
            // 延时100毫秒执行，给当前的添加
            setTimeout(function () {
                $('.section').eq(index - 1).addClass('current');
            }, 100);
            if (index == 1) {
                changeNav(logoSrcBai, colorfff, colorff79);
            }
            if (index == 2) {
                changeNav(logoSrcBai, colorfff, colorff79);
                $('.section2').find('h5').addClass('animated bounce');
                $('.section2').find('.desc').addClass('animated bounceInLeft');
                $('.section2 .content').find('.p1').addClass('animated bounceInRight');
                $('.section2 .content').find('.p2').addClass('animated bounceInLeft');
                $('.section2 .content').find('.p3').addClass('animated bounceInRight');
            }

            if (index == 3) {
                changeNav(logoSrcHei, color4747, colorff79);
                $('.section3 .content').find('h5').addClass('animated bounceInUp');
                $('.section3 .content').find('.flow').addClass('animated bounceInDown');
            }
            if (index == 4) {
                changeNav(logoSrcBai, colorfff, colorff79);
                $('.s4_content .title').addClass('animated bounceInLeft');
                $('.s4_content .title').find('.line').addClass('animated bounceInLeft');
                $('.s4_content .cities').addClass('animated bounceInRight');
            }

            if (index == 5) {
                changeNav(logoSrcHei, color4747, colorff79);
                $('.section5 .content').find('h5').addClass('animated bounceInDown');
                $('.section5 .content').find('.list1').addClass('animated slideInLeft');
                $('.section5 .content').find('.list2').addClass('animated slideInLeft');
                $('.section5 .content').find('.list3').addClass('animated slideInRight');
                $('.section5 .content').find('.list4').addClass('animated slideInRight');
            }
        },
        onLeave: function (index, direction) {
            if (index == 2) {
                $('.section2').find('h5').removeClass('animated bounce');
                $('.section2').find('.desc').removeClass('animated bounceInLeft');
                $('.section2 .content').find('.p1').removeClass('animated bounceInRight');
                $('.section2 .content').find('.p2').removeClass('animated bounceInLeft');
                $('.section2 .content').find('.p3').removeClass('animated bounceInRight');
            }

            if (index == 3) {
                $('.section3 .content').find('h5').removeClass('animated bounceInUp');
                $('.section3 .content').find('.flow').removeClass('animated bounceInDown');
            }
            if (index == 4) {
                $('.s4_content .title').removeClass('animated bounceInLeft');
                $('.s4_content .title').find('.line').removeClass('animated bounceInLeft');
                $('.s4_content .cities').removeClass('animated bounceInRight');

            }
            if (index == 5) {
                $('.section5 .content').find('h5').removeClass('animated bounceInDown');
                $('.section5 .content').find('.list1').removeClass('animated slideInLeft');
                $('.section5 .content').find('.list2').removeClass('animated slideInLeft');
                $('.section5 .content').find('.list3').removeClass('animated slideInRight');
                $('.section5 .content').find('.list4').removeClass('animated slideInRight');
            }

        }
    });
    // 城市名称移入
    $('.cities li').hover(function () {
        $(this).addClass('active').siblings().removeClass('active');
        var curIndex = $(this).index();
        console.log(curIndex);
        $('.map_point').eq(curIndex).addClass('open').siblings().removeClass('open');
    }, function () {
        var curIndex = $(this).index();
        console.log(curIndex);
        $('.cities').find('li').eq(curIndex).addClass('active');
        $('.map_point').eq(curIndex).addClass('open').siblings().removeClass('open');
    });
    // 城市名称点击
    $('.cities').on('click', 'li', function () {
        $(this).addClass('active').siblings().removeClass('active');
        var curIndex = $(this).index();
        setMap(curIndex);
        $('.distribution_pop').fadeIn();
    });
    // 地图移入某一城市
    // $('.map_point').mouseenter(function () {
    //     alert('1');
    //     // $(this).addClass('open').siblings().removeClass('open');
    //     var curIndex = $(this).index();
    //     $('.cities li').eq(curIndex).addClass('active').siblings().removeClass('active');
    // }).mouseleave(function(){
    //     var curIndex = $(this).index();
    //     alert('2');
    //     $('.cities').find('li').eq(curIndex).addClass('active').siblings().removeClass('active');
    // })
    $('.map_point').on('click',function(){
        // $(this).addClass('active').siblings().removeClass('active');
        var curIndex = $(this).index();
        setMap(curIndex);
        $('.distribution_pop').fadeIn();
    });
    $('.closeDistribution').on('click', function () {
        $('.distribution_pop').fadeOut();
    });
});
// 修改logo颜色,logoImg logo图片  navColor1 nav开始颜色  navColor2  鼠标移动到nav上的颜色
function changeNav(logoImg, navColor1, navColor2) {
    var targetLogo = $('.menu_box').find('img');
    targetLogo.attr('src', logoImg);
    $('.menu_box').find('a').css({
        color: navColor1
    });
    $('.menu_box .nav').find('a').mouseenter(function () {
        $(this).css({
            color: navColor2
        });
    }).mouseleave(function () {
        $(this).css({
            color: navColor1
        });
    });
}

function setMap(curIndex) {
    // 贵州
    if (curIndex == '0') {
        $('.cityName').html('贵州');
        $('.cityAddress').html('贵州.贵阳.南明区花果园财富广场1号27层');
        $('.iframeUrl').attr('src', 'http://surl.amap.com/ZiMA_0F97TZ9');
        return;
    }
    //北京
    if (curIndex == '1') {
        $('.cityName').html('北京');
        $('.cityAddress').html('北京市西城区莲花池东路汇融大厦B座1805');
        $('.iframeUrl').attr('src', 'http://surl.amap.com/2Cjqf_0C17UxE');
        return;
    }
    //辽宁
    if (curIndex == '2') {
        $('.cityName').html('辽宁');
        $('.cityAddress').html('辽宁省沈阳市沈河区青年大街185-2号30层A单元');
        $('.iframeUrl').attr('src', 'http://surl.amap.com/6c8t1_0847UhE');
        return;
    }
    //江西
    if (curIndex == '3') {
        $('.cityName').html('江西');
        $('.cityAddress').html('江西省南昌市南昌高新技术产业开发区紫阳大道2888号紫鑫商务广场-1#704室');
        $('.iframeUrl').attr('src', 'http://surl.amap.com/4RZUf_0377TQN');
        return;
    }
}