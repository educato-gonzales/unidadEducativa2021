using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IParaleloService
    {
        IEnumerable<Paralelo> GetParalelos();
        Task<Paralelo> GetParalelo(long Id);
        Task InsertParalelo(Paralelo paralelo);
        Task<bool> UpdateParalelo(Paralelo paralelo);
        Task<bool> DeleteParalelo(long Id);
    }
}

