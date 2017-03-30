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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using JSonUtil;
using TControls;
using ARQODE_Core;

namespace TLogic
{
    public partial class CLogic
    {
    				/// #NAME#: #DESCRIPTION#
			public void f_Nuevo_programa()
			{
			//INI CODE PRCGUID: Nuevo programa
                TextBox tb_nombre_programa = (TextBox)view.getCtrl("tb_nombre_programa");
                TextBox tb_descripcion = (TextBox)view.getCtrl("tb_descripcion");
                String Ruta = view.var_str("Ruta");

                if (tb_nombre_programa.Text != "")
                {
                    ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                    DirectoryInfo pprog = Globals.AppDataSection(dPATH.PROGRAM);

                    FileInfo f_plantilla = pprog.GetFiles(dGLOBALS.PROGRAM_TEMPLATE)[0];
                    DirectoryInfo di = App_globals.AppDataSection(Path.Combine(dPATH.CODE, Ruta));

                    JSonFile jplantilla = new JSonFile(f_plantilla.FullName);
                    jplantilla.jActiveObj[dPROGRAM.NAME] = tb_nombre_programa.Text;
                    jplantilla.jActiveObj[dPROGRAM.DESCRIPTION] = tb_descripcion.Text;

                    String n_programa = tb_nombre_programa.Text.EndsWith(".json") ? tb_nombre_programa.Text : tb_nombre_programa.Text + ".json";
                    if (!File.Exists(Path.Combine(di.FullName, n_programa)))
                    {
                        JSonFile jprograma = new JSonFile(Path.Combine(di.FullName, n_programa));
                        jprograma.writeJsonFile(jplantilla.jActiveObj);
                        ((Form)view.mainControl()).Close();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un programa con este nombre");
                    }
                }
                //END CODE PRCGUID: Nuevo programa
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Nueva_carpeta_de_programa()
			{
			//INI CODE PRCGUID: Nueva carpeta de programa

                            TreeView ArbolProgramas = (TreeView)view.getCtrl("ArbolProgramas");
                            TreeNode N_ProgramaActivo = ArbolProgramas.SelectedNode;
                            if (N_ProgramaActivo.Name.EndsWith(".json")) N_ProgramaActivo = N_ProgramaActivo.Parent;

                            N_ProgramaActivo.Nodes.Add("New program folder (F2)");

                            //END CODE PRCGUID: Nueva carpeta de programa
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Eliminar_programa()
			{
			//INI CODE PRCGUID: Eliminar programa
                            TreeView ArbolProgramas = (TreeView)view.getCtrl("ArbolProgramas");

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if (ArbolProgramas.SelectedNode.FullPath.EndsWith(".json"))
                            {
                                CStructModifications csmod = new CStructModifications(sys, App_globals);
                                ArrayList listaProgramas = csmod.SearchProgramCalls_IOC(ArbolProgramas.SelectedNode.FullPath.Replace(dPROGRAM.FOLDER + "\\", "").Replace("\\", ".").Replace(".json", ""));
                                if (listaProgramas.Count <= 0)
                                {
                                    DirectoryInfo di = App_globals.AppDataSection(dPATH.CODE);

                                    File.Delete(Path.Combine(di.FullName, ArbolProgramas.SelectedNode.FullPath));
                                }
                                else
                                {
                                    String mensaje = "";
                                    DirectoryInfo pprog = App_globals.AppDataSection(dPATH.PROGRAM);
                                    foreach (String programa in listaProgramas) { mensaje += programa.Replace(pprog.FullName + "\\", "") + "\r\n"; }
                                    MessageBox.Show("No se puede eliminar el programa hasta que no se eliminen las siguientes referencias: \r\n" + mensaje);
                                }
                            }
                            else
                            {
                                String di_path = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, ArbolProgramas.SelectedNode.FullPath);
                                DirectoryInfo di = new DirectoryInfo(di_path);
                                if (di.GetFiles().Count() <= 0)
                                {
                                    di.Delete();
                                    ArbolProgramas.SelectedNode.Remove();
                                }
                                else
                                {
                                    MessageBox.Show("El directorio debe estar vacío para poder ser eliminado");
                                }

                            }
                            //END CODE PRCGUID: Eliminar programa
			}

			/// #NAME#: #DESCRIPTION#
			public void f_afcc100c_bcf1_43bc_8b91_c5c1fc199b68()
			{
			
			}

			/// #NAME#: #DESCRIPTION#
			public void f_1ff83da1_817c_4c05_bf34_579e43091bb0()
			{
			//INI CODE PRCGUID: 1ff83da1-817c-4c05-bf34-579e43091bb0

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                            if (CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath.Contains(dPROGRAM.FOLDER + "\\"))
                            {
                                String Origin_path = Clipboard.GetText();
                                DirectoryInfo pprog = App_globals.AppDataSection(dPATH.PROGRAM);
                                String Origin_full_path = Path.Combine(pprog.FullName, Origin_path.Replace(".", "\\") + ".json");

                                if (File.Exists(Origin_full_path))
                                {
                                    FileInfo fi = new FileInfo(Origin_full_path);
                                    String Target_full_path = Path.Combine(Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath), fi.Name);
                                    String Target_path = (CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath.Replace(dPROGRAM.FOLDER + "\\", "") + "." + fi.Name).Replace(".json", "").Replace("\\", ".");

                                    // Replace old program path ocurrencies
                                    CStructModifications csmod = new CStructModifications(sys, App_globals);
                                    csmod.MoveProgram(Origin_path, Target_path);

                                    // File move
                                    File.Move(Origin_full_path, Target_full_path);

                                    CVentanaProgramas.contextMenu_Programas.Items[2].Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("Debe cortar un programa del árbol de programas antes de pegarlo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe pegar el programa dentro del árbol de programas");
                            }


                            //END CODE PRCGUID: 1ff83da1-817c-4c05-bf34-579e43091bb0
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Renombrar_programa()
			{
			//INI CODE PRCGUID: Renombrar programa

                            TreeView ArbolProgramas = (TreeView)view.getCtrl("ArbolProgramas");
                            TreeNode N_ProgramaActivo = ArbolProgramas.SelectedNode;

                            ARQODE_UI.ARQODE_UI.CInputDialog CInputDialog = new ARQODE_UI.ARQODE_UI.CInputDialog(vm);
                            CInputDialog.InputDialog.AcceptButton = CInputDialog.BAceptar;
                            CInputDialog.InputDialog.CancelButton = CInputDialog.BCancelar;
                            CInputDialog.InputDialog.Text = "Renombrar carpeta";
                            CInputDialog.Label1.Text = "Nombre de la carpeta";
                            CInputDialog.textBox1.Text = N_ProgramaActivo.Text;

                            vm.Cancel_events = false;
                            DialogResult dr = CInputDialog.InputDialog.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                                CInputDialog.textBox1.Text = CInputDialog.textBox1.Text.Replace("\r\n", "");
                                String di_antiguo = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, N_ProgramaActivo.FullPath);
                                String di_nuevo = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName,
                                        N_ProgramaActivo.FullPath.Substring(0, N_ProgramaActivo.FullPath.LastIndexOf("\\")));

                                if (N_ProgramaActivo.Text.EndsWith(".json"))
                                {
                                    String nombre_f = (CInputDialog.textBox1.Text.ToLower().EndsWith(".json")) ? CInputDialog.textBox1.Text : CInputDialog.textBox1.Text + ".json";
                                    di_nuevo = Path.Combine(di_nuevo, nombre_f);

                                    CStructModifications csmod = new CStructModifications(sys, App_globals);
                                    String from_path = N_ProgramaActivo.FullPath.Replace(dPROGRAM.FOLDER + "\\", "").Replace("\\", ".").Replace(".json", "");
                                    String to_path = Path.Combine(N_ProgramaActivo.FullPath.Substring(0, N_ProgramaActivo.FullPath.LastIndexOf("\\")), nombre_f).Replace(dPROGRAM.FOLDER + "\\", "").Replace("\\", ".").Replace(".json", "");
                                    csmod.MoveProgram(from_path, to_path);

                                    File.Move(di_antiguo, di_nuevo);
                                    N_ProgramaActivo.Text = nombre_f;
                                }
                                else
                                {
                                    di_nuevo = Path.Combine(di_nuevo, CInputDialog.textBox1.Text);
                                    if (di_nuevo != di_antiguo)
                                    {
                                        if (Directory.Exists(di_antiguo))
                                        {
                                            DirectoryInfo di_ant = new DirectoryInfo(di_antiguo);
                                            di_ant.MoveTo(di_nuevo);
                                        }
                                        else
                                        {
                                            Directory.CreateDirectory(di_nuevo);
                                        }
                                        N_ProgramaActivo.Text = CInputDialog.textBox1.Text;
                                    }
                                }

                            }
                            //END CODE PRCGUID: Renombrar programa
			}

	
    }
}
#endregion