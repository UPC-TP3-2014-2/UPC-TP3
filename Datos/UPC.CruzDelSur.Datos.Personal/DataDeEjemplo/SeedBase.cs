using System;
using System.Data.Entity;
using System.Data.SqlTypes;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.DataDeEjemplo
{
    public abstract class SeedBase
    {
        protected static readonly DateTime Date = (DateTime) SqlDateTime.MinValue;

        protected readonly string PostGrado = "Post-Grado";

        protected readonly TipoDocumento Dni = new TipoDocumento {Nombre = "DNI"};
        protected readonly TipoDocumento CarneExtranjeria = new TipoDocumento {Nombre = "Carne de Extranjeria"};

        protected readonly Cargo Conductor = new Cargo {Nombre = "Conductor"};
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
            SeedTiposDocumento(context);
            SeedCargos(context);
            SeedCapacitaciones(context);
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
                Gerente
            });

            context.SaveChanges();
        }
    }
}