using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreBase.Models
{
    public class Services
    {
        // Insert User
        public void Insert(Manager newManager)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                if (newManager.Password != null)
                {
                    newManager.Password = HasService.ComputeSHA256(newManager.Password);
                }
                dbContext.Users.Add(newManager);
                dbContext.SaveChanges();
            }
        }

        // List Users
        public List<Manager> ListUsers()
        {
            using (var context = new DataBaseContext())
            {
                return context.Users.ToList<Manager>();
            }
        }

        // Login and Validation
        public bool ValidateUsers(string Username, string Password)
        {
            using (var validate = new DataBaseContext())
            {
                // Checking Passaword
                string CriptoPassword = HasService.ComputeSHA256(Password);

                // Checking Username
                bool UserExists = validate.Users.Any(user => user.Username == Username && user.Password == CriptoPassword);

                return UserExists;
            }
        }

        // Edit Profile
        public void EditProfile(Manager editUser)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                Manager? manager = dbContext.Users.FirstOrDefault(user => user.Id == editUser.Id);

                if (manager != null)
                {
                    manager.Username = editUser.Username;

                    if (!string.IsNullOrEmpty(editUser.Password))
                    {
                        manager.Password = HasService.ComputeSHA256(editUser.Password);
                    }

                    dbContext.SaveChanges();
                }
            }
        }

        // Find Id
        public Manager? FindForId(int Id)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                return dbContext.Users.Find(Id);
            }
        }
        public Manager? GetPostDetail(int Id)
        {
            using (var context = new DataBaseContext())
            {
                Manager? register = context.Users.Where(r => r.Id == Id).SingleOrDefault();

                return register;
            }
        }
    }
}
