$(function () {
    initTableApprove();
    getNameApprove();
    getStatusList();
    getInformation(0);   

    $("#selectStatus").on('change', function () {
        var id = $(this).val();
        getInformation(id);
    });
})

function convertUnixDateToDate(unixdate) {
    var d = new RegExp('^\d{1,}$');
    var myDate = new Date(unixdate.match(/\d+/)[0] * 1);
    var d = myDate.getDate();
    var m = myDate.getMonth() + 1;
    var y = myDate.getFullYear();

    switch (m) {
        case 1:
            m = "January"
            break;
        case 2:
            m = "February"
            break;
        case 3:
            m = "March"
            break;
        case 4:
            m = "April"
            break;
        case 5:
            m = "May"
            braek;
        case 6:
            m = "June"
            break;
        case 7:
            m = "July"
            break;
        case 8:
            m = "August"
            break;
        case 9:
            m = "September"
            break;
        case 10:
            m = "October"
            break;
        case 11:
            m = "November"
            break;
        case 12:
            m = "December"
            break;
    }
    return d + " " + m + " " + y;
}

function updateApprove() {
    var idEmpApprove = $('#idEmpApprove').val();
    var idSelection = $('#tableApprove').bootstrapTable('getSelections');
    var list = [];

    $.each(idSelection, function () {        
        var b = {
            'BILL_T_TEST_ID': this.BILL_T_TEST_ID,
            'STAT_M_TEST_ID': 3,
            'BILL_T_TEST_APPROVE_IDNAME': idEmpApprove
        }
        list.push(b);        
    });    

    $.ajax({
        contentType: 'application/json',
        dataType: 'json',
        type: 'POST',
        url: base_path + 'Approve/UpdateApprove',
        async: false,
        data: JSON.stringify({ 'billStatus': list }),
        success: function (data) {
            if (data) {
                $('#requestTable').bootstrapTable('load', data);
            }
            else {
                alert('fail');
            }
        },
        error: function (data) {
            alert("error update");
        }
    });    
}

function getNameApprove() {
    $.ajax({
        type: 'GET',
        url: base_path + 'Approve/GetNameApprove',
        async: false,
        success: function (data) {
            if (data) {
                informationEmpApprove($('#idEmpApprove'), $('#nameEmpApprove'), $('#surnameEmpApprove'), $('#positionEmpApprove'), data);
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

function informationEmpApprove(id, name, surname, position, data) {
    $.each(data, function () {
        id.append($('#idEmpApprove').val(this.EMP_T_TEST_ID).html(this.EMP_T_TEST_ID));
        name.append($('#nameEmpApprove').val(this.EMP_T_TEST_NAME).html(this.EMP_T_TEST_NAME));
        surname.append($('#surnameEmpApprove').val(this.EMP_T_TEST_SURNAME).html(this.EMP_T_TEST_SURNAME));
        position.append($('#positionEmpApprove').val(this.POSI_M_TEST_ID).html(this.POSI_M_TEST_NAME));
    });
}

function getInformation(idSelect) {       
    
    if (idSelect == 0) {
        $.ajax({
            type: 'GET',
            url: base_path + 'Approve/GetRequestWithdrawALL',
            async: false,
            success: function (data) {
                if (data) {
                    $('#tableApprove').bootstrapTable('load', data);
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
    else {
        $.ajax({
            type: 'POST',
            url: base_path + 'Approve/GetRequestWithdraw',
            async: false,
            data: {
                'idSelect': idSelect
            },
            success: function (data) {
                if (data) {
                    $('#tableApprove').bootstrapTable('load', data);
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
    
    var getData = $('#tableApprove').bootstrapTable('getData');
    $.each(getData, function () {
        var da = this.BILL_T_TEST_DATE;
        this.BILL_T_TEST_DATE = convertUnixDateToDate(da);
    });
    $('#tableApprove').bootstrapTable('load', getData);
}


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



function initTableApprove() {
    $('#tableApprove').bootstrapTable({
        
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
            title: 'ผู้เบิก',
            formatter: function (value, row) {
                return [row.EMP_T_TEST_NAME, row.EMP_T_TEST_SURNAME].join(' ');
            },    
            sortable: true
        },{
            field: 'state',
            checkbox: true
        }]
    });
}