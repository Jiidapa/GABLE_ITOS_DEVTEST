using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GableTest.Helper;
using GableTest.Models;

namespace GableTest.Controllers
{
    public class WithdrawMoneyController : Controller
    {
        // GET: WithdrawMoney
        protected WithdrawMoneyHelper withdrawHelp = new WithdrawMoneyHelper();
        // GET: WithdrawMoney
        public ActionResult WithdrawMoney()
        {
            return View();
        }
        
        public ActionResult GetEmployeeList()
        {
            try
            {
                List<EmployeeModel> empList = withdrawHelp.GetEmployeeList();
                var list = empList.Select(emp => new
                {
                    EMP_T_TEST_ID = emp.EMP_T_TEST_ID,
                    EMP_T_TEST_NAME = emp.EMP_T_TEST_NAME,
                    EMP_T_TEST_SURNAME = emp.EMP_T_TEST_SURNAME,
                    POSI_M_TEST_ID = emp.POSI_M_TEST_ID,
                    POSI_M_TEST_NAME = emp.POSI_M_TEST_NAME
                });
                return Json(empList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetBillList()
        {
            try
            {
                List<BillModel> billList = withdrawHelp.GetBillList();
                return Json(billList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}