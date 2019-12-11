using Assets.Scripts.System;

namespace Assets.Scripts.Base
{
    /// <summary> Класс переменной. </summary>
    public class Variable
    {
        /// <summary> Имя переменной. </summary>
        public string Name { get; private set; }

        /// <summary> Значение переменной. </summary>
        public string Value { get; private set; }

        /// <summary> Тип переменной. </summary>
        public VariableType Type { get; private set; }

        /// <summary> Создаёт переменную и инициализирует её. </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="type"> Тип. </param>
        /// <param name="defaultValue"> Значение по умолчанию. </param>
        public Variable(string name, VariableType type, string defaultValue = "null")
        {
            Name = name;
            Type = type;
            Value = defaultValue;
        }

        /// <summary> Устанавливает новое значение переменной. </summary>
        public void SetValue(string value)
        {
            if (Type == VariableType.String)
            {
                Value = $"\"{value}\"";
            }
        }
    }

}