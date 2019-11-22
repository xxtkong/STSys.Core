
/* jQuery下拉框插件 */
;(function($){
    var defaults = '';
    $.fn.mySelect = function(options){
        var options = $.extend(true, defaults, options);
        return this.each(function(){
            var that = this;
            var $this = $(this);
            $this.on('click',function(e){
                $('.mySelect').removeClass('open');
                var isOpen = $this.hasClass('open');
                $this[isOpen?'removeClass':'addClass']('open');
                e.stopPropagation();
            });
            $($this,'body').on('click', '.menu',function(event){
                var $menu = $(this);
                var text = $menu.text();
                $menu.addClass('checked').siblings().removeClass('checked');
                options.select(that,this);
                $this.find('.select-text .text').text(text);
                $this.removeClass('open');
                event.stopPropagation();
            });
        });// end each
    };// end $.fn.mySelect
})(jQuery);
$(function(){
    $('body').on('click', function(e){
        var isOpen = $('.mySelect').not(".contact-select-input").hasClass('open');
        if(isOpen){
            $('.mySelect').removeClass('open');
            e.stopPropagation();
        }
    });
});
/** end jQuery下拉框插件 **/

/* jQuery单选框插件 */
;(function($){
    var defaults = '';
    $.fn.myRadio = function(options){
        var options = $.extend(true, defaults, options);
        return this.each(function(){
            var that = this;
            var $this = $(this);
            $this.on('click', function(event){
                $this.addClass('checked').siblings('.label').removeClass('checked');
                options.select($(this));
                event.stopPropagation();
            });
        });// end each
    };// end $.fn.myRadio
})(jQuery);

/* jQuery复选框插件 */
;(function($){
    var defaults = '';
    $.fn.myCheckbox = function(options){
        var options = $.extend(true, defaults, options);
        var that = this;
        var $this = $(this);
        $this.on('click', function(event){
            var isChecked = $(this).hasClass('checked');
            $(this)[isChecked?'removeClass':'addClass']('checked');
            options.select($(this));
            event.stopPropagation();
        });

    };// end $.fn.myCheckbox
})(jQuery);

$(function(){
    /*mytab切换*/
    $(function(){
        $('.tabsPanel .tabs-header .list').on('click',function(){
            var index = $(this).index();
            $(this).addClass('selected').siblings().removeClass('selected');
            $(this).closest('.tabsPanel').children('.tabs-bodyer').children('.bodyer-panel').eq(index).addClass('selected').siblings().removeClass('selected');
        });
    });

    /* 下拉菜单 */
    $('.qds-dropdown').hover(function(){
        $(this).addClass('open');
    },function(){
        $(this).removeClass('open');
    });
});