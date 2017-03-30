using System; 
using TControls; 
using Newtonsoft.Json.Linq;

namespace TLogic.Views.Main
 { 
public class CMainView
 { 
public static String _JSON { get { return "ew0KICAiJHNjaGVtYSI6ICIuLlxcU2NoZW1hc1xcU2NoZW1hX2Jhc2VfY29udHJvbC5qc29uIiwNCiAgImRlc2NyaXB0aW9uIjogIiIsDQogICJWYXJpYWJsZXMiOiBbDQogICAgIkpTT04gSW1wb3J0YWRvIGRlc2RlIEV4Y2VsIg0KICBdLA0KICAiQ29udHJvbHMiOiBbDQogICAgew0KICAgICAgIkd1aWQiOiAiTWFpblZpZXciLA0KICAgICAgIkNsYXNzX1BhdGgiOiAiIiwNCiAgICAgICJUeXBlIjogIlN5c3RlbS5XaW5kb3dzLkZvcm1zLkZvcm0iLA0KICAgICAgIkRlc2NyaXB0aW9uIjogIiIsDQogICAgICAiVmVyc2lvbiI6ICIxLjAuMC4wIiwNCiAgICAgICJDb25maWd1cmF0aW9uIjogew0KICAgICAgICAiU2l6ZSI6IHsNCiAgICAgICAgICAiV2lkdGgiOiA4MDIsDQogICAgICAgICAgIkhlaWdodCI6IDUxNw0KICAgICAgICB9LA0KICAgICAgICAiVGV4dCI6ICJVdGlsaWRhZGVzIiwNCiAgICAgICAgIlBhZGRpbmciOiB7DQogICAgICAgICAgIlRvcCI6IDMsDQogICAgICAgICAgIlJpZ2h0IjogMywNCiAgICAgICAgICAiQm90dG9tIjogMywNCiAgICAgICAgICAiTGVmdCI6IDMNCiAgICAgICAgfQ0KICAgICAgfSwNCiAgICAgICJDb250cm9scyI6IFtdLA0KICAgICAgIkV2ZW50cyI6IHsNCiAgICAgICAgIkxvYWQiOiAiQ29udm9jYXRvcmlhIGRlIGF5dWRhcy5JbXBvcnRhciBDTkFFIGVuIENvbnZvY2F0b3JpYSINCiAgICAgIH0NCiAgICB9DQogIF0NCn0="; } }
public JObject MappedView { get { return JObject.Parse(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(_JSON))); } } 
public System.Windows.Forms.Form MainView;
public CView.CtrlStruct MainView_cstr;
public object MainView_vars(String var, object value = null) 
{ 
	if (value != null)  view.CtrlVars("Main.MainView")[var] = value; 
	return (object)view.CtrlVars("Main.MainView")[var];
}
public object JSON_Importado_desde_Excel { get { return (view.vars.ContainsKey("JSON Importado desde Excel"))? (object)view.vars["JSON Importado desde Excel"]: null; } set { view.vars["JSON Importado desde Excel"] = value; } }
public CView view; 
public CMainView (CViewsManager vm) { view = (vm.getFirstView("Main.MainView") != null)? vm.getFirstView("Main.MainView"): vm.AddView("Main.MainView");
MainView = (System.Windows.Forms.Form) view.getCtrl("Main.MainView");
MainView_cstr = view.getCtrlStruct("Main.MainView");
 }}

}

