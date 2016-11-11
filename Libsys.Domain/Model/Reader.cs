using System;
using System.Collections.Generic;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 读者
    /// </summary>
    public partial class Reader : User
    {
        //public Guid ReaderTypeID { get; set; }
        public ReaderType ReaderType { get; set; }  //读者类型 
              
        public DateTime EffectiveDate { get; set; } //生效日期
        public DateTime ExpirationDate { get; set; }    //失效日期

        /// <summary>
        /// 借阅历史
        /// </summary>
        public virtual List<BorrowRecord> BorrowRecords { get; set; }
    }
}
