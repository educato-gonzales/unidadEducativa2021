using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UnidadEducativa.Core.DTO;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Rol, RolDto>();
            CreateMap<RolDto, Rol>();

            CreateMap<Parametro, ParametroDto>();
            CreateMap<ParametroDto, Parametro>();

            CreateMap<Paralelo, ParaleloDto>();
            CreateMap<ParaleloDto, Paralelo>();

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();

            CreateMap<Periodo, PeriodoDto>();
            CreateMap<PeriodoDto, Periodo>();

            CreateMap<Asistencia, AsistenciaDto>();
            CreateMap<AsistenciaDto, Asistencia>();

            CreateMap<Autoevaluacion, AutoevaluacionDto>();
            CreateMap<AutoevaluacionDto, Autoevaluacion>();

            CreateMap<Calendario, CalendarioDto>();
            CreateMap<CalendarioDto, Calendario>();

            CreateMap<Curso, CursoDto>();
            CreateMap<CursoDto, Curso>();

            CreateMap<Estudiante, EstudianteDto>();
            CreateMap<EstudianteDto, Estudiante>();

            CreateMap<EstudianteMateria, EstudianteMateriaDto>();
            CreateMap<EstudianteMateriaDto, EstudianteMateria>();

            CreateMap<EvaluacionProfesor, EvaluacionProfesorDto>();
            CreateMap<EvaluacionProfesorDto, EvaluacionProfesor>();

            CreateMap<Fotos, FotosDto>();
            CreateMap<FotosDto, Fotos>();

            CreateMap<Horario, HorarioDto>();
            CreateMap<HorarioDto, Horario>();

            CreateMap<Institucion, InstitucionDto>();
            CreateMap<InstitucionDto, Institucion>();

            CreateMap<Materia, MateriaDto>();
            CreateMap<MateriaDto, Materia>();

            CreateMap<MateriaDictada, MateriaDictadaDto>();
            CreateMap<MateriaDictadaDto, MateriaDictada>();

            CreateMap<Nota, NotaDto>();
            CreateMap<NotaDto, Nota>();

            CreateMap<Notificacion, NotificacionDto>();
            CreateMap<NotificacionDto, Notificacion>();

            CreateMap<Profesor, ProfesorDto>();
            CreateMap<ProfesorDto, Profesor>();

            CreateMap<Representante, RepresentanteDto>();
            CreateMap<RepresentanteDto, Representante>();

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<Rude, RudeDto>();
            CreateMap<RudeDto, Rude>();

            CreateMap<Calificacion, CalificacionDto>();
            CreateMap<CalificacionDto, Calificacion>();

            CreateMap<Administrador, AdministradorDto>();
            CreateMap<AdministradorDto, Administrador>();

            CreateMap<EstudianteCurso, EstudianteCursoDto>();
            CreateMap<EstudianteCursoDto, EstudianteCurso>();

            CreateMap<Notas, NotasDto>();
            CreateMap<NotasDto, Notas>();

        }
    }
}
