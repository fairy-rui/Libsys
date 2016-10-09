using System.Collections.Generic;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 权限
    /// </summary>
    public partial class Privilege : AggregateRootBase
    {        
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Permission> Roles { get; set; }
    }
}
