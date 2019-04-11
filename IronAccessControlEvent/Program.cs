using IronAccessControlEvent.Common;
using IronAccessControlEvent.Repository;
using IronAccessControlEvent.Services;
using System;
using System.Linq;

namespace IronAccessControlEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService(new UserRepository());
            var accessControlService = new AccessControlService();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello to Iron Access Control App");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("AccessControl only accepts adult users [Upper 18 years]");
            Console.ForegroundColor = ConsoleColor.Green;
           
            var users = userService.GetAll();
            Console.WriteLine($"Process Start - Total Users: { users.Count }");

            accessControlService.RegisterError += AccessControlService_RegisterError;
            accessControlService.RegisterSuccess += AccessControlService_RegisterSuccess;

            accessControlService.RegisterUsers(users);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Process Results:");
            Console.WriteLine($"Registered Users: { users.Where(u=> u.Status == eOperationStatus.RegisterSuccess).Count()  }");
            Console.WriteLine($"Unregistered Users : { users.Where(u => u.Status == eOperationStatus.RegisterError).Count() }");

            Console.WriteLine("Process End");
            Console.Read();
        }

        private static void AccessControlService_RegisterSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"OnRegisterSuccess: { message }");
        }

        private static void AccessControlService_RegisterError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"OnRegisterError: { message }");
        }
    }
}
