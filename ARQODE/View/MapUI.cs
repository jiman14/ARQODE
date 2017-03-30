using System;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace ARQODE_VISUAL_EDITOR
{
    public partial class MapUI : Form
    {
        #region Load main form

        static String TiposBasicos = "int,int32,int64,unsignedint,long,float,double,boolean,char,bit";
        static String PropiedadesNoSerializables = "isempty,all,horizontal,vertical";
        static String desp = "\t";
        private Control main_control = null;
        bool theres_errors = false;
        ArrayList lista_guids;
        String App_path;

        public MapUI(String app_path="")
        {
            InitializeComponent();
            App_path = app_path;

            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                String name = t.FullName.Replace("ARQODE_VISUAL_EDITOR.", "");
                if (name.IndexOf(".") > 0)
                {
                    name = name.Substring(0, name.IndexOf("."));
                    if (((t.BaseType.Name == "Form") || (t.BaseType.Name == "UserControl")) &&
                        (CBProyectos.Items.IndexOf(name) < 0))
                    {
                        CBProyectos.Items.Add(name);
                    }
                }
            }            
        }

        private void TBProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBForms.Items.Clear();
            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                String name = t.FullName.Replace("ARQODE_VISUAL_EDITOR.", "");
                if (((t.BaseType.Name == "Form") || (t.BaseType.Name == "UserControl")) &&
                        (name.StartsWith(CBProyectos.Text)))                    
                {
                    name = name.Substring(name.IndexOf(".")+1);
                    CBForms.Items.Add(name);
                }
            }
        }

        #endregion

        #region Open form

        /// <summary>
        /// Abrir formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BVerForm_Click(object sender, EventArgs e)
        {
            if (CBForms.Text != "")
            {
                Type type_control = Type.GetType("ARQODE_VISUAL_EDITOR." + CBProyectos.Text + "." + CBForms.Text);
                Form f1 = null;
                if (type_control.BaseType.Name == "Form")
                {
                    f1 = (Form)Activator.CreateInstance(type_control);
                }
                else
                {
                    f1 = new Form();
                    f1.Controls.Add((Control)Activator.CreateInstance(type_control));
                    f1.WindowState = FormWindowState.Maximized;
                    CBDialogo.Checked = false;
                }

                if (!CBDialogo.Checked)
                {
                    f1.Show();
                }
                else
                {
                    DialogResult dr = f1.ShowDialog();
                    MessageBox.Show("Retorno de la ventana de diálogo: " + dr.ToString());
                }
            }
            else
            {
                MessageBox.Show("Selecciona una ventana primero en el desplegable.");
            }
        }
        #endregion

        #region Generar código para ARQODE UI

        /// <summary>
        /// Generar código para ARQODE UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BGenerar_Click(object sender, EventArgs e)
        {
            if (CBForms.Text != "")
            {
                Type type_control = Type.GetType("ARQODE_VISUAL_EDITOR." + CBProyectos.Text + "." + CBForms.Text);                

                main_control = (Control)Activator.CreateInstance(type_control);

                lista_guids = new ArrayList();
                String controls_str = RecursiveLoad(main_control);

                TB_Preview.Text = validate_json(controls_str);
            }
        }

        /// <summary>
        /// Cabecera del fichero de controles
        /// </summary>
        /// <returns></returns>
        private String File_header()
        {
            String header = "{" +
                "\"$schema\": \"..\\\\Schemas\\\\Schema_base_control.json\", \r\n" +
                "\"description\": \"\", \r\n" +
                "\"Variables\": [ ], \r\n" +
                "\"Controls\": [ \r\n";

            return header;
        }

        /// <summary>
        /// Recorre los controles extrayendo su configuración
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private String RecursiveLoad(Control ctrl)
        {
            String ChildControlsList = "";
            String ChildControls_str = "";
            foreach (Control child_ctrl in ctrl.Controls)
            {
                if (child_ctrl.Name != "")
                {
                    ChildControlsList += "\"" + child_ctrl.Name + "\", ";
                    ChildControls_str += RecursiveLoad(child_ctrl);
                }
            }

            if ((ctrl.ContextMenuStrip != null) && (!lista_guids.Contains(ctrl.ContextMenuStrip.Name))) {
                ChildControls_str += RecursiveLoad(ctrl.ContextMenuStrip);
            }


ChildControlsList = (ChildControlsList.Length > 0) ?
                desp + "\"Controls\": [ " +
                ChildControlsList.Substring(0, ChildControlsList.Length - 2) + "], \r\n ": "";

            String Guid = "";
            String Type = "";
            String Class_Path = "";
            if ((ctrl is Form) || (ctrl is UserControl))
            {
                Guid = String.Format(desp + "\"Guid\": \"{0}\", \r\n", ctrl.Name);
                Class_Path = String.Format(desp + "\"Class_Path\": \"{0}.{1}.{2}\", \r\n", "ARQODE_VISUAL_EDITOR", CBProyectos.SelectedItem.ToString(), ctrl.Name);
                Type = String.Format(desp + "\"Type\": \"{0}\", \r\n", ctrl.GetType().BaseType.FullName);
            }
            else
            {
                Guid = String.Format(desp + "\"Guid\": \"{0}\", \r\n", ctrl.Name);
                Type = String.Format(desp + "\"Type\": \"{0}\", \r\n", ((Object)ctrl).GetType().ToString());
            }
            String Description = String.Format(desp + "\"Description\": \"{0}\", \r\n", ctrl.Tag);
            String Version = String.Format(desp + "\"Version\": \"{0}\", \r\n", ctrl.ProductVersion);

            String control = "{ \r\n" +
                Guid +
                Class_Path +
                Type +
                Description +
                Version +
                Configuration(ctrl) + // get configuration string
                //Eventos(ctrl) +
                ChildControlsList +
                "}, \r\n";

            lista_guids.Add(ctrl.Name);

            return control + ChildControls_str;
        }

        /// <summary>
        /// Get control configuration
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected String Configuration(Control ctrl)
        {            
            String Cfg_str = "";
            // Common configuration
            Cfg_str += (ctrl.Dock != DockStyle.Fill)? GetProperty(ctrl, "Size"): "";
            Cfg_str += (ctrl.Dock == DockStyle.None)? GetProperty(ctrl, "Location"): "";
            Cfg_str += (ctrl.Dock != DockStyle.None)? GetProperty(ctrl, "Dock"): "";
            Cfg_str += (ctrl.TabIndex > 0)? GetProperty(ctrl, "TabIndex"): "";
            Cfg_str += (ctrl.Text != "") ? GetProperty(ctrl, "Text") : "";
            Cfg_str += (ctrl.Padding.All != 0) ? GetProperty(ctrl, "Padding") : "";
            Cfg_str += (ctrl.Margin.All != 0) ? GetProperty(ctrl, "Margin") : "";
            Cfg_str += (!ctrl.MinimumSize.IsEmpty)? GetProperty(ctrl, "MinimumSize"): "";            

            String Configuration = desp + "\"Configuration\":{ \r\n " +
                Cfg_str +
                FormConfiguration(ctrl) +
                PanelConfiguration(ctrl) +
                LabelConfiguration(ctrl) +
                TextBoxConfiguration(ctrl) +
                DataGridViewonfiguration(ctrl) +
                desp + "}, \r\n";

            return Configuration;
        }

        #region Configuración personalizada por tipo de control

        /// <summary>
        /// Form special configuration
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected String FormConfiguration(Control ctrl)
        {
            String Cfg_str = "";
            if (ctrl is Form)
            {
                Form f = (Form)ctrl;                
                
                Cfg_str += (f.TopMost)? GetProperty(ctrl, "TopMost"): "";
                Cfg_str += (f.WindowState != FormWindowState.Normal)? GetProperty(ctrl, "WindowState") : "";
                Cfg_str += (f.StartPosition != FormStartPosition.WindowsDefaultLocation)? GetProperty(ctrl, "StartPosition") : "";
                Cfg_str += (f.AllowDrop) ? GetProperty(ctrl, "AllowDrop") : "";
            }
            return Cfg_str;
        }
        /// <summary>
        /// Panel special configuration
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected String PanelConfiguration(Control ctrl)
        {
            String Cfg_str = "";
            if (ctrl is Panel)
            {
                Panel p = (Panel)ctrl;

                Cfg_str += (p.AllowDrop) ? GetProperty(ctrl, "AllowDrop") : "";
                Cfg_str += (p.AutoScroll) ? GetProperty(ctrl, "AutoScroll") : "";
                Cfg_str += GetProperty(ctrl, "AutoScrollMinSize");
                Cfg_str += (p.VerticalScroll.Enabled) ? GetProperty(ctrl, "VerticalScroll", "Enabled") : "";
                Cfg_str += (p.HorizontalScroll.Enabled) ? GetProperty(ctrl, "HorizontalScroll", "Enabled") : "";
            }
            return Cfg_str;
        }
        /// <summary>
        /// Label special configuration
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected String LabelConfiguration(Control ctrl)
        {
            String Cfg_str = "";
            if (ctrl is Label)
            {
                Label l = (Label)ctrl;
                Cfg_str += (l.TextAlign != ContentAlignment.MiddleCenter) ? GetProperty(ctrl, "TextAlign") : "";
            }
            return Cfg_str;
        }
        /// <summary>
        /// TextBox special configuration
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected String TextBoxConfiguration(Control ctrl)
        {
            String Cfg_str = "";
            if (ctrl is TextBox)
            {
                TextBox tb = (TextBox)ctrl;
                Cfg_str += (tb.ReadOnly) ? GetProperty(ctrl, "ReadOnly") : "";
                Cfg_str += (tb.Multiline) ? GetProperty(ctrl, "Multiline") : "";
                Cfg_str += (tb.ScrollBars != ScrollBars.None) ? GetProperty(ctrl, "ScrollBars") : "";
            }
            return Cfg_str;
        }
        /// <summary>
        /// DataGridView special configuration
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected String DataGridViewonfiguration(Control ctrl)
        {
            String Cfg_str = "";
            if (ctrl is DataGridView)
            {
                DataGridView d = (DataGridView)ctrl;
                
                Cfg_str += GetProperty(ctrl, "EditMode");
                Cfg_str += (d.MultiSelect)? GetProperty(ctrl, "MultiSelect"): "";
                Cfg_str += GetProperty(ctrl, "SelectionMode");
                Cfg_str += (d.ScrollBars != ScrollBars.None)? GetProperty(ctrl, "ScrollBars"): "";
                Cfg_str += GetProperty(ctrl, "AllowUserToAddRows");
                Cfg_str += GetProperty(ctrl, "AllowUserToDeleteRows");
                Cfg_str += GetProperty(ctrl, "AllowUserToOrderColumns");
                Cfg_str += GetProperty(ctrl, "AllowUserToResizeColumns");
                Cfg_str += GetProperty(ctrl, "AllowUserToResizeRows");
                Cfg_str += (d.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.None)? GetProperty(ctrl, "AutoSizeColumnsMode") : "";
                Cfg_str += GetProperty(ctrl, "MultiSelect");
                Cfg_str += GetProperty(ctrl, "SelectionMode");
                Cfg_str += GetProperty(ctrl, "ColumnHeadersHeightSizeMode");
                Cfg_str += GetProperty(ctrl, "RowHeadersWidthSizeMode");
                Cfg_str += GetProperty(ctrl, "AlternatingRowsDefaultCellStyle", "BackColor");
            }
            return Cfg_str;
        }
        #endregion

        #region Configuración propiedades genéricas


        /// <summary>
        /// Get property and subproperty as string
        /// </summary>
        /// <param name="c"></param>
        /// <param name="prop"></param>
        /// <param name="sub_prop"></param>
        /// <param name="tab"></param>
        /// <returns></returns>
        protected String GetProperty(object c, String prop, String sub_prop="", String tab = "\t\t")
        {
            Type tc = c.GetType();
            String str_ret = "";
            String plantilla_comillas = tab+"\"{0}\": \"{1}\", \r\n";
            String plantilla = tab+"\"{0}\":{1}, \r\n";

            foreach (PropertyInfo pi in tc.GetProperties())
            {
                if ((pi.Name == prop) || (prop == ""))
                {
                    if (pi.PropertyType == typeof(Color))
                    {
                        if (!((Color)pi.GetValue(c)).IsEmpty)
                        {
                            str_ret += String.Format(plantilla_comillas, prop, ColorTranslator.ToHtml((Color)pi.GetValue(c)));
                        }
                    }
                    else if (pi.PropertyType == typeof(Keys))
                    {
                        str_ret += String.Format(plantilla_comillas, prop, new KeysConverter().ConvertToString((Keys)pi.GetValue(c)));
                    }
                    else if (pi.PropertyType == typeof(Image))
                    {
                        str_ret += String.Format(plantilla_comillas, "Image", "");
                    }
                    else if (pi.PropertyType == typeof(Icon))
                    {
                        str_ret += String.Format(plantilla_comillas, "Icon", "");
                    }
                    else if (pi.PropertyType == typeof(Font))
                    {
                        Font f = (Font)pi.GetValue(c);

                        if (f != null)
                        {
                            String font_style = String.Format(plantilla_comillas, "FontStyle", f.Style.ToString());
                            String familyName = String.Format(plantilla_comillas, "familyName", f.FontFamily.Name);
                            String emSize = String.Format(plantilla, "emSize", f.Size.ToString());
                            str_ret += tab + "\"Font\":{ " + font_style + familyName + emSize + tab + "} \r\n";
                        }
                    }
                    else if (pi.PropertyType.BaseType == typeof(Enum))
                    {
                        //int n = (int) pi.GetValue(c);
                        str_ret += String.Format(plantilla_comillas, prop, pi.GetValue(c).ToString());
                    }
                    else if (pi.PropertyType == typeof(String))
                    {
                        if (pi.GetValue(c).ToString() != "")
                        {
                            str_ret += String.Format(plantilla_comillas, prop, pi.GetValue(c).ToString());
                        }
                    }
                    else if (pi.PropertyType == typeof(Boolean))
                    {
                        str_ret += String.Format(plantilla, prop, pi.GetValue(c).ToString().ToLower());
                    }
                    else if (TiposBasicos.Contains(pi.PropertyType.Name.ToLower()))
                    {
                        if (c.ToString() != "")
                        {                            
                            str_ret += String.Format(plantilla, prop, pi.GetValue(c).ToString());
                        }
                    }
                    else if (pi.PropertyType == typeof(Padding))
                    {
                        Padding p = (Padding)pi.GetValue(c);
                        String datos_padding = " {" +
                            String.Format("\"Top\": {0}, ", p.Top.ToString()) +
                            String.Format("\"Right\": {0}, ", p.Right.ToString()) +
                            String.Format("\"Bottom\": {0}, ", p.Bottom.ToString()) +
                            String.Format("\"Left\": {0}", p.Left.ToString()) + " }";
                        str_ret += String.Format(plantilla, pi.PropertyType.Name, datos_padding);
                    }
                    else if (pi.PropertyType == typeof(Size))
                    {
                        Size p = (Size)pi.GetValue(c);
                        String datos_padding = " {" +
                            String.Format("\"Width\": {0}, ", p.Width.ToString()) +
                            String.Format("\"Height\": {0}", p.Height.ToString()) + " }";
                        str_ret += String.Format(plantilla, pi.Name, datos_padding);
                    }
                    else if (pi.PropertyType == typeof(Point))
                    {
                        Point p = (Point)pi.GetValue(c);
                        if ((pi.Name == "Location") && ((p.X != 0) || (p.Y != 0)))
                        {
                            String datos_padding = " {" +
                                String.Format("\"X\": {0}, ", p.X.ToString()) +
                                String.Format("\"Y\": {0}", p.Y.ToString()) + " }";
                            str_ret += String.Format(plantilla, pi.Name, datos_padding);
                        }
                    }                    
                    else 
                    {
                        object c1 = pi.GetValue(c);

                        if (c1 != null)
                        {
                            if (c1.GetType() == c.GetType())
                            {
                                str_ret += String.Format(plantilla_comillas, prop, pi.GetValue(c).ToString());
                            }
                            else
                            {
                                String str_child = "";
                                foreach (PropertyInfo pi_child in c1.GetType().GetProperties())
                                {
                                    if (!PropiedadesNoSerializables.Contains(pi_child.Name.ToLower()))
                                        if (sub_prop == pi_child.Name)
                                        {
                                            str_child += GetProperty(c1, pi_child.Name, "", tab + "\t");
                                        }
                                }
                                str_ret += tab + "\"" + pi.Name + "\":{\r\n" + str_child + tab + "}, \r\n";
                            }
                        }
                    }
                }
            }
            return str_ret;
        }
        #endregion

        /// <summary>
        /// Get events configuration
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected String Eventos(Control ctrl)
        {
            String eventos_str = "";
            String plantilla = "\t\t\"{0}\": \"\", \r\n";
            Type tc = ctrl.GetType();
            foreach (EventInfo ei in tc.GetEvents())
            {
                if (ei.EventHandlerType != null)
                {
                    eventos_str += String.Format(plantilla, ei.Name);
                }
            }
            return
                "\t\"Events\": { \r\n" +
                eventos_str +
                "\t}, \r\n";
        }
        #endregion

        #region Guardar y validar fichero json

        private void BGuardar_Click(object sender, EventArgs e)
        {
            // Regenerate before save
            BGenerar_Click(null, null);

            if (!theres_errors) 
            {
                SaveDiag.InitialDirectory = App_path;
                SaveDiag.FileName = main_control.Name + ".json";

                if (SaveDiag.ShowDialog() == DialogResult.OK)
                {
                    bool write_file = true;
                    if (File.Exists(SaveDiag.FileName))
                    {
                        write_file = MergeFiles(SaveDiag.FileName);
                    }
                    if (write_file)
                    {
                        File.WriteAllText(SaveDiag.FileName, TB_Preview.Text);
                        MessageBox.Show("Archivo guardado");
                    }
                }
            }
            else
            {
                if (TB_Preview.Text == "")
                {
                    MessageBox.Show("Antes de guardar es necesario generar el código");
                }
                else
                {
                    MessageBox.Show("Corrige los errores antes de guardar el fichero");
                }
            }
        }
        private bool MergeFiles(String original_file)
        {
            bool filesMerged = true;
            try
            {
                String foriginal = File.ReadAllText(original_file);
                JObject joriginal = JObject.Parse(foriginal);

                JObject jnewfile = JObject.Parse(TB_Preview.Text);
                JArray jNewControls = (JArray)jnewfile["Controls"];

                JArray jOriginalControls = (JArray) joriginal["Controls"];
                foreach (JToken jcontrol in jNewControls)
                {
                    // insert events
                    JToken jEvent = getEventsByGuid(jOriginalControls, jcontrol["Guid"].ToString());
                    if (jEvent != null)
                    {
                        jcontrol["Events"] = jEvent;
                    }
                }

                // copy objects
                if (joriginal["Objects"] != null)
                {
                    jnewfile.Add("Objects", joriginal["Objects"]);
                }
                // Merge Variables
                jnewfile["Variables"].Replace(joriginal["Variables"]);

                TB_Preview.Text = jnewfile.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error validando json del fichero original: " + exc.Message);
                filesMerged = false;
            }
            return filesMerged;
        }
        private JToken getEventsByGuid(JArray jOriginalControls, String guid)
        {
            JToken jEvent = null;
            foreach (JToken jcontrol in jOriginalControls)
            {
                if (jcontrol["Guid"].ToString() == guid)
                {
                    jEvent = jcontrol["Events"];
                    break;
                }
            }
            return jEvent;
        }

        private String validate_json(String controls_json)
        {
            try
            {
                controls_json = File_header() + controls_json + "\r\n] \r\n }";
                JObject job = JObject.Parse(controls_json);
                theres_errors = false;
                return job.ToString();
            }
            catch(Exception exc)
            {                
                String[] lineas_preview = controls_json.Split('\n');
                String texto_error = "";
                int n = 1;
                foreach (String str in lineas_preview)
                {
                    texto_error += n.ToString() + ": " + str + "\r\n";
                    n++;
                }
                theres_errors = true;
                return "Error validando json: " + exc.Message + "\r\n\r\n" + texto_error;
            }
        }
        #endregion
    }
}
