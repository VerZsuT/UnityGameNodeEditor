using Assets.Scripts.Base;
using System.Collections.Generic;

namespace Assets.Scripts.System
{
    /// <summary> Отвечает за переменные в проекте. </summary>
    public static class Variables
    {
        /// <summary> Переменные проекта. </summary>
        private static List<Variable> list = new List<Variable>();

        /// <summary> Получить список переменных. </summary>
        public static List<Variable> GetAll()
        {
            return list;
        }

        /// <summary> Создать переменную. </summary>
        /// <param name="name"> Имя переменной. </param>
        /// <param name="type"> Тип переменной. </param>
        /// <param name="defaultValue"> Значение переменной по умолчанию. </param>
        public static void CreateVariable(string name, VariableType type, string defaultValue = "null")
        {
            Variable variable = new Variable(name, type, defaultValue);

            foreach (Variable vr in list)
            {
                if (vr.Name == variable.Name)
                {
                    return;
                }
            }

            list.Add(new Variable(name, type, defaultValue));
        }

        /// <summary> Найти переменную по имени. </summary>
        /// <param name="name"> Имя переменной. </param>
        public static Variable Find(string name)
        {
            foreach (Variable variable in list)
            {
                if (variable.Name == name)
                {
                    return variable;
                }
            }

            return null;
        }

        /// <summary> Найти первую переменную по типу. </summary>
        /// <param name="type"> Тип переменной. </param>
        public static Variable Find(VariableType type)
        {
            foreach (Variable variable in list)
            {
                if (variable.Type == type)
                {
                    return variable;
                }
            }

            return null;
        }
    }
}
