DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

EXEC sp_MSforeachtable 'DROP TABLE ?'
GO

-- ************************************** [Rol]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Rol')
CREATE TABLE [Rol]
(
 [id]          bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]      varchar(50)  NOT NULL ,
 [descripcion] varchar(200) NULL     ,
 [estado_sql]  bigint       NOT NULL ,

 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ************************************** [Usuario]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Usuario')
CREATE TABLE [Usuario]
(
 [id]           bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]       varchar(50) NOT NULL ,
 [clave]        varchar(50) NOT NULL ,
 [estado]       varchar(50) NOT NULL ,
 [entidad]      varchar(50) NULL     ,
 [id_ref]       bigint ,
 [id_rol]       bigint      NOT NULL ,
 [estado_sql]   bigint      NOT NULL ,

 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_rol_usuario] FOREIGN KEY ([id_rol])  REFERENCES [Rol]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_rol_usuario] ON [Usuario] 
 (
  [id_rol] ASC
 )

GO

-- ************************************** [Representante]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Representante')
CREATE TABLE [Representante]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [cedulaIdentidad]                   varchar(10) NOT NULL ,
 [complemento]          varchar(2)  NOT NULL ,
 [expedido]             varchar(10)  NOT NULL ,
 [apPaterno]            varchar(20) NOT NULL ,
 [apMaterno]            varchar(20) NOT NULL ,
 [nombres]              varchar(20) NOT NULL ,
 [idiomaFrecuente]      varchar(20) NOT NULL ,
 [ocupacionLaboral]     varchar(20) NOT NULL ,
 [gradoInstruccion]     varchar(20) NOT NULL , 
 [fechaNacimiento]      date        NOT NULL ,
 [parentesco]           varchar(20) NOT NULL , 
 [telefono]             varchar(10) NULL     ,
 [celular]              varchar(10) NULL     ,
 [estado_sql]           bigint      NOT NULL ,
 
 CONSTRAINT [PK_Representante] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ************************************** [Periodo]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Periodo')
CREATE TABLE [Periodo]
(
 [id]                   bigint IDENTITY (1, 1)  NOT NULL ,
 [nombre]               varchar(100)    NOT NULL ,
 [fechaInicio]          date            NOT NULL ,
 [fechaFin]             date            NOT NULL , 
 [estado]               varchar(20)     NOT NULL , 
 [descripcion]          varchar(200)    NULL , 
 [estado_sql]           bigint      NOT NULL ,
 
 CONSTRAINT [PK_Periodo] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ************************************** [Paralelo]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Paralelo')
CREATE TABLE [Paralelo]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]               varchar(10)  NOT NULL ,
 [estado_sql]           bigint      NOT NULL ,
 
 CONSTRAINT [PK_Paralelo] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- **** DATOS ****
insert into paralelo (nombre, estado_sql) 
    values ('A', 1 );

-- ************************************** [Curso]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Curso')
CREATE TABLE [Curso]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]               varchar(25)  NOT NULL ,
 [nivel]                varchar(20)  NOT NULL ,
 [turno]                varchar(20)  NOT NULL ,
 [descripcion]          varchar(100) NULL ,
 [id_paralelo]          bigint       NOT NULL,
 [estado_sql]           bigint      NOT NULL ,

 
 CONSTRAINT [PK_curso] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_paralelo_curso] FOREIGN KEY ([id_paralelo])  REFERENCES [Paralelo]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_paralelo_curso] ON [Curso] 
 (
  [id_paralelo] ASC
 )

GO



-- ************************************** [Estudiante]
-- ************************************** Contiene los datos de inscripcion del estudiante

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Estudiante')
CREATE TABLE [Estudiante]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [apPaterno]            varchar(20)     NOT NULL ,
 [apMaterno]            varchar(20)     NOT NULL ,
 [nombres]              varchar(20)     NOT NULL ,
 [fechaNacimiento]      date            NOT NULL ,
 [cedulaIdentidad]                   varchar(10)     NOT NULL ,
 [telefono]             varchar(10)     NULL     ,
 [celular]              varchar(10)     NULL     ,
 [id_curso]                 bigint      NULL ,
 [id_periodo]               bigint      NULL ,
 [estado_sql]   bigint      NOT NULL ,


 CONSTRAINT [PK_estudiante] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_curso_estudiante] FOREIGN KEY ([id_curso])  REFERENCES [Curso]([id]),
 CONSTRAINT [FK_periodo_estudiante] FOREIGN KEY ([id_periodo])  REFERENCES [Periodo]([id])
);
GO



CREATE NONCLUSTERED INDEX [fkIdx_curso_estudiante] ON [Estudiante] 
 (
  [id_curso] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_periodo_estudiante] ON [Estudiante] 
 (
  [id_periodo] ASC
 )
GO

-- ************************************** [Rude]
-- ************************************** Contiene los datos de inscripcion del estudiante

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Rude')
CREATE TABLE [Rude]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [codSieue]             varchar(8)      NOT NULL ,
 [pais]                 varchar(20)     NOT NULL ,
 [departamento]         varchar(20)     NOT NULL ,
 [provincia]            varchar(20)     NOT NULL ,
 [localidad]            varchar(20)     NOT NULL ,
 [oficialia]            varchar(10)     NOT NULL ,
 [libro]                bigint          NOT NULL ,
 [partida]              bigint          NOT NULL ,
 [folio]                bigint          NOT NULL ,
 [complemento]          varchar(2)      NOT NULL ,
 [expedido]             varchar(10)     NOT NULL ,
 [codRude]              varchar(20)     NOT NULL ,
 [sexo]                 bit             NOT NULL ,
 [discapacidad]         bit             NOT NULL ,
 [numDiscapacidad]      bigint          NULL     ,
 [tipoDiscapacidad]     varchar(20)     NULL     ,
 [gradoDiscapacidad]    varchar(20)     NULL     ,
 [departamentoEst]      varchar(50)     NOT NULL ,
 [provinciaEst]         varchar(50)     NOT NULL ,
 [seccionEst]           varchar(50)     NOT NULL ,
 [localidadEst]         varchar(50)     NOT NULL ,
 [zonaEst]              varchar(50)     NULL     ,
 [avenidaEst]           varchar(50)     NULL     ,
 [numViviendaEst]       varchar(50)     NULL     ,
 [idiomaNiniez]         varchar(20)     NOT NULL ,
 [idiomaFrecuente]      varchar(70)     NOT NULL ,
 [nacion]               varchar(30)     NOT NULL ,
 [centroSalud]          bit             NOT NULL ,
 [problemaSalud]        varchar(150)    NOT NULL ,
 [frecuenciaCs]         varchar(50)     NULL     , 
 [seguroCs]             bit             NOT NULL ,
 [agua]                 bit             NOT NULL ,
 [banio]                bit             NOT NULL ,
 [alcantarillado]       bit             NOT NULL ,
 [energiaElectrica]     bit             NOT NULL ,
 [servBasura]           bit             NOT NULL ,
 [vivienda]             varchar(50)     NOT NULL ,
 [internet]             varchar(300)    NOT NULL ,
 [frecuenciaInternet]   varchar(100)    NOT NULL ,
 [trabajo]              bit             NOT NULL ,
 [mesesTrabajo]         varchar(300)    NULL ,
 [actividadTrabajo]     varchar(300)    NULL ,
 [turnoTrabajo]         varchar(100)    NULL ,
 [frecuenciaTrabajo]    varchar(50)     NULL ,
 [pagoTrabajo]          bit             NULL ,
 [tipoPago]             bit             NULL ,
 [medioTransporte]      varchar(50)     NOT NULL ,
 [tiempoTransporte]     varchar(50)     NOT NULL ,
 [abandonoUe]           bit             NOT NULL ,
 [razonAbandono]        varchar(300)    NULL ,
 [fechaRegistro]        datetime        NOT NULL default GETDATE(), 
 [lugarRegistro]        varchar(50)     NOT NULL ,
 [id_representante_padre]   bigint      NULL ,
 [id_representante_madre]   bigint      NULL ,
 [id_representante_tutor]   bigint      NULL ,
 [id_estudiante]            bigint      NOT NULL ,
 [estado_sql]   bigint      NOT NULL ,

 CONSTRAINT [PK_rude] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_representante_padre_rude] FOREIGN KEY ([id_representante_padre])  REFERENCES [Representante]([id]),
 CONSTRAINT [FK_representante_madre_rude] FOREIGN KEY ([id_representante_madre])  REFERENCES [Representante]([id]),
 CONSTRAINT [FK_representante_tutor_rude] FOREIGN KEY ([id_representante_tutor])  REFERENCES [Representante]([id]),
 CONSTRAINT [FK_estudiante_rude] FOREIGN KEY ([id_estudiante])  REFERENCES [Estudiante]([id])
 );
GO

CREATE NONCLUSTERED INDEX [fkIdx_representante_padre_rude] ON [Rude] 
 (
  [id_representante_padre] ASC
 )

CREATE NONCLUSTERED INDEX [fkIdx_representante_madre_rude] ON [Rude] 
 (
  [id_representante_madre] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_representante_tutor_rude] ON [Rude] 
 (
  [id_representante_tutor] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_estudiante_rude] ON [Rude] 
 (
  [id_representante_tutor] ASC
 )
GO

-- ************************************** [Fotos]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Fotos')
CREATE TABLE [Fotos]
(
 [id]               bigint IDENTITY (1, 1) NOT NULL ,
 [descripcion]      varchar(150) NOT NULL ,
 [path_img]         varchar(max) NOT NULL ,
 [id_estudiante]    bigint       NOT NULL ,
 [estado_sql]       bigint      NOT NULL ,

 CONSTRAINT [PK_fotos] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_estudiante_fotos] FOREIGN KEY ([id_estudiante]) REFERENCES [Estudiante]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_estudiante_fotos] ON [Fotos] 
 (
  [id_estudiante] ASC
 )

GO

-- ************************************** [Parametro]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Parametro')
CREATE TABLE [Parametro]
(
 [id]        bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]       varchar(50) NOT NULL ,
 [valor]        text NOT NULL ,
 [estado_sql]   bigint      NOT NULL ,

 CONSTRAINT [PK_parametro] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ************************************** [Institucion]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Institucion')
CREATE TABLE [Institucion]
(
 [id]                       bigint IDENTITY (1, 1) NOT NULL ,
 [codUe]                    varchar(50)     NOT NULL ,  
 [nombreUe]                 varchar(70)     NOT NULL ,
 [numResolucionAdm1]        bigint          NULL     ,
 [fechaResolucionAdm1]      date            NULL     ,
 [codDistritoEducativo]     varchar(50)     NOT NULL ,
 [nombreDistritoEducativo]  varchar(50)     NOT NULL ,
 [numResolucionAdm2]        bigint          NULL     ,
 [fechaResolucionAdm2]      date            NULL     ,
 [codEdificioEscolar]       varchar(50)     NULL     ,
 [nuevoCodEdificioEscolar]  varchar(50)     NULL     ,
 [departamento]             varchar(20)     NOT NULL ,
 [provincia]                varchar(20)     NOT NULL ,
 [seccionMunicipal]         varchar(20)     NOT NULL ,
 [canton]                   varchar(20)     NOT NULL ,
 [ciudad]                   varchar(20)     NOT NULL ,
 [zona]                     varchar(50)     NOT NULL ,
 [direccion]                varchar(50)     NOT NULL ,
 [estatal]                  bit             NOT NULL ,
 [convenio]                 bit             NOT NULL ,
 [nombreInstitucion]        varchar(70)     NOT NULL ,
 [comunitaria]              bit             NOT NULL ,
 [privada]                  bit             NOT NULL ,
 [edFormal]                 bit             NOT NULL ,
 [edInicial]                bit             NOT NULL ,
 [edPrimaria]               bit             NOT NULL ,
 [edSecundaria]             bit             NOT NULL ,
 [edAlternativa]            bit             NOT NULL ,
 [edAdultos]                bit             NOT NULL ,
 [edEspecial]               bit             NOT NULL ,
 [edPermanente]             bit             NOT NULL ,
 [bachillerato]             bit             NOT NULL ,
 [humanistico]              bit             NOT NULL ,
 [tecnico]                  bit             NOT NULL ,
 [siglas]                   varchar(10)     NOT NULL ,
 [latitud]                  decimal(18,6)   NOT NULL ,
 [longitud]                 decimal(18,6)   NOT NULL ,
 [correo]                   varchar(100)    NULL,
 [telefono1]                varchar(10)     NULL ,
 [telefono2]                varchar(10)     NULL ,
 [celular1]                 varchar(10)     NULL ,
 [celular2]                 varchar(10)     NULL ,
 [web]                      varchar(100)    NULL ,
 [descripcion]              varchar(50)     NOT NULL ,
 [lugarRecepcion]           varchar(50)     NOT NULL ,
 [fechaRecepcion]           date            NOT NULL default GETDATE(), 
 [estado_sql]               bigint      NOT NULL ,

 CONSTRAINT [PK_Institucion] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ************************************** [Profesor]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Profesor')
CREATE TABLE [Profesor]
(
 [id]                   bigint IDENTITY (1, 1)  NOT NULL ,
 [cedulaIdentidad]                   varchar(10) NOT NULL ,
 [apPaterno]            varchar(20) NOT NULL ,
 [apMaterno]            varchar(20) NOT NULL ,
 [nombres]              varchar(20) NOT NULL ,
 [sexo]                 bit         NOT NULL ,
 [Rda]                  bit         NOT NULL ,
 [Cas]                  bit         NOT NULL ,
 [tituloProvNacional]   varchar(50) NOT NULL ,
 [tituloProfesional]    varchar(50) NOT NULL ,
 [posgrado]             varchar(50) NOT NULL ,
 [idiomaFrecuente]      varchar(20) NOT NULL ,
 [telefono]             varchar(10) NULL     ,
 [celular]              varchar(10) NULL     ,
 [correo]               varchar(90) NULL     ,
 [estado_sql]           bigint      NOT NULL ,

 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ************************************** [Calendario]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Calendario')
CREATE TABLE [Calendario]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]               varchar(50)  NOT NULL ,
 [fecha]                datetime     NOT NULL ,
 [lugar]                varchar(50)  NOT NULL ,
 [descripcion]          varchar(200) NULL     ,
 [id_periodo]           bigint       NOT NULL ,
 [estado_sql]           bigint      NOT NULL ,
 
 CONSTRAINT [PK_Calendario] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_periodo_calendario] FOREIGN KEY ([id_periodo])  REFERENCES [Periodo]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_periodo_calendario] ON [Calendario] 
 (
  [id_periodo] ASC
 )

GO

-- ************************************** [Notificacion]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Notificacion')
CREATE TABLE [Notificacion]
(
 [id]                   bigint IDENTITY (1, 1)  NOT NULL ,
 [nombre]               varchar(20)     NOT NULL ,
 [descripcion]          varchar(1000)   NOT NULL ,
 [fecha]                datetime        NOT NULL default GETDATE(), 
 [id_curso]             bigint          NOT NULL ,
 [id_profesor]          bigint          NOT NULL ,
 [estado_sql]           bigint      NOT NULL ,
 
 CONSTRAINT [PK_notificacion] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_curso_notificacion] FOREIGN KEY ([id_curso])  REFERENCES [Curso]([id]),
 CONSTRAINT [FK_profesor_notificacion] FOREIGN KEY ([id_profesor])  REFERENCES [Profesor]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_curso_notificacion] ON [Notificacion] 
 (
  [id_curso] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_profesor_notificacion] ON [Notificacion] 
 (
  [id_profesor] ASC
 )

GO

-- ************************************** [Horario]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Horario')
CREATE TABLE [Horario]
(
 [id]                   bigint IDENTITY (1, 1)  NOT NULL ,
 [dia]                  varchar(10)     NOT NULL ,
 [horaInicio]           varchar(10)            NOT NULL ,
 [horaFin]              varchar(10)            NOT NULL , 
 [estado_sql]           bigint      NOT NULL ,
 
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO


/* [horaInicio]           varchar(10)            NOT NULL ,
 [horaFin]              varchar(10)          NOT NULL , */

-- ************************************** [Materia]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Materia')
CREATE TABLE [Materia]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [sigla]                    varchar(10)  NOT NULL ,
 [nombre]                   varchar(50)  NOT NULL ,
 [nivel]                    varchar(20)  NOT NULL ,
 [descripcion]              varchar(100) NULL ,
 [estado_sql]               bigint      NOT NULL ,
 
 CONSTRAINT [PK_materia] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ************************************** [MateriaDictada]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='MateriaDictada')
CREATE TABLE [MateriaDictada]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [descripcion]              varchar(100)    NULL     ,
 [id_materia]               bigint          NOT NULL ,
 [id_curso]                 bigint          NOT NULL ,
 [id_profesor]              bigint          NOT NULL ,
 [id_horario]               bigint          NOT NULL ,
 [id_periodo]               bigint          NOT NULL ,
 [estado_sql]               bigint          NOT NULL ,
 
 CONSTRAINT [PK_materiaDictada] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_materia_materiaDictada] FOREIGN KEY ([id_materia])  REFERENCES [Materia]([id]),
 CONSTRAINT [FK_curso_materiaDictada] FOREIGN KEY ([id_curso])  REFERENCES [Curso]([id]),
 CONSTRAINT [FK_profesor_materiaDictada] FOREIGN KEY ([id_profesor])  REFERENCES [Profesor]([id]),
 CONSTRAINT [FK_horario_materiaDictada] FOREIGN KEY ([id_horario])  REFERENCES [Horario]([id]),
 CONSTRAINT [FK_periodo_materiaDictada] FOREIGN KEY ([id_periodo])  REFERENCES [Periodo]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_materia_materiaDictada] ON [MateriaDictada] 
 (
  [id_materia] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_curso_materiaDictada] ON [MateriaDictada] 
 (
  [id_curso] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_profesor_materiaDictada] ON [MateriaDictada] 
 (
  [id_profesor] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_horario_materiaDictada] ON [MateriaDictada] 
 (
  [id_horario] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_periodo_materiaCurso] ON [MateriaDictada] 
 (
  [id_periodo] ASC
 )

GO

-- ************************************** [EstudianteMateria]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='EstudianteMateria')
CREATE TABLE [EstudianteMateria]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [id_materia]               bigint          NOT NULL ,
 [id_estudiante]            bigint          NOT NULL ,
 [id_horario]               bigint          NOT NULL ,
 [id_periodo]               bigint          NOT NULL ,
 [estado_sql]               bigint          NOT NULL ,
 
 CONSTRAINT [PK_estudianteMateria] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_materia_estudianteMateria] FOREIGN KEY ([id_materia])  REFERENCES [Materia]([id]),
 CONSTRAINT [FK_estudiante_estudianteMateria] FOREIGN KEY ([id_estudiante])  REFERENCES [Estudiante]([id]),
 CONSTRAINT [FK_horario_estudianteMateria] FOREIGN KEY ([id_horario])  REFERENCES [Horario]([id]),
 CONSTRAINT [FK_periodo_estudianteMateria] FOREIGN KEY ([id_periodo])  REFERENCES [Periodo]([id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_estudiante_estudianteMateria] ON [EstudianteMateria] 
 (
  [id_estudiante] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_materia_estudianteMateria] ON [EstudianteMateria] 
 (
  [id_materia] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_horario_estudianteMateria] ON [EstudianteMateria] 
 (
  [id_horario] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_periodo_estudianteMateria] ON [EstudianteMateria] 
 (
  [id_periodo] ASC
 )
GO

-- ************************************** [Asistencia]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Asistencia')
CREATE TABLE [Asistencia]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [fecha]                    datetime    NOT NULL ,
 [estado]                   varchar(10) NOT NULL ,
 [descripcion]              varchar(50) NULL     ,
 [id_estudiante]            bigint      NOT NULL ,
 [id_materia]               bigint      NOT NULL ,
 [id_periodo]               bigint      NOT NULL ,
 [estado_sql]               bigint      NOT NULL ,
 
 CONSTRAINT [PK_asistencia] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_estudiante_asistencia] FOREIGN KEY ([id_estudiante])  REFERENCES [EstudianteMateria]([id]),
 CONSTRAINT [FK_materia_asistencia] FOREIGN KEY ([id_materia])  REFERENCES [EstudianteMateria]([id]),
 CONSTRAINT [FK_periodo_asistencia] FOREIGN KEY ([id_periodo])  REFERENCES [Periodo]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_estudiante_asistencia] ON [Asistencia] 
 (
  [id_estudiante] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_materia_asistencia] ON [Asistencia] 
 (
  [id_materia] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_periodo_asistencia] ON [Asistencia] 
 (
  [id_periodo] ASC
 )
GO

-- ************************************** [Categoria]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Categoria')
CREATE TABLE [Categoria]
(
 [id]                   bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]                   varchar (50)    NOT NULL ,
 [descripcion]              varchar (50)    NOT NULL ,
 [estado_sql]               bigint          NOT NULL ,

 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ************************************** [Nota]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Nota')
CREATE TABLE [Nota]
(
 [id]               bigint IDENTITY (1, 1) NOT NULL ,
 [fecha]               date            NOT NULL ,
 [nota]                 decimal(18,1)   NULL ,
 [descripcion]          varchar(150)    NOT NULL ,
 [id_curso]             bigint          NOT NULL ,
 [id_periodo]           bigint          NOT NULL ,
 [id_materia]           bigint          NOT NULL ,
 [id_categoria]         bigint          NOT NULL ,
 -- Id REF: ID de evaluador bien profesor u almuno
 [id_ref]               bigint ,
 [estado_sql]           bigint          NOT NULL ,

 CONSTRAINT [PK_nota] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_curso_nota] FOREIGN KEY ([id_curso])  REFERENCES [Curso]([id]),
 CONSTRAINT [FK_periodo_nota] FOREIGN KEY ([id_periodo])  REFERENCES [Periodo]([id]),
 CONSTRAINT [FK_materia_nota] FOREIGN KEY ([id_materia])  REFERENCES [Materia]([id]),
 CONSTRAINT [FK_categoria_nota] FOREIGN KEY ([id_categoria])  REFERENCES [Categoria]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_curso_nota] ON [Nota] 
 (
  [id_curso] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_periodo_nota] ON [Nota] 
 (
  [id_periodo] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_materia_nota] ON [Nota] 
 (
  [id_materia] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_categoria_nota] ON [Nota] 
 (
  [id_categoria] ASC
 )
GO

-- ************************************** [Autoevaluacion]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Autoevaluacion')
CREATE TABLE [Autoevaluacion]
(
 [id]               bigint IDENTITY (1, 1) NOT NULL ,
 [notaSer]              bigint          NOT NULL ,
 [notaDecidir]          bigint          NOT NULL ,
 [id_eval_poseedor]     bigint          NOT NULL ,
 [estado_sql]           bigint          NOT NULL ,


 CONSTRAINT [PK_autoevaluacion] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_eval_poseedor_autoevaluacion] FOREIGN KEY ([id_eval_poseedor])  REFERENCES [Nota]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_eval_poseedor_autoevaluacion] ON [Autoevaluacion] 
 (
  [id_eval_poseedor] ASC
 )
GO

-- ************************************** [EvaluacionProfesor]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='EvaluacionProfesor')
CREATE TABLE EvaluacionProfesor
(
 [id]               bigint IDENTITY (1, 1) NOT NULL ,
 [notaSer]              bigint          NOT NULL ,
 [notaDecidir]          bigint          NOT NULL ,
 [id_estudiante]          bigint         NOT NULL ,
 [id_eval_poseedor]     bigint          NOT NULL ,
 [estado_sql]           bigint          NOT NULL ,


 CONSTRAINT [PK_evaluacionProfesor] PRIMARY KEY CLUSTERED ([id] ASC),
  CONSTRAINT [FK_estudiante_evaluacionProfesor] FOREIGN KEY ([id_estudiante])  REFERENCES [Estudiante]([id]),
 CONSTRAINT [FK_eval_poseedor_evaluacionProfesor] FOREIGN KEY ([id_eval_poseedor])  REFERENCES [Nota]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_eval_poseedor_evaluacionProfesor] ON EvaluacionProfesor 
 (
  [id_eval_poseedor] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_estudiante_evaluacionProfesor] ON EvaluacionProfesor 
 (
  [id_estudiante] ASC
 )
GO

-- ************************************** [Calificacion]

IF NOT EXISTS (SELECT * FROM sys.tables t WHERE t.name='Calificacion')
CREATE TABLE Calificacion
(
 [id]               bigint IDENTITY (1, 1) NOT NULL ,
 [nota]              bigint          NOT NULL ,
 [id_estudiante]          bigint          NOT NULL ,
 [id_eval_poseedor]     bigint          NOT NULL ,
 [estado_sql]           bigint          NOT NULL ,


 CONSTRAINT [PK_calificacion] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [FK_estudiante_calificacion] FOREIGN KEY ([id_estudiante])  REFERENCES [Estudiante]([id]),
 CONSTRAINT [FK_eval_poseedor_calificacion] FOREIGN KEY ([id_eval_poseedor])  REFERENCES [Nota]([id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_eval_poseedor_calificacion] ON Calificacion 
 (
  [id_eval_poseedor] ASC
 )
GO

CREATE NONCLUSTERED INDEX [fkIdx_estudiante_calificacion] ON Calificacion 
 (
  [id_estudiante] ASC
 )
GO

-- **** DATOS ****



insert into rol (nombre, descripcion, estado_sql) values ('Estudiante', 'detalle', 1);
insert into rol (nombre, descripcion, estado_sql) values ('Administrador', 'detalle', 1);
insert into rol (nombre, descripcion, estado_sql) values ('Profesor', 'detalle', 1);
insert into rol (nombre, descripcion, estado_sql) values ('Representante', 'detalle', 1);

insert into usuario (nombre, clave, estado, entidad, id_ref, id_rol, estado_sql) values ('claudia', 'claudia', 'activo', 'estudiante', 1, 1, 1 );

insert into representante (cedulaIdentidad, complemento, expedido, apPaterno, apMaterno, nombres, idiomaFrecuente, ocupacionLaboral, gradoInstruccion, fechaNacimiento, parentesco, telefono, celular, estado_sql) 
    values ('5044224','CN', 'Tj', 'Figueroa', 'Daza', 'Claudia Valeria', 'Español', 'Secretaria', 'Tecnico superior', '19-07-80', 'Madre', '66-52733', '78704331', 1);

insert into periodo (nombre, fechaInicio, fechaFin, estado, descripcion, estado_sql) 
    values ('Primer trimestre', '01-02-21', '01-04-21', 'activo', 'detalle', 1 );

insert into paralelo (nombre, estado_sql) 
    values ('A', 1 );

insert into curso (nombre, nivel, turno, descripcion, id_paralelo, estado_sql) 
    values ('primero', 'primaria', 'mañana', 'detalle', 1, 1 );

insert into estudiante (apPaterno ,apMaterno, nombres, fechaNacimiento,cedulaIdentidad, telefono,celular, id_curso, id_periodo, estado_sql) 
    values ('Gonzales','Figueroa','Claudia Jerissa','28-12-98','10664565','66-41332','69303525',1,1,1 );

insert into rude (codSieue, pais, departamento, provincia, localidad, oficialia,
    libro, partida, folio, complemento, expedido, codRude, sexo, discapacidad, numDiscapacidad, tipoDiscapacidad,
    gradoDiscapacidad, departamentoEst, provinciaEst, seccionEst, localidadEst, zonaEst, avenidaEst, numViviendaEst,idiomaNiniez,
    idiomaFrecuente, nacion, centroSalud, problemaSalud, frecuenciaCs,seguroCs, agua, banio, alcantarillado,
    energiaElectrica, servBasura, vivienda, internet, frecuenciaInternet, trabajo, mesesTrabajo, actividadTrabajo, turnoTrabajo,
    frecuenciaTrabajo, pagoTrabajo, tipoPago, medioTransporte, tiempoTransporte, abandonoUe, razonAbandono, fechaRegistro, lugarRegistro,
    id_representante_padre, id_representante_madre, id_representante_tutor, id_estudiante, estado_sql) 
    values ('00730790','Bolivia','Tarija','Cercado','Tarija','75/1',35,1324,23,'CN','Tarija','548434233',1,0,0,'-','grado','Tarija',
    'Cercado','Cercado','Tarija','Pampa Galana','B/Monte Cristo','s/n','Español','Español','Bolivia',1,'No','Alta',1,1,1,1,1,1,'vivienda','internet','Frecuencia',0,'2 meses',
    'actividad','turno','frecuencia trabajo',0,0,'auto particular','15 min',0,'razon abandono','01-01-2021','Unidad Educativa',1,1,1,1,1 );


-- **** DATOS ****
insert into fotos (descripcion, path_img, id_estudiante, estado_sql) 
    values ('detalle', 'path_img', 1, 1 );

-- **** DATOS ****
insert into parametro (nombre, valor, estado_sql) 
    values ('parametro', 'detalle',  1 );

-- **** DATOS ****
insert into institucion (codUe, nombreUe, numResolucionAdm1, fechaResolucionAdm1 , codDistritoEducativo , nombreDistritoEducativo,
    numResolucionAdm2, fechaResolucionAdm2,codEdificioEscolar, nuevoCodEdificioEscolar, departamento, provincia,
    seccionMunicipal, canton, ciudad, zona, direccion, estatal, convenio, nombreInstitucion, comunitaria, privada,
    edFormal, edInicial, edPrimaria, edSecundaria, edAlternativa, edAdultos, edEspecial, edPermanente, bachillerato,
    humanistico, tecnico, siglas, latitud, longitud, correo, telefono1, telefono2, celular1, celular2, web, descripcion,
    lugarRecepcion, fechaRecepcion, estado_sql) 
    values ('4487644', 'Santa Ana', 12, '01-01-21', 14, 'Nombre distrito UE', 15, '01-01-2021', 'codigo edificio escolar',
        'codigo edificio escolar', 'Tarija', 'Cercado', 'Cercado', 'canton', 'Tarija', 'Pampa Galana', 'Z/Pampa Galana',
        0,1, 'UE Santa Ana', 1,0,1,1,1,1,0,0,0,0,1,1,0, 'CSA', -12.5, -14.4, 'santaana@gmail.com', '6684556','6687452', '655452150',
         '78456266', 'sanataana.com', 'detalle', 'Unidad Educativa', '01-01-2021', 1);

insert into profesor (cedulaIdentidad, apPaterno, apMaterno, nombres, sexo, RDA, CAS, tituloProvNacional, tituloProfesional,
posgrado, idiomaFrecuente, telefono, celular, correo, estado_sql) 
    values ('5048955', 'Almazan', 'Rios', 'Nataly', 1, 1, 1, 'Licenciado en ciencias matemáticas', 'Licenciado en ciencias matemáticas',
    'posgrado', 'español', '6689425','60258654', 'profnataly@gmail.com', 1 );

insert into calendario (nombre, fecha, lugar, descripcion, id_periodo, estado_sql) 
    values ('Aniversario del colegio', '15-05-2021', 'Colegio', 'detalle',1, 1 );

insert into notificacion(nombre, descripcion, fecha, id_curso, id_profesor, estado_sql) 
    values ('Practico Nº 5', 'Realizar la pag 35-36-37', '01-05-2021', 1, 1, 1 );

insert into horario (dia, horaInicio, horaFin, estado_sql) 
    values ('Lunes', '07:00', '09:30', 1 );

insert into materia (sigla, nombre, nivel, descripcion, estado_sql) 
    values ('MAT-101', 'Matematicas', 'primaria', 'detalle', 1 );

insert into materiaDictada (descripcion, id_materia, id_curso, id_profesor, id_horario, id_periodo, estado_sql) 
    values ('Detalle', 1,1,1,1,1,1 );

insert into estudianteMateria (id_materia, id_estudiante, id_horario, id_periodo, estado_sql) 
    values (1,1,1,1,1 );

insert into asistencia (fecha, estado, descripcion, id_estudiante, id_materia, id_periodo, estado_sql) 
    values ('01-02-2021', 'Presente', 'detalle', 1,1,1,1 );

insert into categoria (nombre, descripcion, estado_sql) 
    values ('Evaluacion', 'Detalle', 1 );
insert into categoria (nombre, descripcion, estado_sql) 
    values ('Autoevaluacion', 'Detalle', 1 );
insert into categoria (nombre, descripcion, estado_sql) 
    values ('Evaluacion a Alumno', 'Detalle', 1 );
insert into categoria (nombre, descripcion, estado_sql) 
    values ('Actividad', 'Detalle', 1 );

insert into nota (fecha, nota, descripcion, id_curso, id_periodo, id_materia, id_categoria, id_ref, estado_sql) 
    values ('2021-01-01', 85, 'detalle', 1,1,1,1,1,1 );

insert into autoevaluacion (notaSer, notaDecidir, id_eval_poseedor, estado_sql) 
    values (25, 12, 1, 1 );

insert into evaluacionProfesor (notaSer, notaDecidir, id_estudiante, id_eval_poseedor, estado_sql) 
    values (18, 15, 1, 1, 1 );

insert into calificacion (nota, id_estudiante, id_eval_poseedor, estado_sql) values (30,1,1, 1);