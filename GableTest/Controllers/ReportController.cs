using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GableTest.Models;
using GableTest.Helper;

namespace GableTest.Controllers
{
    public class ReportController : Controller
    {
        protected ReportHelper reportHelp = new ReportHelper();
        // GET: Report
        public ActionResult Report()
        {
            return View();
        }

        //1
        public ActionResult SearchReportAllInput(BillModel bill)
        {
            try
            {
                if (bill != null)
                {
                    List<BillModel> b = reportHelp.SearchReportAllInput(bill);
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //2
        public ActionResult SearchReportNameInput(BillModel bill)
        {
            try
            {
                if (bill != null)
                {
                    List<BillModel> b = reportHelp.SearchReportNameInput(bill);
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //3
        public ActionResult SearchReportStatusInput(BillModel bill)
        {
            try
            {
                if (bill != null)
                {
                    List<BillModel> b = reportHelp.SearchReportStatusInput(bill);
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //4
        public ActionResult SearchReportTypeInput(BillModel bill)
        {
            try
            {
                if (bill != null)
                {
                    List<BillModel> b = reportHelp.SearchReportTypeInput(bill);
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        //5
        public ActionResult SearchReportNameStatusInput(BillModel bill)
        {
            try
            {
                if (bill != null)
                {
                    List<BillModel> b = reportHelp.SearchReportNameStatusInput(bill);
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        //6
        public ActionResult SearchReportNameTypeInput(BillModel bill)
        {
            try
            {
                if (bill != null)
                {
                    List<BillModel> b = reportHelp.SearchReportNameTypeInput(bill);
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        //7
        public ActionResult SearchReportStatusTypeInput(BillModel bill)
        {
            try
            {
                if (bill != null)
                {
                    List<BillModel> b = reportHelp.SearchReportStatusTypeInput(bill);
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        //8
        public ActionResult SearchReportAllNull()
        {
            try
            {
                List<BillModel> b = reportHelp.SearchReportAllNull();
                return Json(b, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}