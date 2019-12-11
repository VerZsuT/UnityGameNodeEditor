using Assets.Scripts.Base;
using Assets.Scripts.Menu;
using Assets.Scripts.System;
using UnityEngine;
using ContextMenu = Assets.Scripts.Menu.ContextMenu;

namespace Assets.Scripts.Managers
{
    /// <summary> Класс менеджера контекстного меню. </summary>
    public class ContextManager : MonoBehaviour
    {
        private GameObject menu;
        private GameObject nodes;

        private void Start()
        {
            nodes = GameObject.Find("Nodes");

            Prefabs.Initialize();
        }

        /// <summary> Рендерит контекстное меню для переданной ноды. </summary>
        public void RenderContextTo(Node node)
        {
            CreateMenu(Prefabs.Menu.Context);

            menu.GetComponent<ContextMenu>().Initialize(node);
        }

        /// <summary> Рендерит меню создания нод на позиции курсора. </summary>
        public void RenderCreationMenu()
        {
            CreateMenu(Prefabs.Menu.Creation);
        }

        /// <summary> Рендерит меню создания переменных на прежней позиции меню. </summary>
        public void RenderCreationVariableMenu()
        {
            CreateMenu(Prefabs.Menu.CreationVariables, true);
        }

        /// <summary> Рендерит меню переменных на рпежней позиции меню. </summary>
        public void RenderVariablesMenu()
        {
            CreateMenu(Prefabs.Menu.Variables, true);
        }

        /// <summary> Рендерит Get\Set меню переменной. </summary>
        public void RenderGetSetVariableMenu(Variable variable)
        {
            CreateMenu(Prefabs.Menu.GetSet, true);

            menu.GetComponent<GetSetVariableMenu>().Initialize(variable);
        }

        private void CreateMenu(GameObject prefab, bool onMenuPosition = false)
        {
            Vector3 position;

            if (onMenuPosition)
            {
                position = menu.transform.position;
            }
            else
            {
                position = ProjectMath.GetCursorPosition() + new Vector3(0, 0, -1);
            }

            DestroyMenu();

            menu = Instantiate(prefab, position, Quaternion.identity, nodes.transform);
        }

        /// <summary> Удаляет меню. </summary>
        public void DestroyMenu()
        {
            if (menu)
            {
                Destroy(menu);
                menu = null;
            }
        }
    }
}