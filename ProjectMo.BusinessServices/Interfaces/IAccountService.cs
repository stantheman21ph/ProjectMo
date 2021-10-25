using ProjectMo.DataModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMo.BusinessServices.Interfaces
{
    public interface IAccountService
    {
        AccountDetails GetAccountBalance(string UserName);
        AccountDetails GetAccountBalance(string UserName, string PaymentDate);
    }
}
