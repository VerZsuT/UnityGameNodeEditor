using Assets.Scripts.Base;
using Assets.Scripts.System;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    /// <summary> Контекстное меню ноды. </summary>
    public class ContextMenu : MonoBehaviour
    {
        private Node node;

        /// <summary> Инициализирует меню. </summary>
        /// <param name="node"> Нода, к которой меню привязано. </param>
        public void Initialize(Node node)
        {
            this.node = node;
        }

        /// <summary> Удаляет со сцены привязанную ноду и закрыть меню. </summary>
        public void DestroyNode()
        {
            if (node)
            {
                Destroy(node.gameObject);
            }

            Manager.ContextManager.DestroyMenu();
        }
    }
}
