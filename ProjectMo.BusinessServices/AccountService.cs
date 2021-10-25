using ProjectMo.BusinessServices.Interfaces;
using ProjectMo.SQLDataAccess;
using ProjectMo.SQLDataAccess.Interfaces;
using ProjectMo.DataModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMo.BusinessServices
{
    public class AccountService: IAccountService
    {
        private readonly IAccountProcess accountProcess;
        public AccountService(IAccountProcess accountProcess)
        {
            this.accountProcess = accountProcess;
        }

        public AccountDetails GetAccountBalance(string UserName)
        {
            return accountProcess.GetAccountBalanceFromSQL(UserName);
            
        }

        public AccountDetails GetAccountBalance(string UserName, string PaymentDate)
        {
            return accountProcess.GetAccountBalanceFromSQL(UserName, PaymentDate);
        }
    }
}
