using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GableTest.Entities;
using GableTest.Models;

namespace GableTest.Libraries
{
    public class WithdrawMoneyLibrary
    {

        gable_testEntities db = new gable_testEntities();
        public IQueryable<emp_t_test> IQuerableEmployee()
        {
            return db.emp_t_test;
        }

        public IQueryable<posi_m_test> IQueryablePosition()
        {
            return db.posi_m_test;
        }

        public IQueryable<bill_t_test> IQueryableBill()
        {
            return db.bill_t_test;
        }

        public IQueryable<type_m_test> IQueryableType()
        {
            return db.type_m_test;
        }

        public IQueryable<stat_m_test> IQueryableStatus()
        {
            return db.stat_m_test;
        }
        public List<EmployeeModel> GetEmployeeList()
        {
            try
            {
                             
                List<EmployeeModel> employee = (from em in db.emp_t_test
                                         join po in db.posi_m_test on em.POSI_M_TEST_ID equals po.POSI_M_TEST_ID
                                         where em.EMP_T_TEST_NAME.Contains("อำนาจ")
                                         orderby em.EMP_T_TEST_ID
                                         select new EmployeeModel
                                         {
                                             EMP_T_TEST_ID = em.EMP_T_TEST_ID,
                                             EMP_T_TEST_NAME = em.EMP_T_TEST_NAME,
                                             EMP_T_TEST_SURNAME = em.EMP_T_TEST_SURNAME,
                                             EMP_T_TEST_ACTIVE = em.EMP_T_TEST_ACTIVE,
                                             EMP_T_TEST_EMAIL = em.EMP_T_TEST_EMAIL,
                                             EMP_T_TEST_TELL = em.EMP_T_TEST_TELL,
                                             POSI_M_TEST_ID = (int)em.POSI_M_TEST_ID,
                                             POSI_M_TEST_NAME = po.POSI_M_TEST_NAME
                                         }).ToList();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BillModel> GetBillList()
        {
            try
            {
                List<BillModel> bill = ( from b in db.bill_t_test
                                         join type in db.type_m_test on b.TYPE_M_TEST_ID equals type.TYPE_M_TEST_ID
                                         join stat in db.stat_m_test on b.STAT_M_TEST_ID equals stat.STAT_M_TEST_ID
                                         join emp in db.emp_t_test on b.EMP_T_TEST_ID equals emp.EMP_T_TEST_ID
                                         where b.EMP_T_TEST_NAME.Contains("อำนาจ")
                                         orderby b.BILL_T_TEST_ID
                                         select new BillModel
                                         {
                                             BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                             EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                             EMP_T_TEST_ID = (int)b.EMP_T_TEST_ID,
                                             TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                             TYPE_M_TEST_NAME = type.TYPE_M_TEST_NAME,
                                             STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                             STAT_M_TEST_NAME = stat.STAT_M_TEST_NAME,
                                             BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                             BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                             BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                             BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                             BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                         }).ToList();
                return bill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}