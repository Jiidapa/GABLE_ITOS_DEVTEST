using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GableTest.Helper;
using GableTest.Models;

namespace GableTest.Controllers
{
    public class RequestWithdrawController : Controller
    {

        protected RequestWithdrawHelper requestWithdrawHelp = new RequestWithdrawHelper();
        // GET: RequestWithdraw
        public ActionResult RequestWithdraw()
        {
            return View();
        }

        public ActionResult GetTypeList()
        {
            try
            {
                List<TypeModel> typeList = requestWithdrawHelp.GetTypeList();
                var select = typeList.Select(t => new
                {
                    TYPE_M_TEST_ID = t.TYPE_M_TEST_ID,
                    TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME
                });
                return Json(typeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddBill(BillModel bill)
        {
            try
            {
                int id = requestWithdrawHelp.AddBill(bill);
                if (id > 0)
                {
                    List<BillModel> b = requestWithdrawHelp.GetRequestWithdraw(id);
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetRequestWithdraw(int b) {
            try
            {
                List<BillModel> bill = requestWithdrawHelp.GetRequestWithdraw(b);
                return Json(bill, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateRequestApprove(List<BillModel> billStatus)
        {
            try
            {
                bool updated = requestWithdrawHelp.UpdateRequestApprove(billStatus);
                if (updated) {
                    var bList = requestWithdrawHelp;
                    return Json(bList, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteRequestWithdraw(List<BillModel> delUniqueID)
        {
            try
            {
                bool deleted = requestWithdrawHelp.DeleteRequestWithdraw(delUniqueID);
                if (deleted)
                {
                    var list = requestWithdrawHelp;
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}