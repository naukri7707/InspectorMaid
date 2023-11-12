using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Layout;
using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Services.Default
{
    // Hide script field at Project Setting Page, but keep it at Inspector.
    [HideIfScope(nameof(isDrawingSettingsProvider)), ScriptField, EndScope]
    // Add support for custom type
    [Divider("Working On")]
    [RowScope]
    [DisableIfScope(nameof(IsSupported), args: typeof(MonoBehaviour))]
    [Button("MonoBehaviour", binding: nameof(AddSupport), args: typeof(MonoBehaviour)), Style(height: "24")]
    [EndScope]
    [DisableIfScope(nameof(IsSupported), args: typeof(ScriptableObject))]
    [Button("ScriptableObject", binding: nameof(AddSupport), args: typeof(ScriptableObject)), Style(height: "24")]
    [EndScope]
    [Spacer, Style(flexGrow: "1")]
    [Button("Custom Type", binding: nameof(AddSupportOfCustomType)), Style(height: "24")]
    [EndScope]
    // Add pre-defined style sheet
    [Divider("Style"), Style(marginTop: "10")]
    [Slot(nameof(importStyleSheets))]
    internal partial class InspectorMaidSettings : ScriptableObject, IInspectorMaidSettings
    {
        [SerializeField]
        private StyleSheet[] importStyleSheets = new StyleSheet[0];

        public StyleSheet[] ImportStyleSheets => importStyleSheets;
    }

    partial class InspectorMaidSettings
    {
        public static InspectorMaidSettings Instance => GetOrCreateSettings();

        private static InspectorMaidSettings GetOrCreateSettings()
        {
            const string kSettingFolderPath = "Assets/Plugins/Naukri/Inspector Maid";
            const string kSettingAssetPath = "Assets/Plugins/Naukri/Inspector Maid/Settings.asset";

            var settings = AssetDatabase.LoadAssetAtPath<InspectorMaidSettings>(kSettingAssetPath);
            if (settings == null)
            {
                settings = CreateInstance<InspectorMaidSettings>();

                var projectFolderPath = Directory.GetParent(Application.dataPath).ToString();
                var folderPath = Path.Combine(projectFolderPath, kSettingFolderPath);

                Directory.CreateDirectory(folderPath);
                AssetDatabase.CreateAsset(settings, kSettingAssetPath);
                AssetDatabase.SaveAssets();
            }
            return settings;
        }
    }

    // UI
    partial class InspectorMaidSettings
    {
        // to tell inspector maid that we are drawing settings provider,
        // so we will skip the script field at Project Setting Page, but keep it at Inspector.
        // - we can't make this field private otherwise Unity will display [CS0414] (value never used) error
        internal static bool isDrawingSettingsProvider;

        private static bool IsSupported(Type supportType)
        {
            var imEditors = TypeCache.GetTypesDerivedFrom<InspectorMaidEditor>();
            foreach (var editor in imEditors)
            {
                var attr = editor.GetCustomAttribute<CustomEditor>();
                var ctype = (Type)attr.GetType().GetField("m_InspectedType", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(attr);
                if (ctype == supportType)
                {
                    return true;
                }
            }
            return false;
        }

        private static void AddSupport(Type supportType)
        {
            var supportTypeName = supportType.Name;
            ScriptFileGenerator.Create($"Assets/Plugins/Naukri/Inspector Maid/Editor/{supportTypeName}CustomEditor.cs", $"Template_{supportTypeName}CustomEditor.cs");
        }

        private static void AddSupportOfCustomType()
        {
            ScriptFileGenerator.CreateByProjectWidnow("InspectorMaidBehaviour.cs", "Template_CustomEditor.cs");
        }

        [SettingsProvider]
        private static SettingsProvider CreateProvider()
        {
            var target = Instance;
            var serializedObject = new SerializedObject(target);
            IEditorEventService editorEventService = null;
            var title = "Inspector Maid";
            var provider = new SettingsProvider($"Project/{title}", SettingsScope.Project)
            {
                label = title,
                keywords = SettingsProvider.GetSearchKeywordsFromSerializedObject(serializedObject),
                activateHandler = (searchContext, rootElement) =>
                {
                    var classContext = InspectorMaidEditor.CreateContextTree(target);
                    var classElement = classContext.Build();
                    isDrawingSettingsProvider = false;

                    editorEventService = IEditorEventService.Of(classContext);
                    EditorApplication.update += editorEventService.InvokeUpdate;

                    var page = new ProjectSettingPage(title, classElement);
                    rootElement.Add(page);

                    // We need to use Bind() after we add classElement to rootElement, otherwise the propertyField in classElement won't show up.
                    rootElement.Bind(serializedObject);
                },
                deactivateHandler = () =>
                {
                    if (editorEventService != null)
                    {
                        EditorApplication.update -= editorEventService.InvokeUpdate;
                        editorEventService.InvokeDestroy();
                    }
                },
                inspectorUpdateHandler = () =>
                {
                    editorEventService?.InvokeSceneGUI();
                }
            };

            return provider;
        }
    }
}
