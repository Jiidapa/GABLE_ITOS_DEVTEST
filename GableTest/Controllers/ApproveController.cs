using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GableTest.Models;
using GableTest.Helper;

namespace GableTest.Controllers
{
    public class ApproveController : Controller
    {

        protected ApproveHelper approveHelp = new ApproveHelper();
        // GET: Approve
        public ActionResult Approve()
        {
            return View();
        }

        public ActionResult GetNameApprove() {
            try
            {
                List<EmployeeModel> name = approveHelp.GetNameApprove();
                var list = name.Select(e => new
                {
                    EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                    EMP_T_TEST_NAME = e.EMP_T_TEST_NAME,
                    EMP_T_TEST_SURNAME = e.EMP_T_TEST_SURNAME,
                    POSI_M_TEST_ID = e.POSI_M_TEST_ID,
                    POSI_M_TEST_NAME = e.POSI_M_TEST_NAME
                });
                return Json(name, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetRequestWithdraw(int idSelect) {
            try
            {
                List<BillModel> billList = approveHelp.GetRequestWithdraw(idSelect);
                return Json(billList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetRequestWithdrawALL()
        {
            try
            {
                List<BillModel> billList = approveHelp.GetRequestWithdrawALL();
                return Json(billList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetStatusList() {
            try
            {
                List<StatusModel> statusList = approveHelp.GetStatusList();
                var s = statusList.Select( st => new {
                    STAT_M_TEST_ID = st.STAT_M_TEST_ID,
                    STAT_M_TEST_NAME = st.STAT_M_TEST_NAME
                });
                return Json(statusList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateApprove(List<BillModel> billStatus) {
            try
            {
                bool updated = approveHelp.UpdateApprove(billStatus);
                if (updated)
                {
                    var blist = approveHelp.GetNameApprove();
                    return Json(blist, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}