namespace UPC.CruzDelSur.Negocio.Modelo.Carga
{
    public class BEDetalleBitacora
    {
        public int IdDetalleBitacora { get; set; }
        public string	Descripcion { get; set; }
        BETipoIncidencia	IdTipoIncidencia { get; set; }
        BEBitacora IdBitacora { get; set; }

        public BEDetalleBitacora()
        {
            IdDetalleBitacora = -1;
            Descripcion = "";
            IdTipoIncidencia = new BETipoIncidencia();
            IdBitacora = new BEBitacora();
         }
    }
}
