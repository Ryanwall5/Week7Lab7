using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lab6_RyanWall_WebDesign.Models;


namespace Lab6_RyanWall_WebDesign.Data
{
    
    public class EfRepository : IRepository
    {
        private readonly UserContext _usercontext = new UserContext();
       
        public List<User> GetAllUsers()
        {
            return _usercontext.Users.ToList();
        }

        public void AddUser(User user)
        {
            foreach(var pet in user.Pets)
            {
                _usercontext.Users.Attach(user);
            }

            _usercontext.Users.Add(user);
            _usercontext.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _usercontext.Users.Find(id);
        }

        public void UpdateUser(User user)
        {
            _usercontext.Entry(user).State = EntityState.Modified;
            _usercontext.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _usercontext.Users.Remove(user);
            _usercontext.SaveChanges();
        }

        public List<Pet> GetAllPets()
        {
            return _usercontext.Pets.ToList();
        }
    }
}