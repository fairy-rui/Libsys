using Libsys.Common;
using Libsys.Domain.Model;
using System.Data.Entity;

namespace Libsys.Domain.Repositories.EntityFramework
{
    public class LibsysDatabaseInitializationStrategy : DropCreateDatabaseIfModelChanges<LibsysContext>
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(LibsysContext context)
        {
            #region Roles

            var administratorRole = new Role
            {
                Name = "Administrator",
                Description = "System administrator role that has the permission of all operations."
            };
            context.Roles.Add(administratorRole);

            var accountManagerRole = new Role
            {
                Name = "Account Manager",
                Description =
                    "Account Managers have the permission to create/update/delete the user accounts in Libsys system."
            };
            context.Roles.Add(accountManagerRole);
            
            #endregion

            #region Privileges

            var createUserPrivilege = new Privilege
            {
                Name = Privileges.ApiCreateUser,
                Description = "The create user privilege."
            };
            context.Privileges.Add(createUserPrivilege);

            var updateUserPrivilege = new Privilege
            {
                Name = Privileges.ApiUpdateUser,
                Description = "The update user privilege."
            };
            context.Privileges.Add(updateUserPrivilege);
            
            #endregion

            #region Permissions

            var adminCreateUserPermission = new Permission
            {
                Privilege = createUserPrivilege,
                Role = administratorRole,
                Value = PermissionValue.Allow
            };
            context.Permissions.Add(adminCreateUserPermission);            

            var accountManagerCreateUserPermission = new Permission
            {
                Privilege = createUserPrivilege,
                Role = accountManagerRole,
                Value = PermissionValue.Allow
            };
            context.Permissions.Add(accountManagerCreateUserPermission);
            
            #endregion

            #region Users            

            #endregion

            base.Seed(context);
        }
    }
}
