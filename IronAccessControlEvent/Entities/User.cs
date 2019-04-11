using IronAccessControlEvent.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IronAccessControlEvent.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public eOperationStatus Status { get; private set; }

        public User(int id, string name, int age)
        {
            UserId = id;
            Name = name;
            Age = age;
            Status = eOperationStatus.None;
        }

        public void SetStatus(eOperationStatus status)
        {
            Status = status;
        }

        public bool IsAdult()
        {
            return Age >= 18;
        }

    }
}
