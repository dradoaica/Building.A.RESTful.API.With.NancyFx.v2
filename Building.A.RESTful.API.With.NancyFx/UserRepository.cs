using System;
using System.Collections.Generic;
using System.Linq;

namespace Building.A.RESTful.API.With.NancyFx
{
    public class UserRepository
    {
        private static UserRepository _instance;
        private readonly Dictionary<string, User> _repo;
        public static UserRepository Instance => _instance ?? (_instance = new UserRepository());

        private UserRepository()
        {
            _repo = new Dictionary<string, User>();
        }

        public User[] GetAll()
        {
            return _repo.Values.ToArray();
        }

        public User Get(string userName)
        {
            if (!_repo.ContainsKey(userName))
            {
                throw new ApplicationException(string.Format("User with name '{0}' doesnot exist", userName));
            }

            return _repo[userName];
        }

        public void Add(User user)
        {
            if (_repo.ContainsKey(user.UserName))
            {
                throw new ApplicationException(string.Format("User with name '{0}' already exists", user.UserName));
            }

            _repo.Add(user.UserName, user);
        }

        public void Modify(User user)
        {
            if (!_repo.ContainsKey(user.UserName))
            {
                throw new ApplicationException(string.Format("User with name '{0}' doesnot exist", user.UserName));
            }

            _repo[user.UserName] = user;
        }

        public void Delete(User user)
        {
            if (!_repo.ContainsKey(user.UserName))
            {
                throw new ApplicationException(string.Format("User with name '{0}' doesnot exist", user.UserName));
            }

            _repo.Remove(user.UserName);
        }
    }
}
