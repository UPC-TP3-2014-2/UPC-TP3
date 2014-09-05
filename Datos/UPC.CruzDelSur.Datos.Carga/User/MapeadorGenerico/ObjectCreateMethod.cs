using System;
using System.Reflection;
using System.Reflection.Emit;

namespace UPC.CruzDelSur.Datos.Carga.User.MapeadorGenerico
{
    /// <summary>
    /// Clase que crea un método dinámico para crear instancias de objetos de un tipo específico
    /// Uso:
    /// ObjectCreateMethod _MetodoDinamico = new ObjectCreateMethod(info.PropertyType);
    /// object _nuevaEntidad = _MetodoDinamico.CreateInstance();
    /// </summary>
    public class ObjectCreateMethod
    {
        delegate object MethodInvoker();
        MethodInvoker methodHandler = null;

        /// <summary>
        /// Crea un método en base al constructor de una clase, descubierto en base a un tipo
        /// </summary>
        /// <param name="type">Tipo</param>
        public ObjectCreateMethod(Type type)
        {
            CreateMethod(type.GetConstructor(Type.EmptyTypes));
        }

        /// <summary>
        /// Crea un método en base al constructor de una clase
        /// </summary>
        /// <param name="target"></param>
        public ObjectCreateMethod(ConstructorInfo target)
        {
            CreateMethod(target);
        }

        /// <summary>
        /// Crea un Método Dinámico en base al constructor de una clase
        /// </summary>
        /// <param name="target">Constructor de la clase</param>
        void CreateMethod(ConstructorInfo target)
        {
            DynamicMethod dynamic = new DynamicMethod(string.Empty,
                        typeof(object),
                        new Type[0],
                        target.DeclaringType);
            ILGenerator il = dynamic.GetILGenerator();
            il.DeclareLocal(target.DeclaringType);
            il.Emit(OpCodes.Newobj, target);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ret);

            methodHandler = (MethodInvoker)dynamic.CreateDelegate(typeof(MethodInvoker));
        }


        /// <summary>
        /// Crea una instancia de una clase, usando un Método Dinámico
        /// </summary>
        /// <returns>Método dinámico</returns>
        public object CreateInstance()
        {
            return methodHandler();
        }
    }
}
