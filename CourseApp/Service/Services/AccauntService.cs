using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccauntService : IAccaountService
    {
        private readonly IAccauntRepository _accauntRepository;

        public AccauntService()
        {
            _accauntRepository = new AccauntRepository();
        }
        public void Register(User user)
        {
             _accauntRepository.Register(user);
        }
       
        public bool LogIn(string email, string password)
        {
           return _accauntRepository.LogIn(email, password);
        }

       
    }
}
