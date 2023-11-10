using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Layout;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Services.Default
{
    [HideIfScope(nameof(isDrawingSettingsProvider)), ScriptField, EndScope]
    [Slot(nameof(importStyleSheets))]
    internal partial class InspectorMaidSettings : ScriptableObject, IInspectorMaidSettings
    {
        [SerializeField]
        private StyleSheet[] importStyleSheets = new StyleSheet[0];

        public StyleSheet[] ImportStyleSheets => importStyleSheets;
    }

    partial class InspectorMaidSettings
    {
        // to tell inspector maid that we are drawing settings provider,
        // so we will skip the script field at Project Setting Page, but keep it at Inspector.
        private static bool isDrawingSettingsProvider;

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

        [SettingsProvider]
        [SuppressMessage("CodeQuality", "IDE0051")]
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
                    isDrawingSettingsProvider = true;
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
