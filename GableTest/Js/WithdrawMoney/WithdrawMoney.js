$(function () {
    getEmployee();
    initWithdrawMoneyTable();
    getWithdrawMoney();

    $('#requestWithdraw').click(function () {
        window.location = base_path + 'RequestWithdraw/RequestWithdraw';
    });
})

function getEmployee() {
    $.ajax({
        type: 'GET',
        url: base_path + 'WithdrawMoney/GetEmployeeList',
        async: false,
        success: function (data) {
            if (data) {
                showInformation($('#name'), $('#surname'), $('#position'), data);
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

function showInformation(name, surname, position, options) {
    $.each(options, function () {
        name.append($('#name').val(this.EMP_T_TEST_ID).html(this.EMP_T_TEST_NAME));
        surname.append($('#surname').val(this.EMP_T_TEST_ID).html(this.EMP_T_TEST_SURNAME));
        position.append($('#position').val(this.EMP_T_TEST_ID).html(this.POSI_M_TEST_NAME));
    });
}

function getWithdrawMoney() {   
    $.ajax({
        type: 'GET',
        url: base_path + 'WithdrawMoney/GetBillList',
        asyn: false,
        success: function (data) {
            if (data) {
                $('#tableWithdrawTable').bootstrapTable('load', data);
            }
            else{
                alert("fail");
            }
        },
        error: function(data){
            alert("error");
        }
    });
}

function initWithdrawMoneyTable() {
    $('#tableWithdrawTable').bootstrapTable({
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
        }]
    });
}



