using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Demo0215.Models
{   
    /// <summary>
    /// 員工物件
    /// </summary>
    [Serializable]
    public class EmployeeModels
    {
        /// <summary>
        /// 電腦編號
        /// </summary>
        [DisplayName("電腦編號")]
         public string EmpNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        public string Name { get; set; }
        /// <summary>
        /// 分機
        /// </summary>
        [DisplayName("分機")]
        public int Exp { get; set; }
}
        
    public class MessageInfo
    {/// <summary>
    /// 錯誤訊息
    /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 結果
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}