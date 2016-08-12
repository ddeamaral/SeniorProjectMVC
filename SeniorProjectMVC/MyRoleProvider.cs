using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SeniorProjectMVC.Models;

namespace SeniorProjectMVC
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //using the db to get the context
            using (Models.DataBass objContext = new Models.DataBass())
            {
                var objUser = objContext.Customers.FirstOrDefault(x => x.Email == username);
                if (objUser == null)
                {
                    return null;
                }
                else
                {
                    //getting the customer's role
                    int[] ret = objUser.XREF_CustomerRole.Select(x => x.Role_ID).ToArray();
                    var role_properties = objContext.Roles.Select(x => new {x.Name, x.Role_ID}).Where(a => a.Role_ID.Equals(ret[0]));
                    string[] role = role_properties.Select(x => x.Name).ToArray();
                    return role;
                }
            }

            //throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            //using (Models.DataBass db = new Models.DataBass())
            //{
            //    Customer user = db.Customers.FirstOrDefault(u => u.Email.Equals(username, StringComparison.CurrentCultureIgnoreCase) || u.Email.Equals(username, StringComparison.CurrentCultureIgnoreCase));

            //    var roles = from ur in user.UserRoles
            //                from r in db.Roles
            //                where ur.RoleId == r.Id
            //                select r.Name;
            //    if (user != null)
            //        return roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            //    else
            //        return false;
            //}

            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}