using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(Student student,int groupId);
        void Edit(int id,Student student);
        void Delete(Student student);
        Student GetById(int id);
        List<Student> GetAll();
        List<Student> SearchByFullName(string FullName);
        List<Student> SortedByAge(string sortText);

    }
}
