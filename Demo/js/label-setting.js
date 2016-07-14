function BooleanButtonLabel(data, type, full) {
    if (data != null) {
        if (data == "啟用中") {
            return '<span class="label label-success">啟用中</span>'
        }
        else {
            return '<span class="label label-warning">停用中</span>'
        }
    }
}