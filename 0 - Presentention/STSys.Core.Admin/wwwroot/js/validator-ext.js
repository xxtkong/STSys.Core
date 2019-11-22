
jQuery(document).ready(function () {

    jQuery.validator.addMethod("telphoneValid", function (value, element) {
        var tel = /^(13|15|18|17|19|16)\d{9}$/;
        return tel.test(value) || this.optional(element);
    }, "请输入正确的手机号码");

    jQuery.validator.addMethod("zipCodeValid", function (value, element) {
        var tel = /^\d{6}$/;
        return tel.test(value) || this.optional(element);
    }, "请输入正确的邮编");

    jQuery.validator.addMethod("phoneValid", function (value, element) {
        var tel = /^(\d{8}|\d{6})$/;
        return tel.test(value) || this.optional(element);
    }, "请输入正确的电话号码");

    jQuery.validator.addMethod("CardIDValid", function (value, element) {
        var cardID = /^(\d{6})(18|19|20)?(\d{2})([01]\d)([0123]\d{2})((\d{2})(\d|X|x))?$/;

        return cardID.test(value) || this.optional(element);
    }, "请输入正确的身份证号码");

    jQuery.validator.addMethod("ChinessValid", function (value, element) {
        var chiness = /^[\u4E00-\u9FA5\uF900-\uFA2D]+$/;
        return chiness.test(value) || this.optional(element);
    }, "请输入中文");

    jQuery.validator.addMethod("DataTimeValid", function (value, element) {
        var dTime = /^(\d{4}-\d{1,2}-\d{1,2})( \d{1,2}:\d{2}:\d{2})?$/;
        return dTime.test(value) || this.optional(element);
    }, "请输入正确的时间格式");

    jQuery.validator.addMethod("ChinessAndNumberValid", function (value, element) {
        var chinessAndNumber = /^[A-Za-z0-9]+$/;
        return chinessAndNumber.test(value) || this.optional(element);
    }, "请输入字母和数字");

    jQuery.validator.addMethod("MoneyValid", function (value, element) {
        var money = /^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
        return money.test(value) || this.optional(element);
    }, "请输入正确的金额");
    jQuery.validator.addMethod("MoneyValid2", function (value, element) {
        var money = /^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
        return money.test(value) || this.optional(element);
    }, "请输入正确的金额");

    jQuery.validator.addMethod("StuNo", function (value, element) {
        var StuNo = /^\d{11}$/;
        return StuNo.test(value) || this.optional(element);
    }, "请输入11位的数字！");


    jQuery.validator.addMethod("LoginPwd", function (value, element) {
        var LoginPwd = /^\d{6}$/;
        return LoginPwd.test(value) || this.optional(element);
    }, "请输入6位数字！");

    jQuery.validator.addMethod("CardNo", function (value, element) {
        var CardNo = /^\d{7,8}$/;
        return CardNo.test(value) || this.optional(element);
    }, "请输入7位或8位数字！");
    jQuery.validator.addMethod("isNumber", function (value, element) {
        var isNumber = /^[0-9]+$/;
        return CardNo.test(value) || this.optional(element);
    }, "请输入整数！");

    jQuery.validator.addMethod("IPAddress", function (value, element) {
        var IP = /^(2[5][0-5]|2[0-4]\d|1\d{2}|\d{1,2})\.(25[0-5]|2[0-4]\d|1\d{2}|\d{1,2})\.(25[0-5]|2[0-4]\d|1\d{2}|\d{1,2})\.(25[0-5]|2[0-4]\d|1\d{2}|\d{1,2})$/;
        return IP.test(value) || this.optional(element);
    }, "请输入正确的IP地址！");


    jQuery.validator.addMethod("IPAddress2", function (value, element) {
        var IP = /^(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.)(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.){2}([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))$/;
        return IP.test(value) || this.optional(element);
    }, "请输入正确的IP地址！");

    //jQuery.validator.addMethod("CardIDValid1", function(value, element) {
    //    var cardID = /^[1-9](\d{14})|(\d{16}([0-9]|X|x))$/;

    //    return cardID.test(value) || this.optional(element);
    //}, "请输入正确的身份证号码");


    jQuery.validator.addMethod("isVerifyCode", function (value, element) {
        var isv = verifyCode.validate(document.getElementById("Verification").value);
        return isv;
    }, "请输入正确的验证码");
});


