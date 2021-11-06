using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Infrastructure.Data
{
    public partial class colegioContext : DbContext
    {
        public colegioContext()
        {
        }

        public colegioContext(DbContextOptions<colegioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Autoevaluacion> Autoevaluacion { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<EstudianteCurso> EstudianteCurso { get; set; }
        public virtual DbSet<EstudianteMateria> EstudianteMateria { get; set; }
        public virtual DbSet<EvaluacionProfesor> EvaluacionProfesor { get; set; }
        public virtual DbSet<Fotos> Fotos { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Institucion> Institucion { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<MateriaDictada> MateriaDictada { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<Paralelo> Paralelo { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Representante> Representante { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rude> Rude { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-BIISNMJT\\SQLEXPRESS; Initial Catalog=colegio; Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApMaterno)
                    .IsRequired()
                    .HasColumnName("apMaterno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApPaterno)
                    .IsRequired()
                    .HasColumnName("apPaterno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaIdentidad)
                    .IsRequired()
                    .HasColumnName("cedulaIdentidad")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasIndex(e => e.IdEstudiante)
                    .HasName("fkIdx_estudiante_asistencia");

                entity.HasIndex(e => e.IdMateria)
                    .HasName("fkIdx_materia_asistencia");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fkIdx_periodo_asistencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_curso_asistencia");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_estudiante_asistencia");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_materia_asistencia");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_periodo_asistencia");
            });

            modelBuilder.Entity<Autoevaluacion>(entity =>
            {
                entity.HasIndex(e => e.IdEvalPoseedor)
                    .HasName("fkIdx_eval_poseedor_autoevaluacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdEvalPoseedor).HasColumnName("id_eval_poseedor");

                entity.Property(e => e.NotaDecidir).HasColumnName("notaDecidir");

                entity.Property(e => e.NotaSer).HasColumnName("notaSer");

                entity.HasOne(d => d.IdEvalPoseedorNavigation)
                    .WithMany(p => p.Autoevaluacion)
                    .HasForeignKey(d => d.IdEvalPoseedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eval_poseedor_autoevaluacion");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fkIdx_periodo_calendario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasColumnName("lugar")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Calendario)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_periodo_calendario");
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasIndex(e => e.IdEstudiante)
                    .HasName("fkIdx_estudiante_calificacion");

                entity.HasIndex(e => e.IdEvalPoseedor)
                    .HasName("fkIdx_eval_poseedor_calificacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdEvalPoseedor).HasColumnName("id_eval_poseedor");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Calificacion)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_estudiante_calificacion");

                entity.HasOne(d => d.IdEvalPoseedorNavigation)
                    .WithMany(p => p.Calificacion)
                    .HasForeignKey(d => d.IdEvalPoseedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eval_poseedor_calificacion");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasIndex(e => e.IdParalelo)
                    .HasName("fkIdx_paralelo_curso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdParalelo).HasColumnName("id_paralelo");

                entity.Property(e => e.Nivel)
                    .IsRequired()
                    .HasColumnName("nivel")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Turno)
                    .IsRequired()
                    .HasColumnName("turno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParaleloNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdParalelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paralelo_curso");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fkIdx_periodo_estudiante");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApMaterno)
                    .IsRequired()
                    .HasColumnName("apMaterno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApPaterno)
                    .IsRequired()
                    .HasColumnName("apPaterno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaIdentidad)
                    .IsRequired()
                    .HasColumnName("cedulaIdentidad")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Estudiante)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("FK_periodo_estudiante");
            });

            modelBuilder.Entity<EstudianteCurso>(entity =>
            {
                entity.HasIndex(e => e.IdCurso)
                    .HasName("fkIdx_curso_estudianteCurso");

                entity.HasIndex(e => e.IdEstudiante)
                    .HasName("fkIdx_estudiante_estudianteCurso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.EstudianteCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_curso_estudianteCurso");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.EstudianteCurso)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_estudiante_estudianteCurso");
            });

            modelBuilder.Entity<EstudianteMateria>(entity =>
            {
                entity.HasIndex(e => e.IdEstudiante)
                    .HasName("fkIdx_estudiante_estudianteMateria");

                entity.HasIndex(e => e.IdHorario)
                    .HasName("fkIdx_horario_estudianteMateria");

                entity.HasIndex(e => e.IdMateria)
                    .HasName("fkIdx_materia_estudianteMateria");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fkIdx_periodo_estudianteMateria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdHorario).HasColumnName("id_horario");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_estudiante_estudianteMateria");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_horario_estudianteMateria");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_materia_estudianteMateria");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_periodo_estudianteMateria");
            });

            modelBuilder.Entity<EvaluacionProfesor>(entity =>
            {
                entity.HasIndex(e => e.IdEstudiante)
                    .HasName("fkIdx_estudiante_evaluacionProfesor");

                entity.HasIndex(e => e.IdEvalPoseedor)
                    .HasName("fkIdx_eval_poseedor_evaluacionProfesor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdEvalPoseedor).HasColumnName("id_eval_poseedor");

                entity.Property(e => e.NotaDecidir).HasColumnName("notaDecidir");

                entity.Property(e => e.NotaSer).HasColumnName("notaSer");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.EvaluacionProfesor)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_estudiante_evaluacionProfesor");

                entity.HasOne(d => d.IdEvalPoseedorNavigation)
                    .WithMany(p => p.EvaluacionProfesor)
                    .HasForeignKey(d => d.IdEvalPoseedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eval_poseedor_evaluacionProfesor");
            });

            modelBuilder.Entity<Fotos>(entity =>
            {
                entity.HasIndex(e => e.IdEstudiante)
                    .HasName("fkIdx_estudiante_fotos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.PathImg)
                    .IsRequired()
                    .HasColumnName("path_img")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Fotos)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_estudiante_fotos");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dia)
                    .IsRequired()
                    .HasColumnName("dia")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.HoraFin)
                    .IsRequired()
                    .HasColumnName("horaFin")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HoraInicio)
                    .IsRequired()
                    .HasColumnName("horaInicio")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Institucion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bachillerato).HasColumnName("bachillerato");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasColumnName("canton")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Celular1)
                    .HasColumnName("celular1")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Celular2)
                    .HasColumnName("celular2")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasColumnName("ciudad")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodDistritoEducativo)
                    .IsRequired()
                    .HasColumnName("codDistritoEducativo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodEdificioEscolar)
                    .HasColumnName("codEdificioEscolar")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodUe)
                    .IsRequired()
                    .HasColumnName("codUe")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comunitaria).HasColumnName("comunitaria");

                entity.Property(e => e.Convenio).HasColumnName("convenio");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnName("departamento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EdAdultos).HasColumnName("edAdultos");

                entity.Property(e => e.EdAlternativa).HasColumnName("edAlternativa");

                entity.Property(e => e.EdEspecial).HasColumnName("edEspecial");

                entity.Property(e => e.EdFormal).HasColumnName("edFormal");

                entity.Property(e => e.EdInicial).HasColumnName("edInicial");

                entity.Property(e => e.EdPermanente).HasColumnName("edPermanente");

                entity.Property(e => e.EdPrimaria).HasColumnName("edPrimaria");

                entity.Property(e => e.EdSecundaria).HasColumnName("edSecundaria");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Estatal).HasColumnName("estatal");

                entity.Property(e => e.FechaRecepcion)
                    .HasColumnName("fechaRecepcion")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaResolucionAdm1)
                    .HasColumnName("fechaResolucionAdm1")
                    .HasColumnType("date");

                entity.Property(e => e.FechaResolucionAdm2)
                    .HasColumnName("fechaResolucionAdm2")
                    .HasColumnType("date");

                entity.Property(e => e.Humanistico).HasColumnName("humanistico");

                entity.Property(e => e.Latitud)
                    .HasColumnName("latitud")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Longitud)
                    .HasColumnName("longitud")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.LugarRecepcion)
                    .IsRequired()
                    .HasColumnName("lugarRecepcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDistritoEducativo)
                    .IsRequired()
                    .HasColumnName("nombreDistritoEducativo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreInstitucion)
                    .IsRequired()
                    .HasColumnName("nombreInstitucion")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUe)
                    .IsRequired()
                    .HasColumnName("nombreUe")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.NuevoCodEdificioEscolar)
                    .HasColumnName("nuevoCodEdificioEscolar")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumResolucionAdm1).HasColumnName("numResolucionAdm1");

                entity.Property(e => e.NumResolucionAdm2).HasColumnName("numResolucionAdm2");

                entity.Property(e => e.Privada).HasColumnName("privada");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasColumnName("provincia")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SeccionMunicipal)
                    .IsRequired()
                    .HasColumnName("seccionMunicipal")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Siglas)
                    .IsRequired()
                    .HasColumnName("siglas")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tecnico).HasColumnName("tecnico");

                entity.Property(e => e.Telefono1)
                    .HasColumnName("telefono1")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono2)
                    .HasColumnName("telefono2")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasColumnName("web")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zona)
                    .IsRequired()
                    .HasColumnName("zona")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Nivel)
                    .IsRequired()
                    .HasColumnName("nivel")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasColumnName("sigla")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MateriaDictada>(entity =>
            {
                entity.HasIndex(e => e.IdCurso)
                    .HasName("fkIdx_curso_materiaDictada");

                entity.HasIndex(e => e.IdHorario)
                    .HasName("fkIdx_horario_materiaDictada");

                entity.HasIndex(e => e.IdMateria)
                    .HasName("fkIdx_materia_materiaDictada");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fkIdx_periodo_materiaCurso");

                entity.HasIndex(e => e.IdProfesor)
                    .HasName("fkIdx_profesor_materiaDictada");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdHorario).HasColumnName("id_horario");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.MateriaDictada)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_curso_materiaDictada");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.MateriaDictada)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_horario_materiaDictada");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.MateriaDictada)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_materia_materiaDictada");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.MateriaDictada)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_periodo_materiaDictada");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.MateriaDictada)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_profesor_materiaDictada");
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasIndex(e => e.IdCategoria)
                    .HasName("fkIdx_categoria_nota");

                entity.HasIndex(e => e.IdCurso)
                    .HasName("fkIdx_curso_nota");

                entity.HasIndex(e => e.IdMateria)
                    .HasName("fkIdx_materia_nota");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fkIdx_periodo_nota");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.IdRef).HasColumnName("id_ref");

                entity.Property(e => e.Nota1)
                    .HasColumnName("nota")
                    .HasColumnType("decimal(18, 1)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_categoria_nota");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_curso_nota");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_materia_nota");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_periodo_nota");
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.HasIndex(e => e.IdCategoria)
                    .HasName("fkIdx_categoria_notas");

                entity.HasIndex(e => e.IdCurso)
                    .HasName("fkIdx_curso_notas");

                entity.HasIndex(e => e.IdEstudiante)
                    .HasName("fkIdx_estudiante_notas");

                entity.HasIndex(e => e.IdMateria)
                    .HasName("fkIdx_materia_notas");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fkIdx_periodo_notas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.IdRef).HasColumnName("id_ref");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("decimal(18, 1)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_categoria_notas");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_curso_notas");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_estudiante_notas");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_materia_notas");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_periodo_notas");
            });

            modelBuilder.Entity<Notificacion>(entity =>
            {
                entity.HasIndex(e => e.IdCurso)
                    .HasName("fkIdx_curso_notificacion");

                entity.HasIndex(e => e.IdProfesor)
                    .HasName("fkIdx_profesor_notificacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Notificacion)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_curso_notificacion");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Notificacion)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_profesor_notificacion");
            });

            modelBuilder.Entity<Paralelo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasColumnName("valor")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApMaterno)
                    .IsRequired()
                    .HasColumnName("apMaterno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApPaterno)
                    .IsRequired()
                    .HasColumnName("apPaterno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaIdentidad)
                    .IsRequired()
                    .HasColumnName("cedulaIdentidad")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdiomaFrecuente)
                    .IsRequired()
                    .HasColumnName("idiomaFrecuente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Posgrado)
                    .IsRequired()
                    .HasColumnName("posgrado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TituloProfesional)
                    .IsRequired()
                    .HasColumnName("tituloProfesional")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TituloProvNacional)
                    .IsRequired()
                    .HasColumnName("tituloProvNacional")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Representante>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApMaterno)
                    .IsRequired()
                    .HasColumnName("apMaterno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApPaterno)
                    .IsRequired()
                    .HasColumnName("apPaterno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaIdentidad)
                    .IsRequired()
                    .HasColumnName("cedulaIdentidad")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasColumnName("complemento")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Expedido)
                    .IsRequired()
                    .HasColumnName("expedido")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.GradoInstruccion)
                    .IsRequired()
                    .HasColumnName("gradoInstruccion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdiomaFrecuente)
                    .IsRequired()
                    .HasColumnName("idiomaFrecuente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OcupacionLaboral)
                    .IsRequired()
                    .HasColumnName("ocupacionLaboral")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasColumnName("parentesco")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rude>(entity =>
            {
                entity.HasIndex(e => e.IdRepresentanteMadre)
                    .HasName("fkIdx_representante_madre_rude");

                entity.HasIndex(e => e.IdRepresentantePadre)
                    .HasName("fkIdx_representante_padre_rude");

                entity.HasIndex(e => e.IdRepresentanteTutor)
                    .HasName("fkIdx_representante_tutor_rude");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AbandonoUe).HasColumnName("abandonoUe");

                entity.Property(e => e.ActividadTrabajo)
                    .HasColumnName("actividadTrabajo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Agua).HasColumnName("agua");

                entity.Property(e => e.Alcantarillado).HasColumnName("alcantarillado");

                entity.Property(e => e.AvenidaEst)
                    .HasColumnName("avenidaEst")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Banio).HasColumnName("banio");

                entity.Property(e => e.CentroSalud).HasColumnName("centroSalud");

                entity.Property(e => e.CodRude)
                    .IsRequired()
                    .HasColumnName("codRude")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodSieue)
                    .IsRequired()
                    .HasColumnName("codSieue")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasColumnName("complemento")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnName("departamento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DepartamentoEst)
                    .IsRequired()
                    .HasColumnName("departamentoEst")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Discapacidad).HasColumnName("discapacidad");

                entity.Property(e => e.EnergiaElectrica).HasColumnName("energiaElectrica");

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.Expedido)
                    .IsRequired()
                    .HasColumnName("expedido")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fechaRegistro")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Folio).HasColumnName("folio");

                entity.Property(e => e.FrecuenciaCs)
                    .HasColumnName("frecuenciaCs")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FrecuenciaInternet)
                    .IsRequired()
                    .HasColumnName("frecuenciaInternet")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FrecuenciaTrabajo)
                    .HasColumnName("frecuenciaTrabajo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GradoDiscapacidad)
                    .HasColumnName("gradoDiscapacidad")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdRepresentanteMadre).HasColumnName("id_representante_madre");

                entity.Property(e => e.IdRepresentantePadre).HasColumnName("id_representante_padre");

                entity.Property(e => e.IdRepresentanteTutor).HasColumnName("id_representante_tutor");

                entity.Property(e => e.IdiomaFrecuente)
                    .IsRequired()
                    .HasColumnName("idiomaFrecuente")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.IdiomaNiniez)
                    .IsRequired()
                    .HasColumnName("idiomaNiniez")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Internet)
                    .IsRequired()
                    .HasColumnName("internet")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Libro).HasColumnName("libro");

                entity.Property(e => e.Localidad)
                    .IsRequired()
                    .HasColumnName("localidad")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LocalidadEst)
                    .IsRequired()
                    .HasColumnName("localidadEst")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LugarRegistro)
                    .IsRequired()
                    .HasColumnName("lugarRegistro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedioTransporte)
                    .IsRequired()
                    .HasColumnName("medioTransporte")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MesesTrabajo)
                    .HasColumnName("mesesTrabajo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Nacion)
                    .IsRequired()
                    .HasColumnName("nacion")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumDiscapacidad).HasColumnName("numDiscapacidad");

                entity.Property(e => e.NumViviendaEst)
                    .HasColumnName("numViviendaEst")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oficialia)
                    .IsRequired()
                    .HasColumnName("oficialia")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PagoTrabajo).HasColumnName("pagoTrabajo");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasColumnName("pais")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Partida).HasColumnName("partida");

                entity.Property(e => e.ProblemaSalud)
                    .IsRequired()
                    .HasColumnName("problemaSalud")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasColumnName("provincia")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinciaEst)
                    .IsRequired()
                    .HasColumnName("provinciaEst")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonAbandono)
                    .HasColumnName("razonAbandono")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SeccionEst)
                    .IsRequired()
                    .HasColumnName("seccionEst")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeguroCs).HasColumnName("seguroCs");

                entity.Property(e => e.ServBasura).HasColumnName("servBasura");

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.Property(e => e.TiempoTransporte)
                    .IsRequired()
                    .HasColumnName("tiempoTransporte")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDiscapacidad)
                    .HasColumnName("tipoDiscapacidad")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPago).HasColumnName("tipoPago");

                entity.Property(e => e.Trabajo).HasColumnName("trabajo");

                entity.Property(e => e.TurnoTrabajo)
                    .HasColumnName("turnoTrabajo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Vivienda)
                    .IsRequired()
                    .HasColumnName("vivienda")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZonaEst)
                    .HasColumnName("zonaEst")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Rude)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_estudiante_rude");

                entity.HasOne(d => d.IdRepresentanteMadreNavigation)
                    .WithMany(p => p.RudeIdRepresentanteMadreNavigation)
                    .HasForeignKey(d => d.IdRepresentanteMadre)
                    .HasConstraintName("FK_representante_madre_rude");

                entity.HasOne(d => d.IdRepresentantePadreNavigation)
                    .WithMany(p => p.RudeIdRepresentantePadreNavigation)
                    .HasForeignKey(d => d.IdRepresentantePadre)
                    .HasConstraintName("FK_representante_padre_rude");

                entity.HasOne(d => d.IdRepresentanteTutorNavigation)
                    .WithMany(p => p.RudeIdRepresentanteTutorNavigation)
                    .HasForeignKey(d => d.IdRepresentanteTutor)
                    .HasConstraintName("FK_representante_tutor_rude");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.IdRol)
                    .HasName("fkIdx_rol_usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Entidad)
                    .HasColumnName("entidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSql).HasColumnName("estado_sql");

                entity.Property(e => e.IdRef).HasColumnName("id_ref");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rol_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
