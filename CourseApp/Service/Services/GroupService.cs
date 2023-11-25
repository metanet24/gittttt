using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService()
        {
            _groupRepository=new GroupRepository();
        }

        public void Create(Group group)
        {
            _groupRepository.Create(group);
        }

        public void Delete(Group group)
        {
            _groupRepository.Delete(group);
        }

        public void Edit(Group group)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Group GetById(int id)
        {
            return _groupRepository.GetById(id);
        }

        public List<Group> SearchByName(string groupName)
        {
            return _groupRepository.SearchByName(groupName);
        }

        public List<Group> SortedByCapacity(string sortText)
        {
           return _groupRepository.SortedByCapacity(sortText);
        }
    }
}
