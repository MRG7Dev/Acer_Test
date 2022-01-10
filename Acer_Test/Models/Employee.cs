using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acer_Test.Models
{
    public class Employee
    {
        public string Emp_Id { get; set; }
        [Required]
        public string NAME { get; set; }

        [Required]

        public string MOBILE_NO { get; set; }
        [Required]

        public string EMAIL_ID { get; set; }
        [Required]

        public string DOB { get; set; }
        [Required]

        public string PAN { get; set; }

        public string state { get; set; }


        public string CITY { get; set; }

   
    }
}
//(NAME,MOBILE_NO,EMAIL_ID,DOB,PAN,CITY