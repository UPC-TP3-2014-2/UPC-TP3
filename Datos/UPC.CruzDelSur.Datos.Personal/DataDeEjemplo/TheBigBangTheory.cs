using System;
using System.Collections.Generic;
using System.Data.Entity;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.DataDeEjemplo
{
    public class TheBigBangTheory : SeedBase
    {
        private Persona _sheldon;
        private Persona _leonard;
        private Persona _howard;

        public override void Seed(DbContext context)
        {
            base.Seed(context);

            SeedPersonas(context);
            SeedSolicitudesCapacitacion(context);
            SeedSolicitudesPersonal(context);
        }

        private void SeedPersonas(DbContext context)
        {
            _sheldon = new Persona
            {
                TipoDocumento = CarneExtranjeria,
                NroDocumento = "88756213",
                Nombre = "Sheldon",
                Apellidos = "Cooper",
                FechaNacimiento = new DateTime(1985, 04, 27),
                Foto = "Sheldon_Cooper.jpg",
                Cargo = Gerente,
                DetallesHojaVida = new List<DetalleHojaVida>
                {
                    new ExperienciaLaboral
                    {
                        Desde = new DateTime(2005, 03, 01),
                        Cargo = "Fisico teorico",
                        Institucion = "Caltech",
                        Observaciones = "Investigacion en teoria de cuerdas"
                    },
                    new Educacion
                    {
                        Desde = new DateTime(2001, 07, 10),
                        Hasta = new DateTime(2003, 08, 04),
                        Tipo = PostGrado,
                        GradoObtenido = "DsC",
                        Institucion = "Harvard"
                    },
                    new Educacion
                    {
                        Desde = new DateTime(1999, 05, 10),
                        Hasta = new DateTime(2001, 06, 01),
                        Tipo = PostGrado,
                        GradoObtenido = "PhD",
                        Institucion = "Harvard",
                        Observaciones = "Graduado a los 16 años"
                    },
                    new Educacion
                    {
                        Desde = new DateTime(1997, 08, 20),
                        Hasta = new DateTime(1999, 01, 19),
                        Tipo = PostGrado,
                        GradoObtenido = "MsC",
                        Institucion = "Harvard"
                    }
                }
            };

            _leonard = new Persona
            {
                TipoDocumento = CarneExtranjeria,
                NroDocumento = "25478952",
                Nombre = "Leonard",
                Apellidos = "Hofstadter",
                FechaNacimiento = new DateTime(1982, 07, 20),
                Foto = "Leonard_Hofstadter.jpg",
                Cargo = Conductor,
                DetallesHojaVida = new List<DetalleHojaVida>
                {
                    new ExperienciaLaboral
                    {
                        Desde = new DateTime(2007, 08, 29),
                        Cargo = "Fisico experimental",
                        Institucion = "Caltech"
                    },
                    new Educacion
                    {
                        Desde = new DateTime(2003, 05, 10),
                        Hasta = new DateTime(2006, 06, 01),
                        Tipo = PostGrado,
                        GradoObtenido = "PhD",
                        Institucion = "Stanford",
                    },
                    new Educacion
                    {
                        Desde = new DateTime(2000, 08, 20),
                        Hasta = new DateTime(2002, 01, 19),
                        Tipo = PostGrado,
                        GradoObtenido = "MsC",
                        Institucion = "Stanford"
                    }
                }
            };

            _howard = new Persona
            {
                TipoDocumento = CarneExtranjeria,
                NroDocumento = "54875123",
                Nombre = "Howard",
                Apellidos = "Wolowitz",
                FechaNacimiento = new DateTime(1987, 06, 10),
                Foto = "Howard_Wolowitz.jpg",
                Cargo = Conductor,
                DetallesHojaVida = new List<DetalleHojaVida>
                {
                    new ExperienciaLaboral
                    {
                        Desde = new DateTime(2008, 03, 18),
                        Cargo = "Ingeniero Espacial",
                        Institucion = "Caltech"
                    },
                    new Educacion
                    {
                        Desde = new DateTime(2002, 08, 01),
                        Hasta = new DateTime(2007, 01, 25),
                        Tipo = PostGrado,
                        GradoObtenido = "Master",
                        Institucion = "MIT"
                    }
                }
            };

            context.Set<Persona>().AddRange(new[]
            {
                _sheldon,
                _leonard,
                _howard
            });

            context.SaveChanges();
        }

        private void SeedSolicitudesCapacitacion(DbContext context)
        {
            context.Set<SolicitudCapacitacion>().AddRange(new[]
            {
                new SolicitudCapacitacion
                {
                    FechaRegistro = new DateTime(2014, 08, 02),
                    FechaPlanificada = new DateTime(2014, 08, 25),
                    Capacitacion = SeguridadVial,
                    Trabajador = _howard,
                    Observaciones = "Soliciado por la persona, aprovechando la capacitacion ya planificada para nuevo proyecto"
                }, 
                new SolicitudCapacitacion
                {
                    FechaRegistro = new DateTime(2014, 08, 01),
                    FechaPlanificada = new DateTime(2014, 08, 25),
                    Capacitacion = BusesScania,
                    Trabajador = _leonard,
                    Observaciones = "Capacitacion urgente para nuevo proyecto"
                },
                new SolicitudCapacitacion
                {
                    FechaRegistro = new DateTime(2014, 05, 20),
                    FechaPlanificada = new DateTime(2014, 09, 01),
                    Capacitacion = CamionesVolvo,
                    Trabajador = _howard,
                    Observaciones = "Solicitado por la misma persona"
                }
            });

            context.SaveChanges();
        }

        private void SeedSolicitudesPersonal(DbContext context)
        {
            context.Set<SolicitudPersonal>().AddRange(new[]
            {
                new SolicitudPersonal
                {
                    FechaRegistro = new DateTime(2014, 09, 15),
                    FechaVencimiento = new DateTime(2014, 10, 15),
                    Area = Logistica,
                    Cargo = EncargadoLogistica,
                    Salario = 25000,
                    Inicio = Inmediato,
                    Contrato = TiempoCompleto,
                    TipoEducacion = Universitario,
                    EducacionDescripcion = "Administracion, Ingeniería industrial",
                    ExperienciaLaboral = "Preferentemente con 4 años de experiencia en gerencia de operaciones y logística",
                    Requisitos = "Manejo avanzado de Microsoft Office (Excel, Word, Power Point)",
                    Funciones = @"
1. Elaborar un plan estratégico para el Área Logística.
2. Reclutar y capacitar al personal adecuado para los diferentes puestos en el departamento.
3. Realizar las evaluaciones de personal y dar retroalimentación a cada miembro del equipo con un plan de acción para mejorar el desempeño y motivación del equipo.
4. Controlar la implementación de buenas prácticas y las recomendaciones de nuestros socios comerciales (Proveedores de Mercaderías etc.).
5. Asegurar el abastecimiento eficiente a cada Sucursal de todos los productos que comercializamos
"
                }
            });

            context.SaveChanges();
        }
    }
}