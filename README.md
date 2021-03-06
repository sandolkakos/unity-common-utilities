# Common Utilities.

Package with some common utilities for Unity Game Engine.

## How to use
Just copy the link below and add it to your project via Unity Package Manager: [Installing from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
```
https://github.com/sandolkakos/unity-common-utilities.git
```

## SceneHierarchyUtility
Editor functionalities from internal SceneHierarchyWindow and SceneHierarchy classes:

```csharp
// Check if the target GameObject is expanded (aka unfolded) in the Hierarchy view.
SceneHierarchyUtility.IsExpanded(GameObject go)
```

```csharp
// Get a list of all GameObjects which are expanded (aka unfolded) in the Hierarchy view.
SceneHierarchyUtility.GetExpandedGameObjects()
```

```csharp
// Set the target GameObject as expanded (aka unfolded) in the Hierarchy view.
SceneHierarchyUtility.SetExpanded(GameObject go, bool expand)
```

```csharp
// Set the target GameObject and all children as expanded (aka unfolded) in the Hierarchy view.
SceneHierarchyUtility.SetExpandedRecursive(GameObject go, bool expand)
```
----
## DefaultEditorUtility
Useful to create and destroy a default UnityEditor object like TransformEditor, RectTransformEditor when customizing them like the example below:
```csharp
[CustomEditor(typeof(RectTransform), true)]
public class RectTransformCustomInspector : UnityEditor.Editor
{
    // Unity's built-in editor
    private UnityEditor.Editor defaultEditor;
    private RectTransform rectTransform;

    private void OnEnable()
    {
        defaultEditor = DefaultEditorUtility.CreateDefaultEditor(targets, "UnityEditor.RectTransformEditor");
    }

    private void OnDisable()
    {
        DefaultEditorUtility.DestroyDefaultEditor(defaultEditor);
    }

    public override void OnInspectorGUI()
    {
        defaultEditor.OnInspectorGUI();
        
        // Add your RectTransform customizations
    }
}
```
