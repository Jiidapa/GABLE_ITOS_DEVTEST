$(function () {
    getStatusList();
    getType();
    searchReport(0, 0, '');


})

function getStatusList() {
    $.ajax({
        type: 'GET',
        url: base_path + 'Approve/GetStatusList',
        async: false,
        success: function (data) {
            if (data) {
                showStatusList($('#selectStatus'), data);
            }
            else {
                alert("fail");
            }
        },
        error: function (data) {
            alert("error");
        }

    });
}

function showStatusList(s, data) {
    $.each(data, function () {
        s.append($('<option></option>').val(this.STAT_M_TEST_ID).html(this.STAT_M_TEST_NAME));
    });
}

function getType() {
    $.ajax({
        type: 'GET',
        url: base_path + 'RequestWithdraw/GetTypeList',
        async: false,
        success: function (data) {
            if (data) {
                showType($('#selectType'), data);
            }
            else {
                alert("fail");
            }
        },
        error: function (data) {
            alert("error");
        }
    });
}

function showType(selector, options) {
    $.each(options, function () {
        selector.append($('<option></option>').val(this.TYPE_M_TEST_ID).html(this.TYPE_M_TEST_NAME));
    })
}


function searchReport(type, status, name) {

    var type = $('#selectType').val();
    var status = $('#selectStatus').val();
    var nameEmp = $('#nameEmp').val();
    initTableReport();
    //1

    if (type != 0 && status != 0 && nameEmp != "") {
        $.ajax({
            type: 'POST',
            url: base_path + 'Report/SearchReportAllInput',
            async: false,
            data: {
                'STAT_M_TEST_ID': status,
                'TYPE_M_TEST_ID': type,
                'EMP_T_TEST_NAME': nameEmp
            },
            success: function (data) {
                if (data) {
                    $('#tableReport').bootstrapTable('load', data);
                }
                else {
                    alert("fail");
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }

    //2
    if ((type && status) == 0 && nameEmp) {
        $.ajax({
            type: 'POST',
            url: base_path + 'Report/SearchReportNameInput',
            async: false,
            data: {
                'EMP_T_TEST_NAME': nameEmp
            },
            success: function (data) {
                if (data) {
                    $('#tableReport').bootstrapTable('load', data);
                }
                else {
                    alert("fail");
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }
    //3
    if (type == 0 && status != 0 && nameEmp == "") {
        $.ajax({
            type: 'POST',
            url: base_path + 'Report/SearchReportStatusInput',
            async: false,
            data: {
                'STAT_M_TEST_ID': status
            },
            success: function (data) {
                if (data) {
                    $('#tableReport').bootstrapTable('load', data);
                }
                else {
                    alert("fail");
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }
    //4
    if (type != 0 && status == 0 && nameEmp == "") {
        $.ajax({
            type: 'POST',
            url: base_path + 'Report/SearchReportTypeInput',
            async: false,
            data: {
                'TYPE_M_TEST_ID': type
            },
            success: function (data) {
                if (data) {
                    $('#tableReport').bootstrapTable('load', data);
                }
                else {
                    alert("fail");
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }
    //5
    if (type == 0 && status != 0 && nameEmp != "") {
        $.ajax({
            type: 'POST',
            url: base_path + 'Report/SearchReportNameStatusInput',
            async: false,
            data: {
                'STAT_M_TEST_ID': status,
                'EMP_T_TEST_NAME': nameEmp
            },
            success: function (data) {
                if (data) {
                    $('#tableReport').bootstrapTable('load', data);
                }
                else {
                    alert("fail");
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }
    //6
    if (type != 0 && status == 0 && nameEmp != "") {
        $.ajax({
            type: 'POST',
            url: base_path + 'Report/SearchReportNameTypeInput',
            async: false,
            data: {
                'TYPE_M_TEST_ID': type,
                'EMP_T_TEST_NAME': nameEmp
            },
            success: function (data) {
                if (data) {
                    $('#tableReport').bootstrapTable('load', data);
                }
                else {
                    alert("fail");
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }
    //7
    if (type != 0 && status != 0 && nameEmp == "") {
        $.ajax({
            type: 'POST',
            url: base_path + 'Report/SearchReportStatusTypeInput',
            async: false,
            data: {
                'TYPE_M_TEST_ID': type,
                'STAT_M_TEST_ID': status
            },
            success: function (data) {
                if (data) {
                    $('#tableReport').bootstrapTable('load', data);
                }
                else {
                    alert("fail");
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }
    //8
    if (type == 0 && status == 0 && nameEmp == "") {
        $.ajax({
            type: 'GET',
            url: base_path + 'Report/SearchReportAllNull',
            async: false,
            success: function (data) {
                if (data) {
                    $('#tableReport').bootstrapTable('load', data);
                }
                else {
                    alert("fail");
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }
}

function initTableReport() {
    $('#tableReport').bootstrapTable({
        columns: [{
            field: 'BILL_T_TEST_ID',
            title: 'ลำดับ',
            sortable: true
        }, {
            field: 'TYPE_M_TEST_NAME',
            title: 'รายการ',
            sortable: true
        }, {
            field: 'BILL_T_TES_VALUES',
            title: 'จำนวน',
            sortable: true
        }, {
            field: 'STAT_M_TEST_NAME',
            title: 'สถานะ',
            sortable: true
        }, {
            field: 'BILL_T_TEST_DATE',
            title: 'วันที่',
            sortable: true
        }, {
            field: 'EMP_T_TEST_NAME',
            title: 'ผู้เบิก',
            sortable: true
        }]
    });
}