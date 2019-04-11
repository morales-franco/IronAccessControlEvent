using IronAccessControlEvent.Common;
using IronAccessControlEvent.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IronAccessControlEvent.Services
{
    public class AccessControlService
    {
        /*
         * Alternative 1:
         * 
         * 1_ Define a delegate
         * 2_ Define an event based on  that delegate
         * 3_ Raise Event
         */
        internal delegate void RegisterSuccessEventHandler(string message);
        internal event RegisterSuccessEventHandler RegisterSuccess;

        /*
        * Alternative 2:
        * 
        * 2_ Define an event with generic delegate Action(Has parameter and Not return value) Func(Has or not parameter and return value)
        * 3_ Raise Event
        */
        internal event Action<string> RegisterError;

        public void RegisterUsers(IList<User> users)
        {
            foreach (var user in users)
            {
                if (user.IsAdult())
                {
                    user.SetStatus(eOperationStatus.RegisterSuccess);
                    if (RegisterSuccess != null)
                        RegisterSuccess($"User: { user.Name } - Age { user.Age } - Register Successfull");
                }
                else
                {
                    user.SetStatus(eOperationStatus.RegisterError);
                    if (RegisterError != null)
                        RegisterError($"User: { user.Name } - Age { user.Age } - Register Error");
                }
            }
        }


    }
}
