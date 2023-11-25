using Domain.Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Services.Interfaces
{
    public interface IAccaountService
    {
        void Register(User user);
        bool LogIn(string email, string password);

    }
}
