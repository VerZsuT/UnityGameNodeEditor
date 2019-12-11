using Assets.Scripts.Base;
using Assets.Scripts.Nodes;
using Assets.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    /// <summary> Класс компилятора. </summary>
    public class Compilator : MonoBehaviour
    {
        private GameObject nodes;

        [SerializeField] private GameObject compiledCodeField = null;

        private Text compiledCodeText;

        private void Start()
        {
            Manager.Initialize();
            Prefabs.Initialize();

            nodes = GameObject.Find("Nodes");

            compiledCodeText = compiledCodeField.GetComponentInChildren<Text>();
        }

        /// <summary> Компилирует проект и выводит на экран результат. </summary>
        public void Compile()
        {
            FunctionDeclaration[] functionDeclarations = nodes.GetComponentsInChildren<FunctionDeclaration>();

            string text = "";

            foreach (Variable variable in Variables.GetAll())
            {
                text += $"{variable.Type.ToString().ToLower()} {variable.Name} = {variable.Value};\n";
            }

            foreach (var func in functionDeclarations)
            {
                text += func.GetString("");
            }

            compiledCodeText.text = text;

            ToggleField();
        }

        /// <summary> Переключает поле для скомпилированного текста. </summary>
        public void ToggleField()
        {
            compiledCodeField.SetActive(!compiledCodeField.activeSelf);
        }
    }

}