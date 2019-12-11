using Assets.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Base
{
    /// <summary> Базовый класс пайвота. </summary>
    public class Pivot : Connector
    {
        [SerializeField] protected VariableType type = VariableType.Boolean;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();

            UpdateColor();
        }

        /// <summary> Тип пайвота. </summary>
        public VariableType Type
        {
            get => type;
            set
            {
                type = value;
                UpdateColor();
                //Start();
            }
        }

        /// <summary> Присоединить пайвот к другому. </summary>
        /// <param name="pivot"> Присоединяемый пайвот. </param>
        public void Connect(Pivot pivot)
        {
            Connected = pivot;
        }

        private void UpdateColor()
        {
            image.color = ProjectMath.GetColor(type);
        }

        /// <summary> Возвращает код пайвота в виде строки. </summary>
        public virtual string GetString()
        {
            return "";
        }
    }
}
