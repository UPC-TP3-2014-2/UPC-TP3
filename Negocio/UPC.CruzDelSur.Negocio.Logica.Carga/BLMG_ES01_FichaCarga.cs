using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UPC.CruzDelSur.Negocio.Logica.Carga
{
    public class BLMG_ES01_FichaCarga
    {

        public static BEMG_ES01_FichaCarga ListarUnoMG_ES01_FichaCarga(List<ParametroGenerico> _ArrayParam)
        {
            DAMG_ES01_FichaCarga oDAMG_ES01_FichaCarga = new DAMG_ES01_FichaCarga();
            return oDAMG_ES01_FichaCarga.ListarUnoMG_ES01_FichaCarga(null, _ArrayParam);
        }
        public static List<BEMG_ES01_FichaCarga> ListarMG_ES01_FichaCarga(List<ParametroGenerico> _ArrayParam)
        {
            DAMG_ES01_FichaCarga oDAMG_ES01_FichaCarga = new DAMG_ES01_FichaCarga();
            return oDAMG_ES01_FichaCarga.ListarMG_ES01_FichaCarga(null, _ArrayParam);
        }
        public static int  InsertarMG_ES01_FichaCarga(BEMG_ES01_FichaCarga _BEMG_ES01_FichaCarga, List<BEMG_ES02_DetalleFCarga> _loBEMG_ES02_DetalleFCarga)
        
        { 
            Conexion _Connection = new Conexion();
            SqlConnection Cn = new SqlConnection();
            Cn = _Connection.ConexionCruzDelSur();

            int inser;
            using (Cn)
            {
                SqlTransaction Tr = null;
                try
                {
                    Cn.Open();
                    Tr = Cn.BeginTransaction();
                    

                    DAMG_ES01_FichaCarga oDAMG_ES01_FichaCarga = new DAMG_ES01_FichaCarga();
                    inser =  oDAMG_ES01_FichaCarga.InsertarMG_ES01_FichaCarga(Cn, Tr, _BEMG_ES01_FichaCarga);

                    DABEMG_ES02_DetalleFCarga oDABEMG_ES02_DetalleFCarga = new DABEMG_ES02_DetalleFCarga();
                    BEMG_ES02_DetalleFCarga _BEMG_ES02_DetalleFCarga = new BEMG_ES02_DetalleFCarga();
                    _BEMG_ES02_DetalleFCarga.MG_ES01_FichaCarga_ID = inser;
                    inser = oDABEMG_ES02_DetalleFCarga.EliminarMG_ES02_DetalleFCarga(Cn, Tr, _BEMG_ES02_DetalleFCarga);

                    for (int Fila = 0; Fila < _loBEMG_ES02_DetalleFCarga.Count; Fila++)
                    {
                        BEMG_ES02_DetalleFCarga oBEMG_ES02_DetalleFCarga = new BEMG_ES02_DetalleFCarga();

                        oBEMG_ES02_DetalleFCarga.MG_ES01_FichaCarga_ID = _BEMG_ES02_DetalleFCarga.MG_ES01_FichaCarga_ID;
                        oBEMG_ES02_DetalleFCarga.Cantidad = Convert.ToInt32(_loBEMG_ES02_DetalleFCarga[Fila].Cantidad );
                        oBEMG_ES02_DetalleFCarga.Descripcion  = _loBEMG_ES02_DetalleFCarga[Fila].Descripcion ;
                        oBEMG_ES02_DetalleFCarga.Importe  = Convert.ToDouble(_loBEMG_ES02_DetalleFCarga[Fila].Importe);
                        oBEMG_ES02_DetalleFCarga.TipoCarga  = _loBEMG_ES02_DetalleFCarga[Fila].TipoCarga ;
                        oBEMG_ES02_DetalleFCarga.Peso  = Convert.ToInt32(_loBEMG_ES02_DetalleFCarga[Fila].Peso);
                        oBEMG_ES02_DetalleFCarga.MG_ES03_Producto_ID  = Convert.ToInt32(_loBEMG_ES02_DetalleFCarga[Fila].MG_ES03_Producto_ID);
                        oBEMG_ES02_DetalleFCarga.Producto = _loBEMG_ES02_DetalleFCarga[Fila].Producto;


                        oDABEMG_ES02_DetalleFCarga.InsertarMG_ES02_DetalleFCarga(Cn, Tr, oBEMG_ES02_DetalleFCarga);
                    }

                    //SEGU.DataAccess.DAUsuarioRol oDAUsuarioRol = new SEGU.DataAccess.DAUsuarioRol();
                    //SEGU.Entities.ENUsuarioRol oBEUsuarioRol = new SEGU.Entities.ENUsuarioRol();
                    //oBEUsuarioRol.IdUsuario.IdUsuario = oBEUsuario.IdUsuario;
                    //oDAUsuarioRol.Eliminar(Cn, Tr, oBEUsuarioRol);

                    //for (int Fila = 0; Fila < ListaUsuarioRol.Count; Fila++)
                    //{
                    //    SEGU.Entities.ENUsuarioRol objUsuarioRol = new SEGU.Entities.ENUsuarioRol();
                    //    objUsuarioRol.IdUsuario.IdUsuario = oBEUsuario.IdUsuario;
                    //    objUsuarioRol.IdRol.IdRol = Convert.ToInt32(ListaUsuarioRol[Fila].IdRol.IdRol);
                    //    objUsuarioRol.Principal = Convert.ToString(ListaUsuarioRol[Fila].Principal);
                    //    objUsuarioRol.Anulado = Convert.ToString(ListaUsuarioRol[Fila].Anulado);
                    //    oDAUsuarioRol.Grabar(Cn, Tr, objUsuarioRol);
                    //}

                    //SEGU.DataAccess.DAUsuarioEmpresa oDAUsuarioEmpresa = new SEGU.DataAccess.DAUsuarioEmpresa();
                    //SEGU.Entities.ENUsuarioEmpresa oBEUsuarioEmpresa = new SEGU.Entities.ENUsuarioEmpresa();
                    //oBEUsuarioEmpresa.IdUsuario.IdUsuario = oBEUsuario.IdUsuario;
                    //oDAUsuarioEmpresa.Eliminar(Cn, Tr, oBEUsuarioEmpresa);
                    //for (int Fila = 0; Fila < ListaUsuarioEmpresa.Count; Fila++)
                    //{
                    //    SEGU.Entities.ENUsuarioEmpresa obj = new SEGU.Entities.ENUsuarioEmpresa();
                    //    obj.IdUsuario.IdUsuario = oBEUsuario.IdUsuario;
                    //    obj.IdEmpresa.IdEmpresa = Convert.ToInt32(ListaUsuarioEmpresa[Fila].IdEmpresa.IdEmpresa);
                    //    obj.Anulado = Convert.ToString(ListaUsuarioEmpresa[Fila].Anulado);
                    //    oDAUsuarioEmpresa.InsertaActualiza(Cn, Tr, obj);
                    //}

                    //SEGU.DataAccess.DAUsuarioLocal oDAUsuarioLocal = new SEGU.DataAccess.DAUsuarioLocal();
                    //SEGU.Entities.ENUsuarioLocal oBEUsuarioLocal = new SEGU.Entities.ENUsuarioLocal();
                    //oBEUsuarioLocal.IdUsuario.IdUsuario = oBEUsuario.IdUsuario;
                    //oDAUsuarioLocal.Eliminar(Cn, Tr, oBEUsuarioLocal);

                    //for (int Fila = 0; Fila < ListaUsuarioLocal.Count; Fila++)
                    //{
                    //    SEGU.Entities.ENUsuarioLocal objUsuarioLocal = new SEGU.Entities.ENUsuarioLocal();
                    //    objUsuarioLocal.IdUsuario.IdUsuario = oBEUsuario.IdUsuario;
                    //    objUsuarioLocal.IdLocal.IdLocal = Convert.ToInt32(ListaUsuarioLocal[Fila].IdLocal.IdLocal);
                    //    objUsuarioLocal.Principal = ListaUsuarioLocal[Fila].Principal;
                    //    objUsuarioLocal.Anulado = Convert.ToString(ListaUsuarioLocal[Fila].Anulado);
                    //    oDAUsuarioLocal.Grabar(Cn, Tr, objUsuarioLocal);
                    //}

                    //inser = oDAUsuario.Actualiza(Cn, Tr, oBEUsuario);
                    Tr.Commit();
                    
                }
                catch (Exception ex)
                {
                    Tr.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //if( (Cn.State == ConnectionState.Open) ) Cn.Close();
                }

                return inser;
            }
        }
    }
}
