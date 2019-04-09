/// <reference path="typings/jquery.d.ts" />

module Helper {

    declare var $;

    export class SmartConsole {
        showMessage = false;
        message = ""

        constructor(_showMessage: boolean, _message: string) {
            this.message = _message;
            this.showMessage = _showMessage;
        }

        log = () : void => {          
            if (this.showMessage) { console.log(this.message); }
        }
    }

    export class AjaxPost {
        url = "";
        data = {};
        successCallback: (data, statusText, xhdr) => void;
        failCallback: (errData, statusText, errorText) => void;

        constructor(url: string,  data: Object) {
            this.url = url;            
            this.data = data;
        }

        run() {
            var self = this;

            $.ajax({
                type: "POST",
                url: self.url,
                data: self.data
            })
            .done((data, statusText, xhdr) => self.onSuccess(data, statusText, xhdr))            
                .fail((err, errorText, xhdr) => self.OnFailed(err, errorText, xhdr));
        }

        private onSuccess(data, statusText, xhdr) {
            if (xhdr.status === 200 || xhdr.status === 201) {            

                if (this.successCallback && typeof (this.successCallback) === 'function') {
                    this.successCallback(data, statusText, xhdr);
                }
            } 
        }

        private OnFailed(err, errorText, xhdr) {
            if (xhdr.status >= 400) {
                if (this.failCallback && typeof (this.failCallback) === 'function') {
                    this.failCallback(err, errorText, xhdr);
                }
            } 
        }
    }

}