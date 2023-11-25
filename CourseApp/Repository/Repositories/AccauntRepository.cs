﻿using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccauntRepository : BaseRepository<User>, IAccauntRepository
    {   
        
        public void Register(User user)
        {
            AppDbContext<User>.Datas.Add(user);
        }
      
        public bool LogIn(string email, string password)
        {
            var res = AppDbContext<User>.Datas;
            foreach (var item in res)
            {
                if (item.Email == email && item.Password == password)
                {
                    return true;

                }
            }
            return false;
        }

       
    }
}
