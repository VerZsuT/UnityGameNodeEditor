using Assets.Scripts.Base;

namespace Assets.Scripts.Nodes
{
    /// <summary> Нода объявления функции. </summary>
    public class FunctionDeclaration : Node
    {
        public override string GetString(string tabs)
        {
            string other = "";

            if (rightConnectors[0].Connected)
            {
                other = rightConnectors[0].Connected.RootNode.GetString("    ");
            }

            return $"public void {nodeName}()\n{{\n{other}\n}}";
        }
    }

}