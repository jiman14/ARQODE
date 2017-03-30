#region Copyright © 2015, 2016 MJM [info.ARQODE@gmail.com]
/*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.

* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
* GNU General Public License for more details.

* You should have received a copy of the GNU General Public License
* along with this program.If not, see<http:* www.gnu.org/licenses/>.
*/

using System;
using System.IO;
using Newtonsoft.Json.Linq;
using ARQODE_Core;

namespace TLogic
{
    public static class CLogicEditor
    {
        /// <summary>
        /// Send code to editor
        /// </summary>
        /// <param name="arqode_path"></param>
        /// <param name="sys_app_path"></param>
        /// <param name="app_path"></param>
        /// <param name="app_name"></param>
        /// <param name="p_guid"></param>
        /// <param name="prc"></param>
        public static void SendCodeToEditor(String app_path, String app_name, String p_guid, TProcess prc)
        {
            CGlobals sys_globals = new CGlobals();
            String sys_app_path = sys_globals.App_path.FullName;
            String arqode_path = sys_globals.ARQODE_APP;

            // Save code in editor
            String editor_prc_guid = SaveCode(arqode_path, prc.Guid);

            if (prc.Guid != editor_prc_guid)
            {

                // get map vars code
                CMap cmap = new CMap(sys_app_path, app_path, arqode_path, app_name);

                // Map changes in views 
                cmap.MapViews();

                // Map all vars
                String varsregion = cmap.MapVars(prc.BaseInputs as JArray, prc.BaseOutputs as JArray, prc.BaseConfiguration as JArray, prc.vars);

                // Get code file
                String codefile_path = Path.Combine(arqode_path, dEXPORTCODE.P_CODER_CS);
                String codefile = File.ReadAllText(codefile_path);

                // get code from logic or from process json file
                String codigo_prc = get_Code_from_logic(arqode_path, p_guid);
                if ((codigo_prc == "") && (prc.Code != null) && (prc.Code.ToString() != ""))
                {
                    codigo_prc = System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(prc.Code.ToString()));
                }

                if (codigo_prc != "")
                {
                    if (((dEXPORTCODE.P_Ini_code_process_mark + p_guid) == codigo_prc.Split('\n')[0].Replace("\r", "")) && (codefile.Contains(dEXPORTCODE.P_Begin_editor_code_mark)))
                    {
                        int write_code_index = write_code_index = codefile.IndexOf(dEXPORTCODE.P_Begin_editor_code_mark) + dEXPORTCODE.P_Begin_editor_code_mark.Length;

                        codefile = codefile.Insert(write_code_index, "\n\n" + codigo_prc);
                        File.WriteAllText(codefile_path, codefile);
                    }
                }
                else
                {
                    String prc_name = "//" + prc.Name.ToString();
                    codigo_prc = dEXPORTCODE.P_Ini_code_process_mark + p_guid + "\n" + prc_name + "\n\n" + varsregion + "\n\n" + dEXPORTCODE.P_End_code_process_mark + p_guid;
                    int write_code_index = write_code_index = codefile.IndexOf(dEXPORTCODE.P_Begin_editor_code_mark) + dEXPORTCODE.P_Begin_editor_code_mark.Length;
                    codefile = codefile.Insert(write_code_index, "\n\n" + codigo_prc);

                    File.WriteAllText(codefile_path, codefile);
                }
            }
        }

        /// <summary>
        /// Get code from logic
        /// </summary>
        /// <param name="arqode_path"></param>
        /// <param name="p_guid"></param>
        /// <returns></returns>
        public static String get_Code_from_logic(String arqode_path, String p_guid)
        {
            String logicfile_path = Path.Combine(arqode_path, dEXPORTCODE.P_LOGIC_CS);
            String logicfile = File.ReadAllText(logicfile_path);

            bool founded = false;
            int start_index = 0;
            while (!founded)
            {
                int ini_code = logicfile.IndexOf(dEXPORTCODE.P_Ini_code_process_mark + p_guid, start_index);
                start_index = ini_code + (dEXPORTCODE.P_Ini_code_process_mark + p_guid).Length;
                if (ini_code > 0)
                {
                    if (logicfile.Substring(ini_code).Substring(0, logicfile.Substring(ini_code).IndexOf("\n")).Trim() == dEXPORTCODE.P_Ini_code_process_mark + p_guid)
                    {
                        founded = true;
                        int fin_code = logicfile.IndexOf(dEXPORTCODE.P_End_code_process_mark + p_guid);
                        if (fin_code > 0)
                        {
                            return logicfile.Substring(ini_code, (fin_code + (dEXPORTCODE.P_End_code_process_mark + p_guid).Length) - ini_code);
                        }
                    }
                }
                else
                {
                    founded = true;
                }
            }
            return "";
        }

        /// <summary>
        /// Get code from editor
        /// </summary>
        /// <param name="arqode_path"></param>
        /// <returns></returns>
        public static String get_Code_from_editor(String arqode_path, ref String p_guid)
        {
            String codefile_path = Path.Combine(arqode_path, dEXPORTCODE.P_CODER_CS);
            String codefile = File.ReadAllText(codefile_path);

            int ini_code = 0;
            int fin_code = 0;
            String codigo_prc_editor = "";

            if (codefile.Contains(dEXPORTCODE.P_Ini_code_process_mark))
            {
                ini_code = codefile.IndexOf(dEXPORTCODE.P_Ini_code_process_mark);
                String temp_code = codefile.Substring(ini_code);
                p_guid = temp_code.Substring(dEXPORTCODE.P_Ini_code_process_mark.Length, temp_code.IndexOf("\n") - dEXPORTCODE.P_Ini_code_process_mark.Length).Replace("\n", "").Trim();

                if (ini_code > 0)
                {
                    fin_code = codefile.IndexOf(dEXPORTCODE.P_End_code_process_mark + p_guid);
                    if (fin_code > 0)
                    {
                        codigo_prc_editor = codefile.Substring(ini_code, (fin_code + (dEXPORTCODE.P_End_code_process_mark + p_guid).Length) - ini_code);
                    }
                }
            }
            return codigo_prc_editor;
        }

        /// <summary>
        /// Save code in editor
        /// </summary>
        /// <param name="arqode_path"></param>
        /// <param name="p_guid"></param>
        public static String SaveCode(String arqode_path, String new_prc_guid = "")
        {
            // comprobar si hay código en el editor y guardar en clogic
            String codefile_path = Path.Combine(arqode_path, dEXPORTCODE.P_CODER_CS);
            String codefile = File.ReadAllText(codefile_path);

            String logicfile_path = Path.Combine(arqode_path, dEXPORTCODE.P_LOGIC_CS);
            String logicfile = File.ReadAllText(logicfile_path);

            int ini_code = 0;
            int fin_code = 0;
            String codigo_prc = "";

            String p_guid = "";
            String codigo_prc_editor = get_Code_from_editor(arqode_path, ref p_guid);

            if ((p_guid != "") && (new_prc_guid != p_guid))
            {
                ini_code = logicfile.IndexOf(dEXPORTCODE.P_Ini_code_process_mark + p_guid);
                if (ini_code > 0)
                {
                    fin_code = logicfile.IndexOf(dEXPORTCODE.P_End_code_process_mark + p_guid);
                    if (fin_code > 0)
                    {
                        codigo_prc = logicfile.Substring(ini_code, (fin_code + (dEXPORTCODE.P_End_code_process_mark + p_guid).Length) - ini_code);

                        // Cambiar código del proceso actual por código del editor
                        if (codigo_prc != codigo_prc_editor)
                        {
                            logicfile = logicfile.Replace(codigo_prc, codigo_prc_editor);
                            File.WriteAllText(logicfile_path, logicfile);
                        }
                    }
                }
                else
                {
                    // buscar marca de fin en el fichero de lógica e insertar ahí el código del editor

                    ini_code = logicfile.IndexOf(dEXPORTCODE.P_End_logic_code);
                    if (ini_code > 0)
                    {
                        // poner case

                        String Init_case = String.Format("\t\t\t\t\tcase \"{0}\":\n", p_guid) + "{\n";
                        String End_case = "\n\t\t\t\t\t}\nbreak;\n";

                        logicfile = logicfile.Insert(ini_code - 1, Init_case + codigo_prc_editor + End_case);
                        File.WriteAllText(logicfile_path, logicfile);
                    }
                }

                codefile = codefile.Replace(codigo_prc_editor, "");
                ini_code = codefile.IndexOf(dEXPORTCODE.P_Begin_editor_code_mark);
                fin_code = codefile.LastIndexOf(dEXPORTCODE.P_End_editor_code_mark);
                codefile = codefile.Replace(codefile.Substring(ini_code + dEXPORTCODE.P_Begin_editor_code_mark.Length, fin_code - (ini_code + dEXPORTCODE.P_Begin_editor_code_mark.Length)), "\r\n");
                File.WriteAllText(codefile_path, codefile);
            }

            return p_guid;
        }
    }
}
#endregion