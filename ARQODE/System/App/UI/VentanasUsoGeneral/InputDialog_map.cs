using System; 
using TControls; 
using Newtonsoft.Json.Linq;

namespace TLogic.ARQODE_UI.ARQODE_UI
{ 
public class CInputDialog
 { 
String _JSON = "ew0KICAiJHNjaGVtYSI6ICIuLlxcU2NoZW1hc1xcU2NoZW1hX2Jhc2VfY29udHJvbC5qc29uIiwNCiAgImRlc2NyaXB0aW9uIjogIiIsDQogICJWYXJpYWJsZXMiOiBbXSwNCiAgIkNvbnRyb2xzIjogWw0KICAgIHsNCiAgICAgICJHdWlkIjogIklucHV0RGlhbG9nIiwNCiAgICAgICJDbGFzc19QYXRoIjogIkFSUU9ERV9WSVNVQUxfRURJVE9SLlZFTlRBTkFTX1VTT19HRU5FUkFMLklucHV0RGlhbG9nIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLkZvcm0iLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICIxLjAuMC4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiU2l6ZSI6IHsNCiAgICAgICAgICAiV2lkdGgiOiA2NDksDQogICAgICAgICAgIkhlaWdodCI6IDE3OQ0KICAgICAgICB9LA0KICAgICAgICAiVGV4dCI6ICJFbnRyYWRhIGRlIGRhdG9zIiwNCiAgICAgICAgIlBhZGRpbmciOiB7DQogICAgICAgICAgIlRvcCI6IDMsDQogICAgICAgICAgIlJpZ2h0IjogMywNCiAgICAgICAgICAiQm90dG9tIjogMywNCiAgICAgICAgICAiTGVmdCI6IDMNCiAgICAgICAgfQ0KICAgICAgfSwNCiAgICAgICJDb250cm9scyI6IFsNCiAgICAgICAgIlBDb250ZW5pZG8iLA0KICAgICAgICAicGFuZWwxIg0KICAgICAgXQ0KICAgIH0sDQogICAgew0KICAgICAgIkd1aWQiOiAiUENvbnRlbmlkbyIsDQogICAgICAiVHlwZSI6ICJTeXN0ZW0uV2luZG93cy5Gb3Jtcy5QYW5lbCIsDQogICAgICAiRGVzY3JpcHRpb24iOiAiIiwNCiAgICAgICJWZXJzaW9uIjogIjQuNi4xMDg3LjAiLA0KICAgICAgIkNvbmZpZ3VyYXRpb24iOiB7DQogICAgICAgICJEb2NrIjogIkZpbGwiLA0KICAgICAgICAiVGFiSW5kZXgiOiAxLA0KICAgICAgICAiUGFkZGluZyI6IHsNCiAgICAgICAgICAiVG9wIjogMywNCiAgICAgICAgICAiUmlnaHQiOiAzLA0KICAgICAgICAgICJCb3R0b20iOiAzLA0KICAgICAgICAgICJMZWZ0IjogMw0KICAgICAgICB9LA0KICAgICAgICAiQXV0b1Njcm9sbE1pblNpemUiOiB7DQogICAgICAgICAgIldpZHRoIjogMCwNCiAgICAgICAgICAiSGVpZ2h0IjogMA0KICAgICAgICB9LA0KICAgICAgICAiVmVydGljYWxTY3JvbGwiOiB7DQogICAgICAgICAgIkVuYWJsZWQiOiB0cnVlDQogICAgICAgIH0sDQogICAgICAgICJIb3Jpem9udGFsU2Nyb2xsIjogew0KICAgICAgICAgICJFbmFibGVkIjogdHJ1ZQ0KICAgICAgICB9DQogICAgICB9LA0KICAgICAgIkNvbnRyb2xzIjogWw0KICAgICAgICAiUFRleHRCb3giLA0KICAgICAgICAiUExhYmVsIg0KICAgICAgXQ0KICAgIH0sDQogICAgew0KICAgICAgIkd1aWQiOiAiUFRleHRCb3giLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuUGFuZWwiLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICI0LjYuMTA4Ny4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiRG9jayI6ICJGaWxsIiwNCiAgICAgICAgIlRhYkluZGV4IjogMSwNCiAgICAgICAgIlBhZGRpbmciOiB7DQogICAgICAgICAgIlRvcCI6IDMsDQogICAgICAgICAgIlJpZ2h0IjogMywNCiAgICAgICAgICAiQm90dG9tIjogMywNCiAgICAgICAgICAiTGVmdCI6IDMNCiAgICAgICAgfSwNCiAgICAgICAgIkF1dG9TY3JvbGxNaW5TaXplIjogew0KICAgICAgICAgICJXaWR0aCI6IDAsDQogICAgICAgICAgIkhlaWdodCI6IDANCiAgICAgICAgfSwNCiAgICAgICAgIlZlcnRpY2FsU2Nyb2xsIjogew0KICAgICAgICAgICJFbmFibGVkIjogdHJ1ZQ0KICAgICAgICB9LA0KICAgICAgICAiSG9yaXpvbnRhbFNjcm9sbCI6IHsNCiAgICAgICAgICAiRW5hYmxlZCI6IHRydWUNCiAgICAgICAgfQ0KICAgICAgfSwNCiAgICAgICJDb250cm9scyI6IFsNCiAgICAgICAgInRleHRCb3gxIg0KICAgICAgXQ0KICAgIH0sDQogICAgew0KICAgICAgIkd1aWQiOiAidGV4dEJveDEiLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuVGV4dEJveCIsDQogICAgICAiRGVzY3JpcHRpb24iOiAiIiwNCiAgICAgICJWZXJzaW9uIjogIjQuNi4xMDg3LjAiLA0KICAgICAgIkNvbmZpZ3VyYXRpb24iOiB7DQogICAgICAgICJTaXplIjogew0KICAgICAgICAgICJXaWR0aCI6IDYwNSwNCiAgICAgICAgICAiSGVpZ2h0IjogNDENCiAgICAgICAgfSwNCiAgICAgICAgIkxvY2F0aW9uIjogew0KICAgICAgICAgICJYIjogMTYsDQogICAgICAgICAgIlkiOiAzDQogICAgICAgIH0sDQogICAgICAgICJNdWx0aWxpbmUiOiB0cnVlDQogICAgICB9DQogICAgfSwNCiAgICB7DQogICAgICAiR3VpZCI6ICJQTGFiZWwiLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuUGFuZWwiLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICI0LjYuMTA4Ny4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiU2l6ZSI6IHsNCiAgICAgICAgICAiV2lkdGgiOiA2MzMsDQogICAgICAgICAgIkhlaWdodCI6IDM4DQogICAgICAgIH0sDQogICAgICAgICJEb2NrIjogIlRvcCIsDQogICAgICAgICJQYWRkaW5nIjogew0KICAgICAgICAgICJUb3AiOiAzLA0KICAgICAgICAgICJSaWdodCI6IDMsDQogICAgICAgICAgIkJvdHRvbSI6IDMsDQogICAgICAgICAgIkxlZnQiOiAzDQogICAgICAgIH0sDQogICAgICAgICJBdXRvU2Nyb2xsTWluU2l6ZSI6IHsNCiAgICAgICAgICAiV2lkdGgiOiAwLA0KICAgICAgICAgICJIZWlnaHQiOiAwDQogICAgICAgIH0sDQogICAgICAgICJWZXJ0aWNhbFNjcm9sbCI6IHsNCiAgICAgICAgICAiRW5hYmxlZCI6IHRydWUNCiAgICAgICAgfSwNCiAgICAgICAgIkhvcml6b250YWxTY3JvbGwiOiB7DQogICAgICAgICAgIkVuYWJsZWQiOiB0cnVlDQogICAgICAgIH0NCiAgICAgIH0sDQogICAgICAiQ29udHJvbHMiOiBbDQogICAgICAgICJMYWJlbDEiDQogICAgICBdDQogICAgfSwNCiAgICB7DQogICAgICAiR3VpZCI6ICJMYWJlbDEiLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuTGFiZWwiLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICI0LjYuMTA4Ny4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiU2l6ZSI6IHsNCiAgICAgICAgICAiV2lkdGgiOiA0MiwNCiAgICAgICAgICAiSGVpZ2h0IjogMTYNCiAgICAgICAgfSwNCiAgICAgICAgIkxvY2F0aW9uIjogew0KICAgICAgICAgICJYIjogMTMsDQogICAgICAgICAgIlkiOiAxMw0KICAgICAgICB9LA0KICAgICAgICAiVGV4dCI6ICJsYWJlbDEiLA0KICAgICAgICAiUGFkZGluZyI6IHsNCiAgICAgICAgICAiVG9wIjogMCwNCiAgICAgICAgICAiUmlnaHQiOiAzLA0KICAgICAgICAgICJCb3R0b20iOiAwLA0KICAgICAgICAgICJMZWZ0IjogMw0KICAgICAgICB9LA0KICAgICAgICAiVGV4dEFsaWduIjogIlRvcExlZnQiDQogICAgICB9DQogICAgfSwNCiAgICB7DQogICAgICAiR3VpZCI6ICJwYW5lbDEiLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuUGFuZWwiLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICI0LjYuMTA4Ny4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiU2l6ZSI6IHsNCiAgICAgICAgICAiV2lkdGgiOiA2MzMsDQogICAgICAgICAgIkhlaWdodCI6IDU2DQogICAgICAgIH0sDQogICAgICAgICJEb2NrIjogIkJvdHRvbSIsDQogICAgICAgICJQYWRkaW5nIjogew0KICAgICAgICAgICJUb3AiOiAzLA0KICAgICAgICAgICJSaWdodCI6IDMsDQogICAgICAgICAgIkJvdHRvbSI6IDMsDQogICAgICAgICAgIkxlZnQiOiAzDQogICAgICAgIH0sDQogICAgICAgICJBdXRvU2Nyb2xsTWluU2l6ZSI6IHsNCiAgICAgICAgICAiV2lkdGgiOiAwLA0KICAgICAgICAgICJIZWlnaHQiOiAwDQogICAgICAgIH0sDQogICAgICAgICJWZXJ0aWNhbFNjcm9sbCI6IHsNCiAgICAgICAgICAiRW5hYmxlZCI6IHRydWUNCiAgICAgICAgfSwNCiAgICAgICAgIkhvcml6b250YWxTY3JvbGwiOiB7DQogICAgICAgICAgIkVuYWJsZWQiOiB0cnVlDQogICAgICAgIH0NCiAgICAgIH0sDQogICAgICAiQ29udHJvbHMiOiBbDQogICAgICAgICJCQ2FuY2VsYXIiLA0KICAgICAgICAiQkFjZXB0YXIiDQogICAgICBdDQogICAgfSwNCiAgICB7DQogICAgICAiR3VpZCI6ICJCQ2FuY2VsYXIiLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuQnV0dG9uIiwNCiAgICAgICJEZXNjcmlwdGlvbiI6ICIiLA0KICAgICAgIlZlcnNpb24iOiAiNC42LjEwODcuMCIsDQogICAgICAiQ29uZmlndXJhdGlvbiI6IHsNCiAgICAgICAgIlNpemUiOiB7DQogICAgICAgICAgIldpZHRoIjogMTAxLA0KICAgICAgICAgICJIZWlnaHQiOiAzMA0KICAgICAgICB9LA0KICAgICAgICAiTG9jYXRpb24iOiB7DQogICAgICAgICAgIlgiOiA0MTMsDQogICAgICAgICAgIlkiOiAxNA0KICAgICAgICB9LA0KICAgICAgICAiVGFiSW5kZXgiOiAyLA0KICAgICAgICAiVGV4dCI6ICJDYW5jZWxhciIsDQogICAgICAgICJQYWRkaW5nIjogew0KICAgICAgICAgICJUb3AiOiAzLA0KICAgICAgICAgICJSaWdodCI6IDMsDQogICAgICAgICAgIkJvdHRvbSI6IDMsDQogICAgICAgICAgIkxlZnQiOiAzDQogICAgICAgIH0NCiAgICAgIH0sDQogICAgICAiRXZlbnRzIjogew0KICAgICAgICAiQ2xpY2siOiAiQ29tw7puLkNhbmNlbGFyIGRpw6Fsb2dvIg0KICAgICAgfQ0KICAgIH0sDQogICAgew0KICAgICAgIkd1aWQiOiAiQkFjZXB0YXIiLA0KICAgICAgIlR5cGUiOiAiU3lzdGVtLldpbmRvd3MuRm9ybXMuQnV0dG9uIiwNCiAgICAgICJEZXNjcmlwdGlvbiI6ICIiLA0KICAgICAgIlZlcnNpb24iOiAiNC42LjEwODcuMCIsDQogICAgICAiQ29uZmlndXJhdGlvbiI6IHsNCiAgICAgICAgIlNpemUiOiB7DQogICAgICAgICAgIldpZHRoIjogMTAxLA0KICAgICAgICAgICJIZWlnaHQiOiAzMA0KICAgICAgICB9LA0KICAgICAgICAiTG9jYXRpb24iOiB7DQogICAgICAgICAgIlgiOiA1MjAsDQogICAgICAgICAgIlkiOiAxNA0KICAgICAgICB9LA0KICAgICAgICAiVGFiSW5kZXgiOiAxLA0KICAgICAgICAiVGV4dCI6ICJBY2VwdGFyIiwNCiAgICAgICAgIlBhZGRpbmciOiB7DQogICAgICAgICAgIlRvcCI6IDMsDQogICAgICAgICAgIlJpZ2h0IjogMywNCiAgICAgICAgICAiQm90dG9tIjogMywNCiAgICAgICAgICAiTGVmdCI6IDMNCiAgICAgICAgfQ0KICAgICAgfSwNCiAgICAgICJFdmVudHMiOiB7DQogICAgICAgICJDbGljayI6ICJDb23Dum4uQWNlcHRhciBkacOhbG9nbyINCiAgICAgIH0NCiAgICB9DQogIF0NCn0=";
public JObject MappedView { get { return JObject.Parse(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(_JSON))); } } 
public System.Windows.Forms.Form InputDialog;
public CView.CtrlStruct InputDialog_cstr;
public object InputDialog_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("ARQODE_UI.InputDialog")[var] = value; 
	return (object)view.CtrlVars("ARQODE_UI.InputDialog")[var];
}
public System.Windows.Forms.Panel PContenido;
public CView.CtrlStruct PContenido_cstr;
public object PContenido_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("PContenido")[var] = value; 
	return (object)view.CtrlVars("PContenido")[var];
}
public System.Windows.Forms.Panel PTextBox;
public CView.CtrlStruct PTextBox_cstr;
public object PTextBox_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("PTextBox")[var] = value; 
	return (object)view.CtrlVars("PTextBox")[var];
}
public System.Windows.Forms.TextBox textBox1;
public CView.CtrlStruct textBox1_cstr;
public object textBox1_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("textBox1")[var] = value; 
	return (object)view.CtrlVars("textBox1")[var];
}
public System.Windows.Forms.Panel PLabel;
public CView.CtrlStruct PLabel_cstr;
public object PLabel_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("PLabel")[var] = value; 
	return (object)view.CtrlVars("PLabel")[var];
}
public System.Windows.Forms.Label Label1;
public CView.CtrlStruct Label1_cstr;
public object Label1_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("Label1")[var] = value; 
	return (object)view.CtrlVars("Label1")[var];
}
public System.Windows.Forms.Panel panel1;
public CView.CtrlStruct panel1_cstr;
public object panel1_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("panel1")[var] = value; 
	return (object)view.CtrlVars("panel1")[var];
}
public System.Windows.Forms.Button BCancelar;
public CView.CtrlStruct BCancelar_cstr;
public object BCancelar_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("BCancelar")[var] = value; 
	return (object)view.CtrlVars("BCancelar")[var];
}
public System.Windows.Forms.Button BAceptar;
public CView.CtrlStruct BAceptar_cstr;
public object BAceptar_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("BAceptar")[var] = value; 
	return (object)view.CtrlVars("BAceptar")[var];
}
public CView view; 
public CInputDialog (CViewsManager vm) { view = (vm.getFirstView("ARQODE_UI.InputDialog") != null)? vm.getFirstView("ARQODE_UI.InputDialog"): vm.AddView("ARQODE_UI.InputDialog");
InputDialog = (System.Windows.Forms.Form) view.getCtrl("ARQODE_UI.InputDialog");
InputDialog_cstr = view.getCtrlStruct("ARQODE_UI.InputDialog");
PContenido = (System.Windows.Forms.Panel) view.getCtrl("PContenido");
PContenido_cstr = view.getCtrlStruct("PContenido");
PTextBox = (System.Windows.Forms.Panel) view.getCtrl("PTextBox");
PTextBox_cstr = view.getCtrlStruct("PTextBox");
textBox1 = (System.Windows.Forms.TextBox) view.getCtrl("textBox1");
textBox1_cstr = view.getCtrlStruct("textBox1");
PLabel = (System.Windows.Forms.Panel) view.getCtrl("PLabel");
PLabel_cstr = view.getCtrlStruct("PLabel");
Label1 = (System.Windows.Forms.Label) view.getCtrl("Label1");
Label1_cstr = view.getCtrlStruct("Label1");
panel1 = (System.Windows.Forms.Panel) view.getCtrl("panel1");
panel1_cstr = view.getCtrlStruct("panel1");
BCancelar = (System.Windows.Forms.Button) view.getCtrl("BCancelar");
BCancelar_cstr = view.getCtrlStruct("BCancelar");
BAceptar = (System.Windows.Forms.Button) view.getCtrl("BAceptar");
BAceptar_cstr = view.getCtrlStruct("BAceptar");
 }}

}

