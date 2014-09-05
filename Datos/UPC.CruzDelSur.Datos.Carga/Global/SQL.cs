using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using UPC.CruzDelSur.Datos.Carga.User;
using UPC.CruzDelSur.Datos.Carga.User.Cache;
using UPC.CruzDelSur.Datos.Carga.User.MapeoXML;

namespace UPC.CruzDelSur.Datos.Carga.Global
{
    public class SQL
    {

    public static string _mapeadorSql = "MapeadorSQL";
    public static List<MapaXML> diccionarioglobalSql = new List<MapaXML>() ;
    public static List<string> _entidadesSql = new List<string>() ;
 
    public static string PrefijoParametros_SQL = System.Configuration.ConfigurationManager.AppSettings.Get("PrefijoParametros_SQL").ToString();
    public static Validacion _validacion = new Validacion();
    public CacheUtil _cacheUtil = new CacheUtil();
 
    /// <summary>
    /// Inicializador de la clase
    /// Carga la lista de Entidades(_entidadesSQL) y las Relaciones entre ellas (diccionarioglobalSQL) en memoria,
    /// leyéndolas del archivo de configuración XML indicado en la sección appSettings en el web.config, identificado por la clave _mapeadorSQL (MapeadorSQL)
    /// </summary>
    public SQL() {
 
        if( diccionarioglobalSql == null | diccionarioglobalSql.Count == 0 ){
            diccionarioglobalSql = MapeadorXML.CargarMapa(_mapeadorSql);
        }
        if( _entidadesSql == null | _entidadesSql.Count == 0 ){
            _entidadesSql = MapeadorXML.ObtenerEntidades(_mapeadorSql);
        }
    }  
 
    /// <summary>
    /// Devuelve un data reader con varios registros, recibiendo parámetros a través de una Entidad
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vObj">Entidad</param>
    /// <returns>DataReader</returns>
    public SqlDataReader ObtenerVariosRegistrosDataReader(SqlConnection vCon, SqlTransaction vTrx, string vSP, object vObj, bool PermiteCadenasVacias) {
        SqlCommand cmd = new SqlCommand(vSP, vCon);
        SqlDataReader drd;
        try{
            if( vTrx != null ){
                cmd.Transaction = vTrx;
            }
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if( vObj != null ){
                GenerarParametrosObjetos(cmd, vObj, PermiteCadenasVacias);
            }
            drd = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
 
            return (drd);
        }catch(SqlException ex){
            //return (null);
            throw new Exception(ex.Message);
        }
    }  
 
    /// <summary>
    /// Devuelve un datareader con un solo registro, con varios campos, recibiendo parámetros a través de una Entidad
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vObj">Entidad</param>
    /// <returns>DataReader</returns>
    public SqlDataReader ObtenerUnSoloRegistroDataReader(SqlConnection vCon, SqlTransaction vTrx, string vSP, object vObj, bool PermiteCadenasVacias) {
        using(SqlCommand cmd = new SqlCommand(vSP, vCon)){    
            SqlDataReader drd;
            try{
                if( vTrx != null ){
                    cmd.Transaction = vTrx;
                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if( vObj != null ){
                    GenerarParametrosObjetos(cmd, vObj, PermiteCadenasVacias);
                }
                drd = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow | System.Data.CommandBehavior.CloseConnection);
 
                return (drd);
            }catch(SqlException ex){
                return (null);
                throw new Exception(ex.Message);
            }
        }
    }  
 
    /// <summary>
    /// Devuelve un solo valor, recibiendo parámetros a través de una Entidad
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vObj">Entidad</param>
    /// <returns>Valor de retorno como Object</returns>
    public object ObtenerUnSoloValor(SqlConnection vCon, SqlTransaction vTrx, string vSP, object vObj, bool PermiteCadenasVacias) {
        SqlCommand cmd = new SqlCommand(vSP, vCon);
        object val;
        try{
            if( vTrx != null ){
                cmd.Transaction = vTrx;
            }
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if( vObj != null ){
                GenerarParametrosObjetos(cmd, vObj, PermiteCadenasVacias);
            }
            val = cmd.ExecuteScalar();
            return (val);
        }catch(SqlException ex){
            return (null);
            throw new Exception(ex.Message);
        }
    }  
 
    /// <summary>
    /// Realiza operaciones Insert, Update, Delete, recibiendo parámetros a través de una Entidad, y devolviendo un valor de retorno
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vObj">Entidad</param>
    /// <param name="_out">Devuelve valor de retorno</param>
    /// <param name="ParamOutPut">Nombre parámetro de valor de retorno</param>
    /// <returns>Valor de retorno como Object</returns>
    public object InsertaActualizaElimina(SqlConnection vCon, SqlTransaction vTrx, string vSP, object vObj, int _out, string ParamOutPut, bool PermiteCadenasVacias)
    {
        using(SqlCommand cmd = new SqlCommand(vSP, vCon)){
            int n;
            try{
                if( vTrx != null ){
                    cmd.Transaction = vTrx;
                }
                cmd.CommandType =System.Data.CommandType.StoredProcedure;
                GenerarParametrosObjetosRetornaValor(cmd, vObj, _out, ParamOutPut, PermiteCadenasVacias);
                n = cmd.ExecuteNonQuery();
                if( _out == 1 ){
                    if( ParamOutPut == "" ){
                        string P_out;
                        P_out = Convert.ToString(cmd.Parameters["@P_OUT"].Value);
                        return (P_out);
                    }else{
                        return cmd.Parameters[PrefijoParametros_SQL + ParamOutPut].Value;
                    }
                }else{
                    if( n <= 0 ){
                        return (-1);
                    }else{
                        return cmd.Parameters[0].Value;
                    }
                }
 
            }catch(SqlException ex){
                return (-1);
                throw new Exception(ex.Message);
            }    
        }
    }

    public object InsertaActualizaElimina2(SqlConnection vCon, SqlTransaction vTrx, string vSP, object vObj, int _out, string ParamOutPut, bool PermiteCadenasVacias)
    {
        using (SqlCommand cmd = new SqlCommand(vSP, vCon))
        {
            int n;
            try
            {
                if (vTrx != null)
                {
                    cmd.Transaction = vTrx;
                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                GenerarParametrosObjetosRetornaValor(cmd, vObj, _out, ParamOutPut, PermiteCadenasVacias);
                n = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (_out == 1)
                {
                    if (ParamOutPut == "")
                    {
                        string P_out;
                        P_out = Convert.ToString(cmd.Parameters["@P_OUT"].Value);
                        return (P_out);
                    }
                    else
                    {
                        return cmd.Parameters[PrefijoParametros_SQL + ParamOutPut].Value;
                    }
                }
                else
                {
                    if (n <= 0)
                    {
                        return (-1);
                    }
                    else
                    {
                        return n;
                    }
                }

            }
            catch (SqlException ex)
            {
                return (-1);
                throw new Exception(ex.Message);
            }
        }
    }  

 
    /// <summary>
    /// Devuelve un data reader con varios registros, recibiendo parámetros a través de un Array
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vArray">Array de parámetros</param>
    /// <returns>DataReader</returns>
    public SqlDataReader ObtenerVariosRegistrosDataReaderArrayParametros(SqlConnection vCon, SqlTransaction vTrx, string vSP, List<ParametroGenerico> vArray) {
        try{
            using(SqlCommand cmd = new SqlCommand(vSP, vCon)){
                SqlDataReader drd;
                try{
                    if( vTrx != null ){
                        cmd.Transaction = vTrx;
                    }
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmd);
 
                    GenerarParametrosArray(cmd, vArray, 0);

                    drd = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
 
                    return drd;
                }catch(Exception ex){
                    string str;
                    str = ex.Message;
                    return (null);
                }
            }
        }catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }  
 
    /// <summary>
    /// Devuelve un data reader con un solo registro, recibiendo parámetros a través de un Array
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vArray">Array de parámetros</param>
    /// <returns>DataReader</returns>
    public SqlDataReader ObtenerUnSoloRegistroDataReaderArrayParametros(SqlConnection vCon, SqlTransaction vTrx, string vSP, List<ParametroGenerico> vArray) {
        using(SqlCommand cmd = new SqlCommand(vSP, vCon)){
            SqlDataReader drd;
            try{
                if( vTrx != null ){
                    cmd.Transaction = vTrx;
                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
 
                GenerarParametrosArray(cmd, vArray, 0);

                drd = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow | System.Data.CommandBehavior.CloseConnection);
 
                return (drd);
            }catch(SqlException ex){
                return (null);
                throw new Exception(ex.Message);
            }
        }
    }  
 
 
    /// <summary>
    /// Genera los parámetros del Procedimiento Almacenado dinámicamente, basado en una Entidad
    /// </summary>
    /// <param name="vCmd">Nombre del Procedimiento Almacenado</param>
    /// <param name="vObj">Entidad</param>
    private void GenerarParametrosObjetos(SqlCommand vCmd, object vObj, bool PermiteCadenasVacias) {
        try{
            GenerarParametrosGenerico(vCmd, vObj, PermiteCadenasVacias);
        }catch(SqlException ex){
            throw new Exception(ex.Message);
        }
    }  
 
    /// <summary>
    /// Genera los parámetros del Procedimiento Almacenado dinámicamente, incluyendo un parámetro de retorno
    /// </summary>
    /// <param name="vCmd">Nombre del Procedimiento Almacenado</param>
    /// <param name="vObj">Entidad</param>
    /// <param name="_out">Devuelve valor de retorno</param>
    /// <param name="ParamOutPut">Nombre parámetro de valor de retorno</param>
    private void GenerarParametrosObjetosRetornaValor(SqlCommand vCmd, object vObj, int _out, string ParamOutPut, bool PermiteCadenasVacias) {
        try{
            GenerarParametrosGenerico(vCmd, vObj, PermiteCadenasVacias);
            if( _out == 1 & ParamOutPut != "" ){
                vCmd.Parameters[PrefijoParametros_SQL + ParamOutPut].Direction = System.Data.ParameterDirection.Output;
            }
        }catch(SqlException ex){
            throw new Exception(ex.Message);
        }
    }  
 
 
 
    /// <summary>
    /// Genera los parámetros del Procedimiento Almacenado dinámicamente, basado en una Entidad, a través de Reflection
    /// </summary>
    /// <param name="vCmd">Nombre del Procedimiento Almacenado</param>
    /// <param name="vObj">Entidad</param>
    private void GenerarParametrosGenerico(SqlCommand vCmd, object vObj, bool PermiteCadenasVacias) {
        //SE PODRIA COLOCAR EN CACHE LOS PARAMETROS DERIVADOS DE UN PROCEDIMIENTO ALMACENADO
        SqlCommandBuilder.DeriveParameters(vCmd);
 
        if( vObj != null ){
            bool Valido;
            object Valor;
            List<string> res = new List<string>() ;
 
            Type _tipoentidadbase = vObj.GetType();
            List<PropertyInfo> Propiedad = _cacheUtil.InicializarCacheReflection(vObj);
 
            for(Int32 I= 0; I< Propiedad.Count; I++){
                Valor = Propiedad[I].GetValue(vObj, null);
                res = ValidarParametroObjetos(Valor, Propiedad[I].Name, _tipoentidadbase.ToString(), PermiteCadenasVacias);
                Valido = Convert.ToBoolean(res[0].ToString());
                if( Valido == true ){
                    if( vCmd.Parameters.Contains(PrefijoParametros_SQL + Propiedad[I].Name) ){
                        if( res[1] != null ){
                            vCmd.Parameters[PrefijoParametros_SQL + Propiedad[I].Name].Value = res[1].ToString();
                        }else{
                            vCmd.Parameters[PrefijoParametros_SQL + Propiedad[I].Name].Value = Valor;
                        }
                    }
                }
            }
        }
    }  
         
    /// <summary>
    /// Valida el valor de los parámetros correspondientes a Propiedades que a su vez son otras Entidades, haciendo un Mapeo entre las Propiedades de ambas Entidades
    /// basándose en la relación entre ellas
    /// </summary>
    /// <param name="valor">Valor de la propiedad en la entidad base (padre), en el caso que esta propiedad sea otra entidad (subentidad)</param>
    /// <param name="_propiedadbase">Propiedad de la entidad base (padre)</param>
    /// <param name="_tipoentidadbase">Tipo de la entidad base (padre)</param>
    /// <returns>Devuelve una lista de 2 cadenas: si el parámetro es válido, y el valor del mismo</returns>
    public List<string> ValidarParametroObjetos(object valor, string _propiedadbase, string _tipoentidadbase, bool PermiteCadenasVacias) {
        bool valido = false;
        List<string> res = new List<string>() ;
        if( (valor != null) ){
            Type TIPO = valor.GetType();
            if( _validacion.ValidarParametrosSimples(valor, PermiteCadenasVacias) ){
                valido = true;
            }else if( _entidadesSql.Contains(TIPO.ToString()) ){
                List<PropertyInfo> Propiedad = _cacheUtil.InicializarCacheReflection(valor);
                string _atributomapeado = null;
                _atributomapeado = MapeadorXML.Mapear(_tipoentidadbase, _propiedadbase, _mapeadorSql);
                for(Int32 I= 0; I< Propiedad.Count; I++){
                    if( Propiedad[I].Name == _propiedadbase | _atributomapeado == (TIPO.ToString() + ".") + Propiedad[I].Name ){
                        valido = _validacion.ValidarParametrosSimples(Propiedad[I].GetValue(valor, null), PermiteCadenasVacias);
                        res.Add(Convert.ToString(valido));
 
                        if( valido == false ){
                            res.Add(null);
                        }else{
                            res.Add(Propiedad[I].GetValue(valor, null).ToString());
                        }
                        return res;
                    }
                }
            }
        }else{
            valido = false;
        }
        res.Add(Convert.ToString(valido));
        res.Add(null);
        return res;
    }  
 
    /// <summary>
    /// Realiza operaciones Insert, Update, Delete, recibiendo parámetros a través de un Array, y devolviendo un valor de retorno
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vArray">Array de parámetros</param>
    /// <param name="out">Devuelve un valor de retorno</param>
    /// <returns>Valor de retorno como Object</returns>
    public object InsertarActualizarEliminarArrayParametros(SqlConnection vCon, SqlTransaction vTrx, string vSP, List<ParametroGenerico> vArray, int _out) {
        using(SqlCommand cmd = new SqlCommand(vSP, vCon)){
            int n = 0;
            try{
                if( vTrx != null ){
                    cmd.Transaction = vTrx;
                }
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                GenerarParametrosArray(cmd, vArray, _out);
                n = cmd.ExecuteNonQuery();
                if( _out == 1 ){
                    string P_out = null;
                    P_out = cmd.Parameters["@P_OUT"].Value.ToString();
                    return (P_out);
                }else{
                    return n;
                }
            }catch(Exception ex){
                throw ex;
            }
        }
    }  
 
    /// <summary>
    /// Genera parámetros basado en valores recibidos en un Array
    /// </summary>
    /// <param name="vCmd">Nombre del Procedimiento Almacenado</param>
    /// <param name="vArray">Array de parámetros</param>
    /// <param name="out">Indica si hay un valor de retorno</param>
    private void GenerarParametrosArray(SqlCommand vCmd, List<ParametroGenerico> vArray, int _out) {
        try{
            SqlCommandBuilder.DeriveParameters(vCmd);
            if( vArray != null ){
                foreach(ParametroGenerico obj in vArray){
                    vCmd.Parameters[PrefijoParametros_SQL + obj.nombre].Value = obj.valor.ToString();
                }
            }
            if( _out == 1 ){
                vCmd.Parameters["@P_OUT"].Direction = System.Data.ParameterDirection.Output;
            }
        }catch(Exception ex){
            throw ex;
        }
    }  
 
    /// <summary>
    /// Realiza operaciones Insert, Update, Delete, recibiendo parámetros a través de un DataTable, y devolviendo un valor de retorno
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vTable"></param>
    /// <param name="vRow"></param>
    /// <param name="out">Devuelve un valor de retorno</param>
    /// <returns>Valor de retorno como Object</returns>
    public object InsertarActualizarEliminarDataTable(SqlConnection vCon, SqlTransaction vTrx, string vSP, System.Data.DataTable vTable, System.Data.DataRow vRow, int _out)
    {
        using(SqlCommand cmd = new SqlCommand(vSP, vCon)){
            int n = 0;
            try{
                if( vTrx != null ){
                    cmd.Transaction = vTrx;
                }
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                GenerarParametrosDataTable(cmd, vTable, vRow, _out);
                n = cmd.ExecuteNonQuery();
                if( _out == 1 ){
                    string P_out = null;
                    P_out = cmd.Parameters["@P_OUT"].Value.ToString();
                    return (P_out);
                }else{
                    return n;
                }
            }catch(Exception ex){
                throw ex;
            }
        }
    }  
 
    /// <summary>
    /// Genera parámetros con valores recibidos a través de un DataTable
    /// </summary>
    /// <param name="vCmd">Nombre del Procedimiento Almacenado</param>
    /// <param name="vTable"></param>
    /// <param name="vRow"></param>
    /// <param name="out">Indica si hay un valor de retorno</param>
    private void GenerarParametrosDataTable(SqlCommand vCmd, System.Data.DataTable vTable, System.Data.DataRow vRow, int _out)
    {
        try{
            SqlCommandBuilder.DeriveParameters(vCmd);
            if( vTable != null ){
                foreach (System.Data.DataColumn _colum in vTable.Columns)
                {
                    string columnName = _colum.ColumnName;
                    object valor = vRow[columnName];
                    vCmd.Parameters[PrefijoParametros_SQL + columnName].Value = valor;
                }
            }
            if( _out == 1 ){
                vCmd.Parameters["@P_OUT"].Direction = System.Data.ParameterDirection.Output;
            }
        }catch(Exception ex){
            throw ex;
        }
    }  
 
    /// <summary>
    /// Lista los parámetros de un procedimiento almacenado de Sql, mostrando el nombre y el tipo de datos de cada parámetro
    /// </summary>
    /// <param name="vCmd">Nombre del procedimiento almacenado</param>
    /// <remarks></remarks>
    public void ListarParametrosSql(SqlCommand vCmd) {
        SqlParameterCollection pcs;
        pcs = vCmd.Parameters;
        int j = 1;
        int l = pcs.Count;
        string x;
        if( l > 0 ){
            for(j = 0; j < l; j++){
                x = pcs[j].ParameterName;
                x = Convert.ToString(pcs[j].SqlDbType);
            }
        }
    }  
 
    /// <summary>
    /// Devuelve un DataSet, generando parámetros dinámicamente en base a una Entidad
    /// </summary>
    /// <param name="vCon">Conección</param>
    /// <param name="vTrx">Transacción</param>
    /// <param name="vSP">Procedimiento Almacenado</param>
    /// <param name="vObj">Entidad</param>
    /// <param name="PermiteCadenasVacias">PermiteCadenasVacias</param>
    /// <returns>Dataset</returns>
    public System.Data.DataSet ObtenerDataSet(SqlConnection vCon, SqlTransaction vTrx, string vSP, object vObj, bool PermiteCadenasVacias) {
        using(SqlDataAdapter dap = new SqlDataAdapter(vSP, vCon)){
            using (System.Data.DataSet dst = new System.Data.DataSet())
            {
                try{
                    if( vTrx != null ){
                        dap.SelectCommand.Transaction = vTrx;
                    }
                    dap.SelectCommand.CommandTimeout = 0;
                    dap.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    if( vObj != null ){
                        GenerarParametrosObjetos(dap.SelectCommand, vObj, PermiteCadenasVacias);
                    }
                    dap.Fill(dst, vSP);
                    return (dst);
                }catch(SqlException ex){
                    throw new Exception(ex.Message);
                }
        }
            }
    }   
    public int InsertaActualizaEliminaXML<T>(SqlConnection vCon, SqlTransaction vTrx, string vSP, List<T> _objetos) where T : new() {
 
        using(SqlCommand cmd = new SqlCommand(vSP, vCon)){
            int n;
            try{
                if( vTrx != null ){
                    cmd.Transaction = vTrx;
                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
 
                String strxml = "";
                Serializador customSer = new Serializador();                
                strxml = customSer.ListaObjetosToXml <T>(_objetos, "");
                strxml = "<root>" + strxml + "</root>";

                cmd.Parameters.Add(PrefijoParametros_SQL + "REGISTROS", System.Data.SqlDbType.VarChar);
                cmd.Parameters[PrefijoParametros_SQL + "REGISTROS"].Value = strxml;
                n = cmd.ExecuteNonQuery();
 
                return n;
            }catch(SqlException ex){
                return (-1);
                throw new Exception(ex.Message);
            }
        }
    }

    /***************************************************************************************************
        SIN STOREDPROCEDURE
     * * *************************************************************************************************/
    public SqlDataReader SIN_SP_ObtenerVariosRegistrosDataReaderArrayParametros(SqlConnection vCon, SqlTransaction vTrx, string vQUERY, List<ParametroGenerico> vArray)
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand(vQUERY, vCon))
            {
                SqlDataReader drd;
                try
                {
                    if (vTrx != null)
                    {
                        cmd.Transaction = vTrx;
                    }
                    cmd.CommandType = System.Data.CommandType.Text;
                    SIN_SP_GenerarParametrosArray(cmd, vArray, 0);
                    drd = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);

                    return drd;
                }
                catch (Exception ex)
                {
                    string str;
                    str = ex.Message;
                    return (null);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void SIN_SP_GenerarParametrosArray(SqlCommand vCmd, List<ParametroGenerico> vArray, int _out)
    {
        try
        {
  
            if (vArray != null)
            {
                foreach (ParametroGenerico obj in vArray)
                {
                    vCmd.Parameters.AddWithValue(PrefijoParametros_SQL + obj.nombre, obj.valor.ToString());
                }
            }
            if (_out == 1)
            {
               // vCmd.Parameters["@P_OUT"].Direction = System.Data.ParameterDirection.Output;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }  

    }
}
