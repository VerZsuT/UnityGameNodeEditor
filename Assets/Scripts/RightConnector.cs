using Assets.Scripts.Base;
using Assets.Scripts.System;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    /// <summary> Класс правого (выходного) коннектора (стрелки). </summary>
    public class RightConnector : Connector
    {
        override public void OnPointerClick(PointerEventData data)
        {
            if (Connected)
            {
                Connected.Disconnect();
                Disconnect();
            }
            else
            {
                Manager.ConnectManager.SelectToConnect(this);
            }
        }
    }
}