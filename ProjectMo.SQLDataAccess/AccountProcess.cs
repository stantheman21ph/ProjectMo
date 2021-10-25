using ProjectMo.SQLDataAccess.Interfaces;
using ProjectMo.DataModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMo.SQLDataAccess
{
    public class AccountProcess: IAccountProcess
    {
        public AccountDetails GetAccountBalanceFromSQL(string UserName)
        {
            AccountDetails myAccount = new AccountDetails();
            List<PaymentList> myPayments = new List<PaymentList>();

            using (var context = new ProjectMDatabaseEntities())
            {
                myAccount.UserName = UserName;
                //myAccount = context.Accounts.FirstOrDefault(x => x.UserName == UserName)
                var myAccountId = context.Accounts.FirstOrDefault(x => x.UserName == UserName).AccountId;
                var myPaymentList = (from p in context.Payments
                                     join b in context.Balances on p.PaymentId equals b.PaymentId
                                     where p.AccountId == myAccountId
                                     select new PaymentList
                                     {
                                        PaymentDate = p.PaymentDate.ToString(),
                                        Amount = p.Amount ?? 0,
                                        Balance = b.BalanceAmount ?? 0,
                                        DueDate = b.BalanceDueDate.ToString()
                                     }).Distinct().ToList().OrderBy(x => x.PaymentDate);
                myPayments.AddRange(myPaymentList);
             }

            myAccount.Payments = myPayments;
            return myAccount;
        }
        public AccountDetails GetAccountBalanceFromSQL(string UserName, string PaymentDate)
        {
            AccountDetails myAccount = new AccountDetails();
            List<PaymentList> myPayments = new List<PaymentList>();

            DateTime PaymentDateConverted = DateTime.Parse(PaymentDate);
            using (var context = new ProjectMDatabaseEntities())
            {
                myAccount.UserName = UserName;
                //myAccount = context.Accounts.FirstOrDefault(x => x.UserName == UserName)
                var myAccountId = context.Accounts.FirstOrDefault(x => x.UserName == UserName).AccountId;
                var myPaymentList = (from p in context.Payments
                                     join b in context.Balances on p.PaymentId equals b.PaymentId
                                     where p.AccountId == myAccountId && p.PaymentDate >= PaymentDateConverted
                                     select new PaymentList
                                     {
                                         PaymentDate = p.PaymentDate.ToString(),
                                         Amount = p.Amount ?? 0,
                                         Balance = b.BalanceAmount ?? 0,
                                         DueDate = b.BalanceDueDate.ToString()
                                     }).Distinct().ToList().OrderBy(x => x.PaymentDate);
                myPayments.AddRange(myPaymentList);
            }

            myAccount.Payments = myPayments;
            return myAccount;
        }
    }
}
