using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GableTest.Libraries;
using GableTest.Models;

namespace GableTest.Helper
{
    public class ReportHelper
    {
        //1
        public List<BillModel> SearchReportAllInput(BillModel bill)
        {
            return new ReportLibrary().SearchReportAllInput(bill);
        }      
        
        //2 
        public List<BillModel> SearchReportNameInput(BillModel bill)
        {
            return new ReportLibrary().SearchReportNameInput(bill);
        }

        //3 
        public List<BillModel> SearchReportStatusInput(BillModel bill)
        {
            return new ReportLibrary().SearchReportStatusInput(bill);
        }

        //4 
        public List<BillModel> SearchReportTypeInput(BillModel bill)
        {
            return new ReportLibrary().SearchReportTypeInput(bill);
        }
        //5
        public List<BillModel> SearchReportNameStatusInput(BillModel bill)
        {
            return new ReportLibrary().SearchReportNameStatusInput(bill);
        }
        //6
        public List<BillModel> SearchReportNameTypeInput(BillModel bill)
        {
            return new ReportLibrary().SearchReportNameTypeInput(bill);
        }
        //7
        public List<BillModel> SearchReportStatusTypeInput(BillModel bill)
        {
            return new ReportLibrary().SearchReportStatusTypeInput(bill);
        }
        //7
        public List<BillModel> SearchReportAllNull()
        {
            return new ReportLibrary().SearchReportAllNull();
        }
    }
}