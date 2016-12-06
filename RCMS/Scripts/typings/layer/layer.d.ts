interface LayerOptions {
    /**
    * 基本层类型
    */
    type?: number;
    /**
    * 标题
    */
    title?: string | Array<string> | boolean;
    /**
    * 内容
    */
    content?: string | Document | Array<string> | JQuery;
    /**
    * 样式类名
    */
    skin?: string;
    /**
    * 宽高
    */
    area?: string | Array<string>
    /**
    * 坐标
    */
    offset?: string | Array<string> | Array<number>
    /**
    * icon
    */
    icon?: number;
    /**
    * 按钮
    */
    btn?: string | Array<string>;
    /**
    * 关闭按钮
    */
    closeBtn?: string | boolean | number;
    /**
    * 遮罩
    */
    shade?: string | boolean | Array<string> | number;
    /**
    * 是否点击遮罩关闭
    */
    shadeClose?: boolean;
    /**
    * 自动关闭所需毫秒
    */
    time?: number;
    /**
* 用于控制弹层唯一标识
*/
    id?: number;
    /**
    * 动画
    */
    shift?: number;
    /**
    * 动画
    */
    maxmin?: boolean;
    /**
    * 固定
    */
    fix?: boolean;
    /**
    * 是否允许浏览器出现滚动条
    */
    scrollbar?: boolean;
    /**
    * 最大宽度
    */
    maxWidth?: number;
    /**
    * 层叠顺序
    */
    zIndex?: number;
    /**
    * 触发拖动的元素
    */
    move?: string | Document | boolean;
    /**
    * 触发拖动的元素
    */
    moveType?: number;
    /**
    * 是否允许拖拽到窗口外
    */
    moveOut?: boolean;
    /**
    * 拖动完毕后的回调方法
    */
    moveEnd?: Function;
    /**
    * tips方向和颜色
    */
    tips?: number | Array<any>;
    /**
    * 是否允许多个tips
    */
    tipsMore?: boolean;
    /**
    * 层弹出后的成功回调方法
    */
    success?: Function;
    /**
    *  确定按钮回调方法
    */
    yes?: Function;
     /**
    * 第二个按钮的事件
    */
    btn2?: Function;
     /**
    * 第二个按钮的事件
    */
    btn3?: Function;
    /**
    * 取消和关闭按钮触发的回调
    */
    cancel?: Function;
    /**
    * 层销毁后触发的回调
    */
    end?: Function;
    /**
    * 最大化的回调
    */
    full?: Function;
    /**
    * 最小化的回调
    */
    min?: Function;
    /**
    * 还原的回调
    */
    restore?: Function;
}
interface Layer {
    /**
    * 初始化全局配置
    */
    config(options);
    /**
    * 初始化就绪
    */
    ready(path, callback);
    /**
    * 原始核心方法
    */
    open(options: LayerOptions);
    /**
    * 普通信息框
    */
    alert(content, options?: LayerOptions, yes?: Function);
    /**
    * 询问框
    */
    confirm(content, options?: LayerOptions, yes?: Function, cancel?: Function);
    /**
    * 提示框
    */
    msg(content, options?: LayerOptions, end?: Function);
    /**
    * 加载层
    */
    load(icon, options?: LayerOptions);
    /**
    * tips层
    */
    tips(content, follow, options?: LayerOptions);
    /**
    * 关闭特定层
    */
    close(index);
    /**
    * 关闭所有层
    */
    closeAll(type?);
    /**
    * 重新定义层的样式
    */
    style(index, cssStyle);
    /**
    * 改变层的标题
    */
    title(title, index);
    /**
    * 获取iframe页的DOM
    */
    getChildFrame(selector, index): Document;
    /**
    *  获取特定iframe层的索引
    */
    getFrameIndex(windowName);
    /**
    *  指定iframe层自适应
    */
    iframeAuto(index);
    /**
    *  重置特定iframe url
    */
    iframeSrc(index, url);
    /**
    *  置顶当前窗口
    */
    setTop(layero);
    full();
    min();
    restore();
    /**
    *  输入层
    */
    prompt(options, yes);
    /**
    *  tab层
    */
    tab(options);
    /**
    *  相册层
    */
    photos(options);
}
declare let layer: Layer;

interface LayerDateOptions {
    /**
    * 需显示日期的元素选择器
    */
    elem: string;
    /**
    * 触发事件
    */
    event?: string;
    /**
    * 日期格式
    */
    format?: string;
    /**
    * 是否开启时间选择
    */
    istime?: boolean,
    /**
    * 是否显示清空
    */
    isclear?: boolean;
    /**
    * 是否显示今天
    */
    istoday?: boolean;
    /**
    * 是否显示确认
    */
    issure?: boolean;
    /**
    * 是否显示节日
    */
    festival?: boolean;
    /**
    * 最小日期
    */
    min?: string;
    /**
    * 最大日期
    */
    max?: string;
    /**
    * 开始日期
    */
    start?: string;
    /**
    * 是否固定在可视区域
    */
    fixed?: boolean;
    /**
    * css z-index
    */
    zIndex?: number;
    /**
    *选择好日期的回调
    */
    choose?: Function;
}
interface LayDate {
    /**
    * laydate 版本号
    */
    v: string;
    /**
    * 加载皮肤，参数skinStr为皮肤名
    */
    skin(skinStr: string);
    (options: LayerDateOptions);
    now(timestamp?, format?);
    /**
    * 重设日历控件坐标，一般用于页面dom结构改变时。
    */
    reset();
}
declare let laydate: LayDate;
