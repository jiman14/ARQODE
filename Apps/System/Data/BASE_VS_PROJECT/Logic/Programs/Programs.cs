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
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TLogic
{
    public class Programs
    {
        Dictionary<String, String> LPrograms;

        public JObject getProgram(String _namespace)
        {
            return ((LPrograms.ContainsKey(_namespace)) && (LPrograms[_namespace] != "")) ? 
                JObject.Parse( System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(LPrograms[_namespace])) ) : null;
        }

        public Programs()
        { 
            LPrograms = new Dictionary<String, String>();            
            // Programs json
        //PROGRAMS
        }

    }
}
#endregion