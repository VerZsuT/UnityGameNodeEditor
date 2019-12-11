using Assets.Scripts.Base;
using Assets.Scripts.System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary> Класс менеджера присоединения. </summary>
    public class ConnectManager : MonoBehaviour
    {
        private Connector selectedConnector;
        private Pivot selectedPivot;

        private bool isConnecting = false;

        private void Update()
        {
            if (isConnecting)
            {
                Vector3 cursorPosition = ProjectMath.GetCursorPosition();

                if (selectedConnector)
                {
                    selectedConnector.DrawLineToPosition(cursorPosition);
                }
                else if (selectedPivot)
                {
                    selectedPivot.DrawLineToPosition(cursorPosition);
                }
            }
        }

        /// <summary> Присоединяет выбранный коннектор к передаваемому. </summary>
        public void Connect(Connector connector)
        {
            if (selectedConnector && selectedConnector != connector)
            {
                selectedConnector.ConnectAndDrawLine(connector);
                connector.Connect(selectedConnector);

                isConnecting = false;
                selectedConnector = null;
            }
        }

        /// <summary> Присоединяет выбранный пайвот к переданному. </summary>
        /// <returns> Успешность присоединения. </returns>
        public bool Connect(Pivot pivot)
        {
            if (selectedPivot && selectedPivot != pivot && selectedPivot.Type == pivot.Type)
            {
                selectedPivot.ConnectAndDrawLine(pivot);
                pivot.Connect(selectedPivot);

                isConnecting = false;
                selectedPivot = null;

                return true;
            }

            return false;
        }

        /// <summary> Выбрает коннектор как присоединяемый и входит в режим присоединения. </summary>
        public void SelectToConnect(Connector connector)
        {
            if (!isConnecting && !selectedConnector)
            {
                selectedConnector = connector;
                isConnecting = true;
            }
        }


        /// <summary> Выбирает пайвот как присоединяемый и входит в режим присоединения. </summary>
        public void SelectToConnect(Pivot pivot)
        {
            if (!isConnecting && !selectedPivot)
            {
                selectedPivot = pivot;
                isConnecting = true;
            }
        }

        /// <summary> Обнуляет выбранный коннектор\пайвот и выходит из режима присоединения. </summary>
        public void StopConnecting()
        {
            if (isConnecting)
            {
                if (selectedConnector)
                {
                    selectedConnector.DestroyLine();

                    selectedConnector = null;
                }
                else if (selectedPivot)
                {
                    selectedPivot.DestroyLine();

                    selectedPivot = null;
                }

                isConnecting = false;
            }
        }
    }
}
