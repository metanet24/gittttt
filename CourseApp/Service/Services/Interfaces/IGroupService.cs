using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group group);
        void Edit(int id,Group group);
        void Delete(Group group);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> SearchByName(string groupName);
        List<Group> SortedByCapacity(string sortText);


    }
}
