/// <reference path="news-helper.ts" />
/// <reference path="d3tree-helper.ts" />
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
    function treeMaker(treeData, tree, diagonal, svg, i, duration, root, frameElement, width, height) {
        return new D3treeHelper.D3Tree();
        //return new D3treeHelper.D3Tree(treeData, tree, diagonal, svg, i, duration, root, frameElement, width, height); 
    }
    UtilHelper.treeMaker = treeMaker;
})(UtilHelper || (UtilHelper = {}));
