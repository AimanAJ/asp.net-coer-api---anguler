using AngularApp3.Server.Models;
using AngularApp3.Server.DTO;
using AngularApp3.Server.IDataService;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp3.Server.DataService
{
    public class DataServicee : IDataServicee
    {
        private readonly MyDbContext _db;
        public DataServicee (MyDbContext dbContext)
        {  _db = dbContext; }

        public List<User> getAllusers()
        {
            var user = _db.Users.ToList();
            return user;
        }


        public bool AddnewUser(AddUserDTO user)
        {
            if (user == null) return false;
            else
            {
                var myUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                };
                _db.Users.Add(myUser);
                _db.SaveChanges();
                return true;
            }
        }

        public User getSingleUser(int id)
        {
            var user = _db.Users.Find(id);
            //var user2 = _db.Users.FirstOrDefault(x => x.Id == id);
            //var user3 = _db.Users.SingleOrDefault(x => x.Id == id);
            //var user3 = _db.Users.LastOrDefault(x => x.Id == id);
            return user;
        }

        public User getUserByname(string name)
        {
            var user = _db.Users.FirstOrDefault(x => x.Name == name);
            return user;
        }


        public bool deleteUser(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null) return false;
            else
            {
                _db.Remove(user);
                _db.SaveChanges();
                return true;

            }
        }

        public bool  UpdateUser(int id, [FromBody] AddUserDTO newUser)
        {
            

            var user = _db.Users.Find(id);
            if (user == null) return false;
            else
            {
                user.Name = newUser.Name;
                user.Email = newUser.Email;
                _db.SaveChanges();
                return true;
            }
        }

    }
}
