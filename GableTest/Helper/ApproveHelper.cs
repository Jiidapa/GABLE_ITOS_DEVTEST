using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GableTest.Libraries;
using GableTest.Models;

namespace GableTest.Helper
{
    public class ApproveHelper
    {
        public List<EmployeeModel> GetNameApprove() {
            return new ApproveLibrary().GetNameApprove();
        }

        public List<BillModel> GetRequestWithdraw(int idSelect) {
            return new ApproveLibrary().GetRequestWithdraw(idSelect);
        }

        public List<BillModel> GetRequestWithdrawALL()
        {
            return new ApproveLibrary().GetRequestWithdrawALL();
        }

        public List<StatusModel> GetStatusList() {
            return new ApproveLibrary().GetStatusList();
        }

        public bool UpdateApprove(List<BillModel> billStatus) {
            return new ApproveLibrary().UpdateApprove(billStatus);
        }
    }
}