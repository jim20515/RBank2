var table = $('#example').dataTable({
    //columnDefs: [{
    //    targets: [0],
    //    visible: false,
    //    searchable: false
    //}],
    order: [],
    language: { url: "/Scripts/DataTables/Chinese-traditional.json" },
    //stateSave: true,
    //scrollX: true,
    lengthMenu: [[5, 10, 20, 50, -1], [5, 10, 20, 50, "全部"]],
    iDisplayLength: 10
});