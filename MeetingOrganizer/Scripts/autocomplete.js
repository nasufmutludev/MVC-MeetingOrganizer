$(function () {
    RunAutoCompletes();
});

function RunAutoCompletes() {
    $('*[data-autocomplete-url]')
		.each(function () {
		    var _url = $(this).data("autocomplete-url");
		    var _hiddenInput = this.id;

		    $(this).autocomplete({
		        source: function (request, response) {

		            $.ajax({
		                url: _url,
		                method: "post",
		                data: {
		                    key: request.term
		                },
		                success: function (data) {
		                    response($.map(data, function (item) {
		                        return { label: item.Label, value: item.ID };
		                    }))
		                }
		            });
		        },
		        minLength: 1,
		        select: function (event, ui) {
		            $("input:hidden[id=" + _hiddenInput + "]").val(ui.item.value);
		            $("input[id=" + _hiddenInput + "][type!='hidden']").val(ui.item.label);
		            return false;
		        },
		        open: function () {
		            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
		        },
		        close: function () {
		            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
		        },
		        change: function (event, ui) {
		            if (ui.item) {
		                $("input:hidden[id=" + _hiddenInput + "]").val(ui.item.value);
		                $("input[id=" + _hiddenInput + "][type!='hidden']").val(ui.item.label);

		            } else {
		                $("input:hidden[id=" + _hiddenInput + "]").val("");
		                $("input[id=" + _hiddenInput + "][type!='hidden']").val("");
		            }
		            return false;
		        }
		    });
		});
}