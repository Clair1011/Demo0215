using Demo0215.Models;
using Demo0215.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Demo0215.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public PartialViewResult EmpData(string EmpNo = "")
        {
            List<EmployeeModels> empList = new List<EmployeeModels>();
            if (Session["EmpData"] == null)
            {
                EmployMethodes employMethodes = new EmployMethodes();
                empList = employMethodes.GetEmployeeData();
                Session["EmpData"] = empList;
            }
            else
            {
                empList = Session["EmpData"] as List<EmployeeModels>;
                //empList = (List<EmployeeModels>)Session["EmpData"];
            }

            if (string.IsNullOrEmpty(EmpNo))
            {
                return PartialView(empList);

            }
            var result = new List<EmployeeModels>();
            foreach (var emp in empList)
            {
                if (emp.EmpNo == EmpNo)
                {
                    result.Add(emp);
                }
            }

            return PartialView(result);
        }
        // 練習 Session / ViewBag / ViewData / TempData
        public ActionResult About()

        {
            ViewBag.Message = "Your application description page.";

            Session["D1"] = "hello session";
            ViewBag.D1 = "hello bag";
            ViewData["D1"] = "hello data";
            TempData["D1"] = "hello temp";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";



            return View();
        }
        // Edit 編輯功能
        public ActionResult Edit(string EmpNo)
        {
            MessageInfo messageInfo = new MessageInfo();
            if (Session["EmpData"] == null)
            {
                return View(new EmployeeModels());
            }

            EmployeeModels result =
                ((List<EmployeeModels>)Session["EmpData"]).Where(x => x.EmpNo == EmpNo).FirstOrDefault();

            return View(result);

        }
        //Create 新增功能
        public ActionResult Create() 
        {
            
            return View();

        }

        // 編輯的Post
        [HttpPost]
        public JsonResult EditPost(EmployeeModels EmpData)
        {

            MessageInfo messageInfo = new MessageInfo() { IsSuccess = true, Msg = "" };
            // todo 檢核資料
            if (Session["EmpData"] == null)
            {
                messageInfo.IsSuccess = false;
                messageInfo.Msg = "No Data.";
                return Json(messageInfo);
            }

            List<EmployeeModels> result = (List<EmployeeModels>)Session["EmpData"];

            if (result.Where(x => x.EmpNo == EmpData.EmpNo).Count() == 0)
            {
                messageInfo.IsSuccess = false;
                messageInfo.Msg = "No Data.";
                return Json(messageInfo);

            }
            var emp = result.Where(x => x.EmpNo == EmpData.EmpNo).FirstOrDefault();
            emp.Name = EmpData.Name;
            emp.Exp = EmpData.Exp;
            Session["EmpData"] = result;
            return Json(messageInfo);
        }

        // 刪除的post
        [HttpPost]
        public JsonResult DeletePost(string EmpNo)
        {
            MessageInfo messageInfo = new MessageInfo() { IsSuccess = true, Msg = "" };

            if (Session["EmpData"] == null)
            {
                messageInfo.IsSuccess = false;
                messageInfo.Msg = "查無資料";
                return Json(messageInfo);
            }
            List<EmployeeModels> result = (List<EmployeeModels>)Session["EmpData"];

            if (result.Where(x => x.EmpNo == EmpNo).Count() == 0)
            {
                messageInfo.IsSuccess = false;
                messageInfo.Msg = "No Data.";
                return Json(messageInfo);
            }
            result.Remove(result.Where(x => x.EmpNo == EmpNo).FirstOrDefault());
            Session["EmpData"] = result;
            return Json(messageInfo);
        }

        /// <summary>
        /// CreatePost 新增的post
        /// </summary>
        /// <param name="EmpNo"></param>
        /// <param name="Name"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreatePost(EmployeeModels employee)
        {
            try {
                MessageInfo messageInfo = new MessageInfo() { IsSuccess = true, Msg = "" };
                // todo 檢核資料
                if (Session["EmpData"] == null)
                {
                    
                    //messageInfo.IsSuccess = false;
                    //messageInfo.Msg = "查無資料";
                    return Json(messageInfo);
                }


                List<EmployeeModels> result = (List<EmployeeModels>)Session["EmpData"];

                result.Add(employee);

                return Json(messageInfo);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}