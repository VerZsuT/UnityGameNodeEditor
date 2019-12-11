using Assets.Scripts.Base;
using Assets.Scripts.System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    /// <summary> Класс фона. </summary>
    public class Background : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler
    {
        private float speed = 1f;

        private GameObject nodes;

        private Vector3 beforeCursorPosition;

        private void Start()
        {
            nodes = GameObject.Find("Nodes");
        }

        // Event listeners
        public void OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Manager.ConnectManager.StopConnecting();
                Manager.ContextManager.DestroyMenu();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Manager.ContextManager.RenderCreationMenu();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 currentCursorPosition = ProjectMath.GetCursorPosition();
            Vector3 position = currentCursorPosition - beforeCursorPosition;

            nodes.transform.position += new Vector3(position.x * speed, position.y * speed);

            foreach (Node node in nodes.GetComponentsInChildren<Node>())
            {
                node.RenderLines();
            }

            beforeCursorPosition = currentCursorPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            beforeCursorPosition = ProjectMath.GetCursorPosition();
        }
    }

}