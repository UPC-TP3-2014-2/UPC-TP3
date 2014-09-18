namespace UPC.CruzDelSur.Negocio.Modelo.Personal
{
    public class Cargo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
    }
}