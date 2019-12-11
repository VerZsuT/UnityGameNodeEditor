using Assets.Scripts.Base;
using System.Collections.Generic;

namespace Assets.Scripts.Nodes
{
    /// <summary> Функциональная нода. </summary>
    public class Function : Node
    {
        public override string GetString(string tabs)
        {
            string other = null;

            if (rightConnectors[0].Connected)
            {
                other = rightConnectors[0].Connected.RootNode.GetString(tabs);
            }

            string input = "";

            if (inputs != null)
            {
                List<string> vs = new List<string>();

                foreach (InputPivot inputPivot in inputs)
                {
                    if (inputPivot.Connected)
                    {
                        OutputPivot connected = (OutputPivot)inputPivot.Connected;
                        vs.Add(connected.GetString());
                    }
                    else
                    {
                        vs.Add(inputPivot.GetInputValue());
                    }
                }

                for (int i = 0; i < vs.Count; i++)
                {
                    if (i > 0)
                    {
                        input += $", {vs[i]}";
                    }
                    else
                    {
                        input += $"{vs[i]}";
                    }
                }
            }

            if (output && output.Connected)
            {
                return $"{tabs}{output.Type.ToString().ToLower()} {id} = {nodeName}({input});\n{other}";
            }
            else
            {
                if (other != null)
                {
                    return $"{tabs}{nodeName}({input});\n{other}";
                }
                else
                {
                    return $"{tabs}{nodeName}({input});";
                }

            }
        }
    }
}