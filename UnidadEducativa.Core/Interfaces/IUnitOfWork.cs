using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //object RolRepository { get; }
        IRepository<Asistencia> AsistenciaRepository { get; }
        IRepository<Autoevaluacion> AutoevaluacionRepository { get; }
        IRepository<Calendario> CalendarioRepository { get; }
        IRepository<Curso> CursoRepository { get; }
        IRepository<Categoria> CategoriaRepository { get; }
        IRepository<Estudiante> EstudianteRepository { get; }
        IRepository<EstudianteMateria> EstudianteMateriaRepository { get; }
        IRepository<EvaluacionProfesor> EvaluacionProfesorRepository { get; }
        IRepository<Fotos> FotosRepository { get; }
        IRepository<Horario> HorarioRepository { get; }
        IRepository<Institucion> InstitucionRepository { get; }
        IRepository<Materia> MateriaRepository { get; }
        IRepository<MateriaDictada> MateriaDictadaRepository { get; }
        IRepository<Nota> NotaRepository { get; }
        IRepository<Notificacion> NotificacionRepository { get; }
        IRepository<Paralelo> ParaleloRepository { get; }
        IRepository<Parametro> ParametroRepository { get; }
        IRepository<Periodo> PeriodoRepository { get; }
        IRepository<Profesor> ProfesorRepository { get; }
        IRepository<Representante> RepresentanteRepository { get; }
        IRepository<Rol> RolRepository { get; }
        IRepository<Rude> RudeRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }
        IRepository<Calificacion> CalificacionRepository { get; }
        IRepository<Administrador> AdministradorRepository { get; }
        IRepository<EstudianteCurso> EstudianteCursoRepository { get; }
        IRepository<Notas> NotasRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
