using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Data;
using System.Threading.Channels;
using System.Reflection.Metadata.Ecma335;

namespace CourseApp.Controllers
{
    public class GroupController
    {
        private readonly IGroupService _groupService;

        public GroupController()
        {
            _groupService = new GroupService();
        }

        string message=string.Empty;
        public void Create()
        {
            ConsoleColor.Yellow.WriteConsole("Add Name:");
            Name: string name=Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                ConsoleColor.DarkRed.WriteConsole(CommonMessages.RequiredMessages(message));
                goto Name;
            }
            foreach (var item in _groupService.GetAll())
            {
                if(item.Name == name)
                {
                    ConsoleColor.Red.WriteConsole("Such a group already exists,please try again");
                    goto Name;
                }
            }
            

            
            ConsoleColor.Yellow.WriteConsole("Add capacity of group:");

            Capacity: string capacityStr=Console.ReadLine();

            int capacity;
            bool isCorrectCount=int.TryParse(capacityStr, out capacity);

            if (isCorrectCount)
            {

                _groupService.Create(new Group { Name = name, Capacity=capacity });
                ConsoleColor.Green.WriteConsole("Group create is succes");

            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Format is wrong,please try again:");
                goto Capacity;
            }


        }

        public void GetAll()
        {
            var res=_groupService.GetAll();
            foreach (var item in res)
            {
                string result = $"{item.Name}-{item.Capacity}";

                ConsoleColor.Yellow.WriteConsole(result);
            }
        }

        public void Delete()
        {
            ConsoleColor.Blue.WriteConsole("Please add id for deleting:");
            Id: string IdStr = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(IdStr, out id);

            if (isCorrectId)
            {
                var group = _groupService.GetById(id);
                _groupService.Delete(group);
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again:");
            }
        }

        public void Edit()
        {

        }

        public void GetById()
        {
            ConsoleColor.Blue.WriteConsole("Please add id:");

            Id: string IdStr = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(IdStr, out id);
            if (isCorrectId)
            {
                var response = _groupService.GetById(id);
                Console.WriteLine($"{response.Id}-{response.Name}-{response.Capacity}");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again:");
                    goto Id;
            }
        }

        public void SearchByName()
        {
            string Name = Console.ReadLine();
            var groups = _groupService.SearchByName(Name);
            foreach (var group in groups)
            {

                ConsoleColor.Yellow.WriteConsole(group.Name + " "+group.Capacity);

            }
        }

        public void SortByCapacity()
        {
            ConsoleColor.Blue.WriteConsole("Please,add sort text");
            string sortText= Console.ReadLine();
            var res= _groupService.SortedByCapacity(sortText);

            foreach (var group in res)
            {
                ConsoleColor.Blue.WriteConsole(group.Name+" "+group.Capacity);
            }

        }


    }
}
