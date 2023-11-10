using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Helpers
{
    public static class ScriptTemplates
    {
        [MenuItem("Assets/Create/Inspector Maid/Custom Editor", false, 79)]
        public static void CreateCustomEditor()
        {
            ScriptFileGenerator.CreateByProjectWidnow("CustomEditor.cs", "CustomEditor.cs");
        }
    }
}
