using System.Collections.Generic;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 书籍作者
    /// </summary>
    public partial class Author : AggregateRootBase
    {
        public string Name { get; set; }    //姓名
        public string Description { get; set; }     //描述信息
        public string Email { get; set; }   //邮箱

        public virtual List<Book> Books { get; set; }   //书籍
    }
}
