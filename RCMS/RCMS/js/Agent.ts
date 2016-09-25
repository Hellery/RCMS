class Agent {
    static Api(fullCode: String, reqMsg: Object, successCallBack: Function, errorCallBack: Function) {
        var reqMsgStr = JSON.stringify(reqMsg);
        let agentUrl = "/Agent/Api";
        this.Post(agentUrl, { fullCode: fullCode, reqMsg: reqMsg }, successCallBack, errorCallBack);
    }
    static Post(url, data, successCallBack: Function, errorCallBack: Function) {
        $.post(url, data, function (resp) {
            if (resp.IsSuccess) {
                successCallBack(resp);
            } else {
                errorCallBack(resp);
            }
        });
    }
}

