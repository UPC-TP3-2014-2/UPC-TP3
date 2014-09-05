using System;
using System.Data;

namespace UPC.CruzDelSur.Datos.Carga.Funciones
{
    class Populate
    {

        private UCMapeador ValidExistColumn = new UCMapeador();

        public BETipoIncidencia setBETipoIncidencia(IDataReader _dr)
        {

            BETipoIncidencia _Entity = new BETipoIncidencia();

            if (ValidExistColumn.HasColumn(_dr, "IdTipoIncidencia")) { _Entity.IdTipoIncidencia = Convert.ToInt32(_dr["IdTipoIncidencia"]); }
            if (ValidExistColumn.HasColumn(_dr, "Descripcion")) { _Entity.Descripcion = Convert.ToString(_dr["Descripcion"]); }
            if (ValidExistColumn.HasColumn(_dr, "Estado")) { _Entity.Estado = Convert.ToString(_dr["Estado"]); }
            if (ValidExistColumn.HasColumn(_dr, "FechaRegistra")) { _Entity.FechaRegistra = Convert.ToDateTime(_dr["FechaRegistra"]); }
            if (ValidExistColumn.HasColumn(_dr, "UsuarioRegistra")) { _Entity.UsuarioRegistra = Convert.ToString(_dr["UsuarioRegistra"]); }
            if (ValidExistColumn.HasColumn(_dr, "FechaModifica")) { _Entity.FechaModifica = Convert.ToDateTime(_dr["FechaModifica"]); }
            if (ValidExistColumn.HasColumn(_dr, "UsuarioModifica")) { _Entity.UsuarioModifica = Convert.ToString(_dr["UsuarioModifica"]); }

            return _Entity;

        }

        public BERuta setBERuta(IDataReader _dr)
        {

            BERuta _Entity = new BERuta();

            if (ValidExistColumn.HasColumn(_dr, "IdRuta")) { _Entity.IdRuta = Convert.ToInt32(_dr["IdRuta"]); }
            if (ValidExistColumn.HasColumn(_dr, "Descripcion")) { _Entity.Descripcion = Convert.ToString(_dr["Descripcion"]); }
            if (ValidExistColumn.HasColumn(_dr, "Origen")) { _Entity.Origen = Convert.ToString(_dr["Origen"]); }
            if (ValidExistColumn.HasColumn(_dr, "Destino")) { _Entity.Destino = Convert.ToString(_dr["Destino"]); }
            if (ValidExistColumn.HasColumn(_dr, "Estado")) { _Entity.Estado = Convert.ToString(_dr["Estado"]); }
            if (ValidExistColumn.HasColumn(_dr, "Directo")) { _Entity.Directo = Convert.ToInt32(_dr["Directo"]); }
            if (ValidExistColumn.HasColumn(_dr, "FechaRegistra")) { _Entity.FechaRegistra = Convert.ToDateTime(_dr["FechaRegistra"]); }
            if (ValidExistColumn.HasColumn(_dr, "UsuarioRegistra")) { _Entity.UsuarioRegistra = Convert.ToString(_dr["UsuarioRegistra"]); }
            if (ValidExistColumn.HasColumn(_dr, "FechaModifica")) { _Entity.FechaModifica = Convert.ToDateTime(_dr["FechaModifica"]); }
            if (ValidExistColumn.HasColumn(_dr, "UsuarioModifica")) { _Entity.UsuarioModifica = Convert.ToString(_dr["UsuarioModifica"]); }

            return _Entity;

        }

        public BEMG_ES04_Cliente SetMG_ES04_Cliente(IDataReader _dr)
        {
            BEMG_ES04_Cliente _Entity = new BEMG_ES04_Cliente();
            if (ValidExistColumn.HasColumn(_dr, "NroCliente")) { _Entity.NroCliente = Convert.ToInt32(_dr["NroCliente"]); }
            if (ValidExistColumn.HasColumn(_dr, "Documento")) { _Entity.Documento = _dr["Documento"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "TipoDocumento")) { _Entity.TipoDocumento = _dr["TipoDocumento"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Nombres")) { _Entity.Nombres = _dr["Nombres"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Apellidos")) { _Entity.Apellidos = _dr["Apellidos"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Direccion")) { _Entity.Direccion = _dr["Direccion"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Telefono")) { _Entity.Telefono = _dr["Telefono"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "TipoCliente")) { _Entity.TipoCliente = _dr["TipoCliente"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Puntaje")) { _Entity.Puntaje = Convert.ToInt32(_dr["Puntaje"]); }
            if (ValidExistColumn.HasColumn(_dr, "NroTarjeta")) { _Entity.NroTarjeta = Convert.ToInt32(_dr["NroTarjeta"]); }
            if (ValidExistColumn.HasColumn(_dr, "FechaRegistra")) { _Entity.FechaRegistra = Convert.ToDateTime(_dr["FechaRegistra"]); }
            if (ValidExistColumn.HasColumn(_dr, "UsuarioRegsitra")) { _Entity.UsuarioRegsitra = _dr["UsuarioRegsitra"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "FechaModifica")) { _Entity.FechaModifica = Convert.ToDateTime(_dr["FechaModifica"]); }
            if (ValidExistColumn.HasColumn(_dr, "UsuarioModifica")) { _Entity.UsuarioModifica = _dr["UsuarioModifica"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "MG_ES04_Cliente_ID")) { _Entity.MG_ES04_Cliente_ID = Convert.ToInt32(_dr["MG_ES04_Cliente_ID"]); }
            return _Entity;
        }

        public BEMK_ProgramacionRuta SetMK_ProgramacionRuta(IDataReader _dr)
        {
            BEMK_ProgramacionRuta _Entity = new BEMK_ProgramacionRuta();
            if (ValidExistColumn.HasColumn(_dr, "FechaHoraOrigen")) { _Entity.FechaHoraOrigen = Convert.ToDateTime(_dr["FechaHoraOrigen"]); }

            if (ValidExistColumn.HasColumn(_dr, "FechaHoraDestino")) { _Entity.FechaHoraDestino = Convert.ToDateTime(_dr["FechaHoraDestino"]); }
            if (ValidExistColumn.HasColumn(_dr, "MK_ProgramacionRuta_ID")) { _Entity.MK_ProgramacionRuta_ID = Convert.ToInt32(_dr["MK_ProgramacionRuta_ID"]); }
            if (ValidExistColumn.HasColumn(_dr, "MK_Ruta_ID")) { _Entity.MK_Ruta_ID = Convert.ToInt32(_dr["MK_Ruta_ID"]); }
            if (ValidExistColumn.HasColumn(_dr, "Descripcion")) { _Entity.Descripcion = _dr["Descripcion"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Origen")) { _Entity.Origen = _dr["Origen"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Destino")) { _Entity.Destino = _dr["Destino"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "MG_ES10_Agencia_ID")) { _Entity.MG_ES10_Agencia_ID = Convert.ToInt32(_dr["MG_ES10_Agencia_ID"]); }
            if (ValidExistColumn.HasColumn(_dr, "MG_ES10_Agencia_T_MG_ES10_Agencia_ID")) { _Entity.MG_ES10_Agencia_T_MG_ES10_Agencia_ID = Convert.ToInt32(_dr["MG_ES10_Agencia_T_MG_ES10_Agencia_ID"]); }
            
            return _Entity;
        }


        public BEMG_ES03_Producto SetMG_ES03_Producto(IDataReader _dr)
        {
            BEMG_ES03_Producto _Entity = new BEMG_ES03_Producto();
            if (ValidExistColumn.HasColumn(_dr, "Producto")) { _Entity.Producto = _dr["Producto"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Descripcion")) { _Entity.Descripcion = _dr["Descripcion"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "FechaRegistra")) { _Entity.FechaRegistra = Convert.ToDateTime(_dr["FechaRegistra"]); }
            if (ValidExistColumn.HasColumn(_dr, "UsuarioRegistra")) { _Entity.UsuarioRegistra = _dr["UsuarioRegistra"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "FechaModifica")) { _Entity.FechaModifica = Convert.ToDateTime(_dr["FechaModifica"]); }
            if (ValidExistColumn.HasColumn(_dr, "UsuarioModifica")) { _Entity.UsuarioModifica = _dr["UsuarioModifica"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "MG_ES03_Producto_ID")) { _Entity.MG_ES03_Producto_ID = Convert.ToInt32(_dr["MG_ES03_Producto_ID"]); }
            if (ValidExistColumn.HasColumn(_dr, "Precio")) { _Entity.Precio  = Convert.ToDouble(_dr["Precio"]); }
            if (ValidExistColumn.HasColumn(_dr, "TipoCarga")) { _Entity.TipoCarga = _dr["TipoCarga"].ToString(); }


            return _Entity;
        }



        public BEMG_ES01_FichaCarga SetBEMG_ES01_FichaCarga(IDataReader _dr)
        {
            BEMG_ES01_FichaCarga _Entity = new BEMG_ES01_FichaCarga();
            if (ValidExistColumn.HasColumn(_dr, "Ficha")) { _Entity.Ficha = _dr["Ficha"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Origen")) { _Entity.Origen = _dr["Origen"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Destino")) { _Entity.Destino = _dr["Destino"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "FechaHoraOrigen")) { _Entity.FechaHoraOrigen = Convert.ToDateTime(_dr["FechaHoraOrigen"]); }
            if (ValidExistColumn.HasColumn(_dr, "FechaHoraDestino")) { _Entity.FechaHoraDestino = Convert.ToDateTime(_dr["FechaHoraDestino"]); }
            if (ValidExistColumn.HasColumn(_dr, "Remitente")) { _Entity.Remitente = _dr["Remitente"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "Destinatario")) { _Entity.Destinatario = _dr["Destinatario"].ToString(); }
            if (ValidExistColumn.HasColumn(_dr, "DestiDni")) { _Entity.DestiDni  = int.Parse( _dr["DestiDni"].ToString()); }
            if (ValidExistColumn.HasColumn(_dr, "MG_ES01_FichaCarga_ID")) { _Entity.MG_ES01_FichaCarga_ID = Convert.ToInt32(_dr["MG_ES01_FichaCarga_ID"]); }


            if (ValidExistColumn.HasColumn(_dr, "MG_ES10_Agencia_IDOrigen")) { _Entity.MG_ES10_Agencia_IDOrigen = Convert.ToInt32(_dr["MG_ES10_Agencia_IDOrigen"]); }
            if (ValidExistColumn.HasColumn(_dr, "MG_ES10_Agencia_IDDestino")) { _Entity.MG_ES10_Agencia_IDDestino = Convert.ToInt32(_dr["MG_ES10_Agencia_IDDestino"]); }
            if (ValidExistColumn.HasColumn(_dr, "MG_ES04_Cliente_ID")) { _Entity.MG_ES04_Cliente_ID = Convert.ToInt32(_dr["MG_ES04_Cliente_ID"]); }
            if (ValidExistColumn.HasColumn(_dr, "MG_ES04_Cliente_T_MG_ES04_Cliente_ID")) { _Entity.MG_ES04_Cliente_T_MG_ES04_Cliente_ID = Convert.ToInt32(_dr["MG_ES04_Cliente_T_MG_ES04_Cliente_ID"]); }
            if (ValidExistColumn.HasColumn(_dr, "MK_ProgramacionRuta_ID")) { _Entity.MK_ProgramacionRuta_ID = Convert.ToInt32(_dr["MK_ProgramacionRuta_ID"]); }
            if (ValidExistColumn.HasColumn(_dr, "ClaveSeguridad")) { _Entity.ClaveSeguridad = _dr["ClaveSeguridad"].ToString(); }


            


            return _Entity;
        }




        //    public SEGU.Entities.ENUsuarioRol setUsuarioRol(IDataReader _dr) {
        //    SEGU.Entities.ENUsuarioRol _Entity = new SEGU.Entities.ENUsuarioRol();
        //        if (ValidExistColumn.HasColumn(_dr,"IdUsuario")) { _Entity.IdUsuario.IdUsuario = Convert.ToInt32(_dr["IdUsuario"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdRol")) { _Entity.IdRol.IdRol = Convert.ToInt32(_dr["IdRol"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"NombreRol")) { _Entity.IdRol.Nombre = Convert.ToString(_dr["NombreRol"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Principal")) { _Entity.Principal = Convert.ToString(_dr["Principal"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }    
        //    return _Entity;
        //}  
        //    public SEGU.Entities.ENUsuarioPais setUsuarioPais(IDataReader _dr) {
        //    SEGU.Entities.ENUsuarioPais _Entity = new SEGU.Entities.ENUsuarioPais();
        //    if (ValidExistColumn.HasColumn(_dr,"IdUsuario")) { _Entity.IdUsuario.IdUsuario = Convert.ToInt32(_dr["IdUsuario"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"IdPais")) { _Entity.IdPais.IdPais = Convert.ToInt32(_dr["IdPais"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"NombrePais")) { _Entity.IdPais.Nombre = Convert.ToString(_dr["NombrePais"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"Principal")) { _Entity.Principal = Convert.ToString(_dr["Principal"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]);}
        //    return _Entity;
        //}
        //    public SEGU.Entities.ENUsuarioEmpresa setUsuarioEmpresa(IDataReader _dr) {
        //    SEGU.Entities.ENUsuarioEmpresa _Entity = new SEGU.Entities.ENUsuarioEmpresa();
        //    if (ValidExistColumn.HasColumn(_dr,"IdUsuario")) { _Entity.IdUsuario.IdUsuario = Convert.ToInt32(_dr["IdUsuario"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"ApellidoPaterno")) { _Entity.IdUsuario.ApellidoPaterno = Convert.ToString(_dr["ApellidoPaterno"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"ApellidoMaterno")) { _Entity.IdUsuario.ApellidoMaterno = Convert.ToString(_dr["ApellidoMaterno"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"Nombres")) { _Entity.IdUsuario.Nombres = Convert.ToString(_dr["Nombres"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"IdEmpresa")) { _Entity.IdEmpresa.IdEmpresa = Convert.ToInt32(_dr["IdEmpresa"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"RazonSocial")) { _Entity.IdEmpresa.RazonSocial = Convert.ToString(_dr["RazonSocial"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"IdPais")) { _Entity.IdEmpresa.IdPais.IdPais = Convert.ToInt32(_dr["IdPais"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"NombrePais")) { _Entity.IdEmpresa.IdPais.Nombre = Convert.ToString(_dr["NombrePais"]); }
        //    if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //    return _Entity;
        //}
        //    public SEGU.Entities.ENEmpresa setEmpresa(IDataReader _dr) {
        //    SEGU.Entities.ENEmpresa _Entity = new SEGU.Entities.ENEmpresa();
        //        if (ValidExistColumn.HasColumn(_dr,"IdEmpresa")) { _Entity.IdEmpresa = Convert.ToInt32(_dr["IdEmpresa"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"RazonSocial")) { _Entity.RazonSocial = Convert.ToString(_dr["RazonSocial"]);}
        //        if (ValidExistColumn.HasColumn(_dr,"IdPais")) { _Entity.IdPais.IdPais = Convert.ToInt32(_dr["IdPais"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"NombrePais")) { _Entity.IdPais.Nombre = Convert.ToString(_dr["NombrePais"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Ruc")) { _Entity.Ruc = Convert.ToString(_dr["Ruc"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //    return _Entity;
        //    }       
        //    public SEGU.Entities.ENOpcionRol setOpcionRol(IDataReader _dr) {
        //    SEGU.Entities.ENOpcionRol _Entity = new SEGU.Entities.ENOpcionRol();
        //        if (ValidExistColumn.HasColumn(_dr,"IdOpcion")) { _Entity.IdOpcion.IdOpcion = Convert.ToInt32(_dr["IdOpcion"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdMenu")) { _Entity.IdOpcion.IdMenu = Convert.ToInt32(_dr["IdMenu"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Nombre")) { _Entity.IdOpcion.Nombre = Convert.ToString(_dr["Nombre"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"RutaFormulario")) { _Entity.IdOpcion.RutaFormulario = Convert.ToString(_dr["RutaFormulario"]); }
        //        if( ValidExistColumn.HasColumn(_dr,"Anulado")){ _Entity.Anulado = Convert.ToString(_dr["Anulado"]);}
        //        if (ValidExistColumn.HasColumn(_dr,"Visible")){ _Entity.IdOpcion.Visible = Convert.ToString(_dr["Visible"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"PageNew")){ _Entity.IdOpcion.PageNew = Convert.ToString(_dr["PageNew"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Imagen")){ _Entity.IdOpcion.Imagen = Convert.ToString(_dr["Imagen"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdRol")){ _Entity.IdRol.IdRol = Convert.ToInt32(_dr["IdRol"]); }
        //    return _Entity;
        //    }
        //    public SEGU.Entities.ENPermiso setPermiso(IDataReader _dr) {
        //    SEGU.Entities.ENPermiso _Entity = new SEGU.Entities.ENPermiso();
        //        if (ValidExistColumn.HasColumn(_dr,"IdPermiso")) { _Entity.IdPermiso = Convert.ToInt32(_dr["IdPermiso"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Descripcion")) { _Entity.Descripcion = Convert.ToString(_dr["Descripcion"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Control")) { _Entity.Control = Convert.ToString(_dr["Control"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"NroOrden")) { _Entity.NroOrden = Convert.ToDecimal(_dr["NroOrden"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdOpcion")) { _Entity.IdOpcion.IdOpcion = Convert.ToInt32(_dr["IdOpcion"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Nombre")) { _Entity.IdOpcion.Nombre = Convert.ToString(_dr["Nombre"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"RutaFormulario")) { _Entity.IdOpcion.RutaFormulario = Convert.ToString(_dr["RutaFormulario"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //    return _Entity;
        //    }  
        //    public SEGU.Entities.ENPermisoOpcionRol setPermisoOpcionRol(IDataReader _dr) {
        //    SEGU.Entities.ENPermisoOpcionRol _Entity = new SEGU.Entities.ENPermisoOpcionRol();
        //        if (ValidExistColumn.HasColumn(_dr,"IdRol")) { _Entity.IdRol.IdRol = Convert.ToInt32(_dr["IdRol"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"NombreRol")) { _Entity.IdRol.Nombre = Convert.ToString(_dr["NombreRol"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdOpcion")) { _Entity.IdOpcion.IdOpcion = Convert.ToInt32(_dr["IdOpcion"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdMenu")) { _Entity.IdOpcion.IdMenu = Convert.ToInt32(_dr["IdMenu"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"NombreOpcion")) { _Entity.IdOpcion.Nombre = Convert.ToString(_dr["NombreOpcion"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdPermiso")) { _Entity.IdPermiso.IdPermiso = Convert.ToInt32(_dr["IdPermiso"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Descripcion")) { _Entity.IdPermiso.Descripcion = Convert.ToString(_dr["Descripcion"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Control")) { _Entity.IdPermiso.Control = Convert.ToString(_dr["Control"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"NroOrden")) { _Entity.IdPermiso.NroOrden = Convert.ToDecimal(_dr["NroOrden"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"RutaFormulario")) { _Entity.IdOpcion.RutaFormulario = Convert.ToString(_dr["RutaFormulario"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "VisbleDisabled")) { _Entity.VisbleDisabled = Convert.ToString(_dr["VisbleDisabled"]); }
        //    return _Entity;
        //    }
        //    public SEGU.Entities.ENModuloRol setModuloRol(IDataReader _dr) {
        //    SEGU.Entities.ENModuloRol _Entity = new SEGU.Entities.ENModuloRol();
        //        if (ValidExistColumn.HasColumn(_dr,"IdModulo")) { _Entity.IdModulo.IdModulo = Convert.ToInt32(_dr["IdModulo"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"NombreModulo")) { _Entity.IdModulo.Nombre = Convert.ToString(_dr["NombreModulo"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdRol")) { _Entity.IdRol.IdRol = Convert.ToInt32(_dr["IdRol"]);}
        //        if (ValidExistColumn.HasColumn(_dr,"NombreRol")) { _Entity.IdRol.Nombre = Convert.ToString(_dr["NombreRol"]);}
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //    return _Entity;
        //    }
        //    public SEGU.Entities.ENModulo setModulo(IDataReader _dr)
        //    {
        //        SEGU.Entities.ENModulo _Entity = new SEGU.Entities.ENModulo();
        //        if (ValidExistColumn.HasColumn(_dr,"IdModulo")) { _Entity.IdModulo = Convert.ToInt32(_dr["IdModulo"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Nombre")) { _Entity.Nombre = Convert.ToString(_dr["Nombre"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //        return _Entity;
        //    }
        //    public SEGU.Entities.ENOpcion setOpcion(IDataReader _dr)
        //    {
        //        SEGU.Entities.ENOpcion _Entity = new SEGU.Entities.ENOpcion();
        //        if (ValidExistColumn.HasColumn(_dr,"IdOpcion")) { _Entity.IdOpcion = Convert.ToInt32(_dr["IdOpcion"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdMenu")) { _Entity.IdMenu = Convert.ToInt32(_dr["IdMenu"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdModulo")) { _Entity.IdModulo.IdModulo = Convert.ToInt32(_dr["IdModulo"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Nombre")) { _Entity.Nombre = Convert.ToString(_dr["Nombre"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"RutaFormulario")) { _Entity.RutaFormulario = Convert.ToString(_dr["RutaFormulario"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"NroOrden")) { _Entity.NroOrden = Convert.ToDecimal(_dr["NroOrden"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Visible")) { _Entity.Visible = Convert.ToString(_dr["Visible"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"PageNew")) { _Entity.PageNew = Convert.ToString(_dr["PageNew"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Imagen")) { _Entity.Imagen = Convert.ToString(_dr["Imagen"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //        return _Entity;
        //    }
        //    public SEGU.Entities.ENPais setPais(IDataReader _dr)
        //    {
        //        SEGU.Entities.ENPais _Entity = new SEGU.Entities.ENPais();
        //        if (ValidExistColumn.HasColumn(_dr,"IdPais")) { _Entity.IdPais = Convert.ToInt32(_dr["IdPais"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Nombre")) { _Entity.Nombre = Convert.ToString(_dr["Nombre"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"IdPaisPersonasNetwork")) { _Entity.IdPaisPersonasNetwork = Convert.ToString(_dr["IdPaisPersonasNetwork"]); }
        //        return _Entity;
        //    }
        //    public SEGU.Entities.ENParametroGenerales setParametroGenerales(IDataReader _dr)
        //    {
        //        SEGU.Entities.ENParametroGenerales _Entity = new SEGU.Entities.ENParametroGenerales();
        //        if (ValidExistColumn.HasColumn(_dr,"IdParametroGeneral")) { _Entity.IdParametroGeneral = Convert.ToInt32(_dr["IdParametroGeneral"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Descripcion")) { _Entity.Descripcion = Convert.ToString(_dr["Descripcion"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Valor")) { _Entity.Valor = Convert.ToString(_dr["Valor"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Comentario")) { _Entity.Comentario = Convert.ToString(_dr["Comentario"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }            
        //        return _Entity;
        //    }
        //    public SEGU.Entities.ENRol setRol(IDataReader _dr)
        //    {
        //        SEGU.Entities.ENRol _Entity = new SEGU.Entities.ENRol();
        //        if (ValidExistColumn.HasColumn(_dr,"IdRol")) { _Entity.IdRol = Convert.ToInt32(_dr["IdRol"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Nombre")) { _Entity.Nombre = Convert.ToString(_dr["Nombre"]); }
        //        if (ValidExistColumn.HasColumn(_dr,"Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //        return _Entity;
        //    }
        //    public SEGU.Entities.ENLocal setLocal(IDataReader _dr) {
        //        SEGU.Entities.ENLocal _Entity = new SEGU.Entities.ENLocal();
        //        if( ValidExistColumn.HasColumn(_dr, "IdLocal")){ _Entity.IdLocal = Convert.ToInt32(_dr["IdLocal"]);}
        //        if( ValidExistColumn.HasColumn(_dr, "IdEmpresa")){_Entity.IdEmpresa.IdEmpresa = Convert.ToInt32(_dr["IdEmpresa"]);}
        //        if( ValidExistColumn.HasColumn(_dr, "RazonSocial")){_Entity.IdEmpresa.RazonSocial = Convert.ToString(_dr["RazonSocial"]);}
        //        if( ValidExistColumn.HasColumn(_dr, "Nombre")){_Entity.Nombre = Convert.ToString(_dr["Nombre"]);}        
        //        if( ValidExistColumn.HasColumn(_dr, "Direccion")){_Entity.Direccion = Convert.ToString(_dr["Direccion"]);}
        //        if( ValidExistColumn.HasColumn(_dr, "Tipo")){_Entity.Tipo = Convert.ToString(_dr["Tipo"]);}
        //        if (ValidExistColumn.HasColumn(_dr, "IdPais")) { _Entity.IdEmpresa.IdPais.IdPais = Convert.ToInt32(_dr["IdPais"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "NombrePais")) { _Entity.IdEmpresa.IdPais.Nombre = Convert.ToString(_dr["NombrePais"]); }
        //        if( ValidExistColumn.HasColumn(_dr, "Anulado")){_Entity.Anulado = Convert.ToString(_dr["Anulado"]);}
        //        return _Entity;
        //    }
        //    public SEGU.Entities.ENUsuarioLocal setUsuarioLocal(IDataReader _dr)
        //    {
        //        SEGU.Entities.ENUsuarioLocal _Entity = new SEGU.Entities.ENUsuarioLocal();
        //        if (ValidExistColumn.HasColumn(_dr, "IdUsuario")) { _Entity.IdUsuario.IdUsuario = Convert.ToInt32(_dr["IdUsuario"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "IdPais")) { _Entity.IdLocal.IdEmpresa.IdPais.IdPais = Convert.ToInt32(_dr["IdPais"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "NombrePais")) { _Entity.IdLocal.IdEmpresa.IdPais.Nombre = Convert.ToString(_dr["NombrePais"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "IdEmpresa")) { _Entity.IdLocal.IdEmpresa.IdEmpresa= Convert.ToInt32(_dr["IdEmpresa"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "RazonSocial")) { _Entity.IdLocal.IdEmpresa.RazonSocial = Convert.ToString(_dr["RazonSocial"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "IdLocal")) { _Entity.IdLocal.IdLocal= Convert.ToInt32(_dr["IdLocal"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "NombreLocal")) { _Entity.IdLocal.Nombre = Convert.ToString(_dr["NombreLocal"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "Tipo")) { _Entity.IdLocal.Tipo= Convert.ToString(_dr["Tipo"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "Principal")) { _Entity.Principal = Convert.ToString(_dr["Principal"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //        return _Entity;
        //    }
        //    public SEGU.Entities.ENMoneda setMoneda(IDataReader _dr)
        //    {
        //        SEGU.Entities.ENMoneda _Entity = new SEGU.Entities.ENMoneda();
        //        if (ValidExistColumn.HasColumn(_dr, "IdMoneda")) { _Entity.IdMoneda = Convert.ToInt32(_dr["IdMoneda"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "Nombre")) { _Entity.Nombre = Convert.ToString(_dr["Nombre"]); }
        //        if (ValidExistColumn.HasColumn(_dr, "Abv")) { _Entity.Abv = Convert.ToString(_dr["Abv"]); }            
        //        if (ValidExistColumn.HasColumn(_dr, "Anulado")) { _Entity.Anulado = Convert.ToString(_dr["Anulado"]); }
        //        return _Entity;
        //    }      

    }
}
