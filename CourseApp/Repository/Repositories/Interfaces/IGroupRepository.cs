using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository:IBaseRepository<Group>
    {
        List<Group> SearchByName(string groupName);

        List<Group> SortedByCapacity(string sortText);

        void Edit(int id, Group group );

    }
}
