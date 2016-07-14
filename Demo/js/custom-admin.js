$(function () {
    $('select').selectpicker();

    $('.date').datepicker({
        language: "zh-TW",
        clearBtn: true,
        todayHighlight: true,
        format: "yyyy-mm-dd",
        autoclose: true
    });

    // http://stackoverflow.com/a/8524597 required label show '*'
    $('input[type=text]').each(function () {
        var req = $(this).attr('data-val-required');
        if (undefined !== req) {
            var label = $('label[for="' + $(this).attr('id') + '"]');
            var text = label.text();
            if (text.length > 0) {
                //label.prepend('<span style="color:red"> *</span>');
                label.addClass('required');
            }
        }
    });

    $("#checkAll").change(function () {
        $(this).closest('.form-group')
               .find($("input:checkbox"))
               .prop('checked', $(this).prop("checked"));
    });

    // http://stackoverflow.com/a/24914782 fix multiple modals scrollbar
    $(document).on('hidden.bs.modal', '.modal', function () {
        $('.modal:visible').length && $(document.body).addClass('modal-open');
    });

    // PreviewImage 
    var frameSrc = "/fileman/dev.html?integration=custom&txtFieldId=";//?integration=custom&type=files&txtFieldId=Picture_Path
    var finder = document.getElementById('Finder');
    var $modal = $('.modal-preview-image');
    $('body').on('click', '.preview-image', function () {
        var id = this.getAttribute('data-id');
        $modal.on('shown.bs.modal', function () {      //correct here use 'shown.bs.modal' event which comes in bootstrap3
            finder.src = frameSrc + id;
        })
        $modal.modal({ show: true })
    })
    $('body').on('click', '.preview-close', function () {
        var id = $(this).closest('.box').find('img').data('id');
        document.getElementById(id + '_Preview').src = 'http://placehold.it/300x200?text=IMAGE';
        document.getElementById(id).value = '';
        $(this).closest('.box').find('.box-title').text('');
    });

});

function closeModal_PreviewImage() {
    $('.modal-preview-image').modal('hide');
    document.getElementById('Finder').src = '';
}