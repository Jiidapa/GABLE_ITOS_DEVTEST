$(function () {
    getEmployee();
    getType();

    $("#requestApprove").hide();
    var date = getdate();
    $('#dateBill').val(date);

    $('#removeRequest').hide();
    $('#removeRequest').click(function () {
        var idSelection = $('#requestTable').bootstrapTable('getSelections');
        $.each(idSelection, function (key, val) {
            $('#requestTable').bootstrapTable('removeByUniqueId', this.BILL_T_TEST_ID);
        });
        deleteRequestWithdraw(idSelection);
    })
})

function getdate() {
    var dNow = new Date();
    var day = dNow.getDate();
    var month = dNow.getMonth() + 1;
    var year = dNow.getFullYear();

    /*
    switch (month){
        case 1: 
            month = "January"
            break;
        case 2:
            month ="February"
            break;
        case 3:
            month = "March"
            break;
        case 4:
            month = "April"
            break;
        case 5:
            month = "May"
            braek;
        case 6:
            month = "June"
            break;
        case 7:
            month = "July"
            break;
        case 8:
            month = "August"
            break;
        case 9:
            month = "September"
            break;
        case 10:
            month = "October"
            break;
        case 11:
            month = "November"
            break;
        case 12:
            month = "December"
            break;
    }
    */
    var utcdate = day + '/' + month + '/' + year;
    return utcdate;
}
function getEmployee() {
    $.ajax({
        type: 'GET',
        url: base_path + 'WithdrawMoney/GetEmployeeList',
        async: false,
        success: function (data) {
            if (data) {
                showInformation($('#idEmp'), $('#name'), $('#surname'), $('#position'), data);
            }
            else {
                alert('fail');
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}

function showInformation(idEmp, name, surname, position, options) {
    $.each(options, function () {
        idEmp.append($('#idEmp').val(this.EMP_T_TEST_ID).html(this.EMP_T_TEST_ID));
        name.append($('#name').val(this.EMP_T_TEST_NAME).html(this.EMP_T_TEST_NAME));
        surname.append($('#surname').val(this.EMP_T_TEST_ID).html(this.EMP_T_TEST_SURNAME));
        position.append($('#position').val(this.EMP_T_TEST_ID).html(this.POSI_M_TEST_NAME));
    });
}

function getType() {
    $.ajax({
        type: 'GET',
        url: base_path + 'RequestWithdraw/GetTypeList',
        async: false,
        success: function (data) {
            if (data) {
                populateSelect($('#selectType'), data);
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

function populateSelect(selector, options) {
    $.each(options, function () {
        selector.append($('<option></option>').val(this.TYPE_M_TEST_ID).html(this.TYPE_M_TEST_NAME));
    })
}

function addRequestWithdraw() {
    initTableRequestWithdraw();
}

function timestamp() {
    Number.prototype.padLeft = function (base, chr) {
        var len = (String(base || 10).length - String(this).length) + 1;
        return len > 0 ? new Array(len).join(chr || '0') + this : this;
    }
    var d = new Date,
        dformat = [d.getFullYear().padLeft(),
                    (d.getMonth() + 1).padLeft(),
                    d.getDate()].join('-') +
                    ' ' +
                  [d.getHours().padLeft(),
                    d.getMinutes().padLeft(),
                    d.getSeconds().padLeft()].join(':');
    return dformat;
}

function addBill() {
    var EMP_T_TEST_ID = $('#idEmp').val();
    var EMP_T_TEST_NAME = $('#name').val();
    var TYPE_M_TEST_ID = $('#selectType').val();
    var STAT_M_TEST_ID = 1;
    var BILL_T_TES_VALUES = $('#billValue').val();
    var BILL_T_TEST_DATE = $('#billDate').val();
    var BILL_T_TEST_TIMESTMP = timestamp();
    var BILL_T_TEST_ACTINE = "Y";
    var BILL_T_TEST_APPROVE_IDNAME = 0;

    $('#removeRequest').show();
    $.ajax({
        type: 'POST',
        url: base_path + 'RequestWithdraw/AddBill',
        async: false,
        data: {
            'EMP_T_TEST_ID': EMP_T_TEST_ID,
            'EMP_T_TEST_NAME': EMP_T_TEST_NAME,
            'TYPE_M_TEST_ID': TYPE_M_TEST_ID,
            'STAT_M_TEST_ID': STAT_M_TEST_ID,
            'BILL_T_TES_VALUES': BILL_T_TES_VALUES,
            'BILL_T_TEST_DATE': BILL_T_TEST_DATE,
            'BILL_T_TEST_TIMESTMP': BILL_T_TEST_TIMESTMP,
            'BILL_T_TEST_ACTINE': BILL_T_TEST_ACTINE,
            'BILL_T_TEST_APPROVE_IDNAME': BILL_T_TEST_APPROVE_IDNAME,
        },
        success: function (data) {
            if (data) {
                $("#requestApprove").show();
                initTableRequestWithdraw();
                $('#requestTable').bootstrapTable('append', data);
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

function updateStatus() {
    
    var billList = $('#requestTable').bootstrapTable('getData');
    var list = [];
    $.each(billList, function () {
        var b = {
            'BILL_T_TEST_ID': this.BILL_T_TEST_ID,
            'STAT_M_TEST_ID': 2
        }
        list.push(b);
    });

    
    $.ajax({
        contentType: 'application/json',
        dataType: 'json',
        type: 'POST',
        url: base_path + 'RequestWithdraw/UpdateRequestApprove',
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

    var newData = $('#requestTable').bootstrapTable('getData');
    $.each(newData, function () {
        this.STAT_M_TEST_NAME = 'รออนุมัติ';
    });
    $('#requestTable').bootstrapTable('load', newData);
}


function deleteRequestWithdraw(id) {
    $.ajax({
        contentType: 'application/json',
        dataType: 'json',
        type: 'POST',
        url: base_path + 'RequestWithdraw/DeleteRequestWithdraw',
        data: JSON.stringify({'delUniqueID': id}),
        success: function(data)
        {
            if (data) {
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

function initTableRequestWithdraw() {
    $('#requestTable').bootstrapTable({
        uniqueId: 'BILL_T_TEST_ID',
        columns: [{
            field: 'state',
            checkbox: true
        }, {
            field: 'BILL_T_TEST_ID',
            title: 'ลำดับ'
        }, {
            field: 'TYPE_M_TEST_NAME',
            title: 'รายการ'
        }, {
            field: 'BILL_T_TES_VALUES',
            title: 'จำนวน'
        }, {
            field: 'STAT_M_TEST_NAME',
            title: 'สถานะ'
        }, {
            field: 'BILL_T_TEST_DATE',
            title: 'วันที่'
        }]
    });
}