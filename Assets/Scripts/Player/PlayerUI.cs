using UnityEngine;

/// <summary>
/// <see cref="PlayerUI"/> is responsible for spawning the 
/// <see cref="UIWidget"/>s required by the player.
/// </summary>
public class PlayerUI : MonoBehaviour
{
    [Tooltip("The UI widgets to spawn.")]
    [SerializeField]
    public UIWidget[] widgetPrefabs = null;

    private void Awake()
    {
        // Spawn each widget with ourself as the owner.
        foreach (UIWidget prefab in widgetPrefabs)
        {      
            UIWidgetFactory.SpawnUIWidget(prefab, gameObject);
        }
    }
}
