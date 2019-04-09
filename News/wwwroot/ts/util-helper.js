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
    function test() {
        var x = new D3treeHelper.Test();
        x.testLog();
    }
    UtilHelper.test = test;
    function treeMaker(treeData, tree, diagonal, svg, i, duration, root, frameElement, width, height) {
        var d3tree = new D3treeHelper.D3Tree(treeData, tree, diagonal, svg, i, duration, root, frameElement, width, height);
        d3tree.generateTreeDiagram(treeData);
    }
    UtilHelper.treeMaker = treeMaker;
})(UtilHelper || (UtilHelper = {}));
