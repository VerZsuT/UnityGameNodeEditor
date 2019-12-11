using Assets.Scripts.Base;
using Assets.Scripts.System;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    /// <summary> Меню переменных проекта. </summary>
    public class VariablesMenu : MonoBehaviour
    {
        [SerializeField] private GameObject content = null;

        private int count = 1;

        private Vector3 buttonBasePosition = new Vector3(2, -14, 0);

        private void Start()
        {
            Initialize();
        }

        /// <summary> Рендерит меню создания переменных. </summary>
        public void RenderCreationMenu()
        {
            Manager.ContextManager.RenderCreationVariableMenu();
        }

        /// <summary> Рендерит Get\Set меню. </summary>
        public void RenderGetSetMenu(Variable variable)
        {
            Manager.ContextManager.RenderGetSetVariableMenu(variable);
        }

        private void Initialize()
        {
            foreach (Variable variable in Variables.GetAll())
            {
                GameObject button = Instantiate(Prefabs.VariableMenu.Button, new Vector3(), Quaternion.identity, content.transform);

                button.GetComponent<VariableMenuButton>().Initialize(variable, this);

                buttonBasePosition = button.transform.localPosition = buttonBasePosition + new Vector3(0, -30, 0);

                count++;
            }

            content.GetComponent<RectTransform>().sizeDelta = new Vector3(0, 36 * count);
        }
    }
}
