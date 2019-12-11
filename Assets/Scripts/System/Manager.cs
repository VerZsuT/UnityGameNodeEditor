using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.System
{
    public static class Manager
    {
        /// <summary> Контролирует приблежение камеры. </summary>
        public static CameraManager CameraManager { get; private set; }

        /// <summary> Отвечает за компиляцию проекта. </summary>
        public static Compilator Compilator { get; private set; }

        /// <summary> Отвечает за присоединение нод. </summary>
        public static ConnectManager ConnectManager { get; private set; }

        /// <summary> Отвечает за создания контекстного меню. </summary>
        public static ContextManager ContextManager { get; private set; }

        /// <summary> Отвечает за горячие клавиши. </summary>
        public static KeyManager KeyManager { get; private set; }

        /// <summary> Инициализирует объект. </summary>
        public static void Initialize()
        {
            CameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
            Compilator = GameObject.Find("Compilator").GetComponent<Compilator>();
            ConnectManager = GameObject.Find("ConnectManager").GetComponent<ConnectManager>();
            ContextManager = GameObject.Find("ContextManager").GetComponent<ContextManager>();
            KeyManager = GameObject.Find("KeyManager").GetComponent<KeyManager>();
        }
    }
}
