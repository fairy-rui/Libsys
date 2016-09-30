using System;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 图书馆工作人员
    /// </summary>
    public partial class Staff : User
    {
        public DateTime EntryDate { get; set; } //入职日期
    }
}
