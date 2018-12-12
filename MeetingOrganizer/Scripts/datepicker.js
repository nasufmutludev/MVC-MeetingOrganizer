$(function () {
	RunDatePickers();
})

function RunDatePickers() {
	$('*[data-datepicker-active]')
		.each(function () {
			var datePicker = $(this).data("datepicker-active");
			if (datePicker) {
				$(this).datetimepicker({
					date: this.value ? new Date(moment(this.value, "MM.DD.YYYY hh:mm")) : null,
					format: "MM.DD.YYYY HH:mm"
				});
			}
		});
}