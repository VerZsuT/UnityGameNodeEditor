using Assets.Scripts.Base;
using Assets.Scripts.System;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    /// <summary> Класс выходного пайвота. </summary>
    public class OutputPivot : Pivot
    {
        public override void OnPointerClick(PointerEventData data)
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

        public override string GetString()
        {
            if (RootNode.Type == NodeType.Variable)
            {
                return RootNode.GetString("");
            }

            return RootNode.id;
        }
    }
}
