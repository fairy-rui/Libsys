using Apstars;
using System;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 聚合根父类
    /// </summary>
    public partial class AggregateRootBase : IAggregateRoot
    {
        public Guid ID { get; set; }
    }
}
