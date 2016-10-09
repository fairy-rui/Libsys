using System.Collections.Generic;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public partial class Role : AggregateRootBase
    {
        /// <summary>
        /// 角色名称。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色描述。
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 拥有该角色的用户
        /// </summary>
        public virtual List<User> Users { get; set; }
        /// <summary>
        /// 该角色所拥有的权限
        /// </summary>
        public virtual List<Permission> Permissions { get; set; }
    }
}
