using System.Collections.Generic;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 图书类别
    /// </summary>
    public partial class Category : AggregateRootBase
    {       
        public string Name { get; set; }    //分类的名称        
        public string Description { get; set; }     //分类的描述信息

        public virtual List<Book> Books { get; set; }   //该分类下的所有书籍
    }
}
