/// <reference path="news-helper.ts" />

module UtilHelper {
    export function log(showMessage: boolean, message: string) {
        var logger = new Helper.SmartConsole(showMessage, message);
        logger.log();
    }

    export function AjaxPostwithCallback(url: string, data: Object, successfn, failfn) {
        var ajaxPost = new Helper.AjaxPost(url , data);
        ajaxPost.successCallback = successfn;
        ajaxPost.failCallback = failfn;
        ajaxPost.run();
    }
}