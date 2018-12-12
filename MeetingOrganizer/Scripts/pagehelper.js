$("#big-modal").on('shown.bs.modal', function (e) {
    RunDatePickers();
    RunMultiSelect();
    RunAutoCompletes();
})

function GetPartialView(data, url, title) {
    var data = data || "";
    $.ajax({
        url: url,
        data: data,
        type: "GET",
        success: function (result) {
            $("#big-modal-content").html(result);
            $("#big-modal-title").html(title);
            $("#big-modal").modal('show') ;
        }
    })
}

function HideModal() {
    $("#big-modal").modal('hide');
}

function Notify(xhr) {
    var data = xhr || { status :200 , statusText: "Success",responseJSON :{
        content:"Operation has been completed"
    }};
    var State="";
    var Title = data.statusText;
    var Icon = "fa fa-check";

    switch (data.status) {
        case 400:
            State= "error";
            Icon= "fa fa-times";
            break;
        case 200:
            State= "success";
            Icon="fa fa-thumbs-up";
            break;
    }
    new PNotify({
        title: Title,
        text: data.content || data.responseJSON["content"],
        type: State,
        icon:Icon
    })
}