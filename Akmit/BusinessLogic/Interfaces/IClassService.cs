using Akmit.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface IClassService
    {
        Task<bool> Create(string token, ClassIdentityBlo classIdentityBlo); 
        Task<bool> Join(string token, ClassIdentityBlo classIdentityBlo);
        Task<bool> Leave(string token);
        Task<int> RefreshCode(string token);
        private int GenerateCode(string token) => new Random().Next(100, 1000);
    }
}
