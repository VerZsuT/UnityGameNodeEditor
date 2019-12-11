using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Base
{
    /// <summary> Базовый класс коннектора. </summary>
    public class Connector : MonoBehaviour, IPointerClickHandler
    {
        /// <summary> Ссылка на ноду-родителя. </summary>
        public Node RootNode { get; private set; }

        /// <summary> Ссылка на присоединённый коннектор. </summary>
        public Connector Connected { get; protected set; }

        protected LineRenderer line;

        private void Awake()
        {
            RootNode = GetComponentInParent<Node>();

            TryGetComponent(out line);
        }

        /// <summary> Присоединяет коннектор к данному и рисует линию к нему. </summary>
        /// <param name="connector"> Присоединяемый коннектор. </param>
        public void ConnectAndDrawLine(Connector connector)
        {
            Connected = connector;
            DrawLineToConnector(connector);
        }

        /// <summary> Присоединяет коннектор к данному. </summary>
        /// <param name="connector"> Присоединяемый коннектор. </param>
        public void Connect(Connector connector)
        {
            Connected = connector;
        }

        /// <summary> Отсоединяет коннектор и удаляет линию. </summary>
        public void Disconnect()
        {
            Connected = null;
            DestroyLine();
        }

        /// <summary> Рисует линию к позиции. </summary>
        public void DrawLineToPosition(Vector3 position)
        {
            Vector3[] positions = { transform.position, position };

            if (!line)
            {
                TryGetComponent(out line);
            }

            line.SetPositions(positions);
        }

        /// <summary> Рисует линию к позиции конектора. </summary>
        public void DrawLineToConnector(Connector connector)
        {
            Vector3 otherNodePosition = connector.transform.position;

            Vector3[] positions = { transform.position, otherNodePosition };

            line.SetPositions(positions);
        }

        /// <summary> Удаляет линию. </summary>
        public void DestroyLine()
        {
            if (line)
            {
                line.positionCount = 0;
                line.positionCount = 2;
            }
        }

        /// <summary> Рисует линию к присоединённому коннектору. </summary>
        public void DrawLineToConnected()
        {
            if (Connected)
            {
                DrawLineToConnector(Connected);
            }
        }

        // Event listeners
        virtual public void OnPointerClick(PointerEventData data) { }
    }
}