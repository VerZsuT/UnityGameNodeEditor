using Assets.Scripts.Base;

namespace Assets.Scripts.Nodes
{
    /// <summary> Нода конструкции if. </summary>
    public class Branch : Node
    {
        public override string GetString(string tabs)
        {
            string otherTrue = "";
            string otherFalse = "";
            string condition;

            if (rightConnectors[0].Connected)
            {
                otherTrue = rightConnectors[0].Connected.RootNode.GetString(tabs + "    ");
            }

            if (rightConnectors[1].Connected)
            {
                otherFalse = rightConnectors[1].Connected.RootNode.GetString(tabs + "    ");
            }

            if (inputs[0].Connected)
            {
                OutputPivot connected = (OutputPivot)inputs[0].Connected;
                condition = connected.GetString();
            }
            else
            {
                InputPivot input = inputs[0] as InputPivot;
                condition = input.GetInputValue();
            }

            return $"{tabs}if ({condition})\n{tabs}{{\n{otherTrue}\n{tabs}}}\n{tabs}else\n{tabs}{{\n{otherFalse}\n{tabs}}}";
        }
    }
}
