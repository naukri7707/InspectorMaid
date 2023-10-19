using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public static class HelperExtensions
    {
        private const string kLabel = "label";

        public static int GetArrayIndex(this SerializedProperty serializedProperty)
        {
            var match = Regex.Match(serializedProperty.propertyPath, @"^.*\.Array\.data\[(\d+)\]$");

            if (match.Success)
            {
                string value = match.Groups[1].Value;
                int index = int.Parse(value);
                return index;
            }
            else
            {
                return -1;
            }
        }

        public static string GetLabel(this BindableElement self)
        {
            var type = self.GetType();
            var info = type.GetProperty(kLabel, Utility.AllAccessFlags);
            return (string)info.GetValue(self);
        }

        public static ListView GetListView(this DecoratorElement decorator)
        {
            VisualElement current = decorator;
            while (current != null)
            {
                if (current is ListView listView)
                {
                    return listView;
                }
                current = current.parent;
            }
            return null;
        }

        public static void SetLabel(this BindableElement self, string label)
        {
            var type = self.GetType();
            var info = type.GetProperty(kLabel, Utility.AllAccessFlags);
            info.SetValue(self, label);
        }
    }
}
