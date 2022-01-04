using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientWeb.Models;

namespace ClientWeb.Controllers
{
    public class CalculateController : Controller
    {
        // GET: Calculate
        public JsonResult Multiplikation(MultiplikationModel obj)
        {
            if (obj != null) obj.Mult();
            else obj = new MultiplikationModel();

            List<MultiplikationModel> objList = new List<MultiplikationModel>();
            objList.Add(obj);

            return Json(objList, JsonRequestBehavior.AllowGet); ;
        }
    }
}