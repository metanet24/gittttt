using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntitiy
    {
        void Create (T entity);
        void Edit (T entity);
        void Delete (T entity);
        T GetById (int id);
        List<T> GetAll();

    }
}
