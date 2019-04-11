using IronAccessControlEvent.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IronAccessControlEvent.Repository
{
    public class UserRepository
    {
        public IList<User> GetAll()
        {
            IList<User> users = new List<User>();
            var ageGenerator = new Random();

            for (int i = 1; i <= 30; i++)
                users.Add(new User(i, $"User Test_{i}", ageGenerator.Next(1,99)));

            return users;
        }
    }
}
