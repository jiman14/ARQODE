using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using TControls;
using ARQODE_Core;
using System.Reflection;

namespace TLogic
{
    public class CMapObject
    {

        String endline = "\r\n";

        // Eliminar todos los ficheros de una dll antes de regenerarlos de la carpeta plugin del código
        // Eliminar todos los ficheros de procesos\Puglins antes de regenerarlos

        // Primero se crea un MAP de la DLL con los métodos infiriendo los tipos por reflexión

        // crear un proceso para instanciar primero la clase, necesitamos la ruta relativa a la dll
        // Proceso para configurar la clase
        // Desde el proceso únicamente se generan los inputs y outpus y dentro se hace la llamada 
        //    al método de la clase en cuestión previamente inicializada (chequear esto)

        CGlobals app_globals;
        CGlobals sys_globals;

        public CMapObject(CGlobals App_globals, CGlobals Sys_globals)
        {
            app_globals = App_globals;
            sys_globals = Sys_globals;
        }

        /// <summary>
        /// Map objects in assembly file
        /// </summary>
        /// <param name="assembly_file"></param>
        public String MapObjectFromFile(String assembly_file)
        {
            String dll_lines = "";
            String relative_path = assembly_file.Replace(app_globals.AppDataSection(dPATH.DLL).FullName, "").Replace("\\", ".");
            
            // Load assembly
            Assembly _dll = Assembly.LoadFrom(assembly_file);

            // generate maps
            foreach (Type dll_type in _dll.GetTypes())
            {
                #region namespace and class
                String ns_lines = String.Format("namespace {0}", dll_type.FullName) + endline +
                                                "{" + endline +
                              String.Format(sep(1) + "public class {0}", dll_type.Name) + endline +
                                            sep(1) + "{" + endline +
                                                        "vars_lines" + endline +
                                                        "constructor" + endline +
                                                        "property_lines" + endline +
                                                        "method_lines" + endline +
                                            sep(1) + "}" + endline +
                                            "}" + endline;
                #endregion

                #region object variables
                String var_lines =  sep(2) + "Type tobj;" + endline +
                                    sep(2) + "Object obj;" + endline +
                                    sep(2) + String.Format("String dll_path = \"{0}\";", relative_path) + endline;
                #endregion

                #region Constructor
                String constr_lines = sep(2) + String.Format("public {0}(CGlobals App_globals)", dll_type.Name) + endline +
                                        sep(3) + "{" + endline +
                                            sep(4) + "Assembly _dll = Assembly.LoadFrom(App_globals.getAssembly(dll_path));" + endline +
                                            sep(4) + String.Format("tobj = _dll.GetType(\"{0}\");", dll_type.Name) + endline +
                                            sep(4) + "obj = (Object)Activator.CreateInstance(tobj); " + endline +                                                                                        
                                        sep(3) + "}" + endline;
                #endregion

                #region MEthods
                String methods_lines = "";

                foreach (MethodInfo mi in dll_type.GetMethods())
                {
                    //mi.ReturnType.FullName
                    String method_params = "";
                    String mparameters = "";
                    String sepc = "";
                    foreach (ParameterInfo pi in mi.GetParameters())
                    {
                        method_params += sepc + pi.ParameterType.FullName + " " + pi.Name;
                        mparameters = sepc + pi.Name;
                        sepc = ", ";
                    }

                    methods_lines +=
                        sep(2) + String.Format("public {0} {1}({2})", mi.ReturnType.FullName, mi.Name, method_params) + endline +
                        sep(2) + "{" + endline +
                            sep(3) + "object[] method_params = new object[] { " + mparameters + "};" + endline +
                            sep(3) + String.Format("return tobj.GetMethod(\"{0}\").Invoke(obj, method_params);", mi.Name) + endline +
                        sep(2) + "}" + endline;

                }
                #endregion

                #region properties
                String property_lines = "";
                foreach (PropertyInfo pi in dll_type.GetProperties())
                {
                    property_lines += 
                        sep(2) + String.Format("public {0} {1} ", pi.PropertyType.FullName, pi.Name) + endline +
                        sep(2) + "{ " + endline +
                            sep(3) + "get { " + endline +
                                sep(4) + String.Format("return tobj.GetProperty(\"{0}\").GetValue(obj);", pi.Name) + endline +
                            sep(3) + "} " + endline +
                            sep(3) + "set { " + endline +
                                sep(4) + String.Format("tobj.GetProperty(\"{0}\").SetValue(obj, value); ", pi.Name) + endline +
                            sep(3) + "} " + endline +
                        sep(2) + "}" + endline;
                    
                }
                #endregion

                #region add ns
                dll_lines += ns_lines.Replace("vars_lines", var_lines)
                    .Replace("constructor", constr_lines)
                    .Replace("property_lines", property_lines)
                    .Replace("method_lines", methods_lines);
                #endregion
            }
            return dll_lines;
        }

        #region util

        public String sep(int n)
        {
            return ("").PadLeft(n * 3, ' ');
        }

        #endregion
    }
}
