using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IMateriaDictadaService
    {
        IEnumerable<MateriaDictada> GetMateriaDictadas();
        Task<MateriaDictada> GetMateriaDictada(long Id);
        Task InsertMateriaDictada(MateriaDictada materiaDictada);
        Task<bool> UpdateMateriaDictada(MateriaDictada materiaDictada);
        Task<bool> DeleteMateriaDictada(long Id);
    }
}
