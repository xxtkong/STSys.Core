$.fn.extend({
    animateCss: function(animationName, callback) {
        var animationEnd = (function(el) {
            var animations = {
                animation: 'animationend',
                OAnimation: 'oAnimationEnd',
                MozAnimation: 'mozAnimationEnd',
                WebkitAnimation: 'webkitAnimationEnd',
            };

            for (var t in animations) {
                if (el.style[t] !== undefined) {
                    return animations[t];
                }
            }
        })(document.createElement('div'));

        this.addClass('animated ' + animationName).one(animationEnd, function() {
            $(this).removeClass('animated ' + animationName);

            if (typeof callback === 'function') callback();
        });

        return this;
    },
});
var finished = true;
var goTop = $("#standard").offset().top;
var bgL = $('#standard .content .bg-l');
var bgR = $('#standard .content .bg-r');
$(window).scroll(function() {
    if (finished && goTop >= $(window).scrollTop() && goTop < ($(window).scrollTop() + $(window).height())) {
        $(bgL).animateCss('fadeInLeft');
        $(bgR).animateCss('fadeInRight');
        finished = false;
    } 
});