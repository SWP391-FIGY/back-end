﻿using Application.Repositories;
using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class UserRepository : GenericRepository<User> ,IUserRepository
    {
        public UserRepository(AppDbContext context): base(context)
        {
        }
        
    }
}
