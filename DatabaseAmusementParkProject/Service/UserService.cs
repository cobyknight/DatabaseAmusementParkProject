using Microsoft.AspNetCore.Mvc;
using DatabaseAmusementParkProject.Data;

namespace DatabaseAmusementParkProject.Service
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public bool UserLogin(string username, string password)
        {
            var userLoginInfo = _context.Users.Where(u =>  u.UserName == username).FirstOrDefault();

            if (username == userLoginInfo.UserName && password == userLoginInfo.Password)
            {
                return true;
            }
            else {
                return false;
            }
        }


    }
}
