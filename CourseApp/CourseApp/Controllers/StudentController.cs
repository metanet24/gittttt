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
using System.Numerics;
using System.Net;

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

            if (isCorrectId)
            {
                var res = _groupService.GetById(id);
                if (res == null)
                {
                    Console.WriteLine("There is no such ID group,please try again");
                    goto Id;
                }

                if (string.IsNullOrEmpty(IdStr))
                {
                    ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                    goto Id;
                }

                if (res.Id == id)
                {

                    goto Create;
                }

               
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again");
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
                if (age > 18 && age <65)
                {
                _studentService.Create(new Student { FullName = Fullname, Address = Adress, Age = age, Phone = Phone },id);
                ConsoleColor.Green.WriteConsole("Student create is succes");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("The age limit of students is 18-65.");
                    goto Age;
                }
               

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
            ConsoleColor.Blue.WriteConsole("Please write FullName for searching:");
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
                ConsoleColor.Blue.WriteConsole(student.FullName);
            }




        }


        public void StudentEdit()
        {
            ConsoleColor.Blue.WriteConsole("Please add Id for editing:");
            Id: string IdStr = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(IdStr, out id);

            if (isCorrectId)
            {
                var group = _studentService.GetById(id);

                ConsoleColor.Magenta.WriteConsole("Please,add Fullname");
                string Fullname=Console.ReadLine();

                ConsoleColor.Magenta.WriteConsole("Please,add adress");
                string adress = Console.ReadLine();

                ConsoleColor.Magenta.WriteConsole("Please,add phone");
                string phone = Console.ReadLine();

                ConsoleColor.Magenta.WriteConsole("Please,add GroupId");
                Age: string AgeStr = Console.ReadLine();
                int age;
                bool isCorrectAge = int.TryParse(AgeStr, out age);
                if (!isCorrectAge)
                {
                    ConsoleColor.Red.WriteConsole("Format is wrong,please try again:");
                    goto Age;
                }

                ConsoleColor.Magenta.WriteConsole("Please,add Group Id ");
               
                GroupId: string Idstr = Console.ReadLine();
                
                int groupId;
                bool isCorrectGroupId = int.TryParse(Idstr, out groupId);
                if (!isCorrectAge)
                {
                    ConsoleColor.Red.WriteConsole("Format is wrong,please try again:");
                    goto Age;
                }
                else
                {
                     var response = _groupService.GetById(groupId);
                }

                _studentService.Edit(id, new Student { FullName = Fullname, Address = adress, Age = age, Phone = phone });
                
                ConsoleColor.Green.WriteConsole("Student edit is succes");



            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again:");
            }
        }

    }

}




