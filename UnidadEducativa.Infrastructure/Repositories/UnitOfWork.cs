using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;
using UnidadEducativa.Infrastructure.Data;

namespace UnidadEducativa.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Rol> _rolRepository;
        private readonly IRepository<Parametro> _parametroRepository;
        private readonly IRepository<Paralelo> _paraleloRepository;
        private readonly IRepository<Categoria> _categoriaRepository;
        private readonly IRepository<Periodo> _periodoRepository;
        private readonly IRepository<Asistencia> _asistenciaRepository;
        private readonly IRepository<Autoevaluacion> _autoevaluacionRepository;
        private readonly IRepository<Calendario> _calendarioRepository;
        private readonly IRepository<Curso> _cursoRepository;
        private readonly IRepository<Estudiante> _estudianteRepository;
        private readonly IRepository<EstudianteMateria> _estudianteMateriaRepository;
        private readonly IRepository<EvaluacionProfesor> _evaluacionProfesorRepository;
        private readonly IRepository<Fotos> _fotosRepository;
        private readonly IRepository<Horario> _horarioRepository;
        private readonly IRepository<Institucion> _institucionRepository;
        private readonly IRepository<Materia> _materiaRepository;
        private readonly IRepository<MateriaDictada> _materiaDictadaRepository;
        private readonly IRepository<Nota> _notaRepository;
        private readonly IRepository<Notificacion> _notificacionRepository;
        private readonly IRepository<Profesor> _profesorRepository;
        private readonly IRepository<Representante> _representanteRepository;
        private readonly IRepository<Rude> _rudeRepository;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<Calificacion> _calificacionRepository;
        private readonly IRepository<Administrador> _administradorRepository;
        private readonly IRepository<EstudianteCurso> _estudianteCursoRepository;
        private readonly IRepository<Notas> _notasRepository;

        private readonly colegioContext _context;
        public UnitOfWork(colegioContext context)
        {
            _context = context;
        }

        public IRepository<Rol> RolRepository
        {
            get
            {
                if (_rolRepository == null)
                    _rolRepository = new BaseRepository<Rol>(_context);
                return _rolRepository;
            }
        }

        public IRepository<Parametro> ParametroRepository => _parametroRepository ?? new BaseRepository<Parametro>(_context);
        public IRepository<Paralelo> ParaleloRepository => _paraleloRepository ?? new BaseRepository<Paralelo>(_context);
        public IRepository<Categoria> CategoriaRepository => _categoriaRepository ?? new BaseRepository<Categoria>(_context);
        public IRepository<Periodo> PeriodoRepository => _periodoRepository ?? new BaseRepository<Periodo>(_context);
        public IRepository<Asistencia> AsistenciaRepository => _asistenciaRepository ?? new BaseRepository<Asistencia>(_context);
        public IRepository<Autoevaluacion> AutoevaluacionRepository => _autoevaluacionRepository ?? new BaseRepository<Autoevaluacion>(_context);
        public IRepository<Calendario> CalendarioRepository => _calendarioRepository ?? new BaseRepository<Calendario>(_context);
        public IRepository<Curso> CursoRepository => _cursoRepository ?? new BaseRepository<Curso>(_context);
        public IRepository<Estudiante> EstudianteRepository => _estudianteRepository ?? new BaseRepository<Estudiante>(_context);
        public IRepository<EstudianteMateria> EstudianteMateriaRepository => _estudianteMateriaRepository ?? new BaseRepository<EstudianteMateria>(_context);
        public IRepository<EvaluacionProfesor> EvaluacionProfesorRepository => _evaluacionProfesorRepository ?? new BaseRepository<EvaluacionProfesor>(_context);
        public IRepository<Fotos> FotosRepository => _fotosRepository ?? new BaseRepository<Fotos>(_context);
        public IRepository<Horario> HorarioRepository => _horarioRepository ?? new BaseRepository<Horario>(_context);
        public IRepository<Institucion> InstitucionRepository => _institucionRepository ?? new BaseRepository<Institucion>(_context);
        public IRepository<Materia> MateriaRepository => _materiaRepository ?? new BaseRepository<Materia>(_context);
        public IRepository<MateriaDictada> MateriaDictadaRepository => _materiaDictadaRepository ?? new BaseRepository<MateriaDictada>(_context);
        public IRepository<Nota> NotaRepository => _notaRepository ?? new BaseRepository<Nota>(_context);
        public IRepository<Notificacion> NotificacionRepository => _notificacionRepository ?? new BaseRepository<Notificacion>(_context);
        public IRepository<Profesor> ProfesorRepository => _profesorRepository ?? new BaseRepository<Profesor>(_context);
        public IRepository<Representante> RepresentanteRepository => _representanteRepository ?? new BaseRepository<Representante>(_context);
        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new BaseRepository<Usuario>(_context);
        public IRepository<Rude> RudeRepository => _rudeRepository ?? new BaseRepository<Rude>(_context);
        public IRepository<Calificacion> CalificacionRepository => _calificacionRepository ?? new BaseRepository<Calificacion>(_context);
        public IRepository<Administrador> AdministradorRepository => _administradorRepository ?? new BaseRepository<Administrador>(_context);
        public IRepository<EstudianteCurso> EstudianteCursoRepository => _estudianteCursoRepository ?? new BaseRepository<EstudianteCurso>(_context);
        public IRepository<Notas> NotasRepository => _notasRepository ?? new BaseRepository<Notas>(_context);

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
