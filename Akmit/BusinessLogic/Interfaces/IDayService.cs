using Akmit.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.BusinessLogic.Interfaces
{
    public interface IDayService
    {
        Task<bool> Add(string token, DayInformationBlo dayInformationBlo);
        Task<DayInformationBlo> Get(string token, string title);
        Task<List<DayInformationBlo>> GetAll(string token);
        Task<bool> Update(string token, string newTitle);
        Task<bool> Delete(string token, string title);
    }
}
