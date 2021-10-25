using ProjectMo.DataModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMo.SQLDataAccess.Interfaces
{
    public interface IAccountProcess
    {
        AccountDetails GetAccountBalanceFromSQL(string UserName);
        AccountDetails GetAccountBalanceFromSQL(string UserName, string PaymentDate);
    }
}
