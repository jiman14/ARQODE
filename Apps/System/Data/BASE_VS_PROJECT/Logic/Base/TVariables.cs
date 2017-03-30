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

namespace TLogic
{

    public static class dPATH
    {
        public static string CODE = "AppData.Code";
        public static string PROGRAM = "AppData.Code.Programs";
        public static string PROCESSES = "AppData.Code.Processes";
        public static string TRACER = "Data.Tracer";
        public static string DEBUG = "Data.Debug";
        public static string ERRORS = "Data.Errors";
        public static string MAPS = "AppData.Maps";
        public static string VIEWS = "AppData.Views";
        public static string DLL = "AppData.Dll";
    }
    public static class dPROGRAM
    {
        public static string FOLDER = "Programs";
        public static string GUID = "Guid";
        public static string NAME = "Name";
        public static string PARALLEL_EXECUTION = "Parallel_execution";        
        public static string NAMESPACE = "Namespace";
        public static string PROCESSES = "processes";        
        public static string DESCRIPTION = "Description";
        public static string VERSION = "Version";
        public static string VARIABLES = "Variables";
        public static string LOGIC = "Logic";
        public static string CONFIGURATION = "Configuration";
        public static string INPUTS = "Inputs";
        public static string OUTPUTS = "Outputs";
    }
    public static class dPROCESS
    {
        public static string FOLDER = "Processes";
        public static string GUID = "Guid";
        public static string EDIT_CODE = "Edit_code";
        public static string NAME = "Name";
        public static string NAMESPACE = "Namespace";
        public static string PROCESSES = "processes";
        public static string DESCRIPTION = "Description";
        public static string VERSION = "Version";
        public static string DEFAULT_CONFIGURATION = "Default_Configuration";
        public static string CONFIGURATION = "Configuration";
        public static string INPUTS = "Inputs";
        public static string OUTPUTS = "Outputs";
        public static string TOTAL_TIME = "Total_time";
        public static string DEBUG_INFO = "Debug_info";

    }
    public static class dERROR
    {
        public static string NAME = "Name";
        public static string NAMESPACE = "Namespace";        
        public static string DESCRIPTION = "Description";
        public static string STATUS = "Status";
        public static string ERRORS = "Errors";
        public static string ERROR_TIME = "Error_time";
        public static string PROCESS_INFO = "Process";
        public static string ERROR = "Error";

    }
    public static class dDEBUG
    {
        public static string NAME = "Name";
        public static string NAMESPACE = "Namespace";
        public static string PROCESSES = "processes";
        public static string DESCRIPTION = "Description";
        public static string STATUS = "Status";
        public static string TOTAL_TIME = "Total_time";
        public static string LAST_EXECUTION_TIME = "Last_execution_time";
        
    }
    public static class dTRACER
    {
        public static string GLOBAL_STATUS = "Global_status";
        public static string GLOBAL_DATE = "Global_date";
        public static string DATE = "Date";
        public static string INFO = "Info";
        public static string TRACES = "Traces";
    }
}
#endregion