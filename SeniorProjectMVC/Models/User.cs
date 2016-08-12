using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeniorProjectMVC.Models
{
    public class User
    {
        public User(string email, string pass, bool rem = true)
        {
            Email = email;
            Password = pass;
        }

        public User(int id, string firstname, string lastname, string email, string telephone, bool newsletter, string role, bool rem = true)
        {
            Customer_ID = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Telephone = telephone;
            Role = role;
            RememberMe = rem;
        }

        public int Customer_ID { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; }

        public string Telephone { get; }

        public bool Newsletter { get; }

        public string Role { get; }

        public bool RememberMe { get; }

        public static User IsValid(string email, string pass)
        {
            User u;
            MyRoleProvider mrp = new MyRoleProvider();

            using (Models.DataBass objContext = new Models.DataBass())
            {
                var objUser = objContext.Customers.FirstOrDefault(x => x.Email == email && x.PasswordHash == pass);
                if (objUser == null)
                {
                    u = null;
                }
                else
                {
                    string[] role = mrp.GetRolesForUser(email);
                    u = new User(objUser.Customer_ID, objUser.FirstName, objUser.LastName, objUser.Email, objUser.Telephone, objUser.Newsletter, role[0], false);
                }
            }

            return u;
        }
    }


}