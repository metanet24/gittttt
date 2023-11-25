using Service.Helpers.Extensions;
using Service.Services.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Data;
using System.Xml.Linq;

namespace CourseApp.Controllers
{
    public class StudentController
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

        public StudentController()
        {
            _studentService = new StudentService();
            _groupService = new GroupService();
        }


        string message = string.Empty;

        public void Create()

        {
          
            ConsoleColor.Yellow.WriteConsole("Add GroupId:");
            Id: string IdStr = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(IdStr, out id);

            var res=_groupService.GetById(id);
           

            if (string.IsNullOrEmpty(IdStr))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Id;
            }

            if (res.Id == id)
            {
                
                goto Create;
            }
            else
            {
                goto Id;
            }
           



            Create: ConsoleColor.Yellow.WriteConsole("Add FullName:");
            FullName: string Fullname = Console.ReadLine();

            if (string.IsNullOrEmpty(Fullname))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto FullName;
            }
  


            ConsoleColor.Yellow.WriteConsole("Add Adrress:");
            Adress: string Adress = Console.ReadLine();

            if (string.IsNullOrEmpty(Adress))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Adress;
            }
            ConsoleColor.Yellow.WriteConsole("Add Phone:");
            Phone: string Phone = Console.ReadLine();

            if (string.IsNullOrEmpty(Phone))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Phone;
            }


          

             

            ConsoleColor.Yellow.WriteConsole("Add age:");

        Age: string AgeStr = Console.ReadLine();

            int age;
            bool isCorrectAge = int.TryParse(AgeStr, out age);

            if (isCorrectAge)
            {

                _studentService.Create(new Student { FullName = Fullname, Address = Adress, Age = age, Phone = Phone },id);
                ConsoleColor.Green.WriteConsole("Student create is succes");

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Age format is wrong,please try again");
                goto Age;
            }



        }

        public void GetAll()
        {
            var res = _studentService.GetAll();
            foreach (var item in res)
            {
                string result = $"{item.FullName}-{item.Age}-{item.Address}-{item.Phone}";

                ConsoleColor.Yellow.WriteConsole(result);
            }
        }

        public void Delete()
        {
            ConsoleColor.Blue.WriteConsole("Please add Id for deleting:");
            Id: string IdStr = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(IdStr, out id);

            if (isCorrectId)
            {
                var group = _studentService.GetById(id);
                _studentService.Delete(group);
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again:");
            }
        }

        public void GetById()
        {
            ConsoleColor.Blue.WriteConsole("Please add Id:");
            Id: string IdStr = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(IdStr, out id);
            if (isCorrectId)
            {
                var response = _studentService.GetById(id);
                Console.WriteLine($"{response.Id}-{response.FullName}-{response.Address}-{response.Age}-{response.Group}");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again:");
                goto Id;
            }


        }

        public void SearchFullName()
        {
            string FullName=Console.ReadLine();
            var students=_studentService.SearchByFullName(FullName);
            foreach ( var student in students )
      
            {
               
                    ConsoleColor.Yellow.WriteConsole(student.FullName + " " + student.Address + " " + student.Age + " " + student.Phone+" "+student.Group.Name);
                
            }
        }

        public void SortByAge()
        {
           
                ConsoleColor.Blue.WriteConsole("Please,add sort text");
                string sortText = Console.ReadLine();
                var res = _studentService.SortedByAge(sortText);

                foreach (var student in res)
                {
                    ConsoleColor.Blue.WriteConsole(student.FullName+" "+student.Group.Name+" "+student.Address+" "+student.Phone+" "+student.Age);
                }

            
        }


    }

}




