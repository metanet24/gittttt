using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
       

        public List<Group> SearchByName(string groupName)
        {
            return AppDbContext<Group>.Datas.Where(x => x.Name.ToLower().Contains(groupName.ToLower())).ToList();
            
        }

        public List<Group> SortedByCapacity(string sortText)
        {
            if (sortText == "ascending")
            {
                return AppDbContext<Group>.Datas.OrderBy(x => x.Capacity).ToList();
            }
            else if(sortText == "descending")
            {
                return AppDbContext<Group>.Datas.OrderByDescending(x => x.Capacity).ToList();

            }

            return null;






        }
    }
}
