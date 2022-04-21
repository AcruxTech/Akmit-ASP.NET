using Akmit.BusinessLogic.Interfaces;
using Akmit.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Services
{
    public class ClassService : IClassService
    {
        public Task<bool> Create(string token, ClassIdentityBlo classIdentityBlo)
        {
            //new Random().Next(100, 1000);
            throw new NotImplementedException();
        }

        public Task<bool> Join(string token, ClassIdentityBlo classIdentityBlo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Leave(string token)
        {
            throw new NotImplementedException();
        }

        public Task<int> RefreshCode(string token)
        {
            throw new NotImplementedException();
        }
    }
}
