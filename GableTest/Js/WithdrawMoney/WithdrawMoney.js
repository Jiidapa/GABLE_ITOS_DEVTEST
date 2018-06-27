$(function () {
    getEmployee();
    initWithdrawMoneyTable();
    getWithdrawMoney();

    $('#requestWithdraw').click(function () {
        window.location = base_path + 'RequestWithdraw/RequestWithdraw';
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
                $('#tableWithdraw').bootstrapTable('load', data);
                var getData = $('#tableWithdraw').bootstrapTable('getData');
                $.each(getData, function () {
                    this.BILL_T_TEST_DATE = convertUnixDateToDate(this.BILL_T_TEST_DATE);
                });
                $('#tableWithdraw').bootstrapTable('load', getData);
            }
            else{
                alert("fail");
            }
        },
        error: function(data){
            alert("error");
        },
    });

}

function initWithdrawMoneyTable() {
    $('#tableWithdraw').bootstrapTable({
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



