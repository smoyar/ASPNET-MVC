using LearningCenter.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{
    public interface IUserRepository
    {
        UserModel LogIn(string userName, string userPassword);
        UserModel Register(string userName, string userPassword);
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
    class UserRepository: IUserRepository
    {
        public UserModel LogIn(string userName, string userPassword)
        {
            var user = DatabaseAccessor.Instance.Users
                .FirstOrDefault(t => t.UserName.ToLower() == userName.ToLower()
                && t.UserPassword == userPassword);
            if (user == null)
            {
                return null;
            }            
            return  new UserModel {UserName= user.UserName, UserPassword= user.UserPassword };
        }
        public UserModel Register(string userName, string userPassword)
        {
            var user = DatabaseAccessor.Instance.Users
                .Add(new LearningCenter.Database.User { UserName = userName, UserPassword = userPassword });
            DatabaseAccessor.Instance.SaveChanges();
            return new UserModel { UserName = user.UserName, UserPassword = user.UserPassword };
        }
    }
}
