using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using TControls;
using ARQODE_Core;

namespace TLogic
{
    public class CMap
    {

        #region Init CMap

        String app_name;
        String app_path;
        String arqode_path;
        bool views_modified = false;
        String strViewList = "";
        String system_app_path;
        bool ForceReMap = false;

        public CMap(String System_app_path, String App_path, String Arqode_app_path, String App_name)
        {
            app_path = App_path;
            arqode_path = Arqode_app_path;
            app_name = App_name;
            system_app_path = System_app_path;
        }
        #endregion

        #region Map Views

        /// <summary>
        /// Maps all views
        /// </summary>
        public void MapViews(bool forceReMap = false)
        {
            try
            {
                ForceReMap = forceReMap;
                String fileName = String.Format(dGLOBALS.MAPS_VIEWS, app_name);
                JObject JViews = initFile(fileName);
                views_modified = false;

                // recorrer todas las vistas recursivamente y si no están en el array meterlas            
                RecursiveAddFiles(new DirectoryInfo(Path.Combine(app_path, dPATH.VIEWS.Replace(".", "\\"))), JViews);

                // eliminar las vistas ya mapeadas que se hayan eliminado
                RemoveDeletedViews(JViews);

                // save if modified
                if (views_modified)
                {
                    writeFile(fileName, JViews);
                }
            }
            catch
            {
                views_modified = false;
            }
        }

        /// <summary>
        /// Remove deleted views in maps
        /// </summary>
        /// <param name="JViews"></param>
        private void RemoveDeletedViews(JObject JViews)
        {
            for (int i = 0; i < (JViews[dEXPORTCODE.VIEWS_MAPS_CLASSES] as JArray).Count; i++)
            {
                JToken JView = (JViews[dEXPORTCODE.VIEWS_MAPS_CLASSES] as JArray).ElementAt(i);
                if (!strViewList.Contains(JView[dPROCESS.NAMESPACE].ToString()))
                {
                    JView.Remove();
                    i--;
                }
            }
        }

        /// <summary>
        /// Generate Map view class
        /// </summary>
        /// <param name="JViews"></param>
        private void writeClass(JToken jview)
        {
            String maps_path = Path.Combine(arqode_path,
                (app_name != dGLOBALS.SYSTEM_APP) ? dEXPORTCODE.VS_PJ_UI_PATH : dEXPORTCODE.ARQODE_PJ_UI_PATH);
            
            String endline = "\r\n";

            String start_file = "using System; " + endline +
                            "using TControls; " + endline +
                            "using Newtonsoft.Json.Linq;" + endline + endline;


            String ns = jview[dPROCESS.NAMESPACE].ToString().Replace(".json", "");
            String[] folders = ns.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            String map_path = maps_path;
            for (int i = 0; i < folders.Length - 1; i++)
            {
                map_path = Path.Combine(map_path, folders[i]);
                if (!Directory.Exists(map_path))
                {
                    Directory.CreateDirectory(map_path);
                }
            }
            map_path = Path.Combine(map_path, folders[folders.Length - 1] + dEXPORTCODE.VIEW_MAP_CS_SUFIX);

            String file = start_file + jview[dEXPORTCODE.VIEWS_MAPS_ITEM].ToString() + endline;

            File.WriteAllText(map_path, file);
        }

        /// <summary>
        /// Map view
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fi"></param>
        /// <param name="JProgram"></param>
        private void MapView(String path, FileInfo fi, JToken JViews)
        {
            bool view_modified = false;
            JObject JNewView = null;

            try
            {
                // Lista de paths actualizada para eliminar posteriormente del fichero de mapeos las vistas con namespaces no incluidos en la lista
                strViewList += path + " |";

                JObject JView = (JObject)JViews.SelectToken(String.Format("$.{0}[?(@.{1} == '{2}')]", 
                                    dEXPORTCODE.VIEWS_MAPS_CLASSES, dPROCESS.NAMESPACE,  path));
                
                String endline = "\r\n";

                // si es nulo o si el timestamp es distinto
                if ((JView == null) || (ForceReMap) || ((JView != null) && (JView[dEXPORTCODE.VIEWS_MAPS_TIMESTAMP].ToString() != fi.LastWriteTime.ToString())))
                {
                    JNewView = new JObject();
                    JNewView.Add(dPROCESS.NAMESPACE, path);
                    JNewView.Add(dEXPORTCODE.VIEWS_MAPS_TIMESTAMP, fi.LastWriteTime.ToString());
                    String control_path = path.Replace(".json", "");

                    // read view file
                    JObject JViewFile = JObject.Parse(File.ReadAllText(fi.FullName));

                    #region Map controls

                    JArray JControls = (JArray)JViewFile[dCONTROLS.CONTROLS];
                    bool first_control = true;
                    String view_name = "";
                    String Declaration_lines = "";
                    String Constructor_lines = "";
                    String Constructor = "";
                    foreach (JToken Jcontrol in JControls)
                    {
                        String current_guid = (Jcontrol[dCONTROLS.GUID].ToString().Contains(".")) ? Jcontrol[dCONTROLS.GUID].ToString().Substring(Jcontrol[dCONTROLS.GUID].ToString().LastIndexOf(".") + 1) :
                                                                    Jcontrol[dCONTROLS.GUID].ToString();
                        if (first_control)
                        {
                            view_name = "C" + escape_sc(current_guid);

                            // Map namespace
                            String str_namespace = path.Replace(".json", "");
                            str_namespace = (str_namespace.Contains(".")) ? "." + str_namespace.Substring(0, str_namespace.LastIndexOf(".")) : "";
                            if (app_name != dGLOBALS.SYSTEM_APP)
                            {
                                Declaration_lines += String.Format("namespace TLogic.Views{0}", escape_sc(str_namespace)) + endline + " { " + endline;
                            }
                            else
                            {
                                Declaration_lines += String.Format("namespace TLogic.ARQODE_UI{0}", escape_sc(str_namespace)) + endline + " { " + endline;
                            }
                            // Map class
                            Declaration_lines += String.Format("public class {0}", view_name) + endline + " { " + endline;
                            Declaration_lines += "public static String _JSON { get { return \"" +
                                Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(JViewFile.ToString())) +
                                "\"; } }" + endline +
                                "public JObject MappedView { get { return JObject.Parse(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(_JSON))); } } " + endline;

        // Map main view
                            Constructor = "public CView view; " + endline +
                                           "public " + view_name + " (CViewsManager vm) { #CONSTRUCTOR_LINES# }";

                            Constructor_lines += "view = (vm.getFirstView(\"" + control_path + "\") != null)? vm.getFirstView(\"" + control_path + "\"): vm.AddView(\"" + control_path + "\");" + endline;

                            first_control = false;
                        }
                        else
                        {
                            control_path = current_guid;
                        }
                        // Map control

                        if (!Declaration_lines.Contains(" " + escape_sc(current_guid)+ ";"))
                        {
                            String str_type = Jcontrol[dCONTROLS.TYPE].ToString();
                            Declaration_lines += String.Format("public {0} {1};", str_type, escape_sc(current_guid)) + endline;
                            Constructor_lines += String.Format("{0} = ({1}) view.getCtrl(\"{2}\");", escape_sc(current_guid), str_type, control_path) + endline;

                            // Map control struct
                            Declaration_lines += String.Format("public CView.CtrlStruct {0}_cstr;", escape_sc(current_guid)) + endline;
                            Constructor_lines += String.Format("{0}_cstr = view.getCtrlStruct(\"{1}\");", escape_sc(current_guid), control_path) + endline;

                            // Map controls vars
                            Declaration_lines += map_var_control(current_guid, control_path) + endline;
                        }
                    }

                    #endregion

                    #region Map vars

                    JArray JVars = (JArray)JViewFile[dCONTROLS.VARIABLES];

                    foreach (JToken jVar in JVars)
                    {
                        String var = jVar.ToString().Trim();
                        if (var != "") Declaration_lines += map_var(var) + endline;
                    }

                    #endregion

                    #region Map objects

                    String object_lines = "";

                    if (JViewFile[dCONTROLS.OBJECTS] != null)
                    {
                        JArray JObjects = (JArray)JViewFile[dCONTROLS.OBJECTS];
                        foreach (JToken Jobject in JObjects)
                        {
                            String object_guid = Jobject[dCONTROLS.GUID].ToString();
                            String class_object_guid = "o_" + escape_sc(object_guid);

                            Declaration_lines += String.Format("public {0} {1};", class_object_guid, escape_sc(object_guid)) + endline;
                            Constructor_lines += String.Format("{0} = new {1}(view);", escape_sc(object_guid), class_object_guid) + endline;

                            object_lines +=
                                        "public class " + class_object_guid + endline +
                                        "{" + endline +
                                        "CView view = null;" + endline +
                                        "public CView.ObjStruct Obj_str { get { return view.getObjStruct(\"" + object_guid + "\"); } }" + endline +
                                        "public " + class_object_guid + "(CView v) { view = v; }" + endline +
                                        "#METODOS#" +
                                        "}" + endline;

                            String methods_lines = "";
                            int i = 0;
                            foreach (JToken metodos in Jobject[dCONTROLS.OBJECTS_METHODS])
                            {
                                String nombre_metodo = ((JObject)metodos.Parent).Properties().ElementAt(i).Name;
                                i++;
                                methods_lines +=
                                        "public object " + escape_sc(nombre_metodo) + "()" + endline +
                                        "{" + endline +
                                        "return view.MethodCall(\"" + object_guid + "\", \"" + nombre_metodo + "\", null);" + endline +
                                        "}" + endline;
                                methods_lines +=
                                        "public object " + escape_sc(nombre_metodo) + "(#PARAMETROS#)" + endline +
                                        "{" + endline +
                                        "return view.MethodCall(\"" + object_guid + "\", \"" + nombre_metodo + "\", new object[] { #PARAMETROS1# });" + endline +
                                        "}" + endline;
                                String parameters_lines = "";
                                String sep = "";
                                int j = 0;
                                foreach (JToken jParam in metodos.First[dCONTROLS.OBJECTS_PARAMETERS])
                                {
                                    parameters_lines += sep + "object " + ((JObject)jParam.Parent).Properties().ElementAt(j).Name;
                                    j++;
                                    sep = ", ";
                                }
                                methods_lines = methods_lines.Replace("#PARAMETROS#", parameters_lines);
                                methods_lines = methods_lines.Replace("#PARAMETROS1#", parameters_lines.Replace("object ", ""));

                            }
                            object_lines = object_lines.Replace("#METODOS#", methods_lines);
                        }
                    }

                    #endregion


                    Declaration_lines = Declaration_lines + Constructor.Replace("#CONSTRUCTOR_LINES#", Constructor_lines) + "}" + endline + object_lines + endline + "}" + endline;

                    JNewView.Add(dEXPORTCODE.VIEWS_MAPS_ITEM, Declaration_lines);
                    view_modified = true;
                }

                // reemplazar por el nuevo (si lo hay) o asignar si es nulo
                if (JView == null)
                {
                    (JViews[dEXPORTCODE.VIEWS_MAPS_CLASSES] as JArray).Add(JNewView);
                    views_modified = true;
                }
                else if (JNewView != null)
                {
                    JView.Replace(JNewView);
                    views_modified = true;
                }
            }
            catch
            {
                views_modified = false;
                view_modified = false;
            }

            if (view_modified)
            {
                // generate class
                writeClass(JNewView);
            }
        }
        #endregion

        #region Map vars

        /// <summary>
        /// Map all vars to process coder!
        /// </summary>
        /// <param name="JInputs"></param>
        /// <param name="JOutputs"></param>
        /// <param name="JConfig"></param>
        /// <param name="JProgram"></param>
        /// <returns></returns>
        public String MapVars(JArray JInputs, JArray JOutputs, JArray JConfig, Dictionary<String, object> programVars)
        {
            try {
                String endline = "\r\n";
                String allVars = "";

                if (programVars.Keys.Count() > 0)
                {
                    allVars += "\t\t\t\t// Program vars" + endline;
                    foreach (String var in programVars.Keys)
                    {
                        allVars += "\t\t\t\tobject P_" + escape_sc(var) + " = prc.vars[\"" + var + "\"];";
                    }
                }

                if (JInputs.Count > 0)
                {
                    allVars += endline + "\t\t\t\t// Inputs vars" + endline;
                    foreach (JToken v_input in JInputs)
                    {
                        String var = (v_input.ToString().StartsWith("-")) ? v_input.ToString().Substring(1) : v_input.ToString();
                        bool nullable = v_input.ToString().StartsWith("-");
                        allVars += "\t\t\t\tobject I_" + escape_sc(var) + " = Input(\"" + var + "\", " + nullable.ToString().ToLower() + "); " + endline;
                    }
                }

                if (JOutputs.Count > 0)
                {
                    allVars += endline + "\t\t\t\t// Outputs vars" + endline;
                    foreach (JToken v_output in JOutputs)
                    {
                        String var = v_output.ToString();
                        allVars += "\t\t\t\t//Outputs(\"" + var + "\", value); " + endline;
                    }
                }

                if ((JConfig != null) && (JConfig.Count > 0))
                {
                    allVars += endline + "\t\t\t\t// Configuration vars" + endline;
                    foreach (JToken v_config in JConfig)
                    {
                        String var = (v_config.ToString().StartsWith("-")) ? v_config.ToString().Substring(1) : v_config.ToString();
                        bool nullable = v_config.ToString().StartsWith("-");
                        allVars += "\t\t\t\tobject C_" + escape_sc(var) + " = Config(\"" + var + "\", " + nullable.ToString().ToLower() + "); " + endline;
                    }
                }
                if (allVars != "")
                {
                    allVars = allVars + endline;
                }

                return allVars;
            }
            catch
            {
                views_modified = false;
                return "";
            }
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Maps vars
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private String map_var(String var)
        {
            String tipo = "object";
            if (var.EndsWith("_s")) tipo = "String";
            else if (var.EndsWith("_i")) tipo = "int";
            else if (var.EndsWith("_l")) tipo = "long";
            else if (var.EndsWith("_f")) tipo = "float";
            else if (var.EndsWith("_d")) tipo = "double";
            else if (var.EndsWith("_b")) tipo = "bool";
            else if (var.EndsWith("_jt")) tipo = "JToken";
            else if (var.EndsWith("_ja")) tipo = "JArray";
            else if (var.EndsWith("_jo")) tipo = "JObject";

            return "public " + tipo + " " + escape_sc(var) + " { get { return (view.vars.ContainsKey(\"" + var + "\"))? (" + tipo + ")view.vars[\"" + var + "\"]: null; } set { view.vars[\"" + var + "\"] = value; } }";
        }
        /// <summary>
        ///  Map var control
        /// </summary>
        /// <param name="ctrl_guid"></param>
        /// <returns></returns>
        private String map_var_control(String ctrl_guid, String ctrl_path = "")
        {
            if (ctrl_path == "") ctrl_path = ctrl_guid;
            return "public object " + escape_sc(ctrl_guid) + "_vars(String var, object value = null) \r\n" +
                    "{ \r\n" +
                    "\tif (value != null)  view.CtrlVars(\"" + ctrl_path + "\")[var] = value; \r\n" +
                    "\treturn (object)view.CtrlVars(\"" + ctrl_path + "\")[var];\r\n" +
                    "}";
        }
        /// <summary>
        /// Recusrive tree explorer
        /// </summary>
        /// <param name="di"></param>
        /// <param name="JContent"></param>
        /// <param name="map_case"></param>
        /// <param name="path"></param>
        private void RecursiveAddFiles(DirectoryInfo di, JToken JContent, String path = "")
        {
            try
            {
                foreach (DirectoryInfo di_child in di.GetDirectories())
                {
                    String fpath = path + "." + di_child.Name;
                    RecursiveAddFiles(di_child, JContent, fpath);
                }
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Name != dCONTROLS.BASE_CONTROL)
                    {
                        String fpath = (path != "") ? path.Substring(1) + "." + fi.Name : fi.Name;
                        MapView(fpath, fi, JContent);
                    }
                }
            }
            catch
            {
                views_modified = false;
            }
        }
        /// <summary>
        /// Get map object
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private JObject initFile(String file)
        {
            JObject JContent = null;
            
            if (new DirectoryInfo(Path.Combine(system_app_path, dPATH.MAPS.Replace(".", "\\"))).GetFiles(file).Count() <= 0)
            {
                JContent = new JObject();
                JContent.Add(dEXPORTCODE.VIEWS_MAPS_CLASSES, new JArray());
            }
            else
            {
                JContent = JObject.Parse(File.ReadAllText(new DirectoryInfo(Path.Combine(system_app_path, dPATH.MAPS.Replace(".", "\\"))).GetFiles(file)[0].FullName));
            }

            return JContent;
        }
        private void writeFile(String file, JToken JContent)
        {
            File.WriteAllText(Path.Combine(new DirectoryInfo(Path.Combine(system_app_path, dPATH.MAPS.Replace(".", "\\"))).FullName, file), JContent.ToString());
        }
        /// <summary>
        /// Escapar carácteres especiales
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private String escape_sc(String cadena)
        {

            String escape_chars = "á,é,í,ó,ú,Á,É,Í,Ó,Ú, ,ñ,Ñ,ü,Ü,-,(,)";
            String replace_escape_chars = "a,e,i,o,u,A,E,I,O,U,_,n,N,u,U,_,_,_";
            String[] rec_array = replace_escape_chars.Split(',');
            int i = 0;
            foreach (String spc in escape_chars.Split(','))
            {
                cadena = cadena.Replace(spc, rec_array[i]);
                i++;
            }
            return cadena;
        }
        #endregion
       
    }

}
