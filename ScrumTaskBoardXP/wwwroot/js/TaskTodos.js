bootstrapSpinner = ' &nbsp; &nbsp; &nbsp; <span class="spinner-border spinner-border-sm"></span> &nbsp; &nbsp; &nbsp; ';




$("#taskTodosForm").on('click', ".btn-AddTaskTodo", function () {
    var btn = $(this);
    var btnText = btn.html();
    btn.html(bootstrapSpinner);
    btn.attr("disabled", "disabled");
    console.log("asdsa");

    var code = $.trim($("#taskTodosForm #code").val());
    var name = $.trim($("#taskTodosForm #name").val());
    var count = parseInt($.trim($("#taskTodosForm #count").val()));
    var variantId = parseInt($.trim($("#variantId").val()));
    var isActive = $("#taskTodosForm #stockIsActive").is(':checked') ? true : false;

    if (count < 0 || variantId < 0 || name.length == 0) {
        btn.html(btnText);
        btn.removeAttr("disabled");
        return;
    }

    var postData = {
        Name: name,
        Code: code,
        Count: count,
        ProductVariantId: variantId,
        IsActive: isActive
    };

    $.post("/Admin/Product/AddStock", postData)
        .done(function (response) {
            ParseTableForStocks(response);
            btn.html(btnText);
            btn.removeAttr("disabled");
        })
        .fail(function (response) {
            console.log("FAIL", response);
            btn.html(btnText);
            btn.removeAttr("disabled");
        });

})