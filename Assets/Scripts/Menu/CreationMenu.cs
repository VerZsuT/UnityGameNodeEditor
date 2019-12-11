using Assets.Scripts.System;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    /// <summary> Меню создания нод. </summary>
    public class CreationMenu : MonoBehaviour
    {
        private GameObject nodes;

        private void Start()
        {
            nodes = GameObject.Find("Nodes");
        }

        /// <summary> Создаёт ноду на позиции курсора и закрывает меню. </summary> 
        /// <param name="name"> Имя префаба. </param>
        public void Create(string name)
        {
            GameObject objectPrefab = Resources.Load($"Prefabs/Nodes/{name}") as GameObject;

            Vector3 position = transform.position + new Vector3(0, 0, 1);

            Instantiate(objectPrefab, position, Quaternion.identity, nodes.transform);

            Manager.ContextManager.DestroyMenu();
        }

        public void Create(GameObject prefab)
        {
            GameObject objectPrefab = Resources.Load($"Prefabs/Nodes/{name}") as GameObject;

            Vector3 position = transform.position + new Vector3(0, 0, 1);

            Instantiate(objectPrefab, position, Quaternion.identity, nodes.transform);

            Manager.ContextManager.DestroyMenu();
        }

        /// <summary> Рендерит меню переменных. </summary>
        public void RenderVariablesMenu()
        {
            Manager.ContextManager.RenderVariablesMenu();
        }
    }
}
