using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using ARQODE_Core;
using TControls;

namespace TLogic
{
    partial class CLogic
    {
        #region Inputs management

        /// <summary>
        /// Gets program & views variables by name as object
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Input(String name)
        {
            return Input(name, false);
        }
        /// <summary>
        /// Gets program & views variables by name as object
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Input_nullable(String name)
        {
            return Input(name, true);
        }
        /// <summary>
        /// Gets program & views variables in jtoken node as jtoken
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public JToken _Input_j(bool nullable, params String[] property_list)
        {
            JToken jItem = null;
            foreach (String prop in property_list)
            {
                if (jItem == null)
                {
                    object res = Input(prop, nullable);
                    if ((res as JToken) != null) jItem = res as JToken;
                    else jItem = new JValue(res);
                }
                else jItem = jItem[prop];
            }
            return jItem;
        }
        /// <summary>
        /// Gets program & views variables in jtoken node as jtoken
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public JToken Input_j(params String[] property_list)
        {
            return _Input_j(false, property_list);
        }
        /// <summary>
        /// Gets program & views variables in jtoken node as jtoken
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public JToken Input_j_nullable(params String[] property_list)
        {
            return _Input_j(true, property_list);
        }
        /// <summary>
        /// Gets program & views variables in jtoken node as jarray
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public JArray Input_jarray(params String[] property_list)
        {
            return Input_j(property_list) as JArray;
        }
        /// <summary>
        /// Gets program & views variables in jtoken node as string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String Input_str(params String[] property_list)
        {
            try
            {
                return Input_j(property_list).ToString();
            }
            catch (Exception exc)
            {
                errors.noInputs = property_list[0].ToString() + ": Error" + exc.Message;
                return "";
            }
        }
        /// <summary>
        /// Gets program & views variables by name, get error only if MustExists is true
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Input(String name, bool nullable)
        {
            String var_name = (prc.Inputs[name] != null) ? prc.Inputs[name].ToString() : prc.Inputs["-" + name].ToString();            
            if (!String.IsNullOrEmpty(var_name))
            {
                if (var_name.Contains("."))
                {
                    String[] tname = var_name.Split('.');
                    String var = tname[tname.Length - 1];
                    String source = var_name.Replace("." + var, "");

                    if (source.StartsWith(dGLOBALS.GLOBALS))
                    {
                        return Globals.get(source, var);
                    }
                    else
                    {
                        CView cv = ((view != null) && (source == view.Name)) ? view : vm.getFirstView(source);

                        if (cv != null)
                        {
                            if (cv.vars.Keys.Contains(var))
                            {
                                return cv.vars[var];
                            }
                            else
                            {
                                if (!nullable) errors.noInputs = String.Format("Error: Var: '{0}' not found in view: {1}", var, source);
                            }
                        }
                        else
                        {
                            if (!nullable) errors.noInputs = String.Format("Error: view {0} not found, and must content var: {1}", source, var);
                        }
                    }
                }
                else
                {
                    if (prc.vars.Keys.Contains(var_name))
                    {
                        return prc.vars[var_name];
                    }
                    else
                    {
                        if (!nullable) errors.noInputs = String.Format("Error: program var: '{0}' not found", var_name);
                    }
                }
            }
            return null;
        }
        #endregion       

        #region Configuration

        /// <summary>
        /// Get active process configuration by name (must exists)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Config(String name)
        {
            return Config(name, false);
        }
        /// <summary>
        /// Get active process configuration by name (can be nullable)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Config_nullable(String name)
        {
            return Config(name, true);
        }
        /// <summary>
        /// Get active process configuration by name (checking if reports an error)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Config(String name, bool nullable)
        {
            if ((prc.Configuration[name] != null) || (prc.Configuration["-" + name] != null))
            {
                return (prc.Configuration[name] != null)? prc.Configuration[name]: prc.Configuration["-" + name];
            }
            else if (!nullable)
            {
                errors.noConfiguration = String.Format("Error: configuration var '{0}' not found", name);
                return null;
            }
            else { return null; }
        }
        /// <summary>
        /// Get active process configuration by name as string (not nullable)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String Config_str(String name)
        {
            return Config(name, false).ToString();
        }
        /// <summary>
        /// Get active process configuration by name as string (nullable)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String Config_str_nullable(String name)
        {
            object val = Config(name, true);
            return (val != null) ? val.ToString() : "";
        }
        /// <summary>
        /// Get active process configuration by name as int
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Config_int(String name)
        {
            try
            {
                return int.Parse(Config(name, false).ToString());
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// Get active process configuration by name as int (nullable)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Config_int_nullable(String name)
        {
            try
            {
                return int.Parse(Config(name, true).ToString());
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Get active process configuration by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object Config(int index)
        {
            if (prc.Configuration[index] != null)
            {
                return prc.Configuration[index];
            }
            else
            {
                errors.noConfiguration = String.Format("Error: configuration var index '{0}' not found", index);
                return null;
            }
        }
        #endregion

        #region Outputs

        /// <summary>
        /// Sets program and view vars by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Outputs(String name, object value)
        {
            String var_name = (prc.Outputs[name] !=null)? prc.Outputs[name].ToString(): prc.Outputs["-" + name].ToString();
            if (!String.IsNullOrEmpty(var_name))
            {
                if (var_name.Contains("."))
                {
                    String[] tname = var_name.Split('.');
                    String var = tname[tname.Length - 1];
                    String source = var_name.Replace("." + var, "");

                    CView cv = ((view != null) && (source == view.Name)) ? view : vm.getFirstView(source);
                    if (cv != null)
                    {
                        cv.vars[var] = value;
                    }
                    else
                    {
                        errors.noOutputs = String.Format("Error: view {0} not found, and must content var: {1}", source, var);
                    }
                }
                else
                {
                    prc.vars[var_name] = value;
                }
            }
        }

        #endregion
    }
}
