using Assets.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Base
{
    /// <summary> Базовый класс ноды. </summary>
    public class Node : MonoBehaviour
    {
        /// <summary> Уникальный идентификатор ноды. </summary>
        public string id;

        /// <summary> Тип ноды. </summary>
        public NodeType Type => type;

        [SerializeField] protected NodeType type = NodeType.Function;

        protected LeftConnector[] leftConnectors;
        protected RightConnector[] rightConnectors;

        protected Pivot[] inputs;
        protected OutputPivot output;

        protected string nodeName;

        private Vector3 beforeCursorPosition;

        protected void Start()
        {
            leftConnectors = GetComponentsInChildren<LeftConnector>();
            rightConnectors = GetComponentsInChildren<RightConnector>();

            inputs = GetComponentsInChildren<InputPivot>();
            output = GetComponentInChildren<OutputPivot>();

            nodeName = GetComponentInChildren<Text>().text.TrimEnd();
            id = ProjectMath.GetNodeId();
        }

        /// <summary> Рендерит все линии ноды. </summary>
        public void RenderLines()
        {
            foreach (LeftConnector leftConnector in leftConnectors)
            {
                if (leftConnector.Connected)
                {
                    leftConnector.Connected.DrawLineToConnected();
                }
            }

            foreach (RightConnector rightConnector in rightConnectors)
            {
                rightConnector.DrawLineToConnected();
            }

            if (inputs != null)
            {
                foreach (Pivot input in inputs)
                {
                    if (input.Connected)
                    {
                        input.Connected.DrawLineToConnected();
                    }
                }
            }

            if (output)
            {
                output.DrawLineToConnected();
            }
        }

        /// <summary> Возвращяет код ноды в виде строки. </summary>
        /// <param name="tabs"> Кол-во пробелов в начале. </param>
        public virtual string GetString(string tabs)
        {
            return "";
        }

        // Event listeners
        public void OnBeginDrag()
        {
            beforeCursorPosition = ProjectMath.GetCursorPosition();
        }

        public void OnDrag()
        {
            Vector3 currentCursorPosition = ProjectMath.GetCursorPosition();

            transform.position += currentCursorPosition - beforeCursorPosition;

            RenderLines();

            beforeCursorPosition = currentCursorPosition;
        }

        public void OnPointerDown()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Manager.ContextManager.RenderContextTo(this);
            }
        }

        private void OnDestroy()
        {
            foreach (LeftConnector leftConnector in leftConnectors)
            {
                if (leftConnector.Connected)
                {
                    leftConnector.Connected.Disconnect();
                }
            }

            foreach (RightConnector rightConnector in rightConnectors)
            {
                if (rightConnector.Connected)
                {
                    rightConnector.Connected.Disconnect();
                }
            }

            if (inputs != null)
            {
                foreach (Pivot input in inputs)
                {
                    if (input.Connected)
                    {
                        input.Connected.Disconnect();
                    }
                }
            }

            if (output && output.Connected)
            {
                output.Connected.Disconnect();
            }
        }
    }

}