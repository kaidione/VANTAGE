using System;
using System.Reflection;

namespace LenovoVantageTest.Utility
{
    [Serializable]
    class LoadAssembly : MarshalByRefObject
    {
        Assembly assembly = null;
        public void Load(string asseblyPath)
        {
            assembly = Assembly.LoadFrom(asseblyPath);
        }

        public object CreateInstance(string fullClassName, params Object[] args)
        {
            if (assembly == null)
                return false;
            Type tp = assembly.GetType(fullClassName);
            if (tp == null)
                return false;
            return Activator.CreateInstance(tp, args);
        }
        public bool InvokeMethod(string fullClassName, object constructorParam, string methodName, params Object[] args)
        {
            if (assembly == null)
                return false;
            Type tp = assembly.GetType(fullClassName);
            if (tp == null)
                return false;
            MethodInfo method = tp.GetMethod(methodName);
            if (method == null)
                return false;
            object[] parameters = new object[1];
            parameters[0] = constructorParam;
            Object obj = Activator.CreateInstance(tp, parameters);
            method.Invoke(obj, args);
            return true;
        }

        public object InvokeStaticMethod(string fullClassName, string methodName, params Object[] args)
        {
            if (assembly == null)
                return false;
            Type tp = assembly.GetType(fullClassName);
            if (tp == null)
                return false;
            MethodInfo method = tp.GetMethod(methodName);
            if (method == null)
                return false;
            object x = method.Invoke(null, args);
            return x;
        }

        public object InvokeProperty(string fullClassName, object constructorParam, string propertyName)
        {
            if (assembly == null)
                return false;
            Type tp = assembly.GetType(fullClassName);
            if (tp == null)
                return false;
            PropertyInfo property = tp.GetProperty(propertyName);
            if (property == null)
                return false;
            object[] parameters = new object[1];
            parameters[0] = constructorParam;
            Object obj = Activator.CreateInstance(tp, parameters);
            return property.GetValue(obj, null);
        }

        public object InvokePropertyLID(string fullClassName, string methodName, string propertyName, params Object[] args)
        {
            if (assembly == null)
                return false;
            Type tp = assembly.GetType(fullClassName);
            if (tp == null)
                return false;
            MethodInfo method = tp.GetMethod(methodName);
            if (method == null)
                return false;
            object x = method.Invoke(null, args);
            PropertyInfo property = tp.GetProperty(propertyName);
            if (property == null)
                return false;
            object prop = property.GetValue(x, null);
            return prop;
        }
    }
}
