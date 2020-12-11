using System.Reflection;
using UnityEngine;

namespace SandolkakosDigital.CommonUtilities.Editor
{
    public static class DefaultEditorUtility
    {
        /// <summary>
        /// To be called in the OnEnable of CustomInspectors which override the internal ones.
        /// When the inspector is created, also create the built-in inspector.
        /// </summary>
        /// <param name="targets">Internal targets from CustomInspector.</param>
        /// <param name="assemblyClassName">For instance: UnityEditor.TransformInspector</param>
        public static UnityEditor.Editor CreateDefaultEditor(Object[] targets, string assemblyClassName)
        {
            return UnityEditor.Editor.CreateEditor(targets, System.Type.GetType($"{assemblyClassName}, {nameof(UnityEditor)}"));
        }

        /// <summary>
        /// To be called in the OnDisable of CustomInspectors.
        /// </summary>
        /// <param name="defaultEditor">The defaultEditor created in the OnEnable method.</param>
        public static void DestroyDefaultEditor(UnityEditor.Editor defaultEditor)
        {
            // When OnDisable is called, the default editor we created should be destroyed to avoid memory leakage.
            // Also, make sure to call any required methods like OnDisable
            MethodInfo disableMethod = defaultEditor.GetType().GetMethod("OnDisable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (disableMethod != null)
            {
                disableMethod.Invoke(defaultEditor, null);
            }

            Object.DestroyImmediate(defaultEditor);
        }
    }
}