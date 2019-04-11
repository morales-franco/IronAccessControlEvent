using IronAccessControlEvent.Entities;
using IronAccessControlEvent.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IronAccessControlEvent.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }    

        public IList<User> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
