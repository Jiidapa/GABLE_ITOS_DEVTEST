using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GableTest.Libraries;
using GableTest.Models;

namespace GableTest.Helper
{
    public class RequestWithdrawHelper
    {
        public List<TypeModel> GetTypeList()
        {
            return new RequestWithdrawLibrary().GetTypeList();
        }

        public int AddBill(BillModel bill)
        {
            return new RequestWithdrawLibrary().AddBill(bill);
        }

        public List<BillModel> GetRequestWithdraw(int b) {
            return new RequestWithdrawLibrary().GetRequestWithdraw(b);
        }

        public bool UpdateRequestApprove(List<BillModel> billStatus)
        {
            return new RequestWithdrawLibrary().UpdateRequestApprove(billStatus);
        }
        
        public bool DeleteRequestWithdraw(List<BillModel> delUniqueID)
        {
            return new RequestWithdrawLibrary().DeleteRequestWithdraw(delUniqueID);
        }
    }
}