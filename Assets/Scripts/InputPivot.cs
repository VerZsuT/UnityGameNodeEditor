using Assets.Scripts.Base;
using Assets.Scripts.System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary> Класс входного пайвота. </summary>
    public class InputPivot : Pivot
    {
        [SerializeField] private GameObject inputField = null;
        [SerializeField] private InputField inputFieldComponent = null;

        [SerializeField] private GameObject text = null;

        [SerializeField] private GameObject inputToggle = null;
        [SerializeField] private Toggle inputToggleComponent = null;

        /// <summary> Возвращает значение по умолчанию. </summary>
        public string GetDefaultValue()
        {
            switch (type)
            {
                case VariableType.String:
                    return "\"Default\"";
                case VariableType.Integer:
                    return "0";
                case VariableType.Float:
                    return "0.0";
                case VariableType.Boolean:
                    return "false";
                default:
                    return "";
            }
        }

        /// <summary> Возвращает значение поля для ввода. </summary>
        public string GetInputValue()
        {
            if (Type == VariableType.String)
            {
                return $"\"{inputFieldComponent.text}\"";
            }
            else if (Type == VariableType.Boolean)
            {
                return $"{inputToggleComponent.isOn.ToString().ToLower()}";
            }
            else
            {
                return inputFieldComponent.text;
            }
        }

        // Event listeners
        public override void OnPointerClick(PointerEventData data)
        {
            if (Connected)
            {
                Connected.Disconnect();
                Disconnect();

                if (inputField)
                {
                    inputField.SetActive(true);
                    text.SetActive(false);
                }
                else if (inputToggle)
                {
                    inputToggle.SetActive(true);
                    text.SetActive(false);
                }
            }
            else
            {
                if (Manager.ConnectManager.Connect(this))
                {
                    if (inputField)
                    {
                        inputField.SetActive(false);
                        text.SetActive(true);
                    }
                    else if (inputToggle)
                    {
                        inputToggle.SetActive(false);
                        text.SetActive(true);
                    }
                }
            }
        }
    }

}