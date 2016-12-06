class Agent {
    static Api(fullCode: String, reqMsg: any, successCallBack: Function, errorCallBack: Function) {
        var reqMsgStr = JSON.stringify(reqMsg);
        let agentUrl = "/Agent/Api";
        this.Post(agentUrl, { fullCode: fullCode, reqMsg: reqMsgStr }, successCallBack, errorCallBack);
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

