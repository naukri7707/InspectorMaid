using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace Naukri.InspectorMaid.Editor.Helpers
{
    /// <summary>
    /// Create script from template. <para/>
    /// <para/> Usage:
    /// <example>
    /// <code>
    /// <para/>[MenuItem("Assets/Create/MyFolder/MyScript", false, 89)]
    /// <para/>private static void CreateMyScript()
    /// <para/>{
    /// <para/>    ScriptTemplate.Replace("#MYTAG", "replaceText");
    /// <para/>    ScriptTemplate.Create("MyScriptTemplate.cs", "NewMyScript.cs");
    /// <para/>}
    /// <para/>
    /// <para/>public static void Replace(string srcText, string dstText)
    /// <para/>{
    /// <para/>    replaceList.Add((srcText, dstText));
    /// <para/>}
    /// </code>
    /// </example>
    /// </summary>
    public static class ScriptFileGenerator
    {
        private static Texture2D ScriptIcon => (EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D);

        /// <summary>
        /// Use this method if your template named style is like "Template_MyScript.cs.txt"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void CreateByProjectWidnow<T>()
        {
            var name = typeof(T).Name;
            CreateByProjectWidnow($"New{name}.cs", $"Template_{name}.cs");
        }

        public static void CreateByProjectWidnow(string defaultScriptName, string templateName)
        {
            string[] templateGuids = AssetDatabase.FindAssets(templateName);
            if (templateGuids.Length == 0)
            {
                Debug.LogWarning($"{templateName} not found in asset database");
                return;
            }
            string templatePath = AssetDatabase.GUIDToAssetPath(templateGuids[0]);
            CreateFromTemplate(defaultScriptName, templatePath);
        }

        public static void Create(string scriptFullName, string templateName)
        {
            string[] templateGuids = AssetDatabase.FindAssets(templateName);
            if (templateGuids.Length == 0)
            {
                Debug.LogWarning($"Template: '{templateName}' not found in asset database");
                return;
            }
            string templatePath = AssetDatabase.GUIDToAssetPath(templateGuids[0]);
            CreateScriptFile(scriptFullName, templatePath);
        }

        private static void CreateFromTemplate(string scriptName, string templatePath)
        {
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                0,
                ScriptableObject.CreateInstance<CodeFileCreator>(),
                scriptName,
                ScriptIcon,
                templatePath
                );
        }

        private static Object CreateScriptFile(string scriptFullName, string templatePath)
        {
            var directoryPath = Path.GetDirectoryName(scriptFullName);

            Directory.CreateDirectory(directoryPath);

            var className = Path.GetFileNameWithoutExtension(scriptFullName).Replace(" ", string.Empty);

            var encoding = new UTF8Encoding(true, false);

            if (File.Exists(templatePath))
            {
                var reader = new StreamReader(templatePath);
                var templateText = reader.ReadToEnd();
                reader.Close();

                templateText = templateText.Replace("#SCRIPTNAME#", className);
                templateText = templateText.Replace("#NOTRIM#", string.Empty);

                StreamWriter writer = new StreamWriter(Path.GetFullPath(scriptFullName), false, encoding);
                writer.Write(templateText);
                writer.Close();

                AssetDatabase.ImportAsset(scriptFullName);
                return AssetDatabase.LoadAssetAtPath(scriptFullName, typeof(Object));
            }
            else
            {
                Debug.LogError($"The template file was not found: {templatePath}");
                return null;
            }
        }

        private class CodeFileCreator : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                var obj = CreateScriptFile(pathName, resourceFile);
                ProjectWindowUtil.ShowCreatedAsset(obj);
            }
        }
    }
}
