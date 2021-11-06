using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IParametroService
    {
        IEnumerable<Parametro> GetParametros();
        Task<Parametro> GetParametro(long Id);
        Task InsertParametro(Parametro parametro);
        Task<bool> UpdateParametro(Parametro parametro);
        Task<bool> DeleteParametro(long Id);
    }
}
