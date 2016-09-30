using System;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 读者
    /// </summary>
    public partial class Reader : User
    {
        public ReaderType ReaderType { get; set; }  //读者类型       
        public DateTime EffectiveDate { get; set; } //生效日期
        public DateTime ExpirationDate { get; set; }    //失效日期
    }
}
