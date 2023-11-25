using UnityEditor;
using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
#if UNITY_EDITOR

    using Naukri.InspectorMaid.Editor.Core;

    [CanEditMultipleObjects]
    [CustomEditor(typeof(AttributeSampleBehaviour), true, isFallback = true)]
    public class AttributeSampleBehaviourEditor : InspectorMaidEditor
    {
    }

#endif

    // You can change [MonoBehaviour] to any type you want.
    // e.g. [ScriptableObject], [BoxCollider], or any class that can be displayed in the Inspector.
    public abstract class AttributeSampleBehaviour : MonoBehaviour
    {
    }
}
