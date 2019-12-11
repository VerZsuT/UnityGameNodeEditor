using Assets.Scripts.Base;
using Assets.Scripts.Nodes;
using Assets.Scripts.System;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    /// <summary> Get\Set меню переменной. </summary>
    public class GetSetVariableMenu : MonoBehaviour
    {
        private Variable variable;

        private GameObject nodes;

        private void Start()
        {
            nodes = GameObject.Find("Nodes");
        }

        /// <summary> Инициализирует меню. </summary>
        public void Initialize(Variable variable)
        {
            this.variable = variable;
        }

        /// <summary> Рендерит Getter переменной. </summary>
        public void RenderVariableGetter()
        {
            VariableGetter node = Render(Prefabs.Nodes.VariableGetter).GetComponent<VariableGetter>();

            node.Initialize(variable);

            Manager.ContextManager.DestroyMenu();
        }

        /// <summary> Рендерит Setter переменной. </summary>
        public void RenderVariableSetter()
        {
            VariableSetter node = Render(Prefabs.Nodes.VariableSetter).GetComponent<VariableSetter>();

            node.Initialize(variable);

            Manager.ContextManager.DestroyMenu();
        }

        private GameObject Render(GameObject prefab)
        {
            Vector3 position = transform.position + new Vector3(0, 0, 1);

            return Instantiate(prefab, position, Quaternion.identity, nodes.transform);
        }
    }
}
