using System;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 权限列表
    /// </summary>
    public partial class Permission : AggregateRootBase
    {
        //public Guid RoleID { get; set; }        //根据EF一对多关系的约定，可以不写
        public virtual Role Role { get; set; }
        //public Guid PrivilegeID { get; set; }   //根据EF一对多关系的约定，可以不写
        public virtual Privilege Privilege { get; set; }
        public PermissionValue Value { get; set; }
    }

    public enum PermissionValue
    {
        Allow,
        Deny,
    }
}
