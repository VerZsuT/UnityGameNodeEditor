using Assets.Scripts.Base;
using UnityEngine.UI;

namespace Assets.Scripts.Nodes
{
    /// <summary> Нода установки переменной. </summary>
    public class VariableSetter : Node
    {
        private Text variableName;
        private InputField inputField;

        private Variable variable;

        /// <summary> Инициализирует ноду. </summary>
        public void Initialize(Variable variable)
        {
            Start();

            this.variable = variable;

            variableName = GetComponentInChildren<Text>();
            inputField = GetComponentInChildren<InputField>();

            variableName.text = $"Set ({variable.Name})";
            inputs[0].Type = variable.Type;
        }

        public override string GetString(string tabs)
        {
            string other = "";
            string result = inputField.text;

            if (rightConnectors[0].Connected)
            {
                other = rightConnectors[0].Connected.RootNode.GetString(tabs);
            }

            if (inputs[0].Connected)
            {
                result = inputs[0].GetString();
            }
            else
            {
                if (inputField.text != "")
                {
                    result = inputField.text;
                }
                else
                {
                    result = "null";
                }
            }

            return $"{tabs}{variable.Name} = {result};\n{other}";
        }
    }
}
