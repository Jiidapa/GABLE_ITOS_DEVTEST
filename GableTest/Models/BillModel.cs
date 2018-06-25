using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GableTest.Models
{
    public class BillModel
    {
        public int BILL_T_TEST_ID { get; set; }
        public string EMP_T_TEST_NAME {get;set;}
        public int EMP_T_TEST_ID { get; set; }
        public int TYPE_M_TEST_ID { get; set; }
        public int STAT_M_TEST_ID { get; set; }
        public int BILL_T_TES_VALUES { get; set; }
        public DateTime BILL_T_TEST_DATE { get; set; }
        public DateTime BILL_T_TEST_TIMESTMP { get; set; }
        public string BILL_T_TEST_ACTINE { get; set; }
        public int BILL_T_TEST_APPROVE_IDNAME { get; set; }

        public string STAT_M_TEST_NAME { get; set; }
        public string TYPE_M_TEST_NAME { get; set; }
    }
}