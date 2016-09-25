var Agent = (function () {
    function Agent() {
    }
    Agent.Api = function (fullCode, reqMsg, successCallBack, errorCallBack) {
        var reqMsgStr = JSON.stringify(reqMsg);
        var agentUrl = "/Agent/Api";
        this.Post(agentUrl, { fullCode: fullCode, reqMsg: reqMsg }, successCallBack, errorCallBack);
    };
    Agent.Post = function (url, data, successCallBack, errorCallBack) {
        $.post(url, data, function (resp) {
            if (resp.IsSuccess) {
                successCallBack(resp);
            }
            else {
                errorCallBack(resp);
            }
        });
    };
    return Agent;
}());
//# sourceMappingURL=Agent.js.map