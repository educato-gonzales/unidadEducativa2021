using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IRudeService
    {
        IEnumerable<Rude> GetRudes();
        Task<Rude> GetRude(long Id);
        Task InsertRude(Rude rude);
        Task<bool> UpdateRude(Rude rude);
        Task<bool> DeleteRude(long Id);
    }
}
