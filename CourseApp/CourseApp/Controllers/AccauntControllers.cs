using Domain.Models;
using Repository.Data;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.Collections.Generic;


namespace CourseApp.Controllers
{
    public class AccauntControllers
    {
        private readonly IAccaountService _accaountService;

        public AccauntControllers()
        {
            _accaountService=new AccauntService();
        }
        string message = string.Empty;
        public void Register()
        {
            ConsoleColor.DarkMagenta.WriteConsole("Please,add name:");
            Name: string name=Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Name;
            }else

            ConsoleColor.DarkMagenta.WriteConsole("Please,add surname:");
            Surname:string surname=Console.ReadLine();
            
            if (string.IsNullOrEmpty(surname))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Surname;
            }

            ConsoleColor.DarkMagenta.WriteConsole("Please,add age:");
        Age: string age = Console.ReadLine();

            AgeStart: int agetxt;

            bool IsTrue=int.TryParse(age, out agetxt);
            if(!IsTrue)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again");
                goto Age;
            }
            if(string.IsNullOrEmpty(age))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Age;
            }
            if (agetxt>18 && agetxt<65)
            {
                
            }
            else
            {
                ConsoleColor.Red.WriteConsole("The age limit of students is 18 - 65");
                goto Age;
            }

         

            

            ConsoleColor.DarkMagenta.WriteConsole("Please,add email:");
            Email:string email=Console.ReadLine();

            if (string.IsNullOrEmpty(email))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Email;
            }
            else if (!email.Contains("@"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again");
                goto Email;
            }

            ConsoleColor.DarkMagenta.WriteConsole("Please,add password:");
            Password:string password=Console.ReadLine();

            if (string.IsNullOrEmpty(password))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Password;
            }

            ConsoleColor.DarkMagenta.WriteConsole("Please,add confirm password:");
            string confirmPassword = Console.ReadLine();

           if(confirmPassword==password)
            {
                ConsoleColor.Green.WriteConsole(" Register is succesfull ");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Unsuccesfull register");
                goto Password;
            }
            User user = new User()
            {
                Age = agetxt,
                Name = name,
                Email = email,
                Password = password,

            };
            _accaountService.Register(user);
          
        }

        
        public void LogIn()

        { 
            Wrong: ConsoleColor.Cyan.WriteConsole("Please,add email:");
            Mail: string mail=Console.ReadLine();

            if (string.IsNullOrEmpty(mail))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Mail;
            }
            else if (!mail.Contains("@"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again");
                goto Mail;
            }



            ConsoleColor.Cyan.WriteConsole("Please,add password:");
            Pass:string pass =Console.ReadLine();

            if (string.IsNullOrEmpty(pass))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Pass;
            }

            var LoginRes=_accaountService.LogIn(mail, pass);


            if (LoginRes)
            {
                ConsoleColor.Green.WriteConsole("LogIn is successfull");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("User not Found");
                goto Wrong;
            }
        }
    }
}
