/// <reference path="typings/jquery.d.ts" />
var Helper;
(function (Helper) {
    var SmartConsole = /** @class */ (function () {
        function SmartConsole(_showMessage, _message) {
            var _this = this;
            this.showMessage = false;
            this.message = "";
            this.log = function () {
                if (_this.showMessage) {
                    console.log(_this.message);
                }
            };
            this.message = _message;
            this.showMessage = _showMessage;
        }
        return SmartConsole;
    }());
    Helper.SmartConsole = SmartConsole;
    var AjaxPost = /** @class */ (function () {
        function AjaxPost(url, data) {
            this.url = "";
            this.data = {};
            this.url = url;
            this.data = data;
        }
        AjaxPost.prototype.run = function () {
            var self = this;
            $.ajax({
                type: "POST",
                url: self.url,
                data: self.data
            })
                .done(function (data, statusText, xhdr) { return self.onSuccess(data, statusText, xhdr); })
                .fail(function (err, errorText, xhdr) { return self.OnFailed(err, errorText, xhdr); });
        };
        AjaxPost.prototype.onSuccess = function (data, statusText, xhdr) {
            if (xhdr.status === 200 || xhdr.status === 201) {
                if (this.successCallback && typeof (this.successCallback) === 'function') {
                    this.successCallback(data, statusText, xhdr);
                }
            }
        };
        AjaxPost.prototype.OnFailed = function (err, errorText, xhdr) {
            if (xhdr.status >= 400) {
                if (this.failCallback && typeof (this.failCallback) === 'function') {
                    this.failCallback(err, errorText, xhdr);
                }
            }
        };
        return AjaxPost;
    }());
    Helper.AjaxPost = AjaxPost;
})(Helper || (Helper = {}));
