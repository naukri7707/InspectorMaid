using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public partial class InspectorMaidSettings : ScriptableObject
    {
        public StyleSheet[] importStyleSheets = new StyleSheet[0];

        public int maxNestingDepth = 7;
    }

    partial class InspectorMaidSettings
    {
        public static InspectorMaidSettings Instance => GetOrCreateSettings();

        [SettingsProvider]
        internal static SettingsProvider CreateFromSettingsFromFunctor()
        {
            var settings = GetOrCreateSettings();
            var settingsSO = new SerializedObject(settings);
            var provider = AssetSettingsProvider.CreateProviderFromObject(
                settingsWindowPath: "Project/Inspector Maid",
                settingsObj: settings,
                keywords: new[] { "Inspector Maid", "Inspector", "Maid", "IM" }
                );

            // Register keywords from the properties
            provider.keywords = SettingsProvider.GetSearchKeywordsFromSerializedObject(settingsSO);

            return provider;
        }

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

    [CustomEditor(typeof(InspectorMaidSettings))]
    internal class InspectorMaidSettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            using var change = new EditorGUI.ChangeCheckScope();

            var current = serializedObject.GetIterator();
            if (current.NextVisible(true))
            {
                do
                {
                    if (current.name == "m_Script")
                    {
                        continue;
                    }
                    EditorGUILayout.PropertyField(current, true);
                } while (current.NextVisible(false));
            }

            if (change.changed)
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
