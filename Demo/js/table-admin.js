var table = $('#example').DataTable({
    //columnDefs: [{
    //    targets: [0],
    //    visible: false,
    //    searchable: false
    //}],
    order: [],
    language: {
        sProcessing: "處理中...",
        sLengthMenu: "&nbsp;顯示 _MENU_ 項結果",
        sZeroRecords: "沒有符合的結果",
        sInfo: "顯示第 _START_ 至 _END_ 項結果，共 _TOTAL_ 項",
        sInfoEmpty: "顯示第 0 至 0 項結果，共 0 項",
        sInfoFiltered: "(從 _MAX_ 項結果過濾)",
        sInfoPostFix: "",
        sSearch: "快速搜尋&nbsp;",
        sUrl: "",
        oPaginate: {
            "sFirst": "首頁",
            "sPrevious": "上頁",
            "sNext": "下頁",
            "sLast": "尾頁"
        }
    },
    //language: { url: "/Scripts/DateTables/Chinese-traditional.json" },
    stateSave: true,
    scrollX: true,
    lengthMenu: [[5, 10, 20, 50, -1], [5, 10, 20, 50, "全部"]],
    iDisplayLength: 10,
    dom: 'CTlfrtip',
    colVis: {
        exclude: [0, 1],
        sAlign: "right",
        buttonText: "<i class='fa fa-columns fa-fw fa-lg'></i>",
        showAll: "顯示全部",
        showNone: "隱藏全部"
    },
    tableTools: {
        sRowSelect: 'single',
        sSelectedClass: 'active',
        sSwfPath: "/Content/DataTables/swf/copy_csv_xls_pdf.swf",
        aButtons: [
            {
                sExtends: "print",
                sButtonText: "<i class='fa fa-print fa-fw fa-lg'></i>",
                sToolTip: "列印"
            },
            {
                sExtends: "collection",
                sButtonText: "<i class='fa fa-cloud-download fa-fw fa-lg'></i>",
                sToolTip: "匯出",
                aButtons: ["csv", "xls", "pdf"]
            }
        ]
    },
    "initComplete": function (settings, json) {
        //alert( 'DataTables has finished its initialisation.' );
        //$('div.loading').remove();
        //$('#page-wrapper').css('opacity', 1);
    }
});

var oTT = TableTools.fnGetInstance('example');

table.on('click', function () {
    if (oTT.fnGetSelected().length) {
        actionBtn.removeClass('hidden');
    } else {
        actionBtn.addClass('hidden');
    }
});

var actionBtn = $('#detailData, #editData, #deleteData');

$('#detailData').on('click', function (e) {
    e.preventDefault();
    location.href = this.href + '/' + oTT.fnGetSelectedData()[0][0];
});
$('#editData').on('click', function (e) {
    e.preventDefault();
    location.href = this.href + '/' + oTT.fnGetSelectedData()[0][0];
});
$('#deleteData').on('click', function (e) {
    e.preventDefault();
    //if (confirm('確認刪除?')) {
    location.href = this.href + '/' + oTT.fnGetSelectedData()[0][0];
    //}
});