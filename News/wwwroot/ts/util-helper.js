/// <reference path="news-helper.ts" />
var UtilHelper;
(function (UtilHelper) {
    function log(showMessage, message) {
        var logger = new Helper.SmartConsole(showMessage, message);
        logger.log();
    }
    UtilHelper.log = log;
    function AjaxPostwithCallback(url, data, successfn, failfn) {
        var ajaxPost = new Helper.AjaxPost(url, data);
        ajaxPost.successCallback = successfn;
        ajaxPost.failCallback = failfn;
        ajaxPost.run();
    }
    UtilHelper.AjaxPostwithCallback = AjaxPostwithCallback;
})(UtilHelper || (UtilHelper = {}));
