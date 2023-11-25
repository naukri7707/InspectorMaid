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
    [
    // Hide script field at Project Setting Page, but keep it at Inspector.
    ScriptField,
        HideIf(nameof(isDrawingSettingsProvider)),
    // Add support for custom type
    Divider("Working On"),
    RowScope,
        Button("MonoBehaviour", binding: nameof(AddSupport), args: new object[] { typeof(MonoBehaviour) }),
            Style(height: "24"),
            DisableIf(nameof(IsSupported), args: new object[] { typeof(MonoBehaviour) }),
        Button("ScriptableObject", binding: nameof(AddSupport), args: new object[] { typeof(ScriptableObject) }),
            Style(height: "24"),
            DisableIf(nameof(IsSupported), args: new object[] { typeof(ScriptableObject) }),
        Spacer,
            Style(flexGrow: "1"),
        Button("Custom Type", binding: nameof(AddSupportOfCustomType)),
            Style(height: "24"),
    EndScope,
    // Add pre-defined style sheet
    Divider("Style"),
       Style(marginTop: "10"),
    Slot(nameof(importStyleSheets))
    ]
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
            ICallbackService editorEventService = null;
            var title = "Inspector Maid";
            var provider = new SettingsProvider($"Project/{title}", SettingsScope.Project)
            {
                label = title,
                keywords = SettingsProvider.GetSearchKeywordsFromSerializedObject(serializedObject),
                activateHandler = (searchContext, rootElement) =>
                {
                    isDrawingSettingsProvider = true;
                    var classContext = InspectorMaidUtility.CreateClassContext(target, serializedObject.GetIterator());
                    var classElement = classContext.Build();

                    // Register callbacks
                    editorEventService = ICallbackService.Of(classContext);
                    editorEventService.RegisterCallback(classElement);

                    // Wrap classElement with ProjectSettingPage and add it to rootElement
                    var page = new ProjectSettingPage(title, classElement);
                    rootElement.Add(page);

                    // We need to use Bind() after we add classElement to rootElement, otherwise the propertyField in classElement won't show up.
                    rootElement.Bind(serializedObject);
                },
                deactivateHandler = () =>
                {
                    // We need to set isDrawingSettingsProvider to false after we remove classElement from rootElement,
                    // otherwise the script field will show up at Project Settings.
                    isDrawingSettingsProvider = false;
                }
            };

            return provider;
        }
    }
}
