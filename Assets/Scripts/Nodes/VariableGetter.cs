using Assets.Scripts.Base;
using UnityEngine.UI;

namespace Assets.Scripts.Nodes
{
    /// <summary> Нода получения переменной. </summary>
    public class VariableGetter : Node
    {
        private Text variableName;

        private Variable variable;

        /// <summary> Инициализирует ноду. </summary>
        public void Initialize(Variable variable)
        {
            Start();

            variableName = GetComponentInChildren<Text>();

            this.variable = variable;

            variableName.text = variable.Name;
            output.Type = variable.Type;
        }

        public override string GetString(string tabs)
        {
            return variable.Name;
        }
    }
}