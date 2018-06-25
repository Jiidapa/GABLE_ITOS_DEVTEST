using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GableTest.Entities;
using GableTest.Models;

namespace GableTest.Libraries
{
    public class RequestWithdrawLibrary
    {
        gable_testEntities db = new gable_testEntities();

        public IQueryable<type_m_test> IQueryableType()
        {
            return db.type_m_test;
        }
        public List<TypeModel> GetTypeList()
        {
            try
            {
                List<type_m_test> typeDB = IQueryableType().ToList();
                List<TypeModel> typeList = new List<TypeModel>();
                foreach(type_m_test t in typeDB)
                {
                    TypeModel typeM = new TypeModel();
                    typeM.TYPE_M_TEST_ID = t.TYPE_M_TEST_ID;
                    typeM.TYPE_M_TEST_NAME = t.TYPE_M_TEST_NAME;
                    typeM.TYPE_M_TEST_ACTIVE = t.TYPE_M_TEST_ACTIVE;
                    typeM.TYPE_M_TEST_TIMESTMP = (DateTime)t.TYPE_M_TEST_TIMESTMP;
                    typeList.Add(typeM);
                }
                return typeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddBill(BillModel bill)
        {
            try
            {
                bill_t_test billDB = new bill_t_test();
                billDB.BILL_T_TEST_ID = bill.BILL_T_TEST_ID;
                billDB.EMP_T_TEST_ID = bill.EMP_T_TEST_ID;
                billDB.EMP_T_TEST_NAME = bill.EMP_T_TEST_NAME;
                billDB.TYPE_M_TEST_ID = bill.TYPE_M_TEST_ID;
                billDB.STAT_M_TEST_ID = bill.STAT_M_TEST_ID;
                billDB.BILL_T_TES_VALUES = bill.BILL_T_TES_VALUES;
                billDB.BILL_T_TEST_DATE= bill.BILL_T_TEST_DATE;
                billDB.BILL_T_TEST_TIMESTMP = bill.BILL_T_TEST_TIMESTMP;
                billDB.BILL_T_TEST_ACTINE = bill.BILL_T_TEST_ACTINE;
                billDB.BILL_T_TEST_APPROVE_IDNAME = bill.BILL_T_TEST_APPROVE_IDNAME;

                db.bill_t_test.Add(billDB);
                db.SaveChanges();
                int idBill = billDB.BILL_T_TEST_ID;
                return idBill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BillModel> GetRequestWithdraw(int bi) {
            try
            {
                List<BillModel> requestWithdraw = ( from b in db.bill_t_test
                                              join emp in db.emp_t_test on b.EMP_T_TEST_ID equals emp.EMP_T_TEST_ID
                                              join t in db.type_m_test on b.TYPE_M_TEST_ID equals t.TYPE_M_TEST_ID
                                              join s in db.stat_m_test on b.STAT_M_TEST_ID equals s.STAT_M_TEST_ID
                                              where b.BILL_T_TEST_ID.Equals(bi)
                                              orderby b.BILL_T_TEST_ID
                                        select new BillModel
                                              {
                                                  BILL_T_TEST_ID = b.BILL_T_TEST_ID,
                                                  EMP_T_TEST_NAME = b.EMP_T_TEST_NAME,
                                                  EMP_T_TEST_ID = emp.EMP_T_TEST_ID,
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
                return requestWithdraw;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<bill_t_test> IQueryableBill()
        {
            return db.bill_t_test;
        }
        public bool UpdateRequestApprove(List<BillModel> billStatus) {
            try
            {
                foreach (BillModel b in billStatus)
                {
                    bill_t_test bbT = IQueryableBill().FirstOrDefault(bil => bil.BILL_T_TEST_ID == b.BILL_T_TEST_ID);
                    bbT.STAT_M_TEST_ID = b.STAT_M_TEST_ID;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteRequestWithdraw(List<BillModel> delUniqueID)
        {
            try
            {
                List<bill_t_test> b = new List<bill_t_test>();
                foreach(BillModel billT in delUniqueID)
                {
                    bill_t_test bt = new bill_t_test();
                    bt.BILL_T_TEST_ID = billT.BILL_T_TEST_ID;
                    bt.BILL_T_TEST_ACTINE = billT.BILL_T_TEST_ACTINE;
                    bt.BILL_T_TEST_APPROVE_IDNAME = billT.BILL_T_TEST_APPROVE_IDNAME;
                    bt.BILL_T_TEST_DATE = billT.BILL_T_TEST_DATE;
                    bt.BILL_T_TEST_TIMESTMP = billT.BILL_T_TEST_TIMESTMP;
                    bt.BILL_T_TES_VALUES = billT.BILL_T_TES_VALUES;
                    bt.EMP_T_TEST_ID = billT.EMP_T_TEST_ID;
                    bt.EMP_T_TEST_NAME = billT.EMP_T_TEST_NAME;
                    bt.STAT_M_TEST_ID = billT.STAT_M_TEST_ID;
                    bt.TYPE_M_TEST_ID = billT.TYPE_M_TEST_ID;
                    b.Add(bt);
                }
                foreach(bill_t_test btt in b)
                {
                    db.bill_t_test.Attach(btt);
                    db.bill_t_test.Remove(btt);
                    db.SaveChanges();
                }
                return true;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}