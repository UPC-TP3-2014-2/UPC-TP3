using UPC.CruzDelSur.Negocio.Modelo;

namespace UPC.CruzDelSur.Datos.Contratos
{
    public interface IPersonasRepositorio : IRepositorio<Persona>
    {
        Persona ObtenerPorDNI(string dni);
    }
}