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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;
        public StudentService()
        {
            _studentRepository=new StudentRepository();
            _groupRepository=new GroupRepository();
        }
        public void Create(Student student, int groupId)
        {
            var group=_groupRepository.GetById(groupId);

            student.Group = group;
            _studentRepository.Create(student);
       

        }
            

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public void Edit(int id,Student student)
        {
            _studentRepository.Edit(id, student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> SearchByFullName(string FullName)
        {
            return _studentRepository.SearchByFullName(FullName);
        }

        public List<Student> SortedByAge(string sortText)
        {
            return _studentRepository.SortedByAge(sortText);
        }
    }
}
