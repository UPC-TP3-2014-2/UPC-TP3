using System;
using System.Data.Entity;
using System.Data.SqlTypes;
using UPC.CruzDelSur.Negocio.Modelo.Personal;

namespace UPC.CruzDelSur.Datos.Personal.DataDeEjemplo
{
    public abstract class SeedBase
    {
        protected static readonly DateTime Date = (DateTime)SqlDateTime.MinValue;

        protected readonly string PostGrado = "Post-Grado";

        protected readonly TipoDocumento Dni = new TipoDocumento { Nombre = "DNI" };
        protected readonly TipoDocumento CarneExtranjeria = new TipoDocumento { Nombre = "Carne de Extranjeria" };
        protected readonly Cargo Conductor = new Cargo {Nombre = "Conductor"};
        protected readonly Cargo Gerente = new Cargo {Nombre = "Gerente"};

        public virtual void Seed(DbContext context)
        {
            SeedTiposDocumento(context);
            SeedCargos(context);
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