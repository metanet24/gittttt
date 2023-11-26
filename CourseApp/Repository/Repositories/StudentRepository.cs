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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public void Edit(int id, Student student)
        {
            Student ExistStudent=AppDbContext<Student>.Datas.FirstOrDefault(x => x.Id == id);

            if (!string.IsNullOrWhiteSpace(student.FullName))
            {

              ExistStudent.FullName = student.FullName;

            }

            if (!string.IsNullOrWhiteSpace(student.Address))
            {

                ExistStudent.Address = student.Address;

            }

            if (!string.IsNullOrWhiteSpace(student.Phone))
            {

                ExistStudent.Phone = student.Phone;

            }
          
            if (student.Age != null) 
                ExistStudent.Age= student.Age;

            if(student.Group != null)
                ExistStudent.Group = student.Group;

        }

        public List<Student> SearchByFullName(string FullName)
        {
            return AppDbContext<Student>.Datas.Where(x => x.FullName.ToLower().Contains(FullName.ToLower())).ToList();
        }

        public List<Student> SortedByAge(string sortText)
        {

            if (sortText == "ascending")
            {
                return AppDbContext<Student>.Datas.OrderBy(x => x.Age).ToList();
            }
            else if (sortText == "descending")
            {
                return AppDbContext<Student>.Datas.OrderByDescending(x => x.Age).ToList();

            }

            return null;


        }


    }
}
