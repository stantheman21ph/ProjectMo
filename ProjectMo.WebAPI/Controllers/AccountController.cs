using ProjectMo.BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Results;
using System.Web.Mvc;

namespace ProjectMo.WebAPI.Controllers
{
    public class AccountController : Controller
    {
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        private IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost, CorsHandleAttribute]
        public ActionResult GetAccountBalance(string UserName)
        {
            try
            {
                var temp =
                new JsonResult()
                {
                    Data = accountService.GetAccountBalance(UserName),
                    MaxJsonLength = 8675390,
                    ContentType = "GetAccountBalance",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return temp;
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = "Error Occured",
                    MaxJsonLength = 8675390,
                    ContentType = "GetAccountBalance",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [HttpPost, CorsHandleAttribute]
        public ActionResult GetAccountBalance(string UserName, string PaymentDate)
        {
            try
            {
                var temp =
                new JsonResult()
                {
                    Data = accountService.GetAccountBalance(UserName,PaymentDate),
                    MaxJsonLength = 8675390,
                    ContentType = "GetAccountBalance",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return temp;
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = "Error Occured with Date Filter",
                    MaxJsonLength = 8675390,
                    ContentType = "GetAccountBalance",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
    }
 }

