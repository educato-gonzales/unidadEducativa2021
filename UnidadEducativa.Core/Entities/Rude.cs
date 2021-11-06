using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.Entities
{
    public class Rude : BaseEntity
    {
        public long Id { get; set; }
        public string CodSieue { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Oficialia { get; set; }
        public long Libro { get; set; }
        public long Partida { get; set; }
        public long Folio { get; set; }
        public string Complemento { get; set; }
        public string Expedido { get; set; }
        public string CodRude { get; set; }
        public bool Sexo { get; set; }
        public bool Discapacidad { get; set; }
        public long? NumDiscapacidad { get; set; }
        public string TipoDiscapacidad { get; set; }
        public string GradoDiscapacidad { get; set; }
        public string DepartamentoEst { get; set; }
        public string ProvinciaEst { get; set; }
        public string SeccionEst { get; set; }
        public string LocalidadEst { get; set; }
        public string ZonaEst { get; set; }
        public string AvenidaEst { get; set; }
        public string NumViviendaEst { get; set; }
        public string IdiomaNiniez { get; set; }
        public string IdiomaFrecuente { get; set; }
        public string Nacion { get; set; }
        public bool CentroSalud { get; set; }
        public string ProblemaSalud { get; set; }
        public string FrecuenciaCs { get; set; }
        public bool SeguroCs { get; set; }
        public bool Agua { get; set; }
        public bool Banio { get; set; }
        public bool Alcantarillado { get; set; }
        public bool EnergiaElectrica { get; set; }
        public bool ServBasura { get; set; }
        public string Vivienda { get; set; }
        public string Internet { get; set; }
        public string FrecuenciaInternet { get; set; }
        public bool Trabajo { get; set; }
        public string MesesTrabajo { get; set; }
        public string ActividadTrabajo { get; set; }
        public string TurnoTrabajo { get; set; }
        public string FrecuenciaTrabajo { get; set; }
        public bool? PagoTrabajo { get; set; }
        public bool? TipoPago { get; set; }
        public string MedioTransporte { get; set; }
        public string TiempoTransporte { get; set; }
        public bool AbandonoUe { get; set; }
        public string RazonAbandono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string LugarRegistro { get; set; }
        public long? IdRepresentantePadre { get; set; }
        public long? IdRepresentanteMadre { get; set; }
        public long? IdRepresentanteTutor { get; set; }
        public long IdEstudiante { get; set; }
        public long EstadoSql { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Representante IdRepresentanteMadreNavigation { get; set; }
        public virtual Representante IdRepresentantePadreNavigation { get; set; }
        public virtual Representante IdRepresentanteTutorNavigation { get; set; }
    }
}
