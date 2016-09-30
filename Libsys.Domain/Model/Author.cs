namespace Libsys.Domain.Model
{
    /// <summary>
    /// 书籍作者-值对象
    /// </summary>
    public partial class Author
    {
        public string Name { get; set; }    //姓名
        public string Description { get; set; }     //描述信息
        public string Email { get; set; }   //邮箱
    }
}
