using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GableTest.Models;
using GableTest.Libraries;

namespace GableTest.Helper
{
    public class WithdrawMoneyHelper
    {
        public List<EmployeeModel> GetEmployeeList()
        {
            return new WithdrawMoneyLibrary().GetEmployeeList();
        }

        public List<BillModel> GetBillList()
        {
            return new WithdrawMoneyLibrary().GetBillList();
        }
    }
}