using Demo0215.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo0215.Service
{
    public class EmployMethodes
    {
        /// <summary>
        /// 取得Default Employ Data
        /// </summary>
        /// <returns>員工物件</returns>
        public List<EmployeeModels> GetEmployeeData()
        {
            List<EmployeeModels> employeeModels = new List<EmployeeModels>();
            employeeModels.Add(new EmployeeModels() { EmpNo = "123", Name = "Claire", Exp = 456 });
            employeeModels.Add(new EmployeeModels() { EmpNo = "666", Name = "AAA", Exp = 777 });
            employeeModels.Add(new EmployeeModels() { EmpNo = "777", Name = "BBB", Exp = 000 });

            return employeeModels;
        } 
    }
}