using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface INotificacionService
    {
        IEnumerable<Notificacion> GetNotificaciones();
        Task<Notificacion> GetNotificacion(long Id);
        Task InsertNotificacion(Notificacion notificacion);
        Task<bool> UpdateNotificacion(Notificacion notificacion);
        Task<bool> DeleteNotificacion(long Id);
    }
}
