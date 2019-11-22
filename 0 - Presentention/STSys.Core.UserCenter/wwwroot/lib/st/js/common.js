//返回顶部
function smoothscroll() {
    $('html,body').animate({ scrollTop: 0 }, 'slow');
}

// 验证码 效果
var wait = 60;

function time(dom) {
    if (wait == 0) {
        dom.removeAttribute("disabled");
        dom.style.color = '#fff';
        dom.style.backgroundColor = '#fd982d';
        dom.value = "获取动态码";
        dom.style.border = ''
        wait = 60;
    } else {
        dom.setAttribute("disabled", true);
        dom.style.color = '#b9b9b9';
        dom.style.backgroundColor = '#fafafa';
        dom.value = "重新发送(" + wait + ")";
        dom.style.border = '1px solid #ddd';
        wait--;
        setTimeout(function () {
            time(dom)
        }, 1000)
    }
}

// 点击关闭,隐藏pop
$('.pop_content .close').on('click', hidePop);


// 点击pop_div  隐藏pop
// $('.pop_div').on('click', hidePop);

function showPop() {
    $('.pop_content').show();
    $('.pop_div').show();
}

function hidePop() {
    $('.pop_content').hide();
    $('.pop_div').hide();
}

// 阻止冒泡
function stopPropagation(e) {
    if (e.stopPropagation) {
        e.stopPropagation();
    } else {
        e.cancelBubble = true;
    }
}

//产生随机数函数
function RandNum(n) {
    var rnd = "";
    for (var i = 0; i < n; i++)
        rnd += Math.floor(Math.random() * 10);
    return rnd;
}

// 使元素滚动到某一处
function scrollTo(ele, speed) {
    if (!speed) speed = 300;
    if (!ele) {
        $("html,body").animate({ scrollTop: 0 }, speed);
    } else {
        if (ele.length > 0) $("html,body").animate({ scrollTop: $(ele).offset().top }, speed);
    }
    return false;
}

// 点击下拉
$('.drop_down_box span').on('click', function (e) {
   
    var e = e || window.event;
    stopPropagation(e);
    $(this).parent().find('ol').slideToggle(200);
});

$('.drop_down_box .drop_down_list').on('click', 'li', function (e) {
   
    var e = e || window.event;
    stopPropagation(e);
    var curHtml = $(this).html();
    var curVal = $(this).data('value');
    $(this).parents('.input_box').find('span').html(curHtml);
    // $(this).parents('.input_box').find('span').data('value', curVal);
    $(this).parents('.input_box').find('span').attr('data-value', curVal);
    $(this).parent('ol').slideUp(200);
});

$(document).on('click', function () {
    $('.drop_down_box .drop_down_list').slideUp(200);
});

//头部登录
function userlogin(usertype) {
    var url = encodeURIComponent(window.location.href);
    if (usertype == "1") {
        window.location = "/login.html?returnurl=" + url;
    } else {
        window.location = "/consultantlogin.html?returnurl=" + url;
    }
}

function userregister() {
    var url = encodeURIComponent(window.location.href);
    window.location = "/register.html?returnurl=" + url;
}


//获取url参数argu_name的值,如果未获取到则返回空
function lnGetLocationParm(argu_name, curr_str) {
    var i = 0;
    var url = curr_str || window.location.search;
    var arguStr = url.split('?')[1];
    var key_val_s = [];
    var len = 0;
    var result = '';
    if (arguStr) {
        key_val_s = arguStr.split('&');
        len = key_val_s.length;
        for (i = 0; i < len; i++) {
            if (argu_name == key_val_s[i].split('=')[0]) {
                result = key_val_s[i].split('=')[1];
                break;
            }
        }
    }
    return result ? result == 'null' ? '' : decodeURIComponent(result) : '';
}
