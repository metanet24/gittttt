using Domain.Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IAccauntRepository:IBaseRepository<User>
    {
        void Register (User user);
        bool LogIn(string email, string password);
       
    }
}
