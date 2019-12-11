using Assets.Scripts.System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary> Класс менеждера горячих клавиш. </summary>
    public class KeyManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                Manager.ContextManager.RenderCreationMenu();
            }
        }
    }

}