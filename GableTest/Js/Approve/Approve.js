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
        }, {
            field: 'EMP_T_TEST_NAME',
            title: 'ผู้เบิก'
        }, {
            field: 'state',
            checkbox: true
        }]
    });
}