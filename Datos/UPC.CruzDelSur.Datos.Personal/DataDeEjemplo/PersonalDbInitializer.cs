using System.Data.Entity;

namespace UPC.CruzDelSur.Datos.Personal.DataDeEjemplo
{
    public class PersonalDbInitializer : DropCreateDatabaseAlways<PersonalDbContext>
    {
        private readonly SeedBase _seed;

        public PersonalDbInitializer()
        {
            _seed = new TheBigBangTheory();
        }

        protected override void Seed(PersonalDbContext context)
        {
            _seed.Seed(context);
        }
    }
}