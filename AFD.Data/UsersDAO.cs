using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AFD.Model;

namespace AFD.Data.EntityFramework
{
    public class UsersDao
    {
        public List<User> GetAllUsers()
        {
            try
            {
                using (var context = new JsonContext())
                {
                    return context.ObjUser.ToList();
                }
            }
            catch (Exception ex)
            {
                //Log error
                return null;
            }
            
        }

        public User CreateUser(User newUser)
        {
            try
            {
                using (var context = new JsonContext())
                {
                    context.ObjUser.Add(newUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //Log error
                newUser = null;                
            }

            return newUser;
        }

        public void UpdateUser(User editedUser)
        {
            try
            {
                using (var context = new JsonContext())
                {
                    context.ObjUser.AddOrUpdate(editedUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //Log error
            }
        }

        public User FindUser(int id)
        {
            try
            {
                using (var context = new JsonContext())
                {
                    return context.ObjUser.Find(id);
                }
            }
            catch (Exception ex)
            {
                //Log error
                return null;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                using (var context = new JsonContext())
                {
                    var user = context.ObjUser.Find(id);         //fetching the user with Id 
                    if (user != null)
                    {
                        context.ObjUser.Remove(user);              //deleting from db
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                //Log error
            }
        }
    }
}
