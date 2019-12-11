using UnityEngine;

namespace Assets.Scripts.System
{
    /// <summary> Математика проекта. </summary>
    public static class ProjectMath
    {
        private static int count = 0;

        /// <summary> Возвращает положение курсора в 2д пространстве. </summary>
        public static Vector3 GetCursorPosition()
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return new Vector3(cursorPosition.x, cursorPosition.y);
        }

        /// <summary> Возвращает тип переменной по его имени. </summary>
        public static VariableType GetVariableType(string name)
        {
            switch (name.ToLower())
            {
                case "string":
                    return VariableType.String;
                case "integer":
                    return VariableType.Integer;
                case "boolean":
                    return VariableType.Boolean;
                case "object":
                    return VariableType.Object;
                default:
                    return VariableType.String;
            }
        }

        /// <summary> Возвращает цвет относящийся к переданному типу. </summary>
        public static Color32 GetColor(VariableType type)
        {
            switch (type)
            {
                case VariableType.String:
                    return new Color32(231, 47, 227, 255);
                case VariableType.Integer:
                    return new Color32(100, 197, 233, 255);
                case VariableType.Float:
                    return new Color32(112, 231, 47, 255);
                case VariableType.Boolean:
                    return new Color32(231, 60, 47, 255);
                case VariableType.Object:
                default:
                    return new Color32(245, 143, 57, 255);
            }
        }

        /// <summary> Возвращает id для ноды. </summary>
        public static string GetNodeId()
        {
            return $"_func_id_{count++}";
        }
    }
}