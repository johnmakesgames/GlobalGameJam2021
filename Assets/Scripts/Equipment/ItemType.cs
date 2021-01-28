using UnityEngine;

/// <summary>
/// <see cref="ItemType"/> describes the data and prefabs required
/// for a single item. Each item is unique (no separate instances)
/// so any item can be fully referred to using a reference to it's
/// <see cref="ItemType"/>.
/// </summary>
[CreateAssetMenu(fileName = "New Item Type", menuName = "GGJ 2021/Item Type")]
public class ItemType : ScriptableObject
{
    [Header("Config")]
    [Tooltip("In-game name for the item.")]
    [SerializeField]
    private string displayName = "";

    [Tooltip("The vibes of the item, determines how AI agents will react to it's presence.")]
    [SerializeField]
    private ItemVibe[] itemVibes = null;

    [Header("Prefabs")]
    [Tooltip("Prefab for the item's equipment game object.")]
    [SerializeField]
    private Equipment equipmentPrefab = null;

    [Tooltip("Prefab for the item's pickup game object.")]
    [SerializeField]
    private Pickup pickupPrefab = null;

    /// <summary>
    /// In-game name for the item.
    /// </summary>
    public string DisplayName { get { return displayName; } }

    /// <summary>
    /// The vibes of the item, determines how AI agents will react to it's presence.
    /// </summary>
    public ItemVibe[] ItemVibes { get { return itemVibes; } }

    /// <summary>
    /// Prefab for the item's equipment game object.
    /// </summary>
    public Equipment EquipmentPrefab { get { return equipmentPrefab; } }

    /// <summary>
    /// Prefab for the item's pickup game object.
    /// </summary>
    public Pickup PickupPrefab { get { return pickupPrefab; } }
}
