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

namespace ARQODE_Core
{

    public static class dGLOBALS
    {
        public static string ARQODE = "ARQODE";
        public static string ARQODE_Manager = "ARQODE_Manager";
        public static string SYSTEM_APP = "System";
        public static string ACTIVE_APP = "Active app";
        public static string GLOBALS = "Globals";
        public static string APPS = "Apps";
        public static string APPDATA_PATH = "AppData";
        public static string DATA_PATH = "Data";
        public static string BASE_VS_PROJECT_PATH = "BASE_VS_PROJECT";
        public static string BASE_APP = "BASE_APP";        
        public static string BASE_VS_PROJECT_MAIN = "Program.cs";
        public static string VS_PROJECT_NAME = "%APP_NAME%";
        public static string VS_PROJECT_PATH = "VS_PROJECT";
        public static string VS_PROJECT_FILE = "VS_PROJECT.csproj";
        public static string RESOURCES_PATH = "Resources";
        public static string ASSEMBLIES_PATH = "Dll";
        public static string MAIN_VIEW = "Main view";
        public static string CRON_INTERVAL = "Cron interval (ms)";
        public static string MAPS_VIEWS = "ViewsMaps_{0}.json";
        public static string MAPS_PROCESS = "mprocess.txt";
        public static string MAPS_PROCESSES = "CProcesses.cs";
        public static string MAPS_PROGRAM = "mprogram.json";
        public static string MAPS_GLOBALS = "mglobals.json";
        public static string PROGRAM_TEMPLATE = "base_program.json";
        public static string PROCESS_TEMPLATE = "base_process.json";
        public static string CRON_CALL_TEXT = "CRON CALL";
    }
    public static class dEXPORTCODE
    {
        public static string VS_PROGRAMS_PATH = @"Logic\Programs";
        public static string VS_PROGRAMS_CS = "Programs.cs";
        public static string VS_PROGRAMS_CS_REP = "//PROGRAMS";
        public static string VS_PJ_PROYECT_NODE = "Project";
        public static string VS_PJ_ITEM_GROUP = "ItemGroup";
        public static string VS_PJ_ITEM_COMPILE = "Compile";
        public static string VS_PJ_ITEM_COMPILE_DEP = "DependentUpon";
        public static string VS_PJ_ITEM_COMPILE_SUBTYPE = "SubType";
        public static string VS_PJ_ATT_INCLUDE = "Include";
        public static string VS_PJ_DESIGNER_SUF = ".Designer.cs";
        public static string VS_PJ_UI_PATH = "UI";
        public static string ARQODE_PJ_UI_PATH = "System\\App\\UI";
        public static string VS_CODE_PATH = "Logic\\Code";
        public static string F_FUNCTIONS = "#FUNCTIONS#";
        public static string F_BASE_PROCESSES = "#BASE_PROCESSES#";
        public static string F_TEMPLATE = "\t\t\t/// #NAME#: #DESCRIPTION#\n\t\t\tpublic void f_#FUNCTION_NAME#()\n\t\t\t{\n\t\t\t#CODE#\n\t\t\t}\n\n";
        public static string F_NAME = "#NAME#";
        public static string F_DESCRIPTION = "#DESCRIPTION#";
        public static string F_FUNCTION_NAME = "#FUNCTION_NAME#";
        public static string F_CODE = "#CODE#";
        public static string VIEW_MAP_CS_SUFIX = "_map.cs";
        public static string VIEWS_MAPS_CLASSES = "classes";
        public static string VIEWS_MAPS_TIMESTAMP = "TimeStamp";
        public static string VIEWS_MAPS_ITEM = "Maps";
        public static string VIEWS_MAPS_PATH = @"AppData\Maps";
        public static string STR_IMPORT_CONVS = "ImportConvs.json";

        public static string P_Ini_code_process_mark= "//INI CODE PRCGUID: ";
		public static string P_End_code_process_mark= "//END CODE PRCGUID: ";
		public static string P_Begin_editor_code_mark= "#region BEGIN_CODE";
		public static string P_End_editor_code_mark= "#endregion END_CODE";
		public static string P_End_logic_code= "//END LOGIC";
        public static string P_CODER_CS = @"Coder\Coder.cs";
        public static string P_LOGIC_CS = @"Logic\Code\CProcesses.cs";
    }
}
#endregion