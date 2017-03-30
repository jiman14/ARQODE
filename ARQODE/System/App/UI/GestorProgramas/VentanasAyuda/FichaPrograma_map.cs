using System; 
using TControls; 
using Newtonsoft.Json.Linq;

namespace TLogic.ARQODE_UI.GestorProgramas.VentanasAyuda
 { 
public class CFichaPrograma
 { 
public static String _JSON { get { return "ew0KICAiJHNjaGVtYSI6ICIuLlxcU2NoZW1hc1xcU2NoZW1hX2Jhc2VfY29udHJvbC5qc29uIiwNCiAgImRlc2NyaXB0aW9uIjogIiIsDQogICJWYXJpYWJsZXMiOiBbDQogICAgIk5vdGVHdWlkIiwNCiAgICAiUnV0YSINCiAgXSwNCiAgIkNvbnRyb2xzIjogWw0KICAgIHsNCiAgICAgICJHdWlkIjogIkZpY2hhUHJvZ3JhbWEiLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuRm9ybSIsDQogICAgICAiRGVzY3JpcHRpb24iOiAiIiwNCiAgICAgICJWZXJzaW9uIjogIjEuMCIsDQogICAgICAiQ29uZmlndXJhdGlvbiI6IHsNCiAgICAgICAgIlRleHQiOiAiUHJvZ3JhbSBmb3JtIiwNCiAgICAgICAgIk1pbmltdW1TaXplIjogew0KICAgICAgICAgICJXaWR0aCI6IDUwMCwNCiAgICAgICAgICAiSGVpZ2h0IjogMzgwDQogICAgICAgIH0sDQogICAgICAgICJGb250Ijogew0KICAgICAgICAgICJmYW1pbHlOYW1lIjogIkFyaWFsIiwNCiAgICAgICAgICAiZW1TaXplIjogMTAuMQ0KICAgICAgICB9LA0KICAgICAgICAiQmFja0NvbG9yIjogIldoaXRlIiwNCiAgICAgICAgIkZvcm1Cb3JkZXJTdHlsZSI6IDUsDQogICAgICAgICJTdGFydFBvc2l0aW9uIjogMSwNCiAgICAgICAgIlRvcE1vc3QiOiBmYWxzZQ0KICAgICAgfSwNCiAgICAgICJDb250cm9scyI6IFsNCiAgICAgICAgIkNvbnRlbnRfcGFuZWwiDQogICAgICBdLA0KICAgICAgIkV2ZW50cyI6IHt9DQogICAgfSwNCiAgICB7DQogICAgICAiR3VpZCI6ICJDb250ZW50X3BhbmVsIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLlBhbmVsIiwNCiAgICAgICJEZXNjcmlwdGlvbiI6ICIiLA0KICAgICAgIlZlcnNpb24iOiAiMS4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiRG9jayI6IDUsDQogICAgICAgICJCYWNrQ29sb3IiOiAiV2hpdGUiDQogICAgICB9LA0KICAgICAgIkNvbnRyb2xzIjogWw0KICAgICAgICAicm93X3BhbmVsXzMiLA0KICAgICAgICAicm93X3BhbmVsXzIiLA0KICAgICAgICAicm93X3BhbmVsXzEiLA0KICAgICAgICAicm93X3BhbmVsX2hlYWQiDQogICAgICBdLA0KICAgICAgIkV2ZW50cyI6IHt9DQogICAgfSwNCiAgICB7DQogICAgICAiR3VpZCI6ICJyb3dfcGFuZWxfaGVhZCIsDQogICAgICAiVHlwZSI6ICJTeXN0ZW0uV2luZG93cy5Gb3Jtcy5QYW5lbCIsDQogICAgICAiRGVzY3JpcHRpb24iOiAiIiwNCiAgICAgICJWZXJzaW9uIjogIjEuMCIsDQogICAgICAiQ29uZmlndXJhdGlvbiI6IHsNCiAgICAgICAgIkhlaWdodCI6IDYwLA0KICAgICAgICAiRG9jayI6IDEsDQogICAgICAgICJNYXJnaW4iOiB7DQogICAgICAgICAgIkFsbCI6IDMwDQogICAgICAgIH0NCiAgICAgIH0sDQogICAgICAiQ29udHJvbHMiOiBbDQogICAgICAgICJsYWJlbF9oZWFkIg0KICAgICAgXQ0KICAgIH0sDQogICAgew0KICAgICAgIkd1aWQiOiAibGFiZWxfaGVhZCIsDQogICAgICAiVHlwZSI6ICJTeXN0ZW0uV2luZG93cy5Gb3Jtcy5MYWJlbCIsDQogICAgICAiRGVzY3JpcHRpb24iOiAiIiwNCiAgICAgICJWZXJzaW9uIjogIjEuMCIsDQogICAgICAiQ29uZmlndXJhdGlvbiI6IHsNCiAgICAgICAgIkZvbnQiOiB7DQogICAgICAgICAgImZhbWlseU5hbWUiOiAiQXJpYWwiLA0KICAgICAgICAgICJlbVNpemUiOiAxMi4xLA0KICAgICAgICAgICJGb250U3R5bGUiOiAxDQogICAgICAgIH0sDQogICAgICAgICJBdXRvU2l6ZSI6IHRydWUsDQogICAgICAgICJUZXh0IjogIkVkaXQgZmllbGRzIiwNCiAgICAgICAgIkxlZnQiOiAxNDAsDQogICAgICAgICJUb3AiOiAyMA0KICAgICAgfQ0KICAgIH0sDQogICAgew0KICAgICAgIkd1aWQiOiAicm93X3BhbmVsXzEiLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuUGFuZWwiLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICIxLjAiLA0KICAgICAgIkNvbmZpZ3VyYXRpb24iOiB7DQogICAgICAgICJIZWlnaHQiOiAzMCwNCiAgICAgICAgIkRvY2siOiAxLA0KICAgICAgICAiTWFyZ2luIjogew0KICAgICAgICAgICJBbGwiOiA1DQogICAgICAgIH0NCiAgICAgIH0sDQogICAgICAiQ29udHJvbHMiOiBbDQogICAgICAgICJ0Yl9ub21icmVfcHJvZ3JhbWEiLA0KICAgICAgICAibF9ub21icmUiDQogICAgICBdDQogICAgfSwNCiAgICB7DQogICAgICAiR3VpZCI6ICJsX25vbWJyZSIsDQogICAgICAiVHlwZSI6ICJTeXN0ZW0uV2luZG93cy5Gb3Jtcy5MYWJlbCIsDQogICAgICAiRGVzY3JpcHRpb24iOiAiIiwNCiAgICAgICJWZXJzaW9uIjogIjEuMCIsDQogICAgICAiQ29uZmlndXJhdGlvbiI6IHsNCiAgICAgICAgIkZvbnQiOiB7DQogICAgICAgICAgIkZvbnRTdHlsZSI6IDENCiAgICAgICAgfSwNCiAgICAgICAgIlRleHRBbGlnbiI6IDQsDQogICAgICAgICJUZXh0IjogIlRpdGxlOiIsDQogICAgICAgICJXaWR0aCI6IDI0MCwNCiAgICAgICAgIkhlaWdodCI6IDMwLA0KICAgICAgICAiVG9wIjogMw0KICAgICAgfQ0KICAgIH0sDQogICAgew0KICAgICAgIkd1aWQiOiAidGJfbm9tYnJlX3Byb2dyYW1hIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLlRleHRCb3giLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICIxLjAiLA0KICAgICAgIkNvbmZpZ3VyYXRpb24iOiB7DQogICAgICAgICJUYWJJbmRleCI6IDAsDQogICAgICAgICJMZWZ0IjogMjUwLA0KICAgICAgICAiV2lkdGgiOiAyMDANCiAgICAgIH0NCiAgICB9LA0KICAgIHsNCiAgICAgICJHdWlkIjogInJvd19wYW5lbF8yIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLlBhbmVsIiwNCiAgICAgICJEZXNjcmlwdGlvbiI6ICIiLA0KICAgICAgIlZlcnNpb24iOiAiMS4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiSGVpZ2h0IjogMzAsDQogICAgICAgICJEb2NrIjogMSwNCiAgICAgICAgIk1hcmdpbiI6IHsNCiAgICAgICAgICAiQWxsIjogNQ0KICAgICAgICB9DQogICAgICB9LA0KICAgICAgIkNvbnRyb2xzIjogWw0KICAgICAgICAidGJfZGVzY3JpcGNpb24iLA0KICAgICAgICAibF9kZXNjcmlwY2lvbiINCiAgICAgIF0NCiAgICB9LA0KICAgIHsNCiAgICAgICJHdWlkIjogImxfZGVzY3JpcGNpb24iLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuTGFiZWwiLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICIxLjAiLA0KICAgICAgIkNvbmZpZ3VyYXRpb24iOiB7DQogICAgICAgICJGb250Ijogew0KICAgICAgICAgICJGb250U3R5bGUiOiAxDQogICAgICAgIH0sDQogICAgICAgICJUZXh0QWxpZ24iOiA0LA0KICAgICAgICAiVGV4dCI6ICJEZXNjcmlwdGlvbjoiLA0KICAgICAgICAiV2lkdGgiOiAyNDAsDQogICAgICAgICJIZWlnaHQiOiAzMCwNCiAgICAgICAgIlRvcCI6IDMNCiAgICAgIH0NCiAgICB9LA0KICAgIHsNCiAgICAgICJHdWlkIjogInRiX2Rlc2NyaXBjaW9uIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLlRleHRCb3giLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICIxLjAiLA0KICAgICAgIkNvbmZpZ3VyYXRpb24iOiB7DQogICAgICAgICJUYWJJbmRleCI6IDEsDQogICAgICAgICJMZWZ0IjogMjUwLA0KICAgICAgICAiV2lkdGgiOiAyMDANCiAgICAgIH0NCiAgICB9LA0KICAgIHsNCiAgICAgICJHdWlkIjogInJvd19wYW5lbF8zIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLlBhbmVsIiwNCiAgICAgICJEZXNjcmlwdGlvbiI6ICIiLA0KICAgICAgIlZlcnNpb24iOiAiMS4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiSGVpZ2h0IjogNjAsDQogICAgICAgICJEb2NrIjogMSwNCiAgICAgICAgIk1hcmdpbiI6IHsNCiAgICAgICAgICAiQWxsIjogNQ0KICAgICAgICB9DQogICAgICB9LA0KICAgICAgIkNvbnRyb2xzIjogWw0KICAgICAgICAiYnV0dG9uX3NhdmUiLA0KICAgICAgICAiYnV0dG9uX2NhbmNlbCINCiAgICAgIF0NCiAgICB9LA0KICAgIHsNCiAgICAgICJHdWlkIjogImJ1dHRvbl9zYXZlIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLkJ1dHRvbiIsDQogICAgICAiRGVzY3JpcHRpb24iOiAiIiwNCiAgICAgICJWZXJzaW9uIjogIjEuMCIsDQogICAgICAiQ29uZmlndXJhdGlvbiI6IHsNCiAgICAgICAgIlRhYkluZGV4IjogMiwNCiAgICAgICAgIkZvbnQiOiB7DQogICAgICAgICAgIkZvbnRTdHlsZSI6IDENCiAgICAgICAgfSwNCiAgICAgICAgIlRleHQiOiAiU2F2ZSIsDQogICAgICAgICJXaWR0aCI6IDEwMCwNCiAgICAgICAgIkRvY2siOiAwLA0KICAgICAgICAiVG9wIjogMjAsDQogICAgICAgICJMZWZ0IjogMjEwDQogICAgICB9LA0KICAgICAgIkV2ZW50cyI6IHsNCiAgICAgICAgIkNsaWNrIjogIkdlc3Rpw7NuIGRlIFByb2dyYW1hcy5Fc3RydWN0dXJhY2nDs24uTnVldm8gcHJvZ3JhbWEiDQogICAgICB9DQogICAgfSwNCiAgICB7DQogICAgICAiR3VpZCI6ICJidXR0b25fY2FuY2VsIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLkJ1dHRvbiIsDQogICAgICAiRGVzY3JpcHRpb24iOiAiIiwNCiAgICAgICJWZXJzaW9uIjogIjEuMCIsDQogICAgICAiQ29uZmlndXJhdGlvbiI6IHsNCiAgICAgICAgIlRhYkluZGV4IjogMiwNCiAgICAgICAgIkZvbnQiOiB7DQogICAgICAgICAgIkZvbnRTdHlsZSI6IDENCiAgICAgICAgfSwNCiAgICAgICAgIlRleHQiOiAiQ2FuY2VsIiwNCiAgICAgICAgIldpZHRoIjogMTAwLA0KICAgICAgICAiRG9jayI6IDAsDQogICAgICAgICJUb3AiOiAyMCwNCiAgICAgICAgIkxlZnQiOiAzMjANCiAgICAgIH0sDQogICAgICAiRXZlbnRzIjoge30NCiAgICB9DQogIF0NCn0="; } }
public JObject MappedView { get { return JObject.Parse(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(_JSON))); } } 
public System.Windows.Forms.Form FichaPrograma;
public CView.CtrlStruct FichaPrograma_cstr;
public object FichaPrograma_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("GestorProgramas.VentanasAyuda.FichaPrograma")[var] = value; 
	return (object)view.CtrlVars("GestorProgramas.VentanasAyuda.FichaPrograma")[var];
}
public System.Windows.Forms.Panel Content_panel;
public CView.CtrlStruct Content_panel_cstr;
public object Content_panel_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("Content_panel")[var] = value; 
	return (object)view.CtrlVars("Content_panel")[var];
}
public System.Windows.Forms.Panel row_panel_head;
public CView.CtrlStruct row_panel_head_cstr;
public object row_panel_head_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("row_panel_head")[var] = value; 
	return (object)view.CtrlVars("row_panel_head")[var];
}
public System.Windows.Forms.Label label_head;
public CView.CtrlStruct label_head_cstr;
public object label_head_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("label_head")[var] = value; 
	return (object)view.CtrlVars("label_head")[var];
}
public System.Windows.Forms.Panel row_panel_1;
public CView.CtrlStruct row_panel_1_cstr;
public object row_panel_1_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("row_panel_1")[var] = value; 
	return (object)view.CtrlVars("row_panel_1")[var];
}
public System.Windows.Forms.Label l_nombre;
public CView.CtrlStruct l_nombre_cstr;
public object l_nombre_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("l_nombre")[var] = value; 
	return (object)view.CtrlVars("l_nombre")[var];
}
public System.Windows.Forms.TextBox tb_nombre_programa;
public CView.CtrlStruct tb_nombre_programa_cstr;
public object tb_nombre_programa_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("tb_nombre_programa")[var] = value; 
	return (object)view.CtrlVars("tb_nombre_programa")[var];
}
public System.Windows.Forms.Panel row_panel_2;
public CView.CtrlStruct row_panel_2_cstr;
public object row_panel_2_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("row_panel_2")[var] = value; 
	return (object)view.CtrlVars("row_panel_2")[var];
}
public System.Windows.Forms.Label l_descripcion;
public CView.CtrlStruct l_descripcion_cstr;
public object l_descripcion_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("l_descripcion")[var] = value; 
	return (object)view.CtrlVars("l_descripcion")[var];
}
public System.Windows.Forms.TextBox tb_descripcion;
public CView.CtrlStruct tb_descripcion_cstr;
public object tb_descripcion_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("tb_descripcion")[var] = value; 
	return (object)view.CtrlVars("tb_descripcion")[var];
}
public System.Windows.Forms.Panel row_panel_3;
public CView.CtrlStruct row_panel_3_cstr;
public object row_panel_3_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("row_panel_3")[var] = value; 
	return (object)view.CtrlVars("row_panel_3")[var];
}
public System.Windows.Forms.Button button_save;
public CView.CtrlStruct button_save_cstr;
public object button_save_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("button_save")[var] = value; 
	return (object)view.CtrlVars("button_save")[var];
}
public System.Windows.Forms.Button button_cancel;
public CView.CtrlStruct button_cancel_cstr;
public object button_cancel_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("button_cancel")[var] = value; 
	return (object)view.CtrlVars("button_cancel")[var];
}
public object NoteGuid { get { return (view.vars.ContainsKey("NoteGuid"))? (object)view.vars["NoteGuid"]: null; } set { view.vars["NoteGuid"] = value; } }
public object Ruta { get { return (view.vars.ContainsKey("Ruta"))? (object)view.vars["Ruta"]: null; } set { view.vars["Ruta"] = value; } }
public CView view; 
public CFichaPrograma (CViewsManager vm) { view = (vm.getFirstView("GestorProgramas.VentanasAyuda.FichaPrograma") != null)? vm.getFirstView("GestorProgramas.VentanasAyuda.FichaPrograma"): vm.AddView("GestorProgramas.VentanasAyuda.FichaPrograma");
FichaPrograma = (System.Windows.Forms.Form) view.getCtrl("GestorProgramas.VentanasAyuda.FichaPrograma");
FichaPrograma_cstr = view.getCtrlStruct("GestorProgramas.VentanasAyuda.FichaPrograma");
Content_panel = (System.Windows.Forms.Panel) view.getCtrl("Content_panel");
Content_panel_cstr = view.getCtrlStruct("Content_panel");
row_panel_head = (System.Windows.Forms.Panel) view.getCtrl("row_panel_head");
row_panel_head_cstr = view.getCtrlStruct("row_panel_head");
label_head = (System.Windows.Forms.Label) view.getCtrl("label_head");
label_head_cstr = view.getCtrlStruct("label_head");
row_panel_1 = (System.Windows.Forms.Panel) view.getCtrl("row_panel_1");
row_panel_1_cstr = view.getCtrlStruct("row_panel_1");
l_nombre = (System.Windows.Forms.Label) view.getCtrl("l_nombre");
l_nombre_cstr = view.getCtrlStruct("l_nombre");
tb_nombre_programa = (System.Windows.Forms.TextBox) view.getCtrl("tb_nombre_programa");
tb_nombre_programa_cstr = view.getCtrlStruct("tb_nombre_programa");
row_panel_2 = (System.Windows.Forms.Panel) view.getCtrl("row_panel_2");
row_panel_2_cstr = view.getCtrlStruct("row_panel_2");
l_descripcion = (System.Windows.Forms.Label) view.getCtrl("l_descripcion");
l_descripcion_cstr = view.getCtrlStruct("l_descripcion");
tb_descripcion = (System.Windows.Forms.TextBox) view.getCtrl("tb_descripcion");
tb_descripcion_cstr = view.getCtrlStruct("tb_descripcion");
row_panel_3 = (System.Windows.Forms.Panel) view.getCtrl("row_panel_3");
row_panel_3_cstr = view.getCtrlStruct("row_panel_3");
button_save = (System.Windows.Forms.Button) view.getCtrl("button_save");
button_save_cstr = view.getCtrlStruct("button_save");
button_cancel = (System.Windows.Forms.Button) view.getCtrl("button_cancel");
button_cancel_cstr = view.getCtrlStruct("button_cancel");
 }}

}

