using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GableTest.Models;
using GableTest.Entities;

namespace GableTest.Libraries
{
    public class ReportLibrary
    {
        gable_testEntities db = new gable_testEntities();
        
        //1
        public List<BillModel> SearchReportAllInput(BillModel bill)
        {
            try
            {
                List<BillModel> query = (from b in db.bill_t_test
                               join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                               join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                               join e in db. emp_t_test on b.EMP_T_TEST_NAME equals e.EMP_T_TEST_NAME
                               where e.EMP_T_TEST_NAME.Contains(bill.EMP_T_TEST_NAME) && t.TYPE_M_TEST_ID.Equals(bill.TYPE_M_TEST_ID) 
                                       && s.STAT_M_TEST_ID.Equals(bill.STAT_M_TEST_ID)
                               orderby b.BILL_T_TEST_ID
                               select new BillModel {
                                   BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                   EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                   EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                                   TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                   TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                   STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                   STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                   BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                   BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                   BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                   BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                   BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                               }).ToList();
                return query;               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //2
        public List<BillModel> SearchReportNameInput(BillModel bill)
        {
            try
            {
                List<BillModel> query = (from b in db.bill_t_test
                                         join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                         join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                         join e in db.emp_t_test on b.EMP_T_TEST_NAME equals e.EMP_T_TEST_NAME
                                         where e.EMP_T_TEST_NAME.Contains(bill.EMP_T_TEST_NAME)
                                         orderby b.BILL_T_TEST_ID
                                         select new BillModel
                                         {
                                             BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                             EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                             EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                                             TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                             TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                             STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                             STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                             BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                             BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                             BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                             BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                             BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                         }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //3
        public List<BillModel> SearchReportStatusInput(BillModel bill)
        {
            try
            {
                List<BillModel> query = (from b in db.bill_t_test
                                         join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                         join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                         join e in db.emp_t_test on b.EMP_T_TEST_NAME equals e.EMP_T_TEST_NAME
                                         where s.STAT_M_TEST_ID.Equals(bill.STAT_M_TEST_ID)
                                         orderby b.BILL_T_TEST_ID
                                         select new BillModel
                                         {
                                             BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                             EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                             EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                                             TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                             TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                             STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                             STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                             BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                             BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                             BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                             BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                             BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                         }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //4
        public List<BillModel> SearchReportTypeInput(BillModel bill)
        {
            try
            {
                List<BillModel> query = (from b in db.bill_t_test
                                         join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                         join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                         join e in db.emp_t_test on b.EMP_T_TEST_NAME equals e.EMP_T_TEST_NAME
                                         where t.TYPE_M_TEST_ID.Equals(bill.TYPE_M_TEST_ID)
                                         orderby b.BILL_T_TEST_ID
                                         select new BillModel
                                         {
                                             BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                             EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                             EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                                             TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                             TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                             STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                             STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                             BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                             BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                             BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                             BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                             BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                         }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //5
        public List<BillModel> SearchReportNameStatusInput(BillModel bill)
        {
            try
            {
                List<BillModel> query = (from b in db.bill_t_test
                                         join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                         join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                         join e in db.emp_t_test on b.EMP_T_TEST_NAME equals e.EMP_T_TEST_NAME
                                         where s.STAT_M_TEST_ID.Equals(bill.STAT_M_TEST_ID) && b.EMP_T_TEST_NAME.Contains(bill.EMP_T_TEST_NAME)
                                         orderby b.BILL_T_TEST_ID
                                         select new BillModel
                                         {
                                             BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                             EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                             EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                                             TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                             TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                             STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                             STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                             BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                             BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                             BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                             BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                             BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                         }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //6
        public List<BillModel> SearchReportNameTypeInput(BillModel bill)
        {
            try
            {
                List<BillModel> query = (from b in db.bill_t_test
                                         join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                         join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                         join e in db.emp_t_test on b.EMP_T_TEST_NAME equals e.EMP_T_TEST_NAME
                                         where t.TYPE_M_TEST_ID.Equals(bill.TYPE_M_TEST_ID) && b.EMP_T_TEST_NAME.Contains(bill.EMP_T_TEST_NAME)
                                         orderby b.BILL_T_TEST_ID
                                         select new BillModel
                                         {
                                             BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                             EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                             EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                                             TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                             TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                             STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                             STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                             BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                             BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                             BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                             BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                             BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                         }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //7
        public List<BillModel> SearchReportStatusTypeInput(BillModel bill)
        {
            try
            {
                List<BillModel> query = (from b in db.bill_t_test
                                         join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                         join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                         join e in db.emp_t_test on b.EMP_T_TEST_NAME equals e.EMP_T_TEST_NAME
                                         where t.TYPE_M_TEST_ID.Equals(bill.TYPE_M_TEST_ID) && s.STAT_M_TEST_ID.Equals(bill.STAT_M_TEST_ID)
                                         orderby b.BILL_T_TEST_ID
                                         select new BillModel
                                         {
                                             BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                             EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                             EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                                             TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                             TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                             STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                             STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                             BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                             BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                             BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                             BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                             BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                         }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //8
        public List<BillModel> SearchReportAllNull()
        {
            try
            {
                List<BillModel> query = (from b in db.bill_t_test
                                         join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                         join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                         join e in db.emp_t_test on b.EMP_T_TEST_NAME equals e.EMP_T_TEST_NAME
                                         orderby b.BILL_T_TEST_ID
                                         select new BillModel
                                         {
                                             BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                             EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                             EMP_T_TEST_ID = e.EMP_T_TEST_ID,
                                             TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                             TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                             STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                             STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                             BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                             BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                             BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                             BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                             BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                         }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}