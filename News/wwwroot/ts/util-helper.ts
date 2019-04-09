/// <reference path="news-helper.ts" />
/// <reference path="d3tree-helper.ts" />

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

    export function test() {
        var x = new D3treeHelper.Test();
            x.testLog();
    }

    export function treeMaker(treeData: Array<Object>,
        tree: any,
        diagonal: any,
        svg: any,
        i: number,
        duration: number,
        root: any,
        frameElement: Object,
        width: number,
        height: number) {

        let d3tree = new D3treeHelper.D3Tree(treeData, tree, diagonal, svg, i, duration, root, frameElement, width, height);        
        d3tree.generateTreeDiagram(treeData);
    }
}