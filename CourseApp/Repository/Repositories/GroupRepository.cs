using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public void Edit(int id, Group group)
        {
            
            Group ExistGroup = AppDbContext<Group>.Datas.FirstOrDefault(x => x.Id == id);

            if (!string.IsNullOrWhiteSpace(group.Name))
            {
              
                 ExistGroup.Name = group.Name;

            }

            if (group.Capacity != null)
            ExistGroup.Capacity = group.Capacity;
                
            
        }

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
