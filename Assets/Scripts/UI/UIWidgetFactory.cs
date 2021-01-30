using UnityEngine;

public class UIWidgetFactory : ScriptableObject
{
    /// <summary>
    /// Spawns and initializes a <see cref="UIWidget"/>.
    /// </summary>
    public static UIWidget SpawnUIWidget(UIWidget prefab, GameObject owner, Transform parent = null)
    {
        if(prefab != null)
        {
            UIWidget widget = Instantiate(prefab, parent);
            if(widget != null)
            {
                widget.InitializeWidget(owner);
                return widget;
            }
        }

        return null;
    }
}
