using System;
using System.Collections.Generic;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 图书
    /// </summary>
    public partial class Book
    {
        public string Name { get; set; }    //名称
        public string Description { get; set; } //描述信息
        public List<Author> Authors { get; set; }   //作者
        public DateTime? PublishDate { get; set; }  //出版日期  
        public Publisher Publisher { get; set; }    //出版社
        public string ISBN { get; set; }    //ISBN      
        public decimal UnitPrice { get; set; }  //价格
    }
}
