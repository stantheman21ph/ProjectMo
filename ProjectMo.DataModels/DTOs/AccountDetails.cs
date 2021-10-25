using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMo.DataModels.DTOs
{
    public class AccountDetails
        {
            public string UserName { get; set; }
            public string AccountNumber { get; set; }

            public List<PaymentList> Payments { get; set; }
        }

        public class PaymentList
        {
            public string PaymentDate { get; set; }
            public decimal Amount { get; set; }
            public decimal Balance { get; set; }
            public string DueDate { get; set; }
        }   
}
