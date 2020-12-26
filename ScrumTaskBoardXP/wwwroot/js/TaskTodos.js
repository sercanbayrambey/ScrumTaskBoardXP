bootstrapSpinner = ' &nbsp; &nbsp; &nbsp; <span class="spinner-border spinner-border-sm"></span> &nbsp; &nbsp; &nbsp; ';

$(document).ready(function () {
    GetTaskTodos();
})



$("#taskTodosForm").on('click', ".btn-updateTaskTodo", function () {
    var btn = $(this);
    var btnText = btn.html();
    btn.html(bootstrapSpinner);
    btn.attr("disabled", "disabled");

    var name = $.trim($("#taskTodosForm #name").val());
    var description = $.trim($("#taskTodosForm #description").val());
    var status = parseInt($.trim($("#taskTodosForm #status").val()));
    var taskTodoId = parseInt($.trim($("#taskTodosForm #taskTodoId").val()));

    if (name.length == 0 || taskTodoId<0) {
        btn.html(btnText);
        btn.removeAttr("disabled");
        return;
    }

    var postData = {
        Name: name,
        Description: description,
        Id: taskTodoId,

        Status: status
    };

    $.post("/TaskTodo/Update", postData)
        .done(function (response) {
            GetTaskTodos();
            btn.removeAttr("disabled");
            btn.html(btnText);
            SwitchAddForm();
        })
        .fail(function (response) {
            console.log("FAIL", response);
            btn.html(btnText);
            btn.removeAttr("disabled");
        });

});


$("#taskTodosForm").on('click', ".btn-AddTaskTodo", function () {
    var btn = $(this);
    var btnText = btn.html();
    btn.html(bootstrapSpinner);
    btn.attr("disabled", "disabled");

    var name = $.trim($("#taskTodosForm #name").val());
    var description = $.trim($("#taskTodosForm #description").val());
    var taskId = parseInt($.trim($("#taskId").val()));
    var status = parseInt($.trim($("#taskTodosForm #status").val()));

    if (taskId < 0 || name.length == 0) {
        btn.html(btnText);
        btn.removeAttr("disabled");
        return;
    }

    var postData = {
        Name: name,
        Description: description,
        TaskId: taskId,
        Status: status
    };

    $.post("/TaskTodo/Add", postData)
        .done(function (response) {
            GetTaskTodos();
            btn.removeAttr("disabled");
            btn.html(btnText);
        })
        .fail(function (response) {
            console.log("FAIL", response);
            btn.html(btnText);
            btn.removeAttr("disabled");
        });

});

function ParseTableForTaskTodos(data) {
    var tableBody = $("#taskTodoTable tbody");
    tableBody.html('');

    for (var i = 0; i < data.length; i++) {
        var status = data[i]['status'] == 0 ? "Yapılacak" : "Yapıldı";
        tableBody.append($("<tr><td>" + data[i]['id'] + "</td><td>" + new Date(data[i]['dateAdded']).toLocaleString() +"</td ><td>" + data[i]['name'] + "</td><td>" + data[i]['description'] + "</td><td value='" + data[i]['status'] + "'>" + status +  "</td><td>" + '<a class="btn btn-warning" onclick="SwitchEditForm(this);">Düzenle</a> <a class="btn btn-danger" onClick="DeleteTaskTodo(' + data[i]['id'] + ',this)">Sil</a>' + "</td></tr>"))
    }

}

function GetTaskTodos() {
    var taskId = parseInt($("#taskId").val());

    if (taskId < 0)
        return;

    $.get("/TaskTodo/Get", { "taskId": taskId })
        .done(function (response) {
            ParseTableForTaskTodos(response);
        })
        .fail(function (response) {
            bootstrapAlert("Error");
        });
}

function DeleteTaskTodo(taskTodoId, btn) {
    if (!confirm("Bu görevi silmek istediğinizden emin misiniz?"))
        return;
    var btnText = $(btn).html();
    $(btn).html(bootstrapSpinner);
    $(btn).attr("disabled", "disabled");

    $.ajax({
        url: '/TaskTodo/Delete',
        method: 'DELETE',
        data: { id: taskTodoId},
        success: function (result) {
            GetTaskTodos();
            $(btn).removeAttr("disabled");
        },
        error: function (request, msg, error) {
            console.log(error);
            $(btn).html(btnText);
            $(btn).removeAttr("disabled");
        }
    });

}

function SwitchEditForm(sender) {
    var tr = $(sender).parents("tr");
    console.log();
    $("#btnSwitchAddForm").show();
    $("#taskTodosForm #name").val(tr.children()[2].innerText)
    $("#taskTodosForm #description").val(tr.children()[3].innerText)
    $("#taskTodosForm #status").val(tr.children()[2].getAttribute("value"))
    $("#taskTodosForm #taskTodoId").val(tr.children()[0].innerText)

    $("#taskTodosForm #btnSubmit").removeClass("btn-success btn-AddTaskTodo").addClass("btn-warning btn-updateTaskTodo");
    $("#taskTodosForm #btnSubmit").text("Yapılacak İşi Güncelle");
}

function SwitchAddForm() {
    $("#btnSwitchAddForm").hide();
    $("#taskTodosForm #name").val("")
    $("#taskTodosForm #description").val("")
    $("#taskTodosForm #status").val("")
    $("#taskTodosForm #taskTodoId").val("")

    $("#taskTodosForm #btnSubmit").addClass("btn-success btn-AddTaskTodo").removeClass("btn-warning btn-updateTaskTodo");
    $("#taskTodosForm #btnSubmit").text("Yapılacak İşi Ekle");
}