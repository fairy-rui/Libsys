using Apstars;
using System;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 借阅记录
    /// </summary>
    public partial class BorrowRecord : IEntity
    {
        public Guid ID { get; set; }
        
        //public Guid BookID { get; set; } //图书ID
        public virtual Book Book { get; set; }  //图书
        //public Guid ReaderID { get; set; }  //读者ID
        public virtual Reader Reader { get; set; }  //读者

        public DateTime BorrowDate { get; set; }    //借出日期
        public DateTime DueDate { get; set; }   //应还日期
        public BorrowStatus Status { get; set; }    //借阅状态
        public DateTime? ReturnDate { get; set; }   //归还日期
    }
}
