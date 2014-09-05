using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UPC.CruzDelSur.Negocio.Logica.Carga
{
    public class BLBitacora
    {
        public Conexion _Connection = new Conexion();

        public int InsertarBitacora(BEBitacora _BEBitacora, List<BEDetalleBitacora> _loBEDetalleBitacora)
        {
            SqlConnection Cn = new SqlConnection(); Cn = _Connection.ConexionCruzDelSur();

            using (Cn)
            {
                SqlTransaction Tr = null;
                try
                {
                    Cn.Open();
                    Tr = Cn.BeginTransaction();
                    int inser;

                    DABitacora oDABitacora = new DABitacora();
                    inser =  oDABitacora.InsertarBitacora(Cn, Tr, _BEBitacora);

                    //SEGU.DataAccess.DAUsuarioPais oDAUsuarioPais = new SEGU.DataAccess.DAUsuarioPais();
                    //SEGU.Entities.ENUsuarioPais oBEUsuarioPais = new SEGU.Entities.ENUsuarioPais();
                    //oBEUsuarioPais.IdUsuario.IdUsuario = oBEUsuario.IdUsuario;
                    //oDAUsuarioPais.Eliminar(Cn, Tr, oBEUsuarioPais);

                    //for (int Fila = 0; Fila < ListaUsuarioPais.Count; Fila++)
                    //{
                    //    SEGU.Entities.ENUsuarioPais objUsuarioPais = new SEGU.Entities.ENUsuarioPais();
                    //    objUsuarioPais.IdUsuario.IdUsuario = oBEUsuario.IdUsuario;
                    //    objUsuarioPais.IdPais.IdPais = Convert.ToInt32(ListaUsuarioPais[Fila].IdPais.IdPais);
                    //    objUsuarioPais.Principal = Convert.ToString(ListaUsuarioPais[Fila].Principal);
                    //    objUsuarioPais.Anulado = Convert.ToString(ListaUsuarioPais[Fila].Anulado);
                    //    oDAUsuarioPais.Grabar(Cn, Tr, objUsuarioPais);
                    //}

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
                    return inser;
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


            }

        }

    }
}
