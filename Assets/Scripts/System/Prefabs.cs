using UnityEngine;

namespace Assets.Scripts.System
{
    /// <summary> Хранит префабы проекта. </summary>
    public static class Prefabs
    {
        /// <summary> Инициализирует префабы. </summary>
        public static void Initialize()
        {
            Menu.Initialize();
            Nodes.Initialize();
            VariableMenu.Initialize();
        }

        /// <summary> Префабы меню. </summary>
        public static class Menu
        {
            public static GameObject Creation { get; private set; }
            public static GameObject Context { get; private set; }
            public static GameObject Variables { get; private set; }
            public static GameObject CreationVariables { get; private set; }
            public static GameObject GetSet { get; private set; }

            public static void Initialize()
            {
                Creation = Resources.Load("Prefabs/Menu/Creation") as GameObject;
                Context = Resources.Load("Prefabs/Menu/Context") as GameObject;
                Variables = Resources.Load("Prefabs/Menu/Variables") as GameObject;
                CreationVariables = Resources.Load("Prefabs/Menu/CreationVariables") as GameObject;
                GetSet = Resources.Load("Prefabs/Menu/GetSet") as GameObject;
            }
        }

        /// <summary> Префабы нод. </summary>
        public static class Nodes
        {
            public static GameObject Branch { get; private set; }
            public static GameObject Print { get; private set; }
            public static GameObject Start { get; private set; }
            public static GameObject VariableGetter { get; private set; }
            public static GameObject VariableSetter { get; private set; }

            public static void Initialize()
            {
                Branch = Resources.Load("Prefabs/Nodes/Branch") as GameObject;
                Print = Resources.Load("Prefabs/Nodes/Print") as GameObject;
                Start = Resources.Load("Prefabs/Nodes/Start") as GameObject;
                VariableGetter = Resources.Load("Prefabs/Nodes/VariableGetter") as GameObject;
                VariableSetter = Resources.Load("Prefabs/Nodes/VariableSetter") as GameObject;
            }
        }

        /// <summary> Префабы меню переменных. </summary>
        public static class VariableMenu
        {
            public static GameObject Button { get; private set; }

            public static void Initialize()
            {
                Button = Resources.Load("Prefabs/VariableMenu/Button") as GameObject;
            }
        }
    }
}
