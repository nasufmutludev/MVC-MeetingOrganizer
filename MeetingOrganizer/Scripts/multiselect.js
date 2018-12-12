$(function () {
    RunMultiSelect();
})

function RunMultiSelect() {
    $('*[data-multiselect-active]')
       .each(function () {
           var multiselect = $(this).data("multiselect-active");
           if (multiselect) {
               $(this).multiSelect({
                   afterselect: function (values) {
                       console.log(values)
                   },
                   afterdeselect: function (values) {
                       console.log(values)
                   },
               });
           }
       });
}