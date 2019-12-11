using Assets.Scripts.Base;
using Assets.Scripts.System;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    /// <summary> Класс левого (входного) коннектора (стрелки). </summary>
    public class LeftConnector : Connector
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
                Manager.ConnectManager.Connect(this);
            }
        }
    }
}