using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GableTest.Models;
using GableTest.Entities;

namespace GableTest.Libraries
{
    public class ApproveLibrary
    {
        gable_testEntities db = new gable_testEntities();
        public IQueryable<emp_t_test> IQueryableEmployee() {
            return db.emp_t_test;
        }

        public IQueryable<stat_m_test> IQueryablrStatus() {
            return db.stat_m_test;
        }

        public IQueryable<bill_t_test> IQueryableBill() {
            return db.bill_t_test;
        }
        public List<EmployeeModel> GetNameApprove() {
            try
            {
                List<EmployeeModel> emp = (from em in db.emp_t_test 
                                     join po in db.posi_m_test on em.POSI_M_TEST_ID equals po.POSI_M_TEST_ID
                                     where po.POSI_M_TEST_ID.Equals(2)
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
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BillModel> GetRequestWithdraw(int idSelect) {
            try
            {
                List<BillModel> billList = (from b in db.bill_t_test
                                            join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                            join e in db.emp_t_test on b.EMP_T_TEST_ID equals e.EMP_T_TEST_ID
                                            join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                            where s.STAT_M_TEST_ID == idSelect
                                            orderby b.BILL_T_TEST_ID
                                            select new BillModel
                                            {
                                                BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                                EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                                EMP_T_TEST_ID = (int)b.EMP_T_TEST_ID,
                                                EMP_T_TEST_SURNAME = e.EMP_T_TEST_SURNAME,
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
                return billList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BillModel> GetRequestWithdrawALL()
        {
            try
            {
                List<BillModel> billList = (from b in db.bill_t_test
                                            join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                            join e in db.emp_t_test on b.EMP_T_TEST_ID equals e.EMP_T_TEST_ID
                                            join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                            orderby b.BILL_T_TEST_ID
                                            select new BillModel
                                            {
                                                BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                                EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                                EMP_T_TEST_ID = (int)b.EMP_T_TEST_ID,
                                                TYPE_M_TEST_ID = (int)b.TYPE_M_TEST_ID,
                                                TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME,
                                                EMP_T_TEST_SURNAME = e.EMP_T_TEST_SURNAME,
                                                STAT_M_TEST_ID = (int)b.STAT_M_TEST_ID,
                                                STAT_M_TEST_NAME = s.STAT_M_TEST_NAME,
                                                BILL_T_TES_VALUES = (int)b.BILL_T_TES_VALUES,
                                                BILL_T_TEST_DATE = (DateTime)b.BILL_T_TEST_DATE,
                                                BILL_T_TEST_TIMESTMP = (DateTime)b.BILL_T_TEST_TIMESTMP,
                                                BILL_T_TEST_ACTINE = b.BILL_T_TEST_ACTINE,
                                                BILL_T_TEST_APPROVE_IDNAME = (int)b.BILL_T_TEST_APPROVE_IDNAME
                                            }).ToList();
                return billList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StatusModel> GetStatusList() {
            try
            {
                List<stat_m_test> statusDB = IQueryablrStatus().ToList();
                List<StatusModel> statusList = new List<StatusModel>();
                foreach(stat_m_test s in statusDB)
                {
                    StatusModel sm = new StatusModel();
                    sm.STAT_M_TEST_ID = s.STAT_M_TEST_ID;
                    sm.STAT_M_TEST_ACTIVE = s.STAT_M_TEST_ACTIVE;
                    sm.STAT_M_TEST_NAME = s.STAT_M_TEST_NAME;
                    sm.STAT_M_TEST_TIMESTMP = s.STAT_M_TEST_TIMESTMP;
                    statusList.Add(sm);
                }
                return statusList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public bool UpdateApprove(List<BillModel> billStatus)
        {
            try
            {
                foreach(BillModel b in billStatus)
                {
                    bill_t_test billDB = IQueryableBill().FirstOrDefault(s => s.BILL_T_TEST_ID == b.BILL_T_TEST_ID);
                    billDB.STAT_M_TEST_ID = b.STAT_M_TEST_ID;
                    billDB.BILL_T_TEST_APPROVE_IDNAME = b.BILL_T_TEST_APPROVE_IDNAME;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}