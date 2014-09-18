using System;
using System.Data.Entity;
using System.Data.SqlTypes;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.DataDeEjemplo
{
    public abstract class SeedBase
    {
        protected const string TiempoCompleto = "Tiempo Completo";
        protected const string Inmediato = "Inmediato";
        protected static readonly DateTime Date = (DateTime) SqlDateTime.MinValue;

        protected readonly Area Finanzas = new Area{Nombre = "Finanzas"};
        protected readonly Area RecursosHumanos = new Area{Nombre = "Recursos Humanos"};
        protected readonly Area Operaciones = new Area{Nombre = "Operaciones"};
        protected readonly Area Mantenimiento = new Area{Nombre = "Mantenimiento"};
        protected readonly Area Logistica = new Area{Nombre = "Logística"};
        
        protected readonly TipoEducacion Tecnico = new TipoEducacion {Nombre = "Técnico"};
        protected readonly TipoEducacion Universitario = new TipoEducacion {Nombre = "Universitario"};
        protected readonly TipoEducacion PostGrado = new TipoEducacion {Nombre = "Post-Grado"};

        protected readonly TipoDocumento Dni = new TipoDocumento {Nombre = "DNI"};
        protected readonly TipoDocumento CarneExtranjeria = new TipoDocumento {Nombre = "Carne de Extranjeria"};

        protected readonly Cargo Conductor = new Cargo {Nombre = "Conductor"};
        protected readonly Cargo EncargadoLogistica = new Cargo {Nombre = "Encargado de Logística"};
        protected readonly Cargo Gerente = new Cargo {Nombre = "Gerente"};

        protected readonly Capacitacion BusesScania = new Capacitacion {Nombre = "Buses Scania", Duracion = 16};
        protected readonly Capacitacion CamionesScania = new Capacitacion {Nombre = "Camiones Scania", Duracion = 24};
        protected readonly Capacitacion BusesVolvo = new Capacitacion {Nombre = "Buses Volvo", Duracion = 20};
        protected readonly Capacitacion CamionesVolvo = new Capacitacion {Nombre = "Camiones Volvo", Duracion = 30};
        protected readonly Capacitacion BusesMercedesBenz = new Capacitacion
        {
            Nombre = "Buses Mercedes Benz",
            Duracion = 8
        };
        protected readonly Capacitacion CamionesMercedesBenz = new Capacitacion
        {
            Nombre = "Camiones Mercedes Benz",
            Duracion = 12
        };
        protected readonly Capacitacion SeguridadVial = new Capacitacion {Nombre = "Seguridad Vial", Duracion = 16};
        protected readonly Capacitacion PrimerosAuxilios = new Capacitacion {Nombre = "Primeros Auxilios", Duracion = 8};

        public virtual void Seed(DbContext context)
        {
            SeedAreas(context);
            SeedTiposDocumento(context);
            SeedTiposEducacion(context);
            SeedCargos(context);
            SeedCapacitaciones(context);
        }

        private void SeedAreas(DbContext context)
        {
            context.Set<Area>().AddRange(new[]
            {
                Finanzas,
                RecursosHumanos,
                Operaciones,
                Mantenimiento,
                Logistica
            });

            context.SaveChanges();
        }

        private void SeedCapacitaciones(DbContext context)
        {
            context.Set<Capacitacion>().AddRange(new[]
            {
                BusesScania,
                CamionesScania,
                BusesVolvo,
                CamionesVolvo,
                BusesMercedesBenz,
                CamionesMercedesBenz,
                SeguridadVial,
                PrimerosAuxilios
            });

            context.SaveChanges();
        }

        private void SeedTiposEducacion(DbContext context)
        {
            context.Set<TipoEducacion>().AddRange(new[]
            {
                Tecnico,
                Universitario,
                PostGrado
            });

            context.SaveChanges();
        }

        private void SeedTiposDocumento(DbContext context)
        {
            context.Set<TipoDocumento>().AddRange(new[]
            {
                Dni,
                CarneExtranjeria
            });

            context.SaveChanges();
        }

        private void SeedCargos(DbContext context)
        {
            context.Set<Cargo>().AddRange(new[]
            {
                Conductor,
                EncargadoLogistica,
                Gerente
            });

            context.SaveChanges();
        }
    }
}