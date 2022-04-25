using Akmit.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface IClassService
    {
        Task<ClassInformationBlo> Create(string token, ClassInformationBlo classInformationBlo); 
        Task<bool> Join(string token, ClassInformationBlo classInformationBlo);
        Task<bool> Leave(string token);
        Task<int> RefreshCode(string token);
    }
}
