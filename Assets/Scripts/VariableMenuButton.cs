using Assets.Scripts.Base;
using Assets.Scripts.Menu;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary> Кнопка меню переменных. </summary>
    public class VariableMenuButton : MonoBehaviour, IPointerDownHandler
    {
        private Variable variable;

        [SerializeField] private Text buttonName = null;

        private VariablesMenu variablesMenu;

        /// <summary> Инициализирует кнопку. </summary>
        public void Initialize(Variable variable, VariablesMenu variablesMenu)
        {
            this.variable = variable;
            this.variablesMenu = variablesMenu;
            buttonName.text = variable.Name;
        }

        // Event listeners
        public void OnPointerDown(PointerEventData eventData)
        {
            variablesMenu.RenderGetSetMenu(variable);
        }
    }
}
