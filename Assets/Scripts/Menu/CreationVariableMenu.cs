using Assets.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    /// <summary> Класс меню создания переменных. </summary>
    public class CreationVariableMenu : MonoBehaviour
    {
        [SerializeField] private InputField nameField = null;
        [SerializeField] private Text typeText = null;

        // Event listeners
        public void OnCreationButtonClick()
        {
            string name = nameField.text;
            VariableType type = ProjectMath.GetVariableType(typeText.text);

            Variables.CreateVariable(name, type);

            Manager.ContextManager.RenderVariablesMenu();
        }
    }
}
