/// <reference path="../../scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../../scripts/typings/layer/layer.d.ts" />

class ProductCategory {
    treeSetting;
    constructor() {
        this.InitApp();
    }
    InitApp() {
        this.treeSetting = {
            treeId: 'tree_Category',
            view: {
                dblClickExpand: true,
                showLine: true,
                selectedMulti: false
            },
            edit: {
                enable: true,
                showRemoveBtn: false,
                showRenameBtn: false,
                drag: { isMove: true, prev: true, inner: true, next: true }
            },
            data: {
                key: {
                    Id: "Id",
                    name: "CategoryName",
                    title: "CategoryName",
                    CategoryCode: "CategoryCode"
                },
                simpleData: {
                    enable: true,
                    idKey: "Id",
                    pIdKey: "ParentId",
                    rootPId: '1'
                }
            },
            callback: {
                onClick: function (e, treeId, node, flg) {
                    var that = this;
                    var $cName = $('p[data-role=cName]');
                    var $cId = $('#CategoryId');
                    var $cCode = $('#CurrentCode');
                    $cName.html(node.CategoryName);
                    $cId.val(node.Id)
                    $cCode.val(node.CategoryCode);
                    $("#cId").val(node.Id);
                    $.ajax({
                        url: '/ProductCategory/GetAttrsById',
                        type: 'Post',
                        data: { CategoryCode: node.CategoryCode },
                        success: function (result) {
                            that.selectAttr.val(result.Body).trigger("change");
                        }
                    })
                },
                beforeDrag: function () { },
                onDrag: function () { },
                beforeDrop: function () { },
                onDrop: function (event, treeId, treeNodes, targetNode, moveType, isCopy) {
                    if (moveType == null) { return; }
                    var CategoryId = treeNodes[0].Id;
                    var TargetCategoryCode = targetNode.CategoryCode;
                    var MoveType = 1;
                    switch (moveType) {
                        case "prev": { MoveType = 1; break; }
                        case "next": { MoveType = 2; break; }
                        case "inner": { MoveType = 3; break; }
                    }
                    $.post('/ProductCategory/Move', { CategoryId: CategoryId, TargetCategoryCode: TargetCategoryCode, MoveType: MoveType }, function (resp) {
                        layer.tips('分类移动成功！', 0.5);
                    })
                }
            }
        };
        this.BindEvent();
        this.InitTree();
    }
    BindEvent() {

    }
    InitTree() {
        var that = this;
        $.ajax({
            url: '/ProductCategory/GetAll',
            type: 'post',
            dataType: 'json',
            success: function (resp) {
                $(resp.Body).each(function (i, item) {
                    resp.Body[i].FCategoryCode = resp.Body[i].CategoryCode.substr(0, resp.Body[i].CategoryCode.lastIndexOf('-'));
                });
                $.fn.zTree.init($("#treeContainer"), that.treeSetting, resp.Body);
            }
        });
    }
}

let productCategory: ProductCategory = new ProductCategory();