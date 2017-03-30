using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using ARQODE_Core;
using TControls;

namespace TLogic
{
    public static class CDataIntegrity
    {

        /// <summary>
        /// Check all inputs in process
        /// </summary>
        /// <returns></returns>
        public static bool CheckAllVariables(TProcess prc, ref TErrors errors)
        {
            bool no_Input_errors = true;
            foreach (JToken input in prc.BaseInputs)
            {
                if ((!input.ToString().StartsWith("-")) && ((prc.Inputs.Count() == 0) || (prc.Inputs[input.ToString()].ToString() == "")))
                {
                    no_Input_errors = false;
                    errors.noInputs = String.Format("Error: no input '{0}' found in current program.", input.ToString());
                }
            }
            bool no_configs_errors = true;
            foreach (JToken conf in prc.BaseConfiguration)
            {
                if ((!conf.ToString().StartsWith("-")) && ((prc.Configuration.Count() == 0) || (prc.Configuration[conf.ToString()].ToString() == "")))
                {
                    no_configs_errors = false;
                    errors.noConfiguration = String.Format("Error: no configuration '{0}' found in current program.", conf.ToString());
                }
            }

            bool no_outputs_errors = true;
            foreach (JToken output in prc.BaseOutputs)
            {
                if ((!output.ToString().StartsWith("-")) && ((prc.Outputs.Count() == 0) || (prc.Outputs[output.ToString()].ToString() == "")))
                {
                    no_outputs_errors = false;
                    errors.noOutputs = String.Format("Error: no output '{0}' found out current program.", output.ToString());
                }
            }

            return (no_Input_errors && no_configs_errors && no_outputs_errors);

        }

    }
}
