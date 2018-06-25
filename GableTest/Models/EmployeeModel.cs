using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GableTest.Models
{
    public class EmployeeModel
    {
        public int EMP_T_TEST_ID { get; set; }
        public int POSI_M_TEST_ID { get; set; }
        public string EMP_T_TEST_NAME { get; set; }
        public string EMP_T_TEST_SURNAME { get; set; }
        public string EMP_T_TEST_TELL { get; set; }
        public string EMP_T_TEST_EMAIL { get; set; }
        public string EMP_T_TEST_ACTIVE { get; set; }
        public string POSI_M_TEST_NAME { get; set; }
    }
}