using System;
using System.Collections.Generic;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 图书
    /// </summary>
    public partial class Book : AggregateRootBase
    {        
        public string Name { get; set; }    //名称
        public string Description { get; set; } //描述信息       
        public DateTime? PublishDate { get; set; }  //出版日期  
        public Publisher Publisher { get; set; }    //出版社
        public string ISBN { get; set; }    //ISBN      
        public decimal UnitPrice { get; set; }  //价格

        public virtual List<Author> Authors { get; set; }   //作者
        public virtual List<Category> Categorization { get; set; }  //分类
        /// <summary>
        /// 借阅历史
        /// </summary>
        public virtual List<BorrowRecord> BorrowRecords { get; set; }   
    }
}
